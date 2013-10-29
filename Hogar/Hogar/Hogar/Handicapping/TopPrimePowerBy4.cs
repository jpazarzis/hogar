using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;


namespace Hogar.Handicapping
{
    class TopPrimePowerBy4 : Factor
    {
        public TopPrimePowerBy4(int bitpower)
            : base("TopPrimePowerBy4",bitpower)
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

            int pr = horse.PrimePowerRating - 4;
            Race myRace = myhorse.Parent;

            // TODO Make the find highest prime power in the race faster using a dictionary
            foreach (BrisHorse h in race.Horses)
            {
                Horse myh = myRace.GetHorseByProgramNumber(h.ProgramNumber);

                if (myh.Scratched || h == horse)
                {
                    continue;
                }

                if (h.PrimePowerRating >= pr)
                {
                    return false;
                }
            }

            return true;    
        }
    }
    
}
