using System.Drawing.Imaging;

namespace QRGen
{
	/// <summary>
	/// Output Form which is created when the user generates a QR Code and lets the user save it as an image.
	/// </summary>
	public partial class FormOutput : Form
	{
		public FormOutput()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Asks the user to save the Image shown in the outputPictureBox.
		/// </summary>
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
						MessageBox.Show("Failed to save image:\n" + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("No image in the PictureBox.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveImage();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Mimic Zoom SizeMode, but use nearest neighbor filtering to remain sharp. (this is a QR Code afterall)
		/// </summary>
		private void outputPictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (outputPictureBox.Image == null)
				return;

			var image = outputPictureBox.Image;
			var container = outputPictureBox.ClientRectangle;

			float imageAspect = (float)image.Width / image.Height;
			float boxAspect = (float)container.Width / container.Height;

			int drawWidth, drawHeight;
			if (imageAspect > boxAspect)
			{
				drawWidth = container.Width;
				drawHeight = (int)(container.Width / imageAspect);
			}
			else
			{
				drawHeight = container.Height;
				drawWidth = (int)(container.Height * imageAspect);
			}

			int offsetX = (container.Width - drawWidth) / 2;
			int offsetY = (container.Height - drawHeight) / 2;

			var destRect = new Rectangle(offsetX, offsetY, drawWidth, drawHeight);

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

			e.Graphics.Clear(outputPictureBox.BackColor); //fill background to remove previously rendered images
			e.Graphics.DrawImage(image, destRect);
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (outputPictureBox.Image != null)
			{
				Clipboard.SetImage(outputPictureBox.Image);
			}
		}
	}
}
