using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.GeneticProgramming
{
    public class DecisionTreeStatistics
    {
        private class SessionData
        {
            private int _totalMatches = 0;
            private int _totalNumberOfSuccesses = 0;
            private int _sampleSize = 0;
            private double _amountCollected = 0;

            public SessionData()
            {
            }

            public SessionData(SessionData other)
            {
                _totalMatches = other._totalMatches;
                _totalNumberOfSuccesses = other._totalNumberOfSuccesses;
                _sampleSize = other._sampleSize;
                _amountCollected = other._amountCollected;
            }

            public void IncreaseAmountCollected(double amount)
            {
                _amountCollected += amount;
            }

            public void IncreaseTotal()
            {
                ++_totalMatches;
            }

            public void IncreaseSuccesses()
            {
                ++_totalNumberOfSuccesses;
            }

            public double SelectionRate
            {
                get
                {
                    return _sampleSize <= 0 ? 0.0 : ((double) _totalMatches)/((double) _sampleSize);
                }
            }

            public int SampleSize
            {
                get
                {
                    return _sampleSize;
                }
                set
                {
                    _sampleSize = value;
                }
            }

            public double SuccessRate
            {
                get
                {
                    return _totalMatches <= 0 ? 0.0 : ((double) _totalNumberOfSuccesses)/((double) _totalMatches);
                }
            }

            public int TotalNumberOfSuccesses
            {
                get
                {
                    return _totalNumberOfSuccesses;
                }
            }

            public int TotalMatches
            {
                get
                {
                    return _totalMatches;
                }
            }

            public double PNL
            {
                get
                {
                    return _amountCollected - _totalMatches*1.0;
                }
            }

            public double ROI
            {
                get
                {
                    return _totalMatches > 0 ? _amountCollected/(_totalMatches*1.0) : 0.0;
                }
            }

            public override string ToString()
            {
                return string.Format("ROI: {0:0.00} SuccessRate: {1:0.00}%", ROI, SuccessRate*100.00);
            }
        }

        private List<SessionData> _sessionData = new List<SessionData>();

        private SessionData _currentSessionData = null;

        internal static DecisionTreeStatistics Make()
        {
            return new DecisionTreeStatistics();
        }

        public DecisionTreeStatistics MakeACopy()
        {
            var newDts = new DecisionTreeStatistics();
            newDts._sessionData.Clear();
            _sessionData.ForEach(sd => newDts._sessionData.Add(new SessionData(sd)));
            return newDts;
        }

        private DecisionTreeStatistics()
        {
            Initialize();
        }

        public void Initialize()
        {
            _sessionData.Clear();
            _currentSessionData = null;
        }

        public void AddSession()
        {
            var sd = new SessionData();
            _sessionData.Add(sd);
            _currentSessionData = sd;
        }

        public void IncreaseAmountCollected(double amount)
        {
            _currentSessionData.IncreaseAmountCollected(amount);
        }

        public double PNL
        {
            get
            {
                return _sessionData.Count <= 0 ? 0.0 : _sessionData.Average(sd => sd.PNL);
            }
        }

        public double ROI_SD
        {
            get
            {
                if (_sessionData.Count < 1)
                {
                    return 0.0;
                }
                
                double mean = 0, stddev = 0;

                foreach (var sessionData in _sessionData)
                {
                    mean += sessionData.ROI;
                    stddev += sessionData.ROI*sessionData.ROI;
                }

                int N = _sessionData.Count+1;

                mean /= N;
                stddev = Math.Sqrt((stddev - _sessionData.Count*mean*mean)/(N - 1));
                return stddev;
            }
        }

        public double ROI
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : _sessionData.Average(sd => sd.ROI);
            }
        }

        public int WinningSessions
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : _sessionData.Count(st => st.ROI >= 1.0);
            }
        }

        public int LoosingSessions
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : _sessionData.Count(st => st.ROI < 1.0);
            }
        }

        public int NumberOfSessions
        {
            get
            {
                return _sessionData.Count;
            }
        }

        public void IncreaseTotal()
        {
            _currentSessionData.IncreaseTotal();
        }

        public void IncreaseSuccesses()
        {
            _currentSessionData.IncreaseSuccesses();
        }

        public double SelectionRate
        {
            get
            {
                return _sessionData.Count <= 0 ? 0.0 : _sessionData.Average(sd => sd.SelectionRate);
            }
        }

        public int SampleSize
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : (int) _sessionData.Sum(sd => sd.SampleSize);
            }
            set
            {
                _currentSessionData.SampleSize = value;
            }
        }

        public double SuccessRate
        {
            get
            {
                return _sessionData.Count <= 0 ? 0.0 : _sessionData.Average(sd => sd.SuccessRate);
            }
        }

        public int TotalNumberOfSuccesses
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : _sessionData.Sum(sd => sd.TotalNumberOfSuccesses);
            }
        }

        public int TotalMatches
        {
            get
            {
                return _sessionData.Count <= 0 ? 0 : _sessionData.Sum(sd => sd.TotalMatches);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(string.Format(@"AVG ROI: {0:0.00} STDEV: {1:0.00}", ROI, ROI_SD));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format(@"SelectionRate: {0:0.00}% ", SelectionRate*100.0));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format(@"SuccessRate: {0:0.00}% ", SuccessRate*100.0));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format(@"Sessions: {0}", NumberOfSessions));
            sb.Append(Environment.NewLine);
            _sessionData.ForEach(sd => sb.Append(sd.ToString() + Environment.NewLine));
            return sb.ToString();
        }
    }
}