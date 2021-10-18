using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Thayer.Birding.Configuration
{
	class EncryptedSettingsSectionHandler : IConfigurationSectionHandler
	{
		public EncryptedSettingsSectionHandler()
		{
		}

		public object Create(object parent, object configContext, XmlNode section)
		{
			return ReadXml(section);
		}

		public EncryptedSettings ReadXml(XmlNode section)
		{
			EncryptedSettings settings = new EncryptedSettings();

			if (section != null)
			{
				settings.ReadXml(section);
			}

			return settings;
		}
	}
}
