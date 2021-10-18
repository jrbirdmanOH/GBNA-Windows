using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI.Quiz;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class QuizFlashCardForm : BaseForm, IQuizForm, ISpeechProvider
	{
		private static readonly string PauseButtonText = "Pause";
		private static readonly string ResumeButtonText = "Resume";

		private System.Timers.Timer nameTimer = new System.Timers.Timer(1000);
		private System.Timers.Timer navigationTimer = new System.Timers.Timer(1000);
		private System.Timers.Timer mediaTimer = new System.Timers.Timer(1000);
		private QuizSettings quizSettings = null;
		private string title = null;
		private int nameTimerTickCount = 0;
		private int navigationTimerTickCount = 0;
		private int mediaTimerTickCount = 0;
		private PauseState pauseState = null;

		public QuizSettings QuizSettings
		{
			get
			{
				return quizSettings;
			}

			set
			{
				quizSettings = value;
			}
		}

		private IQuizMediaPlayer QuizMediaPlayer
		{
			get
			{
				return quizMediaPlayer;
			}
		}

		public QuizFlashCardForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private void QuizFlashCardForm_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			this.ClientSize = new System.Drawing.Size(700, 550);

			nameTimerLabel.Text = string.Empty;
			navigationTimerLabel.Text = string.Empty;
			answerLabel.Text = string.Empty;
			mnemonicLabel.Text = string.Empty;

			nameTimerTickCount = 0;
			nameTimer.SynchronizingObject = this;
			nameTimer.Elapsed += new System.Timers.ElapsedEventHandler(nameTimer_Elapsed);

			navigationTimerTickCount = 0;
			navigationTimer.SynchronizingObject = this;
			navigationTimer.Elapsed += new System.Timers.ElapsedEventHandler(navigationTimer_Elapsed);

			mediaTimerTickCount = 0;
			mediaTimer.SynchronizingObject = this;
			mediaTimer.Elapsed += new System.Timers.ElapsedEventHandler(mediaTimer_Elapsed);

			// Set the base title of the form
			title = "Flash Card Quiz";

			// Set size of answer font depending on how much text will be shown
			if (QuizSettings.Language == QuizSettings.Languages.All)
			{
				Font currentFont = answerLabel.Font;
				Font newFont = new Font(currentFont.FontFamily, 9.75f, FontStyle.Bold, GraphicsUnit.Point);
				answerLabel.Font = newFont;
			}
			else
			{
				Font currentFont = answerLabel.Font;
				Font newFont = new Font(currentFont.FontFamily, 14.25f, FontStyle.Bold, GraphicsUnit.Point);
				answerLabel.Font = newFont;
			}

			// Initialize the quiz media player
			quizMediaPlayer.MediaPlayer = this.mediaPlayer;

			// Clear the Pause state
			ClearPauseState();

			// Initialize the quiz engine
			quizEngine.QuizForm = this;
			quizEngine.SpeechProvider = this;
			quizEngine.MediaPlayer = QuizMediaPlayer;
			quizEngine.QuizSettings = QuizSettings;
			quizEngine.QuizEntries = QuizEntry.GetList(quizEngine.QuizSettings.QuizSource.Type);

			// Set the label describing the quiz source
			quizSourceLabel.Text = quizEngine.QuizSettings.QuizSource.Name;

			// Start the quiz
			quizEngine.Start();

			// Show Petey the bird
			ShowPetey();
		}

		private void nameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// Calculate the time remaining
			int timeRemaining = quizEngine.QuizSettings.DisplayNameTimerLength - nameTimerTickCount;

			// Set the time remaining message
			StringBuilder timerText = new StringBuilder("Displaying name in ");
			timerText.Append(timeRemaining.ToString());
			timerText.Append(" seconds...");
			nameTimerLabel.Text = timerText.ToString();
			this.Update();

			// Check if the total time threshold has been reached
			if (nameTimerTickCount == quizEngine.QuizSettings.DisplayNameTimerLength)
			{
				OnNameTimerThresholdReached();
			}
			else
			{
				// Increment the tick count
				nameTimerTickCount++;
			}
		}

		private void navigationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// Calculate the time remaining
			int timeRemaining = quizEngine.QuizSettings.DisplayNextItemTimerLength - navigationTimerTickCount;

			// Set the time remaining message
			StringBuilder timerText = new StringBuilder("Displaying next item in ");
			timerText.Append(timeRemaining.ToString());
			timerText.Append(" seconds...");
			navigationTimerLabel.Text = timerText.ToString();
			this.Update();

			// Check if the total time threshold has been reached
			if (navigationTimerTickCount == quizEngine.QuizSettings.DisplayNextItemTimerLength)
			{
				OnNavigationTimerThresholdReached();
			}
			else
			{
				// Increment the tick count
				navigationTimerTickCount++;
			}
		}

		private void mediaTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// Calculate the time remaining
			int timeRemaining = quizEngine.QuizSettings.DisplayNextMediaTimerLength - mediaTimerTickCount;

			// Set the time remaining message
			StringBuilder timerText = new StringBuilder("Displaying next media in ");
			timerText.Append(timeRemaining.ToString());
			timerText.Append(" seconds...");
			nameTimerLabel.Text = timerText.ToString();
			this.Update();

			// Check if the total time threshold has been reached
			if (mediaTimerTickCount == quizEngine.QuizSettings.DisplayNextMediaTimerLength)
			{
				OnMediaTimerThresholdReached();
			}
			else
			{
				// Increment the tick count
				mediaTimerTickCount++;
			}
		}

		private void QuizFlashCardForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (quizEngine.QuizScore.Remaining > 0 || quizEngine.QuizSettings.LoopFlashCards)
			{
				bool isNameTimerRunning = nameTimer.Enabled;
				bool isNavigationTimerRunning = navigationTimer.Enabled;
				bool isMediaTimerRunning = mediaTimer.Enabled;

				// Stop the timers
				StopNameTimer(false);
				StopNavigationTimer(false);
				StopMediaTimer(false);

				DialogResult result = MessageBox.Show("Are you sure you want to stop the quiz?", "eViewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Yes)
				{
					OnStop();

					base.OnClosing(e);
				}
				else
				{
					e.Cancel = true;

					// Set the timers to their previous state
					nameTimer.Enabled = isNameTimerRunning;
					navigationTimer.Enabled = isNavigationTimerRunning;
					mediaTimer.Enabled = isMediaTimerRunning;
				}
			}
			else
			{
				OnStop();

				base.OnClosing(e);
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			OnNext();
		}

		private void OnNext()
		{
			// Stop any running timers
			StopTimers();

			// Stop Petey
			StopPetey();

			// Clear the navigation timer label
			navigationTimerLabel.Text = string.Empty;
			this.Update();

			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			if (!quizEngine.CurrentEntry.IsAnswered)
			{
				// Submit the answer
				SubmitAnswer();
			}
			else
			{
				// Navigate to the next item
				quizEngine.NavigateQuiz(QuizEngine.NavigationDirection.Next);
			}
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			OnBack();
		}

		private void OnBack()
		{
			// Stop any running timers
			StopTimers();

			// Stop Petey
			StopPetey();

			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			quizEngine.NavigateQuiz(QuizEngine.NavigationDirection.Back);
		}

		private void finishButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void pauseResumeButton_Click(object sender, EventArgs e)
		{
			OnPauseResume();
		}

		private void OnPauseResume()
		{
			if (pauseResumeButton.Text == PauseButtonText)
			{
				pauseState = new PauseState(nameTimer.Enabled, navigationTimer.Enabled, mediaTimer.Enabled);

				if (!pauseState.IsNameTimerRunning && !pauseState.IsNavigationTimerRunning && !pauseState.IsMediaTimerRunning)
				{
					// Don't pause now.  Wait until the next timer starts
					Console.WriteLine("In OnPauseResume - All timers are disabled!");
				}
				else
				{
					pauseResumeButton.Text = ResumeButtonText;

					// Stop the timers
					StopNameTimer(false);
					StopNavigationTimer(false);
					StopMediaTimer(false);

					// Pause the audio
					this.mediaPlayer.Pause();

					// Stop Petey from talking
					StopPetey();
				}
			}
			else
			{
				if (pauseState != null)
				{
					// Set the timers to their previous state
					nameTimer.Enabled = pauseState.IsNameTimerRunning;
					navigationTimer.Enabled = pauseState.IsNavigationTimerRunning;
					mediaTimer.Enabled = pauseState.IsMediaTimerRunning;
				}

				ClearPauseState();
				ShowPetey();
				this.mediaPlayer.Resume();
			}
		}

		private void ClearPauseState()
		{
			pauseResumeButton.Text = PauseButtonText;
			pauseState = null;
		}

		private void OnStop()
		{
			// Stop any running timers
			StopTimers();

			// Stop Petey
			StopPetey();
		}

		private void UpdateNavigationStatus()
		{
			StringBuilder questionLocation = new StringBuilder("Question ");
			questionLocation.Append((quizEngine.CurrentQuestionNumber).ToString());
			questionLocation.Append(" of ");
			questionLocation.Append(quizEngine.NumberOfEntries.ToString());

			StringBuilder titleText = new StringBuilder(this.title);
			titleText.Append(" - ");
			titleText.Append(questionLocation.ToString());
			this.Text = titleText.ToString();

			// Update status of back button
			backButton.Enabled = quizEngine.CanNavigateBackward;

			// Update status of next button
			nextButton.Enabled = quizEngine.CanNavigateForward;
		}

		public void LoadQuizEntry(QuizEntry quizEntry)
		{
			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			nameTimerLabel.Text = string.Empty;
			navigationTimerLabel.Text = string.Empty;
			answerLabel.Text = string.Empty;
			mnemonicLabel.Text = string.Empty;

			// Clear the Pause state
			ClearPauseState();

			// See if this entry has already been answered
			if (quizEntry.IsAnswered)
			{
				// Restore the quiz entry
				RestoreQuizEntry(quizEntry);
			}
			else
			{
				// No answer is initially shown
				answerLabel.Text = string.Empty;
				mnemonicLabel.Text = string.Empty;

				// Set the question mode to Answer
				quizEngine.QuestionMode = QuizEngine.QuestionModes.Answer;
			}

			// Update any visual changes
			this.Update();

			// Set initial media if showing all media types
			if (quizEngine.QuizSettings.MediaType == QuizSettings.MediaTypes.All)
			{
				quizEntry.SetNextMedia(true);
				DisplayMediaCaption();
			}

			// Load media into the media player
			QuizMediaPlayer.LoadMedia(quizEntry.PrimaryMedia, quizEntry.SecondaryMedia);

			// Update status of navigation controls
			UpdateNavigationStatus();

			// Update the status of the answer button
			UpdateAnswerNavigation();

			// See if a timer delay is set
			if (quizEngine.QuizSettings.MediaType == QuizSettings.MediaTypes.All && quizEngine.CurrentEntry.HasMoreMedia)
			{
				// Start the media timer
				StartMediaTimer();
			}
			else
			{
				if (quizEngine.QuizSettings.DisplayNameTimerLength > 0)
				{
					// Start the name timer
					StartNameTimer();
				}
				else
				{
					// Threshold is reached immediately since a timer delay has not been set
					OnNameTimerThresholdReached();
				}
			}
		}

		private void RestoreQuizEntry(QuizEntry quizEntry)
		{
			// Set the question mode to ReadOnly
			quizEngine.QuestionMode = QuizEngine.QuestionModes.ReadOnly;
		}

		public void UpdateAnswer(QuizAnswer answer)
		{
		}

		public void UpdateScore(QuizScore score)
		{
		}

		public void UpdateAnswerNavigation()
		{
		}

		private void SubmitAnswer()
		{
			QuizAnswer answer = new QuizAnswer();
			int thingID = quizEngine.CurrentEntry.ThingID;
			answer.ThingID = thingID;
			answer.Response = quizEngine.GetOrganismText(thingID, QuizSettings.Languages.Common);
			quizEngine.AnswerQuestion(answer);
		}

		public void OnQuizFinished()
		{
			if (quizEngine.QuizSettings.LoopFlashCards)
			{
				try
				{
					Cursor = Cursors.WaitCursor;

					// Move to the next item
					OnNext();
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
			else
			{
				// Stop any running timers
				StopTimers();

				StringBuilder messageText = new StringBuilder("The quiz is now finished.  Would you like to review the quiz?\n\nClick \"Yes\" ");
				messageText.Append("to keep the quiz window open for review, click \"No\" to close the quiz and return to the Quiz Wizard or click \"Cancel\" to close the quiz.");
				DialogResult result = MessageBox.Show(this, messageText.ToString(), "Finished Quiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.No)
				{
					this.Close();
					MainForm mainForm = Utility.GetOpenForm<MainForm>();
					mainForm.ShowQuizzes();
				}
				else if (result == DialogResult.Cancel)
				{
					this.Close();
				}
			}
		}

		private void StartNameTimer()
		{
			StartNameTimer(true);
		}

		private void StartNameTimer(bool resetTickCount)
		{
			// Show the name timer label
			nameTimerLabel.Visible = true;

			// Hide the organism name label
			answerLabel.Visible = false;

			// Hide the mnemonic label
			mnemonicLabel.Visible = false;

			this.Update();

			if (resetTickCount)
			{
				// Reset the tick count
				nameTimerTickCount = 0;
			}

			// Start the timer
			nameTimer.Start();
		}

		private void StopNameTimer()
		{
			StopNameTimer(true);
		}

		private void StopNameTimer(bool resetTickCount)
		{
			// Stop the name timer
			nameTimer.Stop();

			if (resetTickCount)
			{
				// Reset the tick count
				nameTimerTickCount = 0;
			}
		}

		private void OnNameTimerThresholdReached()
		{
			// Stop the timer
			StopNameTimer();

			// Hide the name timer label
			nameTimerLabel.Text = string.Empty;
			nameTimerLabel.Visible = false;
			this.Update();

			// Display the name of the organism
			DisplayName();

			// Check if the navigation timer should be started
			if (quizEngine.QuizSettings.DisplayNextItemTimerLength > 0)
			{
				// Start the navigation timer
				StartNavigationTimer();
			}

			// Process pending pause state if necessary
			if (pauseState != null)
			{
				OnPauseResume();
			}
		}

		private void DisplayName()
		{
			// Display the name of the organism
			int thingID = quizEngine.CurrentEntry.ThingID;
			answerLabel.Text = quizEngine.GetOrganismText(thingID);
			answerLabel.Visible = true;

			// Check if mnemonic should be shown
			if (quizEngine.QuizSettings.ShowMnemonic)
			{
				// Display the mnemonic for the organism
				mnemonicLabel.Text = quizEngine.GetMnemonicText(thingID);
				mnemonicLabel.Visible = true;
			}

			this.Update();

			if (quizEngine.QuizSettings.PlayPronunciation)
			{
				// Pronounce the name of the organism
				quizEngine.PronounceSpeech(thingID);
			}
		}

		private void StartNavigationTimer()
		{
			StartNavigationTimer(true);
		}

		private void StartNavigationTimer(bool resetTickCount)
		{
			if (resetTickCount)
			{
				// Reset the tick count
				navigationTimerTickCount = 0;
			}

			// Start the timer
			navigationTimer.Start();
		}

		private void StopNavigationTimer()
		{
			StopNavigationTimer(true);
		}

		private void StopNavigationTimer(bool resetTickCount)
		{
			// Stop the navigation timer
			navigationTimer.Stop();

			if (resetTickCount)
			{
				// Reset the tick count
				navigationTimerTickCount = 0;
			}
		}

		private void OnNavigationTimerThresholdReached()
		{
			// Move to the next item
			OnNext();
		}

		private void StartMediaTimer()
		{
			StartMediaTimer(true);
		}

		private void StartMediaTimer(bool resetTickCount)
		{
			// Show the name timer label
			nameTimerLabel.Visible = true;

			// Hide the organism name label
			answerLabel.Visible = false;

			// Hide the mnemonic label
			mnemonicLabel.Visible = false;

			this.Update();

			if (resetTickCount)
			{
				// Reset the tick count
				mediaTimerTickCount = 0;
			}

			// Start the timer
			mediaTimer.Start();
		}

		private void StopMediaTimer()
		{
			StopMediaTimer(true);
		}

		private void StopMediaTimer(bool resetTickCount)
		{
			// Stop the media timer
			mediaTimer.Stop();

			if (resetTickCount)
			{
				// Reset the tick count
				mediaTimerTickCount = 0;
			}
		}

		private void OnMediaTimerThresholdReached()
		{
			// Stop the timer
			StopMediaTimer();

			// Hide the name timer label
			nameTimerLabel.Text = string.Empty;
			nameTimerLabel.Visible = false;
			this.Update();

			if (quizEngine.CurrentEntry.SetNextMedia(quizEngine.QuizSettings.MediaType == QuizSettings.MediaTypes.All))
			{
				IMedia primaryMedia = quizEngine.CurrentEntry.PrimaryMedia;
				IMedia secondaryMedia = quizEngine.CurrentEntry.SecondaryMedia;
				QuizMediaPlayer.LoadMedia(primaryMedia, secondaryMedia);
			}

			// See if more media exists
			if (quizEngine.CurrentEntry.HasMoreMedia)
			{
				// If more media exists, start the timer for displaying the next media
				StartMediaTimer();
			}
			else
			{
				// No more media exists, so reset the media position
				quizEngine.CurrentEntry.ResetMediaPosition();

				// Begin the process for displaying the name
				if (quizEngine.QuizSettings.DisplayNameTimerLength > 0)
				{
					// Start the name timer
					StartNameTimer();
				}
				else
				{
					// Threshold is reached immediately since a timer delay has not been set
					OnNameTimerThresholdReached();
				}
			}

			// Display the caption for the media
			DisplayMediaCaption();

			// Process pending pause state if necessary
			if (pauseState != null)
			{
				OnPauseResume();
			}
		}

		private void DisplayMediaCaption()
		{
			// Display the media caption where the mnemonic is displayed
			mnemonicLabel.Visible = true;
			string caption = quizEngine.CurrentEntry.PrimaryMedia.Caption;
			mnemonicLabel.Text = caption != null ? caption : string.Empty;
		}

		private void StopTimers()
		{
			StopNameTimer();
			StopNavigationTimer();
			StopMediaTimer();
		}

		private void ShowPetey()
		{
			if (quizEngine.QuizSettings != null)
			{
				if (quizEngine.QuizSettings.PlayPronunciation && quizEngine.QuizSettings.Language != QuizSettings.Languages.BandCode)
				{
					MovePetey();
					Petey.Instance.Show();
				}
			}
		}

		private void MovePetey()
		{
			if (quizEngine.QuizSettings != null)
			{
				if (quizEngine.QuizSettings.PlayPronunciation)
				{
					Point point = this.DesktopLocation;
					Petey.Instance.MoveTo((short)point.X, (short)point.Y);
				}
			}
		}

		private void HidePetey()
		{
			if (quizEngine.QuizSettings != null)
			{
				if (quizEngine.QuizSettings.PlayPronunciation)
				{
					Petey.Instance.Stop();
					Petey.Instance.Hide();
				}
			}
		}

		private void StopPetey()
		{
			if (quizEngine.QuizSettings != null)
			{
				if (quizEngine.QuizSettings.PlayPronunciation)
				{
					Petey.Instance.Stop();
				}
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			// Hide Petey
			HidePetey();

			// Stop the timers
			StopTimers();

			// Dispose the components
			nameTimer.Dispose();
			navigationTimer.Dispose();
			mediaTimer.Dispose();

			base.OnHandleDestroyed(e);
		}

		private void QuizFlashCardForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				HidePetey();
			}
			else
			{
				MovePetey();
			}
		}

		#region ISpeechProvider Members
		public void PronounceSpeech(SpeechPhrase speechPhrase)
		{
			if (quizEngine.QuizSettings != null)
			{
				if (quizEngine.QuizSettings.PlayPronunciation)
				{
					if (this.WindowState != FormWindowState.Minimized)
					{
						ShowPetey();

						StringBuilder phrase = new StringBuilder("\\Map=\"");
						phrase.Append(speechPhrase.PronunciationPhrase);
						phrase.Append("\"=\"");
						phrase.Append(speechPhrase.ActualPhrase);
						phrase.Append("\"\\");

						Petey.Instance.Speak(phrase.ToString());
					}
				}
			}
		}
		#endregion

		#region PauseState Class
		private class PauseState
		{
			private bool isNameTimerRunning;
			private bool isNavigationTimerRunning;
			private bool isMediaTimerRunning;

			public PauseState()
			{
			}

			public PauseState(bool isNameTimerRunning, bool isNavigationTimerRunning, bool isMediaTimerRunning)
			{
				this.IsNameTimerRunning = isNameTimerRunning;
				this.IsNavigationTimerRunning = isNavigationTimerRunning;
				this.IsMediaTimerRunning = isMediaTimerRunning;
			}

			public bool IsNameTimerRunning
			{
				get
				{
					return isNameTimerRunning;
				}

				set
				{
					isNameTimerRunning = value;
				}
			}

			public bool IsNavigationTimerRunning
			{
				get
				{
					return isNavigationTimerRunning;
				}

				set
				{
					isNavigationTimerRunning = value;
				}
			}

			public bool IsMediaTimerRunning
			{
				get
				{
					return isMediaTimerRunning;
				}

				set
				{
					isMediaTimerRunning = value;
				}
			}
		}
		#endregion
	}
}