using Cyotek.Windows.Forms;
using RestSharp;
using System.Reflection;

namespace QRGen
{
	/// <summary>
	/// The static Util class which possesses several utilities used throughout the program.
	/// </summary>
	public static class Util
	{
		/// <summary>
		/// Converts a .NET Color class to a Hex string.
		/// </summary>
		/// <param name="c">Color to be converted.</param>
		/// <param includeHashtag="c">Whether or not to include a hashtag in front of the hex string.</param>
		/// <returns>Color Hex string.</returns>
		public static string ColorToHex(Color c, bool includeHashtag = false)
		{
			return $"{(includeHashtag ? "#" : "")}{c.R:X2}{c.G:X2}{c.B:X2}";
		}

		/// <summary>
		/// Converts a hex string to a .NET Color.
		/// </summary>
		/// <param name="hexColor">Color hex string to be converted.</param>
		/// <param name="fallback">Fallback color if hexColor is invalid. Defaults to Color.Empty.</param>
		/// <returns>The parsed Color or fallback (Color.Empty if not provided).</returns>
		public static Color HexToColor(string hexColor, Color? fallback = null)
		{
			if (!hexColor.StartsWith('#'))
			{
				hexColor.Prepend('#');
			}
			try
			{
				return ColorTranslator.FromHtml(hexColor);
			}
			catch
			{
				return fallback ?? Color.Empty;
			}
		}

		/// <summary>
		/// Creates a darkmode-compatible Cyotek Color Picker.
		/// </summary>
		/// <param name="doAlpha">Whether to include the Alpha slider or not.</param>
		/// <returns>The created ColorPickerDialog.</returns>
		public static ColorPickerDialog NewFixedColorPickerDialog(bool doAlpha = false)
		{
			ColorPickerDialog colorPicker = new ColorPickerDialog();

			//Access Ok button via reflection and set its FlatStyle to System (which supports dark-mode)
			var okButtonField = typeof(ColorPickerDialog).GetField("okButton", BindingFlags.NonPublic | BindingFlags.Instance);
			if (okButtonField != null)
			{
				Button okButton = (Button)okButtonField.GetValue(colorPicker);
				okButton.FlatStyle = FlatStyle.System;
				okButton.BackColor = SystemColors.ControlDark;
				okButton.ForeColor = SystemColors.ControlLightLight;
			}

			//Access Cancel button via reflection and set its FlatStyle to System (which supports dark-mode)
			var cancelButtonField = typeof(ColorPickerDialog).GetField("cancelButton", BindingFlags.NonPublic | BindingFlags.Instance);
			if (cancelButtonField != null)
			{
				Button cancelButton = (Button)cancelButtonField.GetValue(colorPicker);
				cancelButton.FlatStyle = FlatStyle.System;
				cancelButton.BackColor = SystemColors.ControlDark;
				cancelButton.ForeColor = SystemColors.ControlLightLight;
			}

			//Remove alpha channel slider if requested
			var colorEditorAlphaField = typeof(ColorPickerDialog).GetField("_showAlphaChannel", BindingFlags.NonPublic | BindingFlags.Instance);
			if (colorEditorAlphaField != null)
			{
				colorEditorAlphaField.SetValue(colorPicker, doAlpha);
			}

			return colorPicker;
		}
	}

	/// <summary>
	/// Static util class specifically made for handling API calls.
	/// </summary>
	public static class ApiUtil
	{
		/// <summary>
		/// Checks if you can reach the current baseUrl.
		/// </summary>
		/// <param name="baseUrl">The baseUrl to check.</param>
		/// <returns>Whether baseUrl is reachable or not.</returns>
		public static async Task<bool> CheckUrlAsync(string baseUrl)
		{
			try
			{
				RestClient client = new RestClient(baseUrl);
				RestRequest request = new RestRequest("", Method.Get);

				// Make a request to the API
				var response = await client.ExecuteAsync(request);

				// Check if the response is successful
				return response.IsSuccessful;
			}
			catch (Exception)
			{
				// If there is an exception (e.g. no network), return false
				return false;
			}
		}

		/// <summary>
		/// Gets a Response Content string from a URL and an endpoint.
		/// </summary>
		/// <param name="baseUrl">The Base URL of the website.</param>
		/// <param name="subUrl">The Endpoint Sub URL.</param>
		/// <returns>Response Content string.</returns>
		public static async Task<string?> GetApiDataAsync(string baseUrl, string subUrl)
		{
			try
			{
				RestClient restClient = new(baseUrl); //Create the RestClient from the baseUrl
				RestRequest rq = new(subUrl, Method.Get);
				var rsp = await restClient.ExecuteAsync(rq); //Asyncronously performas the request
				if (rsp.IsSuccessful && rsp.Content != null)
				{
					return rsp.Content;
				}
				else
				{
					MessageBox.Show($"Failed to execute: {rsp.StatusCode}");
				}
				restClient.Dispose();
			}
			catch (Exception e)
			{
				MessageBox.Show($"Failed to execute: {e.Message}");
			}
			return null;
		}

		/// <summary>
		/// Gets a Response Content string from a URL and a RestRequest.
		/// </summary>
		/// <param name="baseUrl">The Base URL of the website.</param>
		/// <param name="request">Request to execute</param>
		/// <returns></returns>
		public static async Task<string?> GetApiDataAsync(string baseUrl, RestRequest request)
		{
			try
			{
				RestClient restClient = new(baseUrl);
				var rsp = await restClient.ExecuteAsync(request); // Perform the request

				if (rsp.IsSuccessful && rsp.Content != null)
				{
					return rsp.Content;
				}
				else
				{
					MessageBox.Show($"Failed to execute: {rsp.StatusCode}");
				}
				restClient.Dispose();
			}
			catch (Exception e)
			{
				MessageBox.Show($"Failed to execute: {e.Message}");
			}
			return null;
		}

		/// <summary>
		/// Loads and returns an image from a website URL.
		/// </summary>
		/// <param name="url">The URL to load the image from</param>
		/// <returns>The loaded Image, or null if not found.</returns>
		public static async Task<Image?> LoadImageFromUrlAsync(string url)
		{
			try
			{
				RestClient restClient = new RestClient(url);
				byte[] imageData = await restClient.DownloadDataAsync(new("", Method.Get)); //Get the image stream, try-catch handles the CS8600 warning.
				Stream fileStream = new MemoryStream(imageData);

				restClient.Dispose();
				return Image.FromStream(fileStream); //Convert the Stream to an Image
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Image load error: {ex.Message}");
			}
			return null;
		}
	}
}