// *************************************************************
// 
//                           Written By John Pazarzis
// 
// *************************************************************
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Hogar.Parsing;
using Hogar;
using System.Data;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar.Cynthia;

namespace Hogar.BrisPastPerformances
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
        private ParsableText _pt = null;
        private Tokenizer _tokenizer;
        private readonly int _index;
        private Dictionary<FractionCall.Level, FractionCall> _fraction = new Dictionary<FractionCall.Level, FractionCall>();

        private readonly string _brisRaceShapeFirstCall;
        private readonly string _brisRaceShapeSecondCall;
        private readonly double _thirdFractionInYards;
        private readonly double _secondFractionInYards;
        private readonly double _firstFractionInYards;
        private readonly string _firstCallPosition;
        private readonly string _firstCallDistanceFromLeader;
        private readonly string _secondCallPosition;
        private readonly string _secondCallDistanceFromLeader;
        private readonly string _stretchCallPosition;
        private readonly string _stretchCallDistanceFromLeader;
        private readonly int _daysSinceLastRace;
        private readonly int _brisEarlyPace;
        private readonly int _brisLatePace;
        private readonly double _brisRaceRating;
        private readonly double _brisClassRating;
        private readonly int _brisSpeedRatingAsInteger;
        private readonly string _brisSpeedRating;
        private readonly string _finalPosition;
        private readonly double _rawFinalCallDistanceFromLeader;
        private readonly string _finalCallDistanceFromLeader;
        private readonly string _trackCondition;
        private readonly string _numberOfEntrants;
        private readonly string _postPosition;
        private readonly string _startCallPosition;
        private readonly string _jockey;
        private readonly string _ageSexRestrictions;
        private readonly string _raceType;
        private readonly double _maxClaimingPriceOfTheRace;
        private readonly bool _wasTheFavorite;
        private readonly string _odds;
        private readonly string _equipment;
        private readonly string _medication;
        private readonly string _tripComment;
        private readonly string _weight;
        private readonly bool _isMSW;
        private readonly bool _isMCL;
        private readonly string _raceClassification;
        private readonly double _claimingPrice;
        private readonly string _surface;
        private readonly string _leadersFirstCall;
        private readonly string _leadersSecondCall;
        private readonly string _leadersThirdCall;
        private readonly string _leadersFinalCall;
        private readonly string _raceNumber;
        private readonly DateTime _date;
        private readonly string _dateAsString;
        private readonly string _raceTrack;
        private readonly string _distanceAbreviation;
        private readonly bool _aboutDistanceFlag;
        private readonly SurfaceType _surfaceType;
        private readonly bool _isATurfRace;
        private readonly bool _isSynthetic;
        private readonly bool _wasTheWinner;
        private readonly bool _isARoute;
        private readonly bool _isASprint;
        private readonly int _distanceInYards;
        private readonly string _distance;
        private readonly bool _isValid;
        private readonly bool _stateBredRestrictedRace;

        private double _cynthiaFigure = 0;
        private double _cynthiaFigureForTheWinner = 0;

        private int _avgVariant = -9999;

        private bool _needsToLoadCynthiaFigures = true;

        private CynthiaPar _cynthiaParForTheRace = null;
        private double _adjustedFirstCall = 0.0;
        private double _adjustedSecondCall = 0.0;
        private double _adjustedFinalCall = 0.0;

        private bool _needsToCalculateAdjustedCalls = true;

        private PaceFigure _paceFigure;

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

            public double FirstCall { get { return _firstCall; } }

            public double SecondCall { get { return _secondCall; } }

            public double FinalCall { get { return _finalCall; } }
        }

        #endregion

        public bool NeedsToCalculateAdjustedCalls { get { return _needsToCalculateAdjustedCalls; } set { _needsToCalculateAdjustedCalls = value; } }

        public CynthiaPar CynthiaParForTheRace
        {
            get
            {
                if (null == _cynthiaParForTheRace)
                {
                    string cynthiaClass = this.Parent.Parent.CorrespondingRace.CynthiaClassification;
                    _cynthiaParForTheRace = CynthiaPar.Make(_raceTrack, SurfaceToUseForCynthiaPars, _distanceInYards, cynthiaClass, 'N');
                }

                return _cynthiaParForTheRace;
            }
        }

        public void ReloadCynthiaParForTheRace()
        {
            _cynthiaParForTheRace = null;
        }

        public bool IsStateBredRestrictedRace { get { return _stateBredRestrictedRace; } }

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
                string s = _raceClassification.ToUpper();
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

        private bool _needsToLoadGoldenFigure = true;

        private double _goldenTrackVariant = -999.0;
        private double _goldenFigureForTheWinnerOfTheRace = -999.0;
        private double _goldenFigureForThisHorse = -999.0;
        private double _goldenPaceFigureForRace = -999.0;
        private double _goldenPaceFigureForThisHorse = -999.0;

        public double GoldenTrackVariant
        {
            get
            {
                if (_needsToLoadGoldenFigure)
                {
                    LoadGoldenFigures();
                }

                return _goldenTrackVariant != -999 ? (int) (_goldenTrackVariant*5.0) : _goldenTrackVariant;
            }
        }

        public double GoldenPaceFigureForThisHorse
        {
            get
            {
                if (_needsToLoadGoldenFigure)
                {
                    LoadGoldenFigures();
                }

                return (int) _goldenPaceFigureForThisHorse;
            }
        }

        public double GoldenPaceFigureForTheRace
        {
            get
            {
                if (_needsToLoadGoldenFigure)
                {
                    LoadGoldenFigures();
                }

                return (int) _goldenPaceFigureForRace;
            }
        }

        public double GoldenFigureForTheWinner
        {
            get
            {
                if (_needsToLoadGoldenFigure)
                {
                    LoadGoldenFigures();
                }

                return (int) _goldenFigureForTheWinnerOfTheRace;
            }
        }

        public double GoldenFigureForThisHorse
        {
            get
            {
                if (_needsToLoadGoldenFigure)
                {
                    LoadGoldenFigures();
                }

                return (int) _goldenFigureForThisHorse;
            }
        }

        private void LoadGoldenTrackVariant()
        {
            _goldenTrackVariant = -999;

            if (!IsATurfRace)
            {
                using (var dbr = new DbReader())
                {
                    string sql = string.Format("select  dbo.GetGoldenTrackVariant ('{0}','{1}' )   'GoldenTrackVariant' ", TrackCode, Utilities.GetDateInYYYYMMDD(Date));
                    if (dbr.Open(sql))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            _goldenTrackVariant = dbr.GetValue<double>("GoldenTrackVariant");
                        }
                    }
                }
            }
        }

        private void LoadGolendPaceFigureForThisHorse()
        {
            _goldenPaceFigureForThisHorse = -999;
            if (!IsATurfRace)
            {
                using (var dbr = new DbReader())
                {
                    int raceNumber = 0;
                    if (int.TryParse(RaceNumber, out raceNumber))
                    {
                        string sql = string.Format("select  dbo.GetGoldenPaceFigureForSpecificStarter ('{0}','{1}',{2}, '{3}')   'GoldenPaceFigure' ", TrackCode, Utilities.GetDateInYYYYMMDD(Date), raceNumber, this.Parent.Name);

                        if (dbr.Open(sql))
                        {
                            while (dbr.MoveToNextRow())
                            {
                                _goldenPaceFigureForThisHorse = dbr.GetValue<double>("GoldenPaceFigure");
                            }
                        }
                    }
                }
            }
        }

        private void LoadGolendPaceFigureForTheRace()
        {
            _goldenPaceFigureForRace = -999;
            if (!IsATurfRace)
            {
                using (var dbr = new DbReader())
                {
                    int raceNumber = 0;
                    if (int.TryParse(RaceNumber, out raceNumber))
                    {
                        string sql = string.Format("select  dbo.GetGoldenPaceFigureForRace ('{0}','{1}',{2})   'GoldenPaceFigure' ", TrackCode, Utilities.GetDateInYYYYMMDD(Date), raceNumber);

                        if (dbr.Open(sql))
                        {
                            while (dbr.MoveToNextRow())
                            {
                                _goldenPaceFigureForRace = dbr.GetValue<double>("GoldenPaceFigure");
                            }
                        }
                    }
                }
            }
        }

        private void LoadGoldenFigures()
        {
            _goldenFigureForTheWinnerOfTheRace = -999.0;
            _goldenFigureForThisHorse = -999.0;

            if (!IsATurfRace)
            {
                using (var dbr = new DbReader())
                {
                    double lengthsBehind = 0.0;

                    string sql = string.Format("select dbo.GoldenSpeedFigure ('{0}', '{1}', {2}, {3}, {4})  'SpeedFigure' ", TrackCode, Utilities.GetDateInYYYYMMDD(Date), WinnersFinalTime, lengthsBehind, DistanceInYards);

                    if (dbr.Open(sql))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            _goldenFigureForTheWinnerOfTheRace = dbr.GetValue<double>("SpeedFigure");
                        }
                    }

                    int finalPosition = 0;

                    int.TryParse(_finalPosition, out finalPosition);

                    if (1 == finalPosition)
                    {
                        _goldenFigureForThisHorse = _goldenFigureForTheWinnerOfTheRace;
                    }
                    else if (0 == finalPosition)
                    {
                        _goldenFigureForThisHorse = -999.0;
                    }
                    else
                    {
                        lengthsBehind = _rawFinalCallDistanceFromLeader;

                        sql = string.Format("select dbo.GoldenSpeedFigure ( '{0}', '{1}', {2}, {3}, {4}) 'SpeedFigure' ", TrackCode, Utilities.GetDateInYYYYMMDD(Date), WinnersFinalTime, lengthsBehind, DistanceInYards);

                        if (dbr.Open(sql))
                        {
                            while (dbr.MoveToNextRow())
                            {
                                _goldenFigureForThisHorse = dbr.GetValue<double>("SpeedFigure");
                            }
                        }
                    }
                }
            }

            LoadGolendPaceFigureForTheRace();
            LoadGolendPaceFigureForThisHorse();
            LoadGoldenTrackVariant();
            _needsToLoadGoldenFigure = false;
        }

        public bool IsDoubleMove
        {
            get
            {
                int p1, p2, p3, p4;

                if (int.TryParse(GetToken(FieldIndex.FIRST_CALL_POSITION + _index), out p1) &&
                    int.TryParse(GetToken(FieldIndex.SECOND_CALL_POSITION + _index), out p2) &&
                    int.TryParse(GetToken(FieldIndex.STRETCH_POSITION + _index), out p3) &&
                    int.TryParse(GetToken(FieldIndex.FINISH_POSITION + _index), out p4))
                {
                    return p1 > p2 && p3 > p4 && p3 > p2;
                }
                else
                {
                    return false;
                }
            }
        }

        public PaceFigure PaceFigure
        {
            get
            {
                if (null == _paceFigure)
                {
                    string date = string.Format("{0:0000}{1:00}{2:00}", _date.Year, _date.Month, _date.Day);

                    int raceNumber = 0;
                    int.TryParse(this._raceNumber, out raceNumber);
                    _paceFigure = BrisPastPerformances.PaceFigure.Make(this.TrackCode, date, raceNumber, this.Parent.Name);
                }
                return _paceFigure;
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
                    double lengthsBehind0 = Convert.ToDouble(GetToken(FieldIndex.FIRST_CALL_LENGTHS + _index));
                    double lengthsBehind1 = Convert.ToDouble(GetToken(FieldIndex.SECOND_CALL_LENGTHS + _index));

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
                        double lengthsBehind = Convert.ToDouble(GetToken(FieldIndex.FIRST_CALL_LENGTHS + _index));

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

        public Sartin SartinFigures { get { return new Sartin(this); } }

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

        public string BrisRaceShapeFirstCall { get { return _brisRaceShapeFirstCall; } }

        public string BrisRaceShapeSecondCall { get { return _brisRaceShapeSecondCall; } }

        public double ThirdFractionInYards { get { return _thirdFractionInYards; } }

        public double SecondFractionInYards { get { return _secondFractionInYards; } }

        public double FirstFractionInYards { get { return _firstFractionInYards; } }

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

            if (fractionTime == StrgToDouble(GetToken(FieldIndex.SIXTEEN_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*16.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.FORTEEN_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*14.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.TWELVE_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*12.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.TEN_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*10.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.EIGHT_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*8.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.SEVEN_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*7.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.SIX_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*6.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.FIVE_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*5.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.FOUR_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*4.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.THREE_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*3.0;
            }
            else if (fractionTime == StrgToDouble(GetToken(FieldIndex.TWO_FULRONGS_FRACTION + _index).Trim()))
            {
                return Utilities.YARDS_IN_A_FURLONG*2.0;
            }
            else
            {
                return 0.0;
            }
        }

        public BrisHorse Parent { get { return _parent; } }

        public override string ToString()
        {
            return "Not Implemented";
        }

        internal BrisPastPerformance(ParsableText pt, int index, BrisHorse parent)
        {
            _pt = pt;
            _index = index;
            _parent = parent;
            _tokenizer = null;

            {
                string d = GetToken(FieldIndex.DATE + _index);

                if (d.Length <= 0)
                {
                    _dateAsString = "";
                    _isValid = false;
                    return;
                }
                else
                {
                    int year = Convert.ToInt32(d.Substring(0, 4));
                    int month = Convert.ToInt32(d.Substring(4, 2));
                    int day = Convert.ToInt32(d.Substring(6, 2));

                    if (day < 10)
                    {
                        _dateAsString = " " + day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                    }
                    else
                    {
                        _dateAsString = day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                    }
                }
            }

            _brisRaceShapeFirstCall = GetToken(FieldIndex.BRIS_RACE_SHAPE_FIRST_CALL + _index).Trim();
            _brisRaceShapeSecondCall = GetToken(FieldIndex.BRIS_RACE_SHAPE_SECOND_CALL + _index).Trim();
            _thirdFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.THIRD_FRACTION + _index).Trim());
            _secondFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.SECOND_FRACTION + _index).Trim());
            _firstFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.FIRST_FRACTION + _index).Trim());
            _firstCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.FIRST_CALL_POSITION + _index));
            _firstCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.FIRST_CALL_LENGTHS + _index));
            _secondCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.SECOND_CALL_POSITION + _index));
            _secondCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.SECOND_CALL_LENGTHS + _index));
            _stretchCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.STRETCH_POSITION + _index));
            _stretchCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.STRETCH_LENGTHS + _index));

            {
                string s = GetToken(FieldIndex.DAYS_SINCE_LAST + _index);

                if (s.Length <= 0)
                {
                    _daysSinceLastRace = 0;
                }
                else
                {
                    _daysSinceLastRace = Convert.ToInt32(s);
                }
            }

            try
            {
                int fieldIndex = IsASprint ? FieldIndex.BRIS_2_FURLONG_PACE_FIGURE : FieldIndex.BRIS_4_FURLONG_PACE_FIGURE;
                string s = GetToken(fieldIndex + _index).Trim();
                _brisEarlyPace = s.Length > 0 ? Convert.ToInt32(s) : 0;
            }
            catch
            {
                _brisEarlyPace = 0;
            }

            try
            {
                string s = GetToken(FieldIndex.BRIS_LATE_PACE_FIGURE + _index).Trim();
                _brisLatePace = s.Length > 0 ? Convert.ToInt32(s) + BrisSpeedRatingAsInteger : 0;
            }
            catch
            {
                _brisLatePace = 0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_RACE_RATING + _index).Trim();
                _brisRaceRating = s.Length > 0 ? Convert.ToDouble(s) : -1.0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_CLASS_RATING + _index).Trim();
                _brisClassRating = s.Length > 0 ? Convert.ToDouble(s) : -1.0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_SPEED_RATING + _index).Trim();
                _brisSpeedRatingAsInteger = s.Length > 0 ? Convert.ToInt32(s) : 0;
            }

            _brisSpeedRating = GetToken(FieldIndex.BRIS_SPEED_RATING + _index);
            _finalPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.FINISH_POSITION + _index));

            {
                string s = GetToken(FieldIndex.FINISH_LENGTHS + _index).Trim();
                _rawFinalCallDistanceFromLeader = s.Length > 0 ? Convert.ToDouble(s) : 0;
            }

            _finalCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.FINISH_LENGTHS + _index));
            _trackCondition = GetToken(FieldIndex.TRACK_CONDITION + _index).ToLower();
            _numberOfEntrants = GetToken(FieldIndex.NUMBER_OF_ENTRANTS + _index);
            _postPosition = GetToken(FieldIndex.POST_POSITION + _index);
            _startCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.START_CALL_POSITION + _index));
            _jockey = Utilities.CapitalizeOnlyFirstLetter((GetToken(FieldIndex.JOCKEY + _index)));
            _raceType = Utilities.CapitalizeOnlyFirstLetter((GetToken(FieldIndex.RACE_TYPE + _index)));
            _ageSexRestrictions = (GetToken(FieldIndex.AGE_SEX_RESTRICTIONS + _index));
            _ageSexRestrictions += "    ";
            {
                string s = GetToken(FieldIndex.FAVORITE_INDICATOR + _index);
                s = s.Trim();
                _wasTheFavorite = s.Length > 0 ? s[0] == '1' : false;
            }

            {
                string s = GetToken(FieldIndex.STATE_BRED_FLAG + _index);
                s = s.Trim().ToUpper();
                _stateBredRestrictedRace = s.Length > 0 ? s[0] == 'S' : false;
            }

            if (WasTheFavorite)
            {
                _odds = "*" + GetToken(FieldIndex.ODDS + _index);
            }
            else
            {
                _odds = GetToken(FieldIndex.ODDS + _index);
            }

            {
                double od = 0;
                double.TryParse(GetToken(FieldIndex.ODDS + _index), out od);
                OddsAsDouble = od;
            }

            _equipment = GetToken(FieldIndex.EQUIPMENT + _index);

            if (null == GetToken(FieldIndex.MEDICATION + _index))
            {
                _medication = "";
            }
            else
            {
                string s = GetToken(FieldIndex.MEDICATION + _index).Trim();
                if (s.Length <= 0)
                {
                    _medication = "";
                }
                else
                {
                    switch (Convert.ToInt32(GetToken(FieldIndex.MEDICATION + _index)))
                    {
                        case 1:
                            _medication = "L";
                            break;
                        case 2:
                            _medication = "B";
                            break;
                        case 3:
                            _medication = "BL";
                            break;
                        default:
                            _medication = "";
                            break;
                    }
                }
            }

            _tripComment = GetToken(FieldIndex.TRIP_COMMENT + _index);
            _weight = GetToken(FieldIndex.WEIGHT + _index);

            _raceClassification = GetToken(FieldIndex.RACE_CLASSIFICATION + _index).ToLower();
            _raceClassification = _raceClassification.Replace("clm", "Clm").Replace("alw", "Alw").Replace("hcp", "Hcp").Replace("md", "Md").Replace("Mdspwt", "MdSpWt").Replace("oc", "OC");
            {
                string p = GetToken(FieldIndex.CLAIMING_PRICE + _index).Trim();
                _claimingPrice = p.Length > 0 ? Convert.ToDouble(p) : 0.0;
            }

            {
                string p = GetToken(FieldIndex.MAX_CLAIMING_PRICE_OF_THE_RACE + _index).Trim();
                _maxClaimingPriceOfTheRace = p.Length > 0 ? Convert.ToDouble(p) : 0.0;
            }

            if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
            {
                _isMSW = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
            {
                _isMSW = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MSW") >= 0)
            {
                _isMSW = true;
            }
            else
            {
                _isMSW = false;
            }

            if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
            {
                _isMCL = false;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
            {
                _isMCL = false;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD") >= 0)
            {
                _isMCL = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MCL") >= 0)
            {
                _isMCL = true;
            }
            else
            {
                _isMCL = false;
            }

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    _surface = "";
                }
                else if (s[0] == 'D')
                {
                    _surface = "";
                }
                else if (s[0] == 'T')
                {
                    _surface = "T";
                }
                else if (s[0] == 'd')
                {
                    _surface = "id";
                }
                else if (s[0] == 't')
                {
                    _surface = "iT";
                }
                else if (s[0] == 's')
                {
                    _surface = "s";
                }
                else if (s[0] == 'h')
                {
                    _surface = "h";
                }
                else
                {
                    _surface = "";
                }
            }

            {
                string rn = GetToken(FieldIndex.RACE_NUMBER + _index);
                _raceNumber = rn.Length <= 1 ? " " + rn : rn;
            }

            try
            {
                string d = GetToken(FieldIndex.DATE + _index).Trim();

                int year = Convert.ToInt32(d.Substring(0, 4));
                int month = Convert.ToInt32(d.Substring(4, 2));
                int day = Convert.ToInt32(d.Substring(6, 2));
                _date = new DateTime(year, month, day);
            }
            catch
            {
                _date = DateTime.Now;
            }

            {
                string rt = GetToken(FieldIndex.RACE_TRACK + _index);
                if (rt.Length <= 2)
                {
                    _raceTrack = rt + " ";
                }
                else
                {
                    _raceTrack = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.RACE_TRACK + _index));
                }
            }

            {
                string s = GetToken(FieldIndex.DISTANCE + _index);
                _aboutDistanceFlag = false;

                if (s.Length <= 0)
                {
                    _distanceAbreviation = "Invalid";
                }
                else
                {
                    int yards = Convert.ToInt32(GetToken(FieldIndex.DISTANCE + _index));
                    if (yards < 0)
                    {
                        _aboutDistanceFlag = true;
                        yards = (-1)*yards;
                    }

                    _distanceAbreviation = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards);
                }
            }

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
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

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    _isSynthetic = false;
                }
                else if (s[0] == 'S' || s[0] == 's')
                {
                    _isSynthetic = true;
                }
                else
                {
                    _isSynthetic = false;
                }
            }

            {
                string s = GetToken(FieldIndex.MONEY_POSITION + _index);
                try
                {
                    int p = Convert.ToInt32(s.Trim());
                    _wasTheWinner = (p == 1);
                }
                catch
                {
                    _wasTheWinner = false;
                }
            }

            {
                string s = GetToken(FieldIndex.DISTANCE + _index).Trim();
                _distanceInYards = s.Length > 0 ? Convert.ToInt32(s) : 0;

                if (_distanceInYards < 0)
                    _distanceInYards = (-1)*_distanceInYards;
            }

            _isARoute = ((double) DistanceInYards) >= Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;
            _isASprint = ((double) DistanceInYards) < Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;

            {
                if (GetToken(FieldIndex.DISTANCE + _index).Trim().Length > 0)
                {
                    _distance = Utilities.ConvertYardsToMilesOrFurlongs(_distanceInYards);
                }
                else
                {
                    _distance = "";
                }
            }

            _leadersFirstCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.FIRST_FRACTION + _index));
            _leadersSecondCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.SECOND_FRACTION + _index));
            _leadersThirdCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.THIRD_FRACTION + _index));
            _leadersFinalCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.FINAL_TIME + _index));

            _fraction[FractionCall.Level.First] = FractionCall.Make(_pt.Tokens, _firstFractionInYards, FieldIndex.FIRST_CALL_POSITION + _index, FieldIndex.FIRST_FRACTION + _index, FieldIndex.FIRST_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Second] = FractionCall.Make(_pt.Tokens, _secondFractionInYards, FieldIndex.START_CALL_POSITION + _index, FieldIndex.SECOND_FRACTION + _index, FieldIndex.SECOND_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Stretch] = FractionCall.Make(_pt.Tokens, _thirdFractionInYards, FieldIndex.STRETCH_POSITION + _index, FieldIndex.THIRD_FRACTION + _index, FieldIndex.STRETCH_LENGTHS + _index);
            _fraction[FractionCall.Level.Final] = FractionCall.Make(_pt.Tokens, _distanceInYards, FieldIndex.FINISH_POSITION + _index, FieldIndex.FINAL_TIME + _index, FieldIndex.FINISH_LENGTHS + _index);

            _isValid = true;
        }

        private string GetToken(int index)
        {
            if (null != _tokenizer)
            {
                string s = _tokenizer[index];
                s = s.Replace("\"", "");
                return s;
            }
            else
            {
                return _pt.Tokens[index].ToString();
            }
        }

        internal BrisPastPerformance(Tokenizer tokenizer, int index, BrisHorse parent)
        {
            _pt = null;
            _index = index;
            _parent = parent;
            _tokenizer = tokenizer;

            {
                string d = GetToken(FieldIndex.DATE + _index);

                if (d.Length <= 0)
                {
                    _dateAsString = "";
                    _isValid = false;
                    return;
                }
                else
                {
                    int year = Convert.ToInt32(d.Substring(0, 4));
                    int month = Convert.ToInt32(d.Substring(4, 2));
                    int day = Convert.ToInt32(d.Substring(6, 2));

                    if (day < 10)
                    {
                        _dateAsString = " " + day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                    }
                    else
                    {
                        _dateAsString = day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
                    }
                }
            }

            _brisRaceShapeFirstCall = GetToken(FieldIndex.BRIS_RACE_SHAPE_FIRST_CALL + _index).Trim();
            _brisRaceShapeSecondCall = GetToken(FieldIndex.BRIS_RACE_SHAPE_SECOND_CALL + _index).Trim();
            _thirdFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.THIRD_FRACTION + _index).Trim());
            _secondFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.SECOND_FRACTION + _index).Trim());
            _firstFractionInYards = GetFractionInYardsUsingItsTiming(GetToken(FieldIndex.FIRST_FRACTION + _index).Trim());
            _firstCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.FIRST_CALL_POSITION + _index));
            _firstCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.FIRST_CALL_LENGTHS + _index));
            _secondCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.SECOND_CALL_POSITION + _index));
            _secondCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.SECOND_CALL_LENGTHS + _index));
            _stretchCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.STRETCH_POSITION + _index));
            _stretchCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.STRETCH_LENGTHS + _index));

            {
                string s = GetToken(FieldIndex.DAYS_SINCE_LAST + _index);

                if (s.Length <= 0)
                {
                    _daysSinceLastRace = 0;
                }
                else
                {
                    _daysSinceLastRace = Convert.ToInt32(s);
                }
            }

            try
            {
                int fieldIndex = IsASprint ? FieldIndex.BRIS_2_FURLONG_PACE_FIGURE : FieldIndex.BRIS_4_FURLONG_PACE_FIGURE;
                string s = GetToken(fieldIndex + _index).Trim();
                _brisEarlyPace = s.Length > 0 ? Convert.ToInt32(s) : 0;
            }
            catch
            {
                _brisEarlyPace = 0;
            }

            try
            {
                string s = GetToken(FieldIndex.BRIS_LATE_PACE_FIGURE + _index).Trim();
                _brisLatePace = s.Length > 0 ? Convert.ToInt32(s) + BrisSpeedRatingAsInteger : 0;
            }
            catch
            {
                _brisLatePace = 0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_RACE_RATING + _index).Trim();
                _brisRaceRating = s.Length > 0 ? Convert.ToDouble(s) : -1.0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_CLASS_RATING + _index).Trim();
                _brisClassRating = s.Length > 0 ? Convert.ToDouble(s) : -1.0;
            }

            {
                string s = GetToken(FieldIndex.BRIS_SPEED_RATING + _index).Trim();
                _brisSpeedRatingAsInteger = s.Length > 0 ? Convert.ToInt32(s) : 0;
            }

            _brisSpeedRating = GetToken(FieldIndex.BRIS_SPEED_RATING + _index);
            _finalPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.FINISH_POSITION + _index));

            {
                string s = GetToken(FieldIndex.FINISH_LENGTHS + _index).Trim();
                _rawFinalCallDistanceFromLeader = s.Length > 0 ? Convert.ToDouble(s) : 0;
            }

            _finalCallDistanceFromLeader = ConvertToDistanceFraction(GetToken(FieldIndex.FINISH_LENGTHS + _index));
            _trackCondition = GetToken(FieldIndex.TRACK_CONDITION + _index).ToLower();
            _numberOfEntrants = GetToken(FieldIndex.NUMBER_OF_ENTRANTS + _index);
            _postPosition = GetToken(FieldIndex.POST_POSITION + _index);
            _startCallPosition = ConvertNonNumericPositionToZero(GetToken(FieldIndex.START_CALL_POSITION + _index));
            _jockey = Utilities.CapitalizeOnlyFirstLetter((GetToken(FieldIndex.JOCKEY + _index)));
            _raceType = Utilities.CapitalizeOnlyFirstLetter((GetToken(FieldIndex.RACE_TYPE + _index)));
            _ageSexRestrictions = (GetToken(FieldIndex.AGE_SEX_RESTRICTIONS + _index));
            _ageSexRestrictions += "    ";
            {
                string s = GetToken(FieldIndex.FAVORITE_INDICATOR + _index);
                s = s.Trim();
                _wasTheFavorite = s.Length > 0 ? s[0] == '1' : false;
            }

            {
                string s = GetToken(FieldIndex.STATE_BRED_FLAG + _index);
                s = s.Trim().ToUpper();
                _stateBredRestrictedRace = s.Length > 0 ? s[0] == 'S' : false;
            }

            if (WasTheFavorite)
            {
                _odds = "*" + GetToken(FieldIndex.ODDS + _index);
            }
            else
            {
                _odds = GetToken(FieldIndex.ODDS + _index);
            }

            {
                double od = 0;
                double.TryParse(GetToken(FieldIndex.ODDS + _index), out od);
                OddsAsDouble = od;
            }

            _equipment = GetToken(FieldIndex.EQUIPMENT + _index);

            if (null == GetToken(FieldIndex.MEDICATION + _index))
            {
                _medication = "";
            }
            else
            {
                string s = GetToken(FieldIndex.MEDICATION + _index).Trim();
                if (s.Length <= 0)
                {
                    _medication = "";
                }
                else
                {
                    switch (Convert.ToInt32(GetToken(FieldIndex.MEDICATION + _index)))
                    {
                        case 1:
                            _medication = "L";
                            break;
                        case 2:
                            _medication = "B";
                            break;
                        case 3:
                            _medication = "BL";
                            break;
                        default:
                            _medication = "";
                            break;
                    }
                }
            }

            _tripComment = GetToken(FieldIndex.TRIP_COMMENT + _index);
            _weight = GetToken(FieldIndex.WEIGHT + _index);

            _raceClassification = GetToken(FieldIndex.RACE_CLASSIFICATION + _index).ToLower();
            _raceClassification = _raceClassification.Replace("clm", "Clm").Replace("alw", "Alw").Replace("hcp", "Hcp").Replace("md", "Md").Replace("Mdspwt", "MdSpWt").Replace("oc", "OC");
            {
                string p = GetToken(FieldIndex.CLAIMING_PRICE + _index).Trim();
                _claimingPrice = p.Length > 0 ? Convert.ToDouble(p) : 0.0;
            }

            {
                string p = GetToken(FieldIndex.MAX_CLAIMING_PRICE_OF_THE_RACE + _index).Trim();
                _maxClaimingPriceOfTheRace = p.Length > 0 ? Convert.ToDouble(p) : 0.0;
            }

            if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
            {
                _isMSW = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
            {
                _isMSW = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MSW") >= 0)
            {
                _isMSW = true;
            }
            else
            {
                _isMSW = false;
            }

            if (RaceClassification.ToUpper().IndexOf("MDSPWT") >= 0)
            {
                _isMCL = false;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD SP WT") >= 0)
            {
                _isMCL = false;
            }
            else if (RaceClassification.ToUpper().IndexOf("MD") >= 0)
            {
                _isMCL = true;
            }
            else if (RaceClassification.ToUpper().IndexOf("MCL") >= 0)
            {
                _isMCL = true;
            }
            else
            {
                _isMCL = false;
            }

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    _surface = "";
                }
                else if (s[0] == 'D')
                {
                    _surface = "";
                }
                else if (s[0] == 'T')
                {
                    _surface = "T";
                }
                else if (s[0] == 'd')
                {
                    _surface = "id";
                }
                else if (s[0] == 't')
                {
                    _surface = "iT";
                }
                else if (s[0] == 's')
                {
                    _surface = "s";
                }
                else if (s[0] == 'h')
                {
                    _surface = "h";
                }
                else
                {
                    _surface = "";
                }
            }

            {
                string rn = GetToken(FieldIndex.RACE_NUMBER + _index);
                _raceNumber = rn.Length <= 1 ? " " + rn : rn;
            }

            try
            {
                string d = GetToken(FieldIndex.DATE + _index).Trim();

                int year = Convert.ToInt32(d.Substring(0, 4));
                int month = Convert.ToInt32(d.Substring(4, 2));
                int day = Convert.ToInt32(d.Substring(6, 2));
                _date = new DateTime(year, month, day);
            }
            catch
            {
                _date = DateTime.Now;
            }

            {
                string rt = GetToken(FieldIndex.RACE_TRACK + _index);
                if (rt.Length <= 2)
                {
                    _raceTrack = rt + " ";
                }
                else
                {
                    _raceTrack = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.RACE_TRACK + _index));
                }
            }

            {
                string s = GetToken(FieldIndex.DISTANCE + _index);
                _aboutDistanceFlag = false;

                if (s.Length <= 0)
                {
                    _distanceAbreviation = "Invalid";
                }
                else
                {
                    int yards = Convert.ToInt32(GetToken(FieldIndex.DISTANCE + _index));
                    if (yards < 0)
                    {
                        _aboutDistanceFlag = true;
                        yards = (-1)*yards;
                    }

                    _distanceAbreviation = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards);
                }
            }

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
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

            {
                string s = GetToken(FieldIndex.SURFACE + _index);
                if (s.Length <= 0)
                {
                    _isSynthetic = false;
                }
                else if (s[0] == 'S' || s[0] == 's')
                {
                    _isSynthetic = true;
                }
                else
                {
                    _isSynthetic = false;
                }
            }

            {
                string s = GetToken(FieldIndex.MONEY_POSITION + _index);
                try
                {
                    int p = Convert.ToInt32(s.Trim());
                    _wasTheWinner = (p == 1);
                }
                catch
                {
                    _wasTheWinner = false;
                }
            }

            {
                string s = GetToken(FieldIndex.DISTANCE + _index).Trim();
                _distanceInYards = s.Length > 0 ? Convert.ToInt32(s) : 0;

                if (_distanceInYards < 0)
                    _distanceInYards = (-1)*_distanceInYards;
            }

            _isARoute = ((double) DistanceInYards) >= Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;
            _isASprint = ((double) DistanceInYards) < Hogar.Utilities.MIN_DISTANCE_FOR_ROUTE;

            {
                if (GetToken(FieldIndex.DISTANCE + _index).Trim().Length > 0)
                {
                    _distance = Utilities.ConvertYardsToMilesOrFurlongs(_distanceInYards);
                }
                else
                {
                    _distance = "";
                }
            }

            _leadersFirstCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.FIRST_FRACTION + _index));
            _leadersSecondCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.SECOND_FRACTION + _index));
            _leadersThirdCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.THIRD_FRACTION + _index));
            _leadersFinalCall = Utilities.ConvertTimeToMMSSFifth(GetToken(FieldIndex.FINAL_TIME + _index));

            _fraction[FractionCall.Level.First] = FractionCall.Make(tokenizer, _firstFractionInYards, FieldIndex.FIRST_CALL_POSITION + _index, FieldIndex.FIRST_FRACTION + _index, FieldIndex.FIRST_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Second] = FractionCall.Make(tokenizer, _secondFractionInYards, FieldIndex.START_CALL_POSITION + _index, FieldIndex.SECOND_FRACTION + _index, FieldIndex.SECOND_CALL_LENGTHS + _index);
            _fraction[FractionCall.Level.Stretch] = FractionCall.Make(tokenizer, _thirdFractionInYards, FieldIndex.STRETCH_POSITION + _index, FieldIndex.THIRD_FRACTION + _index, FieldIndex.STRETCH_LENGTHS + _index);
            _fraction[FractionCall.Level.Final] = FractionCall.Make(tokenizer, _distanceInYards, FieldIndex.FINISH_POSITION + _index, FieldIndex.FINAL_TIME + _index, FieldIndex.FINISH_LENGTHS + _index);

            _isValid = true;
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

        public string FirstCallPosition { get { return _firstCallPosition; } }

        public string FirstCallDistanceFromLeader { get { return _firstCallDistanceFromLeader; } }

        public string SecondCallPosition { get { return _secondCallPosition; } }

        public string SecondCallDistanceFromLeader { get { return _secondCallDistanceFromLeader; } }

        public string StretchCallPosition { get { return _stretchCallPosition; } }

        public string StretchCallDistanceFromLeader { get { return _stretchCallDistanceFromLeader; } }

        public int DaysSinceLastRace { get { return _daysSinceLastRace; } }

        public int DaysSinceThatRace
        {
            get
            {
                DateTime todaysDate = _parent.Parent.Parent.GetFullDate();
                TimeSpan span = todaysDate - Date;

                return span.Days;
            }
        }

        public int BrisComposite { get { return BrisEarlyPace + BrisLatePace; } }

        public int BrisEarlyPace { get { return _brisEarlyPace; } }

        public int BrisLatePace { get { return _brisLatePace; } }

        private double InterpolateValue(double min, double max, double v)
        {
            return max - min != 0.0 ? 10.0*(v - min)/(max - min) : 0.0;
        }

        private double CynthiaFigure
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

        private double CynthiaFigureForTheWinner
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

        public double InterpolatedSpeedFigure { get { return InterpolateValue(_parent.Parent.MinSpeedFigure, _parent.Parent.MaxSpeedFigure, (double) _brisSpeedRatingAsInteger); } }

        public double InterpolatedRaceRating { get { return InterpolateValue(_parent.Parent.MinRaceRating, _parent.Parent.MaxRaceRating, _brisRaceRating); } }

        public double InterpolatedClassRating { get { return InterpolateValue(_parent.Parent.MinClassRating, _parent.Parent.MaxClassRating, _brisClassRating); } }

        public double BrisRaceRating { get { return _brisRaceRating; } }

        public double BrisClassRating { get { return _brisClassRating; } }

        public int BrisSpeedRatingAsInteger { get { return _brisSpeedRatingAsInteger; } }

        public double CustomTrackVariant { get { return Hogar.TrackVariant.Singleton.GetVariant(this.TrackCode, this.Date); } }

        public int TrackVariant
        {
            get
            {
                string s = GetToken(FieldIndex.TRACK_VARIANT + _index);
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

        public int BrisSpeedRating
        {
            get
            {
                int rating = 0;
                int.TryParse(_brisSpeedRating, out rating);
                return rating;
            }
        }

        public string FinalPosition { get { return _finalPosition; } }

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

        public double RawFinalCallDistanceFromLeader { get { return _rawFinalCallDistanceFromLeader; } }

        public string FinalCallDistanceFromLeader { get { return _finalCallDistanceFromLeader; } }

        public bool IsValid { get { return _isValid; } }

        public string TrackCondition { get { return _trackCondition; } }

        public string NumberOfEntrants { get { return _numberOfEntrants; } }

        public string PostPosition { get { return _postPosition; } }

        public string StartCallPosition { get { return _startCallPosition; } }

        public string Jockey { get { return _jockey; } }

        public string AgeSexRestrictions { get { return _ageSexRestrictions; } }

        public string RaceType { get { return _raceType; } }

        public bool WasTheFavorite { get { return _wasTheFavorite; } }

        public string Odds { get { return _odds; } }

        public double OddsAsDouble { get; private set; }

        public string Equipment { get { return _equipment; } }

        public string Medication { get { return _medication; } }

        public string TripComment { get { return _tripComment; } }

        public string Weight { get { return _weight; } }

        public bool IsMSW { get { return _isMSW; } }

        public bool IsMCL { get { return _isMCL; } }

        public string RaceClassification { get { return _raceClassification; } }

        public double ClaimingPrice { get { return _claimingPrice; } }

        public double MaxClaimingPriceOfTheRace { get { return _maxClaimingPriceOfTheRace; } }

        public SurfaceType SurfaceAndDistanceType { get { return _surfaceType; } }

        public bool AboutDistanceFlag { get { return _aboutDistanceFlag; } }

        public string Surface
        {
            get
            {
                if (_surface.Length == 0)
                {
                    return "D";
                }
                return _surface;
            }
        }

        public string AdjustedLeadersFirstCall(double diff)
        {
            try
            {
                double t = Convert.ToDouble(GetToken(FieldIndex.FIRST_FRACTION + _index));
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
                double t = Convert.ToDouble(GetToken(FieldIndex.SECOND_FRACTION + _index));
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
                double t = Convert.ToDouble(GetToken(FieldIndex.THIRD_FRACTION + _index));
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
                double t = Convert.ToDouble(GetToken(FieldIndex.FINAL_TIME + _index));
                return Utilities.ConvertTimeToMMSSFifth(string.Format("{0:0.0000}", t + diff));
            }
            catch
            {
                return "N/A";
            }
        }

        public string LeadersFirstCall { get { return _leadersFirstCall; } }

        public string LeadersSecondCall { get { return _leadersSecondCall; } }

        public string LeadersThirdCall { get { return _leadersThirdCall; } }

        public string LeadersFinalCall { get { return _leadersFinalCall; } }

        public string RaceNumber { get { return _raceNumber; } }

        public FractionCall GetFraction(FractionCall.Level fractionLevel)
        {
            return _fraction[fractionLevel];
        }

        public DateTime Date { get { return _date; } }

        public string DateAsString { get { return _dateAsString; } }

        public string TrackCode { get { return _raceTrack; } }

        public string DistanceAbreviation { get { return _distanceAbreviation; } }

        public bool IsSynthetic { get { return _isSynthetic; } }

        public bool IsATurfRace { get { return _isATurfRace; } }

        public bool WasTheWinner { get { return _wasTheWinner; } }

        public bool IsARoute { get { return _isARoute; } }

        public bool IsASprint { get { return _isASprint; } }

        public int DistanceInYards { get { return _distanceInYards; } }

        public string Distance { get { return _distance; } }

        public string ExtraCommentLine { get { return GetToken(FieldIndex.EXTRA_COMMENT_LINE + _index); } }

        public string WinnersName { get { return GetToken(FieldIndex.WINNERS_NAME + _index).Trim(); } }

        public string SecondPlaceFinisherName { get { return GetToken(FieldIndex.SECOND_PLACE_FINISHER_NAME + _index).Trim(); } }

        public string ThirdPlaceFinisherName { get { return GetToken(FieldIndex.THIRD_PLACE_FINISHER_NAME + _index).Trim(); } }

        public string WinnersWeight { get { return GetToken(FieldIndex.WINNERS_WEIGHT + _index); } }

        public string SecondPlaceFinisherWeight { get { return GetToken(FieldIndex.SECOND_PLACE_FINISHER_WEIGHT + _index); } }

        public string ThirdPlaceFinisherWeight { get { return GetToken(FieldIndex.THIRD_PLACE_FINISHER_WEIGHT + _index); } }

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
                try
                {
                    return Convert.ToDouble(GetToken(FieldIndex.FINAL_TIME + _index).Trim());
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        internal void AppendToXmlNode(XmlDocument doc, XmlElement starter)
        {
            XmlElement pp = doc.CreateElement("PastPerformance");
            pp.SetAttribute("DaysSinceLastRace", this.DaysSinceLastRace.ToString());
            pp.SetAttribute("DaysSinceThisRace", this.DaysSinceThatRace.ToString());
            pp.SetAttribute("Date", this.DateAsString);
            pp.SetAttribute("Track", this.TrackCode);
            pp.SetAttribute("Surface", this.Surface);
            pp.SetAttribute("TrackCondition", this.TrackCondition);
            pp.SetAttribute("RaceClassification", this.RaceClassification);
            pp.SetAttribute("Distance", Utilities.ConvertYardsToMilesOrFurlongsAbreviation(this.DistanceInYards));
            pp.SetAttribute("PostPosition", this.PostPosition);
            pp.SetAttribute("Jockey", Jockey);
            pp.SetAttribute("GoldenPaceFigureForThis", ((int) GoldenPaceFigureForThisHorse).ToString());
            pp.SetAttribute("GoldenPaceFigureForWinner", ((int) GoldenPaceFigureForTheRace).ToString());
            pp.SetAttribute("GoldenFigureForThis", ((int) GoldenFigureForThisHorse).ToString());
            pp.SetAttribute("GoldenFigureForWinner", ((int) GoldenFigureForTheWinner).ToString());
            pp.SetAttribute("Odds", this.Odds);

            starter.AppendChild(pp);
        }
    }
}