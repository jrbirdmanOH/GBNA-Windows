using System;

namespace Thayer.Birding.Updates
{
	public class FileInstallingEventArgs : EventArgs
	{
		private string fileName;
		private int percentComplete;

		public FileInstallingEventArgs(string fileName, int fileIndex, int numFiles)
		{
			this.fileName = fileName;
			if (numFiles == 0)
			{
				this.percentComplete = -1;
			}
			else
			{
				this.percentComplete = (int)(fileIndex * 100.0 / numFiles);
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
