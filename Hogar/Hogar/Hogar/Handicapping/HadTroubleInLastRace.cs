using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
   

    class HadTroubleInLastRace : Factor
    {
        static string[] KEYWORDS = {"Steadied",
                                    "Bobbled",
                                    "Stumbled",
                                    "Drifted",
                                    "Drftd",
                                    "bumped",
                                    "Awkward",
                                    "Off Slowly",
                                    "Slow Start",
                                    "duel"};

        public HadTroubleInLastRace(int bitpower)
            : base("HadTroubleInLastRace",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race= myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            List<BrisPastPerformance> pp = horse.PastPerformances;

            if (pp.Count <= 1)
            {
                return false;
            }
            else
            {
                string s = horse.PastPerformances[0].TripComment.Trim();


                if (s.Length <= 0)
                {
                    return false;
                }

                foreach (string keyword in KEYWORDS)
                {
                    if (s.Contains(keyword))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
