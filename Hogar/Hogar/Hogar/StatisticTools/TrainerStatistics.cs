using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.StatisticTools
{
    public class TrainerStatistics
    {
        readonly string _name;
                
        public class PeriodResults
        {
            int _total = 0;
            int _countWinners = 0;
            readonly int _minDaysLayoff = 0;
            readonly int _maxDaysLayoff = 0;

            public int Winners
            {
                get
                {

                    return _countWinners;
                }
            }

            public int Total
            {
                get
                {
                    return _total;
                }
            }

            public int MinLayoff
            {
                get
                {
                    return _minDaysLayoff;
                }
            }

            public int MaxLayoff
            {
                get
                {
                    return _maxDaysLayoff;
                }
            }

            internal PeriodResults(int min, int max)
            {
                _total = 0;
                _countWinners = 0;
                _minDaysLayoff = min;
                _maxDaysLayoff = max;
            }

            internal bool MatchesDaysOff(int daysOff)
            {
                return daysOff >= _minDaysLayoff && daysOff <= _maxDaysLayoff;
            }

            internal void Add(int officialPosition)
            {
                ++_total;
                if (officialPosition == 1)
                {
                    ++_countWinners;
                }
            }
        }

        readonly List<PeriodResults> _results = new List<PeriodResults>();

        internal TrainerStatistics(string name)
        {
            _name = name;
            _results.Add(new PeriodResults(0, 7));
            _results.Add(new PeriodResults(8, 20));
            _results.Add(new PeriodResults(21, 60));
            _results.Add(new PeriodResults(61, 180));
            _results.Add(new PeriodResults(181, 2000));
        }

        public List<PeriodResults> PeriodResulsCollection
        {
            get
            {
                return _results;
            }
        }

        internal void AddStarterInfo(int officialPos, int daysOff)
        {
            foreach (PeriodResults pr in _results)
            {
                if (pr.MatchesDaysOff(daysOff))
                {
                    pr.Add(officialPos);
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
