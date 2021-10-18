using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomQuizCategoryDM
	{
		private static CustomQuizCategoryDM instance = new CustomQuizCategoryDM();

		private CustomQuizCategoryDM()
		{
		}

		public static CustomQuizCategoryDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(CustomQuizCategory category, IDbTransaction trans)
		{
			if (category.ID == 0)
			{
				Insert(category, trans);
			}
			else
			{
				Update(category, trans);
			}
		}

		protected void Insert(CustomQuizCategory category, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("INSERT INTO QuizCategory (Name) VALUES (:Name)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = category.Name;
				cmd.Parameters.Add(nameParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				category.ID = ApplicationSettings.GetIdentityValue(conn, trans);
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

		protected void Update(CustomQuizCategory category, IDbTransaction trans)
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
				cmd.CommandText = "UPDATE QuizCategory SET Name=:Name WHERE QuizCategory.ID=:QuizCategoryID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = category.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":QuizCategoryID";
				idParam.Value = category.ID;
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
				cmd.CommandText = "DELETE FROM QuizCategory WHERE QuizCategory.ID=:QuizCategoryID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":QuizCategoryID";
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

		public void DeleteList(List<CustomQuizCategory> categories)
		{
			if (categories.Count > 0)
			{
				IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				IDbCommand cmd = null;
				try
				{
					StringBuilder commandText = new StringBuilder();
					commandText.Append("DELETE FROM QuizCategory WHERE QuizCategory.ID IN (");

					int index = 0;
					foreach (CustomQuizCategory category in categories)
					{
						commandText.Append(category.ID.ToString());

						if (index != categories.Count - 1)
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

		public CustomQuizCategory GetByID(int id)
		{
			CustomQuizCategory category = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT QuizCategory.ID, QuizCategory.Name FROM QuizCategory WHERE QuizCategory.ID = :QuizCategoryID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizCategoryIDParam = cmd.CreateParameter();
				quizCategoryIDParam.ParameterName = ":QuizCategoryID";
				quizCategoryIDParam.Value = id;
				cmd.Parameters.Add(quizCategoryIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					category = new CustomQuizCategory();

					category.ID = reader.GetInt32(0);
					category.Name = reader.GetString(1);
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

			return category;
		}

		public CustomQuizCategory GetByName(string name)
		{
			CustomQuizCategory category = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT QuizCategory.ID, QuizCategory.Name FROM QuizCategory WHERE QuizCategory.Name = :QuizCategoryName";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizCategoryNameParam = cmd.CreateParameter();
				quizCategoryNameParam.ParameterName = ":QuizCategoryName";
				quizCategoryNameParam.Value = name;
				cmd.Parameters.Add(quizCategoryNameParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					category = new CustomQuizCategory();

					category.ID = reader.GetInt32(0);
					category.Name = reader.GetString(1);
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

			return category;
		}

		public List<CustomQuizCategory> GetList()
		{
			List<CustomQuizCategory> list = new List<CustomQuizCategory>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				StringBuilder sql = new StringBuilder("SELECT QuizCategory.ID, QuizCategory.Name FROM QuizCategory ORDER BY QuizCategory.Name");
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomQuizCategory category = new CustomQuizCategory();

					category.ID = reader.GetInt32(0);
					category.Name = reader.GetString(1);

					list.Add(category);
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
	}
}
