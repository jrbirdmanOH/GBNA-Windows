using System.Collections;

namespace Thayer.Birding
{
	/// <summary>
	/// Summary description for TaxonomyCollection.
	/// </summary>
	public class TaxonomyCollection : CollectionBase
	{
		public TaxonomyCollection()
		{
		}

		public void Add(Taxonomy taxonomy)
		{
			List.Add(taxonomy);
		}
	}
}
