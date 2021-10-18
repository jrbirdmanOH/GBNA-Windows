using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class HallOfFameDM
	{
		private static HallOfFameDM instance = new HallOfFameDM();

		private HallOfFameDM()
		{
		}

		public static HallOfFameDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<HallOfFame> GetList()
		{
			List<HallOfFame> list = new List<HallOfFame>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM [Hall Of Fame] ORDER BY [QuizName] ASC, [QuizType], [DifficultyLevel], ([Score]/[Max Possible]) DESC, [Date] ASC";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					HallOfFame hallOfFame = new HallOfFame();

					hallOfFame.ID = reader.GetInt32(0);
					hallOfFame.QuizName = reader.GetString(1);
					hallOfFame.Name = reader.GetString(2);
					hallOfFame.QuizType = reader.GetString(3);
					hallOfFame.DifficultyLevel = reader.GetString(4);
					hallOfFame.Language = reader.GetString(5);
					hallOfFame.Date = reader.GetDateTime(6);
					hallOfFame.Score = reader.GetInt32(7);
					hallOfFame.MaxPossible = reader.GetInt32(8);

					list.Add(hallOfFame);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public List<HallOfFame> GetListByCriteria(HallOfFameCriteria criteria)
		{
			List<HallOfFame> list = new List<HallOfFame>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM [Hall Of Fame] WHERE [QuizName] = :QuizName AND [QuizType] = :QuizType AND [DifficultyLevel] = :DifficultyLevel AND [Language] = :Language ORDER BY ([Score]/[Max Possible]) DESC, [Date] ASC";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizNameParam = cmd.CreateParameter();
				quizNameParam.ParameterName = ":QuizName";
				quizNameParam.Value = criteria.QuizName;
				cmd.Parameters.Add(quizNameParam);

				IDbDataParameter quizTypeParam = cmd.CreateParameter();
				quizTypeParam.ParameterName = ":QuizType";
				quizTypeParam.Value = criteria.QuizType;
				cmd.Parameters.Add(quizTypeParam);

				IDbDataParameter difficultyLevelParam = cmd.CreateParameter();
				difficultyLevelParam.ParameterName = ":DifficultyLevel";
				difficultyLevelParam.Value = criteria.DifficultyLevel;
				cmd.Parameters.Add(difficultyLevelParam);

				IDbDataParameter languageParam = cmd.CreateParameter();
				languageParam.ParameterName = ":Language";
				languageParam.Value = criteria.Language;
				cmd.Parameters.Add(languageParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					HallOfFame hallOfFame = new HallOfFame();

					hallOfFame.ID = reader.GetInt32(0);
					hallOfFame.QuizName = reader.GetString(1);
					hallOfFame.Name = reader.GetString(2);
					hallOfFame.QuizType = reader.GetString(3);
					hallOfFame.DifficultyLevel = reader.GetString(4);
					hallOfFame.Language = reader.GetString(5);
					hallOfFame.Date = reader.GetDateTime(6);
					hallOfFame.Score = reader.GetInt32(7);
					hallOfFame.MaxPossible = reader.GetInt32(8);

					list.Add(hallOfFame);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public List<string> GetListOfUniqueQuizNames()
		{
			List<string> list = new List<string>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT DISTINCT QuizName FROM [Hall Of Fame] ORDER BY [QuizName] ASC;";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					list.Add(reader.GetString(0));
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public void DeleteAll(IDbTransaction trans)
		{
			IDbConnection conn = null;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}

			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "DELETE FROM [Hall Of Fame]";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		public void DeleteByID(int id)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "DELETE FROM [Hall Of Fame] WHERE HOFid = :ID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":ID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void DeleteByQuizNames(List<string> quizNames)
		{
			if (quizNames.Count > 0)
			{
				IDbConnection conn = ApplicationSettings.CreateConnection();
				IDbCommand cmd = null;
				try
				{
					StringBuilder commandText = new StringBuilder();
					commandText.Append("DELETE FROM [Hall Of Fame] WHERE QuizName IN (");

					int index = 0;
					foreach (string quizName in quizNames)
					{
						commandText.Append("'");
						commandText.Append(quizName);
						commandText.Append("'");

						if (index != quizNames.Count - 1)
						{
							commandText.Append(", ");
						}

						index++;
					}

					commandText.Append(")");

					cmd = conn.CreateCommand();
					cmd.CommandText = commandText.ToString();
					cmd.CommandType = CommandType.Text;

					conn.Open();
					cmd.ExecuteNonQuery();
				}
				finally
				{
					if (cmd != null)
					{
						cmd.Dispose();
					}

					if (conn != null)
					{
						conn.Close();
					}
				}
			}
		}

		public void Save(HallOfFame hallOfFame, IDbTransaction trans)
		{
			IDbConnection conn = null;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}

			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "INSERT INTO [Hall Of Fame] ([QuizName], [Name], [QuizType], [DifficultyLevel], [Language], [Date], [Score], [Max Possible]) VALUES (:QuizName, :Name, :QuizType, :DifficultyLevel, :Language, :Date, :Score, :MaxPossible)";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter quizNameParam = cmd.CreateParameter();
				quizNameParam.ParameterName = ":QuizName";
				quizNameParam.Value = hallOfFame.QuizName;
				cmd.Parameters.Add(quizNameParam);

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = hallOfFame.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter quizTypeParam = cmd.CreateParameter();
				quizTypeParam.ParameterName = ":QuizType";
				quizTypeParam.Value = hallOfFame.QuizType;
				cmd.Parameters.Add(quizTypeParam);

				IDbDataParameter difficultyLevelParam = cmd.CreateParameter();
				difficultyLevelParam.ParameterName = ":DifficultyLevel";
				difficultyLevelParam.Value = hallOfFame.DifficultyLevel;
				cmd.Parameters.Add(difficultyLevelParam);

				IDbDataParameter languageParam = cmd.CreateParameter();
				languageParam.ParameterName = ":Language";
				languageParam.Value = hallOfFame.Language;
				cmd.Parameters.Add(languageParam);

				IDbDataParameter dateParam = cmd.CreateParameter();
				dateParam.ParameterName = ":Date";
				dateParam.Value = ApplicationSettings.GetDBDateTimeValue(hallOfFame.Date);
				cmd.Parameters.Add(dateParam);

				IDbDataParameter scoreParam = cmd.CreateParameter();
				scoreParam.ParameterName = ":Score";
				scoreParam.Value = hallOfFame.Score;
				cmd.Parameters.Add(scoreParam);

				IDbDataParameter maxPossibleParam = cmd.CreateParameter();
				maxPossibleParam.ParameterName = ":MaxPossible";
				maxPossibleParam.Value = hallOfFame.MaxPossible;
				cmd.Parameters.Add(maxPossibleParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				cmd.ExecuteNonQuery();

				hallOfFame.ID = ApplicationSettings.GetIdentityValue(conn, trans);
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		public bool Exists(HallOfFame hallOfFame)
		{
			bool bExists = false;

			IDbConnection conn = null;
			IDbCommand cmd = null;

			try
			{
				conn = ApplicationSettings.CreateConnection();

				StringBuilder sql = new StringBuilder("SELECT COUNT(HOFid) FROM [Hall Of Fame] WHERE [QuizName] = :QuizName AND [Name] = :Name AND [QuizType] = :QuizType AND [DifficultyLevel] = :DifficultyLevel AND [Language] = :Language AND [Date] = :Date AND [Score] = :Score AND [Max Possible] = :MaxPossible");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizNameParam = cmd.CreateParameter();
				quizNameParam.ParameterName = ":QuizName";
				quizNameParam.Value = hallOfFame.QuizName;
				cmd.Parameters.Add(quizNameParam);

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = hallOfFame.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter quizTypeParam = cmd.CreateParameter();
				quizTypeParam.ParameterName = ":QuizType";
				quizTypeParam.Value = hallOfFame.QuizType;
				cmd.Parameters.Add(quizTypeParam);

				IDbDataParameter difficultyLevelParam = cmd.CreateParameter();
				difficultyLevelParam.ParameterName = ":DifficultyLevel";
				difficultyLevelParam.Value = hallOfFame.DifficultyLevel;
				cmd.Parameters.Add(difficultyLevelParam);

				IDbDataParameter languageParam = cmd.CreateParameter();
				languageParam.ParameterName = ":Language";
				languageParam.Value = hallOfFame.Language;
				cmd.Parameters.Add(languageParam);

				IDbDataParameter dateParam = cmd.CreateParameter();
				dateParam.ParameterName = ":Date";
				dateParam.Value = ApplicationSettings.GetDBDateTimeValue(hallOfFame.Date);
				cmd.Parameters.Add(dateParam);

				IDbDataParameter scoreParam = cmd.CreateParameter();
				scoreParam.ParameterName = ":Score";
				scoreParam.Value = hallOfFame.Score;
				cmd.Parameters.Add(scoreParam);

				IDbDataParameter maxPossibleParam = cmd.CreateParameter();
				maxPossibleParam.ParameterName = ":MaxPossible";
				maxPossibleParam.Value = hallOfFame.MaxPossible;
				cmd.Parameters.Add(maxPossibleParam);

				conn.Open();

				bExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return bExists;
		}
	}
}
