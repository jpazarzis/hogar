using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class ComingFromBigWin : Factor
    {
        static double LENGTHS_CONSIDERED_AS_BIG_WIN = 3.0;

        public ComingFromBigWin(int bitpower)
            : base("ComingFromBigWin", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            try
            {
                List<BrisPastPerformance> pp = horse.PastPerformances;

                if (pp.Count <= 0)
                {
                    return false;
                }
                else
                {
                    int finalPosition = Convert.ToInt32(pp[0].FinalPosition.Trim());

                    if (finalPosition == 1 && pp[0].RawFinalCallDistanceFromLeader > LENGTHS_CONSIDERED_AS_BIG_WIN)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
