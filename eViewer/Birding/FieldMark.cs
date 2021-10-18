using System.Collections.Generic;

namespace Thayer.Birding
{
	public class FieldMark
	{
		public static FieldMark CrestTufts;
		public static FieldMark EyeRing;
		public static FieldMark WhiteOuterTailFeathers;
		public static FieldMark WingBars;

		private static List<FieldMark> fieldMarks;

		private string name;
		private string dbColumn;

		static FieldMark()
		{
			fieldMarks = new List<FieldMark>();

			CrestTufts = Create("Crest/Tufts", Characteristic.FieldMark.CrestsTufts);
			EyeRing = Create("Eye-ring", Characteristic.FieldMark.EyeRing);
			WhiteOuterTailFeathers = Create("White outer tail feathers", Characteristic.FieldMark.WhiteOuterTailFeathers);
			WingBars = Create("Wing bars", Characteristic.FieldMark.WingBars);
		}

		private static FieldMark Create(string name, string dbColumn)
		{
			FieldMark fieldMark = new FieldMark(name, dbColumn);

			fieldMarks.Add(fieldMark);

			return fieldMark;
		}

		private FieldMark(string name, string dbColumn)
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

		public static FieldMark[] FieldMarks
		{
			get
			{
				return fieldMarks.ToArray();
			}
		}
	}
}
