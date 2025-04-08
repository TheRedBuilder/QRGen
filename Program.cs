namespace QRGen
{
    public static class Program
    {

		/// <summary>
		/// The app settings instance.
		/// </summary>
		public static JsonSettings<AppSettings> appSettings = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Red Builder/QRGen/config.json"));

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
			Application.SetColorMode(appSettings.Data.DarkMode ? SystemColorMode.Dark : SystemColorMode.Classic);
            Application.Run(new FormMain());
        }
    }
}