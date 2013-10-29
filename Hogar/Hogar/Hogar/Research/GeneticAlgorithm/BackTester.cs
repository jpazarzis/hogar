using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    public class BackTester
    {
        private readonly Solution _solution;

        private double _bankroll;
        private readonly int _numberOfRaces;
        private readonly int _minAdvantage;
        private int _numberOfBetsFound = 0;

        public BackTester(Solution s, double bankroll, int numberOfRaces, int minAdvantage)
        {
            _solution = s;
            _bankroll = bankroll;
            _numberOfRaces = numberOfRaces;
            _minAdvantage = minAdvantage;
        }

        public double Bankroll 
        { 
            get
            {
                return _bankroll;
            }
        }

        public int NumberOfBetsFound
        {
            get
            {
                return _numberOfBetsFound;
            }
        }

        public void Run()
        {
            var rc = new RaceCollection(_numberOfRaces);
            _numberOfBetsFound = 0;
            double advantage = ((double) _minAdvantage)/100.0;

            foreach (var race in rc.Races)
            {
                _bankroll += race.BetIt(_solution, _bankroll, advantage, ref _numberOfBetsFound);
            }
        }
    }
}
