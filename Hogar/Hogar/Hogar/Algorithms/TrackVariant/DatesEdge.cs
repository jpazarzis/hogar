using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hogar.Algorithms.TrackVariant
{
    public class DatesEdge
    {
        
        List<double> _time1 = new List<double>();
        List<double> _time2 = new List<double>();


        public override string ToString()
        {
            return string.Format("[{0}: {1}  {2} : {3} ]", V1, AbsoluteTime1, V2,AbsoluteTime2);
        }

        

        public DateVertex V1 { get; set; }

        public DateVertex V2 { get; set; }

        public void AddTimePair(double time1, double time2)
        {
            _time1.Add(time1);
            _time2.Add(time2);
        }

        public double AbsoluteTime1
        {
            get
            {
                return _time1.Average();
            }
        }

        public double AbsoluteTime2
        {
            get
            {
                return _time2.Average();
            }
        }

        public double AbsoluteTimeDiff
        {
            get
            {
                return AbsoluteTime1 - AbsoluteTime2;
            }
        }

        public double AdjustedTime1 { get { return AbsoluteTime1 + V1.Variant; } }

        public double AdjustedTime2 { get { return AbsoluteTime2 + V2.Variant; } }

        public void AdjsutVariants()
        {
            double diff = (AdjustedTime1 - AdjustedTime2) / 2.0;
            V1.AddVariantAdjustment((-1.0) * diff);
            V2.AddVariantAdjustment(diff);
        }
    }
}