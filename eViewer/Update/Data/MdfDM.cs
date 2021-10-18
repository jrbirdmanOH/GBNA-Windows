using System.Data;

namespace Thayer.Birding.Updates.Data
{
	internal class MdfDM
	{
		private static MdfDM instance = new MdfDM();

		private MdfDM()
		{
		}

		public static MdfDM Instance
		{
			get
			{
				return instance;
			}
		}

		public string GetDatabaseVersion(string databasePath)
		{
			string version = null;

			IDbConnection conn = ConnectionFactory.CreateConnection(databasePath);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Version FROM MDF";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					version = reader.GetString(0);
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

			return version;
		}
	}
}
