using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
    internal class QuizDM
    {
		private static QuizDM instance = new QuizDM();

        private QuizDM()
		{
		}

        public static QuizDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Quiz GetByID(int id)
		{
			Quiz quiz = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quiz.QuizID, Quiz.Name, Quiz.Category1 FROM Quiz WHERE Quiz.QuizID = :QuizID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = id;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					quiz = new Quiz();

					quiz.ID = reader.GetInt32(0);
					quiz.Name = reader.GetString(1);
					quiz.Category = reader.GetString(2);
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

        public List<Quiz> GetList(int collectionID)
        {
            List<Quiz> list = new List<Quiz>();

            IDbConnection conn = ApplicationSettings.CreateConnection();
            IDbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Quiz.QuizID, Quiz.Name, Quiz.Category1 FROM Quiz WHERE QuizID IN (SELECT QuizID FROM CollectionsQuiz WHERE CollectionID = :CollectionID) ORDER BY Name";
                cmd.CommandType = CommandType.Text;

                IDbDataParameter collectionIDParam = cmd.CreateParameter();
                collectionIDParam.ParameterName = ":CollectionID";
                collectionIDParam.Value = collectionID;
                cmd.Parameters.Add(collectionIDParam);

                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Quiz quiz = new Quiz();

                    quiz.ID = reader.GetInt32(0);
                    quiz.Name = reader.GetString(1);
					quiz.Category = reader.GetString(2);

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

        public Dictionary<string, List<Quiz>> GetCategorizedList(int collectionID)
        {
            Dictionary<string, List<Quiz>> list = new Dictionary<string, List<Quiz>>();

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
					cmd.CommandText = "SELECT Quiz.QuizID, Quiz.Name, Quiz.Category1 FROM Quiz WHERE (Category1 = :CategoryName OR Category2 = :CategoryName OR Category3 = :CategoryName) AND (Quiz.QuizID IN (SELECT CollectionsQuiz.QuizID FROM CollectionsQuiz WHERE CollectionsQuiz.CollectionID = :CollectionID)) ORDER BY Name";
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

                        List<Quiz> quizzes = new List<Quiz>();

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Quiz quiz = new Quiz();

                            quiz.ID = reader.GetInt32(0);
                            quiz.Name = reader.GetString(1);
							quiz.Category = reader.GetString(2);

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

		public List<int> GetThingsInQuiz(int quizID)
		{
			List<int> thingIDList = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quizzes.ThingID FROM Quizzes WHERE Quizzes.QuizID = :QuizID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = quizID;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					thingIDList.Add(reader.GetInt32(0));
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

			return thingIDList;
		}
    }
}
