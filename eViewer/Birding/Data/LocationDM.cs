using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class LocationDM
	{
		private static LocationDM instance = new LocationDM();

		private LocationDM()
		{
		}

		public static LocationDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Location GetByID(int id)
		{
			Location location = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT LocationID, Name FROM Locations WHERE LocationID=:LocationID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":LocationID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					location = new Location();

					location.ID = reader.GetInt32(0);
					location.Name = reader.GetString(1);
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

			return location;
		}

		public Location GetParent()
		{
			Location location = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT LocationID, Name FROM Locations WHERE TopLocation=" + ApplicationSettings.GetDBBooleanValue(true);
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					location = new Location();

					location.ID = reader.GetInt32(0);
					location.Name = reader.GetString(1);
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

			return location;
		}

		public List<Location> GetList(int collectionID)
		{
			List<Location> list = new List<Location>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Locations.LocationID, Locations.Name FROM CollectionLocations, Locations WHERE Locations.LocationID=CollectionLocations.LocationID AND CollectionLocations.CollectionID=:CollectionID AND Locations.LocationID NOT IN (SELECT DISTINCT ParentID FROM LocationParents)";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Location location = new Location();

					location.ID = reader.GetInt32(0);
					location.Name = reader.GetString(1);

					list.Add(location);
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

		public List<Location> GetChildren(int id, int collectionID)
		{
			List<Location> list = new List<Location>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Locations.LocationID,Locations.Name FROM Locations,LocationParents WHERE Locations.LocationID=LocationParents.LocationID AND LocationParents.ParentID=:LocationID AND Locations.LocationID IN (SELECT DISTINCT LocationID FROM CollectionLocations WHERE CollectionID=:CollectionID) ORDER BY Locations.Name";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter locationIDParam = cmd.CreateParameter();
				locationIDParam.ParameterName = ":LocationID";
				locationIDParam.Value = id;
				cmd.Parameters.Add(locationIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Location location = new Location();

					location.ID = reader.GetInt32(0);
					location.Name = reader.GetString(1);

					list.Add(location);
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
