using System;
using System.Collections.Generic;



namespace Hogar.StatisticTools
{
    // Tranforms figures to probabilities
    // Developed based in cosmic instructions
    // Please note that this class is assuming that a larger figure 
    // is better than a smaller....

    public class FiguresToProbabilities
    {
        List<double> _figure = new List<double>();
        double _raceConstant = 0;


        public List<double> Calculate(List<double> figures, double raceConstant)
        {
            if (raceConstant <= 0)
            {
                throw new Exception("Race Constant has to be larger than 0");
            }

            for (int i = 0; i < figures.Count; ++i)
            {
               
                figures[i] = figures[i];
            }

            CopyFigures(_figure, figures);
            _raceConstant = raceConstant;
            Transform();
            ConvertToExps();
            ConvertToPercentages();

            return CopyFigures(null, _figure);
        }

        void ConvertToPercentages()
        {
            double sum = FiguresSum;

            if (sum != 0)
            {
                for (int i = 0; i < _figure.Count; ++i)
                {
                    _figure[i] = _figure[i] / sum;
                }
            }
        }

        void ConvertToExps()
        {
            for (int i = 0; i < _figure.Count; ++i)
            {
                _figure[i] = (_figure[i] == 0.00) ? 1 : Math.Exp((1) * (_figure[i]) / _raceConstant);
            }
        }

        void Transform()
        {
            double max = MaximumValue;

            if (max != 0.0)
            {
                for (int i = 0; i < _figure.Count; ++i)
                {
                    _figure[i] = _figure[i] - max;
                }
            }
        }

        private double MaximumValue
        {
            get
            {
                if (_figure.Count == 0)
                {
                    return 0;
                }

                double max = _figure[0];

                foreach (double d in _figure)
                {
                    if (d > max)
                    {
                        max = d;
                    }
                }

                return max;
            }
        }

        static private List<double> CopyFigures(List<double> destnination, List<double> source)
        {
            if (null == destnination)
            {
                destnination = new List<double>();
            }

            destnination.Clear();
            foreach (double f in source)
            {
                destnination.Add(f);
            }
            return destnination;
        }

        double FiguresSum
        {
            get
            {
                double sum = 0;

                foreach (double d in _figure)
                {
                    sum += d;
                }
                return sum;
            }
        }
    }
}
