using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Collections.Specialized;

namespace Thayer.Birding.Licensing
{
	public class ThayerLicenseFile
	{
		private static ThayerLicenseFile instance = null;
		private static string licenseFileName = null;
		private static RSA rsaFullKey = null;
		private static RSA rsaPublicKey = null;
		private const string RSAFullKeyXml = "<RSAKeyValue><Modulus>t9x7gvrj6Jd7pNQ3YPnyqx3GHF/XH+1fWXSK2+TaF32xoUYXy1q9GtPQa5/qwGKesdRnKDX0lz51hLJ4lIwSKTXBTfPwdMtSP2/BVY5pF7x8O6TWYu+ygQgzBJ0Ppz8Udts1XMWtOh/o++UCrZBt4lXmt/lLvQaJTN7LOVCu9lk=</Modulus><Exponent>AQAB</Exponent><P>8WEH8bhORXhQgwyQMVEpgPOzy5E+DdhzxHWaPtT6oMMmJCftT9Ld+XCV3pesl5a5/34a3JVN03QtJ65OnrVCfw==</P><Q>wv+L00UalCS+/6Tuk55AgIGYdvAiWKVNJFLM/efNcOTxfW/BO1/fF98RQo7bEWt4ZUvRqYGUh7RyqrasTtmrJw==</Q><DP>2ZJNt9saalINuGJdoqZ2065XlRlhJtfBWgdrNlGBa+EbgyGeLgJzZQDPhimPP8Bz/VDs44GM+hnRDeB3K2VU/w==</DP><DQ>XnpEO/uqUgavx9sYgMtXAyxHO7FDYuHMS4IWshqCjmVOn/DqlaLwy3cXvMDMYVdJwQKINfGDjnCechoJyDZsVw==</DQ><InverseQ>HF6YyxWbaWkHLepe8yGbpJ0bQgkpL6qw6uTaDVkYDqKVdCkGEifHK9VDVieaKbuVZ+kaSb23tb4LnsMQ3TfcHw==</InverseQ><D>mm0onEGoDSK2qiHIhb5J8SlnzUs+P8W68UKuorTb7SEYgdGCiL2k2ZSQmOTPYlky20AAiMiQsDu4rwTLvFDNqrrDCH4Ii76vJRri08+TULUmxQd9SUz+rmN0w8w0rtjTDkQxSTY6zTDm3khHbtqqGzPTsJoKCaQp5g7lDX9qV4U=</D></RSAKeyValue>";
		private const string RSAPublicKeyXml = "<RSAKeyValue><Modulus>t9x7gvrj6Jd7pNQ3YPnyqx3GHF/XH+1fWXSK2+TaF32xoUYXy1q9GtPQa5/qwGKesdRnKDX0lz51hLJ4lIwSKTXBTfPwdMtSP2/BVY5pF7x8O6TWYu+ygQgzBJ0Ppz8Udts1XMWtOh/o++UCrZBt4lXmt/lLvQaJTN7LOVCu9lk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		private string version = string.Empty;
		private DateTime? lastAccessedDate = null;
		private ThayerLicenseCollection licenses = null;

		protected ThayerLicenseFile()
		{
			Init();
		}

		public static ThayerLicenseFile Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ThayerLicenseFile();
				}

