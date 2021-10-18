using System;
using System.Collections.Generic;
using Thayer.Birding.Data;
using Thayer.Birding.Filtering;

namespace Thayer.Birding
{
	public class SightingsReportItem
	{
		public enum SortableColumn
		{
			TaxonomicOrder,
			CommonName,
			Location,
			Date
		}

		public enum GroupableColumn
		{
			None,
			Family,
			Location
		}

		private string commonName = string.Empty;
		private string family = string.Empty;
		private string location = string.Empty;
		private DateTime date = DateTime.Now;
		private string comments = string.Empty;
        private double taxonomicOrder = 0.0;

		public SightingsReportItem()
		{
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

		public string Family
		{
			get
			{
				return family;
			}

			set
			{
				family = value;
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

		public DateTime Date
		{
			get
			{
				return date;
			}

			set
			{
				date = value;
			}
		}

		public string Comments
		{
			get
			{
				return comments;
			}

			set
			{
				comments = value;
			}
		}

        public double TaxonomicOrder
        {
            get
            {
                return taxonomicOrder;
            }

            set
            {
                taxonomicOrder = value;
            }
        }

		private string GetGroupKey(GroupableColumn groupBy)
		{
			string groupKey = string.Empty;

			switch (groupBy)
			{
				case GroupableColumn.None:
					groupKey = string.Empty;
					break;
				case GroupableColumn.Family:
					groupKey = this.Family;
					break;
				case GroupableColumn.Location:
					groupKey = this.Location;
					break;
			}

			return groupKey;
		}

		public static List<SightingsReportItem> GetFilteredList(SightingsReportFilter filter)
		{
			return SightingsReportDM.Instance.GetList(filter);
		}

		public static IList<SightingsReportItem> GetFilteredList(SightingsReportFilter filter, SortableColumn sortColumn)
		{
			List<SightingsReportItem> items = SightingsReportDM.Instance.GetList(filter);
			items.Sort(new SightingsReportItemSortColumnComparer(sortColumn));

			return items;
		}

		public static SortedList<string, List<SightingsReportItem>> GroupList(IList<SightingsReportItem> reportItems, GroupableColumn groupBy, SortableColumn sortColumn)
		{
			SortedList<string, List<SightingsReportItem>> sortedGroupList = new SortedList<string, List<SightingsReportItem>>();
			foreach (SightingsReportItem item in reportItems)
			{
				string groupKey = item.GetGroupKey(groupBy);
				List<SightingsReportItem> group;
				if (sortedGroupList.TryGetValue(groupKey, out group))
				{
					group.Add(item);
				}
				else
				{
					group = new List<SightingsReportItem>();
					group.Add(item);
					sortedGroupList.Add(groupKey, group);
				}
			}

			foreach (List<SightingsReportItem> list in sortedGroupList.Values)
			{
				list.Sort(new SightingsReportItemSortColumnComparer(sortColumn));
			}

			return sortedGroupList;
		}

		private class SightingsReportItemSortColumnComparer : IComparer<SightingsReportItem>
		{
			private SortableColumn sortColumn = SortableColumn.TaxonomicOrder;

			public SightingsReportItemSortColumnComparer(SortableColumn sortColumn)
			{
				this.sortColumn = sortColumn;
			}

			public int Compare(SightingsReportItem x, SightingsReportItem y)
			{
				int compareResult = 0;
				switch (sortColumn)
				{
					case SortableColumn.TaxonomicOrder:
						compareResult = x.TaxonomicOrder.CompareTo(y.TaxonomicOrder);
						if (compareResult == 0)
						{
							DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
							DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);
							compareResult = xDate.CompareTo(yDate);
							if (compareResult == 0)
							{
								compareResult = x.Location.CompareTo(y.Location);
							}
						}
						break;
					case SortableColumn.CommonName:
						compareResult = x.CommonName.CompareTo(y.CommonName);
						if (compareResult == 0)
						{
							DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
							DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);
							compareResult = xDate.CompareTo(yDate);
							if (compareResult == 0)
							{
								compareResult = x.Location.CompareTo(y.Location);
							}
						}
						break;
					case SortableColumn.Location:
						compareResult = x.Location.CompareTo(y.Location);
						if (compareResult == 0)
						{
							DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
							DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);
							compareResult = xDate.CompareTo(yDate);
							if (compareResult == 0)
							{
								compareResult = x.CommonName.CompareTo(y.CommonName);
							}
						}
						break;
					case SortableColumn.Date:
						{
							// Only compare date information, not time
							DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
							DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);
							compareResult = xDate.CompareTo(yDate);
							if (compareResult == 0)
							{
								compareResult = x.CommonName.CompareTo(y.CommonName);
								if (compareResult == 0)
								{
									compareResult = x.Location.CompareTo(y.Location);
								}
							}
						}
						break;
				}

				return compareResult;
			}
		}

		private class SightingsReportItemComparer : IComparer<SightingsReportItem>
		{
			public SightingsReportItemComparer()
			{
			}

			public int Compare(SightingsReportItem x, SightingsReportItem y)
			{
                int compareResult = x.TaxonomicOrder.CompareTo(y.TaxonomicOrder);
                if (compareResult == 0)
                {
                    compareResult = x.CommonName.CompareTo(y.CommonName);
                    if (compareResult == 0)
                    {
						compareResult = x.Date.CompareTo(y.Date);
                        if (compareResult == 0)
                        {
							compareResult = x.Location.CompareTo(y.Location);
							if (compareResult == 0)
                            {
                                compareResult = x.Comments.CompareTo(y.Comments);
                            }
                        }
                    }
                }

				return compareResult;
			}
        }
	}
}
