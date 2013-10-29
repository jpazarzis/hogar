using System;

namespace Hogar.Research.GeneticAlgorithm
{
    class Partition
    {
        private readonly double _from;
        private readonly double _to;

        private int _count = 0;
        private int _winners = 0;

        public Partition(double from, double to)
        {
            _from = from;
            _to = to;
        }

        public override string ToString()
        {
            return string.Format(" {0:0.0} - {1:0.0} : {2} / {3} ", _from, _to, _winners, _count);
        }

        public void Clear()
        {
            _winners = _count = 0;
        }

        bool IsValid
        {
            get
            {
                return _from >= 0.0 && _to <= 1.0 && _from < _to;
            }
        }

        public double LowerBound
        {
            get
            {
                return _from;
            }
        }

        public double UpperBound
        {
            get
            {
                return _to;
            }
        }

#if DEBUG
        public bool FillsIn(double v)
        {
            return v >= _from && v <= _to;
        }
#endif

        public void IncreaseCount()
        {
            ++_count;
        }

        public void IncreaseWinners()
        {
            ++_winners;
            IncreaseCount();
        }

        public int Winners
        {
            get
            {
                return _winners;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public double WinningPercent
        {
            get { return _count == 0 ? 0.0 : (double) _winners/(double) _count; }
        }

    }
}