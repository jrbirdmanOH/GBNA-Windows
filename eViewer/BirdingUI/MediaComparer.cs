using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Thayer.Birding.UI
{
	public class MediaComparer : IComparer<IMedia>
	{
		public enum SortableColumn
		{
			FileName,
			Caption,
			Type
		}

		private SortableColumn sortColumn = SortableColumn.FileName;
		private SortOrder sortOrder = SortOrder.Ascending;

		public MediaComparer(SortableColumn sortColumn, SortOrder sortOrder)
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

		public int Compare(IMedia x, IMedia y)
		{
			int compareResult = 0;
			bool enforceSortOrder = true;
			switch (sortColumn)
			{
				case SortableColumn.FileName:
					compareResult = x.FileName.CompareTo(y.FileName);
					if (compareResult == 0)
					{
						compareResult = x.Caption.CompareTo(y.Caption);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.Caption:
					compareResult = x.Caption.CompareTo(y.Caption);
					if (compareResult == 0)
					{
						compareResult = x.FileName.CompareTo(y.FileName);
						enforceSortOrder = false;
					}
					break;
				case SortableColumn.Type:
					compareResult = x.TypeDescription.CompareTo(y.TypeDescription);
					if (compareResult == 0)
					{
						compareResult = x.FileName.CompareTo(y.FileName);
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
