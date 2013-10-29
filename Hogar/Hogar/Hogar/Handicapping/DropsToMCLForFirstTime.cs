using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class DropsToMCLForFirstTime : Factor
    {
        public DropsToMCLForFirstTime(int bitpower)
            : base("DropsToMCLForFirstTime",bitpower)
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

            if (!horse.TodaysRaceIsMCL)
            {
                return false;
            }

            foreach (BrisPastPerformance pp in horse.PastPerformances)
            {
                if (pp.IsMCL)
                {
                    return false;
                } 
            }

            return true;
        }
    }
}
