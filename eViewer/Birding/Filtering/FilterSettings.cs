using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Thayer.Birding.Filtering
{
    public class FilterSettings
    {
		private bool restoreFilterAtStartup = false;
		private FilterCollection filterCollection = null;

		public FilterSettings()
		{
		}

		public bool RestoreFilterAtStartup
		{
			get
			{
				return restoreFilterAtStartup;
			}

			set
			{
				restoreFilterAtStartup = value;
			}
		}

		public FilterCollection FilterCollection
        {
            get
            {
				if (filterCollection == null)
				{
					filterCollection = new FilterCollection();
				}

                return filterCollection;
            }

            set
            {
				filterCollection = value;
            }
        }

		public bool CanRestore()
		{
			bool canRestore = true;

			switch (this.FilterCollection.FilterType)
			{
				case FilterCollection.FilterTypes.None:
					canRestore = false;
					break;
				case FilterCollection.FilterTypes.CustomList:
					// Make sure custom list exists before restoring
					foreach (IFilter filter in this.FilterCollection)
					{
						if (CustomList.GetByID(filter.ID) == null)
						{
							canRestore = false;
						}
					}
					break;
				default:
					canRestore = true;
					break;
			}

			return canRestore;
		}
	}
}
