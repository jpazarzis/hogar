using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class FirstTimeTurf : Factor
    {
        public FirstTimeTurf(int bitpower)
            : base("FirstTimeTurf",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 
            if (false == horse.TodaysRaceIsInTurf || horse.IsFirstTimeOut)
            {
                return false;
            }

            foreach (BrisPastPerformance p in horse.PastPerformances)
            {
                if (p.IsATurfRace)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
