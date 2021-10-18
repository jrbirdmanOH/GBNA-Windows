using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Thayer.Birding.Configuration;
using Thayer.Birding.Data;
using Thayer.Birding.Licensing;

namespace Thayer.Birding
{
	/// <summary>
	/// Summary description for ApplicationSettings.
	/// </summary>
	public sealed class ApplicationSettings
	{
		private const string AppVersion = "7.0";
		private const string DBDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

		private static OperatingSystem operatingSystem;

		private static bool useAppDataPath;
		private static string appDataPath;

		private static string assemblyLocation;
		private static string assemblyPath;
		private static string configFileName;
		private static string mediaPath;
		private static string customMediaPath;
		private static string databaseName;
		private static string customDatabaseName;
		private static string connectionString;
		private static ConstructorInfo constructorInfo;
		private static bool sqlite;
		private static LicenseCollection licenses = null;
		private static EncryptedSettings encryptedSettings = null;
		private static ThayerEncryptedData thayerData = null;
		private static string temporaryDirectory = null;
		private static string updateLocation = null;
		private static string spectrogramLocation = null;

		private static bool restartQuiz = true;
		private static bool enableHallOfFame = true;
		private static string hallOfFameSoundEffectLocation = string.Empty;
		private static int numberOfHallOfFameTopScorers = 5;

		static ApplicationSettings()
		{
			assemblyLocation = Assembly.GetEntryAssembly().Location;
			assemblyPath = Path.GetDirectoryName(assemblyLocation);

			operatingSystem = GetOperatingSystem();

			if (ConfigurationManager.AppSettings["UseAppDataPath"] != null)
			{
				useAppDataPath = Convert.ToBoolean(ConfigurationManager.AppSettings["UseAppDataPath"]);
			}
			else
			{
				useAppDataPath = true;
			}

			if (useAppDataPath)
			{
				appDataPath = GetCommonAppPath();
			}
			else
			{
				appDataPath = assemblyPath;
			}
			
//			assemblyLocation = Assembly.GetEntryAssembly().Location;
//			configFileName = assemblyLocation + ".config";

			// TODO - Change location of config file
			StringBuilder configFile = new StringBuilder(Path.GetFileName(assemblyLocation));
			configFile.Append(".config");
			configFileName = Path.Combine(appDataPath, configFile.ToString());

//			assemblyPath = Path.GetDirectoryName(assemblyLocation);
//			mediaPath = Path.Combine(assemblyPath, "Media");

			// TODO - Change location of media directory
			mediaPath = Path.Combine(appDataPath, "Media");
			customMediaPath = Path.Combine(appDataPath, "CustomMedia");

			// TODO - Change location of temp directory
			temporaryDirectory = Path.Combine(appDataPath, "Temp");

//			temporaryDirectory = Path.Combine(assemblyPath, "Temp");
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

			Load();
		}

		private ApplicationSettings()
		{
		}

		private static OperatingSystem GetOperatingSystem()
		{
			OperatingSystem operatingSystem = OperatingSystem.Windows;

			// The first versions of the framework (1.0 and 1.1) didn't include any PlatformID
			// value for Unix, so Mono used the value 128. The newer framework 2.0 added Unix 
			// to the PlatformID enum but, sadly, with a different value: 4 and newer versions 
			// of .NET distinguished between Unix and MacOS X, introducing yet another value 6 
			// for MacOS X. 

			// This means that in order to detect properly code running on Unix platforms you must 
			// check the three values (4, 6 and 128). This ensure that the detection code will work 
			// as expected when executed on Mono CLR 1.x runtime and with both Mono and Microsoft 
			// CLR 2.x runtimes. 

			// The versions of Mono (1.2.x and 1.9.x) that were used to build the eViewer software 
			// return a platform ID of 4, which corresponds to the Unix enumeration.  This is not 
			// a big deal since we don't need to distinguish between Unix and Mac OS X.

			int platformID = (int)Environment.OSVersion.Platform;
			if (platformID == 4 || platformID == 6 || platformID == 128)
			{
				operatingSystem = OperatingSystem.MacOSX;
			}

			return operatingSystem;
		}

