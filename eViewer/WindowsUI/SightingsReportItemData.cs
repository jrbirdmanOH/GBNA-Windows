using System;
using System.Collections.Generic;
using Thayer.Birding.Filtering;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public class SightingsReportItemData
	{
		private string commonName = string.Empty;
		private string family = string.Empty;
		private string location = string.Empty;
		private DateTime date = DateTime.Now;
		private string comments = string.Empty;
        private double taxonomicOrder = 0.0;

		public SightingsReportItemData(SightingsReportItem reportItem)
		{
			this.CommonName = reportItem.CommonName;
			this.Family = reportItem.Family;
			this.Location = reportItem.Location;
			this.Date = reportItem.Date;
			this.Comments = reportItem.Comments;
            this.TaxonomicOrder = reportItem.TaxonomicOrder;
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

		public static List<SightingsReportItemData> GetFilteredList(SightingsReportFilter filter)
		{
			List<SightingsReportItemData> list = new List<SightingsReportItemData>();
			List<SightingsReportItem> reportItems = SightingsReportItem.GetFilteredList(filter);
			foreach (SightingsReportItem reportItem in reportItems)
			{
				list.Add(new SightingsReportItemData(reportItem));
			}

			return list;
		}

		public static List<SightingsReportItemData> GetFilteredList(SightingsReportFilter filter, SightingsReportItem.SortableColumn sortColumn)
		{
			List<SightingsReportItemData> list = new List<SightingsReportItemData>();

			IList<SightingsReportItem> reportItems = SightingsReportItem.GetFilteredList(filter, sortColumn);
			foreach (SightingsReportItem reportItem in reportItems)
			{
				list.Add(new SightingsReportItemData(reportItem));
			}

			return list;
		}
	}
}
