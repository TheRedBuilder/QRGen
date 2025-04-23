using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QRGen
{
	public enum ECCLevel {
		L,
		M,
		Q,
		H
	}

	//These classes dont inherit from anything, as they are way too different from each other

	/// <summary>
	/// Class used to construct the Create request to the QR Code Generation API.
	/// </summary>
	public class APIGenerateQRRequest
	{
		public string data = "";
		public int? size = null;
		public ECCLevel? ecc = null;
		public Color foregroundColor = Color.Black;
		public Color backgroundColor = Color.White;

		/// <summary>
		/// Formats this request as a valid API URL request.
		/// </summary>
		/// <returns>APIRequest URL.</returns>
		public override string ToString()
		{
			var sb = new StringBuilder("https://api.qrserver.com/v1/create-qr-code/?"); //StringBuilder makes the code look a bit cleaner

			if (!string.IsNullOrEmpty(data))
				sb.Append("data=" + Uri.EscapeDataString(data));

			if (size.HasValue)
				sb.Append("&size=" + size.Value + "x" + size.Value);

			if (ecc.HasValue)
				sb.Append("&ecc=" + ecc.Value.ToString());

			if (foregroundColor != Color.Black)
				sb.Append("&color=" + Util.ColorToHex(foregroundColor));

			if (backgroundColor != Color.White)
				sb.Append("&bgcolor=" + Util.ColorToHex(backgroundColor));

			return sb.ToString();
		}
	}

	/// <summary>
	/// Class used to construct the Read request to the QR Code Reading API.
	/// </summary>
	public class APIReadQRRequest
	{
		public Image imageData = null;

		/// <summary>
		/// Constructs a RestSharp request to upload the image for QR code reading.
		/// </summary>
		/// <returns>A ready-to-send RestRequest object.</returns>
		public RestRequest ToRestRequest()
		{
			if (imageData == null)
				return null;

			var request = new RestRequest();
			request.Method = Method.Post;

			// Save image to memory stream as PNG
			using var ms = new MemoryStream();
			imageData.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			ms.Position = 0;

			// Add file as multipart/form-data
			request.AddFile("file", ms.ToArray(), "upload.png", "image/png");

			return request;
		}

		/// <summary>
		/// Gets the Request baseUrl, you must call the ToRestRequest() to get the encoded image data!
		/// </summary>
		/// <returns>APIRequest baseUrl.</returns>
		public override string ToString()
		{
			return "https://api.qrserver.com/v1/read-qr-code/?";
		}
	}

	/// <summary>
	/// Data returned from the Read request to the QR Code Reading API.
	/// </summary>
	public class APIReadQRRequestData
	{
		[JsonProperty("type")]
		public string? Type { get; set; }

		[JsonProperty("symbol")]
		public List<QRSymbol> Symbols { get; set; } = new();

		/// <summary>
		/// Splits any symbol that has multiple QR codes inside it (delimited by "\nQR-Code:").
		/// </summary>
		public void Normalize()
		{
			var normalized = new List<QRSymbol>();

			foreach (var symbol in Symbols)
			{
				if (!string.IsNullOrEmpty(symbol.Data) && symbol.Data.Contains("QR-Code:"))
				{
					var parts = symbol.Data.Split(new[] { "QR-Code:" }, StringSplitOptions.RemoveEmptyEntries);
					foreach (var part in parts)
					{
						normalized.Add(new QRSymbol
						{
							Data = part.Trim(),
							Error = null,
							Sequence = symbol.Sequence
						});
					}
				}
				else
				{
					normalized.Add(symbol);
				}
			}

			Symbols = normalized;
		}

		public override string ToString()
		{
			if (Symbols == null || Symbols.Count == 0)
				return "No QR symbols found.";

			this.Normalize(); //gotta do this as the API creator seperated the output into multiple symbols but then mashes them all together into one anyway, oh god...

			var sb = new StringBuilder();
			for (int i = 0; i < Symbols.Count; i++)
			{
				var symbol = Symbols[i];

				if (!string.IsNullOrEmpty(symbol.Error))
				{
					sb.AppendLine($"QR {i + 1}: ERROR - {symbol.Error}");
				}
				else
				{
					sb.AppendLine($"QR {i + 1}:");
					sb.AppendLine(symbol.Data ?? "<no data>");
					sb.AppendLine();
				}
			}

			return sb.ToString().TrimEnd();
		}
	}

	/// <summary>
	/// Represents an individual symbol read from the QR code image.
	/// </summary>
	public class QRSymbol
	{
		[JsonProperty("seq")]
		public int Sequence { get; set; }

		[JsonProperty("data")]
		public string? Data { get; set; }

		[JsonProperty("error")]
		public string? Error { get; set; }
	}
}
