using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizTypePanel : QuizWizardPanel
    {
        public QuizTypePanel()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
			base.LoadSettings();
            SetQuizType(QuizSettings.QuizType);
			SetQuizLengthLabel();

			// Initialize navigation capabilities of panel
			if (QuizSettings.WizardStartupType == QuizSettings.WizardStartupTypes.CustomList)
			{
				BackEnabled = false;
			}
			else
			{
				BackEnabled = true;
			}
			NextEnabled = true;
			FinishEnabled = true;
		}

        public override void SaveSettings()
        {
			base.SaveSettings();
            QuizSettings.QuizType = GetQuizType();
        }

        private void QuizTypePanel_Load(object sender, EventArgs e)
        {
        }

		private void SetQuizLengthLabel()
		{
			StringBuilder labelText = new StringBuilder("Based on your selection, the quiz will be ");
			labelText.Append(QuizSettings.QuizLength);
			labelText.Append(" species long plus duplicates, if requested.");
			quizLengthLabel.Text = labelText.ToString();
		}

        private QuizSettings.QuizTypes GetQuizType()
        {
            QuizSettings.QuizTypes quizType = QuizSettings.QuizTypes.MultipleChoice;

            if (multipleChoiceRadioButton.Checked)
            {
                quizType = QuizSettings.QuizTypes.MultipleChoice;
            }
            else if (fillInTheBlankRadioButton.Checked)
            {
                quizType = QuizSettings.QuizTypes.FillInTheBlank;
            }
            else if (flashCardsRadioButton.Checked)
            {
                quizType = QuizSettings.QuizTypes.FlashCards;
            }
            else if (pickOneRadioButton.Checked)
            {
                quizType = QuizSettings.QuizTypes.PickOne;
            }

            return quizType;
        }

        private void SetQuizType(QuizSettings.QuizTypes quizType)
        {
			pickOneRadioButton.Enabled = true;

			// Make sure Pick One quiz type is not available when
			// selecting a quiz with all videos since the Pick One
			// quiz type does not support media with videos.
			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.PredefinedQuiz)
			{
				if (QuizSettings.QuizSource.PredefinedQuiz.Category == Thayer.Birding.Quiz.QUIZ_CATEGORY_VIDEO)
				{
					pickOneRadioButton.Enabled = false;
					if (quizType == QuizSettings.QuizTypes.PickOne)
					{
						quizType = QuizSettings.QuizTypes.MultipleChoice;
					}
				}
			}

            switch (quizType)
            {
                case QuizSettings.QuizTypes.MultipleChoice:
                    multipleChoiceRadioButton.Checked = true;
                    break;
                case QuizSettings.QuizTypes.FillInTheBlank:
                    fillInTheBlankRadioButton.Checked = true;
                    break;
                case QuizSettings.QuizTypes.FlashCards:
                    flashCardsRadioButton.Checked = true;
                    break;
                case QuizSettings.QuizTypes.PickOne:
                    pickOneRadioButton.Checked = true;
                    break;
                default:
                    multipleChoiceRadioButton.Checked = true;
                    break;
            }
        }
    }
}
