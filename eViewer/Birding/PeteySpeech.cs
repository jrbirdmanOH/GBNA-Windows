using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class PeteySpeech
	{
		private List<string> lines = new List<string>();

		public PeteySpeech()
		{
		}

		public List<string> Lines
		{
			get
			{
				return lines;
			}
		}

		public static int GetCount(string key)
		{
			return PeteySpeechDM.Instance.GetCount(key);
		}

		public static PeteySpeech GetByID(string key, int id)
		{
			return PeteySpeechDM.Instance.GetSpeech(key, id);
		}
	}
}
