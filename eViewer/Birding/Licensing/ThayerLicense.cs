using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Thayer.Birding.Licensing
{
	public class ThayerLicense
	{
		private string licenseKey = string.Empty;
		private bool enabled = true;
		private DateTime? createdDate = null;
		private Product product = null;

		public ThayerLicense()
		{
		}

		public ThayerLicense(string licenseKey)
		{
			this.LicenseKey = licenseKey;
		}

		public string LicenseKey
		{
			get
			{
				return licenseKey;
			}

			set
			{
				licenseKey = FormatLicenseKey(value);
			}
		}

		public bool Enabled
		{
			get
			{
				return enabled;
			}

			set
			{
				enabled = value;
			}
		}

		public Product Product
		{
			get
			{
				if (product == null)
				{
					product = new Product(License.GetProductCode(this.LicenseKey));
				}

				return product;
			}

			set
			{
				product = value;
			}
		}

		public DateTime? CreatedDate
		{
			get
			{
				return createdDate;
			}

			private set
			{
				createdDate = value;
			}
		}

		public bool IsBirdsOfMyRegion
		{
			get
			{
				return product.Code == Product.BirdsOfMyRegion;
			}
		}

		private string FormatLicenseKey(string key)
		{
			string formattedLicenseKey = string.Empty;

			string fullKeyPattern = @"\d{4}-\d{4}-\d{4}-\d{4}";
			Match fullKeyMatch = Regex.Match(key, fullKeyPattern);

			if (fullKeyMatch.Success)
			{
				formattedLicenseKey = key;
			}
			else
			{
				// Make sure all dashes are removed
				string tempKey = key.Replace("-", "");

				string partPattern = @"\d{4}";
				MatchCollection matches = Regex.Matches(tempKey, partPattern);

				List<string> keyParts = new List<string>(4);
				foreach (Match match in matches)
				{
					keyParts.Add(match.Value);
				}

				tempKey = string.Join("-", keyParts.ToArray());

				// Make sure format is correct
				fullKeyMatch = Regex.Match(tempKey, fullKeyPattern);
				if (fullKeyMatch.Success)
				{
					formattedLicenseKey = tempKey;
				}
				else
				{
					throw new ThayerLicenseException(string.Format("License key {0} is not a valid license key format.", key));
				}
			}

			return formattedLicenseKey;
		}

		public void Save()
		{
			XmlDocument doc = ThayerLicenseFile.Instance.Document;

			StringBuilder xPath = new StringBuilder("//license[licenseKey = \"");
			xPath.Append(this.LicenseKey);
			xPath.Append("\"]");

			XmlNode licenseNode = doc.SelectSingleNode(xPath.ToString());
			if (licenseNode == null)
			{
				Insert(doc);
			}
			else
			{
				Update(doc, licenseNode);
			}
		}

		private void Insert(XmlDocument doc)
		{
			XmlNode parentNode = doc.SelectSingleNode("//licenses");
			if (parentNode != null)
			{
				this.CreatedDate = DateTime.Now;
				XmlDocumentFragment fragment = doc.CreateDocumentFragment();
				fragment.InnerXml = this.ToXmlString();
				parentNode.AppendChild(fragment);
				ThayerLicenseFile.Instance.Document = doc;
			}
		}

		private void Update(XmlDocument doc, XmlNode licenseNode)
		{
			XmlDocumentFragment fragment = doc.CreateDocumentFragment();
			fragment.InnerXml = this.ToXmlString();
			licenseNode.ParentNode.ReplaceChild(fragment, licenseNode);
			ThayerLicenseFile.Instance.Document = doc;
		}

		public void Delete()
		{
			XmlDocument doc = ThayerLicenseFile.Instance.Document;

			StringBuilder xPath = new StringBuilder("//license[licenseKey = \"");
			xPath.Append(this.LicenseKey);
			xPath.Append("\"]");
			XmlNode licenseNode = doc.SelectSingleNode(xPath.ToString());
			if (licenseNode != null)
			{
				licenseNode.ParentNode.RemoveChild(licenseNode);
				ThayerLicenseFile.Instance.Document = doc;
			}
		}

		public bool IsValid()
		{
			string reason;
			return IsValid(out reason, true);
		}

		public bool IsValid(out string reason, bool enforceProductSelection)
		{
			bool isValid = false;
			reason = string.Empty;

			if (this.LicenseKey != null)
			{
				Product product = new Product();
//				Log.Write(string.Format("About to validate license key {0} with length {1}.", this.LicenseKey, this.LicenseKey.Length));
				if (License.ValidateKey(this.LicenseKey, product))
				{
					if (this.Product.Code == product.Code)
					{
						if (enforceProductSelection)
						{
							if (this.Product.RequiresProductSelection)
							{
								if (this.Product.HasSelectedProduct)
								{
									isValid = true;
								}
								else
								{
									reason = "The product associated with the license key requires the selection of a state/region.";
								}
							}
							else
							{
								isValid = true;
							}
						}
						else
						{
							isValid = true;
						}
					}
					else
					{
						reason = "The product code in the license file is not valid for the license key.";
					}
				}
				else
				{
					reason = "Invalid license key.";
				}
			}
			else
			{
				reason = "The license key cannot be found.";
			}

			return isValid;
		}

		public string ToXmlString()
		{
			StringBuilder xmlString = new StringBuilder();

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = Encoding.UTF8;
			settings.Indent = true;
			settings.IndentChars = ("\t");
			settings.OmitXmlDeclaration = true;

			using (XmlWriter xmlWriter = XmlWriter.Create(new StringWriter(xmlString), settings))
			{
				WriteXml(xmlWriter);
				xmlWriter.Flush();
			}

			return xmlString.ToString();
		}
		
		public void ReadXml(XmlNode node)
		{
			XmlAttribute enabledAttribute = node.Attributes["enabled"];
			if (enabledAttribute != null)
			{
				this.Enabled = Convert.ToBoolean(enabledAttribute.Value);
			}

			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name == "licenseKey")
				{
					this.LicenseKey = childNode.FirstChild.Value;
				}
				else if (childNode.Name == "createdDate")
				{
					this.CreatedDate = DateTime.Parse(childNode.FirstChild.Value);
				}
				else if (childNode.Name == "product")
				{
					Product product = new Product();
					product.ReadXml(childNode);
					this.Product = product;
				}
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("license");
			writer.WriteAttributeString("enabled", this.Enabled.ToString());
			writer.WriteElementString("licenseKey", this.LicenseKey);
			writer.WriteElementString("createdDate", this.CreatedDate.Value.ToString());

			if (this.Product != null)
			{
				this.Product.WriteXml(writer);
			}
			writer.WriteEndElement();
		}

		public static ThayerLicense GetLicense(string licenseKey)
		{
			ThayerLicense license = new ThayerLicense(licenseKey);

			XmlDocument doc = ThayerLicenseFile.Instance.Document;

			StringBuilder xPath = new StringBuilder("//license[licenseKey = \"");
			xPath.Append(license.LicenseKey);
			xPath.Append("\"]");
			XmlNode licenseNode = doc.SelectSingleNode(xPath.ToString());
			if (licenseNode != null)
			{
				license.ReadXml(licenseNode);
			}
			else
			{
				license = null;
			}

			return license;
		}
	}
}
