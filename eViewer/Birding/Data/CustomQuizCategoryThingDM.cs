using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	class CustomQuizCategoryThingDM
	{
		private static CustomQuizCategoryThingDM instance = new CustomQuizCategoryThingDM();

		private CustomQuizCategoryThingDM()
		{
		}

		public static CustomQuizCategoryThingDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(int categoryID, int customThingID, IDbTransaction trans)
		{
			if (!Exists(categoryID, customThingID, trans))
			{
				Insert(categoryID, customThingID, trans);
			}
		}

		protected void Insert(int categoryID, int customThingID, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("INSERT INTO CategoryCustomThing (CategoryID, CustomThingID) VALUES (:CategoryID, :CustomThingID)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

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

		public void Delete(int categoryID, int customThingID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM CategoryCustomThing WHERE CategoryCustomThing.CategoryID=:CategoryID AND CategoryCustomThing.CustomThingID=:CustomThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = customThingID;
				cmd.Parameters.Add(thingIDParam);

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

		public void DeleteByCategoryID(int categoryID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM CategoryCustomThing WHERE CategoryCustomThing.CategoryID=:CategoryID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CategoryID";
				idParam.Value = categoryID;
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
				cmd.CommandText = "DELETE FROM CategoryCustomThing WHERE CategoryCustomThing.CustomThingID=:CustomThingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

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

		public bool IsCustomThingReferenced(int customThingID, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("SELECT COUNT(CustomThingID) FROM CategoryCustomThing WHERE CustomThingID=:CustomThingID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = customThingID;
				cmd.Parameters.Add(idParam);

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

		private bool Exists(int categoryID, int customThingID, IDbTransaction trans)
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
				StringBuilder sql = new StringBuilder("SELECT COUNT(CategoryID) FROM CategoryCustomThing WHERE CategoryID=:CategoryID AND CustomThingID=:CustomThingID");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter categoryIDParam = cmd.CreateParameter();
				categoryIDParam.ParameterName = ":CategoryID";
				categoryIDParam.Value = categoryID;
				cmd.Parameters.Add(categoryIDParam);

				IDbDataParameter customThingIDParam = cmd.CreateParameter();
				customThingIDParam.ParameterName = ":CustomThingID";
				customThingIDParam.Value = customThingID;
				cmd.Parameters.Add(customThingIDParam);

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
