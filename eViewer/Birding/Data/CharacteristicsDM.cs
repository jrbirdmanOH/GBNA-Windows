using System.Data;

namespace Thayer.Birding.Data
{
	internal class CharacteristicsDM
	{
		private static CharacteristicsDM instance = new CharacteristicsDM();

		private CharacteristicsDM()
		{
		}

		public static CharacteristicsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public string GetColumn(string category, string description)
		{
			string retVal = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT [Column] FROM Characteristics WHERE Category=:Category AND Description=:Description";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter categoryParam = cmd.CreateParameter();
				categoryParam.ParameterName = ":Category";
				categoryParam.Value = category;
				cmd.Parameters.Add(categoryParam);

				IDbDataParameter descriptionParam = cmd.CreateParameter();
				descriptionParam.ParameterName = ":Description";
				descriptionParam.Value = description;
				cmd.Parameters.Add(descriptionParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					retVal = reader.GetString(0);
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

			return retVal;
		}
	}
}
