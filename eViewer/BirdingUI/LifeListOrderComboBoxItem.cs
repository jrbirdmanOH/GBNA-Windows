using System.Collections.Generic;

namespace Thayer.Birding.UI
{
	public class LifeListOrderComboBoxItem
	{
		private static List<LifeListOrderComboBoxItem> list = null;
		private LifeListReportItem.SortableColumn sortColumn;
		private string description = string.Empty;

		public LifeListOrderComboBoxItem()
		{
		}

		public LifeListOrderComboBoxItem(LifeListReportItem.SortableColumn sortColumn, string description)
		{
			this.sortColumn = sortColumn;
			this.description = description;
		}

		public LifeListReportItem.SortableColumn SortColumn
		{
			get
			{
				return sortColumn;
			}

			set
			{
				sortColumn = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}

			set
			{
				description = value;
			}
		}

		public override string ToString()
		{
			return description;
		}

		public static List<LifeListOrderComboBoxItem> GetList()
		{
			if (list == null)
			{
				list = new List<LifeListOrderComboBoxItem>(4);
				list.Add(new LifeListOrderComboBoxItem(LifeListReportItem.SortableColumn.CommonName, "Common Name"));
				list.Add(new LifeListOrderComboBoxItem(LifeListReportItem.SortableColumn.LifeListNumber, "Life Number"));
				list.Add(new LifeListOrderComboBoxItem(LifeListReportItem.SortableColumn.FirstSeenDate, "First Seen Date"));
				list.Add(new LifeListOrderComboBoxItem(LifeListReportItem.SortableColumn.Location, "Location"));
			}

			return list;
		}
	}
}
