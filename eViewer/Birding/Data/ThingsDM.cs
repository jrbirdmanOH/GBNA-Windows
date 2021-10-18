using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.Data
{
	internal class ThingsDM
	{
		private static ThingsDM instance = new ThingsDM();

		protected ThingsDM()
		{
		}

		public static ThingsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Organism GetByIDAndLanguage(int thingID, int languageID)
		{
			Organism organism = null;

			if (languageID == Language.English.ID)
			{
				organism = GetByID(thingID, languageID);
			}
			else
			{
				organism = GetByIDAndForeignLanguage(thingID, languageID);
			}

			return organism;
		}

		private Organism GetByID(int thingID, int languageID)
		{
			Organism organism = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Classifications.ThingID, CommonNames.CommonNameID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, CommonNames.Pronunciation, Genus.GenusID, Genus.Genus, Genus.Pronunciation, Species.SpeciesID, Species.Species, Species.Pronunciation, [Order].OrderID, [Order].[Order], [Order].Description, [Order].Narrative, Family.FamilyID, Family.Family, Family.Description, Family.Narrative FROM Classifications, CommonNames, Genus, [Order], Species, Family WHERE CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND [Order].OrderID=Classifications.OrderID AND Species.SpeciesID=Classifications.SpeciesID AND Family.FamilyID=Classifications.FamilyID AND Classifications.ThingID=:id";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":id";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					organism = new Organism();
					CommonName commonName = new CommonName();

					organism.ID = reader.GetInt32(0);
					commonName.ID = reader.GetInt32(1);
					commonName.LanguageID = languageID;
					commonName.Name = reader.GetString(2);
					commonName.First = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
					commonName.Last = reader.GetString(4);
					commonName.AlternatePronunciation = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
					organism.SetCommonName(commonName);
					organism.Genus.ID = reader.GetInt32(6);
					organism.Genus.Name = reader.GetString(7);
					organism.Genus.Pronunciation = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
					organism.Species.ID = reader.GetInt32(9);
					organism.Species.Name = reader.GetString(10);
					organism.Species.Pronunciation = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
					organism.Order.ID = reader.GetInt32(12);
					organism.Order.Name = reader.GetString(13);
					organism.Order.Description = reader.GetString(14);
					organism.Order.Narrative = reader.GetString(15);
					organism.Family.ID = reader.GetInt32(16);
					organism.Family.Name = reader.GetString(17);
					organism.Family.Description = reader.GetString(18);
					organism.Family.Narrative = reader.GetString(19);
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

			return organism;
		}

		private Organism GetByIDAndForeignLanguage(int thingID, int languageID)
		{
			Organism organism = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Classifications.ThingID, CommonNames.CommonNameID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.GenusID, Genus.Genus, Genus.Pronunciation, Species.SpeciesID, Species.Species, Species.Pronunciation, [Order].OrderID, [Order].[Order], [Order].Description, [Order].Narrative, Family.FamilyID, Family.Family, Family.Description, Family.Narrative FROM Classifications, CommonNames, Genus, [Order], Species, Family, AliasLanguageRegion WHERE Genus.GenusID=Classifications.GenusID AND [Order].OrderID=Classifications.OrderID AND Species.SpeciesID=Classifications.SpeciesID AND Family.FamilyID=Classifications.FamilyID AND AliasLanguageRegion.ThingID=Classifications.ThingID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND Classifications.ThingID=:ThingID AND AliasLanguageRegion.LanguageRegionID=:LanguageRegionID";
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
					organism = new Organism();
					CommonName commonName = new CommonName();

					organism.ID = reader.GetInt32(0);
					commonName.ID = reader.GetInt32(1);
					commonName.LanguageID = languageID;
					commonName.Name = reader.GetString(2);
					commonName.First = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
					commonName.Last = reader.GetString(4);
					organism.SetCommonName(commonName);
					organism.Genus.ID = reader.GetInt32(5);
					organism.Genus.Name = reader.GetString(6);
					organism.Genus.Pronunciation = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
					organism.Species.ID = reader.GetInt32(8);
					organism.Species.Name = reader.GetString(9);
					organism.Species.Pronunciation = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
					organism.Order.ID = reader.GetInt32(11);
					organism.Order.Name = reader.GetString(12);
					organism.Order.Description = reader.GetString(13);
					organism.Order.Narrative = reader.GetString(14);
					organism.Family.ID = reader.GetInt32(15);
					organism.Family.Name = reader.GetString(16);
					organism.Family.Description = reader.GetString(17);
					organism.Family.Narrative = reader.GetString(18);
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

			return organism;
		}

		public bool Exists(int thingID)
		{
			bool bExists = false;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(ThingID) FROM Classifications WHERE Classifications.ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				bExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

			return bExists;
		}

		public OrganismListItem GetOrganismListItemByID(int organismID)
		{
			OrganismListItem organism = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CommonNames, Genus, Species WHERE Classifications.ThingID=:ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID ORDER BY SortOrder";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = organismID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					organism = new OrganismListItem();

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6);
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

			return organism;
		}

		public OrganismListItem GetOrganismListItemByMediaID(int mediaID)
		{
			OrganismListItem organism = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CommonNames, Genus, Species WHERE Classifications.ThingID = (SELECT MediaThings.ThingID FROM MediaThings WHERE MediaThings.MediaID=:MediaID) AND CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaID;
				cmd.Parameters.Add(mediaIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					organism = new OrganismListItem();

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6);
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

			return organism;
		}

		public List<OrganismListItem> GetList(int collectionID, int languageID, FilterCollection filters, bool includeAliases)
		{
			List<OrganismListItem> list = null;

			if (languageID == Language.English.ID)
			{
				list = GetEnglishList(collectionID, filters);
				if (includeAliases)
				{
					list.AddRange(GetAliasList(collectionID, filters));
				}
			}
			else
			{
				list = GetForeignList(collectionID, languageID, filters);
			}

			return list;
		}

		private List<OrganismListItem> GetForeignList(int collectionID, int languageID, FilterCollection filters)
		{
			List<OrganismListItem> list = new List<OrganismListItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				//				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CollectionThings, AliasLanguageRegion, CommonNames, Genus, Species WHERE Classifications.ThingID=CollectionThings.ThingID AND CollectionThings.CollectionID=:CollectionID AND AliasLanguageRegion.LanguageRegionID=:LanguageRegionID AND AliasLanguageRegion.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID");
				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder, BandCodeList.Name, BandCodes.BandCode FROM Classifications, CollectionThings, AliasLanguageRegion, CommonNames, Genus, Species, BandCodeList, BandCodes WHERE Classifications.ThingID=CollectionThings.ThingID AND CollectionThings.CollectionID=:CollectionID AND AliasLanguageRegion.LanguageRegionID=:LanguageRegionID AND AliasLanguageRegion.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=AliasLanguageRegion.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID AND BandCodes.ThingID=CollectionThings.ThingID AND BandCodeList.BandCodeListID=BandCodes.BandCodeListID");
				if (filters != null && filters.Count > 0)
				{
					query.Append(" AND Classifications.ThingID IN (");
					query.Append(filters.Query);
					query.Append(")");
				}
				query.Append(" ORDER BY SortOrder");
				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter languageIDParam = cmd.CreateParameter();
				languageIDParam.ParameterName = ":LanguageRegionID";
				languageIDParam.Value = languageID;
				cmd.Parameters.Add(languageIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					OrganismListItem organism = new OrganismListItem();

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6);

					BandCode bandCode = new BandCode();
					bandCode.Name = reader.GetString(7);
					bandCode.Code = reader.GetString(8);
					organism.BandCode = bandCode;

					list.Add(organism);
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

		private List<OrganismListItem> GetEnglishList(int collectionID, FilterCollection filters)
		{
			List<OrganismListItem> list = new List<OrganismListItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				//				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CollectionThings, CommonNames, Genus, Species WHERE CollectionThings.CollectionID=:CollectionID AND Classifications.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID");
				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder, BandCodeList.Name, BandCodes.BandCode FROM Classifications, CollectionThings, CommonNames, Genus, Species, BandCodeList, BandCodes WHERE CollectionThings.CollectionID=:CollectionID AND Classifications.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID AND BandCodes.ThingID=CollectionThings.ThingID AND BandCodeList.BandCodeListID=BandCodes.BandCodeListID");
				if (filters != null && filters.Count > 0)
				{
					query.Append(" AND Classifications.ThingID IN (");
					query.Append(filters.Query);
					query.Append(")");
				}
				query.Append(" ORDER BY SortOrder");
				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					OrganismListItem organism = new OrganismListItem();

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6);

					BandCode bandCode = new BandCode();
					bandCode.Name = reader.GetString(7);
					bandCode.Code = reader.GetString(8);
					organism.BandCode = bandCode;

					list.Add(organism);
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

		private List<OrganismListItem> GetAliasList(int collectionID, FilterCollection filters)
		{
			List<OrganismListItem> list = new List<OrganismListItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				//				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CollectionThings, AliasCommonNames, CommonNames, Genus, Species WHERE CollectionThings.CollectionID=:CollectionID AND Classifications.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=AliasCommonNames.CommonNameID AND AliasCommonNames.ThingID=Classifications.ThingID AND AliasCommonNames.CommonNameID <> Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID");
				StringBuilder query = new StringBuilder("SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder, BandCodeList.Name, BandCodes.BandCode FROM Classifications, CollectionThings, AliasCommonNames, CommonNames, Genus, Species, BandCodeList, BandCodes WHERE CollectionThings.CollectionID=:CollectionID AND Classifications.ThingID=CollectionThings.ThingID AND CommonNames.CommonNameID=AliasCommonNames.CommonNameID AND AliasCommonNames.ThingID=Classifications.ThingID AND AliasCommonNames.CommonNameID <> Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID AND BandCodes.ThingID=CollectionThings.ThingID AND BandCodeList.BandCodeListID=BandCodes.BandCodeListID");
				if (filters != null && filters.Count > 0)
				{
					query.Append(" AND Classifications.ThingID IN (");
					query.Append(filters.Query);
					query.Append(")");
				}
				query.Append(" ORDER BY SortOrder, CommonName");
				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();

				int previousThingID = 0;
				int groupIndex = 1;
				while (reader.Read())
				{
					OrganismListItem organism = new OrganismListItem();

					int thingID = reader.GetInt32(0);
					if (thingID != previousThingID)
					{
						groupIndex = 1;
					}
					else
					{
						groupIndex++;
					}
					previousThingID = thingID;

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6) + (groupIndex * 0.1);
					organism.IsAlias = true;

					BandCode bandCode = new BandCode();
					bandCode.Name = reader.GetString(7);
					bandCode.Code = reader.GetString(8);
					organism.BandCode = bandCode;

					list.Add(organism);
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

		public List<OrganismListItem> Search(int collectionID, int taxonomyID, Location[] locations, bool commonOnly, Size[] sizes, Habitat[] habitats, bool predominantColor, Color[] colors, FieldMark[] fieldMarks, Sound[] sounds, Kingdom[] kingdoms, Phylum[] phyla, Class[] classes, Order[] orders, Family[] families, Genus[] genus)
		{
			List<OrganismListItem> list = new List<OrganismListItem>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();

				string selectClause = "SELECT Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder";

				StringBuilder fromClause = new StringBuilder("FROM Classifications, CollectionThings, CommonNames, Genus, Species");
				StringBuilder whereClause = new StringBuilder("WHERE ");
				whereClause.Append("CollectionThings.CollectionID=");
				whereClause.Append(collectionID);
				whereClause.Append(" AND Classifications.ThingID=CollectionThings.ThingID AND ");
				whereClause.Append("CommonNames.CommonNameID=Classifications.CommonNameID AND ");
				whereClause.Append("Classifications.TaxonomyID=");
				whereClause.Append(taxonomyID);
				whereClause.Append(" AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID");

				StringBuilder thingCharsClause = new StringBuilder();

				AppendLocations(whereClause, locations, commonOnly);
				AppendSizes(thingCharsClause, sizes);
				AppendHabitats(thingCharsClause, habitats);
				AppendColors(thingCharsClause, predominantColor, colors);
				AppendFieldMarks(thingCharsClause, fieldMarks);
				AppendSounds(thingCharsClause, sounds);

				StringBuilder taxonomyClause = new StringBuilder();
				AppendKingdom(taxonomyClause, kingdoms);
				AppendPhyla(taxonomyClause, phyla);
				AppendClass(taxonomyClause, classes);
				AppendOrder(taxonomyClause, orders);
				AppendFamilies(taxonomyClause, families);
				AppendGenus(taxonomyClause, genus);

				if (thingCharsClause.Length > 0)
				{
					fromClause.Append(",ThingCharacteristics");
					whereClause.Append(" AND ThingCharacteristics.ThingID=CollectionThings.ThingID");
					whereClause.Append(" AND ");
					whereClause.Append(thingCharsClause);
				}

				StringBuilder sql = new StringBuilder(selectClause);
				sql.Append(" ");
				sql.Append(fromClause);
				sql.Append(" ");
				sql.Append(whereClause);
				if (taxonomyClause.Length > 0)
				{
					sql.Append(" AND (");
					sql.Append(taxonomyClause);
					sql.Append(")");
				}
				sql.Append(" ORDER BY [SortOrder]");

				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					OrganismListItem organism = new OrganismListItem();

					organism.ID = reader.GetInt32(0);
					organism.CommonName = reader.GetString(1);
					organism.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					organism.LastName = reader.GetString(3);
					organism.Genus = reader.GetString(4);
					organism.Species = reader.GetString(5);
					organism.TaxonomicOrder = reader.GetDouble(6);

					list.Add(organism);
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

		internal void AppendLocations(StringBuilder whereClause, Location[] locations, bool commonOnly)
		{
			if(locations != null && locations.Length > 0)
			{
				whereClause.Append(" AND CollectionThings.ThingID IN (SELECT DISTINCT CheckList.ThingID FROM CheckList,LocationDescendants WHERE LocationDescendants.LocationID IN (");
				for (int i = 0; i < locations.Length; i++)
				{
					if (i > 0)
					{
						whereClause.Append(",");
					}
					whereClause.Append(locations[i].ID);
				}
				whereClause.Append(") AND LocationDescendants.DescendantID=CheckList.LocationID");
				if (commonOnly)
				{
					whereClause.Append(" AND Common=");
					whereClause.Append(ApplicationSettings.GetDBBooleanValue(true));
				}
				whereClause.Append(")");
			}
		}

		internal void AppendSizes(StringBuilder whereClause, Size[] sizes)
		{
			if (sizes != null && sizes.Length > 0)
			{
				whereClause.Append("(");

				SortedList<double, Size> sortedSizes = new SortedList<double, Size>(sizes.Length);
				foreach (Size size in sizes)
				{
					sortedSizes.Add(size.SmallestSize, size);
				}

				IList<Size> sizeList = sortedSizes.Values;
				bool firstOne = true;
				double smallestSize = sizeList[0].SmallestSize;
				double largestSize = sizeList[0].LargestSize;
				for (int i = 1; i < sizeList.Count; i++)
				{
					Size size = sizeList[i];
					if (size.SmallestSize < largestSize)
					{
						largestSize = size.LargestSize;
					}
					else
					{
						if (firstOne)
						{
							firstOne = false;
						}
						else
						{
							whereClause.Append(" OR ");
						}
						AppendSize(whereClause, smallestSize, largestSize);

						smallestSize = size.SmallestSize;
						largestSize = size.LargestSize;
					}
				}

				if (!firstOne)
				{
					whereClause.Append(" OR ");
				}

				AppendSize(whereClause, smallestSize, largestSize);

				whereClause.Append(")");
			}
		}

		internal void AppendSize(StringBuilder whereClause, double smallestSize, double largestSize)
		{
			whereClause.Append("(");
			whereClause.Append(Characteristic.Size.Low);
			whereClause.Append(">=");
			whereClause.Append(smallestSize);
			whereClause.Append(" AND ");
			whereClause.Append(Characteristic.Size.High);
			whereClause.Append("<=");
			whereClause.Append(largestSize);
			whereClause.Append(")");
		}

		internal void AppendHabitats(StringBuilder whereClause, Habitat[] habitats)
		{
			if (habitats != null && habitats.Length > 0)
			{
				if (whereClause.Length > 0)
				{
					whereClause.Append(" AND ");
				}
				whereClause.Append("(");
				for (int i = 0; i < habitats.Length; i++)
				{
					if (i > 0)
					{
						whereClause.Append(" OR ");
					}
					whereClause.Append(habitats[i].DBColumn);
					whereClause.Append("=");
					whereClause.Append(ApplicationSettings.GetDBBooleanValue(true));
				}
				whereClause.Append(")");
			}
		}

		internal void AppendColors(StringBuilder whereClause, bool predominantColor, Color[] colors)
		{
			if (colors != null && colors.Length > 0)
			{
				if (whereClause.Length > 0)
				{
					whereClause.Append(" AND ");
				}

				if (predominantColor)
				{
					whereClause.Append(Characteristic.Color.MajorColor);
					whereClause.Append("='");
					whereClause.Append(colors[0].DBColumn);
					whereClause.Append("'");
				}
				else
				{
					whereClause.Append("(");
					for (int i = 0; i < colors.Length; i++)
					{
						if (i > 0)
						{
							whereClause.Append(" AND ");
						}
						whereClause.Append(colors[i].DBColumn);
						whereClause.Append("=");
						whereClause.Append(ApplicationSettings.GetDBBooleanValue(true));
					}
					whereClause.Append(")");
				}
			}
		}

		internal void AppendFieldMarks(StringBuilder whereClause, FieldMark[] fieldMarks)
		{
			if (fieldMarks != null && fieldMarks.Length > 0)
			{
				if (whereClause.Length > 0)
				{
					whereClause.Append(" AND ");
				}
				whereClause.Append("(");
				for (int i = 0; i < fieldMarks.Length; i++)
				{
					if (i > 0)
					{
						whereClause.Append(" AND ");
					}
					whereClause.Append(fieldMarks[i].DBColumn);
					whereClause.Append("=");
					whereClause.Append(ApplicationSettings.GetDBBooleanValue(true));
				}
				whereClause.Append(")");
			}
		}

		internal void AppendSounds(StringBuilder whereClause, Sound[] sounds)
		{
			if (sounds != null && sounds.Length > 0)
			{
				if (whereClause.Length > 0)
				{
					whereClause.Append(" AND ");
				}
				whereClause.Append("(");
				for (int i = 0; i < sounds.Length; i++)
				{
					if (i > 0)
					{
						whereClause.Append(" AND ");
					}
					whereClause.Append(sounds[i].DBColumn);
					whereClause.Append("=");
					whereClause.Append(ApplicationSettings.GetDBBooleanValue(true));
				}
				whereClause.Append(")");
			}
		}

		internal void AppendKingdom(StringBuilder whereClause, Kingdom[] kingdoms)
		{
			if (kingdoms != null && kingdoms.Length > 0)
			{
				int[] ids = new int[kingdoms.Length];
				for (int i = 0; i < kingdoms.Length; i++)
				{
					ids[i] = kingdoms[i].ID;
				}
				AppendTaxonomy(whereClause, "KingdomID", ids);
			}
		}

		internal void AppendPhyla(StringBuilder whereClause, Phylum[] phyla)
		{
			if (phyla != null && phyla.Length > 0)
			{
				int[] ids = new int[phyla.Length];
				for (int i = 0; i < phyla.Length; i++)
				{
					ids[i] = phyla[i].ID;
				}
				AppendTaxonomy(whereClause, "PhylaID", ids);
			}
		}

		internal void AppendClass(StringBuilder whereClause, Class[] classes)
		{
			if (classes != null && classes.Length > 0)
			{
				int[] ids = new int[classes.Length];
				for (int i = 0; i < classes.Length; i++)
				{
					ids[i] = classes[i].ID;
				}
				AppendTaxonomy(whereClause, "ClassID", ids);
			}
		}

		internal void AppendOrder(StringBuilder whereClause, Order[] orders)
		{
			if (orders != null && orders.Length > 0)
			{
				int[] ids = new int[orders.Length];
				for (int i = 0; i < orders.Length; i++)
				{
					ids[i] = orders[i].ID;
				}
				AppendTaxonomy(whereClause, "OrderID", ids);
			}
		}

		internal void AppendFamilies(StringBuilder whereClause, Family[] families)
		{
			if (families != null && families.Length > 0)
			{
				int[] ids = new int[families.Length];
				for (int i = 0; i < families.Length; i++)
				{
					ids[i] = families[i].ID;
				}
				AppendTaxonomy(whereClause, "FamilyID", ids);
			}
		}

		internal void AppendGenus(StringBuilder whereClause, Genus[] genus)
		{
			if (genus != null && genus.Length > 0)
			{
				int[] ids = new int[genus.Length];
				for (int i = 0; i < genus.Length; i++)
				{
					ids[i] = genus[i].ID;
				}
				AppendTaxonomy(whereClause, "GenusID", ids);
			}
		}

		internal void AppendTaxonomy(StringBuilder whereClause, string columnName, int[] ids)
		{
			if (whereClause.Length > 0)
			{
				whereClause.Append(" OR ");
			}
			for (int i = 0; i < ids.Length; i++)
			{
				if (i > 0)
				{
					whereClause.Append(" OR ");
				}
				whereClause.Append("Classifications.");
				whereClause.Append(columnName);
				whereClause.Append("=");
				whereClause.Append(ids[i]);
			}
		}

		public List<int> GetRelatedThings(int collectionID, int familyID, int taxonomyID)
		{
			List<int> list = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Classifications.ThingID FROM Classifications,CollectionThings WHERE Classifications.ThingID=CollectionThings.ThingID AND CollectionThings.CollectionID=:CollectionID AND Classifications.FamilyID=:FamilyID AND Classifications.TaxonomyID=:TaxonomyID AND Classifications.[FamilyPlate?]=" + ApplicationSettings.GetDBBooleanValue(true);
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter familyIDParam = cmd.CreateParameter();
				familyIDParam.ParameterName = ":FamilyID";
				familyIDParam.Value = familyID;
				cmd.Parameters.Add(familyIDParam);

				IDbDataParameter taxonomyIDParam = cmd.CreateParameter();
				taxonomyIDParam.ParameterName = ":TaxonomyID";
				taxonomyIDParam.Value = taxonomyID;
				cmd.Parameters.Add(taxonomyIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int id = reader.GetInt32(0);

					list.Add(id);
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

		public int GetNumberOfThingsWithMediaByQuiz(int quizID, int collectionID)
		{
			int count = 0;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();

				StringBuilder sqlText = new StringBuilder();
				sqlText.Append("SELECT COUNT(*) AS NumberOfRecords FROM (SELECT DISTINCT MediaThings.ThingID FROM MediaThings, Quizzes WHERE ");
				sqlText.Append("(Quizzes.QuizID = :QuizID) AND ");
				sqlText.Append("(Quizzes.ThingID = MediaThings.ThingID) AND ");
				sqlText.Append("(Quizzes.ThingID IN (SELECT CollectionThings.ThingID FROM CollectionThings WHERE CollectionThings.CollectionID = :CollectionID)))");

				cmd.CommandText = sqlText.ToString();
				cmd.CommandType = CommandType.Text;

				// Collection ID parameter MUST be added first since Access
				// binds parameters by position, not name.  The subselect
				// will get processed first.  Just run query in Access and
				// see which parameter you are prompted for first.  This
				// will be the order the parameters need to be added to the
				// parameter collection.
				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = quizID;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				count = Convert.ToInt32(cmd.ExecuteScalar());
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

			return count;
		}

        public int GetNumberOfThingsWithMediaByLocation(Location[] locations, bool commonOnly)
        {
            int count = 0;

            IDbConnection conn = ApplicationSettings.CreateConnection();
            IDbCommand cmd = null;
            try
            {
                cmd = conn.CreateCommand();

				StringBuilder sqlText = new StringBuilder();
				sqlText.Append("SELECT COUNT(*) AS NumberOfRecords FROM (SELECT DISTINCT MediaThings.ThingID FROM MediaThings, CheckList WHERE (CheckList.ThingID = MediaThings.ThingID)");

				if (locations.Length > 0)
				{
					StringBuilder locationClause = new StringBuilder(" AND CheckList.LocationID IN (");

					int locationIndex = 0;
					foreach (Location location in locations)
					{
						if (locationIndex > 0)
						{
							locationClause.Append(", ");
						}
						locationClause.Append(location.ID.ToString());
						locationIndex++;
					}

					locationClause.Append(")");
					sqlText.Append(locationClause);
				}

				if(commonOnly)
				{
					sqlText.Append(" AND (Checklist.Common = ");
					sqlText.Append(ApplicationSettings.GetDBBooleanValue(true));
					sqlText.Append(")");
				}

				sqlText.Append(")");

				cmd.CommandText = sqlText.ToString();
                cmd.CommandType = CommandType.Text;

                conn.Open();

				count = Convert.ToInt32(cmd.ExecuteScalar());
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

            return count;
        }

		public int GetNumberOfThingsWithMediaByTaxonomy(int taxonomyID, Kingdom[] kingdoms, Phylum[] phyla, Class[] classes, Order[] orders, Family[] families, Genus[] genera)
		{
			int count = 0;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();

				StringBuilder sqlText = new StringBuilder();
				sqlText.Append("SELECT COUNT(*) AS NumberOfRecords FROM (SELECT DISTINCT MediaThings.ThingID FROM MediaThings, Classifications WHERE (Classifications.ThingID = MediaThings.ThingID) AND TaxonomyID = :TaxonomyID");

				StringBuilder taxonomyClause = new StringBuilder();
				AppendKingdom(taxonomyClause, kingdoms);
				AppendPhyla(taxonomyClause, phyla);
				AppendClass(taxonomyClause, classes);
				AppendOrder(taxonomyClause, orders);
				AppendFamilies(taxonomyClause, families);
				AppendGenus(taxonomyClause, genera);

				if(taxonomyClause.Length > 0)
				{
					sqlText.Append(" AND (");
					sqlText.Append(taxonomyClause);
					sqlText.Append(")");
				}

				sqlText.Append(")");

				cmd.CommandText = sqlText.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter taxonomyIDParam = cmd.CreateParameter();
				taxonomyIDParam.ParameterName = ":TaxonomyID";
				taxonomyIDParam.Value = taxonomyID;
				cmd.Parameters.Add(taxonomyIDParam);

				conn.Open();
				count = Convert.ToInt32(cmd.ExecuteScalar());
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

			return count;
		}

		public List<int> GetListWithMedia(int collectionID)
		{
			List<int> list = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT DISTINCT Classifications.ThingID, Classifications.SortOrder FROM Classifications, MediaThings, CollectionThings WHERE CollectionThings.CollectionID=:CollectionID AND Classifications.ThingID=CollectionThings.ThingID AND Classifications.ThingID = MediaThings.ThingID ORDER BY Classifications.SortOrder";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					list.Add(reader.GetInt32(0));
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
