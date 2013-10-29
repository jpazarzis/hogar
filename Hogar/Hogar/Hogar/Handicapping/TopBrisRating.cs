using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping 
{
    class TopBrisRating: Factor
    {
        public TopBrisRating(int bitpower)
            : base("TopBrisRating",bitpower)
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

            foreach (BrisHorse h in race.Horses)
            {
                if (h.ProgramNumber.Trim().Length > 0)
                {
                    if (null != myhorse.Parent.GetHorseByProgramNumber(h.ProgramNumber))
                    {
                        if (myhorse.Parent.GetHorseByProgramNumber(h.ProgramNumber).Scratched || h == horse)
                        {
                            continue;
                        }
                        else
                        {
                            if (h.BestRating >= horse.BestRating)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;    
        }
    }
}
