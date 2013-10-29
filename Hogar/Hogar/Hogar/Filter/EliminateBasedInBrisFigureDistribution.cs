using System.Linq;
using Hogar.BrisPastPerformances;

namespace Hogar.Filter
{
    internal class EliminateBasedInBrisFigureDistribution: Filter
    {
        private const string NAME = "EliminateBasedInBrisFigureDistribution";

        internal EliminateBasedInBrisFigureDistribution()
            : base(NAME)
        {

        }

        protected override void ApplyToHorse(Horse h)
        {
            h.IsDonkey = false;

            BrisHorse horse = h.CorrespondingBrisHorse;
            var figures = horse.Parent.GetBrisSpeedFiguresForRecentFormCycles();
            double average = figures.Count > 0 ? figures.Average() : 0;
            double stddev = figures.Count > 0 ? Hogar.Utilities.CalculateStdDev(figures) : 0;
            double cutoff = average + stddev;

            //if(horse.PastPerformances.Count < 3)
              //  return;


            
            if (!horse.GetBrisSpeedFiguresForRecentFormCycles().Any(pp => pp >= cutoff))
            {
               h.IsDonkey = true;
            }
        }        
    }
}