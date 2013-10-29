using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;
using Hogar.FactorStatisticsNew.FactorStatisticsForTrainer;

namespace Hogar.FactorStatisticsNew 
{
    public class FactorStatistic : IDbPopulatable 
    {
        public long BitMask { get; private set; }
        public string Name { get; private set; }
        public int Starters { get; private set; }
        public int Winners { get; private set; }
        public double Roi { get; private set; } 
        public double IV { get; private set; }

        public double WinPercent
        {
            get { return Starters > 0 ? 100.0 * (1.0 * Winners) / (1.0 * Starters) : 0.0; }
            
        }

        public override string ToString()
        {
            return string.Format("{0,5:#####} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}", Starters, WinPercent, Roi, IV);
        }


        internal static FactorStatistic MakeInvalid()
        {
            return new FactorStatistic
                       {
                           BitMask = 0,
                           Name = "",
                           Starters = 0,
                           Winners = 0,
                           Roi = 0,
                           IV = 0
                       };
        }

        internal static FactorStatistic Make(StatisticDataAccumulator sda)
        {
            return new FactorStatistic
                       {
                           BitMask = sda.BitMask,
                           Name = sda.Name,
                           Starters = sda.Starters,
                           Winners = sda.Winners,
                           Roi = sda.Roi,
                           IV = sda.IV
                };
        }

        public void Populate(DbReader dbr)
        {
            BitMask = dbr.GetValue<long>("BIT_MASK");
            Name = dbr.GetValue<string>("FACTOR_NAME").Trim();
            Starters = dbr.GetValue<int>("NUMBER_OF_STARTERS");
            Winners = dbr.GetValue<int>("NUMBER_OF_WINNERS");
            Roi  = dbr.GetValue<double>("ROI");
            IV = dbr.GetValue<double>("IV");
        }
    }
}