		private static string GetCommonAppPath()
		{
			StringBuilder applicationDataPath = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			applicationDataPath.Append(Path.DirectorySeparatorChar);
			applicationDataPath.Append("Thayer Birding Software");
			applicationDataPath.Append(Path.DirectorySeparatorChar);
//			applicationDataPath.Append("eField Guide Viewer");
//			applicationDataPath.Append(Path.DirectorySeparatorChar);
//			applicationDataPath.Append(AppVersion);
			applicationDataPath.Append("eViewer ");
			applicationDataPath.Append(AppVersion);
			
			return applicationDataPath.ToString();
		}

		public static void Load()
		{
			// Get the configuration object representing the configuration file
			System.Configuration.Configuration config = ApplicationSettings.Configuration;

			databaseName = config.AppSettings.Settings["DatabaseName"].Value;
			databaseName = Path.Combine(appDataPath, databaseName);

			customDatabaseName = config.AppSettings.Settings["CustomDatabaseName"].Value;
			customDatabaseName = Path.Combine(appDataPath, customDatabaseName);

			connectionString = config.AppSettings.Settings["ConnectionString"].Value;
			string provider = config.AppSettings.Settings["Provider"].Value;
			updateLocation = config.AppSettings.Settings["UpdateLocation"].Value;

			if (config.AppSettings.Settings["SpectrogramLocation"] != null)
			{
				spectrogramLocation = config.AppSettings.Settings["SpectrogramLocation"].Value;
			}

			Type type = Type.GetType(provider);
			constructorInfo = type.GetConstructor(Type.EmptyTypes);

			sqlite = type.ToString().StartsWith("Mono.Data.Sqlite");

			if (config.AppSettings.Settings["RestartQuiz"] != null)
			{
				restartQuiz = Convert.ToBoolean(config.AppSettings.Settings["RestartQuiz"].Value);
			}

			if (config.AppSettings.Settings["EnableHallOfFame"] != null)
			{
				enableHallOfFame = Convert.ToBoolean(config.AppSettings.Settings["EnableHallOfFame"].Value);
			}

			if (config.AppSettings.Settings["HallOfFameSoundEffectLocation"] != null)
			{
				hallOfFameSoundEffectLocation = config.AppSettings.Settings["HallOfFameSoundEffectLocation"].Value;
			}
			else
			{
				hallOfFameSoundEffectLocation = Path.Combine(assemblyPath, "clap.wav");
			}

			if (config.AppSettings.Settings["NumberOfHallOfFameTopScorers"] != null)
			{
				numberOfHallOfFameTopScorers = Convert.ToInt32(config.AppSettings.Settings["NumberOfHallOfFameTopScorers"].Value);
			}
		}

		public static OperatingSystem OperatingSystem
		{
			get
			{
				return operatingSystem;
			}
		}

		public static string AssemblyPath
		{
			get
			{
				return assemblyPath;
			}
		}

		public static string AppDataPath
		{
			get
			{
				return appDataPath;
			}
		}

		private static System.Configuration.Configuration Configuration
		{
			get
			{
				// TODO - Change location of config file
				// Get the configuration based on the specified config file name
				ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
				fileMap.ExeConfigFilename = ApplicationSettings.ConfigFileName;

				return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			}
		}

		public static string ConfigFileName
		{
			get
			{
				return configFileName;
			}
		}

		public static string DatabaseName
		{
			get
			{
				return databaseName;
			}
		}

		public static string CustomDatabaseName
		{
			get
			{
				return customDatabaseName;
			}
		}

		public static string DatabaseVersion
		{
			get
			{
				return GetDatabaseVersion(DatabaseName);
			}
		}

		public static string CustomDatabaseVersion
		{
			get
			{
				return GetDatabaseVersion(CustomDatabaseName);
			}
		}

		public static string GetDatabaseVersion(string databasePath)
		{
			return MdfDM.Instance.GetDatabaseVersion(databasePath);
		}

		public static LicenseCollection Licenses
		{
			get
			{
				if (licenses == null)
				{
					// Section handling in configuration files in Mono is not working as expected.
/*
					// TODO - Change location of config file
					// Get the configuration object representing the configuration file
					System.Configuration.Configuration config = ApplicationSettings.Configuration;
					ConfigurationSection section = config.GetSection("licenses");
					if (section != null)
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(section.SectionInformation.GetRawXml());
						LicenseConfigurationSectionHandler sectionHandler = new LicenseConfigurationSectionHandler();
						licenses = sectionHandler.ReadXml(doc.DocumentElement);
					}
*/

//					licenses = (LicenseCollection)ConfigurationManager.GetSection("licenses");

					XmlDocument doc = new XmlDocument();
					doc.Load(ApplicationSettings.ConfigFileName);
					XmlNode licensesNode = doc.SelectSingleNode("/configuration/licenses");

					if (licensesNode != null)
					{
						LicenseConfigurationSectionHandler sectionHandler = new LicenseConfigurationSectionHandler();
						licenses = sectionHandler.ReadXml(licensesNode);
					}
					if (licenses == null)
					{
						licenses = new LicenseCollection();
					}
				}

				return licenses;
			}
		}

