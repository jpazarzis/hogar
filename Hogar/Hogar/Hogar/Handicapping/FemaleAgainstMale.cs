using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class FemaleAgainstMale : Factor
    {
        public FemaleAgainstMale(int bitpower)
            : base("FemaleAgainstMale", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            

            if (myhorse.CorrespondingBrisHorse.Sex != BrisHorse.HorseSex.Female)
            {
                return false;
            }

            foreach (Horse other in myhorse.Parent.Horses)
            {
                if (other.CorrespondingBrisHorse.Sex == BrisHorse.HorseSex.Male)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
