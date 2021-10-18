using System.IO;
using System.Security.Principal;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Thayer.Birding.Filtering
{
	public class UserFilterSettings
	{
		private static UserFilterSettings instance = new UserFilterSettings();

		private string fileName;
		private XmlSerializer filterSerializer = new XmlSerializer(typeof(FilterSettings));
		private FilterSettings filterSettings = null;

		private UserFilterSettings()
		{
			string parentPath = ApplicationSettings.AppDataPath;
			parentPath = Path.Combine(parentPath, "Settings");
			if (!Directory.Exists(parentPath))
			{
				Directory.CreateDirectory(parentPath);
			}

			parentPath = Path.Combine(parentPath, WindowsIdentity.GetCurrent().Name);
			if (!Directory.Exists(parentPath))
			{
				Directory.CreateDirectory(parentPath);
			}

			fileName = Path.Combine(parentPath, "UserFilterSettings.xml");

			Reload();
		}

		public static UserFilterSettings Instance
		{
			get
			{
				return instance;
			}
		}

		public FilterSettings FilterSettings
		{
			get
			{
				return filterSettings;
			}

			set
			{
				filterSettings = value;
				Save();
			}
		}

		private void Reload()
		{
			if (File.Exists(fileName))
			{
				using (XmlTextReader reader = new XmlTextReader(fileName))
				{
					reader.WhitespaceHandling = WhitespaceHandling.None;

					if (reader.Name == "FilterSettings" || reader.ReadToFollowing("FilterSettings"))
					{
						filterSettings = (FilterSettings)filterSerializer.Deserialize(reader);
					}
					else
					{
						filterSettings = new FilterSettings();
					}
				}
			}
			else
			{
				filterSettings = new FilterSettings();
			}
		}

		private void Save()
		{
			using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
			{
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument();
				writer.WriteStartElement("UserFilterSettings");
				filterSerializer.Serialize(writer, filterSettings);
				writer.WriteEndElement();
			}
		}
	}
}
