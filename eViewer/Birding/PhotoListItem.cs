using System.Collections.Generic;

namespace Thayer.Birding
{
	public class PhotoListItem
	{
		private string organismName = null;
		private IMedia photo = null;
		private IMediaList sounds = null;

		public PhotoListItem()
		{
		}

		public string OrganismName
		{
			get
			{
				return organismName;
			}

			set
			{
				organismName = value;
			}
		}

		public IMedia Photo
		{
			get
			{
				return photo;
			}

			set
			{
				photo = value;
			}
		}

		public IMediaList Sounds
		{
			get
			{
				return sounds;
			}

			set
			{
				sounds = value;
			}
		}
	}
}
