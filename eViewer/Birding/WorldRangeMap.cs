using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
    public class WorldRangeMap
    {
        private int thingID = 0;
        private string link = null;

		public WorldRangeMap()
        {
        }

        public int ThingID
        {
            get
            {
                return thingID;
            }

            set
            {
                thingID = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

		public static WorldRangeMap GetByThingID(int thingID)
        {
            return WorldRangeMapDM.Instance.GetByThingID(thingID);
        }
    }
}