		public static string MediaPath
		{
			get
			{
				return mediaPath;
			}
		}

		public static string CustomMediaPath
		{
			get
			{
				return customMediaPath;
			}
		}

		public static string UpdateLocation
		{
			get
			{
				return updateLocation;
			}
		}

		public static string SpectrogramLocation
		{
			get
			{
				return spectrogramLocation;
			}

			set
			{
				if (spectrogramLocation != value)
				{
					spectrogramLocation = value;

					SaveSpectrogramLocation();
				}
			}
		}

		public static bool FirstTimeRun
		{
			get
			{
				return ThayerData.FirstTimeRun;
			}

			set
			{
				if (ThayerData.FirstTimeRun != value)
				{
					ThayerData.FirstTimeRun = value;

					StringBuilder xml = new StringBuilder();
					StringWriter xmlWriter = new StringWriter(xml);
					XmlSerializer serializer = new XmlSerializer(typeof(ThayerEncryptedData));
					serializer.Serialize(xmlWriter, thayerData);

					encryptedSettings.Data = xml.ToString();
					encryptedSettings.Save("thayerData");
				}
			}
		}

		public static bool RestartQuiz
		{
			get
			{
				return restartQuiz;
			}

			set
			{
				restartQuiz = value;
				SetAppSettingsValue("RestartQuiz", Convert.ToString(restartQuiz));
			}
		}

		public static bool EnableHallOfFame
		{
			get
			{
				return enableHallOfFame;
			}

			set
			{
				enableHallOfFame = value;
				SetAppSettingsValue("EnableHallOfFame", Convert.ToString(enableHallOfFame));
			}
		}

		public static string HallOfFameSoundEffectLocation
		{
			get
			{
				if (hallOfFameSoundEffectLocation.Length == 0)
				{
					hallOfFameSoundEffectLocation = Path.Combine(AssemblyPath, "clap.wav");
				}

				return hallOfFameSoundEffectLocation;
			}

			set
			{
				hallOfFameSoundEffectLocation = value;
				SetAppSettingsValue("HallOfFameSoundEffectLocation", hallOfFameSoundEffectLocation);
			}
		}

		public static int NumberOfHallOfFameTopScorers
		{
			get
			{
				return numberOfHallOfFameTopScorers;
			}

			set
			{
				numberOfHallOfFameTopScorers = value;
				SetAppSettingsValue("NumberOfHallOfFameTopScorers", Convert.ToString(numberOfHallOfFameTopScorers));
			}
		}

		private static ThayerEncryptedData ThayerData
		{
			get
			{
				if (encryptedSettings == null)
				{
					// TODO - Change location of config file
					// Get the configuration object representing the configuration file
					System.Configuration.Configuration config = ApplicationSettings.Configuration;
					ConfigurationSection section = config.GetSection("thayerData");
					if (section != null)
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(section.SectionInformation.GetRawXml());
						EncryptedSettingsSectionHandler sectionHandler = new EncryptedSettingsSectionHandler();
						encryptedSettings = sectionHandler.ReadXml(doc.DocumentElement);
					}

//					encryptedSettings = (EncryptedSettings)ConfigurationManager.GetSection("thayerData");

					if (encryptedSettings == null)
					{
						encryptedSettings = new EncryptedSettings();
						thayerData = new ThayerEncryptedData();
					}
					else
					{
						using (StringReader xmlReader = new StringReader(encryptedSettings.Data))
						{
							XmlSerializer serializer = new XmlSerializer(typeof(ThayerEncryptedData));
							thayerData = (ThayerEncryptedData)serializer.Deserialize(xmlReader);
						}
					}
				}

				return thayerData;
			}
		}

		public static IDbConnection CreateConnection()
		{
			return CreateConnection(databaseName);
		}

		public static IDbConnection CreateConnection(DataSourceType type)
		{
			string databaseName = string.Empty;

			switch (type)
			{
				case DataSourceType.Standard:
					databaseName = ApplicationSettings.DatabaseName;
					break;
				case DataSourceType.Custom:
					databaseName = ApplicationSettings.CustomDatabaseName;
					break;
			}

			return CreateConnection(databaseName);
		}

