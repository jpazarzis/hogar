using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class DoubleMove : Factor
    {
        public DoubleMove(int bitpower)
            : base("DoubleMove", bitpower)
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
            else
            {
                return horse.PastPerformances[0].IsDoubleMove;
            }

        }
    }
}
