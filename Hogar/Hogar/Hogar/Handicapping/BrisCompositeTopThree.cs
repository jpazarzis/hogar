using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class BrisCompositeTopThree : Factor
    {

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


        public BrisCompositeTopThree(int bitpower)
            : base("BrisCompositeTopThree",bitpower)
        {
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

            list.Sort(Compare);

            if(list.Count <=2)
            {
                return true;
            }
            else
            {
                return list[0] == horse || list[1] == horse || list[2] == horse;
            }
        }
    }
}
