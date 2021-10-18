using System;

namespace Thayer.Birding
{
	public class LanguageChangedEventArgs : EventArgs
	{
		private Language language = Language.Default;

		public LanguageChangedEventArgs(Language language) : base()
		{
			this.language = language;
		}

		public Language Language
		{
			get
			{
				return language;
			}
		}
	}
}
