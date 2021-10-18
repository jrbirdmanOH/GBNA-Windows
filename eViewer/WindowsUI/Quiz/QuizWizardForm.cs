using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizWizardForm : BaseForm
    {
        private Collection collection = null;
        private QuizSettings quizSettings = null;
        private int currentWizardIndex = -1;
        private List<QuizWizardPanel> wizardPanels = new List<QuizWizardPanel>();

        private enum NavigationDirection
        {
            Next,
            Back
        }

        public QuizWizardForm()
        {
            InitializeComponent();
			this.SettingsKey = this.Name;
		}

        public Collection Collection
        {
            get
            {
                return collection;
            }

            set
            {
                collection = value;
                // May need to set this for all panels
                quizSelectPanel.Collection = Collection;
            }
        }

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

        private void QuizWizardForm_Load(object sender, EventArgs e)
        {
			if (!DesignMode)
			{
				// Set the title of the form based on the collection name
				this.Text += " - " + Collection.Name;

				wizardPanels.Add(quizSelectPanel);
				wizardPanels.Add(quizTypePanel);
				wizardPanels.Add(quizMultipleChoicePanel);
				wizardPanels.Add(quizFillInTheBlankPanel);
				wizardPanels.Add(quizFlashCardPanel);
				wizardPanels.Add(quizPickOnePanel);
				wizardPanels.Add(quizCommonOptionsPanel);

				foreach (QuizWizardPanel panel in wizardPanels)
				{
					panel.QuizSettings = quizSettings;
					panel.Visible = false;
					panel.NavigationStatusChanged += new EventHandler(QuizWizardPanel_NavigationStatusChanged);
				}

				if (quizSettings.WizardStartupType == QuizSettings.WizardStartupTypes.CustomList)
				{
					// Start at quiz type panel
					int newWizardIndex = 1;
					NavigateWizard(newWizardIndex);
				}
				else
				{
					NavigateWizard(NavigationDirection.Next);
				}

				CheckForUnfinishedQuiz();
			}
        }

		private void CheckForUnfinishedQuiz()
		{
			quizSettings.RestartQuiz = false;

			if (ApplicationSettings.RestartQuiz)
			{
				if (quizSettings.CanRestart(Collection.ID) && quizSettings.WizardStartupType == QuizSettings.WizardStartupTypes.Default)
				{
					int numberOfUnansweredQuestions = QuizEntry.GetNumberOfUnansweredQuestions();
					if (numberOfUnansweredQuestions > 0)
					{
						StringBuilder message = new StringBuilder("The last quiz taken was not completed.  There are ");
						message.Append(numberOfUnansweredQuestions.ToString());
						message.Append(" unanswered items in a quiz with a total of ");
						message.Append(QuizEntry.GetQuizLength().ToString());
						message.Append(" questions.\n\nDo you want to continue this quiz?");
						DialogResult result = MessageBox.Show(message.ToString(), "Quiz Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
						if (result == DialogResult.Yes)
						{
							// Need to restart the quiz
							quizSettings.RestartQuiz = true;

							this.DialogResult = DialogResult.OK;
							this.Visible = false;
							this.Close();
						}
					}
				}
			}

			// Update with the latest collection ID
			quizSettings.CollectionID = Collection.ID;
		}

        private void nextButton_Click(object sender, EventArgs e)
        {
            NavigateWizard(NavigationDirection.Next);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            NavigateWizard(NavigationDirection.Back);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NavigateWizard(NavigationDirection navigation)
        {
            // Save the settings of the current wizard panel before changing to new panel
            if (currentWizardIndex >= 0 && currentWizardIndex < wizardPanels.Count)
            {
                wizardPanels[currentWizardIndex].SaveSettings();
                wizardPanels[currentWizardIndex].Visible = false;
            }

            // Determine new wizard index
            int newWizardIndex = currentWizardIndex;
			do
			{
				if(navigation == NavigationDirection.Next)
				{
					newWizardIndex++;
				}
				else
				{
					newWizardIndex--;
				}
			}
            while(!wizardPanels[newWizardIndex].WizardEnabled);

			// Navigate to the new index
			NavigateWizard(newWizardIndex);

			// Set the focus to the proper control
			if (navigation == NavigationDirection.Next)
			{
				if (nextButton.Enabled)
				{
					nextButton.Focus();
				}
				else if (finishButton.Enabled)
				{
					finishButton.Focus();
				}
			}
			else
			{
				if (backButton.Enabled)
				{
					backButton.Focus();
				}
				else if (nextButton.Enabled)
				{
					nextButton.Focus();
				}
				else if (finishButton.Enabled)
				{
					finishButton.Focus();
				}
			}
		}

		private void NavigateWizard(int newWizardIndex)
		{
			// Make sure wizard index is valid
			if (newWizardIndex < 0)
			{
				newWizardIndex = 0;
			}
			else if (newWizardIndex > wizardPanels.Count - 1)
			{
				newWizardIndex = wizardPanels.Count - 1;
			}

			// Set new wizard panel as the current panel
			currentWizardIndex = newWizardIndex;
			QuizWizardPanel currentPanel = wizardPanels[currentWizardIndex];
			Cursor = Cursors.WaitCursor;
			try
			{
				currentPanel.LoadSettings();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
			currentPanel.Visible = true;

			// Set the status of the navigation buttons
			backButton.Enabled = currentPanel.BackEnabled;
			nextButton.Enabled = currentPanel.NextEnabled;
			finishButton.Enabled = currentPanel.FinishEnabled;

			if (currentPanel is QuizSelectPanel)
			{
				manageMyQuizzesButton.Enabled = true;
			}
			else
			{
				manageMyQuizzesButton.Enabled = false;
			}

			// Set the focus to the proper control
			if (nextButton.Enabled)
			{
				nextButton.Focus();
			}
			else if (finishButton.Enabled)
			{
				finishButton.Focus();
			}
			else if (backButton.Enabled)
			{
				backButton.Focus();
			}
		}

        private void finishButton_Click(object sender, EventArgs e)
        {
			// Save the settings of the current wizard panel before running the quiz
			if (currentWizardIndex >= 0 && currentWizardIndex < wizardPanels.Count)
			{
				wizardPanels[currentWizardIndex].SaveSettings();
			}

			// Need to save quiz length because generating the quiz entries
			// will set the value to the real number of questions based on
			// the quiz settings.
			int quizLength = quizSettings.QuizLength;

			// Generate the quiz entries
			GenerateQuizProgressForm progressForm = new GenerateQuizProgressForm();
			progressForm.Show();
			QuizEntry.GenerateQuizEntries(QuizSettings, collection.ID);
			progressForm.Close();

			if (QuizSettings.QuizLength > 0)
			{
				// Run the quiz
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				string message = "Sorry, based on the source and media you selected, there are no quiz questions available.\n\nWould you like to return to the Quiz Wizard to modify your settings and try again?";
				DialogResult result = MessageBox.Show(this, message, "Quiz Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Yes)
				{
					// Restore preliminary quiz length
					QuizSettings.QuizLength = quizLength;
				}
				else
				{
					// Cancel out of Quiz Wizard
					this.DialogResult = DialogResult.Cancel;
					this.Close();
				}
			}
        }

        private void QuizWizardPanel_NavigationStatusChanged(object sender, EventArgs e)
        {
            QuizWizardPanel panel = sender as QuizWizardPanel;
            if (panel != null)
            {
                backButton.Enabled = panel.BackEnabled;
                nextButton.Enabled = panel.NextEnabled;
                finishButton.Enabled = panel.FinishEnabled;
            }
        }

        private void hallOfFameButton_Click(object sender, EventArgs e)
        {
			HallOfFameManager.Instance.ShowHallOfFame();
        }

		private void myQuizzesButton_Click(object sender, EventArgs e)
		{
			MyQuizzesForm form = new MyQuizzesForm();
			DialogResult result = form.ShowDialog(this);
//			if (result == DialogResult.OK)
//			{
				// Process here
				quizSelectPanel.UpdateCustomQuizzes();
//			}
		}
    }
}