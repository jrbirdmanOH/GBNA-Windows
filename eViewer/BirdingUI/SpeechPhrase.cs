using System;

namespace Thayer.Birding.UI
{
	public class SpeechPhrase
	{
		private string actualPhrase = string.Empty;
		private string pronunciationPhrase = string.Empty;

		public SpeechPhrase()
		{
		}

		public SpeechPhrase(string actualPhrase, string pronunciationPhrase)
		{
			this.actualPhrase = actualPhrase;
			this.pronunciationPhrase = pronunciationPhrase;
		}

		public string ActualPhrase
		{
			get
			{
				return actualPhrase;
			}

			set
			{
				actualPhrase = value;
			}
		}

		public string PronunciationPhrase
		{
			get
			{
				return pronunciationPhrase;
			}

			set
			{
				pronunciationPhrase = value;
			}
		}
	}
}
