using System;
using Hogar.BrisPastPerformances;
using Hogar.SireStats;

namespace Hogar.Filter
{
    internal class MuddyTrackFilter : Filter
    {
        private const string NAME = "Muddy Track";

        internal MuddyTrackFilter()
            : base(NAME)
        {
            
        }

        protected override void ApplyToHorse(Horse horse)
        {
            BrisHorse h = horse.CorrespondingBrisHorse;
            

            if (h.NumberOfLifeTimeOnWet <= 0)
            {
                string sireName = h.Sire;
                string damSirename = h.DamSire;

                var sire = Sire.CreateSireFromDb(sireName);
                var damSire = Sire.CreateSireFromDb(damSirename);

                if (null == sire && null == damSire) return;

                if (null != sire)
                {
                    if (sire.MudStarters.Contains("F") || sire.MudStarters.Contains("E") || sire.MudStarters.Contains("D"))
                    {
                        horse.IsContenter = false;

                    }
                    else if (sire.MudStarters.Contains("A"))
                    {
                        horse.IsBestBet = true;
                        return;
                    }
                }

                if (null != damSire)
                {
                    if (!damSire.MudStarters.Contains("A") && !damSire.MudStarters.Contains("B"))
                    {
                        horse.IsContenter = false;
                        horse.IsBestBet = false;
                    }    
                }
                
            }
            else if (h.NumberOfLifeTimeOnWet < 3)
            {
                if (h.NumberOfLifePlacesOfWet + h.NumberOfLifeShowsOfWet + h.NumberOfLifeWinsOfWet== 0)
                {
                    horse.IsContenter = false;
                    horse.IsBestBet = false;
                }
            }
            else
            {
                if (h.NumberOfLifeWinsOfWet <= 0)
                {
                    horse.IsContenter = false;
                    horse.IsBestBet = false;
                }
            }

        }

       
    }
}