using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public interface IHallOfFameManager
	{
		void ProcessQuizForHallOfFame(QuizEngine quizEngine);
		void ShowHallOfFame();
	}
}
