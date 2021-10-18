using Thayer.Birding.Data;

namespace Thayer.Birding
{
	internal class Characteristic
	{
		private static SizeCharacteristic size = new SizeCharacteristic();
		private static HabitatCharacteristic habitat = new HabitatCharacteristic();
		private static ColorCharacteristic color = new ColorCharacteristic();
		private static FieldMarkCharacteristic fieldMark = new FieldMarkCharacteristic();
		private static SoundCharacteristic sound = new SoundCharacteristic();

		static Characteristic()
		{
			CharacteristicsDM characteristicsDM = CharacteristicsDM.Instance;

			size.low = characteristicsDM.GetColumn("size", "size low");
			size.high = characteristicsDM.GetColumn("size", "size high");

			habitat.openOcean = characteristicsDM.GetColumn("habitat", "open ocean");
			habitat.oceanShore = characteristicsDM.GetColumn("habitat", "ocean shore");
			habitat.woodlands = characteristicsDM.GetColumn("habitat", "woodlands");
			habitat.lakesStreamsWetlands = characteristicsDM.GetColumn("habitat", "lakes, streams, and wetlands");
			habitat.fieldsGrasslandsScrub = characteristicsDM.GetColumn("habitat", "fields, grasslands, and scrub");
			habitat.mountainsCanyons = characteristicsDM.GetColumn("habitat", "mountains, canyons");
			habitat.tundra = characteristicsDM.GetColumn("habitat", "tundra");
			habitat.desert = characteristicsDM.GetColumn("habitat", "desert");
			habitat.citySuburbs = characteristicsDM.GetColumn("habitat", "city, suburbs");
			habitat.feeders = characteristicsDM.GetColumn("habitat", "feeders");

			color.black = characteristicsDM.GetColumn("color", "black");
			color.blueIndigo = characteristicsDM.GetColumn("color", "blue/indigo");
			color.brown = characteristicsDM.GetColumn("color", "brown");
			color.chestnutRufous = characteristicsDM.GetColumn("color", "chestnut/rufous");
			color.gray = characteristicsDM.GetColumn("color", "gray");
			color.greenOlive = characteristicsDM.GetColumn("color", "green/olive");
			color.orange = characteristicsDM.GetColumn("color", "orange");
			color.purple = characteristicsDM.GetColumn("color", "purple");
			color.redPink = characteristicsDM.GetColumn("color", "red/pink");
			color.white = characteristicsDM.GetColumn("color", "white");
			color.yellowBuff = characteristicsDM.GetColumn("color", "yellow/buff");
			color.majorColor = characteristicsDM.GetColumn("color", "major color");

			fieldMark.crestsTufts = characteristicsDM.GetColumn("field mark", "crests/tufts");
			fieldMark.eyeRing = characteristicsDM.GetColumn("field mark", "eye-ring");
			fieldMark.whiteOuterTailFeathers = characteristicsDM.GetColumn("field mark", "white outer tail feathers");
			fieldMark.wingBars = characteristicsDM.GetColumn("field mark", "wing bars");

			sound.musical = characteristicsDM.GetColumn("sound", "musical");
			sound.whistle = characteristicsDM.GetColumn("sound", "whistle");
			sound.trill = characteristicsDM.GetColumn("sound", "trill");
			sound.buzzy = characteristicsDM.GetColumn("sound", "buzzy");
			sound.chirp = characteristicsDM.GetColumn("sound", "chirp");
			sound.chatter = characteristicsDM.GetColumn("sound", "chatter");
			sound.scream = characteristicsDM.GetColumn("sound", "scream");
			sound.quack = characteristicsDM.GetColumn("sound", "quack");
			sound.squawk = characteristicsDM.GetColumn("sound", "squawk");
			sound.squeek = characteristicsDM.GetColumn("sound", "squeek");
			sound.honk = characteristicsDM.GetColumn("sound", "honk");
			sound.rattle = characteristicsDM.GetColumn("sound", "rattle");
			sound.hoot = characteristicsDM.GetColumn("sound", "hoot");
			sound.unusual = characteristicsDM.GetColumn("sound", "unusual");

			sound.rising = characteristicsDM.GetColumn("sound", "rising");
			sound.flat = characteristicsDM.GetColumn("sound", "flat");
			sound.falling = characteristicsDM.GetColumn("sound", "falling");
			sound.singSong = characteristicsDM.GetColumn("sound", "sing-song");
		}

		private Characteristic()
		{
		}

		public static SizeCharacteristic Size
		{
			get
			{
				return size;
			}
		}

		public static HabitatCharacteristic Habitat
		{
			get
			{
				return habitat;
			}
		}

		public static ColorCharacteristic Color
		{
			get
			{
				return color;
			}
		}

		public static FieldMarkCharacteristic FieldMark
		{
			get
			{
				return fieldMark;
			}
		}

		public static SoundCharacteristic Sound
		{
			get
			{
				return sound;
			}
		}

		internal class SizeCharacteristic
		{
			internal string low;
			internal string high;

			internal SizeCharacteristic()
			{
			}

			public string Low
			{
				get
				{
					return low;
				}
			}

