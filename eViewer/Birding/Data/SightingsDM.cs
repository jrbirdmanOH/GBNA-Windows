using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class SightingsDM
	{
		private static SightingsDM instance = new SightingsDM();

		private SightingsDM()
		{
		}

		public static SightingsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<Sighting> GetList()
		{
			return GetList(0);
		}

		public List<Sighting> GetList(int organismID)
		{
			List<Sighting> list = new List<Sighting>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				StringBuilder sql = new StringBuilder("SELECT Sightings.SightingID, Sightings.ObserverID, Observers.FirstName, Observers.MI, Observers.LastName, Sightings.ThingID, CommonNames.CommonName, Sightings.LocationID, Locations.Name, Sightings.DateAndTime, Sightings.Comments, Classifications.SortOrder FROM Classifications,CommonNames,Locations,Observers,Sightings WHERE ");
				if (organismID > 0)
				{
					sql.Append("Sightings.ThingID=:ThingID AND ");
					IDbDataParameter thingIDParam = cmd.CreateParameter();
					thingIDParam.ParameterName = ":ThingID";
					thingIDParam.Value = organismID;
					cmd.Parameters.Add(thingIDParam);
				}
				sql.Append("Sightings.ThingID=Classifications.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Locations.LocationID=Sightings.LocationID AND Observers.ObserverID=Sightings.ObserverID");
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Sighting sighting = new Sighting();

					sighting.ID = reader.GetInt32(0);

					Observer observer = new Observer();
					observer.ID = reader.GetInt32(1);
					observer.FirstName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					observer.MiddleInitial = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
					observer.LastName = reader.GetString(4);

					sighting.Observer.ID = observer.ID;
					sighting.Observer.Text = observer.FullName;
					sighting.Organism.ID = reader.GetInt32(5);
					sighting.Organism.Text = reader.GetString(6);
					sighting.Location.ID = reader.GetInt32(7);
					sighting.Location.Text = reader.GetString(8);
					sighting.Date = reader.GetDateTime(9);
					sighting.Comments = reader.GetString(10);
					sighting.TaxonomicOrder = reader.GetDouble(11);

					list.Add(sighting);
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

		public void Delete(int sightingID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM Sightings WHERE SightingID=:SightingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter sightingIDParam = cmd.CreateParameter();
				sightingIDParam.ParameterName = ":SightingID";
				sightingIDParam.Value = sightingID;
				cmd.Parameters.Add(sightingIDParam);

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

		public void Save(Sighting sighting, IDbTransaction trans)
		{
			if (sighting.ID == 0)
			{
				Insert(sighting, trans);
			}
			else
			{
				Update(sighting, trans);
			}
		}

		protected void Insert(Sighting sighting, IDbTransaction trans)
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
				cmd.CommandText = "INSERT INTO Sightings (ObserverID, ThingID, LocationID, DateAndTime, Comments) VALUES (:ObserverID, :ThingID, :LocationID, :DateAndTime, :Comments)";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = sighting.Observer.ID;
				cmd.Parameters.Add(observerIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = sighting.Organism.ID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter locationIDParam = cmd.CreateParameter();
				locationIDParam.ParameterName = ":LocationID";
				locationIDParam.Value = sighting.Location.ID;
				cmd.Parameters.Add(locationIDParam);

				IDbDataParameter dateAndTimeParam = cmd.CreateParameter();
				dateAndTimeParam.ParameterName = ":DateAndTime";
				dateAndTimeParam.Value = ApplicationSettings.GetDBDateTimeValue(sighting.Date);
				cmd.Parameters.Add(dateAndTimeParam);

				IDbDataParameter commentsParam = cmd.CreateParameter();
				commentsParam.ParameterName = ":Comments";
				commentsParam.Value = sighting.Comments;
				cmd.Parameters.Add(commentsParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				cmd.ExecuteNonQuery();

				sighting.ID = ApplicationSettings.GetIdentityValue(conn, trans);
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

		protected void Update(Sighting sighting, IDbTransaction trans)
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
				cmd.CommandText = "UPDATE Sightings SET ObserverID=:ObserverID, ThingID=:ThingID, LocationID=:LocationID, DateAndTime=:DateAndTime, Comments=:Comments WHERE SightingID=:SightingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = sighting.Observer.ID;
				cmd.Parameters.Add(observerIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = sighting.Organism.ID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter locationIDParam = cmd.CreateParameter();
				locationIDParam.ParameterName = ":LocationID";
				locationIDParam.Value = sighting.Location.ID;
				cmd.Parameters.Add(locationIDParam);

				IDbDataParameter dateAndTimeParam = cmd.CreateParameter();
				dateAndTimeParam.ParameterName = ":DateAndTime";
				dateAndTimeParam.Value = ApplicationSettings.GetDBDateTimeValue(sighting.Date);
				cmd.Parameters.Add(dateAndTimeParam);

				IDbDataParameter commentsParam = cmd.CreateParameter();
				commentsParam.ParameterName = ":Comments";
				commentsParam.Value = sighting.Comments;
				cmd.Parameters.Add(commentsParam);

				IDbDataParameter sightingIDParam = cmd.CreateParameter();
				sightingIDParam.ParameterName = ":SightingID";
				sightingIDParam.Value = sighting.ID;
				cmd.Parameters.Add(sightingIDParam);

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

		public void DeleteList(List<Sighting> sightings)
		{
			if (sightings.Count > 0)
			{
				IDbConnection conn = ApplicationSettings.CreateConnection();
				IDbCommand cmd = null;
				try
				{
					StringBuilder commandText = new StringBuilder();
					commandText.Append("DELETE FROM Sightings WHERE SightingID IN (");

					int index = 0;
					foreach (Sighting sighting in sightings)
					{
						commandText.Append(sighting.ID.ToString());

						if (index != sightings.Count - 1)
						{
							commandText.Append(", ");
						}

						index++;
					}

					commandText.Append(")");

					cmd = conn.CreateCommand();
					cmd.CommandText = commandText.ToString();
					cmd.CommandType = CommandType.Text;

					conn.Open();
					cmd.ExecuteNonQuery();
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
			}
		}

		public void DeleteByObserver(int observerID, IDbTransaction trans)
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
				cmd.CommandText = "DELETE FROM Sightings WHERE ObserverID=:ObserverID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = observerID;
				cmd.Parameters.Add(observerIDParam);

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

		public bool WasObservedByObserver(int organismID, int observerID)
		{
			bool observed = false;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(Sightings.SightingID) AS NumberOfSightings FROM Sightings WHERE Sightings.ThingID = :ThingID AND Sightings.ObserverID = :ObserverID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = organismID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = observerID;
				cmd.Parameters.Add(observerIDParam);

				conn.Open();
				int numberOfSightings = Convert.ToInt32(cmd.ExecuteScalar());

				observed = numberOfSightings > 0 ? true : false;
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

			return observed;
		}

		public bool Exists(Sighting sighting)
		{
			bool bExists = false;

			IDbConnection conn = null;
			IDbCommand cmd = null;

			try
			{
				conn = ApplicationSettings.CreateConnection();

				StringBuilder sql = new StringBuilder("SELECT COUNT(SightingID) FROM Sightings WHERE ObserverID=:ObserverID AND ThingID=:ThingID AND LocationID=:LocationID AND DateAndTime=:DateAndTime AND Comments=:Comments");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = sighting.Observer.ID;
				cmd.Parameters.Add(observerIDParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = sighting.Organism.ID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter locationIDParam = cmd.CreateParameter();
				locationIDParam.ParameterName = ":LocationID";
				locationIDParam.Value = sighting.Location.ID;
				cmd.Parameters.Add(locationIDParam);

				IDbDataParameter dateAndTimeParam = cmd.CreateParameter();
				dateAndTimeParam.ParameterName = ":DateAndTime";
				dateAndTimeParam.Value = ApplicationSettings.GetDBDateTimeValue(sighting.Date);
				cmd.Parameters.Add(dateAndTimeParam);

				IDbDataParameter commentsParam = cmd.CreateParameter();
				commentsParam.ParameterName = ":Comments";
				commentsParam.Value = sighting.Comments;
				cmd.Parameters.Add(commentsParam);

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
	}
}
