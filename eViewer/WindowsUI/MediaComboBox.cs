using System.ComponentModel;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	class MediaComboBox : ComboBox
	{
		private bool includeVideo = false;
		private IQuizThing thing = null;
		private int preferredMediaID = 0;

		public MediaComboBox()
		{
		}

		[DefaultValue(false)]
		public bool IncludeVideo
		{
			get
			{
				return includeVideo;
			}

			set
			{
				includeVideo = value;
			}
		}

		[DefaultValue(null)]
		public IQuizThing Thing
		{
			get
			{
				return thing;
			}

			set
			{
				thing = value;

				RefreshMedia();
			}
		}

		[Browsable(false)]
		public int PreferredMediaID
		{
			get
			{
				return preferredMediaID;
			}

			set
			{
				preferredMediaID = value;
				SetPreferredMedia();
			}
		}

		protected void RefreshMedia()
		{
			Items.Clear();

			if (thing != null)
			{
				foreach (IMedia media in thing.Photos)
				{
					Items.Add(new MediaListItem(media));
				}

				foreach (IMedia media in thing.Sounds)
				{
					Items.Add(new MediaListItem(media));
				}

				foreach (IMedia media in thing.RangeMaps)
				{
					Items.Add(new MediaListItem(media));
				}

				foreach (IMedia media in thing.AbundanceMaps)
				{
					Items.Add(new MediaListItem(media));
				}

				if (includeVideo)
				{
					foreach (IMedia media in thing.Videos)
					{
						Items.Add(new MediaListItem(media));
					}
				}

				SetPreferredMedia();
			}
		}

		protected void SetPreferredMedia()
		{
			string preferredMediaMarker = "* ";
			for (int index = 0; index < Items.Count; index++)
			{
				MediaListItem item = Items[index] as MediaListItem;
				if (item.media.ID == preferredMediaID)
				{
					item.text = item.text.Insert(0, preferredMediaMarker);
					RefreshItem(index);
				}
				else if (item.text.StartsWith(preferredMediaMarker))
				{
					item.text = item.text.Substring(preferredMediaMarker.Length);
					RefreshItem(index);
				}
			}
		}

		public IMedia SelectedMedia
		{
			get
			{
				MediaListItem item = SelectedItem as MediaListItem;

				if (item == null)
				{
					return null;
				}

				return item.media;
			}
		}

		private class MediaListItem
		{
			public IMedia media;
			public string text;

			public MediaListItem(IMedia media)
			{
				this.media = media;
				if (media.Type == MediaType.Photo)
				{
					this.text = "Photo: " + media.Caption;
				}
				else if (media.Type == MediaType.Sound)
				{
					this.text = "Sound: " + media.Caption;
				}
				else if (media.Type == MediaType.RangeMap)
				{
					this.text = "Range Map";
					if (media.Caption.Length > 0)
					{
						this.text += ": " + media.Caption;
					}
				}
				else if (media.Type == MediaType.AbundanceMap)
				{
					this.text = "Abundance Map: " + media.Caption;
				}
				else if (media.Type == MediaType.Video)
				{
					this.text = "Video";
				}
				else
				{
					this.text = string.Empty;
				}
			}

			public override string ToString()
			{
				return text;
			}
		}
	}
}
