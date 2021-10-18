using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections.Specialized;

namespace Thayer.Birding.Licensing
{
	public class ThayerLicenseCollection : IEnumerable<ThayerLicense>
	{
		private List<ThayerLicense> licenses = null;

		public ThayerLicenseCollection()
		{
		}

		private List<ThayerLicense> Licenses
		{
			get
			{
				if (licenses == null)
				{
					licenses = new List<ThayerLicense>();
				}

				return licenses;
			}
		}

		public int Count
		{
			get
			{
				return this.Licenses.Count;
			}
		}

		public ThayerLicense this[int index]
		{
			get
			{
				return this.Licenses[index];
			}
		}

		public void Sort(IComparer<ThayerLicense> comparer)
		{
			this.Licenses.Sort(comparer);
		}

		public void ReadXml(XmlNode node)
		{
			this.Licenses.Clear();

			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name == "license")
				{
					ThayerLicense license = new ThayerLicense();
					license.ReadXml(childNode);
					if (license.IsValid() && license.Enabled)
					{
						this.Licenses.Add(license);
					}
					else
					{
						StringCollection messages = new StringCollection();
						string reason;
						if (!license.IsValid(out reason, true))
						{
							messages.Add(string.Format("License with key {0} is not valid: {1}", license.LicenseKey, reason));
						}

						if (!license.Enabled)
						{
							messages.Add(string.Format("License with key {0} is not enabled.", license.LicenseKey));
						}

						Log.Write(messages);
					}
				}
			}
		}

		public void Add(ThayerLicense license)
		{
			// Save license in the license file
			license.Save();

			// Add license to the collection
			this.Licenses.Add(license);

			try
			{
				// NOTE: It is not necessary to keep the config file licenses up to date.
				//       This is being done so there is no confusion when looking at the config file.
				ApplicationSettings.Licenses.Add(License.Create(license.LicenseKey));
			}
			catch (Exception ex)
			{
				// Do nothing
				StringCollection messages = new StringCollection();
				messages.Add("Error adding license key to eViewer.exe.config file.");
				messages.Add(ex.Message);
				messages.Add(Environment.NewLine);
				messages.Add(ex.StackTrace);
				Log.Write(messages);
			}

			Log.Write(string.Format("License with key {0} has been added to the license file.", license.LicenseKey));
		}

		public void Enable(ThayerLicense license)
		{
			// Enable the license and save changes to the license file
			license.Enabled = true;
			license.Save();

			// Add license to the collection
			this.Licenses.Add(license);

			try
			{
				// NOTE: It is not necessary to keep the config file licenses up to date.
				//       This is being done so there is no confusion when looking at the config file.
				ApplicationSettings.Licenses.Add(License.Create(license.LicenseKey));
			}
			catch (Exception ex)
			{
				// Do nothing
				StringCollection messages = new StringCollection();
				messages.Add("Error adding license key to eViewer.exe.config file.");
				messages.Add(ex.Message);
				messages.Add(Environment.NewLine);
				messages.Add(ex.StackTrace);
				Log.Write(messages);
			}

			Log.Write(string.Format("License with key {0} has been enabled in the license file.", license.LicenseKey));
		}

		public void Remove(ThayerLicense license)
		{
			// Disable the license and save changes to the license file
			license.Enabled = false;
			license.Save();

			// Remove license from the collection
			this.Licenses.Remove(license);

			try
			{
				// NOTE: It is not necessary to keep the config file licenses up to date.
				//       This is being done so there is no confusion when looking at the config file.
				foreach (License configLicense in ApplicationSettings.Licenses)
				{
					if (configLicense.LicenseKey == license.LicenseKey)
					{
						ApplicationSettings.Licenses.Remove(configLicense);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				// Do nothing
				StringCollection messages = new StringCollection();
				messages.Add("Error removing license key from eViewer.exe.config file.");
				messages.Add(ex.Message);
				messages.Add(Environment.NewLine);
				messages.Add(ex.StackTrace);
				Log.Write(messages);
			}

			Log.Write(string.Format("License with key {0} has been removed/disabled in the license file.", license.LicenseKey));
		}

		public bool ContainsProduct(Product product)
		{
			bool containsProduct = false;

			foreach (ThayerLicense license in this.Licenses)
			{
				if (license.Product.Code == product.Code)
				{
					containsProduct = true;
					break;
				}
			}

			return containsProduct;
		}

		public static void CreateInitialLicenseFile(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("licenses");
			xmlWriter.WriteEndElement();
		}

		#region IEnumerable<ThayerLicense> Members
		public IEnumerator<ThayerLicense> GetEnumerator()
		{
			return this.Licenses.GetEnumerator();
		}
		#endregion

		#region IEnumerable Members
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Licenses.GetEnumerator();
		}
		#endregion
	}
}
