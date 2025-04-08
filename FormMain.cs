using System.ComponentModel;
using System.Diagnostics;
using static QRGen.Program;

namespace QRGen
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			#region Settings Load
			darkModeToolStripMenuItem.Checked = appSettings.Data.DarkMode;
			#endregion
		}

		#region Top Bar

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#region Settings Tab
		private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			appSettings.Data.DarkMode = !appSettings.Data.DarkMode;
			darkModeToolStripMenuItem.Checked = appSettings.Data.DarkMode;
			appSettings.Save();
			if (MessageBox.Show("This setting requires a restart to apply.", "Setting Changed", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				Application.Restart();
			}
		}
		private void inspectSettingsFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string userConfigDirectory = Path.GetDirectoryName(appSettings.FilePath);

				// Open the folder using Process.Start
				if (userConfigDirectory != null && Directory.Exists(userConfigDirectory))
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = userConfigDirectory,
						UseShellExecute = true // Required for opening folders
					});
				}
			}
			catch (Win32Exception)
			{
			}
		}
		#endregion

		#endregion
	}
}
