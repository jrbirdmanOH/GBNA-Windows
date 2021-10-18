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
	public partial class QuizPickOneForm : BaseForm, IQuizForm
	{
		private const int numberOfAnswers = 4;

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

		public QuizPickOneForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private void QuizPickOneForm_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			// Set the initial size of the form
			this.ClientSize = new System.Drawing.Size(775, 550);

			// Set the base title of the form
			title = "Pick One Quiz";

			// Initialize the quiz media player
			quizMediaPlayer.MediaPlayer = this.pickOneMediaPlayer;

			// Initialize the quiz engine
			quizEngine.QuizForm = this;
			quizEngine.MediaPlayer = QuizMediaPlayer;
			quizEngine.QuizSettings = QuizSettings;
			quizEngine.QuizEntries = QuizEntry.GetList(quizEngine.QuizSettings.QuizSource.Type);

			// Set the label describing the quiz source
			quizSourceLabel.Text = quizEngine.QuizSettings.QuizSource.Name;

			// Load the go to navigational combo box
			LoadGoToCombo();

			// Start the quiz
			quizEngine.Start();
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

		private void QuizPickOneForm_FormClosing(object sender, FormClosingEventArgs e)
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
			// Stop any media from playing
			QuizMediaPlayer.MediaPlayer.Stop();

			// Hide the pick one media player until all updates have been made
			pickOneMediaPlayer.Visible = false;

			// Reset the borders to their original state
			pickOneMediaPlayer.ResetBorders();

			// Initially, don't allow user to show the names of the answers
			ShowNames(false);

			// Clear the Go To combo box selection
			goToComboBox.SelectedIndex = -1;

			// Set the name of the correct answer
			if (quizEngine.QuizSettings.Language == QuizSettings.Languages.All)
			{
				answerNameLabel.Text = quizEngine.GetOrganismText(quizEntry.ThingID, QuizSettings.Languages.Common);

				StringBuilder scientificName = new StringBuilder("(");
				scientificName.Append(quizEngine.GetOrganismText(quizEntry.ThingID, QuizSettings.Languages.Scientific));
				scientificName.Append(")");

				// Custom quiz questions do not have band codes
				if (QuizSettings.QuizSource.Type != QuizSource.QuizSourceTypes.CustomQuiz)
				{
					scientificName.Append(" [");
					scientificName.Append(quizEngine.GetOrganismText(quizEntry.ThingID, QuizSettings.Languages.BandCode));
					scientificName.Append("]");
				}
				scientificNameLabel.Text = scientificName.ToString();
			}
			else
			{
				answerNameLabel.Text = quizEngine.GetOrganismText(quizEntry.ThingID);
				scientificNameLabel.Text = string.Empty;
			}

			// Get the choices for the quiz entry
			List<int> quizChoices = quizEntry.Choices;

			// Initialize choices
			List<IMedia> mediaList = new List<IMedia>(quizChoices.Count);
			int addedEntryIndex = 0;
			for (int choiceIndex = 0; choiceIndex < quizChoices.Count; choiceIndex++)
			{
				int thingID = quizChoices[choiceIndex];

				if (thingID == quizEntry.ThingID)
				{
					mediaList.Add(quizEntry.PrimaryMedia);
					addedEntryIndex = choiceIndex;
				}
				else
				{
					if (QuizSettings.MediaType == QuizSettings.MediaTypes.RangeMap)
					{
						mediaList.Add(QuizEntry.GetRangeMapMedia(thingID));
					}
					else
					{
						mediaList.Add(QuizEntry.GetPhotoMedia(thingID, QuizSettings.PictureType));
					}
				}

				// Set the name to be displayed if user asks to show names
				string name = quizEngine.GetOrganismText(thingID, QuizSettings.Language);
				pickOneMediaPlayer.SetName(choiceIndex, name);
			}

			// See if this entry has already been answered
			if (quizEntry.IsAnswered)
			{
				// Restore the quiz entry
				RestoreQuizEntry(quizEntry);
			}
			else
			{
				// Set the question mode to Answer
				quizEngine.QuestionMode = QuizEngine.QuestionModes.Answer;
				pickOneMediaPlayer.AllowSelection = true;
				answerMessageLabel.Text = string.Empty;
				answerMessageLabel.Visible = false;
			}

			// See if secondary media is specified
			if (quizEntry.SecondaryMediaID != null)
			{
				IMedia secondaryMedia = quizEntry.SecondaryMedia;
				QuizMediaPlayer.LoadMedia(mediaList.ToArray(), secondaryMedia);
			}
			else
			{
				QuizMediaPlayer.LoadMedia(mediaList.ToArray());
			}

			// Now show the pick one media player after all updates have been made
			pickOneMediaPlayer.Visible = true;

			// Update status of navigation controls
			UpdateNavigationStatus();

			// Update the status of the answer button
			UpdateAnswerNavigation();
		}

		private void RestoreQuizEntry(QuizEntry quizEntry)
		{
			// Set the question mode to ReadOnly
			quizEngine.QuestionMode = QuizEngine.QuestionModes.ReadOnly;
			pickOneMediaPlayer.AllowSelection = false;

			// Get the user's response (answer)
			int response = Convert.ToInt32(quizEntry.Response);

			// Get the choices for the quiz entry
			List<int> quizChoices = quizEntry.Choices;

			string answerMessage = string.Empty;
			for (int choiceIndex = 0; choiceIndex < quizEntry.Choices.Count; choiceIndex++)
			{
				// Highlight the correct answer
				if (quizChoices[choiceIndex] == quizEntry.ThingID)
				{
					// Display the answer as being correct, but not the user's choice
					pickOneMediaPlayer.DisplayCorrect(choiceIndex, false);
				}

				// See if this choice is the user's answer
				if (quizChoices[choiceIndex] == response)
				{
					if (quizEntry.IsCorrect)
					{
						// Display the answer as being correct
						pickOneMediaPlayer.DisplayCorrect(choiceIndex, true);
						answerMessage = "Your answer was correct and is highlighted in green.";
					}
					else
					{
						// Display the answer as being incorrect
						pickOneMediaPlayer.DisplayIncorrect(choiceIndex);
						answerMessage = "Your answer was incorrect and is highlighted in red.  The correct answer is highlighted in black.";
					}

					// Show the user the status of their answer
					answerMessageLabel.Text = answerMessage;
					answerMessageLabel.Visible = true;
				}
			}
		}

		public void UpdateAnswer(QuizAnswer answer)
		{
			int choiceIndex = quizEngine.GetChoiceIndex(answer);

			// Set color of answer button text based on answer
			if (answer.Status == QuizAnswer.QuizAnswerStatus.Correct)
			{
				// Display the answer as being correct
				pickOneMediaPlayer.DisplayCorrect(choiceIndex, true);
			}
			else
			{
				// Display the answer as being incorrect
				pickOneMediaPlayer.DisplayIncorrect(choiceIndex);
			}

			// Update the score based on the answer
			UpdateScore(quizEngine.QuizScore);

			// Update the go to combo box to reflect the answer
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
            bool showNamesButtonEnabled = quizEngine.QuizSettings.EnableShowNames;

            if (!quizEngine.QuizSettings.EnableShowNames)
            {
                // Determine whether or not the show names functionality is enabled
                QuizEntry quizEntry = quizEngine.CurrentEntry;
                if (quizEntry.IsAnswered)
                {
                    if (quizEngine.QuestionMode == QuizEngine.QuestionModes.ReadOnly)
                    {
                        showNamesButtonEnabled = true;
                    }
                    else
                    {
                        if (quizEngine.QuizSettings.AnswerType == QuizSettings.AnswerTypes.TryUntilCorrect)
                        {
                            if (!quizEntry.IsCorrect)
                            {
                                showNamesButtonEnabled = true;
                            }
                        }
                    }
                }
            }

			// Set the enabled state of the show names button
			showNamesButton.Enabled = showNamesButtonEnabled;

			// Make sure visual changes get updated immediately
			this.Update();
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

		private void pickOneMediaPlayer_PickOnePictureClicked(object sender, PickOnePictureClickedEventArgs e)
		{
			QuizAnswer answer = new QuizAnswer();
			answer.ThingID = quizEngine.CurrentEntry.Choices[e.ChoiceIndex];
			answer.Response = answer.ThingID.ToString();
			quizEngine.AnswerQuestion(answer);
		}

		private void showNamesButton_Click(object sender, EventArgs e)
		{
			// Toggle showing the names of the answers
			ShowNames(!pickOneMediaPlayer.ShowNames);
		}

		private void ShowNames(bool show)
		{
			// Set the desired state for showing the names of the answers
			pickOneMediaPlayer.ShowNames = show;
			showNamesButton.Text = pickOneMediaPlayer.ShowNames ? "Hide Names" : "Show Names";
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