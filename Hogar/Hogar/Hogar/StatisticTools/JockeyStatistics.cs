using System;
using System.Collections.Generic;
using System.Linq;

namespace Hogar.StatisticTools
{
    public class JockeyStatistics
    {
        static Dictionary<string, JockeyStatistics> _jockeyStatistics = new Dictionary<string, JockeyStatistics>();

        public string Name { get; private set; }

        public ImpactValueStat GeneralStats { get; private set; }

        public IEnumerable<ImpactValueStat> AllStats { get; private set; }

        static public JockeyStatistics Get(string name)
        {
            if(!_jockeyStatistics.ContainsKey(name))
            {
                _jockeyStatistics.Add(name,new JockeyStatistics(name));
            }

            return _jockeyStatistics[name];
        }

        private void LoadFromDb()
        {
            var starters = StarterCollection.GetStartersForJockey(Name);

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

        protected JockeyStatistics(string name)
        {
            Name = name;
            LoadFromDb();
        }
    }
}