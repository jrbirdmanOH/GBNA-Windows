using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public class QuizScore
	{
		public enum QuizAnswerTypes
		{
			Correct,
			Incorrect
		}

		private int total = 0;
		private int correct = 0;
		private int incorrect = 0;

		public int Total
		{
			get
			{
				return total;
			}

			set
			{
				total = value;
			}
		}

		public int Correct
		{
			get
			{
				return correct;
			}

			set
			{
				correct = value;
			}
		}

		public int Incorrect
		{
			get
			{
				return incorrect;
			}

			set
			{
				incorrect = value;
			}
		}

		public int Remaining
		{
			get
			{
				return total - (correct + incorrect);
			}
		}

		public QuizScore(int total)
		{
			this.total = total;
		}

		public void AddScore(QuizAnswerTypes answerType)
		{
			if ((correct + incorrect + 1) <= total)
			{
				switch (answerType)
				{
					case QuizAnswerTypes.Correct:
						correct++;
						break;
					case QuizAnswerTypes.Incorrect:
						incorrect++;
						break;
				}
			}
		}
	}
}
