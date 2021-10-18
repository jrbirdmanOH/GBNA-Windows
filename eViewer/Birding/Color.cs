using System.Collections.Generic;

namespace Thayer.Birding
{
	public class Color
	{
		public static Color Black;
		public static Color Blue;
		public static Color Brown;
		public static Color Buff;
		public static Color Chestnut;
		public static Color Gray;
		public static Color Green;
		public static Color Indigo;
		public static Color Olive;
		public static Color Orange;
		public static Color Pink;
		public static Color Purple;
		public static Color Red;
		public static Color Rufous;
		public static Color White;
		public static Color Yellow;

		private static List<Color> colors;

		private string name;
		private string dbColumn;

		static Color()
		{
			colors = new List<Color>();

			Black = Create("Black", Characteristic.Color.Black);
			Blue = Create("Blue", Characteristic.Color.BlueIndigo);
			Brown = Create("Brown", Characteristic.Color.Brown);
			Buff = Create("Buff", Characteristic.Color.YellowBuff);
			Chestnut = Create("Chestnut", Characteristic.Color.ChestnutRufous);
			Gray = Create("Gray", Characteristic.Color.Gray);
			Green = Create("Green", Characteristic.Color.GreenOlive);
			Indigo = Create("Indigo", Characteristic.Color.BlueIndigo);
			Olive = Create("Olive", Characteristic.Color.GreenOlive);
			Orange = Create("Orange", Characteristic.Color.Orange);
			Pink = Create("Pink", Characteristic.Color.RedPink);
			Purple = Create("Purple", Characteristic.Color.Purple);
			Red = Create("Red", Characteristic.Color.RedPink);
			Rufous = Create("Rufous", Characteristic.Color.ChestnutRufous);
			White = Create("White", Characteristic.Color.White);
			Yellow = Create("Yellow", Characteristic.Color.YellowBuff);
		}

		private static Color Create(string name, string dbColumn)
		{
			Color color = new Color(name, dbColumn);

			colors.Add(color);

			return color;
		}

		private Color(string name, string dbColumn)
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

		public static Color[] Colors
		{
			get
			{
				return colors.ToArray();
			}
		}
	}
}
