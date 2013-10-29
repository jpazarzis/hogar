using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class UpInClaimingPriceAfterClaimWin : Factor
    {
        public UpInClaimingPriceAfterClaimWin(int bitpower)
            : base("UpInClaimingPriceAfterClaimWin",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (horse.IsFirstTimeOut|| false == horse.TodaysRaceIsClaimer)
            {
                return false;
            }

            if (!horse.PastPerformances[0].WasTheWinner || horse.PastPerformances[0].ClaimingPrice == 0.0)
            {
                return false;
            }

            return horse.ClaimingPriceOfTheHorse > horse.PastPerformances[0].ClaimingPrice;
        }
    }
}
