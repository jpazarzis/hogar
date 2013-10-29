using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class BrisTopClassAndRaceRating : Factor
    {
        public BrisTopClassAndRaceRating(int bitpower)
            : base("BrisTopClassAndRaceRating",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            if (myhorse == null)
            {
                return false;
            }
            else
            {
                BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
                
                if (null == race)
                {
                    return false;
                }

                return myhorse.CorrespondingBrisHorse == race.BrisTopClassAndRaceRating;
            }
        }
    }
}
