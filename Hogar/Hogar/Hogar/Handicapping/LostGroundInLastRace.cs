using System.Collections.Generic;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class LostGroundInLastRace : Factor
    {
        public LostGroundInLastRace(int bitpower)
            : base("LostGroundInLastRace", bitpower)
        {
        }

        
        public override bool AppliesToHorse(Horse horse)
        {
            if(horse.CorrespondingBrisHorse.IsFirstTimeOut)
            {
                return false;
            }

            var pp = horse.CorrespondingBrisHorse.PastPerformances[0];

            int stretchPosition, finishPosition;
            
            if (!(int.TryParse(pp.StretchCallPosition, out stretchPosition) && int.TryParse(pp.FinalPosition, out finishPosition)))
            {
                return false;
            }

            if (stretchPosition < 2)
            {
                return false;
            }


            if(stretchPosition < finishPosition)
            {
                return true;
            }

            if(stretchPosition > finishPosition)
            {
                return false;
            }

            int stetchLengths, finishLengths;
            if (!(int.TryParse(pp.StretchCallDistanceFromLeader, out stetchLengths) && int.TryParse(pp.FinalCallDistanceFromLeader, out finishLengths)))
            {
                return false;
            }

            return finishLengths < stetchLengths;
            
        }
    }
}