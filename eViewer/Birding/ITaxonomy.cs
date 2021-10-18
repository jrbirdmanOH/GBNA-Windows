using System.Collections.Generic;

namespace Thayer.Birding
{
	public interface ITaxonomy
	{
		string Caption { get; }
		List<ITaxonomy> Children { get; }
	}
}
