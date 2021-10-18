using System.Collections.Generic;

namespace Thayer.Birding
{
	public class MediaCollection
	{
		private MediaList photos = new MediaList();
		private MediaList sounds = new MediaList();
		private MediaList rangeMaps = new MediaList();
		private MediaList abundanceMaps = new MediaList();
		private MediaList videos = new MediaList();

		public MediaCollection()
		{
		}

		public void Add(IMedia media)
		{
			if (media.Type == MediaType.Photo)
			{
				photos.Add(media);
			}
			else if (media.Type == MediaType.Sound)
			{
				sounds.Add(media);
			}
			else if (media.Type == MediaType.RangeMap)
			{
				rangeMaps.Add(media);
			}
			else if (media.Type == MediaType.AbundanceMap)
			{
				abundanceMaps.Add(media);
			}
			else if (media.Type == MediaType.Video)
			{
				videos.Add(media);
			}
		}

		public MediaList All
		{
			get
			{
				MediaList list = new MediaList();
				list.AddRange(this.Photos);
				list.AddRange(this.Sounds);
				list.AddRange(this.RangeMaps);
				list.AddRange(this.AbundanceMaps);
				list.AddRange(this.Videos);

				return list;
			}
		}

		public MediaList AllVisible
		{
			get
			{
				// Include all visible media (no sounds)
				MediaList list = new MediaList();
				list.AddRange(this.Photos);
				list.AddRange(this.RangeMaps);
				list.AddRange(this.AbundanceMaps);
				list.AddRange(this.Videos);

				return list;
			}
		}

		public MediaList QuizPhotos
		{
			get
			{
				MediaList mediaList = new MediaList();
				foreach (IMedia media in photos)
				{
					if (media.Order != PhotoContentType.EGG_ORDER && media.Order != PhotoContentType.NEST_ORDER)
					{
						mediaList.Add(media);
					}
				}

				return mediaList;
			}
		}

		public MediaList Photos
		{
			get
			{
				return photos;
			}
		}

		public MediaList Sounds
		{
			get
			{
				return sounds;
			}
		}

		public MediaList Videos
		{
			get
			{
				return videos;
			}
		}

		public MediaList RangeMaps
		{
			get
			{
				return rangeMaps;
			}
		}

		public MediaList AbundanceMaps
		{
			get
			{
				return abundanceMaps;
			}
		}
	}
}
