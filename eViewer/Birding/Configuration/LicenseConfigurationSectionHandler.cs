using System.Configuration;
using System.Xml;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.Configuration
{
	public class LicenseConfigurationSectionHandler : IConfigurationSectionHandler
	{
		public LicenseConfigurationSectionHandler()
		{
		}

		public object Create(object parent, object configContext, XmlNode section)
		{
			return ReadXml(section);
		}

		public LicenseCollection ReadXml(XmlNode section)
		{
			LicenseCollection licenses = new LicenseCollection();
			if (section == null)
			{
				return licenses;
			}

			foreach (XmlNode node in section.ChildNodes)
			{
				if (node.Name == "license")
				{
					string key = node.FirstChild.Value;

					License license = License.Create(key);

					if (license != null)
					{
						licenses.Add(license);
					}
				}
			}

			return licenses;
		}
	}
}