				return instance;
			}
		}

		public string Version
		{
			get
			{
				return version;
			}

			private set
			{
				version = value;
			}
		}

		public DateTime? LastAccessedDate
		{
			get
			{
				return lastAccessedDate;
			}

			private set
			{
				lastAccessedDate = value;
			}
		}

		public ThayerLicenseCollection Licenses
		{
			get
			{
				if (licenses == null)
				{
					licenses = new ThayerLicenseCollection();
				}

				return licenses;
			}
		}

		public XmlDocument Document
		{
			get
			{
				return DecryptLicenseFile();
			}

			set
			{
				EncryptLicenseFile(value);
			}
		}

		public string DecryptedString
		{
			get
			{
				return this.Document.OuterXml;
			}
		}

		private static string LicenseFileName
		{
			get
			{
				if (licenseFileName == null)
				{
					licenseFileName = Path.Combine(ApplicationSettings.AppDataPath, "eViewer.lic");
				}

				return licenseFileName;
			}
		}

		private static RSA RSAFullKey
		{
			get
			{
				if (rsaFullKey == null)
				{
					rsaFullKey = new RSACryptoServiceProvider();
					rsaFullKey.FromXmlString(ThayerLicenseFile.RSAFullKeyXml);
				}

				return rsaFullKey;
			}
		}

		private static RSA RSAPublicKey
		{
			get
			{
				if (rsaPublicKey == null)
				{
					rsaPublicKey = new RSACryptoServiceProvider();
					rsaPublicKey.FromXmlString(ThayerLicenseFile.RSAPublicKeyXml);
				}

				return rsaPublicKey;
			}
		}

		public void Init()
		{
			ReadXml();
		}

		private void ReadXml()
		{
			if (File.Exists(ThayerLicenseFile.LicenseFileName))
			{
				XmlDocument doc = DecryptLicenseFile();
				ReadXml(doc.DocumentElement);

				if (this.Licenses.Count == 0)
				{
					StringCollection messages = new StringCollection();
					messages.Add("ThayerLicenseFile.cs: ReadXml()");
					messages.Add("ThayerLicenseCollection is empty.");
					messages.Add("");
					messages.Add("License file contents");
					messages.Add("=====================");
					messages.Add(this.DecryptedString);
					Log.Write(messages);
				}
			}
			else
			{
				throw new ThayerLicenseException("The license file is missing.");
			}
		}

		private void ReadXml(XmlNode node)
		{
			XmlAttribute versionAttribute = node.Attributes["licenseVersion"];
			if (versionAttribute != null)
			{
				this.Version = versionAttribute.Value;
			}

			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name == "lastAccessedDate")
				{
					if (childNode.FirstChild != null)
					{
						string dateString = childNode.FirstChild.Value;
						this.LastAccessedDate = dateString.Length > 0 ? DateTime.Parse(dateString) as DateTime? : null;
					}
					else
					{
						this.LastAccessedDate = null;
					}
				}
				else if (childNode.Name == "licenses")
				{
					this.Licenses.ReadXml(childNode);
				}
			}
		}

		public void UpdateLastAccessedDate()
		{
			if (File.Exists(ThayerLicenseFile.LicenseFileName))
			{
				lastAccessedDate = DateTime.Now;
				string dateString = lastAccessedDate.Value.ToString();

				XmlDocument doc = this.Document;
				XmlNode node = doc.SelectSingleNode("/eFieldGuideViewer/lastAccessedDate");
				if (node != null)
				{
					if (node.FirstChild != null)
					{
						node.FirstChild.Value = dateString;
					}
					else
					{
						XmlText text = doc.CreateTextNode(dateString);
						node.AppendChild(text);
					}
				}
				else
				{
					node = doc.CreateNode(XmlNodeType.Element, "lastAccessedDate", null);
					XmlText text = doc.CreateTextNode(dateString);
					node.AppendChild(text);
					doc.DocumentElement.AppendChild(node);
				}

				this.Document = doc;
			}
			else
			{
				throw new ThayerLicenseException("The license file is missing.");
			}
		}

		public void Validate(IProductSelector productSelector)
		{
			UpdateLastAccessedDate();

			if (ApplicationSettings.FirstTimeRun)
			{
				string initialLicenseKey = ApplicationSettings.Licenses[0].LicenseKey;

				// Remove any licenses from a pre existing license file.  The license file may not
				// get removed during an uninstall on Vista due to virtualization.  Therefore, make
				// sure that no remaining licenses are enabled before running the first time.
				for (int index = this.Licenses.Count - 1; index >= 0; index--)
				{
					RemoveLicense(this.Licenses[index]);
				}

				ValidateAndAddNewLicense(new ThayerLicense(initialLicenseKey), productSelector);
			}
			else
			{
				ValidateExisting();
			}
		}

		private void ValidateAndAddNewLicense(ThayerLicense license, IProductSelector productSelector)
		{
			if (File.Exists(ThayerLicenseFile.LicenseFileName))
			{
				if (license.Product.RequiresProductSelection && !license.Product.HasSelectedProduct)
				{
					Product selectedProduct = productSelector.SelectProduct();
					if (selectedProduct != null)
					{
						license.Product.SelectedProductCode = selectedProduct.Code;
					}
					else
					{
						throw new ThayerLicenseException("A specific state/region must be selected.");
					}
				}

				AddLicense(ref license, productSelector);
			}
			else
			{
				throw new ThayerLicenseException("The license file is missing.");
			}
		}

		private void ValidateExisting()
		{
			if (File.Exists(ThayerLicenseFile.LicenseFileName))
			{
				// Can add any license file validation here if necessary
			}
			else
			{
				throw new ThayerLicenseException("The license file is missing.");
			}
		}

		public void AddLicense(ref ThayerLicense license, IProductSelector productSelector)
		{
			ThayerLicense storedLicense = ThayerLicense.GetLicense(license.LicenseKey);
			if (storedLicense != null)
			{
				if (storedLicense.Enabled)
				{
					throw new ThayerLicenseException(string.Format("License key {0} already exists.", license.LicenseKey));
				}
				else
				{
					// Enable the already existing license
					this.Licenses.Enable(storedLicense);
					license = storedLicense;
				}
			}
			else
			{
				// See if a specific product (state/region) needs to be selected
				if (license.Product.RequiresProductSelection && !license.Product.HasSelectedProduct)
				{
					Product selectedProduct = productSelector.SelectProduct();
					if (selectedProduct != null)
					{
						license.Product.SelectedProductCode = selectedProduct.Code;
					}
					else
					{
						throw new ThayerLicenseException("A specific state/region must be selected.");
					}
				}

				// Add the new license
				this.Licenses.Add(license);
			}
		}

		public void RemoveLicense(ThayerLicense license)
		{
			this.Licenses.Remove(license);
		}

		private static void EncryptLicenseFile(XmlDocument doc)
		{
			EncryptedXml eXml = new EncryptedXml(doc);

			// Create a random session key to do the actual work with 
			RijndaelManaged sessionKey = new RijndaelManaged();
			sessionKey.KeySize = 256;

			// Encrypt the session key 
			EncryptedKey eKey = new EncryptedKey();
			byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, ThayerLicenseFile.RSAPublicKey, false);
			eKey.CipherData = new CipherData(encryptedKey);
			eKey.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

			// Set up a key info clause for the key that was used to encrypt the session key 
			KeyInfoName keyName = new KeyInfoName();
			keyName.Value = "publicKey";
			eKey.KeyInfo.AddClause(keyName);
			eXml.AddKeyNameMapping(keyName.Value, ThayerLicenseFile.RSAPublicKey);

			// Encrypt the entire document
			XmlElement elementToEncrypt = doc.DocumentElement;
			byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);

			// Create the encrypted data 
			EncryptedData eData = new EncryptedData();
			eData.CipherData = new CipherData(encryptedElement);
			eData.Type = EncryptedXml.XmlEncElementUrl;
			eData.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
			eData.KeyInfo.AddClause(new KeyInfoEncryptedKey(eKey));

			// Replace the original XML with this version 
			EncryptedXml.ReplaceElement(elementToEncrypt, eData, false);

			doc.Save(ThayerLicenseFile.LicenseFileName);
		}

		private static XmlDocument DecryptLicenseFile()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(ThayerLicenseFile.LicenseFileName);

			// Create a new EncryptedXml object
			EncryptedXml eXml = new EncryptedXml(doc);

			// Setup the key-name mapping (need full key with public and private data for decryption)
			eXml.AddKeyNameMapping("publicKey", ThayerLicenseFile.RSAFullKey);

			// Decrypt the document
			eXml.DecryptDocument();

			return doc;
		}

		public static void CreateInitialLicenseFile()
		{
			// Create an XmlWriterSettings object with the correct options
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = Encoding.UTF8;
			settings.Indent = true;
			settings.IndentChars = ("\t");
			settings.OmitXmlDeclaration = true;

			using (XmlWriter xmlWriter = XmlWriter.Create(ThayerLicenseFile.LicenseFileName, settings))
			{
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("eFieldGuideViewer");
				xmlWriter.WriteAttributeString("licenseVersion", "1.0");
				xmlWriter.WriteStartElement("lastAccessedDate");
				xmlWriter.WriteEndElement();
				ThayerLicenseCollection.CreateInitialLicenseFile(xmlWriter);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
				xmlWriter.Flush();
			}

			// Encrypt the initial license file
			XmlDocument doc = new XmlDocument();
			doc.PreserveWhitespace = true;
			doc.Load(ThayerLicenseFile.LicenseFileName);

			EncryptLicenseFile(doc);
		}
	}
}
