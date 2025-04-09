namespace QRGen
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			mainTabControl = new MyGui.net.CustomTabControl();
			tabPageCreate = new TabPage();
			panel1 = new Panel();
			createButton = new Button();
			label6 = new Label();
			eccComboBox = new ComboBox();
			label4 = new Label();
			flowLayoutPanel1 = new FlowLayoutPanel();
			groupBox1 = new GroupBox();
			foregroundColorButton = new Button();
			foregroundColorPreview = new Panel();
			groupBox2 = new GroupBox();
			backgroundColorButton = new Button();
			backgroundColorPreview = new Panel();
			label5 = new Label();
			encodeTextBox = new TextBox();
			label3 = new Label();
			label1 = new Label();
			tabPageRead = new TabPage();
			panel2 = new Panel();
			textBox1 = new TextBox();
			label7 = new Label();
			decodeButton = new Button();
			groupBox3 = new GroupBox();
			decodeSelectButton = new Button();
			selectedFileLabel = new Label();
			previewPictureBox = new PictureBox();
			label2 = new Label();
			statusStrip1 = new StatusStrip();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			settingsToolStripMenuItem = new ToolStripMenuItem();
			themeToolStripMenuItem = new ToolStripMenuItem();
			autoThemeToolStripMenuItem = new ToolStripMenuItem();
			lightThemeToolStripMenuItem = new ToolStripMenuItem();
			darkThemeToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			saveInputToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			inspectSettingsFileToolStripMenuItem = new ToolStripMenuItem();
			openFileDialog1 = new OpenFileDialog();
			mainTabControl.SuspendLayout();
			tabPageCreate.SuspendLayout();
			panel1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			tabPageRead.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// mainTabControl
			// 
			mainTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			mainTabControl.Controls.Add(tabPageCreate);
			mainTabControl.Controls.Add(tabPageRead);
			mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
			mainTabControl.ItemSize = new Size(120, 25);
			mainTabControl.Location = new Point(0, 27);
			mainTabControl.Name = "mainTabControl";
			mainTabControl.SelectedIndex = 0;
			mainTabControl.Size = new Size(500, 398);
			mainTabControl.TabIndex = 0;
			// 
			// tabPageCreate
			// 
			tabPageCreate.BackColor = SystemColors.ControlLightLight;
			tabPageCreate.Controls.Add(panel1);
			tabPageCreate.Location = new Point(4, 29);
			tabPageCreate.Name = "tabPageCreate";
			tabPageCreate.Padding = new Padding(3);
			tabPageCreate.Size = new Size(492, 365);
			tabPageCreate.TabIndex = 0;
			tabPageCreate.Text = "Create";
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(createButton);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(eccComboBox);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(flowLayoutPanel1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(encodeTextBox);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(486, 359);
			panel1.TabIndex = 1;
			// 
			// createButton
			// 
			createButton.Dock = DockStyle.Top;
			createButton.Enabled = false;
			createButton.FlatStyle = FlatStyle.System;
			createButton.Location = new Point(0, 276);
			createButton.Name = "createButton";
			createButton.Size = new Size(486, 23);
			createButton.TabIndex = 8;
			createButton.Text = "Generate";
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += createButton_ClickAsync;
			// 
			// label6
			// 
			label6.Dock = DockStyle.Top;
			label6.Location = new Point(0, 253);
			label6.Name = "label6";
			label6.Size = new Size(486, 23);
			label6.TabIndex = 7;
			label6.Text = "Finalize";
			label6.TextAlign = ContentAlignment.BottomLeft;
			// 
			// eccComboBox
			// 
			eccComboBox.Dock = DockStyle.Top;
			eccComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			eccComboBox.FlatStyle = FlatStyle.System;
			eccComboBox.Items.AddRange(new object[] { "L (low, ~7%)", "M (medium, ~15%)", "Q (quartile, ~25%)", "H (high, ~30%)" });
			eccComboBox.Location = new Point(0, 230);
			eccComboBox.MaximumSize = new Size(200, 0);
			eccComboBox.Name = "eccComboBox";
			eccComboBox.Size = new Size(200, 23);
			eccComboBox.TabIndex = 4;
			eccComboBox.SelectedIndexChanged += eccComboBox_SelectedIndexChanged;
			// 
			// label4
			// 
			label4.Dock = DockStyle.Top;
			label4.Location = new Point(0, 207);
			label4.Name = "label4";
			label4.Size = new Size(486, 23);
			label4.TabIndex = 3;
			label4.Text = "Error correction level";
			label4.TextAlign = ContentAlignment.BottomLeft;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.Controls.Add(groupBox1);
			flowLayoutPanel1.Controls.Add(groupBox2);
			flowLayoutPanel1.Dock = DockStyle.Top;
			flowLayoutPanel1.Location = new Point(0, 136);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(486, 71);
			flowLayoutPanel1.TabIndex = 6;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(foregroundColorButton);
			groupBox1.Controls.Add(foregroundColorPreview);
			groupBox1.Location = new Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(200, 65);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Foreground";
			// 
			// foregroundColorButton
			// 
			foregroundColorButton.FlatStyle = FlatStyle.System;
			foregroundColorButton.Location = new Point(47, 28);
			foregroundColorButton.Name = "foregroundColorButton";
			foregroundColorButton.Size = new Size(147, 23);
			foregroundColorButton.TabIndex = 1;
			foregroundColorButton.Text = "Select";
			foregroundColorButton.UseVisualStyleBackColor = true;
			foregroundColorButton.Click += foregroundColorButton_Click;
			// 
			// foregroundColorPreview
			// 
			foregroundColorPreview.BackColor = Color.Black;
			foregroundColorPreview.BorderStyle = BorderStyle.FixedSingle;
			foregroundColorPreview.Location = new Point(6, 22);
			foregroundColorPreview.Name = "foregroundColorPreview";
			foregroundColorPreview.Size = new Size(35, 35);
			foregroundColorPreview.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(backgroundColorButton);
			groupBox2.Controls.Add(backgroundColorPreview);
			groupBox2.Location = new Point(209, 3);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(200, 65);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Background";
			// 
			// backgroundColorButton
			// 
			backgroundColorButton.FlatStyle = FlatStyle.System;
			backgroundColorButton.Location = new Point(47, 28);
			backgroundColorButton.Name = "backgroundColorButton";
			backgroundColorButton.Size = new Size(147, 23);
			backgroundColorButton.TabIndex = 1;
			backgroundColorButton.Text = "Select";
			backgroundColorButton.UseVisualStyleBackColor = true;
			backgroundColorButton.Click += backgroundColorButton_Click;
			// 
			// backgroundColorPreview
			// 
			backgroundColorPreview.BackColor = Color.White;
			backgroundColorPreview.BorderStyle = BorderStyle.FixedSingle;
			backgroundColorPreview.Location = new Point(6, 22);
			backgroundColorPreview.Name = "backgroundColorPreview";
			backgroundColorPreview.Size = new Size(35, 35);
			backgroundColorPreview.TabIndex = 0;
			// 
			// label5
			// 
			label5.Dock = DockStyle.Top;
			label5.Location = new Point(0, 113);
			label5.Name = "label5";
			label5.Size = new Size(486, 23);
			label5.TabIndex = 5;
			label5.Text = "Color";
			label5.TextAlign = ContentAlignment.BottomLeft;
			// 
			// encodeTextBox
			// 
			encodeTextBox.AcceptsReturn = true;
			encodeTextBox.Dock = DockStyle.Top;
			encodeTextBox.Location = new Point(0, 53);
			encodeTextBox.Multiline = true;
			encodeTextBox.Name = "encodeTextBox";
			encodeTextBox.PlaceholderText = "Enter the text to encode into a QR code here.";
			encodeTextBox.ScrollBars = ScrollBars.Vertical;
			encodeTextBox.Size = new Size(486, 60);
			encodeTextBox.TabIndex = 2;
			encodeTextBox.TextChanged += encodeTextBox_TextChanged;
			// 
			// label3
			// 
			label3.Dock = DockStyle.Top;
			label3.Location = new Point(0, 30);
			label3.Name = "label3";
			label3.Size = new Size(486, 23);
			label3.TabIndex = 1;
			label3.Text = "Data to encode";
			label3.TextAlign = ContentAlignment.BottomLeft;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(486, 30);
			label1.TabIndex = 0;
			label1.Text = "Generate a QR Code";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// tabPageRead
			// 
			tabPageRead.BackColor = SystemColors.ControlLightLight;
			tabPageRead.Controls.Add(panel2);
			tabPageRead.Location = new Point(4, 29);
			tabPageRead.Name = "tabPageRead";
			tabPageRead.Padding = new Padding(3);
			tabPageRead.Size = new Size(492, 365);
			tabPageRead.TabIndex = 1;
			tabPageRead.Text = "Read";
			// 
			// panel2
			// 
			panel2.AutoScroll = true;
			panel2.BackColor = SystemColors.ControlLightLight;
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(decodeButton);
			panel2.Controls.Add(groupBox3);
			panel2.Controls.Add(label2);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(486, 359);
			panel2.TabIndex = 2;
			// 
			// textBox1
			// 
			textBox1.AcceptsReturn = true;
			textBox1.BackColor = SystemColors.ControlLightLight;
			textBox1.Dock = DockStyle.Top;
			textBox1.Location = new Point(0, 176);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.PlaceholderText = "Decoded data will show up here.";
			textBox1.ReadOnly = true;
			textBox1.ScrollBars = ScrollBars.Vertical;
			textBox1.ShortcutsEnabled = false;
			textBox1.Size = new Size(486, 60);
			textBox1.TabIndex = 5;
			// 
			// label7
			// 
			label7.Dock = DockStyle.Top;
			label7.Location = new Point(0, 153);
			label7.Name = "label7";
			label7.Size = new Size(486, 23);
			label7.TabIndex = 4;
			label7.Text = "Decoded Data";
			label7.TextAlign = ContentAlignment.BottomLeft;
			// 
			// decodeButton
			// 
			decodeButton.Dock = DockStyle.Top;
			decodeButton.Enabled = false;
			decodeButton.FlatStyle = FlatStyle.System;
			decodeButton.Location = new Point(0, 130);
			decodeButton.Name = "decodeButton";
			decodeButton.Size = new Size(486, 23);
			decodeButton.TabIndex = 3;
			decodeButton.Text = "Decode";
			decodeButton.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(decodeSelectButton);
			groupBox3.Controls.Add(selectedFileLabel);
			groupBox3.Controls.Add(previewPictureBox);
			groupBox3.Dock = DockStyle.Top;
			groupBox3.Location = new Point(0, 30);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(486, 100);
			groupBox3.TabIndex = 1;
			groupBox3.TabStop = false;
			groupBox3.Text = "File";
			// 
			// decodeSelectButton
			// 
			decodeSelectButton.FlatStyle = FlatStyle.System;
			decodeSelectButton.Location = new Point(84, 71);
			decodeSelectButton.Name = "decodeSelectButton";
			decodeSelectButton.Size = new Size(148, 23);
			decodeSelectButton.TabIndex = 2;
			decodeSelectButton.Text = "Select";
			decodeSelectButton.UseVisualStyleBackColor = true;
			decodeSelectButton.Click += decodeSelectButton_Click;
			// 
			// selectedFileLabel
			// 
			selectedFileLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			selectedFileLabel.Location = new Point(84, 22);
			selectedFileLabel.Name = "selectedFileLabel";
			selectedFileLabel.Size = new Size(396, 23);
			selectedFileLabel.TabIndex = 1;
			selectedFileLabel.Text = "Current file:";
			selectedFileLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// previewPictureBox
			// 
			previewPictureBox.BorderStyle = BorderStyle.FixedSingle;
			previewPictureBox.Location = new Point(6, 22);
			previewPictureBox.Name = "previewPictureBox";
			previewPictureBox.Size = new Size(72, 72);
			previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			previewPictureBox.TabIndex = 0;
			previewPictureBox.TabStop = false;
			// 
			// label2
			// 
			label2.Dock = DockStyle.Top;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(0, 0);
			label2.Name = "label2";
			label2.Size = new Size(486, 30);
			label2.TabIndex = 0;
			label2.Text = "Read a QR Code";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// statusStrip1
			// 
			statusStrip1.BackColor = SystemColors.ControlLight;
			statusStrip1.GripStyle = ToolStripGripStyle.Visible;
			statusStrip1.Location = new Point(0, 428);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.RenderMode = ToolStripRenderMode.System;
			statusStrip1.Size = new Size(500, 22);
			statusStrip1.TabIndex = 1;
			statusStrip1.Text = "statusStrip1";
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = ToolStripRenderMode.System;
			menuStrip1.Size = new Size(500, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			fileToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
			exitToolStripMenuItem.Size = new Size(135, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// settingsToolStripMenuItem
			// 
			settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem, toolStripSeparator2, saveInputToolStripMenuItem, toolStripSeparator1, inspectSettingsFileToolStripMenuItem });
			settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			settingsToolStripMenuItem.Size = new Size(61, 20);
			settingsToolStripMenuItem.Text = "Settings";
			// 
			// themeToolStripMenuItem
			// 
			themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { autoThemeToolStripMenuItem, lightThemeToolStripMenuItem, darkThemeToolStripMenuItem });
			themeToolStripMenuItem.Name = "themeToolStripMenuItem";
			themeToolStripMenuItem.Size = new Size(178, 22);
			themeToolStripMenuItem.Text = "Theme";
			// 
			// autoThemeToolStripMenuItem
			// 
			autoThemeToolStripMenuItem.Name = "autoThemeToolStripMenuItem";
			autoThemeToolStripMenuItem.Size = new Size(101, 22);
			autoThemeToolStripMenuItem.Tag = "1";
			autoThemeToolStripMenuItem.Text = "Auto";
			autoThemeToolStripMenuItem.Click += themeToolStripMenuItem_Click;
			// 
			// lightThemeToolStripMenuItem
			// 
			lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
			lightThemeToolStripMenuItem.Size = new Size(101, 22);
			lightThemeToolStripMenuItem.Tag = "0";
			lightThemeToolStripMenuItem.Text = "Light";
			lightThemeToolStripMenuItem.Click += themeToolStripMenuItem_Click;
			// 
			// darkThemeToolStripMenuItem
			// 
			darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
			darkThemeToolStripMenuItem.Size = new Size(101, 22);
			darkThemeToolStripMenuItem.Tag = "2";
			darkThemeToolStripMenuItem.Text = "Dark";
			darkThemeToolStripMenuItem.Click += themeToolStripMenuItem_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(175, 6);
			// 
			// saveInputToolStripMenuItem
			// 
			saveInputToolStripMenuItem.Name = "saveInputToolStripMenuItem";
			saveInputToolStripMenuItem.Size = new Size(178, 22);
			saveInputToolStripMenuItem.Text = "Save Input";
			saveInputToolStripMenuItem.Click += saveInputToolStripMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(175, 6);
			// 
			// inspectSettingsFileToolStripMenuItem
			// 
			inspectSettingsFileToolStripMenuItem.Name = "inspectSettingsFileToolStripMenuItem";
			inspectSettingsFileToolStripMenuItem.Size = new Size(178, 22);
			inspectSettingsFileToolStripMenuItem.Text = "Inspect Settings File";
			inspectSettingsFileToolStripMenuItem.Click += inspectSettingsFileToolStripMenuItem_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.DefaultExt = "png";
			openFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif|TIFF (*.tiff;*.tif)|*.tiff;*.tif";
			openFileDialog1.ShowPreview = true;
			openFileDialog1.Title = "Open a QR code";
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(500, 450);
			Controls.Add(statusStrip1);
			Controls.Add(menuStrip1);
			Controls.Add(mainTabControl);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MinimumSize = new Size(400, 300);
			Name = "FormMain";
			Text = "QRCodeUtils.NET";
			Load += FormMain_Load;
			mainTabControl.ResumeLayout(false);
			tabPageCreate.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			tabPageRead.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MyGui.net.CustomTabControl mainTabControl;
		private TabPage tabPageCreate;
		private TabPage tabPageRead;
		private Panel panel1;
		private Label label1;
		private StatusStrip statusStrip1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem settingsToolStripMenuItem;
		private ToolStripMenuItem themeToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem inspectSettingsFileToolStripMenuItem;
		private Panel panel2;
		private Label label2;
		private ToolStripMenuItem autoThemeToolStripMenuItem;
		private ToolStripMenuItem lightThemeToolStripMenuItem;
		private ToolStripMenuItem darkThemeToolStripMenuItem;
		private TextBox encodeTextBox;
		private Label label3;
		private ComboBox eccComboBox;
		private Label label4;
		private Label label5;
		private FlowLayoutPanel flowLayoutPanel1;
		private GroupBox groupBox1;
		private Button foregroundColorButton;
		private Panel foregroundColorPreview;
		private GroupBox groupBox2;
		private Button backgroundColorButton;
		private Panel backgroundColorPreview;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem saveInputToolStripMenuItem;
		private Button createButton;
		private Label label6;
		private GroupBox groupBox3;
		private PictureBox previewPictureBox;
		private Button decodeSelectButton;
		private Label selectedFileLabel;
		private Button decodeButton;
		private TextBox textBox1;
		private Label label7;
		private OpenFileDialog openFileDialog1;
	}
}
