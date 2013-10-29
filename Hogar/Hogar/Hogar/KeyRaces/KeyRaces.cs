using System;
using System.Collections.Generic;
using Hogar.BrisPastPerformances;

namespace Hogar.KeyRaces
{
    
    sealed public class KeyRaces
    {
        readonly Dictionary<Horse, List<RaceInfo>>  _graph = new Dictionary<Horse, List<RaceInfo>>();
        readonly List<RaceInfo> _races = new List<RaceInfo>();

        static public KeyRaces Make(Race race)
        {
            return new KeyRaces(race);
        }

        

        public Dictionary<Horse, List<RaceInfo>> Graph
        {
            get
            {
                return _graph;
            }
        }

        public IEnumerable<Horse> Horses
        {
            get
            {
                foreach (var horse in _graph.Keys)
                {
                    yield return horse;
                }
            }
        }

        public List<RaceInfo> Races
        {
            get
            {
                return _races;
            }
        }

        private KeyRaces(Race race)
        {
            CreateGraph(race);         
        }

        private void CreateGraph(Race race)
        {
            _graph.Clear();
            _races.Clear();

            foreach (var horse in race.Horses)
            {
                if(horse.Scratched)
                    continue;

                foreach (var pp in horse.CorrespondingBrisHorse.PastPerformances)
                {
                    AddRaceInfoToGraph(horse, GetRaceInfo(pp));
                }               
            }

            _races.ForEach(r=>r.Matches=0);

            foreach (var horse in _graph.Keys)
            {
                foreach (var ri in _graph[horse])
                {
                    ++ri.Matches;
                }
            }
        }

        private void AddRaceInfoToGraph(Horse horse, RaceInfo raceInfo)
        {
            if(!_graph.ContainsKey(horse))
            {
                _graph.Add(horse,new List<RaceInfo>());
            }

            _graph[horse].Add(raceInfo);
        }

        private RaceInfo GetRaceInfo(BrisPastPerformance pp)
        {
            var newRaceInfo = RaceInfo.Make(pp);
            newRaceInfo.AddPastPerformance(pp);

            var existingRaceInfo = _races.Find(ri => ri.ToString() == newRaceInfo.ToString());

            if (null != existingRaceInfo)
            {
                existingRaceInfo.AddPastPerformance(pp);
                return existingRaceInfo;
            }
                
            else
            {
                _races.Add(newRaceInfo);
                return newRaceInfo;
            }           
        }
    }
}