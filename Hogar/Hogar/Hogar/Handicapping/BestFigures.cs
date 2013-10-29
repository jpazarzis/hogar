using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{
    class BestFigures : Factor
    {
        public BestFigures(int bitpower) :
            base("BestFigures",bitpower)

        {
        }



        static int CompareBestRating(BrisHorse h1, BrisHorse h2)
        {

            int f1 = h1.BestRating;
            int f2 = h2.BestRating;

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

        static int ComparePowerRating(BrisHorse h1, BrisHorse h2)
        {

            int f1 = h1.PrimePowerRating;
            int f2 = h2.PrimePowerRating;

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



        private bool TopBrisRating(BrisRace race, BrisHorse horse, Horse myhorse)
        {
            if (myhorse.Scratched || horse.IsFirstTimeOut || horse.BestRating <= 0)
            {
                return false;
            }

            List<BrisHorse> list = new List<BrisHorse>();

            foreach (BrisHorse brisHorse in race.Horses)
            {
                Horse h = myhorse.Parent.GetHorseByProgramNumber(brisHorse.ProgramNumber);

                if ((null != h) && (!h.Scratched) && (brisHorse.BestRating > 0))
                {
                    list.Add(brisHorse);
                }
            }

            list.Sort(CompareBestRating);

            if (list.Count <= 2)
            {
                return false;
            }
            else
            {
                return list[0] == horse;
            }
        }

        private bool TopTwoPowerRating(BrisRace race, BrisHorse horse, Horse myhorse)
        {
            if (myhorse.Scratched || horse.IsFirstTimeOut || horse.PrimePowerRating <= 0)
            {
                return false;
            }

            List<BrisHorse> list = new List<BrisHorse>();

            foreach (BrisHorse brisHorse in race.Horses)
            {
                Horse h = myhorse.Parent.GetHorseByProgramNumber(brisHorse.ProgramNumber);

                if ( (null != h) && (!h.Scratched) && (brisHorse.PrimePowerRating > 0))
                {
                    list.Add(brisHorse);
                }
            }

            list.Sort(ComparePowerRating);

            if (list.Count <= 2)
            {
                return false;
            }
            else
            {
                return list[0] == horse || list[1] == horse;
            }
        }


        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            if (myhorse.Scratched || horse.IsFirstTimeOut)
            {
                return false;
            }
         
           return TopBrisRating(race, horse, myhorse) || TopTwoPowerRating(race, horse, myhorse);
           
        }
    }

}
