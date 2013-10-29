using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.BrisPastPerformances.Extended
{
    public class Sartin
    {
        enum DistanceType
        {
            Invalid, Sprint, Route
        }

        readonly double _firstFraction;
        readonly double _secondFraction;
        readonly double _finalFraction;
        readonly double _earlyPace;
        readonly DistanceType _distanceType;

        internal Sartin(BrisPastPerformance pp)
        {
            _firstFraction = pp.SpeedDuringFirstFraction * Utilities.FEET_IN_A_YEARD;
            _secondFraction = pp.SpeedDuringSecondFraction * Utilities.FEET_IN_A_YEARD;
            _finalFraction = pp.SpeedDuringFinalFraction * Utilities.FEET_IN_A_YEARD;
            _earlyPace = pp.SpeedFromStartToSecondCall * Utilities.FEET_IN_A_YEARD;

            int distance = pp.DistanceInYards;

            if (distance <= 0)
            {
                _distanceType = DistanceType.Invalid;
            }
            else if (distance <= Utilities.YARDS_IN_A_FURLONG * 7)
            {
                _distanceType = DistanceType.Sprint;
            }
            else
            {
                _distanceType = DistanceType.Route;
            }

        }

        public double EarlyPace
        {
            get
            {
                return _earlyPace;
            }
        }

        public double SustainedPace
        {
            get
            {
                return (_earlyPace + _finalFraction) / 2.0;
            }
        }

        public double AveragePace
        {
            get
            {
                switch (_distanceType)
                {
                    case DistanceType.Sprint:
                        return (_firstFraction + _secondFraction + _finalFraction) / 3.0;
                    case DistanceType.Route:
                        return (_earlyPace + SustainedPace) / 2;
                    default:
                        return 0.0;
                }
            }
        }

        // Counts ONLY FOR SPRINTS
        public double FactorX
        {
            get
            {
                if (_distanceType == DistanceType.Sprint)
                {
                    return (_firstFraction + _finalFraction) / 2.0;
                }
                else
                {
                    return -1.0;
                }
            }
        }

        public double PercentEarly
        {
            get
            {
                double denominator = _earlyPace + _finalFraction;
                return denominator != 0.0 ? _earlyPace / denominator : 0.0;
            }
        }
    }
}
