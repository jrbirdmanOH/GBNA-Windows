using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public interface IQuizForm
	{
		void LoadQuizEntry(QuizEntry quizEntry);
		void UpdateAnswer(QuizAnswer answer);
		void UpdateAnswerNavigation();
		void OnQuizFinished();
		void UpdateScore(QuizScore score);
	}
}