		public static IDbConnection CreateConnection(string databaseName)
		{
			IDbConnection connection = (IDbConnection)constructorInfo.Invoke(null);
			connection.ConnectionString = connectionString.Replace("%1", databaseName);
#if DEBUG
			connection = new DebugConnection(connection);
#endif

			return connection;
		}

		public static string GetDBBooleanValue(bool value)
		{
			if (sqlite)
			{
				StringBuilder buffer = new StringBuilder("'");
				buffer.Append(value.ToString());
				buffer.Append("'");

				return buffer.ToString();
			}
			else
			{
				return value.ToString();
			}
		}

		public static object GetDBDateTimeValue(DateTime? value)
		{
			object dateTimeValue = null;

			if (value == null)
			{
				dateTimeValue = Convert.DBNull;
			}
			else
			{
				dateTimeValue = ApplicationSettings.FormatDateTime((DateTime)value);
			}

			return dateTimeValue;
		}

		public static string GetDBDateTimeQueryStringValue(DateTime? value)
		{
			string dateTimeString = string.Empty;

			if (value == null)
			{
				dateTimeString = null;
			}
			else
			{
				if (sqlite)
				{
					dateTimeString = String.Format("'{0}'", ApplicationSettings.FormatDateTime((DateTime)value));
				}
				else
				{
					dateTimeString = String.Format("#{0}#", ApplicationSettings.FormatDateTime((DateTime)value));
				}
			}

			return dateTimeString;
		}

		private static string FormatDateTime(DateTime value)
		{
			return value.ToString(ApplicationSettings.DBDateTimeFormat);
		}

		public static int GetIdentityValue(IDbConnection conn)
		{
			return GetIdentityValue(conn, null);
		}

		public static int GetIdentityValue(IDbTransaction trans)
		{
			return GetIdentityValue(trans.Connection, trans);
		}

		public static int GetIdentityValue(IDbConnection conn, IDbTransaction trans)
		{
			int retVal = 0;

			if (sqlite)
			{
/*
				// This does not seem to work anymore!!!
				Type type = conn.GetType();
				PropertyInfo property = type.GetProperty("LastInsertRowId");
				retVal = Convert.ToInt32(property.GetValue(conn, null));
*/
				IDbCommand cmd = null;

				try
				{
					cmd = conn.CreateCommand();

					cmd.CommandText = "select last_insert_rowid()";
					cmd.CommandType = CommandType.Text;
					cmd.Transaction = trans;

					retVal = Convert.ToInt32(cmd.ExecuteScalar());
				}
				finally
				{
					if (cmd != null)
					{
						cmd.Dispose();
					}
				}
			}
			else
			{
				IDbCommand cmd = null;

				try
				{
					cmd = conn.CreateCommand();

					cmd.CommandText = "SELECT @@IDENTITY";
					cmd.CommandType = CommandType.Text;
					cmd.Transaction = trans;

					retVal = Convert.ToInt32(cmd.ExecuteScalar());
				}
				finally
				{
					if (cmd != null)
					{
						cmd.Dispose();
					}
				}
			}

			return retVal;
		}

		public static string TemporaryDirectory
		{
			get
			{
				return temporaryDirectory;
			}
		}

		private static void SaveSpectrogramLocation()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(ApplicationSettings.ConfigFileName);

