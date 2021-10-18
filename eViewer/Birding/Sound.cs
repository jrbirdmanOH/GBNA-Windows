using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Sound
	{
		public static Sound Musical = null;
		public static Sound Whistle = null;
		public static Sound Trill = null;
		public static Sound Buzzy = null;
		public static Sound Chirp = null;
		public static Sound Chatter = null;
		public static Sound Scream = null;
		public static Sound Quack = null;
		public static Sound Squawk = null;
		public static Sound Squeek = null;
		public static Sound Honk = null;
		public static Sound Rattle = null;
		public static Sound Hoot = null;
		public static Sound Unusual = null;

		public static Sound Rising = null;
		public static Sound Flat = null;
		public static Sound Falling = null;
		public static Sound SingSong = null;

		private static List<Sound> sounds;

		private string name;
		private string dbColumn;
		private int[] mediaIDs;
		private string[] mediaCommonNames;

		static Sound()
		{
			sounds = new List<Sound>();

			Musical = Create("Musical", Characteristic.Sound.Musical, new int[] { 2663, 2877 });
			Whistle = Create("Whistle", Characteristic.Sound.Whistle, new int[] { 2848, 3064 });
			Trill = Create("Trill", Characteristic.Sound.Trill, new int[] { 3085, 2984 });
			Buzzy = Create("Buzzy", Characteristic.Sound.Buzzy, new int[] { 2963, 2809 });
			Chirp = Create("Chirp", Characteristic.Sound.Chirp, new int[] { 2762, 2956 });
			Chatter = Create("Chatter", Characteristic.Sound.Chatter, new int[] { 2925, 3030 });
			Scream = Create("Scream", Characteristic.Sound.Scream, new int[] { 3315, 3186 });
			Quack = Create("Quack", Characteristic.Sound.Quack, new int[] { 3151, 3166 });
			Squawk = Create("Squawk", Characteristic.Sound.Squawk, new int[] { 3217, 3192 });
			Squeek = Create("Squeek", Characteristic.Sound.Squeek, new int[] { 3342, 3278 });
			Honk = Create("Honk", Characteristic.Sound.Honk, new int[] { 3091, 3093 });
			Rattle = Create("Rattle", Characteristic.Sound.Rattle, new int[] { 8074, 3028 });
			Hoot = Create("Hoot", Characteristic.Sound.Hoot, new int[] { 3067, 3069 });
			Unusual = Create("Unusual", Characteristic.Sound.Unusual, new int[] { 3128, 3183 });

			Rising = Create("Rising", Characteristic.Sound.Rising, new int[] { 3280, 2929 });
			Flat = Create("Flat", Characteristic.Sound.Flat, new int[] { 3242, 3084 });
			Falling = Create("Falling", Characteristic.Sound.Falling, new int[] { 3216, 2964 });
			SingSong = Create("Sing-Song", Characteristic.Sound.SingSong, new int[] { 2872, 2898 });
		}

		private static Sound Create(string name, string dbColumn, int[] mediaIDs)
		{
			Sound sound = new Sound(name, dbColumn, mediaIDs);
			sounds.Add(sound);

			return sound;
		}

		private Sound(string name, string dbColumn, int[] mediaIDs)
		{
			this.name = name;
			this.dbColumn = dbColumn;
			this.mediaIDs = mediaIDs;

			List<string> commonNames = new List<string>();
			foreach (int mediaID in mediaIDs)
			{
				commonNames.Add(OrganismListItem.GetByMediaID(mediaID).CommonName);
			}
			this.mediaCommonNames = commonNames.ToArray();
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public string DBColumn
		{
			get
			{
				return dbColumn;
			}
		}

		public int[] MediaIDs
		{
			get
			{
				return mediaIDs;
			}
		}

		public string[] MediaCommonNames
		{
			get
			{
				return mediaCommonNames;
			}
		}

		public string ToolTip
		{
			get
			{
				return Sound.GetSoundToolTip(this);
			}
		}

		private static string GetSoundToolTip(Sound sound)
		{
			StringBuilder toolTipText = new StringBuilder();

			int index = 0;
			int mediaCount = sound.MediaCommonNames.Length;
			foreach (string commonName in sound.MediaCommonNames)
			{
				if (index == 0)
				{
					toolTipText.Append("Example sounds:  ");
				}

				toolTipText.Append(sound.MediaCommonNames[index]);

				if (mediaCount > 1 && index != mediaCount - 1)
				{
					toolTipText.Append(", ");
				}

				index++;
			}

			return toolTipText.ToString();
		}

		public static Sound[] Sounds
		{
			get
			{
				return sounds.ToArray();
			}
		}
	}
}
