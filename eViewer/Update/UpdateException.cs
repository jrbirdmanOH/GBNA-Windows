using System;

namespace Thayer.Birding.Updates
{
	public class UpdateException : ApplicationException
	{
		public UpdateException(string message)
			: base(message)
		{
		}
	}
}
