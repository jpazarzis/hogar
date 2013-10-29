using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class OlderMaiden : Factor
    {
        public OlderMaiden(int bitpower)
            : base("OlderMaiden",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisHorse horse = myhorse.CorrespondingBrisHorse;
            return horse.NumberOfLifeTimeWins >= 1 ? false : horse.Age >= 5;
        }
    }
}
