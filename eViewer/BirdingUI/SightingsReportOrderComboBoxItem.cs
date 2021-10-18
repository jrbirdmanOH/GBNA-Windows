using System.Collections.Generic;

namespace Thayer.Birding.UI
{
	public class SightingsReportOrderComboBoxItem
	{
		private static List<SightingsReportOrderComboBoxItem> list = null;
		private SightingsReportItem.SortableColumn sortColumn;
		private string description = string.Empty;

		public SightingsReportOrderComboBoxItem()
		{
		}

		public SightingsReportOrderComboBoxItem(SightingsReportItem.SortableColumn sortColumn, string description)
		{
			this.sortColumn = sortColumn;
			this.description = description;
		}

		public SightingsReportItem.SortableColumn SortColumn
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

		public static List<SightingsReportOrderComboBoxItem> GetList()
		{
			if (list == null)
			{
				list = new List<SightingsReportOrderComboBoxItem>(4);
				list.Add(new SightingsReportOrderComboBoxItem(SightingsReportItem.SortableColumn.TaxonomicOrder, "Taxonomic"));
				list.Add(new SightingsReportOrderComboBoxItem(SightingsReportItem.SortableColumn.CommonName, "Common Name"));
				list.Add(new SightingsReportOrderComboBoxItem(SightingsReportItem.SortableColumn.Location, "Location"));
				list.Add(new SightingsReportOrderComboBoxItem(SightingsReportItem.SortableColumn.Date, "Date"));
			}

			return list;
		}
	}
}
