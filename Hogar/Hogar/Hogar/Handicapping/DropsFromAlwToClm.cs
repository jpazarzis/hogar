using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    
    internal class DropsFromAlwToClm : Factor
    {
        public DropsFromAlwToClm(int bitpower)
            : base("DropsFromAlwToClm", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse;

            if (horse.IsFirstTimeOut || !horse.TodaysRaceIsClaimer)
            {
                return false;
            }

            return horse.PastPerformances[0].ClaimingPrice == 0.0;
        }
    }
}