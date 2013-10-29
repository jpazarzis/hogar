using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Hogar.Algorithms.ANN.InputData;
using Hogar.BrisPastPerformances;

namespace Hogar.Algorithms.ANN.Neurons.NeuronNetworks
{
    public class MemoryBasedNeuronNetwork
    {
        class Pattern
        {
            public List<double> X { get; set; }
            public double EuclidianDistance { get; set; }

            public void CalculateEuclidianDistances(List<double> v)
            {
                Debug.Assert(X.Count == v.Count);

                double sum = 0;

                for (int i = 0; i < X.Count - 1; ++i )
                {
                    sum += Math.Pow(X[i] - v[i], 2);
                }

                EuclidianDistance = Math.Sqrt(sum);
            }
        }

        readonly List<Pattern> _patterns = new List<Pattern>();

        private readonly int _numberOfPastPerformances;

        private static MemoryBasedNeuronNetwork _singleton;

        static public MemoryBasedNeuronNetwork Make(int count)
        {
            return new MemoryBasedNeuronNetwork(count);
        }

        static List<BrisPastPerformance> GetPastPerformancesWithValidGoldenFigures(Horse horse)
        {
            return horse.CorrespondingBrisHorse.PastPerformances.Where
                (pp => pp.GoldenFigureForThisHorse != -999).ToList();
        }

        static StarterInfo CreateStarterInfo(Horse horse, Dictionary<Horse, StarterInfo> map)
        {
            if (horse.Scratched)
            {
                return null;
            }


            var dummyStarterInfo = new StarterInfo();

            dummyStarterInfo.RacingDate = horse.Parent.Parent.Date;
            dummyStarterInfo.Distance = horse.Parent.CorrespondingBrisRace.DistanceInYards;



            StarterInfo currentStarterInfo = dummyStarterInfo;

            foreach (var pp in GetPastPerformancesWithValidGoldenFigures(horse))
            {
                StarterInfo si = StarterInfo.CreateFromBrisPastPerformance(pp);
                currentStarterInfo.Previous = si;
                si.Next = currentStarterInfo;
                currentStarterInfo = si;
            }

            if (dummyStarterInfo.CountPreceding < 4)
                return null;
            map.Add(horse, dummyStarterInfo);
            return dummyStarterInfo;
        }

        static public void Apply(Race race)
        {
            race.Horses.ForEach(horse => horse.NeuralNetworkOpinion = NeuralNetworkOpinion.NoOpinion);

            var map = new Dictionary<Horse, StarterInfo>();
            List<StarterInfo> starterInfoCollection = race.Horses.Select(horse => CreateStarterInfo(horse, map)).Where(si => null != si).ToList();
            foreach (var horse in map.Keys)
            {
                var si = map[horse];

                if(CheckIfStarterWillImprove(si))
                {
                    horse.NeuralNetworkOpinion = NeuralNetworkOpinion.IsACandiateToImprove;
                }
            }
        }

        static public bool CheckIfStarterWillImprove(StarterInfo si)
        {
            if(null == _singleton)
            {
                _singleton = new MemoryBasedNeuronNetwork(4);
                _singleton.AddTrainingPatterns(StarterInfo.LoadStartersFromFile(@"C:\Users\John\Desktop\neural_network.csv", 4));
            }

            return _singleton.GetOpinion(si) > 0;
        }


        

        protected MemoryBasedNeuronNetwork(int numberOfPastPerformances)
        {
            _numberOfPastPerformances = numberOfPastPerformances;
        }


        public void AddTrainingPatterns(List<StarterInfo> list)
        {
            foreach (var si in list)
            {
                _patterns.Add(new Pattern()
                                  {
                                      X = StarterInfo.NormalizedInputForMemoryLearning(si, _numberOfPastPerformances),
                                      EuclidianDistance = 0.0
                                  });
            }
        }

        static int CompareEuclidianDistances(Pattern p1, Pattern p2)
        {
            if (p1.EuclidianDistance == p2.EuclidianDistance)
                return 0;
            if (p1.EuclidianDistance > p2.EuclidianDistance)
                return 1;
            return -1;

        }

        public double GetOpinion(StarterInfo si)
        {
            if (si.CountPreceding < _numberOfPastPerformances)
                return 0;

            var v1 = StarterInfo.NormalizedInputForMemoryLearning(si, _numberOfPastPerformances);
            _patterns.ForEach(p=>p.CalculateEuclidianDistances(v1));
            _patterns.Sort(CompareEuclidianDistances);

            double positive = 0, negative =0;
            int desiredOutcomeIndex = _patterns[0].X.Count - 1;
            for(int i = 0; i < 2; ++i)
            {
                if(_patterns[i].X[desiredOutcomeIndex] == 1)
                {
                    ++positive;
                }
                else
                {
                    ++negative;
                }
            }

            return positive >0 ? 1.0 : 0.0;
        }

        
    }
}