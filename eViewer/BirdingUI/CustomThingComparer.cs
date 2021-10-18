using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI
{
	public class CustomThingComparer : IComparer<CustomThing>
	{
		public enum SortableColumn
		{
			Name,
			AlternateName
		}

		private SortableColumn sortColumn = SortableColumn.Name;
		private SortOrder sortOrder = SortOrder.Ascending;

		public CustomThingComparer(SortableColumn sortColumn, SortOrder sortOrder)
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

		public int Compare(CustomThing x, CustomThing y)
		{
			int compareResult = 0;
			bool enforceSortOrder = true;
			switch (sortColumn)
			{
				case SortableColumn.Name:
					compareResult = x.Name.CompareTo(y.Name);
					if (compareResult == 0)
					{
						compareResult = x.AlternateNameOriginal.CompareTo(y.AlternateNameOriginal);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.AlternateName:
					compareResult = x.AlternateNameOriginal.CompareTo(y.AlternateNameOriginal);
					if (compareResult == 0)
					{
						compareResult = x.Name.CompareTo(y.Name);
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
