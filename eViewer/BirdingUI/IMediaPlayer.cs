using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI
{
	public interface IMediaPlayer
	{
		void ShowPicture(IMedia picture);
		void ShowPictureWithSound(IMedia picture, string soundPath);
		void ShowPictures(IMedia[] pictures);
		void ShowPicturesWithSound(IMedia[] pictures, string soundPath);
		void PlaySound(string path);
		void PlayVideo(string path);
		void Stop();
		void Pause();
		void Resume();
	}
}
