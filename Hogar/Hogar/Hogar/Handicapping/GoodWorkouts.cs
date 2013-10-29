using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class GoodWorkouts : Factor
    {
        public GoodWorkouts(int bitpower)
            : base("GoodWorkouts",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            return myhorse.CorrespondingBrisHorse.HasGoodWorkouts;
        }
    }
}
