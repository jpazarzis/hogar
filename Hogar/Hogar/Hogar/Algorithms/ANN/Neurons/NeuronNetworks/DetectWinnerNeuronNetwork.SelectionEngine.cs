using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Algorithms.ANN.InputData;
using Hogar.BrisPastPerformances;

namespace Hogar.Algorithms.ANN.Neurons.NeuronNetworks
{
    public partial class DetectWinnerNeuronNetwork
    {
        public void Apply(Race race)
        {
            race.Horses.ForEach(horse => horse.NeuralNetworkOpinion = NeuralNetworkOpinion.NoOpinion);

            var map = new Dictionary<Horse, StarterInfo>();
            List<StarterInfo> starterInfoCollection = race.Horses.Select(horse => CreateStarterInfo(horse, map)).Where(si => null != si).ToList();


            int numberOfHorses = race.Horses.Count(h => h.Scratched == false);

            if (starterInfoCollection.Count <= (numberOfHorses * 0.7))
                return;

            var selections = GetSelections(starterInfoCollection);

            foreach (var horse in map.Keys)
            {
                horse.Votes = map[horse].Votes;
                if (null != selections.Find(si=>si==map[horse]))
                {
                    horse.NeuralNetworkOpinion = NeuralNetworkOpinion.IsABet;
                }
                else
                {
                    horse.NeuralNetworkOpinion = NeuralNetworkOpinion.NotABet;
                }
            }
        }

        private StarterInfo CreateStarterInfo(Horse horse, Dictionary<Horse, StarterInfo> map)
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

            if (dummyStarterInfo.CountPreceding < 3)
                return null;
            map.Add(horse, dummyStarterInfo);
            return dummyStarterInfo;
        }

        private static List<BrisPastPerformance> GetPastPerformancesWithValidGoldenFigures(Horse horse)
        {
            return horse.CorrespondingBrisHorse.PastPerformances.Where
                (pp => pp.GoldenFigureForThisHorse != -999).ToList();
        }

        private List<StarterInfo> GetSelections(List<StarterInfo> starterInfos)
        {
            starterInfos.ForEach(si=>si.Votes=0);
            foreach (var combo in CombinationCalculator<StarterInfo>.GenerateCombinations(starterInfos, _fieldSize))
            {
                var selected = GetWinningNeuron(combo).StarterInfo;
                selected.Votes = selected.Votes + 1;
            }

            StarterInfo hasMoreVotes = null;
            int maxVotes = int.MinValue;

            foreach (var si in starterInfos)
            {
                if (null == hasMoreVotes || si.Votes >= maxVotes)
                {
                    hasMoreVotes = si;
                    maxVotes = si.Votes;
                }
            }

            

            var list = new List<StarterInfo>();

            foreach (var si in starterInfos)
            {
                if (si.Votes >= maxVotes)
                {
                    list.Add(si);
                }
            }

            return list;

        }
    }
}