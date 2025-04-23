using Cyotek.Windows.Forms;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using static QRGen.Program;

namespace QRGen
{
	/// <summary>
	/// Main Form of the program.
	/// </summary>
	public partial class FormMain : Form
	{

		public APIGenerateQRRequest currRequest;
		public APIReadQRRequest currReadRequest;

		public ColorPickerDialog colorPicker;
		string _decodeImageFilePath = "";

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string DecodeImageFilePath
		{
			get => _decodeImageFilePath;
			set
			{
				if (File.Exists(value))
				{
					_decodeImageFilePath = value;
					selectedFileLabel.Text = "Current File: " + value;
					decodeButton.Enabled = !string.IsNullOrEmpty(value);

					Bitmap img;
					try
					{
						// Create a copy of the file and load the image from that copy
						using (var fileStream = new FileStream(value, FileMode.Open, FileAccess.Read))
						{
							using (var memoryStream = new MemoryStream())
							{
								fileStream.CopyTo(memoryStream); // Copy file content into MemoryStream
								memoryStream.Seek(0, SeekOrigin.Begin); // Rewind memory stream to the start
								img = new Bitmap(memoryStream); // Create Bitmap from MemoryStream
							}
						}

						previewPictureBox.Image = img;
						currReadRequest.imageData = img;
					}
					catch (Exception) { }
				}
				else
				{
					_decodeImageFilePath = "";
				}
			}
		}

		public FormMain()
		{
			InitializeComponent();

			//Create requests
			currRequest = new();
			currReadRequest = new();

			colorPicker = Util.NewFixedColorPickerDialog();
		}

		private async void FormMain_Load(object sender, EventArgs e)
		{
			CheckConnection();
			#region Setting Category Grouping
			themeStipMenuItems = [lightThemeToolStripMenuItem, autoThemeToolStripMenuItem, darkThemeToolStripMenuItem];
			#endregion

			#region Settings Load
			//Theme
			for (int i = 0; i < themeStipMenuItems.Length; i++)
			{
				var item = themeStipMenuItems[i];
				item.Checked = i == appSettingsData.Theme;
			}

			//Save Input
			saveInputToolStripMenuItem.Checked = appSettingsData.SaveInput;

			//Load Saved Input if desired
			if (saveInputToolStripMenuItem.Checked)
			{
				encodeTextBox.Text = appSettingsData.PreviousInputs.TryGetValue("encodeTextBoxText", out string encodeTextBoxText) ? encodeTextBoxText : "";

				eccComboBox.SelectedIndex = appSettingsData.PreviousInputs.TryGetValue("eccComboBoxSelectedIndex", out string eccComboBoxSelectedIndexString) ? (int.TryParse(eccComboBoxSelectedIndexString, out int eccComboBoxSelectedIndex) ? eccComboBoxSelectedIndex : 0) : 0;

				DecodeImageFilePath = appSettingsData.PreviousInputs.TryGetValue("decodeImageFilePath", out string decodeImageFilePath) ? decodeImageFilePath : "";
			}
			#endregion

			#region Body Load
			if (eccComboBox.SelectedIndex < 0)
			{
				eccComboBox.SelectedIndex = 0; //select first option if -1
			}
			#endregion
		}

		private async void CheckConnection()
		{
			bool connected = await ApiUtil.CheckUrlAsync("https://goqr.me");
			appStateLabel.Text = "Status: " + (connected ? "Ready" : "Service unavailable");
			if (!connected)
			{
				MessageBox.Show("Connection failed! This app will not work correctly, check your internet connection and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			#region Save Input
			if (appSettingsData.SaveInput)
			{
				appSettingsData.PreviousInputs["encodeTextBoxText"] = encodeTextBox.Text;

				appSettingsData.PreviousInputs["eccComboBoxSelectedIndex"] = eccComboBox.SelectedIndex.ToString();

				appSettingsData.PreviousInputs["decodeImageFilePath"] = DecodeImageFilePath;

				appSettings.Save();
			}
			#endregion
		}

		#region Top Bar
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void checkConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			appStateLabel.Text = "Status: Unknown";
			CheckConnection();
		}

		#region Settings Tab
		ToolStripMenuItem[] themeStipMenuItems;
		private void themeToolStripMenuItem_Click(object senderAny, EventArgs e)
		{
			ToolStripMenuItem sender = (ToolStripMenuItem)senderAny;
			appSettingsData.Theme = int.TryParse(sender.Tag.ToString(), out int r) ? r : 0;

			for (int i = 0; i < themeStipMenuItems.Length; i++)
			{
				var item = themeStipMenuItems[i];
				item.Checked = i == appSettingsData.Theme;
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
			appSettingsData.SaveInput = !appSettingsData.SaveInput;
			saveInputToolStripMenuItem.Checked = appSettingsData.SaveInput;
			appSettings.Save();
		}
		#endregion
		#endregion

		#region "Create" Body

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
			outputForm.outputPictureBox.Image = new Bitmap(await ApiUtil.LoadImageFromUrlAsync(currRequest.ToString()));
			outputForm.Show();
		}
		#endregion

		#region "Read" Body
		private void decodeSelectButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				DecodeImageFilePath = openFileDialog1.FileName;
			}
		}

		private async void decodeButton_Click(object sender, EventArgs e)
		{
			string apiOutput = await ApiUtil.GetApiData(currReadRequest.ToString(), currReadRequest.ToRestRequest());

			if (string.IsNullOrEmpty(apiOutput))
			{
				MessageBox.Show("Api returned no data!", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<APIReadQRRequestData> apiData = JsonConvert.DeserializeObject<List<APIReadQRRequestData>>(apiOutput);

			if (apiData == null || apiData.Count == 0)
			{
				MessageBox.Show("Api returned invalid data!", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			decodedTextBox.Text = apiData[0].ToString();
		}
		#endregion
	}
}
