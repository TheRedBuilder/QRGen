using System.Diagnostics;

namespace QRGen
{
	public partial class FormMain : Form
	{
		public static JsonSettings<AppSettings> appSettings = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Red Builder/QRGen/config.json"));


		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			#region Settings Load
			Debug.WriteLine(appSettings.Data.DarkMode);
			appSettings.Save();
			#endregion
		}

		#region Top Bar
		private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion
	}
}
