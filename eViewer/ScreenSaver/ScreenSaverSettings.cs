using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Thayer.Birding.ScreenSaver
{
	[Serializable()]
	public class ScreenSaverSettings : IXmlSerializable
	{
		private int imageDisplayTime = 10;
		private bool randomOrder = false;
		private bool displayCommonName = true;
		private bool displayCaption = true;
		private bool playSound = true;
		private bool loopSound = false;

		private const string Version = "1.0";
		private const string FileName = "ScreenSaver.settings";
		private static readonly string FilePath;

		static ScreenSaverSettings()
		{
			StringBuilder filePath = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
			filePath.Append(Path.DirectorySeparatorChar);
			filePath.Append("Thayer Birding Software");
			filePath.Append(Path.DirectorySeparatorChar);
			filePath.Append("Screen Saver");
			FilePath = filePath.ToString();
		}

		public ScreenSaverSettings()
		{
		}

		private static string SettingsFileName
		{
			get
			{
				return Path.Combine(FilePath, FileName);
			}
		}

		public int ImageDisplayTime
		{
			get
			{
				return imageDisplayTime;
			}

			set
			{
				imageDisplayTime = value;
			}
		}

		public bool RandomOrder
		{
			get
			{
				return randomOrder;
			}

			set
			{
				randomOrder = value;
			}
		}

		public bool DisplayCommonName
		{
			get
			{
				return displayCommonName;
			}

			set
			{
				displayCommonName = value;
			}
		}

		public bool DisplayCaption
		{
			get
			{
				return displayCaption;
			}

			set
			{
				displayCaption = value;
			}
		}

		public bool PlaySound
		{
			get
			{
				return playSound;
			}

			set
			{
				playSound = value;
			}
		}

		public bool LoopSound
		{
			get
			{
				return loopSound;
			}

			set
			{
				loopSound = value;
			}
		}

		public void Save()
		{
			// Make sure the directory path exists
			if (!Directory.Exists(FilePath))
			{
				Directory.CreateDirectory(FilePath);
			}

			XmlSerializer serializer = new XmlSerializer(typeof(ScreenSaverSettings));

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = Encoding.UTF8;
			settings.Indent = true;
			settings.IndentChars = ("\t");
			settings.OmitXmlDeclaration = true;

			using (XmlWriter xmlWriter = XmlWriter.Create(ScreenSaverSettings.SettingsFileName, settings))
			{
				serializer.Serialize(xmlWriter, this);
			}
		}

		public static ScreenSaverSettings Load()
		{
			ScreenSaverSettings settings = null;

			if (File.Exists(ScreenSaverSettings.SettingsFileName))
			{
				using (FileStream file = File.OpenRead(ScreenSaverSettings.SettingsFileName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(ScreenSaverSettings));
					settings = serializer.Deserialize(file) as ScreenSaverSettings;
				}
			}
			else
			{
				settings = new ScreenSaverSettings();
			}

			return settings;
		}

		#region IXmlSerializable Members
		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			string nodeName = reader.Name;
			if (nodeName == "ScreenSaverSettings")
			{
				string version = reader.GetAttribute("version");

				reader.ReadStartElement();
				while (reader.IsStartElement())
				{
					nodeName = reader.Name;
					if (nodeName == "ImageDisplayTime")
					{
						this.ImageDisplayTime = Convert.ToInt32(reader.ReadElementContentAsString());
					}
					else if (nodeName == "RandomOrder")
					{
						this.RandomOrder = Convert.ToBoolean(reader.ReadElementContentAsString());
					}
					else if (nodeName == "DisplayCommonName")
					{
						this.DisplayCommonName = Convert.ToBoolean(reader.ReadElementContentAsString());
					}
					else if (nodeName == "DisplayCaption")
					{
						this.DisplayCaption = Convert.ToBoolean(reader.ReadElementContentAsString());
					}
					else if (nodeName == "PlaySound")
					{
						this.PlaySound = Convert.ToBoolean(reader.ReadElementContentAsString());
					}
					else if (nodeName == "LoopSound")
					{
						this.LoopSound = Convert.ToBoolean(reader.ReadElementContentAsString());
					}
					else
					{
						reader.ReadElementContentAsObject();
					}
				}
				reader.ReadEndElement();
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("version", ScreenSaverSettings.Version);
			writer.WriteElementString("ImageDisplayTime", this.ImageDisplayTime.ToString());
			writer.WriteElementString("RandomOrder", this.RandomOrder.ToString());
			writer.WriteElementString("DisplayCommonName", this.DisplayCommonName.ToString());
			writer.WriteElementString("DisplayCaption", this.DisplayCaption.ToString());
			writer.WriteElementString("PlaySound", this.PlaySound.ToString());
			writer.WriteElementString("LoopSound", this.LoopSound.ToString());
		}
		#endregion
	}
}
