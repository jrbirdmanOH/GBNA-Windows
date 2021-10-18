using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Printing;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Collections.Generic;

namespace Thayer.Birding.UI.Windows
{
	public partial class PhotoListForm : BaseForm
	{
		List<PhotoListItem> photoListItems = null;
		private int selectedListIndex = 0;
		private Audio audio = null;

		private const string PlayRecordingText = "Play &Recording";
		private const string StopRecordingText = "Stop &Recording";

		public PhotoListForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public List<PhotoListItem> PhotoListItems
		{
			get
			{
				if (photoListItems == null)
				{
					photoListItems = new List<PhotoListItem>();
				}

				return photoListItems;
			}

			set
			{
				photoListItems = value;
			}
		}

		public int SelectedListIndex
		{
			get
			{
				return selectedListIndex;
			}

			set 
			{
				selectedListIndex = value;

				previousButton.Enabled = selectedListIndex > 0;
				nextButton.Enabled = selectedListIndex < this.PhotoListItems.Count - 1;
				SetPlayRecordingMenuStatus();

				try
				{
					if (selectedListIndex >= 0)
					{
						// Make sure any previous image resources are disposed
						if (pictureBox.Image != null)
						{
							pictureBox.Image.Dispose();
						}

						PhotoListItem photoListItem = this.SelectedItem;
						pictureBox.Image = Utility.GenerateBitmapWithCopyright(photoListItem.Photo, "Arial", 12.0f, System.Drawing.Color.Yellow);
						StringBuilder text = new StringBuilder(photoListItem.OrganismName);
						text.Append(": ");
						text.Append(photoListItem.Photo.Caption);

						Text = text.ToString();
					}
				}
				catch (Exception ex)
				{
					pictureBox.Image = null;
					StringBuilder message = new StringBuilder("Error viewing photo - ");
					message.Append(ex.Message);
					MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private PhotoListItem SelectedItem
		{
			get
			{
				return this.PhotoListItems[this.SelectedListIndex];
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			StopAudio();

			// Cleanup image resources
			if (pictureBox.Image != null)
			{
				pictureBox.Image.Dispose();
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			SelectedListIndex++;
		}

		private void previousButton_Click(object sender, EventArgs e)
		{
			SelectedListIndex--;
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

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
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

		private void playRecordingContextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording();
		}

		private void playRecordingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording();
		}

		private void PlayRecording()
		{
			if (audio != null && !audio.Disposed && audio.State == StateFlags.Running)
			{
				StopAudio();
			}
			else
			{
				IMedia media = this.SelectedItem.Sounds[0];
				audio = new Audio(media.AbsolutePath);
				audio.Ending += new EventHandler(audio_Ending);
				audio.Play();

				SetPlayRecordingMenuText(StopRecordingText);
			}
		}

		private void SetPlayRecordingMenuText(string menuText)
		{
			playRecordingToolStripMenuItem.Text = menuText;
			playRecordingContextToolStripMenuItem.Text = menuText;
		}

		private void SetPlayRecordingMenuStatus()
		{
			IMediaList sounds = this.SelectedItem.Sounds;
			bool bEnabled = (sounds != null && sounds.Count > 0);
			playRecordingToolStripMenuItem.Enabled = bEnabled;
			playRecordingContextToolStripMenuItem.Enabled = bEnabled;
		}

		void audio_Ending(object sender, EventArgs e)
		{
			Audio audio = sender as Audio;
			if (audio != null && !audio.Disposed)
			{
				if (audio.State == StateFlags.Running)
				{
					audio.Stop();
				}

				SetPlayRecordingMenuText(PlayRecordingText);
			}
		}

		private void StopAudio()
		{
			if (audio != null && !audio.Disposed)
			{
				audio.Stop();
				audio.Dispose();
				audio = null;
			}

			SetPlayRecordingMenuText(PlayRecordingText);
		}
	}
}