			XmlNode spectrogramLocationNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='SpectrogramLocation']");
			XmlAttribute valueAttribute;
			if (spectrogramLocationNode == null)
			{
				XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
				spectrogramLocationNode = doc.CreateElement("add");
				XmlAttribute keyAttribute = doc.CreateAttribute("key");
				keyAttribute.Value = "SpectrogramLocation";
				spectrogramLocationNode.Attributes.Append(keyAttribute);
				valueAttribute = doc.CreateAttribute("value");
				spectrogramLocationNode.Attributes.Append(valueAttribute);
				appSettingsNode.AppendChild(spectrogramLocationNode);
			}
			else
			{
				valueAttribute = spectrogramLocationNode.Attributes["value"];
				if (valueAttribute == null)
				{
					valueAttribute = doc.CreateAttribute("value");
					spectrogramLocationNode.Attributes.Append(valueAttribute);
				}
			}

			valueAttribute.Value = spectrogramLocation != null ? spectrogramLocation : string.Empty;

			doc.Save(ApplicationSettings.ConfigFileName);
		}

		private class DebugConnection : IDbConnection
		{
			private IDbConnection conn;

			public DebugConnection(IDbConnection conn)
			{
				this.conn = conn;
			}

			public IDbTransaction BeginTransaction(IsolationLevel il)
			{
				return conn.BeginTransaction(il);
			}

			public IDbTransaction BeginTransaction()
			{
				return conn.BeginTransaction();
			}

			public void ChangeDatabase(string databaseName)
			{
				conn.ChangeDatabase(databaseName);
			}

			public void Close()
			{
				conn.Close();
			}

			public string ConnectionString
			{
				get
				{
					return conn.ConnectionString;
				}
				set
				{
					conn.ConnectionString = value;
				}
			}

			public int ConnectionTimeout
			{
				get
				{
					return conn.ConnectionTimeout;
				}
			}

			public IDbCommand CreateCommand()
			{
				return new DebugCommand(conn.CreateCommand());
			}

			public string Database
			{
				get
				{
					return conn.Database;
				}
			}

			public void Open()
			{
				conn.Open();
			}

			public ConnectionState State
			{
				get
				{
					return conn.State;
				}
			}

			public void Dispose()
			{
				conn.Dispose();
			}

			public int LastInsertRowId
			{
				get
				{
					Type type = conn.GetType();
					PropertyInfo property = type.GetProperty("LastInsertRowId");

					return Convert.ToInt32(property.GetValue(conn, null));
				}
			}
		}

		private class DebugCommand : IDbCommand
		{
			private IDbCommand cmd;

			public DebugCommand(IDbCommand cmd)
			{
				this.cmd = cmd;
			}

			public void Cancel()
			{
				cmd.Cancel();
			}

			public string CommandText
			{
				get
				{
					return cmd.CommandText;
				}
				set
				{
					cmd.CommandText = value;
				}
			}

			public int CommandTimeout
			{
				get
				{
					return cmd.CommandTimeout;
				}
				set
				{
					cmd.CommandTimeout = value;
				}
			}

			public CommandType CommandType
			{
				get
				{
					return cmd.CommandType;
				}
				set
				{
					cmd.CommandType = value;
				}
			}

			public IDbConnection Connection
			{
				get
				{
					return cmd.Connection;
				}
				set
				{
					cmd.Connection = value;
				}
			}

			public IDbDataParameter CreateParameter()
			{
				return cmd.CreateParameter();
			}

			public int ExecuteNonQuery()
			{
				return cmd.ExecuteNonQuery();
			}

			public IDataReader ExecuteReader(CommandBehavior behavior)
			{
				return cmd.ExecuteReader(behavior);
			}

			public IDataReader ExecuteReader()
			{
				IDataReader reader = null;

				using (StreamWriter writer = new StreamWriter(Path.Combine(ApplicationSettings.AppDataPath, "sql.txt"), true))
				{
					writer.AutoFlush = true;
					writer.WriteLine(cmd.CommandText);
					DateTime start = DateTime.Now;
					reader = cmd.ExecuteReader();
					DateTime end = DateTime.Now;

					writer.Write("Query time: ");
					writer.WriteLine(end - start);
					writer.WriteLine();
				}

				return reader;
			}

			public object ExecuteScalar()
			{
				return cmd.ExecuteScalar();
			}

			public IDataParameterCollection Parameters
			{
				get
				{
					return cmd.Parameters;
				}
			}

			public void Prepare()
			{
				cmd.Prepare();
			}

			public IDbTransaction Transaction
			{
				get
				{
					return cmd.Transaction;
				}
				set
				{
					cmd.Transaction = value;
				}
			}

			public UpdateRowSource UpdatedRowSource
			{
				get
				{
					return cmd.UpdatedRowSource;
				}
				set
				{
					cmd.UpdatedRowSource = value;
				}
			}

			public void Dispose()
			{
				cmd.Dispose();
			}
		}

		private static void SetAppSettingsValue(string key, string value)
		{
			// TODO - Change location of config file
			// Get the configuration object representing the configuration file
//			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
			System.Configuration.Configuration config = ApplicationSettings.Configuration;

			// Remove any existing AppSettings key value pair
			config.AppSettings.Settings.Remove(key);

			// Create a new AppSettings key value pair
			config.AppSettings.Settings.Add(key, value);

			// Save the changes
			config.Save();
		}
	}
}
