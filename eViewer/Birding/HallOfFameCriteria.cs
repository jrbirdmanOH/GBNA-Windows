using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public class HallOfFameCriteria
	{
		private string quizName = string.Empty;
		private string quizType = string.Empty;
		private string difficultyLevel = string.Empty;
		private string language = string.Empty;

		public HallOfFameCriteria()
		{
		}

		public string QuizName
		{
			get
			{
				return quizName;
			}

			set
			{
				quizName = value;
			}
		}

		public string QuizType
		{
			get
			{
				return quizType;
			}

			set
			{
				quizType = value;
			}
		}

		public string DifficultyLevel
		{
			get
			{
				return difficultyLevel;
			}

			set
			{
				difficultyLevel = value;
			}
		}

		public string Language
		{
			get
			{
				return language;
			}

			set
			{
				language = value;
			}
		}
	}
}
