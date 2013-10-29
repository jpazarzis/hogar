using System.Collections.Generic;
using System.Linq;

namespace Hogar.FactorStatisticsNew.FactorStatisticsForTrainer
{
    internal static class FactorStatisticsForTrainerManager
    {
        private static Dictionary<string, Dictionary<long, FactorStatistic>> _factorStatsPerTrainer = new Dictionary<string, Dictionary<long, FactorStatistic>>();
        private static Dictionary<string ,FactorStatistic> _globalStatsPerTrainer = new Dictionary<string, FactorStatistic>();
        private static Dictionary<string, FactorStatistic> _globalStatsPerJockey = new Dictionary<string, FactorStatistic>();
        private static Dictionary<string, FactorStatistic> _globalStatsPerTrainerAndJockey = new Dictionary<string, FactorStatistic>();


        static public FactorStatistic GlobalStatisticsPerJockey(string jockeyName)
        {
            if (!_globalStatsPerJockey.ContainsKey(jockeyName))
            {
                LoadJockeyStatsFromDb(jockeyName);
            }

            return _globalStatsPerJockey[jockeyName];
        }

        

        static public FactorStatistic GlobalStatisticsPerTrainerAndJockey(string trainer, string jockey)
        {
            if (!_factorStatsPerTrainer.ContainsKey(trainer))
            {
                LoadTrainerStatsFromDb(trainer);
            }

            string key = MakeTrainerJockeyKey(trainer, jockey);

            return _globalStatsPerTrainerAndJockey.ContainsKey(key) ? _globalStatsPerTrainerAndJockey[key] : FactorStatistic.MakeInvalid();
        }


        static public FactorStatistic GlobalStatisticsPerTrainer(string trainerName)
        {
            if (!_globalStatsPerTrainer.ContainsKey(trainerName))
            {
                LoadTrainerStatsFromDb(trainerName);
            }

            return _globalStatsPerTrainer[trainerName];
        }

        static public FactorStatistic Get(long mask, string trainerName)
        {
            if (!_factorStatsPerTrainer.ContainsKey(trainerName))
            {
                LoadTrainerStatsFromDb(trainerName);
            }

            var fst = _factorStatsPerTrainer[trainerName];

            return null == fst || !fst.ContainsKey(mask) ? null : fst[mask];
        }


        static string MakeTrainerJockeyKey(string trainer, string jockey)
        {
            return trainer.Trim().ToUpper() + jockey.Trim().ToUpper();
        }

        static void LoadJockeyStatsFromDb(string jockeyName)
        {
            var starters = new StarterCollection();
            starters.LoadStartersForJockey(jockeyName);
            var globalStats = new StatisticDataAccumulator();
            globalStats.Initialize();
            starters.ForEach(globalStats.Add);

            if (_globalStatsPerJockey.ContainsKey(jockeyName))
            {
                _globalStatsPerJockey.Remove(jockeyName);
            }

            _globalStatsPerJockey.Add(jockeyName, FactorStatistic.Make(globalStats));

        }

        static void LoadTrainerAndJockeyStats(StarterCollection sc)
        {
            var accumulators = new Dictionary<string, StatisticDataAccumulator>();

            foreach (var starter in sc)
            {
                string key = MakeTrainerJockeyKey(starter.Trainer, starter.Jockey);

                if(!accumulators.ContainsKey(key))
                {
                    accumulators.Add(key, new StatisticDataAccumulator());
                }

                accumulators[key].Add(starter);
            }

            foreach (var key in accumulators.Keys)
            {
                if(_globalStatsPerTrainerAndJockey.ContainsKey(key))
                {
                    _globalStatsPerTrainerAndJockey.Remove(key);
                }

                _globalStatsPerTrainerAndJockey.Add(key, FactorStatistic.Make(accumulators[key]));

            }
        }

        static void LoadTrainerStatsFromDb(string trainer)
        {
            var starters = new StarterCollection();
            starters.LoadStartersForTrainer(trainer);

            LoadTrainerAndJockeyStats(starters);

            var globalStats = new StatisticDataAccumulator();
            globalStats.Initialize();
            starters.ForEach(globalStats.Add);

            if (_globalStatsPerTrainer.ContainsKey(trainer))
            {
                _globalStatsPerTrainer.Remove(trainer);
            }

            _globalStatsPerTrainer.Add(trainer, FactorStatistic.Make(globalStats));
            
            StatisticDataAccumulatorCollection.Singleton.ToList().ForEach(acc=>acc.Initialize());

            foreach (var starter in starters)
            {
                foreach (var accumulator in StatisticDataAccumulatorCollection.Singleton.Where(accumulator => (starter.FactorsFlag & accumulator.BitMask) != 0))
                {
                    accumulator.Add(starter);
                }    
            }

            _factorStatsPerTrainer.Add(trainer, StatisticDataAccumulatorCollection.Singleton.ToDictionary(accumulator => accumulator.BitMask, accumulator => FactorStatistic.Make(accumulator)));
        }
    }
}