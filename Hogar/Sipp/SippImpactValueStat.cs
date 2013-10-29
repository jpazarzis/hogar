using System.Collections.Generic;

namespace Sipp
{
    public class SippImpactValueStat
    {
        public string Name { get; set; }
        public int Starters { get; set; }
        public double WinPercentage { get; set; }
        public double Roi { get; set; }
        public double IV { get; set; }
        public override string ToString()
        {
            return string.Format("{0,5:#####} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}", Starters, WinPercentage, Roi, IV);
        }
    }
}