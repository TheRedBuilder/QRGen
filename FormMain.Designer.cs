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
			label1 = new Label();
			tabPageRead = new TabPage();
			panel2 = new Panel();
			label2 = new Label();
			statusStrip1 = new StatusStrip();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			settingsToolStripMenuItem = new ToolStripMenuItem();
			darkModeToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			inspectSettingsFileToolStripMenuItem = new ToolStripMenuItem();
			mainTabControl.SuspendLayout();
			tabPageCreate.SuspendLayout();
			panel1.SuspendLayout();
			tabPageRead.SuspendLayout();
			panel2.SuspendLayout();
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
			panel1.Controls.Add(label1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(486, 359);
			panel1.TabIndex = 1;
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
			panel2.Controls.Add(label2);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(486, 359);
			panel2.TabIndex = 2;
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
			settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkModeToolStripMenuItem, toolStripSeparator1, inspectSettingsFileToolStripMenuItem });
			settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			settingsToolStripMenuItem.Size = new Size(61, 20);
			settingsToolStripMenuItem.Text = "Settings";
			// 
			// darkModeToolStripMenuItem
			// 
			darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
			darkModeToolStripMenuItem.Size = new Size(178, 22);
			darkModeToolStripMenuItem.Text = "Dark Mode";
			darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
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
			tabPageRead.ResumeLayout(false);
			panel2.ResumeLayout(false);
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
		private ToolStripMenuItem darkModeToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem inspectSettingsFileToolStripMenuItem;
		private Panel panel2;
		private Label label2;
	}
}
