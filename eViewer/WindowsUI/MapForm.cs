using System;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.Printing;

namespace Thayer.Birding.UI.Windows
{
	public partial class MapForm : BaseForm
	{
		private string mapType = string.Empty;

		public MapForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public Image Image
		{
			get
			{
				return pictureBox.Image;
			}

			set
			{
				pictureBox.Image = value;
			}
		}

		public string MapType
		{
			get
			{
				return mapType;
			}

			set
			{
				mapType = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			SetHelpTopicId();
		}

		private void SetHelpTopicId()
		{
			if (this.MapType == MediaType.AbundanceMap)
			{
				helpProvider.SetHelpKeyword(this, "1");
			}
			else if (this.MapType == MediaType.RangeMap)
			{
				helpProvider.SetHelpKeyword(this, "48");
			}
			else
			{
				helpProvider.SetShowHelp(this, false);
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UltraPrintPreviewDialog dialog = new UltraPrintPreviewDialog();
			dialog.Document = document;
			dialog.ShowDialog();
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintDialog dialog = new PrintDialog();
			dialog.UseEXDialog = true;
			dialog.Document = document;
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				document.Print();
			}
		}

		private void document_PagePrinting(object sender, PagePrintingEventArgs e)
		{
            Graphics g = e.Graphics;

            // Draw title
            Font textFont = new Font("Arial", 12.0f);
            SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black);
            float posX = e.RectInsideBorders.X;
            float posY = e.RectInsideBorders.Y;
            g.DrawString(this.Text, textFont, textBrush, posX, posY);

            // Calculate height of title plus spacing
            int titleHeight = Convert.ToInt32(textFont.GetHeight(g)) + 10;

            // Calculate the available height for the image
            int availableHeightForImage = e.RectInsideBorders.Size.Height - titleHeight;

            // Draw image
            Image image = pictureBox.Image;
            System.Drawing.Size availableImageSize = new System.Drawing.Size(e.RectInsideBorders.Size.Width, availableHeightForImage);
            System.Drawing.Size imageSize = Utility.GetOptimalSize(image, availableImageSize);
            g.DrawImage(pictureBox.Image, e.RectInsideBorders.X, e.RectInsideBorders.Y + titleHeight, imageSize.Width, imageSize.Height);
        }

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			// Cleanup image resources
			if (pictureBox.Image != null)
			{
				pictureBox.Image.Dispose();
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			const int WM_KEYDOWN = 0x100;

			// Only Process Key Down events for the Escape Key
			if (msg.Msg == WM_KEYDOWN)
			{
				if (keyData == Keys.Escape)
				{
					// Close the form
					Close();

					// Return true to indicate that Escape key was handled
					return true;
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
