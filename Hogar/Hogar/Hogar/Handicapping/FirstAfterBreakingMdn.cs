using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class FirstAfterBreakingMdn : Factor
    {
        public FirstAfterBreakingMdn(int bitpower)
            : base("FirstAfterBreakingMdn",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (horse.IsFirstTimeOut)
            {
                return false;
            }
            else if (horse.PastPerformances[0].WasTheWinner)
            {
                return horse.NumberOfLifeTimeWins == 1;
            }
            else
            {
                return false;
            }
        }
    }
}
