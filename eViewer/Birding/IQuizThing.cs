using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public interface IQuizThing
	{
		IMediaList Photos { get; }
		IMediaList Sounds { get; }
		IMediaList Videos { get; }
		IMediaList AbundanceMaps { get; }
		IMediaList RangeMaps { get; }
	}
}
