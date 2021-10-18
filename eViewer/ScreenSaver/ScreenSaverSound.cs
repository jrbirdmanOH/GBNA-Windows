using System;
using System.IO;

namespace Thayer.Birding.ScreenSaver
{
	public class ScreenSaverSound
	{
		private static MP3Player audioPlayer = null;
		private string fileName = string.Empty;

		public string FileName
		{
			get
			{
				return fileName;
			}

			set
			{
				fileName = value;
			}
		}

		private static MP3Player AudioPlayer
		{
			get
			{
				if (audioPlayer == null)
				{
					audioPlayer = new MP3Player();
				}

				return audioPlayer;
			}
		}

		public ScreenSaverSound()
		{
		}

		public void Play(bool loop)
		{
			Stop();

			if (this.FileName != null && File.Exists(this.FileName))
			{
				AudioPlayer.Open(this.FileName);
				AudioPlayer.Looping = loop;
				AudioPlayer.Play();
			}
		}

		public static void Stop()
		{
			if (AudioPlayer != null)
			{
				AudioPlayer.Stop();
			}
		}
	}
}
