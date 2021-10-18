namespace Thayer.Birding
{
	public class SimilarSpecies
	{
		private int thingID = 0;
		private int mediaID = 0;
		private Organism organism = null;
		private ImagePreferenceType imagePreference = ImagePreferenceType.Primary;

		public SimilarSpecies()
		{
		}

		public int ThingID
		{
			get
			{
				return thingID;
			}

			set
			{
				thingID = value;
			}
		}

		public int MediaID
		{
			get
			{
				return mediaID;
			}

			set
			{
				mediaID = value;
			}
		}

		public Organism Organism
		{
			get
			{
				if (organism == null)
				{
					organism = Organism.GetByID(thingID);
				}

				return organism;
			}
		}

		public ImagePreferenceType ImagePreference
		{
			get
			{
				return imagePreference;
			}

			set
			{
				imagePreference = value;
			}
		}

		public IMedia Photo
		{
			get
			{
				IMedia photo;

				switch (this.ImagePreference)
				{
					case ImagePreferenceType.Primary:
						if (mediaID > 0)
						{
							photo = Organism.Photos.GetByMediaID(mediaID, false);
							if (photo == null)
							{
								photo = Organism.Photos[0];
							}
						}
						else
						{
							photo = Organism.Photos[0];
						}
						break;
					case ImagePreferenceType.Secondary:
						if (Organism.Photos.Count > 1)
						{
							if (mediaID > 0)
							{
								if (Organism.Photos[1].ID == mediaID)
								{
									photo = Organism.Photos[0];
								}
								else
								{
									photo = Organism.Photos[1];
								}
							}
							else
							{
								photo = Organism.Photos[1];
							}
						}
						else
						{
							photo = Organism.Photos[0];
						}
						break;
					default:
						photo = Organism.Photos[0];
						break;
				}

				return photo;
			}
		}

		public IMedia Sound
		{
			get
			{
				return Organism.Sounds.Count > 0 ? Organism.Sounds[0] : null;
			}
		}
	}
}
