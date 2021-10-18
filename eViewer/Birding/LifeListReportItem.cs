using System;
using System.Collections.Generic;
using Thayer.Birding.Data;
using Thayer.Birding.Filtering;

namespace Thayer.Birding
{
	public class LifeListReportItem
	{
		public enum SortableColumn
		{
			LifeListNumber,
			CommonName,
			Location,
			FirstSeenDate
		}

		private int lifeListNumber = 0;
		private string commonName = string.Empty;
		private string location = string.Empty;
		private DateTime firstSeenDate = DateTime.Now;

		public LifeListReportItem()
		{
		}

		public LifeListReportItem(int lifeListNumber, string commonName, string location, DateTime firstSeenDate)
		{
			this.LifeListNumber = lifeListNumber;
			this.CommonName = commonName;
			this.Location = location;
			this.FirstSeenDate = firstSeenDate;
		}

		public int LifeListNumber
		{
			get
			{
				return lifeListNumber;
			}

			set
			{
				lifeListNumber = value;
			}
		}

		public string CommonName
		{
			get
			{
				return commonName;
			}

			set
			{
				commonName = value;
			}
		}

		public string Location
		{
			get
			{
				return location;
			}

			set
			{
				location = value;
			}
		}

		public DateTime FirstSeenDate
		{
			get
			{
				return firstSeenDate;
			}

			set
			{
				firstSeenDate = value;
			}
		}

		public static IList<LifeListReportItem> GetFilteredList(LifeListReportFilter filter, SortableColumn sortColumn)
		{
			List<LifeListReportItem> items = SightingsReportDM.Instance.GetList(filter);
			items.Sort(new LifeListReportItemComparer(sortColumn));

			return items;
		}

		private class LifeListReportItemComparer : IComparer<LifeListReportItem>
		{
			private SortableColumn sortColumn = SortableColumn.LifeListNumber;

			public LifeListReportItemComparer(SortableColumn sortColumn)
			{
				this.sortColumn = sortColumn;
			}

			public int Compare(LifeListReportItem x, LifeListReportItem y)
			{
				int compareResult = 0;
				switch (sortColumn)
				{
					case SortableColumn.CommonName:
						compareResult = x.CommonName.CompareTo(y.CommonName);
						break;
					case SortableColumn.LifeListNumber:
						compareResult = x.LifeListNumber.CompareTo(y.LifeListNumber);
						break;
					case SortableColumn.Location:
						compareResult = x.Location.CompareTo(y.Location);
						break;
					case SortableColumn.FirstSeenDate:
						// Only compare date information, not time
						DateTime xFirstSeenDate = new DateTime(x.FirstSeenDate.Year, x.FirstSeenDate.Month, x.FirstSeenDate.Day);
						DateTime yFirstSeenDate = new DateTime(y.FirstSeenDate.Year, y.FirstSeenDate.Month, y.FirstSeenDate.Day);
						compareResult = xFirstSeenDate.CompareTo(yFirstSeenDate);
						if (compareResult == 0)
						{
							compareResult = x.CommonName.CompareTo(y.CommonName);
						}
						break;
				}

				return compareResult;
			}
		}
	}
}
