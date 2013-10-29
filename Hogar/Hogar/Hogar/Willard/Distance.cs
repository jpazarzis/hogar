using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Willard
{
    public class Distance
    {
        public enum TrackType
        {
            InnerTrack,
            OuterTrack
        }


        public class FractionDistances
        {
            readonly double _firstCall;
            readonly double _secondCall;

            public FractionDistances(double firstCall, double secondCall)
            {
                _firstCall = firstCall;
                _secondCall = secondCall;
            }

            public double FirstCallDistanceInFeet
            {
                get
                {
                    return _firstCall;
                }
            }

            public double SecondCallDistanceInFeet
            {
                get
                {
                    return _secondCall;
                }
            }
        }






        public enum FractionType
        {
            First, Second, Third, Fourth, Fifth
        }

        readonly double _distance;
        readonly TrackType _tt;
        readonly FractionType _fractionToUseAsFirst;
        readonly FractionType _fractionToUseAsSecond;


        public Distance(double distance, TrackType tt, FractionType fractionToUseAsFirst, FractionType fractionToUseAsSecond)
        {
            _distance = distance;
            _tt = tt;
            _fractionToUseAsFirst = fractionToUseAsFirst;
            _fractionToUseAsSecond = fractionToUseAsSecond;
        }

        static public bool AreEqual(Distance d1, Distance d2)
        {
            return (d1._distance == d2._distance) && (d1._tt == d2._tt);
        }

        public FractionType FirstFractionType
        {
            get
            {
                return _fractionToUseAsFirst;
            }
        }

        public FractionType SecondFractionType
        {
            get
            {
                return _fractionToUseAsSecond;
            }
        }


        public FractionDistances FractionDistancesForTheDistance
        {
            get
            {
                if (_distance <= (7.5 * Utilities.YARDS_IN_A_FURLONG))
                {
                    return new FractionDistances(1320, 2640);
                }
                else if (_distance <= (9.5 * Utilities.YARDS_IN_A_FURLONG))
                {
                    return new FractionDistances(2640, 3960);
                }
                else if (_distance <= (11 * Utilities.YARDS_IN_A_FURLONG))
                {
                    return new FractionDistances(2640, 5280);
                }
                else
                {
                    return new FractionDistances(2640, 6600);
                }

            }
        }
    }
}
