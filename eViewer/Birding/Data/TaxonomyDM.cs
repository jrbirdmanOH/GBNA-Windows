using System.Data;

namespace Thayer.Birding.Data
{
	/// <summary>
	/// Summary description for TaxonomyDM.
	/// </summary>
	internal class TaxonomyDM
	{
		private static TaxonomyDM instance = new TaxonomyDM();

		private TaxonomyDM()
		{
		}

		public static TaxonomyDM Instance
		{
			get
			{
				return instance;
			}
		}

		public TaxonomyCollection GetList()
		{
			TaxonomyCollection list = new TaxonomyCollection();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT TaxonomyID, Name, Description, Comments, Locked FROM TaxonomyList";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Taxonomy taxonomy = new Taxonomy();

					taxonomy.ID = reader.GetInt32(0);
					taxonomy.Name = reader.GetString(1);
					taxonomy.Description = reader.GetString(2);
					taxonomy.Comments = reader.GetString(3);
					taxonomy.Locked = reader.GetBoolean(4);

					list.Add(taxonomy);
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
