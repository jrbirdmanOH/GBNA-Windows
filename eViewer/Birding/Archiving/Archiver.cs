using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Thayer.Birding.Archiving
{
	public class Archiver
	{
		private Archiver()
		{
		}

		public static void BackUp(string path)
		{
			using (StreamWriter writer = File.CreateText(path))
			{
				BackUp(writer);
			}
		}

		public static void BackUp(TextWriter writer)
		{
			Archive archive = new Archive();

			archive.CustomLists = CustomList.GetList();
			archive.Observers = Observer.GetList();
			archive.Sightings = Sighting.GetList();
			archive.HallOfFameEntries = HallOfFame.GetList();
			archive.Notes = Note.GetList();

			XmlSerializer serializer = new XmlSerializer(typeof(Archive));
			serializer.Serialize(writer, archive);
		}

		public static string GenerateArchiveName()
		{
			StringBuilder name = new StringBuilder("Thayer Birding Backup (");
			name.Append(DateTime.Now.ToString("yyyy-MM-dd"));
			name.Append(").xml");

			return name.ToString();
		}

		public static Archive OpenArchive(string path)
		{
			Archive archive = null;
			using (StreamReader reader = File.OpenText(path))
			{
				archive = OpenArchive(reader);
			}

			return archive;
		}

		public static Archive OpenArchive(TextReader reader)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Archive));
			return (Archive)serializer.Deserialize(reader);
		}
	}
}