			public string High
			{
				get
				{
					return high;
				}
			}
		}

		internal class HabitatCharacteristic
		{
			internal string openOcean;
			internal string oceanShore;
			internal string woodlands;
			internal string lakesStreamsWetlands;
			internal string fieldsGrasslandsScrub;
			internal string mountainsCanyons;
			internal string tundra;
			internal string desert;
			internal string citySuburbs;
			internal string feeders;

			internal HabitatCharacteristic()
			{
			}

			public string OpenOcean
			{
				get
				{
					return openOcean;
				}
			}

			public string OceanShore
			{
				get
				{
					return oceanShore;
				}
			}

			public string Woodlands
			{
				get
				{
					return woodlands;
				}
			}

			public string LakesStreamsWetlands
			{
				get
				{
					return lakesStreamsWetlands;
				}
			}

			public string FieldsGrasslandsScrub
			{
				get
				{
					return fieldsGrasslandsScrub;
				}
			}

			public string MountainsCanyons
			{
				get
				{
					return mountainsCanyons;
				}
			}

			public string Tundra
			{
				get
				{
					return tundra;
				}
			}

			public string Desert
			{
				get
				{
					return desert;
				}
			}

			public string CitySuburbs
			{
				get
				{
					return citySuburbs;
				}
			}

			public string Feeders
			{
				get
				{
					return feeders;
				}
			}
		}

		internal class ColorCharacteristic
		{
			internal string black;
			internal string blueIndigo;
			internal string brown;
			internal string chestnutRufous;
			internal string gray;
			internal string greenOlive;
			internal string orange;
			internal string purple;
			internal string redPink;
			internal string white;
			internal string yellowBuff;
			internal string majorColor;

			internal ColorCharacteristic()
			{
			}

			public string Black
			{
				get
				{
					return black;
				}
			}

			public string BlueIndigo
			{
				get
				{
					return blueIndigo;
				}
			}

			public string Brown
			{
				get
				{
					return brown;
				}
			}

			public string ChestnutRufous
			{
				get
				{
					return chestnutRufous;
				}
			}

			public string Gray
			{
				get
				{
					return gray;
				}
			}

			public string GreenOlive
			{
				get
				{
					return greenOlive;
				}
			}

			public string Orange
			{
				get
				{
					return orange;
				}
			}

			public string Purple
			{
				get
				{
					return purple;
				}
			}

			public string RedPink
			{
				get
				{
					return redPink;
				}
			}

			public string White
			{
				get
				{
					return white;
				}
			}

			public string YellowBuff
			{
				get
				{
					return yellowBuff;
				}
			}

			public string MajorColor
			{
				get
				{
					return majorColor;
				}
			}
		}

		internal class FieldMarkCharacteristic
		{
			internal string crestsTufts;
			internal string eyeRing;
			internal string whiteOuterTailFeathers;
			internal string wingBars;

			internal FieldMarkCharacteristic()
			{
			}

			public string CrestsTufts
			{
				get
				{
					return crestsTufts;
				}
			}

			public string EyeRing
			{
				get
				{
					return eyeRing;
				}
			}

			public string WhiteOuterTailFeathers
			{
				get
				{
					return whiteOuterTailFeathers;
				}
			}

			public string WingBars
			{
				get
				{
					return wingBars;
				}
			}
		}

		internal class SoundCharacteristic
		{
			internal string musical;
			internal string whistle;
			internal string trill;
			internal string buzzy;
			internal string chirp;
			internal string chatter;
			internal string scream;
			internal string quack;
			internal string squawk;
			internal string squeek;
			internal string honk;
			internal string rattle;
			internal string hoot;
			internal string unusual;
			internal string rising;
			internal string flat;
			internal string falling;
			internal string singSong;

			internal SoundCharacteristic()
			{
			}

			public string Musical
			{
				get
				{
					return musical;
				}
			}

			public string Whistle
			{
				get
				{
					return whistle;
				}
			}

			public string Trill
			{
				get
				{
					return trill;
				}
			}

			public string Buzzy
			{
				get
				{
					return buzzy;
				}
			}

			public string Chirp
			{
				get
				{
					return chirp;
				}
			}

			public string Chatter
			{
				get
				{
					return chatter;
				}
			}

			public string Scream
			{
				get
				{
					return scream;
				}
			}

			public string Quack
			{
				get
				{
					return quack;
				}
			}

			public string Squawk
			{
				get
				{
					return squawk;
				}
			}

			public string Squeek
			{
				get
				{
					return squeek;
				}
			}

			public string Honk
			{
				get
				{
					return honk;
				}
			}

			public string Rattle
			{
				get
				{
					return rattle;
				}
			}

			public string Hoot
			{
				get
				{
					return hoot;
				}
			}

			public string Unusual
			{
				get
				{
					return unusual;
				}
			}

			public string Rising
			{
				get
				{
					return rising;
				}
			}

			public string Flat
			{
				get
				{
					return flat;
				}
			}

			public string Falling
			{
				get
				{
					return falling;
				}
			}

			public string SingSong
			{
				get
				{
					return singSong;
				}
			}
		}
	}
}
