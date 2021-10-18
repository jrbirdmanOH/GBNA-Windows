using System;

namespace Thayer.Birding.ScreenSaver
{
	public class ScreenSaverEntry
	{
		private ScreenSaverImage image = null;
		private ScreenSaverSound sound = null;

		public ScreenSaverImage Image
		{
			get
			{
				if (image == null)
				{
					image = new ScreenSaverImage();
				}

				return image;
			}

			set
			{
				image = value;
			}
		}

		public ScreenSaverSound Sound
		{
			get
			{
				if (sound == null)
				{
					sound = new ScreenSaverSound();
				}

				return sound;
			}

			set
			{
				sound = value;
			}
		}

		public ScreenSaverEntry()
		{
		}
	}
}
