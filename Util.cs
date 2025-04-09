using Cyotek.Windows.Forms;
using RestSharp;
using System.Reflection;

namespace QRGen
{
	public static class Util
	{
		public static string ColorToHex(Color c)
		{
			return $"{c.R:X2}{c.G:X2}{c.B:X2}";
		}

		public static ColorPickerDialog NewFixedColorPickerDialog(bool doAlpha = false)
		{
			ColorPickerDialog colorPicker = new ColorPickerDialog();
			var okButtonField = typeof(ColorPickerDialog).GetField("okButton", BindingFlags.NonPublic | BindingFlags.Instance);
			if (okButtonField != null)
			{
				Button okButton = (Button)okButtonField.GetValue(colorPicker);
				okButton.FlatStyle = FlatStyle.System;
				okButton.BackColor = SystemColors.ControlDark;
				okButton.ForeColor = SystemColors.ControlLightLight;
			}

			// Access Cancel button via reflection
			var cancelButtonField = typeof(ColorPickerDialog).GetField("cancelButton", BindingFlags.NonPublic | BindingFlags.Instance);
			if (cancelButtonField != null)
			{
				Button cancelButton = (Button)cancelButtonField.GetValue(colorPicker);
				cancelButton.FlatStyle = FlatStyle.System;
				cancelButton.BackColor = SystemColors.ControlDark;
				cancelButton.ForeColor = SystemColors.ControlLightLight;
			}

			var colorEditoAlpharField = typeof(ColorPickerDialog).GetField("_showAlphaChannel", BindingFlags.NonPublic | BindingFlags.Instance);
			if (colorEditoAlpharField != null)
			{
				colorEditoAlpharField.SetValue(colorPicker, doAlpha);
			}

			return colorPicker;
		}
	}

	public static class ApiUtil
	{
		public static async Task<string?> GetApiData(string baseUrl, string subUrl)
		{
			try
			{
				RestClient restClient = new(baseUrl);
				RestRequest rq = new(subUrl, Method.Get);
				var rsp = await restClient.ExecuteAsync(rq);
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

		public static async Task<Image?> LoadImageFromUrlAsync(string url)
		{
			try
			{
				RestClient restClient = new RestClient(url);
				byte[] imageData = await restClient.DownloadDataAsync(new("", Method.Get));
				Stream fileStream = new MemoryStream(imageData);

				restClient.Dispose();
				return Image.FromStream(fileStream);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Image load error: {ex.Message}");
			}
			return null;
		}
	}
}