using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class FirstTimeSprintToRoute : Factor
    {
        public FirstTimeSprintToRoute(int bitpower)
            : base("FirstTimeSprintToRoute",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (horse.TodaysRaceIsASprint || horse.IsFirstTimeOut)
            {
                return false;
            }

            foreach (BrisPastPerformance p in horse.PastPerformances)
            {
                if (p.IsARoute)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
