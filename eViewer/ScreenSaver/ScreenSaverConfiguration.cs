using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Thayer.Birding.ScreenSaver
{
	public class ScreenSaverConfiguration
	{
		private static readonly string FileName;
		private List<ScreenSaverEntry> entries = null;

		static ScreenSaverConfiguration()
		{
			StringBuilder fileName = new StringBuilder("Thayer Birding Software");
			fileName.Append(Path.DirectorySeparatorChar);
			fileName.Append("Screen Saver");
			fileName.Append(Path.DirectorySeparatorChar);
			fileName.Append("ScreenSaver.config");
			FileName = fileName.ToString();
		}

		public ScreenSaverConfiguration()
		{
		}

		private static string ConfigFileName
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FileName);
			}
		}

		public List<ScreenSaverEntry> Entries
		{
			get
			{
				if (entries == null)
				{
					entries = new List<ScreenSaverEntry>();
				}

				return entries;
			}
		}

		public static ScreenSaverConfiguration Load()
		{
			ScreenSaverConfiguration config = new ScreenSaverConfiguration();

			if (File.Exists(ConfigFileName))
			{
				using (StreamReader reader = File.OpenText(ConfigFileName))
				{
					while (!reader.EndOfStream)
					{
						config.Entries.Add(ParseEntry(reader.ReadLine()));
					}
				}

				if (config.Entries.Count == 0)
				{
					StringBuilder message = new StringBuilder("The Thayer Birding Software configuration ");
					message.Append("file \"");
					message.Append(ConfigFileName);
					message.Append("\" does not specify any birds to display.  You can create a valid ");
					message.Append("configuration file by using the \"Save As Screen Saver...\" menu ");
					message.Append("option in the Custom List Manager of the eField Guide Viewer application.");

					throw new ScreenSaverException(message.ToString());
				}
			}
			else
			{
				StringBuilder message = new StringBuilder("The Thayer Birding Software screen saver could ");
				message.Append("not find the configuration file \"");
				message.Append(ConfigFileName);
				message.Append("\".  You can create a valid configuration file by using the ");
				message.Append("\"Save As Screen Saver...\" menu option in the Custom List Manager ");
				message.Append("of the eField Guide Viewer application.");

				throw new ScreenSaverException(message.ToString());
			}

			return config;
		}

		private static ScreenSaverEntry ParseEntry(string entryString)
		{
			ScreenSaverEntry entry = new ScreenSaverEntry();

			// Simplify the parsing task
			entryString += "&";

			Dictionary<string, string> nameValues = new Dictionary<string, string>();

			string nameValuePattern = @"(?<name>[^=&]+)=(?<value>[^&]+)&";
			MatchCollection matches = Regex.Matches(entryString, nameValuePattern);
			foreach (Match match in matches)
			{
				nameValues.Add(match.Result("${name}"), match.Result("${value}"));
			}

			foreach (string key in nameValues.Keys)
			{
				if (key == "Name")
				{
					entry.Image.Name = nameValues[key];
				}
				else if (key == "Path")
				{
					entry.Image.FileName = nameValues[key];
				}
				else if (key == "Width")
				{
					entry.Image.Width = Convert.ToInt32(nameValues[key]);
				}
				else if (key == "Height")
				{
					entry.Image.Height = Convert.ToInt32(nameValues[key]);
				}
				else if (key == "Caption")
				{
					entry.Image.Caption = nameValues[key];
				}
				else if (key == "Copyright")
				{
					entry.Image.Copyright = nameValues[key];
				}
				else if (key == "Soundfile")
				{
					entry.Sound.FileName = nameValues[key];
				}
				else
				{
					// Not supported
				}
			}

			return entry;
		}
	}
}
