using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class LanguageString
	{
		private string language = string.Empty;
		private string text = string.Empty;

		public LanguageString()
		{
		}

		public LanguageString(string language, string text)
		{
			this.language = language;
			this.text = text;
		}

		public string Language
		{
			get
			{
				return language;
			}

			set
			{
				language = value;
			}
		}

		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		public static List<LanguageString> GetByThingID(int thingID)
		{
			return LanguageRegionListDM.Instance.GetByThingID(thingID);
		}
	}
}
