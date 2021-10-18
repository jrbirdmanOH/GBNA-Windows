using System;
using System.Collections.Generic;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.UI.Windows
{
	public class LifeListReportItemData
	{
		private LifeListReportItem item = null;

		public LifeListReportItemData(LifeListReportItem item)
		{
			this.item = item;
		}

		private LifeListReportItem Item
		{
			get
			{
				if (item == null)
				{
					item = new LifeListReportItem();
				}

				return item;
			}
		}

		public int LifeListNumber
		{
			get
			{
				return Item.LifeListNumber;
			}

			set
			{
				Item.LifeListNumber = value;
			}
		}

		public string CommonName
		{
			get
			{
				return Item.CommonName;
			}

			set
			{
				Item.CommonName = value;
			}
		}

		public string Location
		{
			get
			{
				return Item.Location;
			}

			set
			{
				Item.Location = value;
			}
		}

		public DateTime FirstSeenDate
		{
			get
			{
				return Item.FirstSeenDate;
			}

			set
			{
				Item.FirstSeenDate = value;
			}
		}

		public static List<LifeListReportItemData> GetFilteredList(LifeListReportFilter filter, LifeListReportItem.SortableColumn sortColumn)
		{
			List<LifeListReportItemData> list = new List<LifeListReportItemData>();

			IList<LifeListReportItem> reportItems = LifeListReportItem.GetFilteredList(filter, sortColumn);
			foreach (LifeListReportItem reportItem in reportItems)
			{
				list.Add(new LifeListReportItemData(reportItem));
			}

			return list;
		}
	}
}
