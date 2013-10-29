using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class TopPrimePowerOnlyDirt : Factor
    {
        public TopPrimePowerOnlyDirt(int bitpower)
            : base("TopPrimePowerOnlyDirt",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (myhorse.Scratched)
            {
                return false;
            }

            if (horse.TodaysRaceIsInTurf)
            {
                return false;
            }

            int pr = horse.PrimePowerRating;

            Race myRace = myhorse.Parent;

            // TODO Make the find highest prime power in the race faster using a dictionary
            foreach (BrisHorse h in race.Horses)
            {
                if (h.ProgramNumber.Trim().Length > 0)
                {

                    Horse myh = myRace.GetHorseByProgramNumber(h.ProgramNumber);

                    if (null == myh || myh.Scratched || h == horse)
                    {
                        continue;
                    }

                    if (h.PrimePowerRating >= pr)
                    {
                        return false;
                    }
                }
                else
                {
                    // TODO There are some horses (especially in SA) that do not have a program number assigne to them.

                }
            }

            return true;    
        }
    }
}
