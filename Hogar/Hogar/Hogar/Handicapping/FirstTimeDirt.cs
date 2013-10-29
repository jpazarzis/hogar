using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class FirstTimeDirt : Factor
    {
        public FirstTimeDirt(int bitpower)
            : base("FirstTimeDirt",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (horse.TodaysRaceIsInTurf || horse.IsFirstTimeOut)
            {
                return false;
            }

            foreach (BrisPastPerformance p in horse.PastPerformances)
            {
                if (p.IsATurfRace == false)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
