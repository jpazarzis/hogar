using System.Collections.Generic;
using System.Linq;

namespace Hogar.StatisticTools
{
    public class ImpactValueStat
    {
        internal static ImpactValueStat Make(string statName, IEnumerable<Starter> sc)
        {
            return new ImpactValueStat(statName, sc);
        }

        public void Clear()
        {
            Name = "";
            Starters = 0;
            Winners = 0;
            TotalFieldSize = 0;
            TotalAmountWon = 0;
        }

        public string Name { get; internal set; }

        public int Starters { get; private set; }

        public double WinPercent
        {
            get
            {
                return Starters > 0 ? ((Winners*1.0)/(Starters*1.0))*100.0 : 0;
            }
        }

        public double ROI
        {
            get
            {
                return Starters > 0 ? TotalAmountWon / (Starters*2.0) : 0.0; 
            }
        }

        public double IV
        {
            get
            {
                return Starters <= 0 || TotalFieldSize <= 0 ? 0.0 : ((Winners*1.0)/Starters)/((Starters*1.0)/TotalFieldSize);
            }
        }

        public override string ToString()
        {
            return string.Format("{0,5:#####} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}", Starters, WinPercent, ROI, IV);
        }

        private ImpactValueStat(string statName, IEnumerable<Starter> sc)
        {
            Name = statName;


            sc.ToList().ForEach(AddStarter);
        }

        private int TotalFieldSize { get; set; }

        private double TotalAmountWon { get; set; }

        private int Winners { get; set; }

        private void AddStarter(Starter starter)
        {
            AddStarter(starter.WasTheWinner, starter.WinPayoff, starter.FieldSize);
        }

        private void AddStarter(bool wasTheWinner, double winPayoff, int fieldSize)
        {
            ++Starters;

            if (wasTheWinner)
                ++Winners;

            TotalFieldSize += fieldSize;

            TotalAmountWon += winPayoff;

        }
       
    }
}