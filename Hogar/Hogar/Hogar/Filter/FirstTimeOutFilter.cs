using Hogar.BrisPastPerformances;
using Hogar.SireStats;

namespace Hogar.Filter
{
    internal class FirstTimeOutFilter : Filter
    {

        private const string NAME = "First Time Out";

        internal FirstTimeOutFilter()
            : base(NAME)
        {

        }


        protected override void ApplyToHorse(Horse horse)
        {
            BrisHorse h = horse.CorrespondingBrisHorse;
           

            if(!h.IsFirstTimeOut)
            {
                return;
            }

            
            string sireName = h.Sire;
            string damSirename = h.DamSire;

            var sire = Sire.CreateSireFromDb(sireName);
            var damSire = Sire.CreateSireFromDb(damSirename);

            if (null != sire)
            {
                if (sire.FirstTimeStarters.Contains("F") || sire.FirstTimeStarters.Contains("E") || sire.FirstTimeStarters.Contains("D") || sire.TurfStarters.Contains("C"))
                {
                    horse.IsContenter = false;
                    return;
                }

                if (sire.FirstTimeStarters.Contains("A"))
                {
                    horse.IsBestBet = true;
                    return;
                }
            }

            if (null != damSire)
            {
                if (!damSire.FirstTimeStarters.Contains("A") && !damSire.FirstTimeStarters.Contains("B"))
                {
                    horse.IsContenter = false;
                    horse.IsBestBet = false;
                }
            }

        
        }



    }
}