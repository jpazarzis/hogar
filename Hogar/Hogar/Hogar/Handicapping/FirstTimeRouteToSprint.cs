using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    
    class FirstTimeRouteToSprint : Factor
    {
        public FirstTimeRouteToSprint(int bitpower)
            : base("FirstTimeRouteToSprint",bitpower)
        {
        }


        // Returns true for a horse running a sprint for first time while 
        // he is not an FTS
        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (horse.TodaysRaceIsARoute || horse.IsFirstTimeOut)
            {
                return false;
            }

            

            foreach (BrisPastPerformance p in horse.PastPerformances)
            {
                if (p.IsASprint)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
