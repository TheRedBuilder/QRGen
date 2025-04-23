namespace QRGen
{
    public static class Program
    {

		/// <summary>
		/// The global app settings instance.
		/// </summary>
		public static JsonSettings<AppSettings> appSettings = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Red Builder/QRGen/config.json"));
		public static AppSettings appSettingsData = appSettings.Data; //Quicker than always looking it up in appSettings.

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
			Application.SetColorMode((SystemColorMode)appSettings.Data.Theme); //Set the correct theme. (the error is silenced as this is technically a preview feature)
            Application.Run(new FormMain());
        }
    }
}