using System;
using System.Data;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates.Data
{
	public class ConnectionFactory
	{
		public static IDbConnection CreateConnection()
		{
			return CreateConnection(BirdingAppSettings.DatabaseName);
		}

		public static IDbConnection CreateConnection(string databaseName)
		{
			IDbConnection connection = (IDbConnection)BirdingAppSettings.ConstructorInfo.Invoke(null);
			connection.ConnectionString = BirdingAppSettings.ConnectionString.Replace("%1", databaseName);

			return connection;
		}
	}
}
