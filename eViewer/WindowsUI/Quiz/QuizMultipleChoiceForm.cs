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
	public partial class QuizMultipleChoiceForm : BaseForm, IQuizForm
	{
		private const int numberOfAnswers = 5;

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

		public QuizMultipleChoiceForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private void QuizMultipleChoiceForm_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			// Set the base title of the form
			title = "Multiple Choice Quiz";

			// Create the radio button items
			answerUltraOptionSet.Items.Clear();
			for (int index = 0; index < numberOfAnswers; index++)
			{
				answerUltraOptionSet.Items.Add(index, "");
			}

			// Initialize the quiz media player
			quizMediaPlayer.MediaPlayer = this.mediaPlayer;

			// Initialize the quiz engine
			quizEngine.QuizForm = this;
			quizEngine.MediaPlayer = QuizMediaPlayer;
			quizEngine.QuizSettings = QuizSettings;
			quizEngine.QuizEntries = QuizEntry.GetList(quizEngine.QuizSettings.QuizSource.Type);

			// Handle layout for when all languages are displayed
			if (quizEngine.QuizSettings.Language == QuizSettings.Languages.All)
			{
				answerUltraOptionSet.ItemSpacingVertical = 10;
			}

			// Set the label describing the quiz source
			quizSourceLabel.Text = quizEngine.QuizSettings.QuizSource.Name;

			// Update the visibility status of the clue combo box
			UpdateClueStatus();

			// Load the go to navigational combo box
			LoadGoToCombo();

			// Start the quiz
			quizEngine.Start();
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

		private void QuizMultipleChoiceForm_FormClosing(object sender, FormClosingEventArgs e)
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
			// Set the focus to the answer radio buttons
			answerUltraOptionSet.FocusedIndex = 0;
			answerUltraOptionSet.Focus();

			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			// Clear the Go To combo box selection
			goToComboBox.SelectedIndex = -1;

			// Get the choices for the quiz entry
			List<int> quizChoices = quizEntry.Choices;

			// Initialize choices
			for (int choiceIndex = 0; choiceIndex < quizChoices.Count; choiceIndex++)
			{
				answerUltraOptionSet.BeginUpdate();
				answerUltraOptionSet.Items[choiceIndex].DisplayText = quizEngine.GetOrganismText(quizChoices[choiceIndex]);
				answerUltraOptionSet.Items[choiceIndex].Appearance.ForeColor = System.Drawing.Color.Black;
				answerUltraOptionSet.Items[choiceIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.Default;
				answerUltraOptionSet.EndUpdate();
			}

			// See if this entry has already been answered
			if (quizEntry.IsAnswered)
			{
				// Restore the quiz entry
				RestoreQuizEntry(quizEntry);
			}
			else
			{
				// No answer is initially selected
				answerUltraOptionSet.CheckedIndex = -1;

				// Set the question mode to Answer
				quizEngine.QuestionMode = QuizEngine.QuestionModes.Answer;
			}

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
			int response = Convert.ToInt32(quizEntry.Response);

			// Get the choices for the quiz entry
			List<int> quizChoices = quizEntry.Choices;

			for (int choiceIndex = 0; choiceIndex < quizEntry.Choices.Count; choiceIndex++)
			{
				// See if this choice is the user's answer
				if (quizChoices[choiceIndex] == response)
				{
					answerUltraOptionSet.CheckedIndex = choiceIndex;
					if (quizEntry.IsCorrect)
					{
						// Set correct answer text color
						answerUltraOptionSet.Items[choiceIndex].Appearance.ForeColor = System.Drawing.Color.Green;
					}
					else
					{
						// Set incorrect answer text color
						answerUltraOptionSet.Items[choiceIndex].Appearance.ForeColor = System.Drawing.Color.Red;
					}

					// Set answer font to bold
					answerUltraOptionSet.Items[choiceIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				}

				// Highlight the correct answer
				if (quizChoices[choiceIndex] == quizEntry.ThingID)
				{
					answerUltraOptionSet.Items[choiceIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				}
			}
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
			int choiceIndex = quizEngine.GetChoiceIndex(answer);

			// Set color of answer button text based on answer
			if (answer.Status == QuizAnswer.QuizAnswerStatus.Correct)
			{
				answerUltraOptionSet.BeginUpdate();
				answerUltraOptionSet.Items[choiceIndex].Appearance.ForeColor = System.Drawing.Color.Green;
				answerUltraOptionSet.Items[choiceIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				answerUltraOptionSet.EndUpdate();
			}
			else
			{
				answerUltraOptionSet.BeginUpdate();
				answerUltraOptionSet.Items[choiceIndex].Appearance.ForeColor = System.Drawing.Color.Red;
				answerUltraOptionSet.Items[choiceIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				answerUltraOptionSet.EndUpdate();
			}

			// Update the score based on the answer
			UpdateScore(quizEngine.QuizScore);

			UpdateGoToCombo(quizEngine.CurrentEntryIndex);

			// Make sure visual changes get updated immediately
			Refresh();
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

			QuizEntry quizEntry = quizEngine.CurrentEntry;
			if (!quizEntry.IsAnswered)
			{
				answerButton.Text = "Answer";

				if (answerUltraOptionSet.CheckedIndex >= 0)
				{
					answerButtonEnabled = true;
				}
			}
			else
			{
				if (quizEngine.QuestionMode == QuizEngine.QuestionModes.ReadOnly)
				{
					answerButtonVisible = false;
				}
				else
				{
					if (quizEngine.QuizSettings.AnswerType == QuizSettings.AnswerTypes.TryUntilCorrect)
					{
						if (!quizEntry.IsCorrect)
						{
							answerButton.Text = "Try Again";
							answerButtonEnabled = true;
						}
					}
				}
			}

			// Set the enabled state of the answer button
			answerButton.Enabled = answerButtonEnabled;

			// Set the visible state of the answer button
			answerButton.Visible = answerButtonVisible;

			// Make sure visual changes get updated immediately
			this.Update();
		}

		private void answerButton_Click(object sender, EventArgs e)
		{
			// Select the user's choice as their answer
			int choiceIndex = answerUltraOptionSet.CheckedIndex;
			if (choiceIndex >= 0 && choiceIndex < answerUltraOptionSet.Items.Count)
			{
				QuizAnswer answer = new QuizAnswer();
				answer.ThingID = quizEngine.CurrentEntry.Choices[choiceIndex];
				answer.Response = answer.ThingID.ToString();
				quizEngine.AnswerQuestion(answer);
			}
		}

		private void answerUltraOptionSet_ValueChanged(object sender, EventArgs e)
		{
			UpdateAnswerNavigation();

			// Make sure the choice with the focus is the same as the selected choice
			if (answerUltraOptionSet.CheckedIndex >= 0)
			{
				answerUltraOptionSet.FocusedIndex = answerUltraOptionSet.CheckedIndex;
			}
		}

		private void answerUltraOptionSet_KeyDown(object sender, KeyEventArgs e)
		{
			// Make sure the selected choice is updated to reflect navigation with the arrow keys
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
			{
				if (answerUltraOptionSet.CheckedIndex >= 0)
				{
					answerUltraOptionSet.CheckedIndex = answerUltraOptionSet.FocusedIndex;
				}
			}
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
			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

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