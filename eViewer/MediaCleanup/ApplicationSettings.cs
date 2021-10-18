using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;

namespace Thayer.MediaCleanup
{
	/// <summary>
	/// Summary description for ApplicationSettings.
	/// </summary>
	public sealed class ApplicationSettings
	{
		private static string assemblyLocation;
		private static string assemblyPath;
		private static string connectionString;
		private static string databaseName;
		private static string mediaPath;
		private static string temporaryDirectory = null;

		private static readonly string ConnectionStringKey = "ConnectionString";
		private static readonly string DatabaseNameKey = "DatabaseName";
		private static readonly string MediaPathKey = "MediaPath";

		static ApplicationSettings()
		{
			assemblyLocation = Assembly.GetEntryAssembly().Location;
			assemblyPath = Path.GetDirectoryName(assemblyLocation);
/*
			temporaryDirectory = Path.Combine(assemblyPath, "Temp");
			if (!Directory.Exists(temporaryDirectory))
			{
				Directory.CreateDirectory(temporaryDirectory);
			}
			else
			{
				string[] files = Directory.GetFiles(temporaryDirectory);
				foreach (string file in files)
				{
					File.Delete(file);
				}
			}
*/
			Load();
		}

		private ApplicationSettings()
		{
		}

		public static void Load()
		{
			connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString;
			databaseName = ConfigurationManager.AppSettings[DatabaseNameKey];
			mediaPath = ConfigurationManager.AppSettings[MediaPathKey];
		}

		public static string AssemblyLocation
		{
			get
			{
				return assemblyLocation;
			}
		}

		public static string AssemblyPath
		{
			get
			{
				return assemblyPath;
			}
		}

		public static string DatabaseName
		{
			get
			{
				return databaseName;
			}

			set
			{
				databaseName = value;
				SetAppSettingsValue(DatabaseNameKey, value);
			}
		}

		public static string MediaPath
		{
			get
			{
				return mediaPath;
			}

			set
			{
				mediaPath = value;
				SetAppSettingsValue(MediaPathKey, value);
			}
		}

		public static string TemporaryDirectory
		{
			get
			{
				return temporaryDirectory;
			}
		}

		public static IDbConnection CreateConnection()
		{
			return CreateConnection(databaseName);
		}

		public static IDbConnection CreateConnection(string databaseName)
		{
			IDbConnection connection = new System.Data.OleDb.OleDbConnection();
			connection.ConnectionString = connectionString.Replace("%1", databaseName);

			return connection;
		}

		private static void SetAppSettingsValue(string key, string value)
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);

			// Remove any existing AppSettings key value pair
			config.AppSettings.Settings.Remove(key);

			// Create a new AppSettings key value pair
			config.AppSettings.Settings.Add(key, value);

			// Save the changes
			config.Save(ConfigurationSaveMode.Modified);
		}

		public static void DeleteTemporaryDirectory()
		{
			if (Directory.Exists(TemporaryDirectory))
			{
				Directory.Delete(TemporaryDirectory, true);
			}
		}
	}
}
