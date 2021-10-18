using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public interface IQuizMediaPlayer
	{
		IMediaPlayer MediaPlayer { get; }
		void LoadMedia(IMedia media);
		void LoadMedia(IMedia media, IMedia secondaryMedia);
		void LoadMedia(IMedia[] mediaList);
		void LoadMedia(IMedia[] mediaList, IMedia secondaryMedia);
		void PlaySound(string path, bool waitUntilFinished);
	}
}
