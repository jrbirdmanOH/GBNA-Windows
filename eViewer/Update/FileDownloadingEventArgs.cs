using System;

namespace Thayer.Birding.Updates
{
	public class FileDownloadingEventArgs : EventArgs
	{
		private string fileName;
		private int percentComplete;

		public FileDownloadingEventArgs(string fileName, long bytesRead, long totalBytes)
		{
			this.fileName = fileName;
			if (totalBytes == 0)
			{
				this.percentComplete = -1;
			}
			else
			{
				this.percentComplete = (int)(bytesRead * 100.0 / totalBytes);
			}
		}

		public string FileName
		{
			get
			{
				return fileName;
			}
		}

		public int PercentComplete
		{
			get
			{
				return percentComplete;
			}
		}
	}
}
