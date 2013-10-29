using Hogar.BrisPastPerformances;

namespace Hogar.Filter
{
    internal class LastYearWinningsFilter : Filter
    {
        private const string NAME = "Last Year Winnings";

        internal LastYearWinningsFilter()
            : base(NAME)
        {
            
        }

        
        protected override void ApplyToHorse(Horse horse)
        {
            BrisHorse h = horse.CorrespondingBrisHorse;

            int countStarts = h.CurrentYearStarts < 5 ? h.CurrentYearStarts + h.PreviousYearStarts : h.CurrentYearStarts;
            int countWins = h.CurrentYearStarts < 5 ? h.CurrentYearWins + h.PreviousYearWins : h.CurrentYearWins;
            int countPlaces = h.CurrentYearStarts < 5 ? h.CurrentYearPlaces + h.PreviousYearPlaces : h.CurrentYearPlaces;
            
            if(countStarts >= 5)
            {
                if(countWins >= countStarts * 0.16)
                {
                    return;
                }

                if(countWins + countPlaces >= (countPlaces+countStarts) * 0.22)
                {
                    return;
                }

                horse.IsContenter = false;

            }
        }
         
    }
}