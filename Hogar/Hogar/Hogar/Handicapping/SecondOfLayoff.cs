using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class SecondOfLayoff : Factor
    {
        public SecondOfLayoff(int bitpower)
            : base("SecondOfLayoff", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            return myhorse.SecondAfterLayoff;
        }
    }
}
