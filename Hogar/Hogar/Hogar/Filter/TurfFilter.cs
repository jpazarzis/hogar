using System;
using Hogar.BrisPastPerformances;
using Hogar.SireStats;

namespace Hogar.Filter
{
    internal class TurfFilter : Filter
    {

        private const string NAME = "Turf";

        internal TurfFilter()
            : base(NAME)
        {
            
        }

        
        protected override void ApplyToHorse(Horse horse)
        {
            BrisHorse h = horse.CorrespondingBrisHorse;
            int numberOfTurfStarts = h.NumberOfLifeTimeOfTurf;

            if(numberOfTurfStarts <=1)
            {
                string sireName = h.Sire;
                string damSirename = h.DamSire;

                var sire = Sire.CreateSireFromDb(sireName);
                var damSire = Sire.CreateSireFromDb(damSirename);

                if (null != sire)
                {
                    if (sire.TurfStarters.Contains("F") || sire.TurfStarters.Contains("E") || sire.TurfStarters.Contains("D") || sire.TurfStarters.Contains("B"))
                    {
                        horse.IsContenter = false;
                        return;
                    }

                    if (sire.TurfStarters.Contains("A"))
                    {
                        horse.IsBestBet = true;
                        return;
                    }
                }

                if (null != damSire)
                {
                    if (!damSire.TurfStarters.Contains("A") && !damSire.TurfStarters.Contains("B"))
                    {
                        horse.IsContenter = false;
                        horse.IsBestBet = false;
                    }    
                }
                
            }
            else if (numberOfTurfStarts <= 4 && numberOfTurfStarts >=2)
            {
                if(h.NumberOfLifePlacesOfTurf + h.NumberOfLifeShowsOfTurf + h.NumberOfLifeWinsOfTurf == 0)
                {
                    horse.IsContenter = false;
                    horse.IsBestBet = false;
                }
            }
            
            else
            {
                if (h.NumberOfLifeWinsOfTurf <= 0)
                {
                    horse.IsContenter = false;
                    horse.IsBestBet = false;
                }
            }

        }
       


    }
}