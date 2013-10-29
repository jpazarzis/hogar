using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class Layoff : Factor
    {
        public Layoff(int bitpower)
            : base("Layoff",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            return myhorse.FirstAfterLayoff;
        }
    }
}
