using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomListsThingsDM
	{
		private static CustomListsThingsDM instance = new CustomListsThingsDM();

		private CustomListsThingsDM()
		{
		}

		public static CustomListsThingsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public CustomListItemCollection GetList(int customListID)
		{
			CustomListItemCollection list = new CustomListItemCollection();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomListsThings.CustomListEntryID, Classifications.ThingID, CommonNames.CommonName, CommonNames.FirstName, CommonNames.LastName, Genus.Genus, Species.Species, Classifications.SortOrder FROM Classifications, CommonNames, CustomListsThings, Genus, Species WHERE Classifications.ThingID=CustomListsThings.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Genus.GenusID=Classifications.GenusID AND Species.SpeciesID=Classifications.SpeciesID AND CustomListsThings.CustomListID=:CustomListID ORDER BY [Order]";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter listIDParam = cmd.CreateParameter();
				listIDParam.ParameterName = ":CustomListID";
				listIDParam.Value = customListID;
				cmd.Parameters.Add(listIDParam);

				int order = 0;
				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomListItem value = new CustomListItem();

					value.ID = reader.GetInt32(0);
					value.Organism.ID = reader.GetInt32(1);
					value.Organism.CommonName = reader.GetString(2);
					value.Organism.FirstName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
					value.Organism.LastName = reader.GetString(4);
					value.Organism.Genus = reader.GetString(5);
					value.Organism.Species = reader.GetString(6);
					value.Organism.TaxonomicOrder = reader.GetDouble(7);
					value.Order = order++;
					value.CustomListID = customListID;

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

		public void Delete(int id)
		{
			Delete(id, null);
		}

		public void Delete(int id, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "DELETE FROM CustomListsThings WHERE CustomListEntryID=:CustomListEntryID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomListEntryID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public void DeleteByCustomListID(int customListID, IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM CustomListsThings WHERE CustomListID=:CustomListID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomListID";
				idParam.Value = customListID;
				cmd.Parameters.Add(idParam);

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public void Save(CustomListItem item, IDbTransaction trans)
		{
			if (item.ID == 0)
			{
				Insert(item, trans);
			}
			else
			{
				Update(item, trans);
			}
		}

		protected void Insert(CustomListItem item, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "INSERT INTO CustomListsThings (CustomListID, ThingID, [Order]) VALUES (:CustomListID, :ThingID, :Order)";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter customListIDParam = cmd.CreateParameter();
				customListIDParam.ParameterName = ":CustomListID";
				customListIDParam.Value = item.CustomListID;
				cmd.Parameters.Add(customListIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = item.Organism.ID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter orderParam = cmd.CreateParameter();
				orderParam.ParameterName = ":Order";
				orderParam.Value = item.Order;
				cmd.Parameters.Add(orderParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				item.ID = ApplicationSettings.GetIdentityValue(conn, trans);
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		protected void Update(CustomListItem item, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE CustomListsThings SET CustomListID=:CustomListID, ThingID=:ThingID, [Order]=:Order WHERE CustomListEntryID=:CustomListEntryID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter customListIDParam = cmd.CreateParameter();
				customListIDParam.ParameterName = ":CustomListID";
				customListIDParam.Value = item.CustomListID;
				cmd.Parameters.Add(customListIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = item.Organism.ID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter orderParam = cmd.CreateParameter();
				orderParam.ParameterName = ":Order";
				orderParam.Value = item.Order;
				cmd.Parameters.Add(orderParam);

				IDbDataParameter entryIDParam = cmd.CreateParameter();
				entryIDParam.ParameterName = ":CustomListEntryID";
				entryIDParam.Value = item.ID;
				cmd.Parameters.Add(entryIDParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}
	}
}
