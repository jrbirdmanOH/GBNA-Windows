using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	class ThingCustomMediaDM
	{
		private static ThingCustomMediaDM instance = new ThingCustomMediaDM();

		private ThingCustomMediaDM()
		{
		}

		public static ThingCustomMediaDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(int thingID, int mediaID, IDbTransaction trans)
		{
			if (Exists(thingID, mediaID, trans))
			{
				// No need to update
			}
			else
			{
				int order = GetNextOrder(thingID, trans);
				Insert(thingID, mediaID, order, trans);
			}
		}

		public void Save(int thingID, int mediaID, int order, IDbTransaction trans)
		{
			if (Exists(thingID, mediaID, trans))
			{
				Update(thingID, mediaID, order, trans);
			}
			else
			{
				if (order == 0)
				{
					order = GetNextOrder(thingID, trans);
				}
				Insert(thingID, mediaID, order, trans);
			}
		}

		protected void Insert(int thingID, int mediaID, int order, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("INSERT INTO ThingMedia (ThingID, MediaID, [Order]) VALUES (:ThingID, :MediaID, :Order)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

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

		protected void Update(int thingID, int mediaID, int order, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("UPDATE ThingMedia SET [Order]=:Order WHERE ThingID=:ThingID AND MediaID=:MediaID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter orderParam = cmd.CreateParameter();
				orderParam.ParameterName = ":Order";
				orderParam.Value = order;
				cmd.Parameters.Add(orderParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

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

		public void Delete(int thingID, int mediaID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM ThingMedia WHERE ThingMedia.ThingID=:ThingID AND ThingMedia.MediaID=:MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

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
				cmd.CommandText = "DELETE FROM ThingMedia WHERE ThingMedia.MediaID=:MediaID";
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

		public void DeleteByThingID(int thingID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM ThingMedia WHERE ThingMedia.ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":ThingID";
				idParam.Value = thingID;
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
				StringBuilder sql = new StringBuilder("SELECT COUNT(ThingID) FROM ThingMedia WHERE MediaID=:MediaID");
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

		private bool Exists(int thingID, int mediaID, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("SELECT COUNT(ThingID) FROM ThingMedia WHERE ThingID=:ThingID AND MediaID=:MediaID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

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

		private int GetNextOrder(int thingID, IDbTransaction trans)
		{
			int nextOrder = 0;

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
				StringBuilder sql = new StringBuilder("SELECT MAX([Order]) + 1 FROM ThingMedia WHERE ThingID=:ThingID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				object result = cmd.ExecuteScalar();
				nextOrder = result == DBNull.Value ? 1 : Convert.ToInt32(result);
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

			return nextOrder;
		}
	}
}
