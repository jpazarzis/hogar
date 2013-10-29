using System.Collections.Generic;
using System.Linq;

namespace Hogar.Algorithms.TrackVariant
{
    public class DateVertex
    {
        private readonly string _key;

        private bool _visited;

        private int _numberOfTimesVisited = 0;

        private int _numberOfTimesRecalculatedVariant = 0;

        public DateVertex(string key)
        {
            _key = key;
            _visited = false;
            Variant = 0;
        }

        public override string ToString()
        {
            return string.Format("{0}({1:0.00}) ", Key, Variant);

            //return string.Format("{1:0.00},", Key, Variant);
        }

        public int NumberOfTimesVisited
        {
            get
            {
                return _numberOfTimesVisited;
            }
        }

        public int NumberOfTimesRecalculatedVariant
        {
            get
            {
                return _numberOfTimesRecalculatedVariant;
            }
        }

        

        public bool Visited
        {
            get
            {
                return _visited;
            } 
            set
            {
                ++_numberOfTimesVisited;
                _visited = value;
            }
        }

        public string Key { get { return _key; } }

        public double Variant { get; internal set; }

        public void ClearVariantAdjustments()
        {
            _variantAdjustments.Clear();
        }

        public void AddVariantAdjustment(double adjustment)
        {
            ++_numberOfTimesRecalculatedVariant;
            _variantAdjustments.Add(adjustment);
        }

        public double PreviousVariant { get; set; }

        public double DifferenceFromPreviousVariant { get { return PreviousVariant - Variant; } }

        public int NumberOfCycles { get; set; }

        private int _minCycleSize = int.MaxValue;

        public int MinCycleSize
        { 
            get
            {
                return _minCycleSize;
            }
            set
            {
                if (value < _minCycleSize)
                {
                    _minCycleSize = value;
                }
            }
        }

        public void RecalculateVariant()
        {
           
            if (_variantAdjustments.Count > 0)
            {
                
                PreviousVariant = Variant;
                Variant += _variantAdjustments.Average();
            }
            _variantAdjustments.Clear();
        }

        private readonly List<double> _variantAdjustments = new List<double>();
    }
}