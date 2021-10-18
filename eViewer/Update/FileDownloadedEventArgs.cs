using System;

namespace Thayer.Birding.Updates
{
	public class FileDownloadedEventArgs : EventArgs
	{
		private string fileName;

		public FileDownloadedEventArgs(string fileName)
		{
			this.fileName = fileName;
		}

		public string FileName
		{
			get
			{
				return fileName;
			}
		}
	}
}
