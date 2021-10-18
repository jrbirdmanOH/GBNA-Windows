using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class HallOfFame
	{
		private int id = 0;
		private string quizName = string.Empty;
		private string name = string.Empty;
		private string quizType = string.Empty;
		private string difficultyLevel = string.Empty;
		private string language = string.Empty;
		private DateTime date;
		private int score = 0;
		private int maxPossible = 0;

		public HallOfFame()
		{
		}

		public int ID
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
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

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
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

		public DateTime Date
		{
			get
			{
				return date;
			}

			set
			{
				date = value;
			}
		}

		public int Score
		{
			get
			{
				return score;
			}

			set
			{
				score = value;
			}
		}

		public int MaxPossible
		{
			get
			{
				return maxPossible;
			}

			set
			{
				maxPossible = value;
			}
		}

		public int Percentage
		{
			get
			{
				return CalculatePercentage(Score, MaxPossible);
			}
		}

		private static int CalculatePercentage(double score, double maxPossible)
		{
			return Convert.ToInt32(Math.Round((score / maxPossible) * 100.0, MidpointRounding.AwayFromZero));
		}

		public static string GetQuizTypeCode(QuizSettings.QuizTypes quizType)
		{
			string code = string.Empty;

			switch (quizType)
			{
				case QuizSettings.QuizTypes.MultipleChoice:
					code = "MC";
					break;
				case QuizSettings.QuizTypes.FillInTheBlank:
					code = "FITB";
					break;
				case QuizSettings.QuizTypes.FlashCards:
					// Hall of Fame does not apply to Flash Card quiz type
					break;
				case QuizSettings.QuizTypes.PickOne:
					code = "PM";
					break;
			}

			return code;
		}

		public static string GetQuizTypeString(string code)
		{
			string type = string.Empty;

			if (code == "MC")
			{
				type = "Multiple Choice";
			}
			else if (code == "FITB")
			{
				type = "Fill in the Blank";
			}
			else if (code == "PM")
			{
				type = "Pick One";
			}
			else
			{
				type = "Unknown";
			}

			return type;
		}

		public static string GetDifficultyLevelCode(QuizSettings.DifficultyLevels difficultyLevel)
		{
			string code = string.Empty;

			switch (difficultyLevel)
			{
				case QuizSettings.DifficultyLevels.Easy:
					code = "E";
					break;
				case QuizSettings.DifficultyLevels.Medium:
					code = "M";
					break;
				case QuizSettings.DifficultyLevels.Hard:
					code = "H";
					break;
			}

			return code;
		}

		public static string GetDifficultyLevelString(string code)
		{
			string difficultyLevel = string.Empty;

			if (code == "E")
			{
				difficultyLevel = "Easy";
			}
			else if (code == "M")
			{
				difficultyLevel = "Medium";
			}
			else if (code == "H")
			{
				difficultyLevel = "Hard";
			}

			return difficultyLevel;
		}

		public static string GetLanguageCode(QuizSettings.Languages language)
		{
			string code = string.Empty;

			switch (language)
			{
				case QuizSettings.Languages.Common:
					code = "C";
					break;
				case QuizSettings.Languages.Scientific:
					code = "S";
					break;
				case QuizSettings.Languages.BandCode:
					code = "B";
					break;
				case QuizSettings.Languages.All:
					code = "A";
					break;
			}

			return code;
		}

		public static string GetLanguageString(string code)
		{
			string language = string.Empty;

			if (code == "C")
			{
				language = "Common Name";
			}
			else if (code == "S")
			{
				language = "Scientific Name";
			}
			else if (code == "B")
			{
				language = "Bird Codes";
			}
			else if (code == "A")
			{
				language = "Common & Scientific Name with Bird Codes";
			}

			return language;
		}

		public static List<HallOfFame> GetList()
		{
			return HallOfFameDM.Instance.GetList();
		}

		public static List<HallOfFame> GetListByCriteria(HallOfFameCriteria criteria)
		{
			return HallOfFameDM.Instance.GetListByCriteria(criteria);
		}

		public static List<string> GetListOfUniqueQuizNames()
		{
			return HallOfFameDM.Instance.GetListOfUniqueQuizNames();
		}

		public static void DeleteAll()
		{
			DeleteAll(null);
		}

		public static void DeleteAll(IDbTransaction trans)
		{
			HallOfFameDM.Instance.DeleteAll(trans);
		}

		public static void DeleteByQuizNames(List<string> quizNames)
		{
			HallOfFameDM.Instance.DeleteByQuizNames(quizNames);
		}

		public void Delete()
		{
			HallOfFameDM.Instance.DeleteByID(this.ID);
		}

		public void Save()
		{
			Save(null);
		}

		public void Save(IDbTransaction trans)
		{
			HallOfFameDM.Instance.Save(this, trans);
		}

		public bool Exists()
		{
			return HallOfFameDM.Instance.Exists(this);
		}

		public static void OnNumberOfHallOfFameTopScorersChanged()
		{
			string lastQuizName = string.Empty;
			string lastQuizType = string.Empty;
			string lastDifficultyLevel = string.Empty;
			string lastLanguage = string.Empty;

			List<HallOfFame> hallOfFameList = HallOfFame.GetList();
			if (hallOfFameList.Count > 0)
			{
				int numTopScorersInGroup = 0;
				foreach (HallOfFame hallOfFame in hallOfFameList)
				{
					if (hallOfFame.QuizName != lastQuizName || hallOfFame.QuizType != lastQuizType || hallOfFame.Language != lastLanguage || hallOfFame.DifficultyLevel != lastDifficultyLevel)
					{
						numTopScorersInGroup = 1;
						lastQuizName = hallOfFame.QuizName;
						lastQuizType = hallOfFame.QuizType;
						lastDifficultyLevel = hallOfFame.DifficultyLevel;
						lastLanguage = hallOfFame.Language;
					}
					else
					{
						numTopScorersInGroup++;
					}

					if (numTopScorersInGroup > ApplicationSettings.NumberOfHallOfFameTopScorers)
					{
						hallOfFame.Delete();
					}
				}
			}
		}

		public static bool CanAddToHallOfFame(HallOfFameCriteria criteria, int score, int maxScore, out HallOfFame hallOfFameEntryToPurgeIfAdded)
		{
			bool addToHallOfFame = false;
			hallOfFameEntryToPurgeIfAdded = null;

			if (ApplicationSettings.EnableHallOfFame)
			{
				List<HallOfFame> hallOfFameList = HallOfFame.GetListByCriteria(criteria);

				if (hallOfFameList.Count < ApplicationSettings.NumberOfHallOfFameTopScorers)
				{
					addToHallOfFame = true;
				}
				else if (hallOfFameList.Count > 0)
				{
					// Compare against lowest score in current list
					HallOfFame hallOfFameCutoff = hallOfFameList[hallOfFameList.Count - 1];

					int percentage = HallOfFame.CalculatePercentage(score, maxScore);
					if (percentage > hallOfFameCutoff.Percentage)
					{
						addToHallOfFame = true;
						hallOfFameEntryToPurgeIfAdded = hallOfFameCutoff;						
					}
				}
			}

			return addToHallOfFame;
		}
	}
}
