namespace Thayer.Birding.Filtering
{
	public class LifeListReportFilter
	{
		private int languageID = Language.Default.ID;
		private int observerID = 0;

		public LifeListReportFilter()
		{
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

		public int ObserverID
		{
			get
			{
				return observerID;
			}

			set
			{
				observerID = value;
			}
		}
	}
}
