using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRGen
{
	public partial class FormOutput : Form
	{
		public FormOutput()
		{
			InitializeComponent();
		}

		private void SaveImage()
		{
			if (outputPictureBox.Image != null)
			{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog1.FileName;
					string extension = Path.GetExtension(filePath).ToLowerInvariant();

					ImageFormat format = ImageFormat.Png; // default
					switch (extension)
					{
						case ".jpg":
						case ".jpeg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						case ".gif":
							format = ImageFormat.Gif;
							break;
						case ".tiff":
						case ".tif":
							format = ImageFormat.Tiff;
							break;
						case ".png":
						default:
							format = ImageFormat.Png;
							break;
					}

					try
					{
						outputPictureBox.Image.Save(filePath, format);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Failed to save image:\n" + ex.Message);
					}
				}
			}
			else
			{
				MessageBox.Show("No image in the PictureBox.");
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveImage();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveImage();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
