using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class TopThreeAvgBrisClassRating : Factor
    {
        public TopThreeAvgBrisClassRating(int bitpower)
            : base("TopThreeAvgBrisClassRating",bitpower)
        {
        }

        static int Compare(BrisHorse h1, BrisHorse h2)
        {

            double f1 = h1.BrisAvgClassRatingLastThree;
            double f2 = h2.BrisAvgClassRatingLastThree;

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

            if (horse.BrisAvgClassRatingLastThree < 0)
            {
                return false;
            }

            List<BrisHorse> list = new List<BrisHorse>();

            foreach (BrisHorse brisHorse in race.Horses)
            {
                Horse h = myhorse.Parent.GetHorseByProgramNumber(brisHorse.ProgramNumber);

                if ((null != h) && (!h.Scratched) && (brisHorse.BrisCompositeLastThree > 0))
                {
                    list.Add(brisHorse);
                }
            }

            list.Sort(Compare);

            if (list.Count <= 2)
            {
                return true;
            }
            else
            {
                if (list[0] == horse || list[1] == horse)
                {
                    return list[1].BrisAvgClassRatingLastThree > list[2].BrisAvgClassRatingLastThree + 2.0;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
