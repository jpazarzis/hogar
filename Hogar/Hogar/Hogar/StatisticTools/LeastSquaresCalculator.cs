using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hogar.StatisticTools
{
    public class LeastSquareCalculator
    {
        struct Pair
        {
            private readonly double _x;
            private readonly double _y;

            public Pair(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public double X { get { return _x; } }

            public double Y { get { return _y; } }

        }

        readonly List<Pair> _value = new List<Pair>();

        double _sloppe = 0.0;
        double _ordinate = 0.0;

        private bool _needsToCalculate = true;

        public void Add(double x, double y)
        {
            _value.Add(new Pair(x, y));
            _needsToCalculate = true;
        }

        public void Clear()
        {
            _value.Clear();
            _needsToCalculate = true;
        }

        public int Count
        {
            get
            {
                return _value.Count;
            }
        }

        private void Calculate()
        {
            double A1 = _value.Sum(pair => pair.X * pair.Y);
            double A2 = _value.Sum(pair => pair.X);
            double A3 = _value.Sum(pair => pair.Y);
            double A4 = _value.Sum(pair => Math.Pow(pair.X, 2));
            double N = _value.Count;
            double denominator = (N * A4 - Math.Pow(A2, 2));

            _sloppe = (N * A1 - A2 * A3) / denominator;
            _ordinate = (A4 * A3 - A1 * A2) / denominator;

            _needsToCalculate = false;
        }

        public double Sloppe
        {
            get
            {
                if (_needsToCalculate)
                {
                    Calculate();
                }

                return _sloppe;
            }
        }

        public double Ordinate
        {
            get
            {
                if (_needsToCalculate)
                {
                    Calculate();
                }

                return _ordinate;
            }
        }


        public double GetValue(double x)
        {
            if (_needsToCalculate)
            {
                Calculate();
            }

            return _sloppe * x + _ordinate;
        }


        public void SelfTest()
        {
            var lsc = new LeastSquareCalculator();

            lsc.Add(1, -1);
            lsc.Add(4, 11);
            lsc.Add(-1, -9);
            lsc.Add(-2, -13);

            Debug.Assert(lsc.Sloppe == 4);
            Debug.Assert(lsc.Ordinate == -5);

        }
    }
}
