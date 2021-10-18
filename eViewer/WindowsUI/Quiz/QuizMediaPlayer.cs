using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using Thayer.Birding.UI.Quiz;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public class QuizMediaPlayer : Component, IQuizMediaPlayer
	{
		private IMediaPlayer mediaPlayer = null;
		private Audio audio = null;

		[Browsable(false)]
		public IMediaPlayer MediaPlayer
		{
			get
			{
				return mediaPlayer;
			}

			set
			{
				mediaPlayer = value;
			}
		}

		public QuizMediaPlayer()
		{
		}

		public QuizMediaPlayer(IMediaPlayer mediaPlayer)
		{
			this.mediaPlayer = mediaPlayer;
		}

		public void LoadMedia(IMedia media)
		{
			LoadMedia(media, null);
		}

		public void LoadMedia(IMedia media, IMedia secondaryMedia)
		{
			switch (media.Type)
			{
				case MediaType.Photo:
					if (secondaryMedia == null)
					{
						ShowPhoto(media);
					}
					else
					{
						ShowPhotoWithSound(media, secondaryMedia);
					}
					break;
				case MediaType.Sound:
					PlaySound(media);
					break;
				case MediaType.Video:
					PlayVideo(media);
					break;
				case MediaType.AbundanceMap:
					ShowPhoto(media);
					break;
				case MediaType.RangeMap:
					ShowPhoto(media);
					break;
			}
		}

		public void LoadMedia(IMedia[] mediaList)
		{
			mediaPlayer.ShowPictures(mediaList);
		}

		public void LoadMedia(IMedia[] mediaList, IMedia secondaryMedia)
		{
			mediaPlayer.ShowPicturesWithSound(mediaList, secondaryMedia.AbsolutePath);
		}

		private void ShowPhoto(IMedia media)
		{
			mediaPlayer.ShowPicture(media);
		}

		private void ShowPhotoWithSound(IMedia media, IMedia secondaryMedia)
		{
			mediaPlayer.ShowPictureWithSound(media, secondaryMedia.AbsolutePath);
		}

		private void PlaySound(IMedia media)
		{
			mediaPlayer.PlaySound(media.AbsolutePath);
		}

		public void PlaySound(string path, bool waitUntilFinished)
		{
			if (path != null && File.Exists(path))
			{
				if (audio != null)
				{
					audio.Stop();
					audio.Dispose();
					audio = null;
				}

				audio = new Audio(path, true);
				if (waitUntilFinished)
				{
					while (audio.CurrentPosition < audio.Duration)
					{
						// Periodically check for end of playing sound
						System.Threading.Thread.Sleep(250);
					}
				}
			}
		}

		private void PlayVideo(IMedia media)
		{
			mediaPlayer.PlayVideo(media.AbsolutePath);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (audio != null)
				{
					audio.Dispose();
				}
			}

			base.Dispose(disposing);
		}
	}
}
