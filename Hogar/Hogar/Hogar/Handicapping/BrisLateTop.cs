using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;
using System.Diagnostics;

namespace Hogar.Handicapping
{

    class BrisLateTop : Factor
    {
        public BrisLateTop(int bitpower)
            : base("BrisLateTop",bitpower)
        {
        }

        static int Compare(BrisHorse h1, BrisHorse h2)
        {

            int f1 = h1.BrisLateAvg;
            int f2 = h2.BrisLateAvg;

            if (f1 > f2)
            {
                return -1;
            }
            else if (f1 < f2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (myhorse.Scratched || horse.IsFirstTimeOut || horse.BrisLateAvg <= 0)
            {
                return false;
            }

            List<BrisHorse> list = new List<BrisHorse>();

            foreach (BrisHorse brisHorse in race.Horses)
            {

                Horse h = myhorse.Parent.GetHorseByProgramNumber(brisHorse.ProgramNumber);

                if ( (null != h) && (!h.Scratched) && (brisHorse.BrisLateAvg > 0) && (!brisHorse.IsFirstTimeOut))
                {
                    list.Add(brisHorse);
                }
            }

            list.Sort(Compare);

            if (list.Count < 2)
            {
                return false;
            }

            if (list[0] != horse)
            {
                return false;
            }

            if (list[0].BrisLateAvg == list[1].BrisLateAvg)
            {
                return false;
            }
            else
            {
                Debug.Assert(list[0].BrisLateAvg > list[1].BrisLateAvg);

                return list[0].BrisLateAvg - list[1].BrisLateAvg >= 3;
            }

          
        }
    }
}
