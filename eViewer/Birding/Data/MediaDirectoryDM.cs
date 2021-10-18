using System;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class MediaDirectoryDM
	{
		private static MediaDirectoryDM instance = new MediaDirectoryDM();

		private MediaDirectoryDM()
		{
		}

		public static MediaDirectoryDM Instance
		{
			get
			{
				return instance;
			}
		}

		public MediaDirectory GetByID(int id)
		{
			MediaDirectory mediaDirectory = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT MediaDirectoryID, PrimaryPath FROM MediaDirectory WHERE MediaDirectoryID=:id";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":id";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					mediaDirectory = new MediaDirectory();

					mediaDirectory.ID = reader.GetInt32(0);
					mediaDirectory.PrimaryPath = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
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

			return mediaDirectory;
		}

		public void Save(MediaDirectory mediaDirectory)
		{
			if (mediaDirectory.ID == 0)
			{
				Insert(mediaDirectory);
			}
			else
			{
				Update(mediaDirectory);
			}
		}

		protected void Insert(MediaDirectory mediaDirectory)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "INSERT INTO MediaDirectory (PrimaryPath) VALUES (:PrimaryPath)";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter primaryPathParam = cmd.CreateParameter();
				primaryPathParam.ParameterName = ":PrimaryPath";
				primaryPathParam.Value = mediaDirectory.PrimaryPath;
				cmd.Parameters.Add(primaryPathParam);

				conn.Open();
				cmd.ExecuteNonQuery();

				mediaDirectory.ID = ApplicationSettings.GetIdentityValue(conn);
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

		protected void Update(MediaDirectory mediaDirectory)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE MediaDirectory SET PrimaryPath=:PrimaryPath WHERE MediaDirectoryID=:MediaDirectoryID";
				cmd.CommandType = CommandType.Text;

				string primaryPath = mediaDirectory.PrimaryPath;
				IDbDataParameter primaryPathParam = cmd.CreateParameter();
				primaryPathParam.ParameterName = ":PrimaryPath";
				primaryPathParam.Value = primaryPath != null && primaryPath.Length > 0 ? primaryPath : Convert.DBNull;
				cmd.Parameters.Add(primaryPathParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":MediaDirectoryID";
				idParam.Value = mediaDirectory.ID;
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
	}
}
