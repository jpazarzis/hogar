 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class BadLast2 : Factor
    {
        public BadLast2(int bitpower)
            : base("BadLast2",bitpower)
        {
        }

        private bool RunBadlyInRace(List<BrisPastPerformance> pp, int index)
        {

            int finalPosition = Convert.ToInt32(pp[index].FinalPosition.Trim());

            return  (finalPosition == 0 || 
                    (finalPosition > 5 && pp[index].RawFinalCallDistanceFromLeader >= 9));
            
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 
            List<BrisPastPerformance> pp = horse.PastPerformances;
            if (pp.Count <= 1)
            {
                return false;
            }
            else
            {
                return RunBadlyInRace(pp, 0) && RunBadlyInRace(pp, 1);
            }       
        }
    }
}
