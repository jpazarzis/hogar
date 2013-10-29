using System;
using System.Collections.Generic;
using Hogar.Parsing;
using System.Data;
using System.Data.SqlClient;
using Hogar.Cynthia;

namespace Hogar.BrisPastPerformances.Extended
{
    public class BrisPastPerformance
    {
        private const int INVALID_VARIANT = -99999;

        #region details

        private struct FieldIndex
        {
            public static int DATE = 255;
            public static int DAYS_SINCE_LAST = 265;
            public static int RACE_TRACK = 275;
            public static int RACE_NUMBER = 295;
            public static int TRACK_CONDITION = 305;
            public static int DISTANCE = 315;
            public static int SURFACE = 325;
            public static int NUMBER_OF_ENTRANTS = 345;
            public static int POST_POSITION = 355;
            public static int EQUIPMENT = 365;
            public static int MEDICATION = 385;
            public static int TRIP_COMMENT = 396;
            public static int WINNERS_NAME = 405;
            public static int SECOND_PLACE_FINISHER_NAME = 415;
            public static int THIRD_PLACE_FINISHER_NAME = 425;
            public static int WINNERS_WEIGHT = 435;
            public static int SECOND_PLACE_FINISHER_WEIGHT = 445;
            public static int THIRD_PLACE_FINISHER_WEIGHT = 455;
            public static int EXTRA_COMMENT_LINE = 495;
            public static int WEIGHT = 505;
            public static int ODDS = 515;
            public static int RACE_CLASSIFICATION = 535;
            public static int CLAIMING_PRICE = 545;
            public static int START_CALL_POSITION = 565;
            public static int FIRST_CALL_POSITION = 575;
            public static int SECOND_CALL_POSITION = 585;
            public static int STRETCH_POSITION = 605;
            public static int FINISH_POSITION = 615;
            public static int MONEY_POSITION = 625;
            public static int FIRST_CALL_LENGTHS = 655;
            public static int SECOND_CALL_LENGTHS = 675;
            public static int STRETCH_LENGTHS = 715;
            public static int FINISH_LENGTHS = 735;
            public static int BRIS_2_FURLONG_PACE_FIGURE = 765;
            public static int BRIS_4_FURLONG_PACE_FIGURE = 776;
            public static int BRIS_RACE_SHAPE_FIRST_CALL = 695;
            public static int BRIS_RACE_SHAPE_SECOND_CALL = 755;
            public static int BRIS_LATE_PACE_FIGURE = 815;
            public static int BRIS_RACE_RATING = 825;
            public static int BRIS_CLASS_RATING = 835;
            public static int BRIS_SPEED_RATING = 845;
            public static int TRACK_VARIANT = 865;
            public static int TWO_FULRONGS_FRACTION = 875;
            public static int THREE_FULRONGS_FRACTION = 885;
            public static int FOUR_FULRONGS_FRACTION = 895;
            public static int FIVE_FULRONGS_FRACTION = 905;
            public static int SIX_FULRONGS_FRACTION = 915;
            public static int SEVEN_FULRONGS_FRACTION = 925;
            public static int EIGHT_FULRONGS_FRACTION = 935;
            public static int TEN_FULRONGS_FRACTION = 945;
            public static int TWELVE_FULRONGS_FRACTION = 955;
            public static int FORTEEN_FULRONGS_FRACTION = 965;
            public static int SIXTEEN_FULRONGS_FRACTION = 975;
            public static int FIRST_FRACTION = 985;
            public static int SECOND_FRACTION = 995;
            public static int THIRD_FRACTION = 1005;
            public static int AGE_SEX_RESTRICTIONS = 1095;
            public static int STATE_BRED_FLAG = 1105;
            public static int FAVORITE_INDICATOR = 1125;
            public static int FINAL_TIME = 1035;
            public static int JOCKEY = 1065;
            public static int RACE_TYPE = 1085;
            public static int MAX_CLAIMING_PRICE_OF_THE_RACE = 1211;
        }

        private readonly BrisHorse _parent = null;
        private readonly DataRow _dr = null;
        private readonly int _index;
        private Dictionary<FractionCall.Level, FractionCall> _fraction = new Dictionary<FractionCall.Level, FractionCall>();

        private readonly SurfaceType _surfaceType;
        private readonly bool _isATurfRace;

        private double _cynthiaFigure = 0;
        private double _cynthiaFigureForTheWinner = 0;

        private int _avgVariant = -9999;

        private bool _needsToLoadCynthiaFigures = true;

        private CynthiaPar _cynthiaParForTheRace = null;
        private double _adjustedFirstCall = 0.0;
        private double _adjustedSecondCall = 0.0;
        private double _adjustedFinalCall = 0.0;

        private bool _needsToCalculateAdjustedCalls = true;

        #endregion

        public enum RunningStyleType
        {
            Early,
            Presser,
            Sustained,
            Unspecified
        }

        public enum SurfaceType
        {
            Dirt,
            InnerDirt,
            Turf,
            InnerTurf
        }

        #region FractionCallsToUseForCynthia

        public class FractionCallsToUseForCynthia
        {
            private readonly double _firstCall;
            private readonly double _secondCall;
            private readonly double _finalCall;

            internal FractionCallsToUseForCynthia(double firstCall, double secondCall, double finalCall)
            {
                _firstCall = firstCall;
                _secondCall = secondCall;
                _finalCall = finalCall;
            }

