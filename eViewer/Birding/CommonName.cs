using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class CommonName
	{
		private int id = 0;
		private int languageID = Language.English.ID;
		private string name = string.Empty;
		private string first = string.Empty;
		private string last = string.Empty;
		private string alternatePronunciation = string.Empty;

		public CommonName()
		{
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

		public int LanguageID
		{
			get
			{
				return languageID;
			}

			set
			{
				languageID = value;
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

		public string First
		{
			get
			{
				return first;
			}

			set
			{
				first = value;
			}
		}

		public string Last
		{
			get
			{
				return last;
			}

			set
			{
				last = value;
			}
		}

		public string AlternatePronunciation
		{
			get
			{
				return alternatePronunciation;
			}

			set
			{
				alternatePronunciation = value;
			}
		}

		public string Pronunciation
		{
			get
			{
				if (alternatePronunciation.Length > 0)
				{
					return alternatePronunciation;
				}
				else
				{
					return name;
				}
			}
		}

		public static CommonName GetByThingIDAndLanguage(int thingID, int languageID)
		{
			return CommonNameDM.Instance.GetByThingIDAndLanguage(thingID, languageID);
		}
	}
}
