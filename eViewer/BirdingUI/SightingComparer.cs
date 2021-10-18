using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI
{
	public class SightingComparer : IComparer<Sighting>
	{
		public enum SortableColumn
		{
			CommonName,
			Date,
			Location,
			Observer,
			Comments,
			TaxonomicOrder
		}

		private SortableColumn sortColumn = SortableColumn.CommonName;
		private SortOrder sortOrder = SortOrder.Ascending;

		public SightingComparer(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;
		}

		public SortableColumn SortColumn
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

		public SortOrder SortOrder
		{
			get
			{
				return sortOrder;
			}

			set
			{
				sortOrder = value;
			}
		}

		public int Compare(Sighting x, Sighting y)
		{
			int compareResult = 0;
			bool enforceSortOrder = true;
			switch (sortColumn)
			{
				case SortableColumn.CommonName:
					compareResult = x.Organism.Text.CompareTo(y.Organism.Text);
					if (compareResult == 0)
					{
						// Only compare date information, not time
						DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
						DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);

						// Negate result to always put most recent first
						compareResult = -xDate.CompareTo(yDate);
						enforceSortOrder = false;
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
							compareResult = x.Organism.Text.CompareTo(y.Organism.Text);
							enforceSortOrder = false;
						}
					}
					break;
				case SortableColumn.Location:
					compareResult = x.Location.Text.CompareTo(y.Location.Text);
					if (compareResult == 0)
					{
						compareResult = x.Organism.Text.CompareTo(y.Organism.Text);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.Observer:
					compareResult = x.Observer.Text.CompareTo(y.Observer.Text);
					if (compareResult == 0)
					{
						compareResult = x.Organism.Text.CompareTo(y.Organism.Text);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.Comments:
					compareResult = x.Comments.CompareTo(y.Comments);
					if (compareResult == 0)
					{
						compareResult = x.Organism.Text.CompareTo(y.Organism.Text);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.TaxonomicOrder:
					compareResult = x.TaxonomicOrder.CompareTo(y.TaxonomicOrder);
					if (compareResult == 0)
					{
						// Only compare date information, not time
						DateTime xDate = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day);
						DateTime yDate = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day);

						// Negate result to always put most recent first
						compareResult = -xDate.CompareTo(yDate);
						enforceSortOrder = false;
					}
					break;
			}

			if (sortOrder == SortOrder.Descending && enforceSortOrder)
			{
				compareResult = -compareResult;
			}

			return compareResult;
		}
	}
}
