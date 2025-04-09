using Cyotek.Windows.Forms;
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
			currRequest = new();
			colorPicker = Util.NewFixedColorPickerDialog();
		}

		public APIRequest currRequest;
		public ColorPickerDialog colorPicker;

		private void FormMain_Load(object sender, EventArgs e)
		{
			#region Setting Category Grouping
			themeStipMenuItems = [lightThemeToolStripMenuItem, autoThemeToolStripMenuItem, darkThemeToolStripMenuItem];
			#endregion

			#region Settings Load
			//Theme
			for (int i = 0; i < themeStipMenuItems.Length; i++)
			{
				var item = themeStipMenuItems[i];
				item.Checked = i == appSettings.Data.Theme;
			}

			//Save Input
			saveInputToolStripMenuItem.Checked = appSettings.Data.SaveInput;
			#endregion

			#region Body Load
			eccComboBox.SelectedIndex = 0; //select first option
			#endregion
		}

		#region Top Bar
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#region Settings Tab
		ToolStripMenuItem[] themeStipMenuItems;
		private void themeToolStripMenuItem_Click(object senderAny, EventArgs e)
		{
			ToolStripMenuItem sender = (ToolStripMenuItem)senderAny;
			appSettings.Data.Theme = int.TryParse(sender.Tag.ToString(), out int r) ? r : 0;

			for (int i = 0; i < themeStipMenuItems.Length; i++)
			{
				var item = themeStipMenuItems[i];
				item.Checked = i == appSettings.Data.Theme;
			}

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

		private void saveInputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			appSettings.Data.SaveInput = !appSettings.Data.SaveInput;
			saveInputToolStripMenuItem.Checked = appSettings.Data.SaveInput;
			appSettings.Save();
		}
		#endregion
		#endregion

		#region Create Body

		private void encodeTextBox_TextChanged(object sender, EventArgs e)
		{
			currRequest.data = encodeTextBox.Text;
			createButton.Enabled = currRequest.data != "";
		}

		private void foregroundColorButton_Click(object sender, EventArgs e)
		{
			colorPicker.Color = currRequest.foregroundColor;
			if (colorPicker.ShowDialog() == DialogResult.OK)
			{
				currRequest.foregroundColor = colorPicker.Color;
				foregroundColorPreview.BackColor = colorPicker.Color;
			}
		}

		private void backgroundColorButton_Click(object sender, EventArgs e)
		{
			colorPicker.Color = currRequest.backgroundColor;
			if (colorPicker.ShowDialog() == DialogResult.OK)
			{
				currRequest.backgroundColor = colorPicker.Color;
				backgroundColorPreview.BackColor = colorPicker.Color;
			}
		}

		private void eccComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			currRequest.ecc = (ECCLevel)eccComboBox.SelectedIndex;
		}

		private async void createButton_ClickAsync(object sender, EventArgs e)
		{
			FormOutput outputForm = new();
			outputForm.outputPictureBox.Image = await ApiUtil.LoadImageFromUrlAsync(currRequest.ToString());
			outputForm.Show();
		}
		#endregion

		private void decodeSelectButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}
	}
}
