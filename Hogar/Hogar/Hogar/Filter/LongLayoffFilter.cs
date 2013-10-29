using System;
using Hogar.BrisPastPerformances;

namespace Hogar.Filter
{
    internal class LongLayoffFilter : Filter
    {
        private const string NAME = "Long layoff";

        internal LongLayoffFilter()
            : base(NAME)
        {

        }

        protected override void ApplyToHorse(Horse h)
        {
            BrisHorse horse = h.CorrespondingBrisHorse;
            
            if (horse.IsFirstTimeOut || horse.DaysSinceLastRace < Utilities.LONG_LAYOFF_DAYS)
            {
                return;
            }

            if(horse.TodaysRaceIsMCL || horse.TodaysRaceIsMSW)
            {
                h.IsContenter = false;

                if (horse.Age == 3 && horse.PastPerformances[0].IsMSW && horse.PastPerformances.Count == 1)
                {
                    h.IsContenter = true;
                }
            }
            else if(horse.TodaysRaceIsClaimer)
            {
                if(horse.PastPerformances[0].ClaimingPrice < horse.ClaimingPriceOfTheHorse)
                {
                    h.IsContenter = false;    
                }
            }
            
        }
    }
}