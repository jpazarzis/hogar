using System;
using System.Diagnostics;
using Hogar.BrisPastPerformances;

namespace Hogar.Handicapping
{

    class ChangedStyle : Factor
    {
        public ChangedStyle(int bitpower)
            : base("ChangedStyle",bitpower)
        {
        }

        public override bool AppliesToHorse(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            

            if (horse.IsFirstTimeOut || horse.PastPerformances.Count == 1)
            {
                return false;
            }
            
            int finalPosition = Convert.ToInt32(horse.PastPerformances[0].FinalPosition);
            BrisPastPerformance.RunningStyleType style0 = horse.PastPerformances[0].RunningStyle;

            if (style0 == BrisPastPerformance.RunningStyleType.Presser)
            {
                return false;
            }
            else if (style0 == BrisPastPerformance.RunningStyleType.Unspecified)
            {
                return false;
            }
            if (finalPosition > 2 && style0 != BrisPastPerformance.RunningStyleType.Early)
            {
                return false;
            }

            bool foundAtLeastOnePerformanceWithDiffentStyle = false;

            for (int i = 1; i < horse.PastPerformances.Count; ++i )
            {
                BrisPastPerformance.RunningStyleType style1 = horse.PastPerformances[i].RunningStyle;

                if (style1 == BrisPastPerformance.RunningStyleType.Unspecified ||
                    style1 == BrisPastPerformance.RunningStyleType.Presser)
                {
                    continue; 
                }

                if (style0 == style1)
                {
                    return false;
                }
                else 
                {
                    Debug.Assert(style1 == BrisPastPerformance.RunningStyleType.Early || style1 == BrisPastPerformance.RunningStyleType.Sustained);
                    Debug.Assert(style0 == BrisPastPerformance.RunningStyleType.Early || style0 == BrisPastPerformance.RunningStyleType.Sustained);
                    Debug.Assert(style1 != style0);
                    foundAtLeastOnePerformanceWithDiffentStyle = true;
                }
            }

            return foundAtLeastOnePerformanceWithDiffentStyle;
        }
    }
}
