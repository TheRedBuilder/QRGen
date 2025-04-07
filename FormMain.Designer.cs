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
			statusStrip1 = new StatusStrip();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			darkModeToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			mainTabControl.SuspendLayout();
			tabPageCreate.SuspendLayout();
			panel1.SuspendLayout();
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
			tabPageCreate.Controls.Add(panel1);
			tabPageCreate.Location = new Point(4, 29);
			tabPageCreate.Name = "tabPageCreate";
			tabPageCreate.Padding = new Padding(3);
			tabPageCreate.Size = new Size(492, 365);
			tabPageCreate.TabIndex = 0;
			tabPageCreate.Text = "Create";
			tabPageCreate.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
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
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(486, 30);
			label1.TabIndex = 0;
			label1.Text = "Generate a QR Code";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// tabPageRead
			// 
			tabPageRead.Location = new Point(4, 29);
			tabPageRead.Name = "tabPageRead";
			tabPageRead.Padding = new Padding(3);
			tabPageRead.Size = new Size(492, 365);
			tabPageRead.TabIndex = 1;
			tabPageRead.Text = "Read";
			tabPageRead.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
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
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = ToolStripRenderMode.System;
			menuStrip1.Size = new Size(500, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkModeToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			fileToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
			// 
			// darkModeToolStripMenuItem
			// 
			darkModeToolStripMenuItem.CheckOnClick = true;
			darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
			darkModeToolStripMenuItem.Size = new Size(180, 22);
			darkModeToolStripMenuItem.Text = "Dark Mode";
			darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
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
		private ToolStripMenuItem darkModeToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
	}
}
