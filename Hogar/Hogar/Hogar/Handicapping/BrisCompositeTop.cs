using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;
using System.Diagnostics;

namespace Hogar.Handicapping
{

    class BrisCompositeTop : Factor
    {
        public BrisCompositeTop(int bitpower)
            : base("BrisCompositeTop",bitpower)
        {
        }

        static int Compare(BrisHorse h1, BrisHorse h2)
        {

            int f1 = h1.BrisCompositeLastThree;
            int f2 = h2.BrisCompositeLastThree;

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

            if (myhorse.Scratched || horse.IsFirstTimeOut || horse.BrisCompositeLastThree <= 0)
            {
                return false;
            }

            
            List<BrisHorse> list = new List<BrisHorse>();

            foreach (BrisHorse brisHorse in race.Horses)
            {
                Horse h = myhorse.Parent.GetHorseByProgramNumber(brisHorse.ProgramNumber);

                if ( (null != h) && (!h.Scratched) && (brisHorse.BrisCompositeLastThree > 0))
                {
                    list.Add(brisHorse);
                }
            }

            if (list.Count <= 1)
            {
                return false;
            }

            list.Sort(Compare);

            if (list[0] != horse)
            {
                return false;
            }
            else if (list[0].BrisCompositeLastThree == list[1].BrisCompositeLastThree)
            {
                return false;
            }
            else
            {
                Debug.Assert(list[0].BrisCompositeLastThree > list[1].BrisCompositeLastThree);
                return list[0].BrisCompositeLastThree - list[1].BrisCompositeLastThree >= 4;
            }

            
        }
    }
}
