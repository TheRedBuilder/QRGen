namespace QRGen
{
	partial class FormOutput
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			saveToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			outputPictureBox = new PictureBox();
			saveFileDialog1 = new SaveFileDialog();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)outputPictureBox).BeginInit();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = ToolStripRenderMode.System;
			menuStrip1.Size = new Size(434, 24);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, toolStripMenuItem1, toolStripSeparator1, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			fileToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			saveToolStripMenuItem.Size = new Size(186, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
			toolStripMenuItem1.Size = new Size(186, 22);
			toolStripMenuItem1.Text = "Save As";
			toolStripMenuItem1.Click += toolStripMenuItem1_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(183, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
			exitToolStripMenuItem.Size = new Size(186, 22);
			exitToolStripMenuItem.Text = "Close";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// outputPictureBox
			// 
			outputPictureBox.BorderStyle = BorderStyle.FixedSingle;
			outputPictureBox.Dock = DockStyle.Fill;
			outputPictureBox.Location = new Point(0, 24);
			outputPictureBox.Name = "outputPictureBox";
			outputPictureBox.Size = new Size(434, 437);
			outputPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			outputPictureBox.TabIndex = 4;
			outputPictureBox.TabStop = false;
			// 
			// saveFileDialog1
			// 
			saveFileDialog1.DefaultExt = "png";
			saveFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif|TIFF (*.tiff;*.tif)|*.tiff;*.tif";
			saveFileDialog1.Title = "Save QR Code";
			// 
			// FormOutput
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(434, 461);
			Controls.Add(outputPictureBox);
			Controls.Add(menuStrip1);
			Name = "FormOutput";
			ShowIcon = false;
			Text = "Output";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)outputPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem exitToolStripMenuItem;
		public PictureBox outputPictureBox;
		private SaveFileDialog saveFileDialog1;
	}
}