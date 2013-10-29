using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class WillMakeTheLeadEasily : Factor
    {
        public WillMakeTheLeadEasily(int bitpower)
            : base("WillMakeTheLeadEasily",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 
            Race myRace = (Race)myhorse.Parent;

            foreach (BrisHorse h in race.Horses)
            {
                Horse myOtherHorse = myRace.GetHorseByProgramNumber(h.ProgramNumber);

                if (null == myOtherHorse || myOtherHorse.Scratched)
                {
                    continue;
                }

                if (h != horse)
                {
                    if (h.QuirinSpeedPoints >= horse.QuirinSpeedPoints)
                    {
                        return false;
                    }
                }
            }

            return horse.BrisRunStyle.Contains('E');            
        }
    }
}
