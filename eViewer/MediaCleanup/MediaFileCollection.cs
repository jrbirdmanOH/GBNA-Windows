using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding;

namespace Thayer.MediaCleanup
{
	public class MediaFileCollection
	{
		private MediaFileList photos = new MediaFileList();
		private MediaFileList sounds = new MediaFileList();
		private MediaFileList rangeMaps = new MediaFileList();
		private MediaFileList abundanceMaps = new MediaFileList();
		private MediaFileList videos = new MediaFileList();

		public MediaFileCollection()
		{
		}

		public void Add(MediaFile mediaFile)
		{
			if (mediaFile.Type == MediaType.Photo)
			{
				photos.Add(mediaFile);
			}
			else if (mediaFile.Type == MediaType.Sound)
			{
				sounds.Add(mediaFile);
			}
			else if (mediaFile.Type == MediaType.RangeMap)
			{
				rangeMaps.Add(mediaFile);
			}
			else if (mediaFile.Type == MediaType.AbundanceMap)
			{
				abundanceMaps.Add(mediaFile);
			}
			else if (mediaFile.Type == MediaType.Video)
			{
				videos.Add(mediaFile);
			}
		}

		public MediaFileList Photos
		{
			get
			{
				return photos;
			}
		}

		public MediaFileList Sounds
		{
			get
			{
				return sounds;
			}
		}

		public MediaFileList Videos
		{
			get
			{
				return videos;
			}
		}

		public MediaFileList RangeMaps
		{
			get
			{
				return rangeMaps;
			}
		}

		public MediaFileList AbundanceMaps
		{
			get
			{
				return abundanceMaps;
			}
		}

		public int Count
		{
			get
			{
				int count = 0;

				count += this.Photos.Count;
				count += this.Sounds.Count;
				count += this.Videos.Count;
				count += this.RangeMaps.Count;
				count += this.AbundanceMaps.Count;

				return count;
			}
		}
	}
}
