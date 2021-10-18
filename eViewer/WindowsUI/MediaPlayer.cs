using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Thayer.Birding.UI.Windows
{
	public partial class MediaPlayer : UserControl, IMediaPlayer
	{
		private enum PlayerMode
		{
			None,
			Picture,
			PictureAndSound,
			Sound,
			Video
		}

		private enum PlayerState
		{
			None,
			Paused,
			Playing,
			Stopped
		}

		public enum ZoomLevel
		{
			Normal,
			Large,
			Maximum
		}

		private Object lockObj = new Object();

		private PlayerMode mode = PlayerMode.None;
		private PlayerState state = PlayerState.None;
		private ZoomLevel zoomLevel = ZoomLevel.Normal;
		private string mediaPath = string.Empty;
		private IMedia picture = null;
		private Audio audio = null;
		private Video video = null;
		private delegate void StateChangeCallback(PlayerState state);
		private delegate void UpdateProgressBarCallback(int position);
		Thread mediaPositionThread = null;

		private PlayerMode Mode
		{
			get
			{
				return mode;
			}

			set
			{
				mode = value;
				OnModeChanged();
			}
		}

		private PlayerState State
		{
			get
			{
				return state;
			}

			set
			{
				state = value;
				OnStateChanged();
			}
		}

		private bool LoopMedia
		{
			get
			{
				return loopCheckBox.Checked;
			}
		}

		public string LoopText
		{
			get
			{
				return loopCheckBox.Text;
			}

			set
			{
				loopCheckBox.Text = value;
				LayoutZoomButtons();
			}
		}

		public ZoomLevel VideoZoomLevel
		{
			get
			{
				return zoomLevel;
			}

			set
			{
				zoomLevel = value;
				if (!this.DesignMode)
				{
					UpdateZoomStatus();
					ResizeVideo();
				}
			}
		}

		public MediaPlayer()
		{
			InitializeComponent();
		}

		private void MediaPlayer_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				Mode = PlayerMode.None;
				State = PlayerState.None;

				mediaPositionThread = new Thread(new ThreadStart(MediaPositionUpdate));
				mediaPositionThread.Start();
			}
		}

		private void OnModeChanged()
		{
			switch (Mode)
			{
				case PlayerMode.None:
					pictureBox.Visible = false;
					videoPanel.Visible = false;
					buttonPanel.Visible = false;
					buttonPanel.Enabled = false;
					break;
				case PlayerMode.Picture:
					pictureBox.Visible = true;
					videoPanel.Visible = false;
					buttonPanel.Visible = false;
					buttonPanel.Enabled = false;
					break;
				case PlayerMode.PictureAndSound:
					pictureBox.Visible = true;
					videoPanel.Visible = false;

					zoomInButton.Enabled = false;
					zoomInButton.Visible = false;
					zoomOutButton.Enabled = false;
					zoomOutButton.Visible = false;

					buttonPanel.Visible = true;
					buttonPanel.Enabled = true;
					break;
				case PlayerMode.Sound:
					pictureBox.Visible = false;
					videoPanel.Visible = false;

					zoomInButton.Enabled = false;
					zoomInButton.Visible = false;
					zoomOutButton.Enabled = false;
					zoomOutButton.Visible = false;
					
					buttonPanel.Visible = true;
					buttonPanel.Enabled = true;
					break;
				case PlayerMode.Video:
					pictureBox.Visible = false;
					videoPanel.Visible = true;

					zoomInButton.Visible = true;
					zoomOutButton.Visible = true;
					UpdateZoomStatus();

					buttonPanel.Visible = true;
					buttonPanel.Enabled = true;
					break;
			}
		}

		private void OnStateChanged()
		{
			switch (State)
			{
				case PlayerState.None:
					mediaProgressBar.Value = 0;
					stopButton.Enabled = false;
					playPauseButton.ImageKey = "Play";
					toolTip.SetToolTip(playPauseButton, "Play");
					buttonPanel.Enabled = false;
					break;
				case PlayerState.Paused:
					stopButton.Enabled = true;
					buttonPanel.Enabled = true;
					playPauseButton.ImageKey = "Play";
					toolTip.SetToolTip(playPauseButton, "Play");
					break;
				case PlayerState.Playing:
					stopButton.Enabled = true;
					buttonPanel.Enabled = true;
					playPauseButton.ImageKey = "Pause";
					toolTip.SetToolTip(playPauseButton, "Pause");
					break;
				case PlayerState.Stopped:
					mediaProgressBar.Value = 0;
					stopButton.Enabled = false;
					buttonPanel.Enabled = true;
					playPauseButton.ImageKey = "Play";
					toolTip.SetToolTip(playPauseButton, "Play");
					break;
			}
		}

		private void StateChange(PlayerState state)
		{
			State = state;
		}

		public void ShowPicture(IMedia picture)
		{
			// Dispose of any existing audio/video player objects
			ClearAll();

			pictureBox.Dock = DockStyle.Fill;
			this.picture = picture;
			Mode = PlayerMode.Picture;
			pictureBox.ImageLocation = picture.AbsolutePath;
			this.toolTip.SetToolTip(pictureBox, picture.FullCopyright);
			pictureBox.Refresh();
		}

		public void ShowPictureWithSound(IMedia picture, string soundPath)
		{
			pictureBox.Dock = DockStyle.Fill;
			this.picture = picture;
			pictureBox.ImageLocation = picture.AbsolutePath;
			this.toolTip.SetToolTip(pictureBox, picture.FullCopyright);
			pictureBox.Refresh();
			PlaySound(soundPath, PlayerMode.PictureAndSound);
		}

		public void PlaySound(string path)
		{
			PlaySound(path, PlayerMode.Sound);
		}

		private void PlaySound(string path, PlayerMode mode)
		{
			// Dispose of any existing audio/video player objects
			ClearAll();

			// Set the player mode
			Mode = mode;

			// Create the new audio object
			mediaPath = path;
			audio = new Audio(mediaPath);

			// Play the sound
			audio.Play();
			State = PlayerState.Playing;
		}

		public void PlayVideo(string path)
		{
			// Dispose of any existing audio/video player objects
			ClearAll();

			// Set the player mode
			Mode = PlayerMode.Video;

			// Create the new video object
			mediaPath = path;
			video = new Video(mediaPath);
			video.Owner = videoPanel;

			// Resize the video
			ResizeVideo();

			// Play the video
			video.Play();
			State = PlayerState.Playing;
		}

		public void ShowPictures(IMedia[] pictures)
		{
			if (pictures.Length > 0)
			{
				ShowPicture(pictures[0]);
			}
		}

		public void ShowPicturesWithSound(IMedia[] pictures, string soundPath)
		{
			if (pictures.Length > 0)
			{
				ShowPictureWithSound(pictures[0], soundPath);
			}
		}

		private void ClearAll()
		{
			lock (lockObj)
			{
				ClearAudio();
				ClearVideo();
			}

			State = PlayerState.None;
		}

		private void ClearAudio()
		{
			if (audio != null)
			{
				audio.Stop();
				State = PlayerState.Stopped;
				audio.Dispose();
				audio = null;
			}
		}

		private void ClearVideo()
		{
			if (video != null)
			{
				video.Stop();
				State = PlayerState.Stopped;
				video.Dispose();
				video = null;
			}
		}

		private void playPauseButton_Click(object sender, EventArgs e)
		{
			PlayPause();
		}

		private void PlayPause()
		{
			if (video != null)
			{
				switch (State)
				{
					case PlayerState.Paused:
						video.Play();
						State = PlayerState.Playing;
						break;
					case PlayerState.Playing:
						video.Pause();
						State = PlayerState.Paused;
						break;
					case PlayerState.Stopped:
						PlayVideo(mediaPath);
						break;
				}
			}

			if (audio != null)
			{
				switch (State)
				{
					case PlayerState.Paused:
						audio.Play();
						State = PlayerState.Playing;
						break;
					case PlayerState.Playing:
						audio.Pause();
						State = PlayerState.Paused;
						break;
					case PlayerState.Stopped:
						if (Mode == PlayerMode.Sound)
						{
							PlaySound(mediaPath);
						}
						else if (Mode == PlayerMode.PictureAndSound)
						{
							ShowPictureWithSound(picture, mediaPath);
						}
						break;
				}
			}
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			Stop();
		}

		public void Stop()
		{
			if (video != null)
			{
				video.Stop();
				State = PlayerState.Stopped;
			}

			if (audio != null)
			{
				audio.Stop();
				State = PlayerState.Stopped;
			}
		}

		public void Pause()
		{
			if (video != null)
			{
				if (this.State == PlayerState.Playing)
				{
					video.Pause();
					State = PlayerState.Paused;
				}
			}

			if (audio != null)
			{
				if (this.State == PlayerState.Playing)
				{
					audio.Pause();
					State = PlayerState.Paused;
				}
			}
		}

		public void Resume()
		{
			if (video != null)
			{
				if (this.State == PlayerState.Paused)
				{
					video.Play();
					State = PlayerState.Playing;
				}
			}

			if (audio != null)
			{
				if (this.State == PlayerState.Paused)
				{
					audio.Play();
					State = PlayerState.Playing;
				}
			}
		}

		private void MediaPositionUpdate()
		{
			while (IsHandleCreated)
			{
				lock (lockObj)
				{
					if (audio != null && !audio.Disposed)
					{
						// Make asynchronous call to update the progress bar
						int percentComplete = GetPercentComplete(audio.CurrentPosition, audio.Duration);
						BeginInvoke(new UpdateProgressBarCallback(UpdateProgressBar), new object[] { percentComplete });

						if (audio.CurrentPosition >= audio.Duration)
						{
							if (LoopMedia)
							{
								// Replay the current media
								audio.CurrentPosition = 0.0;
								audio.Play();

								// Make asynchronous call to update the state of the player
								BeginInvoke(new StateChangeCallback(StateChange), new object[] { PlayerState.Playing });
							}
							else
							{
								// Stop the player
								audio.Stop();

								// Make asynchronous call to update the state of the player
								BeginInvoke(new StateChangeCallback(StateChange), new object[] { PlayerState.Stopped });
							}
						}
					}
					else if (video != null && !video.Disposed)
					{
						// Make asynchronous call to update the progress bar
						int percentComplete = GetPercentComplete(video.CurrentPosition, video.Duration);
						BeginInvoke(new UpdateProgressBarCallback(UpdateProgressBar), new object[] { percentComplete });

						if (video.CurrentPosition >= video.Duration)
						{
							if (LoopMedia)
							{
								// Replay the current media
								video.CurrentPosition = 0.0;
								video.Play();

								// Make asynchronous call to update the state of the player
								BeginInvoke(new StateChangeCallback(StateChange), new object[] { PlayerState.Playing });
							}
							else
							{
								// Stop the player
								video.Stop();

								// Make asynchronous call to update the state of the player
								BeginInvoke(new StateChangeCallback(StateChange), new object[] { PlayerState.Stopped });
							}
						}
					}
				}

				System.Threading.Thread.Sleep(500);
			}

//			Console.WriteLine("MediaPositionUpdate:  End of thread");
		}

		private int GetPercentComplete(double currentPosition, double duration)
		{
			int percentComplete = (int)((currentPosition / duration) * 100.0);
			if (percentComplete > 100)
			{
				percentComplete = 100;
			}

			return percentComplete;
		}

		private void UpdateProgressBar(int position)
		{
			mediaProgressBar.Value = position;
		}

		private void MediaPlayer_Resize(object sender, EventArgs e)
		{
			ResizeVideo();
		}

		private void ResizeVideo()
		{
			// Set the visibility of the zoom buttons depending on
			// the ability of the video to actually be zoomed
			bool canZoom = CanZoom();
			zoomInButton.Visible = canZoom;
			zoomOutButton.Visible = canZoom;

			// Set the video size based on the zoom level
			videoPanel.Size = GetVideoSize(VideoZoomLevel);

			// Center the video in the window
			videoPanel.Left = (int)((mainPanel.Width - videoPanel.Width) / 2.0);
			videoPanel.Top = (int)((mainPanel.Height - videoPanel.Height) / 2.0);

			Refresh();
		}

		private System.Drawing.Size GetVideoSize(ZoomLevel zoomLevel)
		{
			System.Drawing.Size size = new System.Drawing.Size(0, 0);

			switch (zoomLevel)
			{
				case ZoomLevel.Normal:
					size = GetNormalVideoSize();
					break;
				case ZoomLevel.Large:
					size = GetLargeVideoSize();
					break;
				case ZoomLevel.Maximum:
					size = GetMaximumVideoSize();
					break;
			}

			return size;
		}

		private System.Drawing.Size GetNormalVideoSize()
		{
			System.Drawing.Size size = new System.Drawing.Size(0, 0);
			if (video != null)
			{
				size = video.DefaultSize;
				System.Drawing.Size maxSize = GetMaximumVideoSize();
				if (size.Width > maxSize.Width || size.Height > maxSize.Height)
				{
					size = maxSize;
				}
			}

			return size;
		}

		private System.Drawing.Size GetLargeVideoSize()
		{
			System.Drawing.Size normalSize = GetNormalVideoSize();
			System.Drawing.Size maxSize = GetMaximumVideoSize();

			System.Drawing.Size largeSize = new System.Drawing.Size(0, 0);
			largeSize.Width = normalSize.Width + (int)((maxSize.Width - normalSize.Width) / 2.0);
			largeSize.Height = normalSize.Height + (int)((maxSize.Height - normalSize.Height) / 2.0);

			return largeSize;
		}

		private System.Drawing.Size GetMaximumVideoSize()
		{
			int maxWidth;
			int maxHeight;

			if (video == null)
			{
				maxWidth = 0;
				maxHeight = 0;
			}
			else
			{
				int width = mainPanel.Width;
				int height = mainPanel.Height;
				int sourceWidth = video.DefaultSize.Width;
				int sourceHeight = video.DefaultSize.Height;

				double widthRatio = sourceWidth / (double)width;
				double heightRatio = sourceHeight / (double)height;

				if (widthRatio > heightRatio)
				{
					maxWidth = width;
					maxHeight = (int)(sourceHeight / widthRatio);
				}
				else
				{
					maxWidth = (int)(sourceWidth / heightRatio);
					maxHeight = height;
				}
			}

			return new System.Drawing.Size(maxWidth, maxHeight);
		}


		private void zoomInButton_Click(object sender, EventArgs e)
		{
			switch (VideoZoomLevel)
			{
				case ZoomLevel.Normal:
					VideoZoomLevel = ZoomLevel.Large;
					break;
				case ZoomLevel.Large:
					VideoZoomLevel = ZoomLevel.Maximum;
					break;
				case ZoomLevel.Maximum:
					VideoZoomLevel = ZoomLevel.Maximum;
					break;
			}
		}

		private void zoomOutButton_Click(object sender, EventArgs e)
		{
			switch (zoomLevel)
			{
				case ZoomLevel.Normal:
					VideoZoomLevel = ZoomLevel.Normal;
					break;
				case ZoomLevel.Large:
					VideoZoomLevel = ZoomLevel.Normal;
					break;
				case ZoomLevel.Maximum:
					VideoZoomLevel = ZoomLevel.Large;
					break;
			}
		}

		private bool CanZoom()
		{
			bool canZoom = false;

			if (video != null)
			{
				System.Drawing.Size defaultSize = video.DefaultSize;
				System.Drawing.Size maxSize = GetMaximumVideoSize();
				if (defaultSize.Width < maxSize.Width && defaultSize.Height < maxSize.Height)
				{
					canZoom = true;
				}
			}

			return canZoom;
		}

		private void UpdateZoomStatus()
		{
			switch (zoomLevel)
			{
				case ZoomLevel.Normal:
					zoomInButton.Enabled = true;
					zoomOutButton.Enabled = false;
					break;
				case ZoomLevel.Large:
					zoomInButton.Enabled = true;
					zoomOutButton.Enabled = true;
					break;
				case ZoomLevel.Maximum:
					zoomInButton.Enabled = false;
					zoomOutButton.Enabled = true;
					break;
			}
		}

		private void LayoutZoomButtons()
		{
			zoomOutButton.Left = loopCheckBox.Right + 9;
			zoomInButton.Left = zoomOutButton.Right + 6;
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			// If the handle is being destroyed and is not being
			// recreated, then clear all media objects.
			if (!RecreatingHandle)
			{
				// Make sure all resources are cleaned up
				ClearAll();
			}

			base.OnHandleDestroyed(e);
		}
	}
}
