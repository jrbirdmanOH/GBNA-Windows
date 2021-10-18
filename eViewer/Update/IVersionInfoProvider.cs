using System;

namespace Thayer.Birding.Updates
{
	public interface IVersionInfoProvider
	{
		string GetVersion(string fileName);
	}
}
