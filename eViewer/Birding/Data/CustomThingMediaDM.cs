using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	class CustomThingMediaDM
	{
		private static CustomThingMediaDM instance = new CustomThingMediaDM();

		private CustomThingMediaDM()
		{
		}

		public static CustomThingMediaDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(int customThingID, int mediaID, int order, IDbTransaction trans)
		{
			if (Exists(customThingID, mediaID, trans))
			{
				Update(customThingID, mediaID, order, trans);
			}
			else
			{
				Insert(customThingID, mediaID, order, trans);
			}
		}

		protected void Insert(int customThingID, int mediaID, int order, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("INSERT INTO CustomThingMedia (CustomThingID, MediaID, [Order]) VALUES (:CustomThingID, :MediaID, :Order)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

				IDbDataParameter orderParam = cmd.CreateParameter();
				orderParam.ParameterName = ":Order";
				orderParam.Value = order;
				cmd.Parameters.Add(orderParam);

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

		protected void Update(int customThingID, int mediaID, int order, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("UPDATE CustomThingMedia SET [Order]=:Order WHERE CustomThingID=:CustomThingID AND MediaID=:MediaID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter orderParam = cmd.CreateParameter();
				orderParam.ParameterName = ":Order";
				orderParam.Value = order;
				cmd.Parameters.Add(orderParam);

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

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

		public void Delete(int customThingID, int mediaID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM CustomThingMedia WHERE CustomThingMedia.CustomThingID=:CustomThingID AND CustomThingMedia.MediaID=:MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

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
/*
		public void DeleteByMediaID(int mediaID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM CustomThingMedia WHERE CustomThingMedia.MediaID=:MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":MediaID";
				idParam.Value = mediaID;
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
*/
		public void DeleteByCustomThingID(int customThingID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM CustomThingMedia WHERE CustomThingMedia.CustomThingID=:CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = customThingID;
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

		public bool IsMediaReferenced(int mediaID, IDbTransaction trans)
		{
			bool bExists = false;

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
				StringBuilder sql = new StringBuilder("SELECT COUNT(CustomThingID) FROM CustomThingMedia WHERE MediaID=:MediaID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

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

		private bool Exists(int customThingID, int mediaID, IDbTransaction trans)
		{
			bool bExists = false;

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
				StringBuilder sql = new StringBuilder("SELECT COUNT(CustomThingID) FROM CustomThingMedia WHERE CustomThingID=:CustomThingID AND MediaID=:MediaID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

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
