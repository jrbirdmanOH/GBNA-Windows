using System.Data;

namespace Thayer.Birding.Data
{
	internal class GenusDM
	{
		private static GenusDM instance = new GenusDM();

		private GenusDM()
		{
		}

		public static GenusDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Genus GetByID(int id)
		{
			Genus genus = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT GenusID, Genus, Pronunciation FROM Genus WHERE GenusID=:GenusID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":GenusID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					genus = new Genus();

					genus.ID = reader.GetInt32(0);
					genus.Name = reader.GetString(1);
					genus.Pronunciation = reader.GetString(2);
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

			return genus;
		}
	}
}
