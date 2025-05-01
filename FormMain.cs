using Cyotek.Windows.Forms;
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
						_decodeImageFilePath = value;
						selectedFileLabel.Text = "Current File: " + value;
						decodeButton.Enabled = !string.IsNullOrEmpty(value);
					}
					catch (Exception)
					{
						selectedFileLabel.Text = "Current File:";
						decodeButton.Enabled = false;
					}
				}
				else
				{
					_decodeImageFilePath = "";
					selectedFileLabel.Text = "Current File:";
					decodeButton.Enabled = false;
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
			await CheckConnection();
			#region Setting Category Grouping
			themeStripMenuItems = [lightThemeToolStripMenuItem, autoThemeToolStripMenuItem, darkThemeToolStripMenuItem];
			#endregion

			#region Settings Load
			//Theme
			for (int i = 0; i < themeStripMenuItems.Length; i++)
			{
				var item = themeStripMenuItems[i];
				item.Checked = i == appSettingsData.Theme;
			}

			//Save Input
			saveInputToolStripMenuItem.Checked = appSettingsData.SaveInput;

			//Load Saved Input if desired
			if (saveInputToolStripMenuItem.Checked)
			{
				encodeTextBox.Text = appSettingsData.PreviousInputs.TryGetValue("encodeTextBoxText", out string encodeTextBoxText) ? encodeTextBoxText : "";

				eccComboBox.SelectedIndex = appSettingsData.PreviousInputs.TryGetValue("eccComboBoxSelectedIndex", out string eccComboBoxSelectedIndexString) ? (int.TryParse(eccComboBoxSelectedIndexString, out int eccComboBoxSelectedIndex) ? eccComboBoxSelectedIndex : 0) : 0;

				currRequest.backgroundColor = appSettingsData.PreviousInputs.TryGetValue("qrBackgroundColor", out string currRequestBackgroundColorString) ? Util.HexToColor(currRequestBackgroundColorString, Color.White) : Color.White;
				backgroundColorPreview.BackColor = currRequest.backgroundColor;

				currRequest.foregroundColor = appSettingsData.PreviousInputs.TryGetValue("qrForegroundColor", out string currRequestForegroundColorString) ? Util.HexToColor(currRequestForegroundColorString, Color.Black) : Color.Black;
				foregroundColorPreview.BackColor = currRequest.foregroundColor;

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

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			#region Save Input
			if (appSettingsData.SaveInput)
			{
				appSettingsData.PreviousInputs["encodeTextBoxText"] = encodeTextBox.Text;
				appSettingsData.PreviousInputs["eccComboBoxSelectedIndex"] = eccComboBox.SelectedIndex.ToString();
				appSettingsData.PreviousInputs["qrBackgroundColor"] = Util.ColorToHex(currRequest.backgroundColor, true);
				appSettingsData.PreviousInputs["qrForegroundColor"] = Util.ColorToHex(currRequest.foregroundColor, true);
				appSettingsData.PreviousInputs["decodeImageFilePath"] = DecodeImageFilePath;

				appSettings.Save();
			}
			#endregion
		}

		#region Top Bar

			#region Program Tab
		private async void checkConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			appStateLabel.Text = "Status: Unknown";
			await CheckConnection();
		}

		private void resetInputsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear out ALL your inputs? This cannot be undone!", "Input Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				//Recreate requests
				currRequest = new();
				currReadRequest = new();
				UpdateInputs(true);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion

			#region Settings Tab
		ToolStripMenuItem[] themeStripMenuItems;
		private void themeToolStripMenuItem_Click(object senderAny, EventArgs e)
		{
			ToolStripMenuItem sender = (ToolStripMenuItem)senderAny;
			appSettingsData.Theme = int.TryParse(sender.Tag.ToString(), out int r) ? r : 0; //these WILL always have the Tag, if not this exception should make the programmer aware of it.

			for (int i = 0; i < themeStripMenuItems.Length; i++)
			{
				var item = themeStripMenuItems[i];
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
			outputForm.outputPictureBox.Image = await currRequest.Execute();
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

		private async void decodeButton_ClickAsync(object sender, EventArgs e)
		{
			decodedTextBox.Text = await currReadRequest.ExecuteAsync();
		}
		#endregion

		#region Drag & Drop
		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data == null)
			{
				return;
			}

			if (mainTabControl.SelectedIndex == 0)
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					// Get the list of files that were dropped, that null reference shouldn't cause any issues in this case, as the if above shouldnt pass when it is empty
					string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

					// If there are files and the first file exists
					if (files.Length > 0 && File.Exists(files[0]))
					{
						encodeTextBox.Text = File.ReadAllText(files[0]);
					}
				}
				else if (e.Data.GetDataPresent(DataFormats.Text))
				{
					string textData = (string)e.Data.GetData(DataFormats.Text);
					encodeTextBox.Text = textData;
				}
			}
			else
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

					// If there are files and the first file exists
					if (files.Length > 0 && File.Exists(files[0]))
					{
						DecodeImageFilePath = files[0];
					}
				}
				else if (e.Data.GetDataPresent(DataFormats.Text))
				{
					// If the dropped data is text, directly set it in the TextBox
					string textData = (string)e.Data.GetData(DataFormats.Text);

					if (File.Exists(textData))
					{
						DecodeImageFilePath = textData;
					}
				}
			}
		}

		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}
		#endregion

		#region Image Pasting
		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (mainTabControl.SelectedIndex == 1 && e.Control && e.KeyCode == Keys.V)
			{
				if (Clipboard.ContainsImage())
				{
					Image img = Clipboard.GetImage(); //Again, this shouldn't ever be null as otherwise the if above won't pass
					previewPictureBox.Image = img;
					currReadRequest.imageData = img;
					_decodeImageFilePath = "";
					selectedFileLabel.Text = "Current File: From Clipboard";
					decodeButton.Enabled = true;
				}
			}
		}
		#endregion

		/// <summary>
		/// Checks connection to goqr.me and updates the gui.
		/// </summary>
		private async Task CheckConnection()
		{
			bool connected = await ApiUtil.CheckUrlAsync("https://goqr.me");
			appStateLabel.Text = "Status: " + (connected ? "Ready" : "Service unavailable");
			if (!connected)
			{
				MessageBox.Show("Connection failed! This app will not work correctly, check your internet connection and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Syncs the input in the gui with the current request.
		/// </summary>
		/// <param name="isReset">If DecodeImageFilePath should be reset.</param>
		private void UpdateInputs(bool isReset = false)
		{
			encodeTextBox.Text = currRequest.data;
			eccComboBox.SelectedIndex = (int)(currRequest.ecc ?? ECCLevel.L);
			backgroundColorPreview.BackColor = currRequest.backgroundColor;
			foregroundColorPreview.BackColor = currRequest.foregroundColor;
			if (isReset)
			{
				DecodeImageFilePath = "";
			};
		}
	}
}
