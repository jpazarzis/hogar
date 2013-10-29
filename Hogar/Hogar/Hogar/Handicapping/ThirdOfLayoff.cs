using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class ThirdOfLayoff : Factor
    {
        public ThirdOfLayoff(int bitpower)
            : base("ThirdOfLayoff", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            return myhorse.ThirdAfterLayoff;
        }
    }
}
