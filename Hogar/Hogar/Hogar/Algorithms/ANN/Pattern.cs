using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Algorithms.ANN.Neurons;

namespace Hogar.Algorithms.ANN
{
    public class Pattern
    {
        private readonly List<double> _dataPoint = new List<double>();
        private readonly List<int> _daysOff = new List<int>();
        private readonly List<int> _finalPosition= new List<int>();
        private readonly List<double> _winPayoff= new List<double>();
        private readonly List<double> _placePayoff= new List<double>();
        private readonly List<double> _showPayoff= new List<double>();
        private readonly List<double> _odds = new List<double>();
        private readonly List<string> _trackCode = new List<string>();

        
    
        
        private double _desiredValue;
        private int _desiredFinalPosition;
        private double _desiredWinPayoff;
        private double _desiredPlacePayoff;
        private double _desiredShowPayoff;
        private double _desiredOdds;
        private string _desiredTrackCode;
        


        private readonly List<double> _normalizedDataPoint = new List<double>();
        private double _normalizedDesiredValue;
        private bool _needsToNormalize = true;

        internal static Pattern Make(Horse horse, int numberOfInputNeurons)
        {
            int numberOfAvailableFigures;
            var p = new Pattern(horse, numberOfInputNeurons, out numberOfAvailableFigures);
            return numberOfAvailableFigures >= numberOfInputNeurons ? p : null;
        }

        internal static Pattern Make(string line, int minNumberOfRacesToConsider)
        {
            string[] s = line.Split(',');

            int minPatternSize = 1 + 7 * minNumberOfRacesToConsider;

            Pattern hp = null;

            if (s.Length >= minPatternSize + 1)
            {
                hp = new Pattern(s, minNumberOfRacesToConsider);
            }

            if (null != hp && hp.CountOfDataPoints <= 0)
                hp = null;

            return hp;
        }

        public Pattern()
        {
        }

        

       


        public bool RandomlySelected { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            _dataPoint.ForEach(v => sb.Append(string.Format("{0:00} ", v)));

            sb.Append("Days off: ");
            _daysOff.ForEach(v => sb.Append(string.Format("{0} ", v)));

            sb.Append(string.Format(" -> ({0:00}) ", DesiredValue));
            sb.Append("Normalized Values: ");

            NormalizedDataPoints.ToList().ForEach(v => sb.Append(string.Format("{0:0.00} ", v)));
            sb.Append(string.Format(" -> ({0:0.00}) ", NormalizedDesiredValue));
            return sb.ToString();
        }

        private Pattern(Horse horse, int numberOfInputNeurons, out int numberOfAvailableFigures)
        {
            HorseName = horse.Name;
            
            numberOfAvailableFigures = 0;

            var listOfFigures = new List<double>();

            foreach (var pp in horse.CorrespondingBrisHorse.PastPerformances)
            {
                if (pp.GoldenFigureForThisHorse > -999)
                    listOfFigures.Add(pp.GoldenFigureForThisHorse);    
            }


            if (numberOfInputNeurons > listOfFigures.Count)
                return;

            for (int i = numberOfInputNeurons - 1; i >=0 ; --i)
            {
                double goldenFigure = listOfFigures[i];
                if(goldenFigure > -999)
                {
                    ++numberOfAvailableFigures;
                    Add((int) goldenFigure);
                    //AddDaysOff(pp[i].DaysSinceLastRace);
                    //AddFinalPosition(Convert.ToInt32(pp[i].FinalPosition));
                    AddPayoffs(0.0, 0.0, 0.0);
                }
            }

            _desiredValue = 0;
            _desiredFinalPosition = 0;
            _desiredWinPayoff = 0;
            _desiredPlacePayoff = 0;
            _desiredShowPayoff = 0;
            _desiredOdds = 0;
            _needsToNormalize = true;
        }

