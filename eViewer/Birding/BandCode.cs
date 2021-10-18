using System.Collections.Generic;
using Thayer.Birding.Data;
using System;

namespace Thayer.Birding
{
	public class BandCode
	{
		private string name;
		private string code;

		public BandCode()
		{
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public string Code
		{
			get
			{
				return code;
			}

			set
			{
				code = value;
			}
		}

		public static BandCode GetByThingID(int thingID)
		{
			return BandCodesDM.Instance.GetByThingID(thingID);
		}
	}
}
