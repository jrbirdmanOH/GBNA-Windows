using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Text;

namespace Thayer.Birding.UI.Windows
{
	public partial class VideoForm : BaseForm
	{
		private string organismName = string.Empty;
		private IMedia media = null;
		private Video video = null;

		public VideoForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (video != null)
			{
				video.Dispose();
				video = null;
			}

			// Set title of form
			StringBuilder text = new StringBuilder(organismName);
			if (media.Caption.Length > 0)
			{
				text.Append(": ");
				text.Append(media.Caption);
			}
			this.Text = text.ToString();

			try
			{
				video = new Video(media.AbsolutePath);
				video.Stopping += new EventHandler(VideoStopping);
				video.Ending += new EventHandler(VideoEnding);
				video.Owner = videoPanel;

				System.Drawing.Size optimalSize = GetOptimalSize();
				ResizeVideoPanel(optimalSize.Width, optimalSize.Height);

				PlayPauseVideo();
			}
			catch (Exception ex)
			{
				StringBuilder message = new StringBuilder("Error playing video - ");
				message.Append(ex.Message);
				MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			if (video != null)
			{
				video.Dispose();
				video = null;
			}
		}

		public string OrganismName
		{
			get
			{
				return organismName;
			}

			set
			{
				organismName = value;
			}
		}

		public IMedia Media
		{
			get
			{
				return media;
			}

			set
			{
				media = value;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (this.IsHandleCreated)
			{
				System.Drawing.Size size = GetOptimalSize();
				ResizeVideoPanel(size.Width, size.Height);
			}
		}

		private System.Drawing.Size GetOptimalSize()
		{
			int newWidth;
			int newHeight;

			if (video == null)
			{
				newWidth = 0;
				newHeight = 0;
			}
			else
			{
				int width = panel1.Width;
				int height = panel1.Height;
				int sourceWidth = video.DefaultSize.Width;
				int sourceHeight = video.DefaultSize.Height;

				double widthRatio = sourceWidth / (double)width;
				double heightRatio = sourceHeight / (double)height;

				if (widthRatio > heightRatio)
				{
					newWidth = width;
					newHeight = (int)(sourceHeight / widthRatio);
				}
				else
				{
					newWidth = (int)(sourceWidth / heightRatio);
					newHeight = height;
				}
			}

			return new System.Drawing.Size(newWidth, newHeight);
		}

		private void ResizeVideoPanel(int width, int height)
		{
			videoPanel.Width = width;
			videoPanel.Height = height;

			videoPanel.Left = (int)((panel1.Width - videoPanel.Width) / 2.0);
			videoPanel.Top = (int)((panel1.Height - videoPanel.Height) / 2.0);
		}

		private void SetVideoSize(int width, int height)
		{
			int newWidth = width;
			int newHeight = menuStrip.Height + height + buttonPanel.Height;

			ClientSize = new System.Drawing.Size(newWidth, newHeight);

			ResizeVideoPanel(width, height);

			Refresh();
		}

		private void playToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayPauseVideo();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void videoSize50ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetVideoSize(video.DefaultSize.Width / 2, video.DefaultSize.Height / 2);
		}

		private void videoSize100ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetVideoSize(video.DefaultSize.Width, video.DefaultSize.Height);
		}

		private void videoSize200ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetVideoSize(video.DefaultSize.Width * 2, video.DefaultSize.Height * 2);
		}

		private void VideoEnding(object sender, EventArgs e)
		{
			StopVideo();
		}

		private void VideoStopping(object sender, EventArgs e)
		{
			video.CurrentPosition = 0.0;
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			StopVideo();
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			PlayPauseVideo();
		}
		
		private void PlayPauseVideo()
		{
			if (video.State == StateFlags.Running)
			{
				video.Pause();
				playButton.Text = "Play";
			}
			else
			{
				video.Play();
				playButton.Text = "Pause";
			}
		}

		private void StopVideo()
		{
			video.Stop();
			playButton.Text = "Play";
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