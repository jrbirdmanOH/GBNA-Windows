using System.Collections.Generic;

namespace Thayer.Birding
{
	public class MediaList : List<IMedia>, IMediaList
	{
		public MediaList()
		{
		}

		public IMedia GetByMediaID(int mediaID, bool isCustom)
		{
			foreach (IMedia media in this)
			{
				if (media.ID == mediaID && media.IsCustom == isCustom)
				{
					return media;
				}
			}

			return null;
		}
/*
		public Media GetByMediaID(int mediaID)
		{
			foreach (Media media in this)
			{
				if (media.ID == mediaID)
				{
					return media;
				}
			}

			return null;
		}
*/
	}
}
