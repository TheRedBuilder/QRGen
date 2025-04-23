namespace QRGen
{
	/// <summary>
	/// Current application settings.
	/// </summary>
	public class AppSettings
	{
		public int Theme { get; set; } = 0;
		public bool SaveInput { get; set; } = true;
		public Dictionary<string, string> PreviousInputs = new() {};
	}
}
