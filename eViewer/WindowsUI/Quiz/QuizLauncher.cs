using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI.Quiz;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public class QuizLauncher : IQuizLauncher
	{
		private static QuizLauncher instance = null;

		protected QuizLauncher()
		{
		}

		public static QuizLauncher Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new QuizLauncher();
				}

				return instance;
			}
		}

		#region IQuizLauncher Members
		public void RunQuizWizard(QuizSettings quizSettings, Collection collection)
		{
			QuizWizardForm form = new QuizWizardForm();
			form.QuizSettings = quizSettings;
			form.Collection = collection;
			DialogResult result = form.ShowDialog();
			if (result == DialogResult.OK)
			{
				RunQuiz(form.QuizSettings, form.Collection);
			}
		}

		public void RunQuiz(QuizSettings quizSettings, Collection collection)
		{
			Application.DoEvents();

			// Set the quiz settings
			UserSettings.Instance.QuizSettings = quizSettings;

			// Run the quiz
			switch (quizSettings.QuizType)
			{
				case QuizSettings.QuizTypes.MultipleChoice:
				{
					QuizMultipleChoiceForm form = new QuizMultipleChoiceForm();
					form.QuizSettings = quizSettings;
					form.Show();
					break;
				}
				case QuizSettings.QuizTypes.FillInTheBlank:
				{
					QuizFillInTheBlankForm form = new QuizFillInTheBlankForm();
					form.QuizSettings = quizSettings;
					form.Show();
					break;
				}
				case QuizSettings.QuizTypes.FlashCards:
				{
					QuizFlashCardForm form = new QuizFlashCardForm();
					form.QuizSettings = quizSettings;
					form.Show();
					break;
				}
				case QuizSettings.QuizTypes.PickOne:
				{
					QuizPickOneForm form = new QuizPickOneForm();
					form.QuizSettings = quizSettings;
					form.Show();
					break;
				}
			}
		}
		#endregion
	}
}
