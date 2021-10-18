using System.Collections.Generic;

namespace Thayer.Birding
{
	public class Habitat
	{
		public static Habitat OpenOcean;
		public static Habitat OceanShore;
		public static Habitat Woodlands;
		public static Habitat LakesStreamsWetlands;
		public static Habitat FieldsGrasslandsScrub;
		public static Habitat MountainsCanyons;
		public static Habitat Tundra;
		public static Habitat Desert;
		public static Habitat CitySuburbs;
		public static Habitat Feeders;

		private static List<Habitat> habitats;

		private string name;
		private string dbColumn;

		static Habitat()
		{
			habitats = new List<Habitat>();

			OpenOcean = Create("Open Ocean", Characteristic.Habitat.OpenOcean);
			OceanShore = Create("Ocean Shore", Characteristic.Habitat.OceanShore);
			Woodlands = Create("Woodlands", Characteristic.Habitat.Woodlands);
			LakesStreamsWetlands = Create("Lakes, streams and wetlands", Characteristic.Habitat.LakesStreamsWetlands);
			FieldsGrasslandsScrub = Create("Fields, grasslands and scrub", Characteristic.Habitat.FieldsGrasslandsScrub);
			MountainsCanyons = Create("Mountains and canyons", Characteristic.Habitat.MountainsCanyons);
			Tundra = Create("Tundra", Characteristic.Habitat.Tundra);
			Desert = Create("Desert", Characteristic.Habitat.Desert);
			CitySuburbs = Create("City and suburbs", Characteristic.Habitat.CitySuburbs);
			Feeders = Create("Feeders", Characteristic.Habitat.Feeders);
		}

		private static Habitat Create(string name, string dbColumn)
		{
			Habitat habitat = new Habitat(name, dbColumn);

			habitats.Add(habitat);

			return habitat;
		}

		private Habitat(string name, string dbColumn)
		{
			this.name = name;
			this.dbColumn = dbColumn;
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		internal string DBColumn
		{
			get
			{
				return dbColumn;
			}
		}

		public static Habitat[] Habitats
		{
			get
			{
				return habitats.ToArray();
			}
		}
	}
}
