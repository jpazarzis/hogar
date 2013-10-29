using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class LongLayoff : Factor
    {
        public LongLayoff(int bitpower)
            : base("LongLayoff",bitpower)
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
            return daysSinceLast >= Utilities.LONG_LAYOFF_DAYS;
        }
    }
}
