using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class LanguageRegionListDM
	{
		private static LanguageRegionListDM instance = new LanguageRegionListDM();

		private LanguageRegionListDM()
		{
		}

		public static LanguageRegionListDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<LanguageString> GetByThingID(int thingID)
		{
			List<LanguageString> list = GetForeignLanguagesByThingID(thingID);
			list.Insert(0, GetEnglishLanguageByThingID(thingID));

			return list;
		}

		private List<LanguageString> GetForeignLanguagesByThingID(int thingID)
		{
			List<LanguageString> list = new List<LanguageString>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder sql = new StringBuilder("SELECT LanguageRegionList.Name, CommonNames.CommonName FROM AliasLanguageRegion,CommonNames,LanguageRegionList WHERE LanguageRegionList.LanguageRegionID=AliasLanguageRegion.LanguageRegionID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND AliasLanguageRegion.ThingID=:ThingID AND LanguageRegionList.EviewerForeignLanguage=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(true));
				sql.Append(" ORDER BY LanguageRegionList.Name");

				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					LanguageString value = new LanguageString();

					value.Language = reader.GetString(0);
					value.Text = reader.GetString(1);

					list.Add(value);
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

		private LanguageString GetEnglishLanguageByThingID(int thingID)
		{
			LanguageString languageString = new LanguageString();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CommonNames.CommonName FROM CommonNames, Classifications WHERE CommonNames.CommonNameID=Classifications.CommonNameID AND Classifications.ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					languageString.Language = Language.English.Name;
					languageString.Text = reader.GetString(0);
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

			return languageString;
		}

		public List<Language> GetLanguageList()
		{
			List<Language> list = GetForeignLanguageList();
			list.Insert(0, Language.English);

			return list;
		}

		private List<Language> GetForeignLanguageList()
		{
			List<Language> list = new List<Language>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				StringBuilder sql = new StringBuilder("SELECT LanguageRegionList.LanguageRegionID, LanguageRegionList.Name FROM LanguageRegionList WHERE LanguageRegionList.EviewerForeignLanguage=");
				sql.Append(ApplicationSettings.GetDBBooleanValue(true));
				sql.Append(" ORDER BY LanguageRegionList.Name");

				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Language language = new Language();

					language.ID = reader.GetInt32(0);
					language.Name = reader.GetString(1);

					list.Add(language);
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

		public Language GetLanguageByID(int id)
		{
			Language language = null;

			if (id == Language.English.ID)
			{
				language = Language.English;
			}
			else
			{
				language = GetForeignLanguageByID(id);
			}

			return language;
		}

		private Language GetForeignLanguageByID(int id)
		{
			Language language = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				StringBuilder sql = new StringBuilder("SELECT LanguageRegionList.LanguageRegionID, LanguageRegionList.Name FROM LanguageRegionList WHERE LanguageRegionList.LanguageRegionID=:LanguageID");

				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter languageIDParam = cmd.CreateParameter();
				languageIDParam.ParameterName = ":LanguageID";
				languageIDParam.Value = id;
				cmd.Parameters.Add(languageIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					language = new Language();
					language.ID = reader.GetInt32(0);
					language.Name = reader.GetString(1);
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

			return language;
		}
	}
}
