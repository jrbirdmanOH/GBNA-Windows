using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public class HallOfFameUI
	{
		public static string GenerateHTML(out bool hasEntries)
		{
			StringBuilder html = new StringBuilder();

			html.Append("<html><head></head><body><p><font face=\"Arial\" size=\"2\">");

			html.Append("<img src=\"file://");
			html.Append(Path.Combine(Environment.CurrentDirectory, "HallOfFame.jpg"));

			html.Append("\" width=\"60\" height=\"65\" align=\"middle\" />");
			html.Append("<font size=\"4\">&nbsp;Quiz Hall of Fame</font><br><br>");

			string lastQuizName = string.Empty;
			string lastQuizType = string.Empty;
			string lastDifficultyLevel = string.Empty;
			string lastLanguage = string.Empty;

			List<HallOfFame> hallOfFameList = HallOfFame.GetList();
			hasEntries = hallOfFameList.Count > 0;
			if (hasEntries)
			{
				foreach (HallOfFame hallOfFame in hallOfFameList)
				{
					if (hallOfFame.QuizName != lastQuizName)
					{
						if (lastQuizName.Length > 0)
						{
							html.Append("<br>");
						}

						html.Append("<b>&quot;");
						html.Append(hallOfFame.QuizName);
						html.Append("&quot;</b><br>");

						html.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
						html.Append(HallOfFame.GetQuizTypeString(hallOfFame.QuizType));
						html.Append("/");
						html.Append(HallOfFame.GetLanguageString(hallOfFame.Language));
						html.Append("/");
						html.Append(HallOfFame.GetDifficultyLevelString(hallOfFame.DifficultyLevel));
						html.Append("<br>");

						lastQuizName = hallOfFame.QuizName;
						lastQuizType = hallOfFame.QuizType;
						lastDifficultyLevel = hallOfFame.DifficultyLevel;
						lastLanguage = hallOfFame.Language;
					}
					else if (hallOfFame.QuizType != lastQuizType || hallOfFame.Language != lastLanguage || hallOfFame.DifficultyLevel != lastDifficultyLevel)
					{
						html.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
						html.Append(HallOfFame.GetQuizTypeString(hallOfFame.QuizType));
						html.Append("/");
						html.Append(HallOfFame.GetLanguageString(hallOfFame.Language));
						html.Append("/");
						html.Append(HallOfFame.GetDifficultyLevelString(hallOfFame.DifficultyLevel));
						html.Append("<br>");

						lastQuizType = hallOfFame.QuizType;
						lastDifficultyLevel = hallOfFame.DifficultyLevel;
						lastLanguage = hallOfFame.Language;
					}

					html.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>");
					html.Append(hallOfFame.Name);
					html.Append("</b>, ");
					html.Append(hallOfFame.Score);
					html.Append(" out of ");
					html.Append(hallOfFame.MaxPossible);
					html.Append(" correct, ");
					html.Append(hallOfFame.Percentage);
					html.Append("%, ");
					html.Append(hallOfFame.Date.ToShortDateString());
					html.Append("<br>");
				}
			}
			else
			{
				html.Append("<br><b>There are currently no entries in the Hall of Fame.</b><br>");
			}

			html.Append("</font></p></body></html>");

			return html.ToString();
		}
	}
}
