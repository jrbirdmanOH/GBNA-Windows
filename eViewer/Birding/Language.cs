using System;
using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Language
	{
		private int id = 0;
		private string name = string.Empty;

		private static Language english = new Language(0, "English");

		public Language()
		{
		}

		private Language(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public int ID
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public bool IsEnglish
		{
			get
			{
				return this.ID == Language.English.ID;
			}
		}

		public static Language English
		{
			get
			{
				return english;
			}
		}

		public static Language Default
		{
			get
			{
				return Language.English;
			}
		}

		public static List<Language> GetList()
		{
			return LanguageRegionListDM.Instance.GetLanguageList();
		}

		public static Language GetByID(int id)
		{
			return LanguageRegionListDM.Instance.GetLanguageByID(id);
		}

		public override string ToString()
		{
			return name;
		}
	}
}
