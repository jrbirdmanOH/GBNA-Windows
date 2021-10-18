using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
    public class AnimatedRangeMap
    {
        private int thingID = 0;
        private string link = null;

        public AnimatedRangeMap()
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

        public static AnimatedRangeMap GetByThingID(int thingID)
        {
            return AnimatedRangeMapDM.Instance.GetByThingID(thingID);
        }
    }
}
