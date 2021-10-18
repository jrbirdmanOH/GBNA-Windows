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
	public partial class QuizFillInTheBlankForm : BaseForm, IQuizForm
	{
		private QuizSettings quizSettings = null;
		private string title = null;

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

		public QuizFillInTheBlankForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private void QuizFillInTheBlankForm_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			// Set the base title of the form
			title = "Fill in the Blank Quiz";

			// Clear answer text box
			answerTextBox.Text = string.Empty;
			answerLabel.Text = string.Empty;

			// Initialize the quiz media player
			quizMediaPlayer.MediaPlayer = this.mediaPlayer;

			// Initialize the quiz engine
			quizEngine.QuizForm = this;
			quizEngine.MediaPlayer = QuizMediaPlayer;
			quizEngine.QuizSettings = QuizSettings;
			quizEngine.QuizEntries = QuizEntry.GetList(quizEngine.QuizSettings.QuizSource.Type);

			// Set the label describing the quiz source
			quizSourceLabel.Text = quizEngine.QuizSettings.QuizSource.Name;

			// Set the label indicating the language (common/scientific)
			InitializeLanguage();

			// Update the visibility status of the clue combo box
			UpdateClueStatus();

			// Load the go to navigational combo box
			LoadGoToCombo();

			// Start the quiz
			quizEngine.Start();
		}

		private void InitializeLanguage()
		{
			// Set the label indicating the language (common/scientific)
			StringBuilder languageText = new StringBuilder();
			switch(quizEngine.QuizSettings.Language)
			{
				case QuizSettings.Languages.Common:
					languageText.Append("Common Name");
					break;
				case QuizSettings.Languages.Scientific:
					languageText.Append("Scientific Name");
					break;
				case QuizSettings.Languages.BandCode:
					languageText.Append("Bird Codes");
					break;
				default:
					languageText.Append("Common Name");
					break;
			}

			switch (quizEngine.QuizSettings.DifficultyLevel)
			{
				case QuizSettings.DifficultyLevels.Easy:
					languageText.Append(" (Easy)");
					break;
				case QuizSettings.DifficultyLevels.Medium:
					languageText.Append(" (Medium)");
					break;
				case QuizSettings.DifficultyLevels.Hard:
					languageText.Append(" (Hard)");
					break;
			}

			languageLabel.Text = languageText.ToString();
		}

		private void UpdateClueStatus()
		{
			clueGroupBox.Enabled = quizEngine.QuizSettings.AllowClues;
		}

		private void LoadGoToCombo()
		{
			goToComboBox.Items.Clear();
			
			for (int index = 0; index < quizEngine.NumberOfEntries; index++)
			{
				goToComboBox.Items.Add(GetGoToComboItem(index));
			}
		}

		private void UpdateGoToCombo(int index)
		{
			goToComboBox.Items[index] = GetGoToComboItem(index);
		}

		private IDString GetGoToComboItem(int index)
		{
			QuizEntry quizEntry = quizEngine.GetQuizEntry(index);
			StringBuilder itemText = new StringBuilder("Question ");
			itemText.Append(Convert.ToString(index + 1));
			if (quizEntry.IsAnswered)
			{
				itemText.Append(quizEntry.IsCorrect ? " (correct)" : " (incorrect)");
			}
			else
			{
				itemText.Append(" (not answered)");
			}

			IDString item = new IDString(index, itemText.ToString());

			return item;
		}

		private void QuizFillInTheBlankForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (quizEngine.QuizScore.Remaining > 0)
			{
				DialogResult result = MessageBox.Show("Are you sure you want to stop the quiz?", "eViewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Yes)
				{
					base.OnClosing(e);
				}
				else
				{
					e.Cancel = true;
				}
			}
			else
			{
				base.OnClosing(e);
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			quizEngine.NavigateQuiz(QuizEngine.NavigationDirection.Next);
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			quizEngine.NavigateQuiz(QuizEngine.NavigationDirection.Back);
		}

		private void finishButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void UpdateNavigationStatus()
		{
			StringBuilder questionLocation = new StringBuilder("Question ");
			questionLocation.Append((quizEngine.CurrentQuestionNumber).ToString());
			questionLocation.Append(" of ");
			questionLocation.Append(quizEngine.NumberOfEntries.ToString());
			goToGroupBox.Text = questionLocation.ToString();

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
			// Set the focus to the answer text box
			answerTextBox.Focus();

			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			// Clear the Go To combo box selection
			goToComboBox.SelectedIndex = -1;

			// See if this entry has already been answered
			if (quizEntry.IsAnswered)
			{
				// Restore the quiz entry
				RestoreQuizEntry(quizEntry);
			}
			else
			{
				// No answer is initially shown
				answerTextBox.Text = string.Empty;
				answerLabel.Text = string.Empty;
				correctAnswerLabel.Text = string.Empty;

				// Set the question mode to Answer
				quizEngine.QuestionMode = QuizEngine.QuestionModes.Answer;
			}

			// Update any visual changes
			this.Update();

			// See if secondary media is specified
			if (quizEntry.SecondaryMediaID != null)
			{
				QuizMediaPlayer.LoadMedia(quizEntry.PrimaryMedia, quizEntry.SecondaryMedia);
			}
			else
			{
				QuizMediaPlayer.LoadMedia(quizEntry.PrimaryMedia);
			}

			// Load the clues for the entry
			LoadClues(quizEntry);

			// Update status of navigation controls
			UpdateNavigationStatus();

			// Update the status of the answer button
			UpdateAnswerNavigation();
		}

		private void RestoreQuizEntry(QuizEntry quizEntry)
		{
			// Set the question mode to ReadOnly
			quizEngine.QuestionMode = QuizEngine.QuestionModes.ReadOnly;

			// Get the user's response (answer)
			answerTextBox.Text = quizEntry.Response;

			if (quizEntry.IsCorrect)
			{
				answerLabel.Text = "Correct";
				answerLabel.ForeColor = System.Drawing.Color.Green;

				correctAnswerLabel.Text = string.Empty;
			}
			else
			{
				answerLabel.Text = "Incorrect";
				answerLabel.ForeColor = System.Drawing.Color.Red;
			}

			// Show the exact correct answer
			StringBuilder correctAnswer = new StringBuilder("The exact correct answer is \"");
			correctAnswer.Append(quizEngine.GetFillInTheBlankCorrectAnswer(quizEntry.ThingID));
			correctAnswer.Append("\"");
			correctAnswerLabel.Text = correctAnswer.ToString();
		}

		private void LoadClues(QuizEntry quizEntry)
		{
			if (QuizSettings.AllowClues)
			{
				clueComboBox.Thing = quizEntry.Thing;
				clueComboBox.PreferredMediaID = (int)quizEntry.MediaID;
			}
		}

		private void clueComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Load the media defined by the selected clue
			IMedia media = clueComboBox.SelectedMedia;
			if (media != null)
			{
				Refresh();

				// Check for secondary media
				QuizEntry quizEntry = quizEngine.CurrentEntry;
				IMedia secondaryMedia = null;
				if (media.ID == (int)quizEntry.MediaID)
				{
					if (quizEntry.SecondaryMediaID != null)
					{
						secondaryMedia = quizEntry.SecondaryMedia;
					}
				}

				QuizMediaPlayer.LoadMedia(media, secondaryMedia);
			}
		}

		public void UpdateAnswer(QuizAnswer answer)
		{
			// Set color of answer label text based on answer
			if (answer.Status == QuizAnswer.QuizAnswerStatus.Correct)
			{
				answerLabel.Text = "Correct";
				answerLabel.ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				answerLabel.Text = "Incorrect";
				answerLabel.ForeColor = System.Drawing.Color.Red;
			}

			// Update the score based on the answer
			UpdateScore(quizEngine.QuizScore);

			UpdateGoToCombo(quizEngine.CurrentEntryIndex);

			// Make sure visual changes get updated immediately
			this.Update();
		}

		public void UpdateScore(QuizScore score)
		{
			scoreCorrectLabel.Text = score.Correct.ToString();
			scoreIncorrectLabel.Text = score.Incorrect.ToString();
			scoreRemainingLabel.Text = score.Remaining.ToString();
		}

		public void UpdateAnswerNavigation()
		{
			bool answerButtonEnabled = false;
			bool answerButtonVisible = true;
			bool answerLabelVisible = true;
			bool answerTextBoxReadOnly = true;
			bool showAnswerButtonVisible = true;

			QuizEntry quizEntry = quizEngine.CurrentEntry;
			if (!quizEntry.IsAnswered)
			{
				answerButton.Text = "Answer";
				answerLabelVisible = false;
				answerTextBoxReadOnly = false;

				if (answerTextBox.Text.Length > 0)
				{
					answerButtonEnabled = true;
				}
			}
			else
			{
				if (quizEngine.QuestionMode == QuizEngine.QuestionModes.ReadOnly)
				{
					answerButtonVisible = false;
					showAnswerButtonVisible = false;
				}
				else
				{
					if (quizEngine.QuizSettings.AnswerType == QuizSettings.AnswerTypes.TryUntilCorrect)
					{
						if (!quizEntry.IsCorrect)
						{
							answerButton.Text = "Try Again";
							answerButtonEnabled = true;
							answerTextBoxReadOnly = false;
						}
					}
					else
					{
						if (quizEntry.IsCorrect)
						{
							answerLabelVisible = false;
						}
					}
				}
			}

			// Set the enabled state of the answer button
			answerButton.Enabled = answerButtonEnabled;

			// Set the visible state of the answer button
			answerButton.Visible = answerButtonVisible;

			// Set the visible state of the answer label
			answerLabel.Visible = answerLabelVisible;

			// Set the read only property of the answer text box
			answerTextBox.ReadOnly = answerTextBoxReadOnly;

			// Set the visible state of the show answer button
			showAnswerButton.Visible = showAnswerButtonVisible;

			// Make sure visual changes get updated immediately
			this.Update();
		}

		private void showAnswerButton_Click(object sender, EventArgs e)
		{
			QuizEntry quizEntry = quizEngine.CurrentEntry;
			StringBuilder message = new StringBuilder("The correct answer is \"");
			message.Append(quizEngine.GetFillInTheBlankCorrectAnswer(quizEntry.ThingID));
			message.Append("\".");
			MessageBox.Show(message.ToString(), "Show Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);

			QuizAnswer answer = new QuizAnswer();
			answer.Status = QuizAnswer.QuizAnswerStatus.ShowAnswer;
			quizEngine.AnswerQuestion(answer);
		}

		private void answerButton_Click(object sender, EventArgs e)
		{
			// Select the user's choice as their answer
			string answerText = answerTextBox.Text;
			if (answerText.Length > 0)
			{
				QuizAnswer answer = new QuizAnswer();
				answer.Response = answerText;
				quizEngine.AnswerQuestion(answer);
			}
			else
			{
				MessageBox.Show("Please enter an answer.", "Answer Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void answerTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateAnswerNavigation();
		}

		private void goToComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			IDString item = goToComboBox.SelectedItem as IDString;
			if (item != null)
			{
				quizEngine.CurrentEntryIndex = item.ID;
				Refresh();
				LoadQuizEntry(quizEngine.CurrentEntry);
			}
		}

		private void goToComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (ValidateGoToComboBoxText())
				{
					int questionNumber = Convert.ToInt32(goToComboBox.Text);
					goToComboBox.SelectedIndex = questionNumber - 1;
				}
				else
				{
					StringBuilder messageText = new StringBuilder("Please enter a value between 1 and ");
					messageText.Append(Convert.ToString(quizEngine.NumberOfEntries));
					MessageBox.Show(messageText.ToString(), "Invalid Question Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private bool ValidateGoToComboBoxText()
		{
			bool isValid = false;
			if (goToComboBox.SelectedIndex == -1 && goToComboBox.Text.Length > 0)
			{
				int questionNumber;
				if (Int32.TryParse(goToComboBox.Text, out questionNumber))
				{
					if (questionNumber > 0 && questionNumber <= goToComboBox.Items.Count)
					{
						isValid = true;
					}
				}
			}

			return isValid;
		}

		public void OnQuizFinished()
		{
			// See if the quiz qualifies for the Hall of Fame
			HallOfFameManager.Instance.ProcessQuizForHallOfFame(quizEngine);

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

		private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				answerButton.PerformClick();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		private void compareButton_Click(object sender, EventArgs e)
		{
			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			if (quizEngine.QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				CustomCompareForm form = new CustomCompareForm();
				form.ShowDialog(this);
			}
			else
			{
				CompareForm form = new CompareForm();
				form.CollectionID = quizEngine.QuizSettings.CollectionID;
				form.LanguageID = UserSettings.Instance.Language.ID;
				form.ShowDialog(this);
			}
		}
	}
}