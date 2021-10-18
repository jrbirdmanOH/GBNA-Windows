using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomListDM
	{
		private static CustomListDM instance = new CustomListDM();

		private CustomListDM()
		{
		}

		public static CustomListDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<CustomList> GetList()
		{
			List<CustomList> list = new List<CustomList>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				StringBuilder sql = new StringBuilder("SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified FROM CustomLists WHERE (Hide=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(false));
				sql.Append(" AND TemporaryList=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(false));
				sql.Append(") AND Length > 0");

				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomList customList = new CustomList();

					customList.ID = reader.GetInt32(0);
					customList.Name = reader.GetString(1);
					customList.Author = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					customList.Length = reader.GetInt32(3);
					customList.CollectionID = reader.GetInt32(4);
					customList.DateCreated = reader.GetDateTime(5);
					customList.DateModified = !reader.IsDBNull(6) ? (DateTime?)reader.GetDateTime(6) : null;

					list.Add(customList);
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

		public List<CustomList> GetList(int collectionID, bool includeEmpty)
		{
			List<CustomList> list = new List<CustomList>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				StringBuilder sql = new StringBuilder("SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified FROM CustomLists WHERE CollectionID=:CollectionID AND (Hide=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(false));
				sql.Append(" OR TemporaryList=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(true));
				sql.Append(")");
				if (!includeEmpty)
				{
					sql.Append(" AND Length > 0");
				}
				sql.Append(" ORDER BY Name");

				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomList customList = new CustomList();

					customList.ID = reader.GetInt32(0);
					customList.Name = reader.GetString(1);
					customList.Author = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					customList.Length = reader.GetInt32(3);
					customList.CollectionID = reader.GetInt32(4);
					customList.DateCreated = reader.GetDateTime(5);
					customList.DateModified = !reader.IsDBNull(6) ? (DateTime?)reader.GetDateTime(6) : null;

					list.Add(customList);
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

		public CustomList GetTemporaryList()
		{
			CustomList customList = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified FROM CustomLists WHERE TemporaryList=" + ApplicationSettings.GetDBBooleanValue(true);
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					customList = new CustomList();

					customList.ID = reader.GetInt32(0);
					customList.Name = reader.GetString(1);
					customList.Author = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					customList.Length = reader.GetInt32(3);
					customList.CollectionID = reader.GetInt32(4);
					customList.DateCreated = reader.GetDateTime(5);
					customList.DateModified = !reader.IsDBNull(6) ? (DateTime?)reader.GetDateTime(6) : null;
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

			return customList;
		}

		public CustomList GetByID(int id)
		{
			CustomList customList = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified FROM CustomLists WHERE CustomListID=:CustomListID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter customListIDParam = cmd.CreateParameter();
				customListIDParam.ParameterName = ":CustomListID";
				customListIDParam.Value = id;
				cmd.Parameters.Add(customListIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					customList = new CustomList();

					customList.ID = reader.GetInt32(0);
					customList.Name = reader.GetString(1);
					customList.Author = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					customList.Length = reader.GetInt32(3);
					customList.CollectionID = reader.GetInt32(4);
					customList.DateCreated = reader.GetDateTime(5);
					customList.DateModified = !reader.IsDBNull(6) ? (DateTime?)reader.GetDateTime(6) : null;
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

			return customList;
		}

		public void Delete(int id, IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM CustomLists WHERE CustomListID=:CustomListID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomListID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public void Save(CustomList list, IDbTransaction trans)
		{
			if (list.ID == 0)
			{
				Insert(list, trans);
			}
			else
			{
				Update(list, trans);
			}
		}

		protected void Insert(CustomList list, IDbTransaction trans)
		{
			IDbConnection conn;
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
				StringBuilder sql = new StringBuilder("INSERT INTO CustomLists (Name, Author, Length, CollectionID, DateCreated, DateModified, Hide, TemporaryList) VALUES (:Name, :Author, :Length, :CollectionID, :DateCreated, :DateModified, ");
				sql.Append(ApplicationSettings.GetDBBooleanValue(false));
				sql.Append(", ");
				sql.Append(ApplicationSettings.GetDBBooleanValue(false));
				sql.Append(")");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = list.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter authorParam = cmd.CreateParameter();
				authorParam.ParameterName = ":Author";
				authorParam.Value = list.Author;
				cmd.Parameters.Add(authorParam);

				IDbDataParameter lengthParam = cmd.CreateParameter();
				lengthParam.ParameterName = ":Length";
				lengthParam.Value = list.Length;
				cmd.Parameters.Add(lengthParam);

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = list.CollectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter dateCreatedParam = cmd.CreateParameter();
				dateCreatedParam.ParameterName = ":DateCreated";
				dateCreatedParam.Value = ApplicationSettings.GetDBDateTimeValue(list.DateCreated);
				cmd.Parameters.Add(dateCreatedParam);

				IDbDataParameter dateModifiedParam = cmd.CreateParameter();
				dateModifiedParam.ParameterName = ":DateModified";
				dateModifiedParam.Value = ApplicationSettings.GetDBDateTimeValue(list.DateModified);
				cmd.Parameters.Add(dateModifiedParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				list.ID = ApplicationSettings.GetIdentityValue(conn, trans);
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if(trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		protected void Update(CustomList list, IDbTransaction trans)
		{
			IDbConnection conn;
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
				cmd.CommandText = "UPDATE CustomLists SET Name=:Name, Author=:Author, Length=:Length, CollectionID=:CollectionID, DateCreated=:DateCreated, DateModified=:DateModified WHERE CustomListID=:CustomListID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = list.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter authorParam = cmd.CreateParameter();
				authorParam.ParameterName = ":Author";
				authorParam.Value = list.Author;
				cmd.Parameters.Add(authorParam);

				IDbDataParameter lengthParam = cmd.CreateParameter();
				lengthParam.ParameterName = ":Length";
				lengthParam.Value = list.Length;
				cmd.Parameters.Add(lengthParam);

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = list.CollectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter dateCreatedParam = cmd.CreateParameter();
				dateCreatedParam.ParameterName = ":DateCreated";
				dateCreatedParam.Value = ApplicationSettings.GetDBDateTimeValue(list.DateCreated);
				cmd.Parameters.Add(dateCreatedParam);

				IDbDataParameter dateModifiedParam = cmd.CreateParameter();
				dateModifiedParam.ParameterName = ":DateModified";
				list.DateModified = DateTime.Now;
				dateModifiedParam.Value = ApplicationSettings.GetDBDateTimeValue(list.DateModified);
				cmd.Parameters.Add(dateModifiedParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomListID";
				idParam.Value = list.ID;
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

		public bool Exists(CustomList list, IDbTransaction trans)
		{
			bool bExists = false;

			IDbConnection conn;
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
				// Right now only need to check for existence by name, author, and collection ID
				StringBuilder sql = new StringBuilder("SELECT COUNT(CustomListID) FROM CustomLists WHERE Name=:Name AND Author=:Author AND CollectionID=:CollectionID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter nameParam = cmd.CreateParameter();
				nameParam.ParameterName = ":Name";
				nameParam.Value = list.Name;
				cmd.Parameters.Add(nameParam);

				IDbDataParameter authorParam = cmd.CreateParameter();
				authorParam.ParameterName = ":Author";
				authorParam.Value = list.Author;
				cmd.Parameters.Add(authorParam);

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = list.CollectionID;
				cmd.Parameters.Add(collectionIDParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				bExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

			return bExists;
		}
	}
}
