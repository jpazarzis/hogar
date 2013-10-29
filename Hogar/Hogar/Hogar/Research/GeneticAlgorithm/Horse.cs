using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    class Horse
    {
        private readonly bool _isWinner;

        private readonly long _factorsFlag;

        private double _weight = 0.0;

        private readonly double _odds;

        private double _probabilityToWin = 0.0;

        public Horse(long factorsFlag, double winPayoff, double odds)
        {
            _factorsFlag = factorsFlag;
            _isWinner = winPayoff > 0.0;
            _odds = odds;
        }

        internal void AssignWeight(List<double > weights)
        {
            _weight = 0.0;

            for (int i = 0; i < weights.Count; ++i)
            {
                if(IsMatchingFactor(i))
                {
                    _weight += weights[i];
                }
            }
        }

        internal double ProbabilityToWin 
        { 
            get
            {
                return _probabilityToWin;
            }
            set
            {
                _probabilityToWin = value;
            }
        }
        

        internal bool IsOverlayByThisMargin(double margin)
        {
            if (_odds <= 0) return false;

            double percentBasedInOdds = 1.0/(_odds + 1.0);

            return _probabilityToWin - percentBasedInOdds >= margin;

        }

        internal double Weight
        {
            get
            {
                return _weight;
            }
        }

        internal double Odds
        {
            get
            {
                return _odds;
            }
        }


        private static long PowerOf2(int power)
        {
            long p = 1;
            const long v = 2;
            for(int i =0; i < power; ++i)
            {
                p *= v;
            }
            return p;
        }

        // index will range from 0 - 63 so to get the corresponding flag add 1
        public bool IsMatchingFactor(int index)
        {
            if(index == 0)
            {
                // index 0 by defauly corresponds to HasNoFactors 
                return _factorsFlag == (long)0;
            }
            else
            {
                long p = PowerOf2(index);
                return (_factorsFlag & p) == p;    
            }
        }

     

        public bool IsWinner 
        { 
            get
            {
                return _isWinner;
            }
        }
    }
}
