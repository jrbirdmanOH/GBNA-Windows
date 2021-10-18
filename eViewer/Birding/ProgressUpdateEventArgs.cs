using System;

namespace Thayer.Birding
{
	public class ProgressUpdateEventArgs : EventArgs
	{
		private string taskDescription = string.Empty;
		private int percentComplete = 0;

		public ProgressUpdateEventArgs(int percentComplete)
		{
			this.percentComplete = percentComplete;
		}

		public ProgressUpdateEventArgs(string taskDescription, int percentComplete)
		{
			this.taskDescription = taskDescription;
			this.percentComplete = percentComplete;
		}

		public string TaskDescription
		{
			get
			{
				return taskDescription;
			}

			set
			{
				taskDescription = value;
			}
		}

		public int PercentComplete
		{
			get
			{
				return percentComplete;
			}

			set
			{
				percentComplete = value;
			}
		}
	}
}
