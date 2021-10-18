using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class ObserverDM
	{
		private static ObserverDM instance = new ObserverDM();

		private ObserverDM()
		{
		}

		public static ObserverDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Observer GetByID(int id)
		{
			Observer observer = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ObserverID, FirstName, MI, LastName, Initials FROM Observers WHERE ObserverID=:ObserverID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = id;
				cmd.Parameters.Add(observerIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					observer = new Observer();

					observer.ID = reader.GetInt32(0);
					observer.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					observer.MiddleInitial = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					observer.LastName = reader.GetString(3);
					observer.Initials = reader.GetString(4);
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

			return observer;
		}

		public Observer GetByName(string firstName, string middleInitial, string lastName)
		{
			Observer observer = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ObserverID, FirstName, MI, LastName, Initials FROM Observers WHERE FirstName=:FirstName AND MI=:MI AND LastName=:LastName";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter firstNameParam = cmd.CreateParameter();
				firstNameParam.ParameterName = ":FirstName";
				firstNameParam.Value = firstName;
				cmd.Parameters.Add(firstNameParam);

				IDbDataParameter middleInitialParam = cmd.CreateParameter();
				middleInitialParam.ParameterName = ":MI";
				middleInitialParam.Value = middleInitial;
				cmd.Parameters.Add(middleInitialParam);

				IDbDataParameter lastNameParam = cmd.CreateParameter();
				lastNameParam.ParameterName = ":LastName";
				lastNameParam.Value = lastName;
				cmd.Parameters.Add(lastNameParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					observer = new Observer();

					observer.ID = reader.GetInt32(0);
					observer.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					observer.MiddleInitial = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					observer.LastName = reader.GetString(3);
					observer.Initials = reader.GetString(4);
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

			return observer;
		}

		public List<Observer> GetList()
		{
			List<Observer> list = new List<Observer>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ObserverID, FirstName, MI, LastName, Initials FROM Observers ORDER BY LastName, FirstName, MI";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Observer observer = new Observer();

					observer.ID = reader.GetInt32(0);
					observer.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					observer.MiddleInitial = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					observer.LastName = reader.GetString(3);
					observer.Initials = reader.GetString(4);

					list.Add(observer);
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
				cmd.CommandText = "DELETE FROM Observers WHERE ObserverID=:ObserverID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":ObserverID";
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

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		public void Save(Observer observer, IDbTransaction trans)
		{
			if (observer.ID == 0)
			{
				Insert(observer, trans);
			}
			else
			{
				Update(observer, trans);
			}
		}

		protected void Insert(Observer observer, IDbTransaction trans)
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
				cmd.CommandText = "INSERT INTO Observers (FirstName, MI, LastName, Initials) VALUES (:FirstName, :MI, :LastName, :Initials)";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter firstNameParam = cmd.CreateParameter();
				firstNameParam.ParameterName = ":FirstName";
				firstNameParam.Value = observer.FirstName;
				cmd.Parameters.Add(firstNameParam);

				IDbDataParameter middleInitialParam = cmd.CreateParameter();
				middleInitialParam.ParameterName = ":MI";
				middleInitialParam.Value = observer.MiddleInitial;
				cmd.Parameters.Add(middleInitialParam);

				IDbDataParameter lastNameParam = cmd.CreateParameter();
				lastNameParam.ParameterName = ":LastName";
				lastNameParam.Value = observer.LastName;
				cmd.Parameters.Add(lastNameParam);

				IDbDataParameter initialsParam = cmd.CreateParameter();
				initialsParam.ParameterName = ":Initials";
				initialsParam.Value = observer.Initials;
				cmd.Parameters.Add(initialsParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				cmd.ExecuteNonQuery();

				observer.ID = ApplicationSettings.GetIdentityValue(conn, trans);
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

		protected void Update(Observer observer, IDbTransaction trans)
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
				cmd.CommandText = "UPDATE Observers SET FirstName=:FirstName, MI=:MI, LastName=:LastName, Initials=:Initials WHERE ObserverID=:ObserverID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter firstNameParam = cmd.CreateParameter();
				firstNameParam.ParameterName = ":FirstName";
				firstNameParam.Value = observer.FirstName;
				cmd.Parameters.Add(firstNameParam);

				IDbDataParameter middleInitialParam = cmd.CreateParameter();
				middleInitialParam.ParameterName = ":MI";
				middleInitialParam.Value = observer.MiddleInitial;
				cmd.Parameters.Add(middleInitialParam);

				IDbDataParameter lastNameParam = cmd.CreateParameter();
				lastNameParam.ParameterName = ":LastName";
				lastNameParam.Value = observer.LastName;
				cmd.Parameters.Add(lastNameParam);

				IDbDataParameter initialsParam = cmd.CreateParameter();
				initialsParam.ParameterName = ":Initials";
				initialsParam.Value = observer.Initials;
				cmd.Parameters.Add(initialsParam);

				IDbDataParameter observerIDParam = cmd.CreateParameter();
				observerIDParam.ParameterName = ":ObserverID";
				observerIDParam.Value = observer.ID;
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

		public bool NameExists(Observer observer)
		{
			bool bNameExists = false;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(ObserverID) FROM Observers WHERE FirstName=:FirstName AND MI=:MI AND LastName=:LastName";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter firstNameParam = cmd.CreateParameter();
				firstNameParam.ParameterName = ":FirstName";
				firstNameParam.Value = observer.FirstName;
				cmd.Parameters.Add(firstNameParam);

				IDbDataParameter middleInitialParam = cmd.CreateParameter();
				middleInitialParam.ParameterName = ":MI";
				middleInitialParam.Value = observer.MiddleInitial;
				cmd.Parameters.Add(middleInitialParam);

				IDbDataParameter lastNameParam = cmd.CreateParameter();
				lastNameParam.ParameterName = ":LastName";
				lastNameParam.Value = observer.LastName;
				cmd.Parameters.Add(lastNameParam);

				conn.Open();
				bNameExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

			return bNameExists;
		}
	}
}
