using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class FamilyDM
	{
		private static FamilyDM instance = new FamilyDM();

		private FamilyDM()
		{
		}

		public static FamilyDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<Family> GetList()
		{
			List<Family> list = new List<Family>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Family.FamilyID, Family.Family, Family.Description, Family.Narrative FROM Classifications, Family WHERE Family.FamilyID=Classifications.FamilyID GROUP BY Family.FamilyID, Family.Family, Family.Description, Family.Narrative ORDER BY Min(Classifications.SortOrder)";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Family family = new Family();

					family.ID = reader.GetInt32(0);
					family.Name = reader.GetString(1);
					family.Description = reader.GetString(2);
					family.Narrative = reader.GetString(3);

					list.Add(family);
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
