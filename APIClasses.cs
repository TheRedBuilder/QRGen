using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGen
{
	public enum ECCLevel {
		L,
		M,
		Q,
		H
	}

	/// <summary>
	/// Class used to construct the request to the QR Code Generation API.
	/// </summary>
	public class APIRequest
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
}
