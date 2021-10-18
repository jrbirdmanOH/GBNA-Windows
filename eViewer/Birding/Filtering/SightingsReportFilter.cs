using System;

namespace Thayer.Birding.Filtering
{
	public class SightingsReportFilter
	{
		private int languageID = Language.Default.ID;
		private int observerID = 0;
		private DateTime startDate;
		private DateTime endDate;
		private bool enforceStartDate = false;
		private bool enforceEndDate = false;

		public SightingsReportFilter()
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

		public DateTime StartDate
		{
			get
			{
				return startDate;
			}

			set
			{
				startDate = value;
				enforceStartDate = true;
			}
		}

		public DateTime EndDate
		{
			get
			{
				return endDate;
			}

			set
			{
				endDate = value;
				enforceEndDate = true;
			}
		}

		public bool EnforceStartDate
		{
			get
			{
				return enforceStartDate;
			}

			set
			{
				enforceStartDate = value;
			}
		}

		public bool EnforceEndDate
		{
			get
			{
				return enforceEndDate;
			}

			set
			{
				enforceEndDate = value;
			}
		}
	}
}
