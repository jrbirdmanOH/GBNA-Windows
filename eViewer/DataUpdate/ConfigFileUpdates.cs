using System;
using System.IO;
using System.Xml;

namespace Thayer.Birding.DataUpdates
{
	internal class ConfigFileUpdates
	{
		private IBirdingApplication birdingApp;

		public ConfigFileUpdates(IBirdingApplication birdingApp)
		{
			this.birdingApp = birdingApp;
		}

		public void Update()
		{
			bool changed = false;
			XmlDocument doc = new XmlDocument();
			doc.Load(ApplicationSettings.ConfigFileName);

			changed |= UpdateDatabaseName(doc);
			changed |= UpdateCustomDatabaseName(doc);
			changed |= UpdateUpdateLocation(doc);
			changed |= UpdateSpectrogramLocation(doc);

			if (changed)
			{
				doc.Save(ApplicationSettings.ConfigFileName);
				ApplicationSettings.Load();
			}
		}

		private bool UpdateDatabaseName(XmlDocument doc)
		{
			bool changed = false;

			XmlNode databaseNameNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='DatabaseName']");
			if (databaseNameNode == null)
			{
				XmlNode connectionStringNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='ConnectionString']");
				string connectionStringValue = connectionStringNode.Attributes["value"].Value;

				string dataSourceString = "Data Source=";
				int startIndex = connectionStringValue.IndexOf(dataSourceString) + dataSourceString.Length;
				int endIndex = connectionStringValue.IndexOf(';', startIndex);
				string databaseName = connectionStringValue.Substring(startIndex, endIndex - startIndex);

				XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
				databaseNameNode = doc.CreateElement("add");
				XmlAttribute keyAttribute = doc.CreateAttribute("key");
				keyAttribute.Value = "DatabaseName";
				databaseNameNode.Attributes.Append(keyAttribute);
				XmlAttribute valueAttribute = doc.CreateAttribute("value");
				valueAttribute.Value = databaseName;
				databaseNameNode.Attributes.Append(valueAttribute);
				appSettingsNode.AppendChild(databaseNameNode);

				connectionStringNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='ConnectionString']");
				connectionStringNode.Attributes["value"].Value = connectionStringValue.Replace(databaseName, "%1");

				changed = true;
			}

			return changed;
		}

		private bool UpdateCustomDatabaseName(XmlDocument doc)
		{
			bool changed = false;

			XmlNode databaseNameNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='CustomDatabaseName']");
			if (databaseNameNode == null)
			{
				XmlNode connectionStringNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='ConnectionString']");
				string connectionStringValue = connectionStringNode.Attributes["value"].Value;

				string dataSourceString = "Data Source=";
				int startIndex = connectionStringValue.IndexOf(dataSourceString) + dataSourceString.Length;
				int endIndex = connectionStringValue.IndexOf(';', startIndex);
				string databaseName = connectionStringValue.Substring(startIndex, endIndex - startIndex);

				XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
				databaseNameNode = doc.CreateElement("add");
				XmlAttribute keyAttribute = doc.CreateAttribute("key");
				keyAttribute.Value = "CustomDatabaseName";
				databaseNameNode.Attributes.Append(keyAttribute);
				XmlAttribute valueAttribute = doc.CreateAttribute("value");
				valueAttribute.Value = databaseName;
				databaseNameNode.Attributes.Append(valueAttribute);
				appSettingsNode.AppendChild(databaseNameNode);

				connectionStringNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='ConnectionString']");
				connectionStringNode.Attributes["value"].Value = connectionStringValue.Replace(databaseName, "%1");

				changed = true;
			}

			return changed;
		}

		private bool UpdateSpectrogramLocation(XmlDocument doc)
		{
			bool changed = false;

			XmlNode spectrogramLocationNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='SpectrogramLocation']");
			if (spectrogramLocationNode == null)
			{
				string spectrogramLocation = birdingApp.GetSpectrogramLocation();

				XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
				spectrogramLocationNode = doc.CreateElement("add");
				XmlAttribute keyAttribute = doc.CreateAttribute("key");
				keyAttribute.Value = "SpectrogramLocation";
				spectrogramLocationNode.Attributes.Append(keyAttribute);
				XmlAttribute valueAttribute = doc.CreateAttribute("value");
				valueAttribute.Value = spectrogramLocation != null ? spectrogramLocation : string.Empty;
				spectrogramLocationNode.Attributes.Append(valueAttribute);
				appSettingsNode.AppendChild(spectrogramLocationNode);

				changed = true;
			}

			return changed;
		}

		private string FileExists(string parent, string fileName)
		{
			string retVal = null;

			try
			{
				string path = Path.Combine(parent, fileName);

				if (File.Exists(path))
				{
					retVal = parent;
				}
				else
				{
					string[] directories = Directory.GetDirectories(parent);

					foreach (string directory in directories)
					{
						retVal = FileExists(directory, fileName);
						if (retVal != null)
						{
							break;
						}
					}
				}
			}
			catch (IOException)
			{
			}
			catch (UnauthorizedAccessException)
			{
			}

			return retVal;
		}

		private bool UpdateUpdateLocation(XmlDocument doc)
		{
			bool changed = false;

			XmlNode updateLocationNode = doc.SelectSingleNode("/configuration/appSettings/add[@key='UpdateLocation']");
			if (updateLocationNode == null)
			{
				XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
				updateLocationNode = doc.CreateElement("add");
				XmlAttribute keyAttribute = doc.CreateAttribute("key");
				keyAttribute.Value = "UpdateLocation";
				updateLocationNode.Attributes.Append(keyAttribute);
				XmlAttribute valueAttribute = doc.CreateAttribute("value");
				valueAttribute.Value = GetUpdateLocation();
				updateLocationNode.Attributes.Append(valueAttribute);
				appSettingsNode.AppendChild(updateLocationNode);

				changed = true;
			}

			return changed;
		}

		private string GetUpdateLocation()
		{
			string updateLocation = string.Empty;

			switch (ApplicationSettings.OperatingSystem)
			{
				case OperatingSystem.MacOSX:
					updateLocation = "http://updates.thayerbirding.com/Mac v7.0";
					break;
				case OperatingSystem.Windows:
				default:
					updateLocation = "http://updates.thayerbirding.com/Windows v7.0";
					break;
			}

			return updateLocation;
		}
	}
}
