using System;

namespace Thayer.Birding.Updates
{
	public class DownloadCompletedEventArgs : EventArgs
	{
		private bool cancelled = false;

		public DownloadCompletedEventArgs()
		{
		}

		public DownloadCompletedEventArgs(bool cancelled)
		{
			this.cancelled = cancelled;
		}

		public bool Cancelled
		{
			get
			{
				return cancelled;
			}
		}
	}
}
