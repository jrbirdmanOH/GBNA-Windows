using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CommonNameDM
	{
		private static CommonNameDM instance = new CommonNameDM();

		private CommonNameDM()
		{
		}

		public static CommonNameDM Instance
		{
			get
			{
				return instance;
			}
		}

		public CommonName GetByID(int id)
		{
			CommonName commonName = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CommonNames.CommonNameID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName FROM CommonNames WHERE CommonNames.CommonNameID=:id";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter commonNameIDParam = cmd.CreateParameter();
				commonNameIDParam.ParameterName = ":id";
				commonNameIDParam.Value = id;
				cmd.Parameters.Add(commonNameIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					commonName = new CommonName();

					commonName.ID = reader.GetInt32(0);
					commonName.Name = reader.GetString(1);
					commonName.First = reader.IsDBNull(2) ? string.Empty : reader.GetString(3);
					commonName.Last = reader.GetString(3);
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

			return commonName;
		}

		public CommonName GetByThingIDAndLanguage(int thingID, int languageID)
		{
			CommonName commonName = null;

			if (languageID == Language.English.ID)
			{
				commonName = GetEnglishByThingIDAndLanguage(thingID, languageID);
			}
			else
			{
				commonName = GetForeignByThingIDAndLanguage(thingID, languageID);
			}

			return commonName;
		}

		private CommonName GetEnglishByThingIDAndLanguage(int thingID, int languageID)
		{
			CommonName commonName = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CommonNames.CommonNameID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName FROM Classifications, CommonNames WHERE CommonNames.CommonNameID=Classifications.CommonNameID AND Classifications.ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					commonName = new CommonName();

					commonName.ID = reader.GetInt32(0);
					commonName.LanguageID = languageID;
					commonName.Name = reader.GetString(1);
					commonName.First = reader.IsDBNull(2) ? string.Empty : reader.GetString(3);
					commonName.Last = reader.GetString(3);
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

			return commonName;
		}

		private CommonName GetForeignByThingIDAndLanguage(int thingID, int languageID)
		{
			CommonName commonName = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CommonNames.CommonNameID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName FROM Classifications, CommonNames, AliasLanguageRegion WHERE AliasLanguageRegion.ThingID=Classifications.ThingID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND Classifications.ThingID=:ThingID AND AliasLanguageRegion.LanguageRegionID=:LanguageRegionID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter languageIDParam = cmd.CreateParameter();
				languageIDParam.ParameterName = ":LanguageRegionID";
				languageIDParam.Value = languageID;
				cmd.Parameters.Add(languageIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					commonName = new CommonName();

					commonName.ID = reader.GetInt32(0);
					commonName.LanguageID = languageID;
					commonName.Name = reader.GetString(1);
					commonName.First = reader.IsDBNull(2) ? string.Empty : reader.GetString(3);
					commonName.Last = reader.GetString(3);
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

			return commonName;
		}
	}
}
