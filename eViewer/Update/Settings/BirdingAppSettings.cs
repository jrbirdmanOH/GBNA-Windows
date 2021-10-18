using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using Thayer.Birding.Updates.Data;

namespace Thayer.Birding.Updates.Settings
{
	public class BirdingAppSettings
	{
		private const string AppVersion = "7.0";
		public const string ApplicationFilesDirectoryName = "Application Files";
		public const string ApplicationDataFilesDirectoryName = "Application Data Files";
		public const string SystemFilesDirectoryName = "System Files";

		private static string applicationPath = null;
		private static string appDataPath = null;
		private static string connectionString = null;
		private static string customDatabaseName = null;
		private static string customDatabaseNameWithRelativePath = null;
		private static string customDatabaseVersion = null;
		private static string databaseName = null;
		private static string databaseNameWithRelativePath = null;
		private static string databaseVersion = null;
		private static string provider = null;
		private static string updateLocation = null;
		private static OperatingSystem targetOS = OperatingSystem.Windows;

		private static Configuration config = null;
		private static ConstructorInfo constructorInfo = null;

		public static void Init(string applicationPath)
		{
			BirdingAppSettings.applicationPath = applicationPath;

			appDataPath = null;
			connectionString = null;
			customDatabaseName = null;
			customDatabaseNameWithRelativePath = null;
			customDatabaseVersion = null;
			databaseName = null;
			databaseNameWithRelativePath = null;
			databaseVersion = null;
			provider = null;
			updateLocation = null;

			config = null;
			constructorInfo = null;

			InitConfig();
		}

		private static void InitConfig()
		{
			try
			{
				config = ConfigurationManager.OpenExeConfiguration(ApplicationPath);
			}
			catch (Exception ex)
			{
				// Config file could not be found in directory where application is located
//				Utility.WriteLogFileEntry("Exception opening config file - " + ex.Message);
			}

			bool useAppDataPath = true;
			if (config != null)
			{
				if (config.AppSettings.Settings["UseAppDataPath"] != null)
				{
					useAppDataPath = Convert.ToBoolean(config.AppSettings.Settings["UseAppDataPath"].Value);
				}
			}
//			else
//			{
//				Utility.WriteLogFileEntry("config is null");
//			}

			if (useAppDataPath)
			{
				StringBuilder applicationDataPath = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
				applicationDataPath.Append(Path.DirectorySeparatorChar);
				applicationDataPath.Append("Thayer Birding Software");
				applicationDataPath.Append(Path.DirectorySeparatorChar);
//				applicationDataPath.Append("eField Guide Viewer");
//				applicationDataPath.Append(Path.DirectorySeparatorChar);
//				applicationDataPath.Append(AppVersion);
				applicationDataPath.Append("eViewer ");
				applicationDataPath.Append(AppVersion);

				appDataPath = applicationDataPath.ToString();
			}
			else
			{
				appDataPath = Path.GetDirectoryName(ApplicationPath);
			}

//			Utility.WriteLogFileEntry("App data path is " + appDataPath);

			StringBuilder configFile = new StringBuilder(Path.GetFileName(ApplicationPath));
			configFile.Append(".config");
			string configFileName = Path.Combine(appDataPath, configFile.ToString());

			try
			{
				ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
				fileMap.ExeConfigFilename = configFileName;
				config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			}
			catch (Exception ex)
			{
//				Utility.WriteLogFileEntry("Exception opening config file - " + ex.Message);
			}

//			Utility.WriteLogFileEntry("Config file name is " + configFileName);
		}

		public static string ApplicationPath
		{
			get
			{
				return applicationPath;
			}

			set
			{
				if (applicationPath != value)
				{
					Init(value);
				}
			}
		}

		public static string AppDataPath
		{
			get
			{
				return appDataPath;
			}
		}

		public static string ConnectionString
		{
			get
			{
				if (connectionString == null)
				{
					connectionString = Config.AppSettings.Settings["ConnectionString"].Value;
				}

				return connectionString;
			}
		}

		public static string CustomDatabaseName
		{
			get
			{
				if (customDatabaseName == null)
				{
					customDatabaseName = Config.AppSettings.Settings["CustomDatabaseName"].Value;
					customDatabaseName = Path.Combine(appDataPath, customDatabaseName);
				}

				return customDatabaseName;
			}
		}

		public static string CustomDatabaseNameWithRelativePath
		{
			get
			{
				if (customDatabaseNameWithRelativePath == null)
				{
					customDatabaseNameWithRelativePath = Config.AppSettings.Settings["CustomDatabaseName"].Value;
				}

				return customDatabaseNameWithRelativePath;
			}
		}

		public static string CustomDatabaseVersion
		{
			get
			{
				if (customDatabaseVersion == null)
				{
					customDatabaseVersion = GetDatabaseVersion(CustomDatabaseName);
				}

				return databaseVersion;
			}
		}

		public static string DatabaseName
		{
			get
			{
				if (databaseName == null)
				{
					databaseName = Config.AppSettings.Settings["DatabaseName"].Value;
					databaseName = Path.Combine(appDataPath, databaseName);
				}

				return databaseName;
			}
		}

		public static string DatabaseNameWithRelativePath
		{
			get
			{
				if (databaseNameWithRelativePath == null)
				{
					databaseNameWithRelativePath = Config.AppSettings.Settings["DatabaseName"].Value;
				}

				return databaseNameWithRelativePath;
			}
		}

		public static string DatabaseVersion
		{
			get
			{
				if (databaseVersion == null)
				{
					databaseVersion = GetDatabaseVersion(DatabaseName);
				}

				return databaseVersion;
			}
		}

		protected static string Provider
		{
			get
			{
				if (provider == null)
				{
					provider = Config.AppSettings.Settings["Provider"].Value;
				}

				return provider;
			}
		}

		public static string UpdateLocation
		{
			get
			{
				if (updateLocation == null)
				{
					updateLocation = Config.AppSettings.Settings["UpdateLocation"].Value;
				}

				return updateLocation;
			}
		}

		public static string UpdateDirectory
		{
			get
			{
				return Path.Combine(BirdingAppSettings.AppDataPath, "Updates");
			}
		}

		public static OperatingSystem TargetOperatingSystem
		{
			get
			{
				KeyValueConfigurationElement element = Config.AppSettings.Settings["TargetOperatingSystem"];
				if (element != null)
				{
					targetOS = (OperatingSystem)Enum.Parse(typeof(OperatingSystem), element.Value);
				}

				return targetOS;
			}
		}

		public static bool IsRunningAs32Bit
		{
			get
			{
				return IntPtr.Size == 4;
			}
		}

		public static bool Is64BitWindows
		{
			get
			{
				bool is64BitWindows = false;
				if (TargetOperatingSystem == OperatingSystem.Windows)
				{
					is64BitWindows = Environment.GetEnvironmentVariable("ProgramFiles(x86)") != null;
				}

				return is64BitWindows;
			}
		}

		protected static Configuration Config
		{
			get
			{
				if (config == null)
				{
					InitConfig();
				}

				return config;
			}
		}

		public static ConstructorInfo ConstructorInfo
		{
			get
			{
				if (constructorInfo == null)
				{
					Type type = Type.GetType(Provider);
					constructorInfo = type.GetConstructor(Type.EmptyTypes);
				}

				return constructorInfo;
			}
		}

		public static string GetDatabaseVersion(string databasePath)
		{
			return MdfDM.Instance.GetDatabaseVersion(databasePath);
		}
	}
}
