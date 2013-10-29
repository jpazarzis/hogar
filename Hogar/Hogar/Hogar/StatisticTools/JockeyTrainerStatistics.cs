using System.Collections.Generic;
using System.Linq;

namespace Hogar.StatisticTools
{
    public class JockeyTrainerStatistics
    {
        static Dictionary<string, JockeyTrainerStatistics> _jockeyTrainerStatistics = new Dictionary<string, JockeyTrainerStatistics>();

        public string Jockey { get; private set; }

        public string Trainer { get; private set; }

        public ImpactValueStat GeneralStats { get; private set; }

        public IEnumerable<ImpactValueStat> AllStats { get; private set; }

        static string MakeKey(string jockey, string trainer)
        {
            return string.Format("{0}-{1}", jockey.Trim(), trainer.Trim()).ToUpper();
        }

        static public JockeyTrainerStatistics Get(string jockey, string trainer)
        {

            string key = MakeKey(jockey, trainer);

            if(!_jockeyTrainerStatistics.ContainsKey(key))
            {
                _jockeyTrainerStatistics.Add(key,new JockeyTrainerStatistics(jockey,trainer));
            }

            return _jockeyTrainerStatistics[key];
        }

        private void LoadFromDb()
        {
            var starters = StarterCollection.GetStartersForJockeyAndTrainer(Jockey,Trainer);

            GeneralStats = ImpactValueStat.Make("General", starters);

            var list = new List<ImpactValueStat>();

            list.Add(GeneralStats);
            list.Add(ImpactValueStat.Make("Favorites", from starter in starters where starter.WasTheFavorite select starter));
            list.Add(ImpactValueStat.Make("Turf", from starter in starters where starter.Turf select starter));
            list.Add(ImpactValueStat.Make("Dirt", from starter in starters where starter.Dirt select starter));
            list.Add(ImpactValueStat.Make("Route", from starter in starters where starter.Route select starter));
            list.Add(ImpactValueStat.Make("Sprint", from starter in starters where starter.Sprint select starter));
            list.Add(ImpactValueStat.Make("3-1 to 5-1", from starter in starters where starter.Odds >=3.0 && starter.Odds < 5 select starter));
            list.Add(ImpactValueStat.Make("5-1 to 10-1", from starter in starters where starter.Odds >= 5.0 && starter.Odds < 10 select starter));
            list.Add(ImpactValueStat.Make("Over 10-1", from starter in starters where starter.Odds >= 10 select starter));

            AllStats = list;

        }

        protected JockeyTrainerStatistics(string jockey, string trainer)
        {
            Jockey = jockey;
            Trainer = trainer;
            LoadFromDb();
        }        
    }
}