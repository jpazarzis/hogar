using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class TopAvgBrisClassRating : Factor
    {
        public TopAvgBrisClassRating(int bitpower)
            : base("TopAvgBrisClassRating",bitpower)
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

            if (horse.BrisAvgClassRatingLastThree < 0)
            {
                return false;
            }

            foreach (BrisHorse h in race.Horses)
            {
                if (h.ProgramNumber.Trim().Length > 0)
                {
                    if (myhorse.Parent.GetHorseByProgramNumber(h.ProgramNumber).Scratched || h == horse)
                    {
                        continue;
                    }
                    else
                    {
                        if (h.BrisAvgClassRatingLastThree+1 >= horse.BrisAvgClassRatingLastThree)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;    
             
        }
    }
}
