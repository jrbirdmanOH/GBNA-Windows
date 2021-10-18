using System.Data;

namespace Thayer.Birding.Data
{
	internal class ThingsDescriptionsDM
	{
		private static ThingsDescriptionsDM instance = new ThingsDescriptionsDM();

		private ThingsDescriptionsDM()
		{
		}

		public static ThingsDescriptionsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public CharacteristicDictionary GetListByThingID(int thingID)
		{
			CharacteristicDictionary list = new CharacteristicDictionary();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT [Section], Description FROM ThingsDescriptions WHERE ThingID=:id";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":id";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string characteristic = reader.GetString(0);
					string[] values = reader.GetString(1).Split('\t');

					foreach (string value in values)
					{
						list.Add(characteristic, value);
					}
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

		public CharacteristicCollection GetCharacteristicByThingID(int thingID, string characteristicType)
		{
			CharacteristicCollection list = new CharacteristicCollection();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Description FROM ThingsDescriptions WHERE ThingID=:id AND [Section]=:Section";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":id";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter sectionParam = cmd.CreateParameter();
				sectionParam.ParameterName = ":Section";
				sectionParam.Value = characteristicType;
				cmd.Parameters.Add(sectionParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string[] values = reader.GetString(0).Split('\t');

					foreach (string value in values)
					{
						list.Add(value);
					}
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
