using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Thayer.Birding.Updates
{
	public class Manifest
	{
		public const string LibrarySchemaVersion = "0.9";

		private string applicationDirectory = string.Empty;
		private string applicationDataDirectory = string.Empty;
		private string updateDirectory = string.Empty;
		private string schemaVersion = LibrarySchemaVersion;
		private FileCollection files = null;
		private IVersionInfoProvider versionInfoProvider = null;

		public Manifest()
		{
			files = new FileCollection(this);
		}

		[DefaultValue("")]
		public string ApplicationDirectory
		{
			get
			{
				return applicationDirectory;
			}

			set
			{
				applicationDirectory = value;
			}
		}

		[DefaultValue("")]
		public string ApplicationDataDirectory
		{
			get
			{
				return applicationDataDirectory;
			}

			set
			{
				applicationDataDirectory = value;
			}
		}

		[DefaultValue("")]
		public string UpdateDirectory
		{
			get
			{
				return updateDirectory;
			}

			set
			{
				updateDirectory = value;
			}
		}

		[XmlAttribute("version")]
		public string SchemaVersion
		{
			get
			{
				return schemaVersion;
			}

			set
			{
				schemaVersion = value;
			}
		}

		public FileCollection Files
		{
			get
			{
				return files;
			}

			set
			{
				files = value;
			}
		}

		[XmlIgnore]
		public bool UpdateAvailable
		{
			get
			{
				foreach (File file in files)
				{
					if (file.RequiresUpdate())
					{
						return true;
					}
				}

				return false;
			}
		}

		[XmlIgnore]
		public FileCollection UpdateFiles
		{
			get
			{
				FileCollection updateFiles = new FileCollection(this);

				foreach (File file in files)
				{
					bool update = file.RequiresUpdate();

					if (update)
					{
						updateFiles.Add(file);
					}
				}

				return updateFiles;
			}
		}

		[XmlIgnore]
		public IVersionInfoProvider VersionInfoProvider
		{
			get
			{
				return versionInfoProvider;
			}

			set
			{
				versionInfoProvider = value;
			}
		}

		public static Manifest Load(string fileName)
		{
			Manifest manifest = null;

			if (System.IO.File.Exists(fileName))
			{
				using (FileStream file = new FileStream(fileName, FileMode.Open))
				{
					manifest = Load(file);
				}
			}

			return manifest;
		}

		internal bool RequiresUpdate()
		{
			foreach (File file in Files)
			{
				if (file.RequiresUpdate())
				{
					return true;
				}
			}

			return false;
		}

		internal bool RequiresUpdate(string fileName)
		{
			foreach (File file in Files)
			{
				if (file.StrippedName == fileName && file.RequiresUpdate())
				{
					return true;
				}
			}

			return false;
		}

		public static Manifest Load(Stream stream)
		{
			Manifest manifest = null;

			XmlSerializer serializer = new XmlSerializer(typeof(Manifest));
			manifest = serializer.Deserialize(stream) as Manifest;

			return manifest;
		}

		public void Save(string fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Manifest));
			FileStream file = null;
			try
			{
				file = new FileStream(fileName, FileMode.Create);
				serializer.Serialize(file, this);
			}
			finally
			{
				file.Close();
			}
		}
	}
}
