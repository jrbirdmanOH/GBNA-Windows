using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomQuizDM
	{
		private static CustomQuizDM instance = new CustomQuizDM();

		private CustomQuizDM()
		{
		}

		public static CustomQuizDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(CustomQuiz quiz, IDbTransaction trans)
		{
			if (quiz.ID == 0)
			{
				Insert(quiz, trans);
			}
			else
			{
				Update(quiz, trans);
			}
		}

		protected void Insert(CustomQuiz quiz, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				StringBuilder sql = new StringBuilder("INSERT INTO Quiz (Name, Author, CategoryID) VALUES (:Name, :Author, :CategoryID)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = quiz.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter authorParam = cmd.CreateParameter();
				authorParam.ParameterName = ":Author";
				authorParam.Value = quiz.Author;
				cmd.Parameters.Add(authorParam);

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = quiz.CategoryID;
				cmd.Parameters.Add(categoryIDParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				quiz.ID = ApplicationSettings.GetIdentityValue(conn, trans);
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

		protected void Update(CustomQuiz quiz, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE Quiz SET Name=:Name, Author=:Author, CategoryID=:CategoryID WHERE Quiz.ID=:QuizID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = quiz.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter authorParam = cmd.CreateParameter();
				authorParam.ParameterName = ":Author";
				authorParam.Value = quiz.Author;
				cmd.Parameters.Add(authorParam);

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = quiz.CategoryID;
				cmd.Parameters.Add(categoryIDParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":QuizID";
				idParam.Value = quiz.ID;
				cmd.Parameters.Add(idParam);

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

		public void Delete(int id, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM Quiz WHERE Quiz.ID=:QuizID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":QuizID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

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

		public CustomQuiz GetByID(int id)
		{
			CustomQuiz quiz = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quiz.ID, Quiz.Name, Quiz.Author, Quiz.CategoryID FROM Quiz WHERE Quiz.ID = :QuizID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = id;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					quiz = new CustomQuiz();

					quiz.ID = reader.GetInt32(0);
					quiz.Name = reader.GetString(1);
					quiz.Author = reader.GetString(2);
					quiz.CategoryID = reader.GetInt32(3);
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

			return quiz;
		}

		public List<CustomQuiz> GetList(int categoryID)
		{
			List<CustomQuiz> list = new List<CustomQuiz>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quiz.ID, Quiz.Name, Quiz.Author, Quiz.CategoryID FROM Quiz WHERE Quiz.CategoryID=:CategoryID ORDER BY Name";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomQuiz quiz = new CustomQuiz();

					quiz.ID = reader.GetInt32(0);
					quiz.Name = reader.GetString(1);
					quiz.Author = reader.GetString(2);
					quiz.CategoryID = reader.GetInt32(3);

					list.Add(quiz);
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
/*
		private List<string> GetCategoryList(int collectionID)
		{
			List<string> list = new List<string>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT DISTINCT Quiz.Category1 AS Category FROM Quiz, CollectionsQuiz WHERE Quiz.QuizID = CollectionsQuiz.QuizID AND (CollectionsQuiz.CollectionID = :CollectionID AND Quiz.Category1 Is Not Null) UNION SELECT Quiz.Category2 FROM Quiz, CollectionsQuiz WHERE Quiz.QuizID = CollectionsQuiz.QuizID AND (CollectionsQuiz.CollectionID = :CollectionID AND Quiz.Category2 Is Not Null) UNION SELECT Quiz.Category3 FROM Quiz, CollectionsQuiz WHERE Quiz.QuizID = CollectionsQuiz.QuizID AND (CollectionsQuiz.CollectionID = :CollectionID AND Quiz.Category3 Is Not Null) ORDER BY Category";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string categoryName = reader.GetString(0);
					list.Add(categoryName);
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

		public Dictionary<string, List<CustomQuiz>> GetCategorizedList(int collectionID)
		{
			Dictionary<string, List<CustomQuiz>> list = new Dictionary<string, List<CustomQuiz>>();

			// Get the list of available categories
			List<string> categories = GetCategoryList(collectionID);

			if (categories.Count > 0)
			{
				IDbConnection conn = ApplicationSettings.CreateConnection();
				IDbCommand cmd = null;
				IDataReader reader = null;
				try
				{
					cmd = conn.CreateCommand();
					cmd.CommandText = "SELECT Quiz.QuizID, Quiz.Name FROM Quiz WHERE (Category1 = :CategoryName OR Category2 = :CategoryName OR Category3 = :CategoryName) AND (Quiz.QuizID IN (SELECT CollectionsQuiz.QuizID FROM CollectionsQuiz WHERE CollectionsQuiz.CollectionID = :CollectionID)) ORDER BY Name";
					cmd.CommandType = CommandType.Text;

					IDbDataParameter collectionIDParam = cmd.CreateParameter();
					collectionIDParam.ParameterName = ":CollectionID";
					collectionIDParam.Value = collectionID;
					cmd.Parameters.Add(collectionIDParam);

					IDbDataParameter categoryNameParam = cmd.CreateParameter();
					categoryNameParam.ParameterName = ":CategoryName";
					cmd.Parameters.Add(categoryNameParam);

					conn.Open();

					// Get list of quizzes for each category
					foreach (string categoryName in categories)
					{
						// Set the parameter value
						categoryNameParam.Value = categoryName;

						List<CustomQuiz> quizzes = new List<CustomQuiz>();

						reader = cmd.ExecuteReader();
						while (reader.Read())
						{
							CustomQuiz quiz = new CustomQuiz();

							quiz.ID = reader.GetInt32(0);
							quiz.Name = reader.GetString(1);

							quizzes.Add(quiz);
						}
						reader.Close();

						// Make sure category has at least one quiz before adding to list
						if (quizzes.Count > 0)
						{
							list.Add(categoryName, quizzes);
						}
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
			}

			return list;
		}
*/
	}
}
