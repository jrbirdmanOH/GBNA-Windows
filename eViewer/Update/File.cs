using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates
{
	public class File
	{
		private string name;
		private FileAction action;
		private CompareMethod compare;
		private string version;
		private long size;
		private bool retain;
		private DestinationType destination = DestinationType.Application;

		internal Manifest manifest;


		public File()
		{
		}

		public File(string name, DestinationType destination, FileAction action, CompareMethod compare, string version)
		{
			this.Name = name;
			this.Destination = destination;
			this.Action = action;
			this.Compare = compare;
			this.Version = version;
		}

		[XmlAttribute("name")]
		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = SetPathSeparator(value);
			}
		}

		[XmlAttribute("destination")]
		public DestinationType Destination
		{
			get
			{
				return destination;
			}

			set
			{
				destination = value;
			}
		}

		[XmlIgnore]
		public string DestinationPath
		{
			get
			{
				string destinationPath = string.Empty;

				switch (destination)
				{
					case DestinationType.Application:
						destinationPath = BirdingAppSettings.ApplicationFilesDirectoryName;
						break;
					case DestinationType.ApplicationData:
						destinationPath = BirdingAppSettings.ApplicationDataFilesDirectoryName;
						break;
					case DestinationType.System:
						destinationPath = BirdingAppSettings.SystemFilesDirectoryName;
						break;
					default:
						destinationPath = string.Empty; 
						break;
				}

				return destinationPath;
			}
		}

		[XmlIgnore]
		public string StrippedName
		{
			get
			{
				int lastIndex = Name.LastIndexOf("%");

				return Name.Substring(lastIndex + 1);
			}
		}

		[XmlIgnore]
		public string StrippedNameWithDestinationPath
		{
			get
			{
				return Path.Combine(DestinationPath, StrippedName);
			}
		}

		[XmlAttribute("compare")]
		public CompareMethod Compare
		{
			get
			{
				return compare;
			}

			set
			{
				compare = value;
			}
		}

		[XmlAttribute("action")]
		public FileAction Action
		{
			get
			{
				return action;
			}

			set
			{
				action = value;
			}
		}

		[XmlAttribute("version")]
		public string Version
		{
			get
			{
				return version;
			}

			set
			{
				version = value;
			}
		}

		[XmlAttribute("size")]
		public long Size
		{
			get
			{
				return size;
			}

			set
			{
				size = value;
			}
		}

		[XmlAttribute("retain")]
		[DefaultValue(false)]
		public bool Retain
		{
			get
			{
				return retain;
			}

			set
			{
				retain = value;
			}
		}

		public string FullPath
		{
			get
			{
				return GetFullPath();
			}
		}

		public string GetFullPath()
		{
			string directory;
			switch (destination)
			{
				case DestinationType.System:
					if (BirdingAppSettings.Is64BitWindows && BirdingAppSettings.IsRunningAs32Bit)
					{
						// Starting with Windows Vista, 32-bit applications can access the native system
						// directory by substituting %windir%\Sysnative for %windir%\System32. WOW64 recognizes
						// Sysnative as a special alias used to indicate that the file system should not redirect
						// the access. This mechanism is flexible and easy to use, therefore, it is the recommended
						// mechanism to bypass file system redirection. Note that 64-bit applications cannot use
						// the Sysnative alias as it is a virtual directory not a real one.
						directory = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "Sysnative");
					}
					else
					{
						directory = Environment.SystemDirectory;
					}
					break;
				case DestinationType.ApplicationData:
					directory = manifest.ApplicationDataDirectory;
					break;
				case DestinationType.Application:
				default:
					directory = manifest.ApplicationDirectory;
					break;
			}

			string fullPath = Path.Combine(directory, StrippedName);

			return fullPath;
		}

		public string GetFullUpdatePath(string updateDirectory)
		{
			string directory;
			switch (destination)
			{
				case DestinationType.System:
				case DestinationType.ApplicationData:
				case DestinationType.Application:
				default:
					directory = updateDirectory;
					break;
			}

			string fullPath = Path.Combine(directory, StrippedNameWithDestinationPath);

			return fullPath;
		}

		internal bool RequiresUpdate()
		{
			bool requiresUpdate = false;

			switch (Action)
			{
				case FileAction.Delete:
					if (System.IO.File.Exists(FullPath))
					{
						requiresUpdate = true;
					}
					break;
				case FileAction.Copy:
					if (System.IO.File.Exists(FullPath))
					{
						switch (Compare)
						{
							case CompareMethod.Version:
								Version localFileVersion = null;
								if (manifest.VersionInfoProvider != null)
								{
									string versionString = manifest.VersionInfoProvider.GetVersion(FullPath);
									if (versionString != null)
									{
										localFileVersion = new Version(versionString);
									}
								}

								if (localFileVersion == null)
								{
									string fileVersion = FileVersionInfo.GetVersionInfo(FullPath).FileVersion;
									if (fileVersion != null)
									{
										localFileVersion = new Version(fileVersion.Replace(", ", "."));
									}
								}

								Version newFileVersion = new Version(Version);
								requiresUpdate = localFileVersion != newFileVersion;
								break;
							case CompareMethod.Date:
//								DateTime localTimeStamp = System.IO.File.GetLastWriteTimeUtc(FullPath);
//								localTimeStamp = new DateTime(localTimeStamp.Year, localTimeStamp.Month, localTimeStamp.Day, localTimeStamp.Hour, localTimeStamp.Minute, localTimeStamp.Second, DateTimeKind.Utc);
//								DateTime requestTimeStamp = DateTime.Parse(Version, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
//								requiresUpdate = localTimeStamp != requestTimeStamp;

								DateTime localTimeStamp = System.IO.File.GetLastWriteTimeUtc(FullPath);
								localTimeStamp = new DateTime(localTimeStamp.Year, localTimeStamp.Month, localTimeStamp.Day, localTimeStamp.Hour, localTimeStamp.Minute, 0, DateTimeKind.Utc);

								DateTime requestTimeStamp = DateTime.Parse(Version, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
								requestTimeStamp = new DateTime(requestTimeStamp.Year, requestTimeStamp.Month, requestTimeStamp.Day, requestTimeStamp.Hour, requestTimeStamp.Minute, 0, DateTimeKind.Utc);

//								Log.WriteLine("");
//								Log.WriteLine("Local timestamp for: " + FullPath + " is " + localTimeStamp.ToString("u"));
//								Log.WriteLine("Request timestamp for: " + FullPath + " is " + requestTimeStamp.ToString("u"));

								requiresUpdate = localTimeStamp != requestTimeStamp;
								break;
						}
					}
					else
					{
						requiresUpdate = true;
					}
					break;
			}

			return requiresUpdate;
		}

		private string SetPathSeparator(string path)
		{
			return path.Replace('\\', Path.DirectorySeparatorChar);
		}
	}
}
