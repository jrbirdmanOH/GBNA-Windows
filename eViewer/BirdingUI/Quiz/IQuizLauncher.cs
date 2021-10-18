using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public interface IQuizLauncher
	{
		void RunQuizWizard(QuizSettings quizSettings, Collection collection);
		void RunQuiz(QuizSettings quizSettings, Collection collection);
	}
}
