using System;
using Hogar.DbTools;

namespace Hogar.FactorStatisticsNew.FactorStatisticsForTrainer
{
    class StatisticDataAccumulator: IDbPopulatable
    {
        public long BitMask { get; private set; }
        public string Name { get; private set; }
        public int Starters { get; set; }
        public int Winners { get; set; }
        public int TotalFieldSize { get; set; }
        public double TotalWinPayoff { get; set; }

        public double Roi
        {
            get { return Starters <= 0 ? 0.0 : TotalWinPayoff/(2.0*Starters); }
        }

        public double IV
        {
            get { return Starters <= 0 || TotalFieldSize <= 0 ? 0.0 : ((1.0*Winners)/(1.0*Starters))/((1.0*Starters)/(1.0*TotalFieldSize)); }
        }

        public void Add(Starter s)
        {
            ++Starters;

            if(s.WinPayoff > 0)
            {
                ++Winners;
                TotalWinPayoff += s.WinPayoff;
            }

            TotalFieldSize += s.FieldSize;
        }

        public StatisticDataAccumulator()
        {
            Initialize();
        }

        public void Initialize()
        {
            Starters = Winners = TotalFieldSize = 0;
            TotalWinPayoff = 0.0;
        }

        public void Populate(DbReader dbr)
        {
            BitMask = dbr.GetValue<long>("BIT_MASK");
            Name = dbr.GetValue<string>("FACTOR_NAME");
            
            Starters = Winners = TotalFieldSize = 0;
            TotalWinPayoff = 0.0;
        }
    }
}