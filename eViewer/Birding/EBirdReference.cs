using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
    public class EBirdReference
    {
        private int thingID = 0;
        private string taxonCode = null;

        public EBirdReference()
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

        public string TaxonCode
        {
            get
            {
                return taxonCode;
            }

            set
            {
				taxonCode = value;
            }
        }

        public static EBirdReference GetByThingID(int thingID)
        {
            return EBirdReferenceDM.Instance.GetByThingID(thingID);
        }
    }
}
