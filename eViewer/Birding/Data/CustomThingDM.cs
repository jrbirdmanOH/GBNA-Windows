using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomThingDM
	{
		private static CustomThingDM instance = new CustomThingDM();

		private CustomThingDM()
		{
		}

		public static CustomThingDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(CustomThing thing, IDbTransaction trans)
		{
			if (thing.ID == 0)
			{
				Insert(thing, trans);
			}
			else
			{
				Update(thing, trans);
			}
		}

		protected void Insert(CustomThing thing, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("INSERT INTO CustomThing (Name, AlternateName) VALUES (:Name, :AlternateName)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = thing.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter alternateNameParam = cmd.CreateParameter();
				alternateNameParam.ParameterName = ":AlternateName";
				alternateNameParam.Value = thing.AlternateNameOriginal;
				cmd.Parameters.Add(alternateNameParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				thing.ID = ApplicationSettings.GetIdentityValue(conn, trans);
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

		protected void Update(CustomThing thing, IDbTransaction trans)
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
				cmd.CommandText = "UPDATE CustomThing SET Name=:Name, AlternateName=:AlternateName WHERE CustomThing.ID=:CustomThingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = thing.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter alternateNameParam = cmd.CreateParameter();
				alternateNameParam.ParameterName = ":AlternateName";
				alternateNameParam.Value = thing.AlternateNameOriginal;
				cmd.Parameters.Add(alternateNameParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = thing.ID;
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
				cmd.CommandText = "DELETE FROM CustomThing WHERE CustomThing.ID=:CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
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

		public CustomThing GetByID(int id)
		{
			CustomThing thing = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThing.ID, CustomThing.Name, CustomThing.AlternateName FROM CustomThing WHERE CustomThing.ID = :CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = id;
				cmd.Parameters.Add(customThingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					thing = new CustomThing();

					thing.ID = reader.GetInt32(0);
					thing.Name = reader.GetString(1);
					thing.AlternateName = reader.GetString(2);
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

			return thing;
		}

		public List<CustomThing> GetByQuizID(int quizID)
		{
			List<CustomThing> things = new List<CustomThing>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThing.ID, CustomThing.Name, CustomThing.AlternateName FROM CustomThing, QuizCustomThing WHERE QuizCustomThing.QuizID=:QuizID AND CustomThing.ID=QuizCustomThing.CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = quizID;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomThing thing = new CustomThing();

					thing.ID = reader.GetInt32(0);
					thing.Name = reader.GetString(1);
					thing.AlternateName = reader.GetString(2);

					things.Add(thing);
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

			return things;
		}

		public List<CustomThing> GetByCategoryID(int categoryID)
		{
			List<CustomThing> things = new List<CustomThing>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThing.ID, CustomThing.Name, CustomThing.AlternateName FROM CustomThing, CategoryCustomThing WHERE CategoryCustomThing.CategoryID=:CategoryID AND CustomThing.ID=CategoryCustomThing.CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomThing thing = new CustomThing();

					thing.ID = reader.GetInt32(0);
					thing.Name = reader.GetString(1);
					thing.AlternateName = reader.GetString(2);

					things.Add(thing);
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

			return things;
		}

		public List<int> GetIDListByCategoryID(int categoryID)
		{
			List<int> list = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThing.ID FROM CustomThing, CategoryCustomThing WHERE CategoryCustomThing.CategoryID=:CategoryID AND CustomThing.ID=CategoryCustomThing.CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					list.Add(reader.GetInt32(0));
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
