using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Thayer.Birding
{
	class EncryptedSettings
	{
		private const string Key = "th@y3rb1rd1ng";
		private string data;

		public EncryptedSettings()
		{
		}

		public string Data
		{
			get
			{
				return data;
			}

			set
			{
				data = value;
			}
		}

		public void ReadXml(XmlNode node)
		{
			foreach (XmlNode parentNode in node.ChildNodes)
			{
				if (parentNode.Name == "EncryptedData")
				{
					XmlNode childNode = parentNode.FirstChild;

					if (childNode.Name == "CipherData")
					{
						childNode = childNode.FirstChild;

						if (childNode.Name == "CipherValue")
						{
							string cipherValue = childNode.FirstChild.Value;
							data = Decrypt(cipherValue);
						}
					}
				}
			}
		}

		public void Save(string nodeName)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(data);

			string encryptedData = Encrypt(doc.DocumentElement.OuterXml);

			doc = new XmlDocument();
			doc.Load(ApplicationSettings.ConfigFileName);

			XmlNode configurationNode = doc.SelectSingleNode("/configuration");

			XmlNode dataNode = configurationNode.SelectSingleNode(nodeName);
			if (dataNode == null)
			{
				dataNode = doc.CreateNode(XmlNodeType.Element, nodeName, null);
				configurationNode.AppendChild(dataNode);
			}

			XmlNode encryptedDataNode = dataNode.SelectSingleNode("EncryptedData");
			if(encryptedDataNode == null)
			{
				encryptedDataNode = doc.CreateNode(XmlNodeType.Element, "EncryptedData", null);
				dataNode.AppendChild(encryptedDataNode);
			}

			XmlNode cipherDataNode = encryptedDataNode.SelectSingleNode("CipherData");
			if(cipherDataNode == null)
			{
				cipherDataNode = doc.CreateNode(XmlNodeType.Element, "CipherData", null);
				encryptedDataNode.AppendChild(cipherDataNode);
			}

			XmlNode cipherValueNode = cipherDataNode.SelectSingleNode("CipherValue");
			if(cipherValueNode == null)
			{
				cipherValueNode = doc.CreateNode(XmlNodeType.Element, "CipherValue", null);
				cipherDataNode.AppendChild(cipherValueNode);
			}

			cipherValueNode.RemoveAll();

			cipherValueNode.AppendChild(doc.CreateTextNode(encryptedData));

			doc.Save(ApplicationSettings.ConfigFileName);
		}

		private static TripleDESCryptoServiceProvider Get3DESCryptoProvider()
		{
			//generate an MD5 hash from the password. 
			//a hash is a one way encryption meaning once you generate
			//the hash, you cant derive the password back from it.
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			byte[] keyHash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
			hashmd5.Clear();

			//implement DES3 encryption
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

			//the key is the secret password hash.
			des.Key = keyHash;

			//the mode is the block cipher mode which is basically the
			//details of how the encryption will work. There are several
			//kinds of ciphers available in DES3 and they all have benefits
			//and drawbacks. Here the Electronic Codebook cipher is used
			//which means that a given bit of text is always encrypted
			//exactly the same when the same password is used.
			des.Mode = CipherMode.ECB; //CBC, CFB

			return des;
		}

		private static string Decrypt(string encryptedData)
		{
			TripleDESCryptoServiceProvider des = Get3DESCryptoProvider();

			//----- decrypt an encrypted string ------------
			//whenever you decrypt a string, you must do everything you
			//did to encrypt the string, but in reverse order. To encrypt,
			//first a normal string was des3 encrypted into a byte array
			//and then base64 encoded for reliable transmission. So, to 
			//decrypt this string, first the base64 encoded string must be 
			//decoded so that just the encrypted byte array remains.
			byte[] buff = Convert.FromBase64String(encryptedData);

			//decrypt DES 3 encrypted byte buffer and return ASCII string
			string decrypted = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

			des.Clear();

			return decrypted;
		}

		private static string Encrypt(string data)
		{
			TripleDESCryptoServiceProvider des = Get3DESCryptoProvider();

			//----- encrypt an un-encrypted string ------------
			//the original string, which needs encrypted, must be in byte
			//array form to work with the des3 class. everything will because
			//most encryption works at the byte level so you'll find that
			//the class takes in byte arrays and returns byte arrays and
			//you'll be converting those arrays to strings.
			byte[] buff = ASCIIEncoding.ASCII.GetBytes(data);

			//encrypt the byte buffer representation of the original string
			//and base64 encode the encrypted string. the reason the encrypted
			//bytes are being base64 encoded as a string is the encryption will
			//have created some weird characters in there. Base64 encoding
			//provides a platform independent view of the encrypted string 
			//and can be sent as a plain text string to wherever.
			string encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

			des.Clear();

			return encrypted;
		}
	}
}
