using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.Data
{
	internal class SightingsReportDM
	{
		private static SightingsReportDM instance = new SightingsReportDM();

		private SightingsReportDM()
		{
		}

		public static SightingsReportDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<SightingsReportItem> GetList(SightingsReportFilter filter)
		{
			List<SightingsReportItem> list = new List<SightingsReportItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder query = new StringBuilder();

				bool isForeignLanguage = false;
				if (filter != null && filter.LanguageID != Language.English.ID)
				{
					isForeignLanguage = true;
					query.Append("SELECT CommonNames.CommonName, Locations.Name, Sightings.DateAndTime, Sightings.Comments, Family.Description, Classifications.SortOrder FROM Classifications, CommonNames, Locations, Sightings, Family, AliasLanguageRegion WHERE Sightings.ThingID=Classifications.ThingID AND AliasLanguageRegion.ThingID=Sightings.ThingID AND AliasLanguageRegion.LanguageRegionID=:LanguageRegionID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND Sightings.LocationID=Locations.LocationID AND Family.FamilyID=Classifications.FamilyID");
				}
				else
				{
					query.Append("SELECT CommonNames.CommonName, Locations.Name, Sightings.DateAndTime, Sightings.Comments, Family.Description, Classifications.SortOrder FROM Classifications, CommonNames, Locations, Sightings, Family WHERE Sightings.ThingID=Classifications.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Sightings.LocationID=Locations.LocationID AND Family.FamilyID=Classifications.FamilyID");
				}

				if (filter != null)
				{
					query.Append(" AND Sightings.ObserverID=:ObserverID");

					if (filter.EnforceStartDate)
					{
						string startDate = ApplicationSettings.GetDBDateTimeQueryStringValue(filter.StartDate);
						if (startDate != null)
						{
							query.Append(" AND Sightings.DateAndTime >= ");
							query.Append(startDate);
						}
					}

					if (filter.EnforceEndDate)
					{
						string endDate = ApplicationSettings.GetDBDateTimeQueryStringValue(filter.EndDate);
						if (endDate != null)
						{
							query.Append(" AND Sightings.DateAndTime <= ");
							query.Append(endDate);
						}
					}
				}
				query.Append(" ORDER BY Classifications.SortOrder, Sightings.DateAndTime");

				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				if (isForeignLanguage)
				{
					IDbDataParameter languageIDParam = cmd.CreateParameter();
					languageIDParam.ParameterName = ":LanguageRegionID";
					languageIDParam.Value = filter.LanguageID;
					cmd.Parameters.Add(languageIDParam);
				}

				if (filter != null)
				{
					IDbDataParameter observerIDParam = cmd.CreateParameter();
					observerIDParam.ParameterName = ":ObserverID";
					observerIDParam.Value = filter.ObserverID;
					cmd.Parameters.Add(observerIDParam);
				}

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SightingsReportItem item = new SightingsReportItem();

					item.CommonName = reader.GetString(0);
					item.Location = reader.GetString(1);
					item.Date = reader.GetDateTime(2);
					item.Comments = reader.GetString(3);
					item.Family = reader.GetString(4);
					item.TaxonomicOrder = reader.GetDouble(5);

					list.Add(item);
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

		public List<LifeListReportItem> GetList(LifeListReportFilter filter)
		{
			List<LifeListReportItem> list = new List<LifeListReportItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder query = new StringBuilder("SELECT DISTINCT s1.ThingID, s1.DateAndTime, loc.Name FROM Sightings AS s1, Locations AS loc WHERE s1.DateAndTime = ");
				query.Append("(SELECT MIN(DateAndTime) FROM Sightings AS s2 WHERE s2.ThingID = s1.ThingID AND s2.ObserverID = :ObserverID) AND (s1.LifeListDisabler = ");
				query.Append(ApplicationSettings.GetDBBooleanValue(false));
				query.Append(" OR s1.LifeListDisabler IS NULL) AND s1.ObserverID = :ObserverID AND s1.LocationID = loc.LocationID ORDER BY s1.DateAndTime");

				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = filter.ObserverID;
				cmd.Parameters.Add(observerIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				int lifeListNumber = 0;
				while (reader.Read())
				{
					LifeListReportItem item = new LifeListReportItem();

					item.LifeListNumber = ++lifeListNumber;
					item.FirstSeenDate = reader.GetDateTime(1);
					item.Location = reader.GetString(2);

					CommonName commonName = CommonNameDM.Instance.GetByThingIDAndLanguage(reader.GetInt32(0), filter.LanguageID);
					item.CommonName = commonName.Name;

					list.Add(item);
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
