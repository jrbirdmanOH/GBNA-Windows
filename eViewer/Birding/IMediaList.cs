using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public interface IMediaList : IList<IMedia>
	{
		IMedia GetByMediaID(int mediaID, bool isCustom);
		IMedia[] ToArray();
	}
}