            public double FirstCall
            {
                get
                {
                    return _firstCall;
                }
            }

            public double SecondCall
            {
                get
                {
                    return _secondCall;
                }
            }

            public double FinalCall
            {
                get
                {
                    return _finalCall;
                }
            }
        }

        #endregion

        public bool NeedsToCalculateAdjustedCalls
        {
            get
            {
                return _needsToCalculateAdjustedCalls;
            }
            set
            {
                _needsToCalculateAdjustedCalls = value;
            }
        }

        public CynthiaPar CynthiaParForTheRace
        {
            get
            {
                if (null == _cynthiaParForTheRace)
                {
                    string cynthiaClass = this.Parent.Parent.CorrespondingRace.CynthiaClassification;
                    _cynthiaParForTheRace = CynthiaPar.Make(TrackCode, SurfaceToUseForCynthiaPars, DistanceInYards, cynthiaClass, 'N');
                }

                return _cynthiaParForTheRace;
            }
        }

        public void ReloadCynthiaParForTheRace()
        {
            _cynthiaParForTheRace = null;
        }

        public bool IsStateBredRestrictedRace
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.STATE_BRED_FLAG + _index).ToUpper();
                return s.Length > 0 ? s[0] == 'S' : false;
            }
        }

        public double AdjustedFirstCall
        {
            get
            {
                if (_needsToCalculateAdjustedCalls)
                {
                    CalculateAdjustedCalls();
                }

                return _adjustedFirstCall;
            }
        }

        public double AdjustedSecondCall
        {
            get
            {
                if (_needsToCalculateAdjustedCalls)
                {
                    CalculateAdjustedCalls();
                }

                return _adjustedSecondCall;
            }
        }

        public double AdjustedFinalCall
        {
            get
            {
                if (_needsToCalculateAdjustedCalls)
                {
                    CalculateAdjustedCalls();
                }

                return _adjustedFinalCall;
            }
        }

        private void CalculateAdjustedCalls()
        {
            _adjustedFirstCall = _adjustedSecondCall = _adjustedFinalCall = 0.0;

            CynthiaPar cp0 = this.Parent.Parent.CorrespondingRace.CynthiaParsForTheRace;
            CynthiaPar cp1 = this.CynthiaParForTheRace;

            double firstCallProjectionDiff = FirstCallAdjustment(cp0, cp1);
            double secondCallProjectionDiff = SecondCallAdjustment(cp0, cp1);
            double finalCallProjectionDiff = FinalCallAdjustment(cp0, cp1);

            BrisPastPerformance.FractionCallsToUseForCynthia f = this.FractionsToUseForCynthia;

            double firstCallProjection = firstCallProjectionDiff + f.FirstCall;
            double secondCallProjection = secondCallProjectionDiff + f.SecondCall;
            double finalCallProjection = finalCallProjectionDiff + f.FinalCall;

            double variantDiff = (this.AvgVariant - this.TrackVariant)/10.0;

            _adjustedFirstCall = firstCallProjection + (variantDiff*1.0/4.0);
            _adjustedSecondCall = secondCallProjection + (variantDiff*2.0/3.0);
            _adjustedFinalCall = finalCallProjection + (variantDiff*4.0/4.0);

            if (f.FirstCall == 0.0)
            {
                _adjustedFirstCall = 0.0;
            }

            if (f.SecondCall == 0.0)
            {
                _adjustedSecondCall = 0.0;
            }

            if (f.FinalCall == 0.0)
            {
                _adjustedFinalCall = 0.0;
            }

            _needsToCalculateAdjustedCalls = false;
        }

        private double FirstCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ((cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.FirstCall - cp1.FirstCall : 0.0;
        }

        private double SecondCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ((cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.MidCall - cp1.MidCall : 0.0;
        }

        private double FinalCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ((cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.FinalCall - cp1.FinalCall : 0.0;
        }

        private char SurfaceToUseForCynthiaPars
        {
            get
            {
                switch (_surfaceType)
                {
                    case SurfaceType.InnerTurf:
                        return 'I';
                    case SurfaceType.InnerDirt:
                        return 'N';
                    case SurfaceType.Turf:
                        return 'T';
                    default:
                        return 'D';
                }
            }
        }

        public int AvgVariant
        {
            get
            {
                if (_avgVariant == -9999)
                {
                    _avgVariant = Cynthia.AverageVariant.AvgVariant(this);
                }
                return _avgVariant;
            }
        }

        private string RaceRestrictions
        {
            get
            {
                string s = RaceClassification.ToUpper();
                s = s.Replace("N1", "NW1");
                s = s.Replace("N2", "NW2");
                s = s.Replace("N3", "NW3");
                s = s.Replace("N4", "NW4");
                return s;
            }
        }

        // The following methods refer to the position of the horse
        // for the fractions used by Cynhthia jp feb 26 2010
        public string FirstFractionPosition
        {
            get
            {
                if (DistanceInYards <= 1650) // 7.5 FURLONGS
                {
                    return FirstCallPosition;
                }
                else if (DistanceInYards <= 1870) // 1 1/16 
                {
                    return SecondCallPosition;
                }
                else if (DistanceInYards <= 1980) // 1 1/8
                {
                    return FirstCallPosition;
                }
                else
                {
                    return SecondCallPosition;
                }
            }
        }

        public string SecondFractionPosition
        {
            get
            {
                if (DistanceInYards <= 1650) // 7.5 FURLONGS
                {
                    return SecondCallPosition;
                }
                else if (DistanceInYards <= 1870) // 1 1/16 
                {
                    return StretchCallPosition;
                }
                else if (DistanceInYards <= 1980) // 1 1/8
                {
                    return SecondCallPosition;
                }
                else
                {
                    return StretchCallPosition;
                }
            }
        }

        // IF YOU MAKE ANY CHANGES in this method please be sure to be
        // aligned with the previous XXXXFractionPosition methods
        public FractionCallsToUseForCynthia FractionsToUseForCynthia
        {
            get
            {
                if (DistanceInYards <= 1650) // 7.5 FURLONGS
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.First].Time, _fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Final].Time);
                }
                else if (DistanceInYards <= 1870) // 1 1/16 
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Stretch].Time, _fraction[FractionCall.Level.Final].Time);
                }
                else if (DistanceInYards <= 1980) // 1 1/8
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.First].Time, _fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Final].Time);
                }
                else if (DistanceInYards <= 2090) // 1 3/16
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Stretch].Time, _fraction[FractionCall.Level.Final].Time);
                }
                else if (DistanceInYards <= 2640) // 1 1/2
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Stretch].Time, _fraction[FractionCall.Level.Final].Time);
                }
                else
                {
                    return new FractionCallsToUseForCynthia(_fraction[FractionCall.Level.Second].Time, _fraction[FractionCall.Level.Stretch].Time, _fraction[FractionCall.Level.Final].Time);
                }
            }
        }

        public bool IsDoubleMove
        {
            get
            {
                int p1 = Utilities.GetFieldAsInteger(_dr, FieldIndex.FIRST_CALL_POSITION + _index);
                int p2 = Utilities.GetFieldAsInteger(_dr, FieldIndex.SECOND_CALL_POSITION + _index);
                int p3 = Utilities.GetFieldAsInteger(_dr, FieldIndex.STRETCH_POSITION + _index);
                int p4 = Utilities.GetFieldAsInteger(_dr, FieldIndex.FINISH_POSITION + _index);
                return p1 > p2 && p3 > p4 && p3 > p2;
            }
        }

        public RunningStyleType RunningStyle
        {
            get
            {
                var call = new List<int>();
                call.Add(Convert.ToInt32(FirstCallPosition));
                call.Add(Convert.ToInt32(SecondCallPosition));
                call.Add(Convert.ToInt32(StretchCallPosition));
                call.Add(Convert.ToInt32(FinalPosition));
                foreach (int c in call)
                {
                    if (c == 0)
                    {
                        return RunningStyleType.Unspecified;
                    }
                }
                if ((call[0] == 1 || call[1] == 1) && call[2] == 1)
                {
                    return RunningStyleType.Early;
                }
                if (call[0] == 2 && call[2] == 2)
                {
                    double lengthsBehind0 = Utilities.GetFieldAsDouble(_dr, FieldIndex.FIRST_CALL_LENGTHS + _index);
                    double lengthsBehind1 = Utilities.GetFieldAsDouble(_dr, FieldIndex.SECOND_CALL_LENGTHS + _index);

                    if (lengthsBehind0 <= 1.5 && lengthsBehind1 < 1)
                    {
                        return RunningStyleType.Early;
                    }
                }
                if (call[2] == 1)
                {
                    return RunningStyleType.Presser;
                }

                if (call[0] >= 6 && (call[3] <= 2 && call[3] >= 1))
                {
                    try
                    {
                        double lengthsBehind = Utilities.GetFieldAsDouble(_dr, FieldIndex.FIRST_CALL_LENGTHS + _index);

                        if (lengthsBehind >= 6.0)
                        {
                            return RunningStyleType.Sustained;
                        }
                    }
                    catch
                    {
                        return RunningStyleType.Unspecified;
                    }
                }
                return RunningStyleType.Unspecified;
            }
        }

        public double SpeedDuringFinalFraction
        {
            get
            {
                if (SecondFractionInYards == 0 || DistanceInYards == 0)
                {
                    return 0;
                }

                double distance = DistanceInYards - SecondFractionInYards;

                if (distance == 0)
                {
                    return 0;
                }

                double time = _fraction[FractionCall.Level.Final].Time - _fraction[FractionCall.Level.Second].Time;

                return distance/time;
            }
        }

        public double SpeedDuringThirdFraction
        {
            get
            {
                try
                {
                    if (SecondFractionInYards == 0 || ThirdFractionInYards == 0)
                    {
                        return 0;
                    }

                    double distance = ThirdFractionInYards - SecondFractionInYards;

                    if (distance == 0)
                    {
                        return 0;
                    }

                    double time = _fraction[FractionCall.Level.Stretch].Time - _fraction[FractionCall.Level.Second].Time;

                    return distance/time;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public double SpeedDuringSecondFraction
        {
            get
            {
                try
                {
                    if (FirstFractionInYards == 0 || SecondFractionInYards == 0)
                    {
                        return 0;
                    }

                    double distance = SecondFractionInYards - FirstFractionInYards;

                    if (distance == 0)
                    {
                        return 0;
                    }

                    double time = _fraction[FractionCall.Level.Second].Time - _fraction[FractionCall.Level.First].Time;

                    return distance/time;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public Sartin SartinFigures
        {
            get
            {
                return new Sartin(this);
            }
        }

        public double SpeedDuringFirstFraction
        {
            get
            {
                try
                {
                    return FirstFractionInYards != 0 ? FirstFractionInYards/_fraction[FractionCall.Level.First].Time : 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public double SpeedFromStartToSecondCall
        {
            get
            {
                try
                {
                    double s = SecondFractionInYards;
                    double t = _fraction[FractionCall.Level.Second].Time;

                    return t != 0 ? s/t : 0.0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public string BrisRaceShapeFirstCall
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_RACE_SHAPE_FIRST_CALL + _index);
            }
        }

        public string BrisRaceShapeSecondCall
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_RACE_SHAPE_SECOND_CALL + _index);
            }
        }

        public double ThirdFractionInYards
        {
            get
            {
                return GetFractionInYardsUsingItsTiming(Utilities.GetFieldAsString(_dr, FieldIndex.THIRD_FRACTION + _index));
            }
        }

        public double SecondFractionInYards
        {
            get
            {
                return GetFractionInYardsUsingItsTiming(Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_FRACTION + _index));
            }
        }

        public double FirstFractionInYards
        {
            get
            {
                return GetFractionInYardsUsingItsTiming(Utilities.GetFieldAsString(_dr, FieldIndex.FIRST_FRACTION + _index));
            }
        }

        private double StrgToDouble(string txt)
        {
            if (txt.Trim().Length <= 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(txt);
            }
        }

        private double GetFractionInYardsUsingItsTiming(string fractionTimeInStrg)
        {
            if (fractionTimeInStrg.Trim().Length <= 0)
            {
                return 0;
            }

            double fractionTime = Convert.ToDouble(fractionTimeInStrg);

            if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.SIXTEEN_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*16.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.FORTEEN_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*14.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.TWELVE_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*12.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.TEN_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*10.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.EIGHT_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*8.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.SEVEN_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*7.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.SIX_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*6.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.FIVE_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*5.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.FOUR_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*4.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.THREE_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*3.0;
            }
            else if (fractionTime == Utilities.GetFieldAsDouble(_dr, FieldIndex.TWO_FULRONGS_FRACTION + _index))
            {
                return Utilities.YARDS_IN_A_FURLONG*2.0;
            }
            else
            {
                return 0.0;
            }
        }

        public BrisHorse Parent
        {
            get
            {
                return _parent;
            }
        }

        public override string ToString()
        {
            return "Not Implemented";
        }

        internal BrisPastPerformance(DataRow dr, int index, BrisHorse parent)
        {
            _dr = dr;
            _index = index;
            _parent = parent;

            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    _isATurfRace = false;
                }
                else if (s[0] == 'T' || s[0] == 't')
                {
                    _isATurfRace = true;
                }
                else
                {
                    _isATurfRace = false;
                }

                _surfaceType = SurfaceType.Dirt;

                if (s.Length > 0)
                {
                    if (s[0] == 'T')
                    {
                        _surfaceType = SurfaceType.Turf;
                    }
                    else if (s[0] == 't')
                    {
                        _surfaceType = SurfaceType.InnerTurf;
                    }
                    else if (s[0] == 'd')
                    {
                        _surfaceType = SurfaceType.InnerDirt;
                    }
                    else
                    {
                        _surfaceType = SurfaceType.Dirt;
                    }
                }
            }

            _fraction[FractionCall.Level.First] = FractionCall.Make(_dr, FirstFractionInYards, FieldIndex.FIRST_CALL_POSITION + _index, FieldIndex.FIRST_FRACTION + _index, FieldIndex.FIRST_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Second] = FractionCall.Make(_dr, SecondFractionInYards, FieldIndex.START_CALL_POSITION + _index, FieldIndex.SECOND_FRACTION + _index, FieldIndex.SECOND_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Stretch] = FractionCall.Make(_dr, ThirdFractionInYards, FieldIndex.STRETCH_POSITION + _index, FieldIndex.THIRD_FRACTION + _index, FieldIndex.STRETCH_LENGTHS + _index);
            _fraction[FractionCall.Level.Final] = FractionCall.Make(_dr, DistanceInYards, FieldIndex.FINISH_POSITION + _index, FieldIndex.FINAL_TIME + _index, FieldIndex.FINISH_LENGTHS + _index);
        }

        private static string ConvertToUnicodeSuperscript(string s)
        {
            string temp = "";
            foreach (char c in s)
            {
                if (c == '1')
                {
                    temp += '\u00B9';
                }
                else if (c == '2')
                {
                    temp += '\u00B2';
                }
                else if (c == '3')
                {
                    temp += '\u00B3';
                }
                else if (c == '4')
                {
                    temp += '\u2074';
                }
                else if (c == '5')
                {
                    temp += '\u2075';
                }
                else if (c == '6')
                {
                    temp += '\u2076';
                }
                else if (c == '7')
                {
                    temp += '\u2077';
                }
                else if (c == '8')
                {
                    temp += '\u2078';
                }
                else if (c == '9')
                {
                    temp += '\u2079';
                }
                else if (c == '0')
                {
                    temp += '\u2070';
                }
                else
                {
                    temp += c;
                }
            }

            return temp;
        }

        private string ConvertToDistanceFraction(string distance)
        {
            char oneHalfUnicode = '\u00BD';
            char oneQuarterUnicode = '\u00BC';
            char threeQuartersUnicode = '\u00BE';

            double d = StrgToDouble(distance);

            int i = (int) d;

            string fulllengths = "";

            if (i > 0)
            {
                fulllengths = i.ToString();
            }

            fulllengths = ConvertToUnicodeSuperscript(fulllengths);

            d = d - i;

            int dec = (int) (d*100);

            if (dec == 0)
            {
                return fulllengths;
            }
            else if (dec == 25)
            {
                return fulllengths + " " + oneQuarterUnicode;
            }
            else if (dec == 50)
            {
                return fulllengths + " " + oneHalfUnicode;
            }
            else if (dec == 75)
            {
                return fulllengths + " " + threeQuartersUnicode;
            }
            else if (dec == 13)
            {
                return fulllengths + " " + "hd";
            }
            else if (dec == 6)
            {
                return fulllengths + " " + "no";
            }
            else
            {
                return fulllengths + " " + d.ToString();
            }
        }

        public string FirstCallPosition
        {
            get
            {
                return ConvertNonNumericPositionToZero(Utilities.GetFieldAsString(_dr, FieldIndex.FIRST_CALL_POSITION + _index));
            }
        }

        public string FirstCallDistanceFromLeader
        {
            get
            {
                return ConvertToDistanceFraction(Utilities.GetFieldAsString(_dr, FieldIndex.FIRST_CALL_LENGTHS + _index));
            }
        }

        public string SecondCallPosition
        {
            get
            {
                return ConvertNonNumericPositionToZero(Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_CALL_POSITION + _index));
            }
        }

        public string SecondCallDistanceFromLeader
        {
            get
            {
                return ConvertToDistanceFraction(Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_CALL_LENGTHS + _index));
            }
        }

        public string StretchCallPosition
        {
            get
            {
                return ConvertNonNumericPositionToZero(Utilities.GetFieldAsString(_dr, FieldIndex.STRETCH_POSITION + _index));
            }
        }

        public string StretchCallDistanceFromLeader
        {
            get
            {
                return ConvertToDistanceFraction(Utilities.GetFieldAsString(_dr, FieldIndex.STRETCH_LENGTHS + _index));
            }
        }

        public int DaysSinceLastRace
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.DAYS_SINCE_LAST + _index);
            }
        }

        public int DaysSinceThatRace
        {
            get
            {
                DateTime todaysDate = _parent.Parent.Parent.GetFullDate();
                TimeSpan span = todaysDate - Date;
                return span.Days;
            }
        }

        public int BrisComposite
        {
            get
            {
                return BrisEarlyPace + BrisLatePace;
            }
        }

        public int BrisEarlyPace
        {
            get
            {
                int fieldIndex = IsASprint ? FieldIndex.BRIS_2_FURLONG_PACE_FIGURE : FieldIndex.BRIS_4_FURLONG_PACE_FIGURE;
                return Utilities.GetFieldAsInteger(_dr, fieldIndex + _index);
            }
        }

        public int BrisLatePace
        {
            get
            {
                int i = Utilities.GetFieldAsInteger(_dr, FieldIndex.BRIS_LATE_PACE_FIGURE + _index);
                return i > 0 ? i + BrisSpeedRatingAsInteger : 0;
            }
        }

        private double InterpolateValue(double min, double max, double v)
        {
            return max - min != 0.0 ? 10.0*(v - min)/(max - min) : 0.0;
        }

        public double CynthiaFigure
        {
            get
            {
                if (_needsToLoadCynthiaFigures)
                {
                    LoadCynthiaFigures();
                }

                return _cynthiaFigure;
            }
        }

        public double CynthiaFigureForTheWinner
        {
            get
            {
                if (_needsToLoadCynthiaFigures)
                {
                    LoadCynthiaFigures();
                }

                return _cynthiaFigureForTheWinner;
            }
        }

        #region Cynthia's Details

        private void LoadCynthiaFigures()
        {
            int avgDailyVariant = GetAverageDailyVariantFromDb();
            if (avgDailyVariant == INVALID_VARIANT)
                return;
            double adjustedWinersTime = this.WinnersFinalTime - DiffInSeconds(this.TrackVariant, avgDailyVariant);
            double adjustedThisHorseTime = this.ThisHorseFinalTime - DiffInSeconds(this.TrackVariant, avgDailyVariant);
            int finishPosition = Convert.ToInt32(this.FinalPosition);
            DataTable dt = LoadPars();
            if (TimeRank(this.WinnersFinalTime, dt) >= 0)
            {
                _cynthiaFigureForTheWinner = TimeRank(adjustedWinersTime, dt);
                if (finishPosition > 0)
                {
                    _cynthiaFigure = TimeRank(adjustedThisHorseTime, dt);
                }
                else
                {
                    _cynthiaFigure = 0;
                }
            }
        }

        private double TimeRank(double time, DataTable timeTable)
        {
            if (timeTable.Rows.Count <= 0)
            {
                return -1;
            }

            int rank = -1;

            if (time <= (double) timeTable.Rows[0]["FINAL_CALL"])
            {
                rank = 0;
            }

            for (int i = 1; i < timeTable.Rows.Count; ++i)
            {
                if (time < (double) timeTable.Rows[i]["FINAL_CALL"])
                {
                    rank = i;
                    break;
                }
            }

            if (rank < 0)
            {
                rank = timeTable.Rows.Count;
            }

            double d = (1.0 - (double) rank/(double) timeTable.Rows.Count)*100.00;
            string s = string.Format("{0:0}", d);
            return Convert.ToDouble(s);
        }

        private double DiffInSeconds(int dailyVariant, int avgDailyVariant)
        {
            return (double) (dailyVariant - avgDailyVariant)/8.0;
        }

        private DataTable LoadPars()
        {
            string sql = SQLLoadPars;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        private string CynthiasAbrForTrackCode(string trackCode)
        {
            if (trackCode.ToUpper() == "OSA")
            {
                return "SA";
            }
            else
            {
                return trackCode;
            }
        }

        private string SQLLoadPars
        {
            get
            {
                BrisPastPerformance.SurfaceType st = SurfaceAndDistanceType;
                string surfaceClause = "";
                switch (st)
                {
                    case BrisPastPerformance.SurfaceType.Dirt:
                        surfaceClause = @" AND SURFACE = 'D' ";
                        break;
                    case BrisPastPerformance.SurfaceType.Turf:
                        surfaceClause = @" AND SURFACE = 'T' ";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerTurf:
                        surfaceClause = @" AND SURFACE = 'I' ";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerDirt:
                        surfaceClause = @" AND SURFACE = 'N' ";
                        break;
                    default:
                        break;
                }

                string aboutClause = "";

                if (AboutDistanceFlag)
                {
                    aboutClause = " AND ABOUT_FLAG = 'A' ";
                }
                else
                {
                    aboutClause = " AND ABOUT_FLAG = 'N' ";
                }

                string sql = string.Format(@"SELECT 
	                                            CLASS,
	                                            FIRST_CALL,
	                                            MID_CALL,
	                                            FINAL_CALL
                                            FROM 
	                                            CYNTHIA_PARS 
                                            WHERE 
	                                            TRACK_CODE = '{0}' 
	                                            AND DISTANCE = {1} ",
                                           CynthiasAbrForTrackCode(TrackCode),
                                           DistanceInYards);
                sql += surfaceClause;
                sql += aboutClause;

                sql += " ORDER BY FINAL_CALL";

                return sql;
            }
        }

        private int GetAverageDailyVariantFromDb()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLLoadAvgVariant, Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            int var = INVALID_VARIANT;
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                var = (int) dr["AVERAGE_VARIANT"];
            }
            return var;
        }

        private string SQLLoadAvgVariant
        {
            get
            {
                BrisPastPerformance.SurfaceType st = SurfaceAndDistanceType;

                string surface = "";
                switch (st)
                {
                    case BrisPastPerformance.SurfaceType.Dirt:
                        surface = "D";
                        break;
                    case BrisPastPerformance.SurfaceType.Turf:
                        surface = "T";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerTurf:
                        surface = "I";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerDirt:
                        surface = "N";
                        break;
                    default:
                        surface = "X";
                        break;
                }

                string aboutFlag = "";

                if (AboutDistanceFlag)
                {
                    aboutFlag = "A";
                }
                else
                {
                    aboutFlag = "";
                }

                string sprintOrRoute = DistanceInYards >= Utilities.YARDS_IN_A_FURLONG*8 ? "R" : "S";

                string trackCondition = TrackCondition.Trim();

                if (trackCondition.ToUpper() == "SY")
                {
                    trackCondition = "sly";
                }
                else if (trackCondition.ToUpper() == "FT")
                {
                    trackCondition = "fst";
                }
                else if (trackCondition.ToUpper() == "TF")
                {
                    trackCondition = "gd";
                }

                string sql = string.Format(@"SELECT TRACK_CONDITION, AVERAGE_VARIANT
                                             FROM CYNTHIA_AVERAGE_VARIANTS
                                            WHERE 
	                                            TRACK_CODE = '{0}'
                                            AND SURFACE = '{1}'
                                            AND SPRINT_OR_ROUTE = '{2}'
                                            AND ABOUT_FLAG = '{3}' 
                                            AND TRACK_CONDITION = '{4}'",
                                           CynthiasAbrForTrackCode(TrackCode),
                                           surface,
                                           sprintOrRoute,
                                           aboutFlag,
                                           trackCondition);

                return sql;
            }
        }

        #endregion

        public double InterpolatedSpeedFigure
        {
            get
            {
                return InterpolateValue(_parent.Parent.MinSpeedFigure, _parent.Parent.MaxSpeedFigure, (double) BrisSpeedRatingAsInteger);
            }
        }

        public double InterpolatedRaceRating
        {
            get
            {
                return InterpolateValue(_parent.Parent.MinRaceRating, _parent.Parent.MaxRaceRating, BrisRaceRating);
            }
        }

        public double InterpolatedClassRating
        {
            get
            {
                return InterpolateValue(_parent.Parent.MinClassRating, _parent.Parent.MaxClassRating, BrisClassRating);
            }
        }

        public double BrisRaceRating
        {
            get
            {
                double d = Utilities.GetFieldAsDouble(_dr, FieldIndex.BRIS_RACE_RATING + _index);
                return d > 0 ? d : -1.0;
            }
        }

        public double BrisClassRating
        {
            get
            {
                double d = Utilities.GetFieldAsDouble(_dr, FieldIndex.BRIS_CLASS_RATING + _index);
                return d > 0 ? d : -1.0;
            }
        }

        public int BrisSpeedRatingAsInteger
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.BRIS_SPEED_RATING + _index);
            }
        }

        public double CustomTrackVariant
        {
            get
            {
                return Hogar.TrackVariant.Singleton.GetVariant(this.TrackCode, this.Date);
            }
        }

        public int TrackVariant
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.TRACK_VARIANT + _index);
                if (s.Length > 0)
                {
                    return Convert.ToInt32(s);
                }
                else
                {
                    return 0;
                }
            }
        }

        // TODO Change the signature to return int
        public string BrisSpeedRating
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_SPEED_RATING + _index);
            }
        }

        public string FinalPosition
        {
            get
            {
                return ConvertNonNumericPositionToZero(Utilities.GetFieldAsString(_dr, FieldIndex.FINISH_POSITION + _index));
            }
        }

        private string ConvertNonNumericPositionToZero(string pos)
        {
            pos = pos.Trim();

            if (pos.Length <= 0)
            {
                return "0";
            }

            foreach (char c in pos)
            {
                if (c < '0' || c > '9')
                {
                    return "0";
                }
            }
            return pos;
        }

        public double RawFinalCallDistanceFromLeader
        {
            get
            {
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.FINISH_LENGTHS + _index);
            }
        }

        public string FinalCallDistanceFromLeader
        {
            get
            {
                return ConvertToDistanceFraction(Utilities.GetFieldAsString(_dr, FieldIndex.FINISH_LENGTHS + _index));
            }
        }

        public bool IsValid
        {
            get
            {
                return DateAsString.Length > 0;
            }
        }

        public string TrackCondition
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.TRACK_CONDITION + _index).ToLower();
            }
        }

        public string NumberOfEntrants
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.NUMBER_OF_ENTRANTS + _index);
            }
        }

        public string PostPosition
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.POST_POSITION + _index);
            }
        }

        public string StartCallPosition
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.START_CALL_POSITION + _index);
            }
        }

        public string Jockey
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.JOCKEY + _index);
            }
        }

        public string AgeSexRestrictions
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.AGE_SEX_RESTRICTIONS + _index) + "    ";
            }
        }

        public string RaceType
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.RACE_TYPE + _index) + "    ";
            }
        }

        public bool WasTheFavorite
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.FAVORITE_INDICATOR + _index);
                return s.Length > 0 ? s[0] == '1' : false;
            }
        }

        public string Odds
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.ODDS + _index);
                return WasTheFavorite ? "*" + s : s;
            }
        }

        public string Equipment
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.EQUIPMENT + _index);
            }
        }

        public string Medication
        {
            get
            {
                switch (Utilities.GetFieldAsInteger(_dr, FieldIndex.MEDICATION + _index))
                {
                    case 1:
                        return "L";
                    case 2:
                        return "B";
                    case 3:
                        return "BL";
                    default:
                        return "";
                }
            }
        }

        public string TripComment
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.TRIP_COMMENT + _index);
            }
        }

        public string Weight
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.WEIGHT + _index);
            }
        }

        public bool IsMSW
        {
            get
            {
                if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
                {
                    return true;
                }
                else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
                {
                    return true;
                }
                else if (RaceClassification.ToUpper().IndexOf("MSW") >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsMCL
        {
            get
            {
                if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
                {
                    return false;
                }
                else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
                {
                    return false;
                }
                else if (RaceClassification.ToUpper().IndexOf("MD") >= 0)
                {
                    return true;
                }
                else if (RaceClassification.ToUpper().IndexOf("MCL") >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string RaceClassification
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.RACE_CLASSIFICATION + _index).ToLower();
                return s.Replace("clm", "Clm").Replace("alw", "Alw").Replace("hcp", "Hcp").Replace("md", "Md").Replace("Mdspwt", "MdSpWt").Replace("oc", "OC");
            }
        }

        public double ClaimingPrice
        {
            get
            {
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.CLAIMING_PRICE + _index);
            }
        }

        public double MaxClaimingPriceOfTheRace
        {
            get
            {
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.MAX_CLAIMING_PRICE_OF_THE_RACE + _index);
            }
        }

        public SurfaceType SurfaceAndDistanceType
        {
            get
            {
                return _surfaceType;
            }
        }

        public bool AboutDistanceFlag
        {
            get
            {
                int yards = Utilities.GetFieldAsInteger(_dr, FieldIndex.DISTANCE + _index);
                return yards < 0;
            }
        }

        public string Surface
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    return "";
                }
                else if (s[0] == 'D')
                {
                    return "";
                }
                else if (s[0] == 'T')
                {
                    return "T";
                }
                else if (s[0] == 'd')
                {
                    return "id";
                }
                else if (s[0] == 't')
                {
                    return "iT";
                }
                else if (s[0] == 's')
                {
                    return "s";
                }
                else if (s[0] == 'h')
                {
                    return "h";
                }
                else
                {
                    return "";
                }
            }
        }

        public string AdjustedLeadersFirstCall(double diff)
        {
            try
            {
                double t = Utilities.GetFieldAsDouble(_dr, FieldIndex.FIRST_FRACTION + _index);
                return Utilities.ConvertTimeToMMSSFifth(string.Format("{0:0.0000}", t + diff));
            }
            catch
            {
                return "N/A";
            }
        }

        public string AdjustedLeadersSecondCall(double diff)
        {
            try
            {
                double t = Utilities.GetFieldAsDouble(_dr, FieldIndex.SECOND_FRACTION + _index);
                return Utilities.ConvertTimeToMMSSFifth(string.Format("{0:0.0000}", t + diff));
            }
            catch
            {
                return "N/A";
            }
        }

        public string AdjustedLeadersThirdCall(double diff)
        {
            try
            {
                double t = Utilities.GetFieldAsDouble(_dr, FieldIndex.THIRD_FRACTION + _index);
                return Utilities.ConvertTimeToMMSSFifth(string.Format("{0:0.0000}", t + diff));
            }
            catch
            {
                return "N/A";
            }
        }

        public string AdjustedLeadersFinalCall(double diff)
        {
            try
            {
                double t = Utilities.GetFieldAsDouble(_dr, FieldIndex.FINAL_TIME + _index);
                return Utilities.ConvertTimeToMMSSFifth(string.Format("{0:0.0000}", t + diff));
            }
            catch
            {
                return "N/A";
            }
        }

        public string LeadersFirstCall
        {
            get
            {
                return Utilities.ConvertTimeToMMSSFifth(Utilities.GetFieldAsString(_dr, FieldIndex.FIRST_FRACTION + _index));
            }
        }

        public string LeadersSecondCall
        {
            get
            {
                return Utilities.ConvertTimeToMMSSFifth(Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_FRACTION + _index));
            }
        }

        public string LeadersThirdCall
        {
            get
            {
                return Utilities.ConvertTimeToMMSSFifth(Utilities.GetFieldAsString(_dr, FieldIndex.THIRD_FRACTION + _index));
            }
        }

        public string LeadersFinalCall
        {
            get
            {
                return Utilities.ConvertTimeToMMSSFifth(Utilities.GetFieldAsString(_dr, FieldIndex.FINAL_TIME + _index));
            }
        }

        public string RaceNumber
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.RACE_NUMBER + _index);
            }
        }

        public FractionCall GetFraction(FractionCall.Level fractionLevel)
        {
            return _fraction[fractionLevel];
        }

        public DateTime Date
        {
            get
            {
                try
                {
                    string d = Utilities.GetFieldAsString(_dr, FieldIndex.DATE + _index);
                    int year = Convert.ToInt32(d.Substring(0, 4));
                    int month = Convert.ToInt32(d.Substring(4, 2));
                    int day = Convert.ToInt32(d.Substring(6, 2));
                    return new DateTime(year, month, day);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }

        public string DateAsString
        {
            get
            {
                {
                    string d = Utilities.GetFieldAsString(_dr, FieldIndex.DATE + _index);

                    if (d.Length <= 0)
                    {
                        return d;
                    }
                    else
                    {
                        int year = Convert.ToInt32(d.Substring(0, 4));
                        int month = Convert.ToInt32(d.Substring(4, 2));
                        int day = Convert.ToInt32(d.Substring(6, 2));

                        if (day < 10)
                        {
                            return " " + day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                        }
                        else
                        {
                            return day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                        }
                    }
                }
            }
        }

        public string TrackCode
        {
            get
            {
                string rt = Utilities.GetFieldAsString(_dr, FieldIndex.RACE_TRACK + _index);
                if (rt.Length <= 2)
                {
                    return rt + " ";
                }
                else
                {
                    return Utilities.CapitalizeOnlyFirstLetter(rt);
                }
            }
        }

        public string DistanceAbreviation
        {
            get
            {
                int yards = Utilities.GetFieldAsInteger(_dr, FieldIndex.DISTANCE + _index);
                return Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards >= 0 ? yards : (-1)*yards);
            }
        }

        public bool IsSynthetic
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    return false;
                }
                else if (s[0] == 'S' || s[0] == 's')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsATurfRace
        {
            get
            {
                return _isATurfRace;
            }
        }

        public bool WasTheWinner
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.MONEY_POSITION + _index) == 1;
            }
        }

        public bool IsARoute
        {
            get
            {
                return ((double) DistanceInYards) >= Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;
            }
        }

        public bool IsASprint
        {
            get
            {
                return ((double) DistanceInYards) < Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;
            }
        }

        public int DistanceInYards
        {
            get
            {
                int yards = Utilities.GetFieldAsInteger(_dr, FieldIndex.DISTANCE + _index);
                return yards > 0 ? yards : (-1)*yards;
            }
        }

        public string Distance
        {
            get
            {
                int d = DistanceInYards;

                if (d < 0)
                {
                    d = (-1)*d;
                }

                if (d == 0)
                {
                    return "";
                }

                return Utilities.ConvertYardsToMilesOrFurlongs(d);
            }
        }

        public string ExtraCommentLine
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.EXTRA_COMMENT_LINE + _index);
            }
        }

        public string WinnersName
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.WINNERS_NAME + _index);
            }
        }

        public string SecondPlaceFinisherName
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_PLACE_FINISHER_NAME + _index);
            }
        }

        public string ThirdPlaceFinisherName
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.THIRD_PLACE_FINISHER_NAME + _index);
            }
        }

        public string WinnersWeight
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.WINNERS_WEIGHT + _index);
            }
        }

        public string SecondPlaceFinisherWeight
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.SECOND_PLACE_FINISHER_WEIGHT + _index);
            }
        }

        public string ThirdPlaceFinisherWeight
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.THIRD_PLACE_FINISHER_WEIGHT + _index);
            }
        }

        public double ThisHorseFinalTime
        {
            get
            {
                try
                {
                    double winnersTime = WinnersFinalTime;
                    if (WasTheWinner)
                    {
                        return winnersTime;
                    }
                    else
                    {
                        return _fraction[FractionCall.Level.Final].Time;
                    }
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WinnersFinalTime
        {
            get
            {
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.FINAL_TIME + _index);
            }
        }
    }
}