using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI.Quiz;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public class HallOfFameManager : IHallOfFameManager
	{
		private static HallOfFameManager instance = null;

		public static HallOfFameManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new HallOfFameManager();
				}

				return instance;
			}
		}

		private HallOfFameManager()
		{
		}

		#region IHallOfFameManager Members

		public void ProcessQuizForHallOfFame(QuizEngine quizEngine)
		{
			if (ApplicationSettings.EnableHallOfFame)
			{
				// Set criteria to check for adding to Hall of Fame
				HallOfFameCriteria criteria = new HallOfFameCriteria();
				criteria.QuizName = quizEngine.QuizSettings.QuizSource.Name;
				criteria.QuizType = HallOfFame.GetQuizTypeCode(quizEngine.QuizSettings.QuizType);
				criteria.DifficultyLevel = HallOfFame.GetDifficultyLevelCode(quizEngine.QuizSettings.DifficultyLevel);
				criteria.Language = HallOfFame.GetLanguageCode(quizEngine.QuizSettings.Language);

				HallOfFame hallOfFameEntryToPurgeIfAdded;
				bool addToHallOfFame = HallOfFame.CanAddToHallOfFame(criteria, quizEngine.QuizScore.Correct, quizEngine.QuizScore.Total, out hallOfFameEntryToPurgeIfAdded);
				if (addToHallOfFame)
				{
					quizEngine.MediaPlayer.PlaySound(ApplicationSettings.HallOfFameSoundEffectLocation, false);

					HallOfFameNameForm nameForm = new HallOfFameNameForm();
					DialogResult nameFormResult = nameForm.ShowDialog();
					if (nameFormResult == DialogResult.OK)
					{
						// Create new Hall of Fame entry
						HallOfFame hallOfFameNew = new HallOfFame();
						hallOfFameNew.Name = nameForm.UserName;
						hallOfFameNew.QuizName = criteria.QuizName;
						hallOfFameNew.QuizType = criteria.QuizType;
						hallOfFameNew.DifficultyLevel = criteria.DifficultyLevel;
						hallOfFameNew.Language = criteria.Language;
						hallOfFameNew.Date = DateTime.Now;
						hallOfFameNew.Score = quizEngine.QuizScore.Correct;
						hallOfFameNew.MaxPossible = quizEngine.QuizScore.Total;

						hallOfFameNew.Save();

						// Purge Hall of Fame entry that no longer qualifies to
						// be in the list of top scorers after adding new one
						if (hallOfFameEntryToPurgeIfAdded != null)
						{
							hallOfFameEntryToPurgeIfAdded.Delete();
						}

						DialogResult showHallOfFameResult = MessageBox.Show("You've been added to the Hall of Fame.  Would you like to see it?", "Hall of Fame", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (showHallOfFameResult == DialogResult.Yes)
						{
							HallOfFameForm form = new HallOfFameForm();
							form.ShowDialog();
						}
					}
				}
			}
		}

		public void ShowHallOfFame()
		{
			HallOfFameForm form = new HallOfFameForm();
			form.ShowDialog();
		}

		#endregion
	}
}
