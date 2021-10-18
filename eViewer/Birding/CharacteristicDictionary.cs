using System.Collections.Generic;

namespace Thayer.Birding
{
	public class CharacteristicDictionary
	{
		private Dictionary<string, CharacteristicCollection> list = new Dictionary<string, CharacteristicCollection>();

		public CharacteristicDictionary()
		{
		}

		public void Add(string characteristic, string value)
		{
			CharacteristicCollection subList = this[characteristic];

			subList.Add(value);
		}

		public Dictionary<string, CharacteristicCollection>.KeyCollection Keys
		{
			get
			{
				return list.Keys;
			}
		}

		public CharacteristicCollection this[string key]
		{
			get
			{
				CharacteristicCollection subList = null;

				if (!list.TryGetValue(key, out subList))
				{
					subList = new CharacteristicCollection();
					list.Add(key, subList);
				}

				return subList;
			}
		}
	}
}
