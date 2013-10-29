using System;
using System.Collections.Generic;
using System.Linq;
using Hogar.DbTools;
using Hogar.FactorStatisticsNew.FactorStatisticsForTrainer;

namespace Hogar.FactorStatisticsNew
{
    static public class FactorStatisticManager
    {
        private static Dictionary<long, FactorStatistic> _pool = null;

        static public FactorStatistic GlobalStatisticsPerTrainerAndJockey(string trainer, string jockey)
        {
            return FactorStatisticsForTrainerManager.GlobalStatisticsPerTrainerAndJockey(trainer,jockey);
        }

        static public FactorStatistic GlobalStatisticsPerTrainer(string trainerName)
        {
            return FactorStatisticsForTrainerManager.GlobalStatisticsPerTrainer(trainerName);
        }

         static public FactorStatistic GlobalStatisticsPerJockey(string jockeyName)
         {
             return FactorStatisticsForTrainerManager.GlobalStatisticsPerJockey(jockeyName);
         }

        static public FactorStatistic Get(long mask)
        {
            var pool = Pool;

            return null != pool && pool.ContainsKey(mask) ? pool[mask] : null;
        }

        static public FactorStatistic Get(long mask, string trainerName)
        {
            return FactorStatisticsForTrainerManager.Get(mask, trainerName);
        }

        static public Dictionary<long, FactorStatistic> Pool
        {
            get
            {
                if (null == _pool)
                {
                    LoadFromDb();    
                }

                return _pool;
            }
        }

        static private void LoadFromDb()
        {
            _pool = new Dictionary<long, FactorStatistic>();
            var collection = new DataBaseCollection<FactorStatistic>();
            collection.Load(@"select BIT_MASK, FACTOR_NAME, NUMBER_OF_STARTERS, NUMBER_OF_WINNERS, ROI, IV from FACTOR_NAME");
            collection.ForEach(fs => _pool.Add(fs.BitMask, fs));
        }
    }
}