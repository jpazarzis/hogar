using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class ThreeYOAgainstOlder : Factor
    {
        public ThreeYOAgainstOlder(int bitpower)
            : base("ThreeYOAgainstOlder", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            if (myhorse.CorrespondingBrisHorse.Age != 3)
            {
                return false;
            }

            foreach (Horse other in myhorse.Parent.Horses)
            {
                if (other.CorrespondingBrisHorse.Age >= 4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
