using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public delegate void PickOnePictureClickedEventHandler(object sender, PickOnePictureClickedEventArgs e);

	public partial class PickOneMediaPlayer : UserControl, IMediaPlayer
	{
		private enum PlayerMode
		{
			None,
			Picture,
			PictureAndSound,
		}

		private enum PlayerState
		{
			None,
			Paused,
			Playing,
			Stopped
		}

		private event PickOnePictureClickedEventHandler pickOnePictureClicked = null;
		private Object lockObj = new Object();

		private PlayerMode mode = PlayerMode.None;
		private PlayerState state = PlayerState.None;
		private string soundPath = string.Empty;
		private Audio audio = null;
		private delegate void StateChangeCallback(PlayerState state);
		private delegate void UpdateProgressBarCallback(int position);
		Thread mediaPositionThread = null;
		private PickOneChoice[] choices = null;
		private bool allowSelection = true;
		private bool showNames = false;

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

		public bool AllowSelection
		{
			get
			{
				return allowSelection;
			}

			set
			{
				allowSelection = value;
				if (allowSelection)
				{
					if (choices != null)
					{
						foreach (PickOneChoice choice in choices)
						{
							choice.Button.Cursor = Cursors.Hand;
						}
					}
				}
				else
				{
					if (choices != null)
					{
						foreach (PickOneChoice choice in choices)
						{
							choice.Button.Cursor = Cursors.Default;
						}
					}
				}
			}
		}

		public bool ShowNames
		{
			get
			{
				return showNames;
			}

			set
			{
				showNames = value;
				if (choices != null)
				{
					if (value)
					{
						foreach (PickOneChoice choice in choices)
						{
							choice.Button.Text = choice.Name;
						}
					}
					else
					{
						foreach (PickOneChoice choice in choices)
						{
							choice.Button.Text = string.Empty;
						}
					}
				}
			}
		}

		public PickOneMediaPlayer()
		{
			InitializeComponent();
		}

		private void PickOneMediaPlayer_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				Mode = PlayerMode.None;
				State = PlayerState.None;

				mediaPositionThread = new Thread(new ThreadStart(MediaPositionUpdate));
				mediaPositionThread.Start();

				// Create the choices
				choices = new PickOneChoice[] { new PickOneChoice(topLeftPictureButton), new PickOneChoice(topRightPictureButton), new PickOneChoice(bottomLeftPictureButton), new PickOneChoice(bottomRightPictureButton) };
			}
		}

		private void OnModeChanged()
		{
			switch (Mode)
			{
				case PlayerMode.None:
					buttonPanel.Visible = false;
					buttonPanel.Enabled = false;
					break;
				case PlayerMode.Picture:
					buttonPanel.Visible = false;
					buttonPanel.Enabled = false;
					break;
				case PlayerMode.PictureAndSound:
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
			// Only implemented for compatibility
			ShowPictures(new IMedia[] { picture });
		}

		public void ShowPictures(IMedia[] pictures)
		{
			// Dispose of any existing audio player objects
			ClearAll();

			for (int index = 0; index < pictures.Length; index++)
			{
				Mode = PlayerMode.Picture;

				PickOneChoice choice = choices[index];
				choice.PicturePath = pictures[index].AbsolutePath;

				// Set button image
				Image image = new Bitmap(choice.PicturePath);
				Button button = choice.Button;
				button.Dock = DockStyle.Fill;
				button.Tag = image;
				button.Image = Utility.GenerateImage(image, button.ClientSize);
				this.toolTip.SetToolTip(button, pictures[index].FullCopyright);
			}
		}

		public void ShowPicturesWithSound(IMedia[] pictures, string soundPath)
		{
			ShowPictures(pictures);
			PlaySound(soundPath, PlayerMode.PictureAndSound);
		}

		public void ShowPictureWithSound(IMedia picture, string soundPath)
		{
			// Only implemented for compatibility
			ShowPicturesWithSound(new IMedia[] { picture }, soundPath);
		}

		public void PlaySound(string path)
		{
			// Only implemented for compatibility
			PlaySound(path, PlayerMode.PictureAndSound);
		}

		private void PlaySound(string path, PlayerMode mode)
		{
			// Dispose of any existing audio player objects
			ClearAll();

			// Set the player mode
			Mode = mode;

			// Create the new audio object
			soundPath = path;
			audio = new Audio(soundPath);

			// Play the sound
			audio.Play();
			State = PlayerState.Playing;
		}

		public void PlayVideo(string path)
		{
			// Not supported
			throw new NotSupportedException();
		}

		private void ClearAll()
		{
			lock (lockObj)
			{
				ClearAudio();
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

		private void playPauseButton_Click(object sender, EventArgs e)
		{
			PlayPause();
		}

		private void PlayPause()
		{
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
						if (Mode == PlayerMode.PictureAndSound)
						{
							PlaySound(soundPath, PlayerMode.PictureAndSound);
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
			if (audio != null)
			{
				audio.Stop();
				State = PlayerState.Stopped;
			}
		}

		public void Pause()
		{
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

		private void splitContainer_Resize(object sender, EventArgs e)
		{
			if (this.ParentForm != null && this.ParentForm.WindowState != FormWindowState.Minimized)
			{
				UpdateSplitterPosition(sender as SplitContainer);
			}
		}

		private void UpdateSplitterPosition(SplitContainer splitContainer)
		{
			if (splitContainer.Orientation == Orientation.Horizontal)
			{
				splitContainer.SplitterDistance = (splitContainer.Height - splitContainer.SplitterWidth) / 2;
			}
			else
			{
				splitContainer.SplitterDistance = (splitContainer.Width - splitContainer.SplitterWidth) / 2;
			}
		}

		public event PickOnePictureClickedEventHandler PickOnePictureClicked
		{
			add
			{
				pickOnePictureClicked += value;
			}

			remove
			{
				pickOnePictureClicked -= value;
			}
		}

		protected virtual void OnPickOnePictureClicked(PickOnePictureClickedEventArgs e)
		{
			if (AllowSelection)
			{
				if (pickOnePictureClicked != null)
				{
					pickOnePictureClicked(this, e);
				}
			}
		}

		private void pictureButton_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;

			if (button != null)
			{
				OnPickOnePictureClicked(new PickOnePictureClickedEventArgs(GetChoiceIndex(button)));
			}
		}

		private void pictureButton_MouseEnter(object sender, EventArgs e)
		{
			if (AllowSelection)
			{
				Button button = sender as Button;
				if (button != null)
				{
					bool markedAsAnswer = GetMarkedAsAnswer(button);
					if (!markedAsAnswer)
					{
						button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
						button.FlatAppearance.BorderSize = 1;
						this.Update();
					}
				}
			}
		}

		private void pictureButton_MouseLeave(object sender, EventArgs e)
		{
			if (AllowSelection)
			{
				Button button = sender as Button;
				if (button != null)
				{
					bool markedAsAnswer = GetMarkedAsAnswer(button);
					if (!markedAsAnswer)
					{
						button.FlatAppearance.BorderSize = 0;
						this.Update();
					}
				}
			}
		}

		private void pictureButton_Resize(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				Image originalImage = button.Tag as Image;
				if (originalImage != null)
				{
					button.Image = Utility.GenerateImage(originalImage, button.ClientSize);
					this.Update();
				}
			}
		}

		private bool GetMarkedAsAnswer(Button button)
		{
			bool markedAsAnswer = false;

			foreach (PickOneChoice choice in choices)
			{
				if (choice.Button == button)
				{
					markedAsAnswer = choice.MarkedAsAnswer;
					break;
				}
			}

			return markedAsAnswer;
		}

		private int GetChoiceIndex(Button button)
		{
			int choiceIndex = 0;

			for (int index = 0; index < choices.Length; index++)
			{
				if (button == choices[index].Button)
				{
					choiceIndex = index;
					break;
				}
			}

			return choiceIndex;
		}

		public void DisplayCorrect(int choiceIndex, bool bIsUserChoice)
		{
			PickOneChoice choice = choices[choiceIndex];
			choice.MarkedAsAnswer = true;

			if (bIsUserChoice)
			{
				choice.Button.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			}
			else
			{
				choice.Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			}

			choice.Button.FlatAppearance.BorderSize = 3;
		}

		public void DisplayIncorrect(int choiceIndex)
		{
			PickOneChoice choice = choices[choiceIndex];
			choice.MarkedAsAnswer = true;
			choice.Button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			choice.Button.FlatAppearance.BorderSize = 3;
		}

		public void ResetBorders()
		{
			foreach (PickOneChoice choice in choices)
			{
				choice.MarkedAsAnswer = false;
				choice.Button.FlatAppearance.BorderSize = 0;
				choice.Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			}
		}

		public void SetName(int choiceIndex, string name)
		{
			choices[choiceIndex].Name = name;
		}

		#region PickOneChoice Class
		private class PickOneChoice
		{
			private Button button = null;
			private string name = string.Empty;
			private string picturePath = string.Empty;
			private bool markedAsAnswer = false;

			public PickOneChoice()
			{
			}

			public PickOneChoice(Button button)
			{
				this.button = button;
			}

			public Button Button
			{
				get
				{
					return button;
				}

				set
				{
					button = value;
				}
			}

			public string Name
			{
				get
				{
					return name;
				}

				set
				{
					name = value;
				}
			}

			public string PicturePath
			{
				get
				{
					return picturePath;
				}

				set
				{
					picturePath = value;
				}
			}

			public bool MarkedAsAnswer
			{
				get
				{
					return markedAsAnswer;
				}

				set
				{
					markedAsAnswer = value;
				}
			}
		}
		#endregion
	}

	public class PickOnePictureClickedEventArgs : EventArgs
	{
		private int choiceIndex;

		public PickOnePictureClickedEventArgs(int choiceIndex)
		{
			this.choiceIndex = choiceIndex;
		}

		public int ChoiceIndex
		{
			get
			{
				return choiceIndex;
			}
		}
	}
}
