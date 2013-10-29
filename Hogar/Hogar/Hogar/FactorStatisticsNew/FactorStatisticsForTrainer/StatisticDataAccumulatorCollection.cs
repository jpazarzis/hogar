using Hogar.DbTools;

namespace Hogar.FactorStatisticsNew.FactorStatisticsForTrainer
{
    sealed class StatisticDataAccumulatorCollection: DataBaseCollection<StatisticDataAccumulator>
    {
        private static StatisticDataAccumulatorCollection _singleton;

        static public StatisticDataAccumulatorCollection Singleton
        {
            get
            {
                return _singleton ?? (_singleton = new StatisticDataAccumulatorCollection());
            }
        }


        private StatisticDataAccumulatorCollection()
        {
            Load(@"SELECT BIT_MASK,FACTOR_NAME FROM FACTOR_NAME");
        }
    }
}