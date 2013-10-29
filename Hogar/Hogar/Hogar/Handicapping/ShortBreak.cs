using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class ShortBreak: Factor
    {
        public ShortBreak(int bitpower)
            : base("ShortBreak", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisHorse horse = myhorse.CorrespondingBrisHorse;
            if (horse.IsFirstTimeOut)
            {
                return false;
            }
            int daysSinceLast = horse.DaysSinceLastRace;
            return daysSinceLast > 0 && daysSinceLast < 7;
        }
    }

}
