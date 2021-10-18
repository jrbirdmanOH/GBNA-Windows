using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace Thayer.Birding.Licensing
{
	public class LicenseCollection : IEnumerable<License>
	{
		private List<License> list = new List<License>();
		private enum LicenseAction { Add, Remove };

		public LicenseCollection()
		{
		}

		public void Add(License license)
		{
			list.Add(license);

			SaveLicenses(license, LicenseAction.Add);
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public void Remove(License license)
		{
			list.Remove(license);

			SaveLicenses(license, LicenseAction.Remove);
		}

		public License this[int index]
		{
			get
			{
				return list[index];
			}
		}

		private void SaveLicenses(License license, LicenseAction action)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(ApplicationSettings.ConfigFileName);

			XmlNode licensesNode = doc.SelectSingleNode("/configuration/licenses");

			if (licensesNode == null)
			{
				XmlNode configurationNode = doc.SelectSingleNode("/configuration");
				licensesNode = doc.CreateNode(XmlNodeType.Element, "licenses", null);
				configurationNode.AppendChild(licensesNode);
			}

			bool found = false;
			foreach (XmlNode node in licensesNode.ChildNodes)
			{
				if (node.FirstChild.Value == license.LicenseKey)
				{
					found = true;
					if (action == LicenseAction.Remove)
					{
						licensesNode.RemoveChild(node);
					}
					break;
				}
			}

			if (!found && action == LicenseAction.Add)
			{
				XmlNode licenseNode = doc.CreateNode(XmlNodeType.Element, "license", null);
				XmlText licenseText = doc.CreateTextNode(license.LicenseKey);
				licenseNode.AppendChild(licenseText);
				licensesNode.AppendChild(licenseNode);
			}

			doc.Save(ApplicationSettings.ConfigFileName);
		}

		IEnumerator<License> IEnumerable<License>.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}
	}
}
