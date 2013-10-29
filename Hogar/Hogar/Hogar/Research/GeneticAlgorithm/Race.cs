using System;
using System.Collections.Generic;

namespace Hogar.Research.GeneticAlgorithm
{
    public class Race
    {
        readonly List<Horse> _horse = new List<Horse>();


        public void AddHorse(long factorsFlag, double winPayoff, double odds)
        {
            _horse.Add(new Horse(factorsFlag,winPayoff,odds));
        }





        internal double CalculateReturn(Solution solution)
        {
            double bankroll = _horse.Count * (1.0);

            double totalWeight = 0.0;
            foreach (var horse in _horse)
            {
                horse.AssignWeight(solution.Weights);
                totalWeight += horse.Weight;
            }

            
            foreach (var horse in _horse)
            {
                if (horse.IsWinner)
                {
                    bankroll = totalWeight / horse.Weight - bankroll;
                }
            }

            return bankroll;
        }

        internal double BetIt(Solution solution, double bankroll, double minPercentAdvantage, ref int numberOfBetsFound)
        {
            double totalWeight = 0;
            foreach (var horse in _horse)
            {
                horse.AssignWeight(solution.Weights);
                totalWeight += horse.Weight;
            }

            double bettingResult = 0.0;

            foreach (var horse in _horse)
            {
                horse.ProbabilityToWin = horse.Weight/totalWeight;

                if(horse.IsOverlayByThisMargin(minPercentAdvantage))
                {
                    double amountToBet = bankroll*minPercentAdvantage;
                    amountToBet = 10;
                    bettingResult = horse.IsWinner ? amountToBet : (-1.0)*amountToBet;
                    if (horse.IsWinner)
                    {
                        ++numberOfBetsFound;
                    }
                    break;
                }
            }

            return bettingResult;

        }

        private void AssignProbabilities(Solution solution)
        {
            _horse.ForEach(horse => horse.AssignWeight(solution.Weights));
            double totalWeight = 0;
            _horse.ForEach(horse => totalWeight += horse.Weight);
            _horse.ForEach(horse=>horse.ProbabilityToWin = horse.Weight / totalWeight);
        }

        public void UpdatePartitions(Solution solution)
        {
            AssignProbabilities(solution);
            _horse.ForEach(h =>
                               {
                                   if (h.IsWinner)
                                       solution.Partitions[h.Weight].IncreaseWinners();
                                   else
                                       solution.Partitions[h.Weight].IncreaseCount();
                               }
                            );
        }
    }
}