        private Pattern(string[] s, int minNumberOfRacesToConsider)
        {
            HorseName = s[0];
            int pos = 1;

            for (int i = 0; i < s.Length && i < minNumberOfRacesToConsider-1; ++i)
            {
                int figure;

                if (int.TryParse(s[pos++], out figure))
                {
                    Add(figure);
                }

                int daysOff;

                if (int.TryParse(s[pos++], out daysOff))
                {
                    AddDaysOff(daysOff);
                }

                int finalPosition;

                if (int.TryParse(s[pos++], out finalPosition))
                {
                    AddFinalPosition(finalPosition);
                }

                double winPayoff = 0 ,placePayoff = 0,showPayoff = 0;

                double.TryParse(s[pos++], out winPayoff);
                double.TryParse(s[pos++], out placePayoff);
                double.TryParse(s[pos++], out showPayoff);
                AddPayoffs(winPayoff, placePayoff, showPayoff);

                double odds;
                if (double.TryParse(s[pos++], out odds))
                {
                    AddOdds(odds);
                }

                string trackCode = s[pos++];
                AddTrackCode(trackCode);
            }

            double.TryParse(s[pos++], out _desiredValue);
            int daysoff;
            int.TryParse(s[pos++], out daysoff);
            int.TryParse(s[pos++], out _desiredFinalPosition);
            double.TryParse(s[pos++], out _desiredWinPayoff);
            double.TryParse(s[pos++], out _desiredPlacePayoff);
            double.TryParse(s[pos++], out _desiredShowPayoff);
            double.TryParse(s[pos++], out _desiredOdds);
            _desiredTrackCode = s[pos++]; 
            

            _needsToNormalize = true;
        }

        public string HorseName { get; private set; }

        public void AddPayoffs(double winPayoff, double placePayoff, double showPayoff)
        {
            _winPayoff.Add(winPayoff);
            _placePayoff.Add(placePayoff);
            _showPayoff.Add(showPayoff);
        }
        

        public void AddFinalPosition(int finalPosition)
        {
            _finalPosition.Add(finalPosition);
            _needsToNormalize = true;
        }

        public void AddDaysOff(int daysOff)
        {
            _daysOff.Add(daysOff);
            _needsToNormalize = true;
        }

        public void AddOdds(double odds)
        {
            _odds.Add(odds);
        }

        public void AddTrackCode(string trackCode)
        {
            _trackCode.Add(trackCode);
        }

        public void Add(double dataPoint)
        {
            _dataPoint.Add(dataPoint);
            _needsToNormalize = true;
        }

        public double DesiredValue
        {
            get { return _desiredValue; }
        }

        public int DesiredFinalPosition
        {
            get { return _desiredFinalPosition; }
        }

        public double DesiredWinPayoff
        {
            get { return _desiredWinPayoff; }
        }

        public double DesiredPlacePayoff
        {
            get { return _desiredPlacePayoff; }
        }

        public double DesiredShowPayoff
        {
            get { return _desiredShowPayoff; }
        }

        public double DesiredOdds
        {
            get
            {
                return _desiredOdds;
            }
        }

        public string DesiredTrackCode
        {
            get
            {
                return _desiredTrackCode;
            }
        }
        
        public int CountOfDataPoints { get { return _dataPoint.Count; } }


        public IEnumerable<int> FinalPosition
        {
            get
            {
                foreach (var d in _finalPosition)
                {
                    yield return d;
                }
            }
        }

        public IEnumerable<string > TrackCode
        {
            get
            {
                foreach (var s in _trackCode)
                {
                    yield return s;
                }
            }
        }
        
        public IEnumerable<double> Odds
        {
            get
            {
                foreach (var odds in _odds)
                {
                    yield return odds;
                }
            }
        }

        public IEnumerable<int> DaysOff
        {
            get
            {
                foreach (var d in _daysOff)
                {
                    yield return d;
                }
            }
        }


        public IEnumerable<double> DataPoints
        {
            get
            {
                foreach (var d in _dataPoint)
                {
                    yield return d;
                }
            }
        }

        public IEnumerable<double> NormalizedDataPoints
        {
            get
            {
                if (_needsToNormalize)
                    Normalize();

                foreach (var d in _normalizedDataPoint)
                {
                    yield return d;
                }
            }
        }

        public double NormalizedDesiredValue
        {
            get
            {
                if (_needsToNormalize)
                    Normalize();

                return _normalizedDesiredValue;
            }
        }


        public double Denormalize(double y)
        {
            y = 2*y - 1;
            double mean = _dataPoint.Average();
            double variance = _dataPoint.Variance();

            if (mean == 0)
                return 0;

            
            return (-1.0) * y * variance / mean;

        }

        private void Normalize()
        {
            _normalizedDataPoint.Clear();
            _dataPoint.ForEach(t => _normalizedDataPoint.Add(NormalizeValue(t)));
            _normalizedDesiredValue = NormalizeValue(_desiredValue);
        }

        private double NormalizeValue(double x)
        {
            double average = _dataPoint.Average();
            double variance = _dataPoint.Variance();

            if (variance == 0)
                return 0;

            double norm =  x - average / variance;

            if (norm > 1)
                norm = 1;

            if (norm < -1)
                norm = -1;

            return (norm + 1) / 2.0;

        }
    }
}