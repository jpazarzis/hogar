using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using Hogar;
using Hogar.GeneticProgramming;
using Hogar.Parsing;
using System.Data;
using Hogar.Handicapping;
using System.Diagnostics;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar.Handicapping.Analysis;
using Hogar.RaceGrouping;

namespace Hogar.BrisPastPerformances
{
    public class BrisHorse
    {
        #region Data

        private ParsableText _parsableText = null;
        private Tokenizer _tokenizer = null;
        private BrisRace _parent = null;
        private double _winningPercentBasedInBestRating;
        private double _winningPercentBasedInPrimePower;
        private int _periodCoveredByPastPerformancesInDays = -1;
        private int _racingFrequencyInDays = -1;
        private List<BrisPastPerformance> _pp = null;

        public enum TimingType
        {
            ThisHorse,
            LeadersHorse,
            ThisHorseCynthiaFractions,
            PaceFigures
        }

        private struct FieldIndex
        {
            public static int RACE_TRACK = 0;
            public static int RACE_DATE = 1;
            public static int RACE_NUMBER = 2;
            public static int POST_POSITION = 3;
            public static int ENTRY_INDICATOR = 4;
            public static int TODAYS_DISTANCE = 5;
            public static int TODAYS_SURFACE = 6;
            public static int RACE_TYPE = 8;
            public static int AGE_SEX_RESTRICTIONS = 9;
            public static int RACE_CLASSIFICATION = 10;
            public static int RACE_CONDITIONS = 15;
            public static int ALL_WEATHER_FLAG = 24;
            public static int JOCKEY_NAME = 32;
            public static int OWNERS_NAME = 38;
            public static int OWNERS_SILKS = 39;
            public static int MEDICATION = 61;
            public static int EQUIPMENT_CHANGE = 63;
            public static int PROGRAM_NUMBER = 42;
            public static int ODDS = 43;
            public static int HORSE_NAME = 44;
            public static int YEAR_OF_BIRTH = 45;
            public static int FOALING_MONTH = 46;
            public static int HORSE_SEX = 48;
            public static int HORSE_COLOR = 49;
            public static int WEIGHT = 50;
            public static int SIRE = 51;
            public static int SIRES_SIRE = 52;
            public static int DAM = 53;
            public static int DAMS_SIRE = 54;
            public static int STATE_WHERE_WAS_BRED = 56;
            public static int UPDATED_POST_POSITION = 57;
            public static int SIRES_STUD_FEE = 1176;
            public static int LIFE_TIME_STARTS = 96;
            public static int LIFE_TIME_WINS = 97;
            public static int LIFE_TIME_PLACES = 98;
            public static int LIFE_TIME_SHOWS = 99;
            public static int LIFE_TIME_EARNINGS = 100;
            public static int CURRENT_YEAR = 84;
            public static int CURRENT_YEAR_STARTS = 85;
            public static int CURRENT_YEAR_WINS = 86;
            public static int CURRENT_YEAR_PLACES = 87;
            public static int CURRENT_YEAR_SHOWS = 88;
            public static int CURRENT_YEAR_EARNINGS = 89;
            public static int PREVIOUS_YEAR = 90;
            public static int PREVIOUS_YEAR_STARTS = 91;
            public static int PREVIOUS_YEAR_WINS = 92;
            public static int PREVIOUS_YEAR_PLACES = 93;
            public static int PREVIOUS_YEAR_SHOWS = 94;
            public static int PREVIOUS_YEAR_EARNINGS = 95;
            public static int TODAYS_TRACK_STARTS = 69;
            public static int TODAYS_TRACK_WINS = 70;
            public static int TODAYS_TRACK_PLACES = 71;
            public static int TODAYS_TRACK_SHOWS = 72;
            public static int TODAYS_TRACK_EARNINGS = 73;
            public static int WET_TRACK_STARTS = 79;
            public static int WET_TRACK_WINS = 80;
            public static int WET_TRACK_PLACES = 81;
            public static int WET_TRACK_SHOWS = 82;
            public static int WET_TRACK_EARNINGS = 83;
            public static int TURF_TRACK_STARTS = 74;
            public static int TURF_TRACK_WINS = 75;
            public static int TURF_TRACK_PLACES = 76;
            public static int TURF_TRACK_SHOWS = 77;
            public static int TURF_TRACK_EARNINGS = 78;
            public static int TODAYS_DISTANCE_STARTS = 64;
            public static int TODAYS_DISTANCE_WINS = 65;
            public static int TODAYS_DISTANCE_PLACES = 66;
            public static int TODAYS_DISTANCE_SHOWS = 67;
            public static int TODAYS_DISTANCE_EARNINGS = 68;
            public static int BRIS_RUN_STYLE = 209;
            public static int QUIRIN_SPEED_POINTS = 210;
            // A Similar variable exists for each past performance
            public static int NUMBER_OF_DAYS_SINCE_LAST_RACE_FOR_TODAYS_RACE = 223;
            public static int TODAYS_RACE_STATE_BRED = 238;
            public static int CLAIMING_PRICE_OF_RACE = 12;
            public static int CLAIMING_PRICE_OF_HORSE = 13;
            public static int PRIME_POWER_RATING = 250;
            // Trainer 
            public static int TRAINER = 27;
            public static int TRAINER_STARTS = 28;
            public static int TRAINER_WINS = 29;
            public static int TRAINER_PLACES = 30;
            public static int TRAINER_SHOWS = 31;
            public static int MAX_PAST_PERFORMANCES = 10;

            public static int BRIS_AVG_THREE_LAST_CLASS_RATINGS = 1145;
            public static int BRIS_DIRT_PEDIGREE_RATING = 1263;
            public static int BRIS_MUD_PEDIGREE_RATING = 1264;
            public static int BRIS_TURF_PEDIGREE_RATING = 1265;
            public static int BRIS_DISTANCE_PEDIGREE_RATING = 1266;
            public static int POST_TIME = 1417;
        }

        #endregion

        private List<Factor> _matchingFactors = null;

        public enum HorseSex
        {
            Unknown,
            Male,
            Female
        }

        public enum DisplayType
        {
            ShowSpeedForFractions,
            ShowFractionTimes
        } ;

        private readonly int _daysSinceLastRace;
        private readonly double _claimingPriceOfTheHorseAsDouble;
        private readonly double _claimingPriceOfTheRaceAsDouble;
        private readonly int _brisLateAvg;
        private readonly int _brisCompositeLastThree;
        private readonly int _bestRating;
        private readonly bool _isFirstTimeLasix;
        private readonly string _brisRunStyle;
        private readonly int _quirinSpeedPoints;
        private readonly int _primePowerRating;
        private readonly int _equipment;
        private readonly string _medication;
        private readonly string _currentYearEarnings;
        private readonly string _todaysTrackEarnings;
        private readonly int _weight;
        private readonly bool _todaysRaceIsARoute;
        private readonly bool _todaysRaceIsInTurf;
        private readonly bool _isSynthetic;
        private readonly int _age;
        private readonly DateTime _postTime;

        private Horse _correspondingHorse = null;

        public Horse CorrespondingHorse
        {
            get
            {
                return _correspondingHorse;
            }
            set
            {
                _correspondingHorse = value;
            }
        }

        public DateTime PostTime
        {
            get
            {
                return _postTime;
            }
        }

        

        internal BrisHorse(ParsableText pt)
        {
            _parent = null;
            _parsableText = pt;

            string s;
            s = _parsableText.Tokens[FieldIndex.NUMBER_OF_DAYS_SINCE_LAST_RACE_FOR_TODAYS_RACE].ToString().Trim();
            _daysSinceLastRace = s.Length > 0 ? Convert.ToInt32(s) : 0;

            s = _parsableText.Tokens[FieldIndex.CLAIMING_PRICE_OF_HORSE].ToString().Trim();
            _claimingPriceOfTheHorseAsDouble = s.Length > 0 ? Convert.ToDouble(s) : 0.0;

            s = _parsableText.Tokens[FieldIndex.CLAIMING_PRICE_OF_RACE].ToString().Trim();
            _claimingPriceOfTheRaceAsDouble = s.Length > 0 ? Convert.ToDouble(s) : 0.0;

            _brisLateAvg = CalcBrisLateAvg();
            _brisCompositeLastThree = CalcBrisCompositeLastThree();
            _bestRating = CalcBestRating();
            _medication = GetMedication();
            _isFirstTimeLasix = Medication.Trim().CompareTo("FL") == 0;
            _brisRunStyle = _parsableText.Tokens[FieldIndex.BRIS_RUN_STYLE].ToString();
            _quirinSpeedPoints = CalcQuirinSpeedPoints();
            _primePowerRating = CalcPrimePowerRating();
            if (_parsableText.Tokens[FieldIndex.EQUIPMENT_CHANGE].Length > 0)
            {
                _equipment = Convert.ToInt32(_parsableText.Tokens[FieldIndex.EQUIPMENT_CHANGE].ToString());
            }
            _currentYearEarnings = GetCurrentYearEarnings();
            _todaysTrackEarnings = GetTodaysTrackEarnings();

            if (_parsableText.Tokens[FieldIndex.WEIGHT].Length > 0)
            {
                _weight = Convert.ToInt32(_parsableText.Tokens[FieldIndex.WEIGHT].ToString());
            }
            _todaysRaceIsARoute = GetTodaysRaceIsARoute();
            _todaysRaceIsInTurf = GetTodaysRaceIsInTurf();
            _isSynthetic = GetTodaysRaceIsSynthetic();
            _age = GetAge();

            string postTimeStr = _parsableText.Tokens[FieldIndex.POST_TIME].ToString();

            _postTime = ConvertPacificMilitaryTimeToEastern(_parsableText.Tokens[FieldIndex.POST_TIME].ToString());
        }

        internal BrisHorse(Tokenizer tokenizer)
        {
            _parent = null;
            _parsableText = null;
            _tokenizer = tokenizer;

            string s;
            s = _tokenizer[FieldIndex.NUMBER_OF_DAYS_SINCE_LAST_RACE_FOR_TODAYS_RACE].Trim();
            _daysSinceLastRace = s.Length > 0 ? Convert.ToInt32(s) : 0;

            s = _tokenizer[FieldIndex.CLAIMING_PRICE_OF_HORSE].ToString().Trim();
            _claimingPriceOfTheHorseAsDouble = s.Length > 0 ? Convert.ToDouble(s) : 0.0;

            s = _tokenizer[FieldIndex.CLAIMING_PRICE_OF_RACE].ToString().Trim();
            _claimingPriceOfTheRaceAsDouble = s.Length > 0 ? Convert.ToDouble(s) : 0.0;

            _brisLateAvg = CalcBrisLateAvg();
            _brisCompositeLastThree = CalcBrisCompositeLastThree();
            _bestRating = CalcBestRating();
            _medication = GetMedication();
            _isFirstTimeLasix = Medication.Trim().CompareTo("FL") == 0;
            _brisRunStyle = _tokenizer[FieldIndex.BRIS_RUN_STYLE].ToString();
            _quirinSpeedPoints = CalcQuirinSpeedPoints();
            _primePowerRating = CalcPrimePowerRating();
            if (_tokenizer[FieldIndex.EQUIPMENT_CHANGE].Length > 0)
            {
                _equipment = Convert.ToInt32(_tokenizer[FieldIndex.EQUIPMENT_CHANGE]);
            }
            _currentYearEarnings = GetCurrentYearEarnings();
            _todaysTrackEarnings = GetTodaysTrackEarnings();

            if (_tokenizer[FieldIndex.WEIGHT].Length > 0)
            {
                _weight = Convert.ToInt32(_tokenizer[FieldIndex.WEIGHT].ToString());
            }
            _todaysRaceIsARoute = GetTodaysRaceIsARoute();
            _todaysRaceIsInTurf = GetTodaysRaceIsInTurf();
            _isSynthetic = GetTodaysRaceIsSynthetic();
            _age = GetAge();

            string postTimeStr = _tokenizer[FieldIndex.POST_TIME].ToString();

            _postTime = ConvertPacificMilitaryTimeToEastern(_tokenizer[FieldIndex.POST_TIME].ToString());
        }

        string GetToken(int index)
        {
            if (null != _tokenizer)
            {
                return _tokenizer[index];
            }
            else
            {
                return _parsableText.Tokens[index].ToString();
            }
        }

        private DateTime ConvertPacificMilitaryTimeToEastern(string time)
        {
            try
            {
                string dateOfTheRace = GetToken(FieldIndex.RACE_DATE);
                int year, month, day, hour, minute;

                if (!int.TryParse(dateOfTheRace.Substring(0, 4), out year))
                {
                    return DateTime.Now;
                }

                if (!int.TryParse(dateOfTheRace.Substring(4, 2), out month))
                {
                    return DateTime.Now;
                }

                if (!int.TryParse(dateOfTheRace.Substring(6, 2), out day))
                {
                    return DateTime.Now;
                }

                if (time.Trim().Length <= 0)
                {
                    hour = minute = 0;
                }
                else
                {
                    if (!int.TryParse(time.Substring(0, 2), out hour))
                    {
                        return DateTime.Now;
                    }
                    else
                    {
                        hour += 3;
                    }

                    if (!int.TryParse(time.Substring(2, 2), out minute))
                    {
                        return DateTime.Now;
                    }
                }

                return new DateTime(year, month, day, hour, minute, 0);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public BrisRace Parent
        {
            get
            {
                return _parent;
            }
            internal set
            {
                _parent = value;
            }
        }

        public override string ToString()
        {
            //return ProgramNumber + ". " + Name;
            return Name;
        }

        public bool WasScratched
        {
            get
            {
                return Entry == "S";
            }
        }

        private string ConvertSpeedToFigure(double speed)
        {
            if (speed <= 10)
            {
                return "0";
            }
            speed -= 10;
            speed *= 10;
            int s = (int) speed;
            return s.ToString();
        }

        public HorseSex Sex
        {
            get
            {
                string sex = GetToken(FieldIndex.HORSE_SEX);
                if (sex.Trim().ToUpper() == "F" || sex.Trim().ToUpper() == "M")
                {
                    return HorseSex.Female;
                }
                else
                {
                    return HorseSex.Male;
                }
            }
        }

        public List<int> GetBrisSpeedFiguresForRecentFormCycles()
        {
            var f = new List<int>();

            int longLayoffs = 0;
            const int maxNumberOfFigures = 6;

            foreach (var pp in PastPerformances)
            {
                if (pp.BrisSpeedRating <= 0)
                    continue;

                f.Add(pp.BrisSpeedRating);

                if (pp.DaysSinceLastRace >= Utilities.LAYOFF_DAYS)
                {
                    ++longLayoffs;
                }

                if(f.Count >= maxNumberOfFigures || longLayoffs >=3)
                {
                    break;
                }
            }
            return f;
        }

        public DataSet Ratings
        {
            get
            {
                DataSet dataSet = new DataSet();

                DataTable dataTable = dataSet.Tables.Add();

                dataTable.Columns.Add("Days", typeof (int));
                dataTable.Columns.Add("RR", typeof (string));
                dataTable.Columns.Add("CR", typeof (string));
                dataTable.Columns.Add("SP", typeof (string));
                dataTable.Columns.Add("CD", typeof (string));
                dataTable.Columns.Add("PP", typeof (BrisPastPerformance));
                List<BrisPastPerformance> pps = PastPerformances;
                foreach (BrisPastPerformance pp in pps)
                {
                    if (!pp.IsValid)
                    {
                        continue;
                    }

                    var v = new object[dataTable.Columns.Count];
                    int index = 0;
                    v[index++] = pp.DaysSinceLastRace;
                    if (pp.InterpolatedRaceRating >= 0)
                    {
                        v[index++] = string.Format("{0:0.0}", pp.InterpolatedRaceRating);
                    }
                    else
                    {
                        v[index++] = "N/A";
                    }

                    if (pp.InterpolatedClassRating >= 0)
                    {
                        v[index++] = string.Format("{0:0.0}", pp.InterpolatedClassRating);
                    }
                    else
                    {
                        v[index++] = "N/A";
                    }
                    v[index++] = string.Format("{0:0.0}", pp.InterpolatedSpeedFigure);
                    v[index++] = pp.TrackCondition;
                    v[index++] = pp;
                    dataTable.Rows.Add(v);
                }
                return dataSet;
            }
        }

        // Used from the front end to highligt a first - second - third finished horse
        // when he has one or more races in the data base
        public List<string> TopSpotFinishersWhoHaveDataBaseEntries
        {
            get
            {
                List<string> horseName = new List<string>();

                PastPerformances.ForEach(pp =>
                                             {
                                                 horseName.Add(pp.WinnersName);
                                                 horseName.Add(pp.SecondPlaceFinisherName);
                                                 horseName.Add(pp.ThirdPlaceFinisherName);
                                             });

                StringBuilder whereClause = new StringBuilder();
                bool needsComma = false;

                horseName.ForEach(name =>
                                      {
                                          if (name.Length > 0)
                                          {
                                              if (needsComma)
                                              {
                                                  whereClause.Append(",");
                                              }
                                              whereClause.Append("'");
                                              whereClause.Append(name);
                                              whereClause.Append("'");
                                              needsComma = true;
                                          }
                                      });

                string s = whereClause.ToString();

                if (s.Length <= 0)
                {
                    return null;
                }

                var horsesWithDbRecords = new List<string>();
                string sql = string.Format("SELECT DISTINCT HORSE_NAME FROM RACE_STARTERS WHERE HORSE_NAME IN ({0})", s);
                SqlDataReader myReader = null;
                try
                {
                    var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        horsesWithDbRecords.Add(myReader["HORSE_NAME"].ToString().ToUpper().Trim());
                    }
                }
                finally
                {
                    if (null != myReader)
                    {
                        myReader.Close();
                    }
                }
                return horsesWithDbRecords;
            }
        }

    

        // showThisHorseTime: true to display this horse time false to display leaders time
        public DataSet GetFractionsAsDataTable(BrisHorse.TimingType timingType, List<string> hiddenColumns)
        {
            hiddenColumns.Clear();
            var dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();
            dataTable.Columns.Add("SELECTED_AS_RUNNING_LINE", typeof (string));
            dataTable.Columns.Add("NumberOfDaysSinceLastRace", typeof (int));
            dataTable.Columns.Add("NumberOfDaysSinceThatRace", typeof (int));
            dataTable.Columns.Add("Date", typeof (string));
            dataTable.Columns.Add("Race&Track", typeof (string));
            dataTable.Columns.Add("Condition", typeof (string));
            dataTable.Columns.Add("Distance", typeof (string));
            dataTable.Columns.Add("Surface", typeof (string));
            dataTable.Columns.Add("First", typeof (string));
            hiddenColumns.Add("First");
            dataTable.Columns.Add("Second", typeof (string));
            hiddenColumns.Add("Second");
            dataTable.Columns.Add("Third", typeof (string));
            hiddenColumns.Add("Third");
            dataTable.Columns.Add("Final", typeof (string));
            hiddenColumns.Add("Final");
            dataTable.Columns.Add("Race Class", typeof (string));
            dataTable.Columns.Add("BrisRaceRating", typeof (string));
            hiddenColumns.Add("BrisRaceRating");
            dataTable.Columns.Add("BrisClassRating", typeof (string));
            hiddenColumns.Add("BrisClassRating");
            dataTable.Columns.Add("FirstFraction", typeof (string));
            dataTable.Columns.Add("SecondFraction", typeof (string));
            dataTable.Columns.Add("ThirdFraction", typeof (string));
            dataTable.Columns.Add("FinalFraction", typeof (string));
            dataTable.Columns.Add("PostPosition", typeof (string));
            dataTable.Columns.Add("FirstCallPosition", typeof (string));
            dataTable.Columns.Add("FirstCallDistanceFromLeader", typeof (string));
            dataTable.Columns.Add("SecondCallPosition", typeof (string));
            dataTable.Columns.Add("SecondCallDistanceFromLeader", typeof (string));
            dataTable.Columns.Add("StretchCallPosition", typeof (string));
            dataTable.Columns.Add("StretchCallDistanceFromLeader", typeof (string));
            dataTable.Columns.Add("FinalCallPosition", typeof (string));
            dataTable.Columns.Add("FinalCallDistanceFromLeader", typeof (string));
            //dataTable.Columns.Add("GoldenPaceFigureForThisHorse", typeof(int));
            //dataTable.Columns.Add("GoldenPaceFigure", typeof(int));
            //dataTable.Columns.Add("GoldenFigure", typeof(int));
            //dataTable.Columns.Add("GoldenFigureForWinnerOfRace", typeof(int));
            //dataTable.Columns.Add("GoldenTrackVariant", typeof(int));
            dataTable.Columns.Add("TrackVariant", typeof (int));
            dataTable.Columns.Add("BrisRaceShapeFirstCall", typeof(string));
            dataTable.Columns.Add("BrisRaceShapeSecondCall", typeof(string));
            dataTable.Columns.Add("BrisSpeedRating", typeof (int));
            dataTable.Columns.Add("Jockey", typeof (string));
            dataTable.Columns.Add("MedicationWeightEquipment", typeof (string));
            dataTable.Columns.Add("Odds", typeof (string));
            dataTable.Columns.Add("TripComment", typeof (string));
            dataTable.Columns.Add("NumberOfEntrants", typeof (string));

            dataTable.Columns.Add("WinnersName", typeof (string));
            dataTable.Columns.Add("SecondHorseName", typeof (string));
            dataTable.Columns.Add("ThirdHorseName", typeof (string));

            dataTable.Columns.Add("ExtraCommentLine", typeof (string));

            // The following columns will be hidden in the front end and are used to easily get the race info
            dataTable.Columns.Add("ID_INFO_DATE", typeof (string));
            hiddenColumns.Add("ID_INFO_DATE");
            dataTable.Columns.Add("ID_INFO_TRACK_CODE", typeof (string));
            hiddenColumns.Add("ID_INFO_TRACK_CODE");
            dataTable.Columns.Add("ID_INFO_RACE_NUMBER", typeof (string));
            hiddenColumns.Add("ID_INFO_RACE_NUMBER");
            dataTable.Columns.Add("ID_INFO_DISTANCE_IN_YARDS", typeof (int));
            hiddenColumns.Add("ID_INFO_DISTANCE_IN_YARDS");
            dataTable.Columns.Add("ID_PP_OBJECT", typeof (BrisPastPerformance));
            hiddenColumns.Add("ID_PP_OBJECT");

            List<BrisPastPerformance> pps = PastPerformances;
            foreach (BrisPastPerformance pp in pps)
            {
                if (!pp.IsValid)
                {
                    continue;
                }

                object[] v = new object[dataTable.Columns.Count];
                int index = 0;
                v[index++] = "";
                v[index++] = pp.DaysSinceLastRace;
                v[index++] = pp.DaysSinceThatRace;
                v[index++] = pp.DateAsString;
                v[index++] = pp.RaceNumber + pp.TrackCode;
                v[index++] = pp.TrackCondition;
                v[index++] = pp.DistanceAbreviation;
                v[index++] = pp.Surface;
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringFirstFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringSecondFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringThirdFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringFinalFraction);

                //v[index++] = pp.RaceClassification;

                v[index++] = Utilities.FormatCondition(pp.RaceClassification, pp.IsStateBredRestrictedRace, pp.AgeSexRestrictions);

                if (pp.BrisRaceRating >= 0)
                {
                    v[index++] = pp.BrisRaceRating.ToString();
                }
                else
                {
                    v[index++] = "N/A";
                }

                if (pp.BrisClassRating >= 0)
                {
                    v[index++] = pp.BrisClassRating.ToString();
                }
                else
                {
                    v[index++] = "N/A";
                }

                if (timingType == TimingType.ThisHorse)
                {
                    v[index++] = pp.GetFraction(FractionCall.Level.First).FormatedTime;
                    v[index++] = pp.GetFraction(FractionCall.Level.Second).FormatedTime;
                    v[index++] = pp.GetFraction(FractionCall.Level.Stretch).FormatedTime;
                    v[index++] = pp.GetFraction(FractionCall.Level.Final).FormatedTime;
                }
                else if (timingType == TimingType.LeadersHorse)
                {
                    v[index++] = pp.LeadersFirstCall;
                    v[index++] = pp.LeadersSecondCall;
                    v[index++] = pp.LeadersThirdCall;
                    v[index++] = pp.LeadersFinalCall;
                }
                else if (timingType == TimingType.ThisHorseCynthiaFractions)
                {
                    v[index++] = "";
                    v[index++] = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFirstCall);
                    v[index++] = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedSecondCall);
                    v[index++] = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFinalCall);
                }
                else if (timingType == TimingType.PaceFigures)
                {
                    v[index++] = "";

                    if (pp.PaceFigure.Figure1ForTheHorse < -500)
                    {
                        v[index++] = "";
                        v[index++] = "";
                        v[index++] = "";
                    }
                    else
                    {

                        v[index++] = string.Format("{0,5:####}/{1,5:####}", pp.PaceFigure.Figure1ForTheHorse, pp.PaceFigure.Figure1ForTheRace);
                        v[index++] = string.Format("{0,5:####}/{1,5:####}", pp.PaceFigure.Figure2ForTheHorse, pp.PaceFigure.Figure2ForTheRace);
                        v[index++] = string.Format("{0,5:####}/{1,5:####}", pp.PaceFigure.FinalFigureForTheHorse, pp.PaceFigure.FinalFigureForTheRace);
                    }
                    
                }
                v[index++] = pp.PostPosition;
                v[index++] = pp.FirstCallPosition;
                v[index++] = pp.FirstCallDistanceFromLeader;
                v[index++] = pp.SecondCallPosition;
                v[index++] = pp.SecondCallDistanceFromLeader;
                v[index++] = pp.StretchCallPosition;
                v[index++] = pp.StretchCallDistanceFromLeader;
                v[index++] = pp.FinalPosition;
                v[index++] = pp.FinalCallDistanceFromLeader;
                //v[index++] = (int) pp.GoldenPaceFigureForThisHorse;
                //v[index++] = (int)pp.GoldenPaceFigureForTheRace;
                //v[index++] = (int) pp.GoldenFigureForThisHorse;
                //v[index++] = (int)pp.GoldenFigureForTheWinner;
                //v[index++] = pp.GoldenTrackVariant;
                v[index++] = pp.TrackVariant;
                v[index++] = pp.BrisRaceShapeFirstCall;
                v[index++] = pp.BrisRaceShapeSecondCall;
                v[index++] = pp.BrisSpeedRating;
                v[index++] = pp.Jockey.Length < 16 ? pp.Jockey : pp.Jockey.Substring(0, 15);
                v[index++] = pp.Medication + pp.Weight + pp.Equipment;
                v[index++] = pp.Odds;
                v[index++] = pp.TripComment;
                v[index++] = pp.NumberOfEntrants;

                v[index++] = Utilities.CapitalizeOnlyFirstLetter(pp.WinnersName);
                v[index++] = Utilities.CapitalizeOnlyFirstLetter(pp.SecondPlaceFinisherName);
                v[index++] = Utilities.CapitalizeOnlyFirstLetter(pp.ThirdPlaceFinisherName);

                v[index++] = pp.ExtraCommentLine;

                v[index++] = pp.Date.Year + string.Format("{0:00}", pp.Date.Month) + string.Format("{0:00}", pp.Date.Day);
                v[index++] = pp.TrackCode;
                v[index++] = pp.RaceNumber;
                v[index++] = pp.DistanceInYards;
                v[index++] = pp;

                dataTable.Rows.Add(v);
            }

            return dataSet;
        }

        // GetPastPerformancesAsDataTable()
        // Similar to the following property method PastPerformances
        // Returns the past performances in a Data Set Format, ready to be
        // used in a DataGridView control or in any other viewer 
        // that supports DataSets. Note that has a different represenation of
        // several fiels. 

        public DataSet GetPastPerformancesAsDataTable(DisplayType displayType)
        {
            DataSet dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();
            dataTable.Columns.Add("Desc", typeof (string));
            dataTable.Columns.Add("Call 1", typeof (object));
            dataTable.Columns.Add("Call 2", typeof (object));
            dataTable.Columns.Add("Call 3", typeof (object));
            dataTable.Columns.Add("Final", typeof (object));
            dataTable.Columns.Add("Finish Position", typeof (string));
            dataTable.Columns.Add("Race Class", typeof (string));
            dataTable.Columns.Add("PostPosition", typeof (string));
            dataTable.Columns.Add("Jockey", typeof (string));
            dataTable.Columns.Add("Medication", typeof (string));
            dataTable.Columns.Add("Weight", typeof (string));
            dataTable.Columns.Add("Equipment", typeof (string));
            dataTable.Columns.Add("Odds", typeof (string));
            dataTable.Columns.Add("TripComment", typeof (string));
            List<BrisPastPerformance> pps = PastPerformances;

            foreach (BrisPastPerformance pp in pps)
            {
                if (!pp.IsValid)
                {
                    continue;
                }

                string desc = pp.DateAsString + " " + pp.RaceNumber + " " + pp.TrackCode + " " + pp.TrackCondition + " " + pp.Distance + " " + pp.Surface;

                if (displayType == DisplayType.ShowFractionTimes)
                {
                    dataTable.Rows.Add(desc,
                                       pp.GetFraction(FractionCall.Level.First),
                                       pp.GetFraction(FractionCall.Level.Second),
                                       pp.GetFraction(FractionCall.Level.Stretch),
                                       pp.GetFraction(FractionCall.Level.Final),
                                       pp.FinalPosition,
                                       pp.RaceClassification,
                                       pp.PostPosition,
                                       pp.Jockey,
                                       pp.Medication,
                                       pp.Weight,
                                       pp.Equipment,
                                       pp.Odds,
                                       pp.TripComment);
                }
                else if (displayType == DisplayType.ShowSpeedForFractions)
                {
                    dataTable.Rows.Add(desc,
                                       String.Format("{0:0.00}", pp.SpeedDuringFirstFraction),
                                       String.Format("{0:0.00}", pp.SpeedDuringSecondFraction),
                                       String.Format("{0:0.00}", pp.SpeedDuringThirdFraction),
                                       String.Format("{0:0.00}", pp.SpeedDuringFinalFraction),
                                       pp.FinalPosition,
                                       pp.RaceClassification,
                                       pp.PostPosition,
                                       pp.Jockey,
                                       pp.Medication,
                                       pp.Weight,
                                       pp.Equipment,
                                       pp.Odds,
                                       pp.TripComment);
                }
            }
            return dataSet;
        }

        public BrisPastPerformance GetPastPerformance(string track, DateTime date, string raceNumber)
        {
            foreach (BrisPastPerformance pp in PastPerformances)
            {
                if (pp.Date == date && pp.TrackCode.CompareTo(track) == 0 && raceNumber.CompareTo(raceNumber) == 0)
                {
                    return pp;
                }
            }

            return null;
        }

        public List<BrisPastPerformance> PastPerformances
        {
            get
            {
                var h = CorrespondingHorse;

               
                return null != _pp ? _pp : MakePastPerformances();
            }
        }

        public void ReloadCynthiaParForTheRace()
        {
            foreach (BrisPastPerformance pp in PastPerformances)
            {
                pp.ReloadCynthiaParForTheRace();
            }
        }

        private List<BrisPastPerformance> MakePastPerformances()
        {
            _pp = new List<BrisPastPerformance>();
            _pp.Clear();
            for (int i = 0; i < FieldIndex.MAX_PAST_PERFORMANCES; ++i)
            {
                if(null != _parsableText)
                {
                    var p = new BrisPastPerformance(_parsableText, i, this);

                    if (p.IsValid)
                    {
                        _pp.Add(p);
                    }    
                }
                else
                {
                    var p = new BrisPastPerformance(_tokenizer, i, this);

                    if (p.IsValid)
                    {
                        _pp.Add(p);
                    }
                }

                
            }

            return _pp;
        }

        public string RaceConditions
        {
            get
            {
                return GetToken(FieldIndex.RACE_CONDITIONS);
            }
        }

        public int DaysSinceLastRace
        {
            get
            {
                return _daysSinceLastRace;
            }
        }

        public int DaysOff2Back
        {
            get
            {
                if (PastPerformances.Count >= 1)
                {
                    return PastPerformances[0].DaysSinceLastRace;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DaysOff3Back
        {
            get
            {
                if (PastPerformances.Count >= 2)
                {
                    return PastPerformances[1].DaysSinceLastRace;
                }
                else
                {
                    return 0;
                }
            }
        }

        public double ClaimingPriceOfTheHorse
        {
            get
            {
                return _claimingPriceOfTheHorseAsDouble;
            }
        }

        public double ClaimingPriceOfTheRace
        {
            get
            {
                return _claimingPriceOfTheRaceAsDouble;
            }
        }

        private int CalcBrisLateAvg()
        {
            switch (PastPerformances.Count)
            {
                case 0:
                    return 0;
                case 1:
                    return PastPerformances[0].BrisLatePace;
                case 2:
                    return (PastPerformances[0].BrisLatePace + PastPerformances[1].BrisLatePace)/2;
                default:
                    {
                        List<int> c = new List<int>();
                        c.Add(PastPerformances[0].BrisLatePace);
                        c.Add(PastPerformances[1].BrisLatePace);
                        c.Add(PastPerformances[2].BrisLatePace);
                        c.Sort();
                        return (PastPerformances[2].BrisLatePace + PastPerformances[1].BrisLatePace)/2;
                    }
            }
        }

        public int PeriodCoveredByPastPerformancesInDays
        {
            get
            {
                if (_periodCoveredByPastPerformancesInDays < 0)
                {
                    _periodCoveredByPastPerformancesInDays = 0;

                    foreach (BrisPastPerformance pp in PastPerformances)
                    {
                        _periodCoveredByPastPerformancesInDays += pp.DaysSinceLastRace;
                    }
                }

                return _periodCoveredByPastPerformancesInDays;
            }
        }

        public int RacingFrequencyInDays
        {
            get
            {
                if (_racingFrequencyInDays < 0)
                {
                    _racingFrequencyInDays = 0;

                    if (PastPerformances.Count > 0)
                    {
                        _racingFrequencyInDays = PeriodCoveredByPastPerformancesInDays/PastPerformances.Count;
                    }
                }
                return _racingFrequencyInDays;
            }
        }

        public int BrisLateAvg
        {
            get
            {
                return _brisLateAvg;
            }
        }

        private int CalcBrisCompositeLastThree()
        {
            switch (PastPerformances.Count)
            {
                case 0:
                    return 0;
                case 1:
                    return PastPerformances[0].BrisComposite;
                case 2:
                    return (PastPerformances[0].BrisComposite + PastPerformances[1].BrisComposite)/2;
                default:
                    {
                        List<int> c = new List<int>();
                        c.Add(PastPerformances[0].BrisComposite);
                        c.Add(PastPerformances[1].BrisComposite);
                        c.Add(PastPerformances[2].BrisComposite);

                        c.Sort();

                        return (PastPerformances[2].BrisComposite + PastPerformances[1].BrisComposite)/2;
                    }
            }
        }

        public int BrisCompositeLastThree
        {
            get
            {
                return _brisCompositeLastThree;
            }
        }

        private int CalcBestRating()
        {
            List<BrisPastPerformance> pps = PastPerformances;
            int r = 0;
            for (int i = 0; i < pps.Count; ++i)
            {
                if (i > 4)
                {
                    break;
                }
                if (pps[i].BrisSpeedRatingAsInteger > r)
                {
                    r = pps[i].BrisSpeedRatingAsInteger;
                }
            }
            return r;
        }

        public int BestRating
        {
            get
            {
                return _bestRating;
            }
        }

        public bool BlinkersOn
        {
            get
            {
                return Equipment == 1;
            }
        }

        public bool BlinkersOff
        {
            get
            {
                return Equipment == 2;
            }
        }

        public bool IsFirstTimeLasix
        {
            get
            {
                return _isFirstTimeLasix;
            }
        }

        public string BrisRunStyle
        {
            get
            {
                return _brisRunStyle;
            }
        }

        private int CalcQuirinSpeedPoints()
        {
            try
            {
                string s = GetToken(FieldIndex.QUIRIN_SPEED_POINTS);
                s.Trim();
                if (s.Length <= 0)
                {
                    return 0;
                }
                return Convert.ToInt32(s);
            }
            catch
            {
                return 0;
            }
        }

        public int QuirinSpeedPoints
        {
            get
            {
                return _quirinSpeedPoints;
            }
        }

        private int CalcPrimePowerRating()
        {
            string s = GetToken(FieldIndex.PRIME_POWER_RATING);
            s.Trim();
            if (s.Length <= 0)
            {
                return 0;
            }
            return (int) (Convert.ToDouble(s));
        }

        public int PrimePowerRating
        {
            get
            {
                return _primePowerRating;
            }
        }

        public int Equipment
        {
            get
            {
                return _equipment;
            }
        }

        private string GetMedication()
        {
            string s = GetToken(FieldIndex.MEDICATION);
            if (s.Length <= 0)
            {
                return "";
            }
            int medication = Convert.ToInt32(GetToken(FieldIndex.MEDICATION));
            switch (medication)
            {
                case 1:
                    return "L";
                case 2:
                    return "B";
                case 3:
                    return "BL";
                case 4:
                    return "FL";
                case 5:
                    return "FLB";
                default:
                    return "";
            }
        }

        public string Medication
        {
            get
            {
                return _medication;
            }
        }

        public string FormatCurrency(string amount)
        {
            amount = amount.Trim();

            if (amount.Length <= 0)
            {
                return "$0";
            }
            double d = Convert.ToDouble(amount);
            return string.Format(" ${0:0,0}", d);
        }

        private string GetCurrentYearEarnings()
        {
            string s = GetToken(FieldIndex.CURRENT_YEAR) ;
            return GetEarningsString(s, FieldIndex.CURRENT_YEAR_STARTS, FieldIndex.CURRENT_YEAR_WINS, FieldIndex.CURRENT_YEAR_PLACES, FieldIndex.CURRENT_YEAR_EARNINGS);
        }

        public string CurrentYearEarnings
        {
            get
            {
                return _currentYearEarnings;
            }
        }

        private string GetTodaysTrackEarnings()
        {
            return GetEarningsString(this.RaceTrack, FieldIndex.TODAYS_TRACK_STARTS, FieldIndex.TODAYS_TRACK_WINS, FieldIndex.TODAYS_TRACK_PLACES, FieldIndex.TODAYS_TRACK_EARNINGS);
        }

        public string TodaysTrackEarnings
        {
            get
            {
                return _todaysTrackEarnings;
            }
        }

        public string TodaysDistanceEarnings
        {
            get
            {
                return GetEarningsString("Dist", FieldIndex.TODAYS_DISTANCE_STARTS, FieldIndex.TODAYS_DISTANCE_WINS, FieldIndex.TODAYS_DISTANCE_PLACES, FieldIndex.TODAYS_DISTANCE_EARNINGS);
            }
        }

        public string TurfTrackEarnings
        {
            get
            {
                return GetEarningsString("Turf", FieldIndex.TURF_TRACK_STARTS, FieldIndex.TURF_TRACK_WINS, FieldIndex.TURF_TRACK_PLACES, FieldIndex.TURF_TRACK_EARNINGS);
            }
        }

        public int GetProgramNumberWithoutEntryChar()
        {
            string num = ProgramNumber;

            if (num.Trim().Length <= 0)
            {
                return 0;
            }

            for (char ch = 'A'; ch <= 'Z'; ++ch)
            {
                string s = new string(ch, 1);

               
                num = num.Replace(s, "");
            }

            return Convert.ToInt32(num.Trim());
        }

        private string GetEarningsString(string desc, int startsIndex, int winsIndex, int placesIndex, int earningsIndex)
        {
            int starts = Convert.ToInt32(GetToken(startsIndex));
            int wins = Convert.ToInt32(GetToken(winsIndex));
            int places = Convert.ToInt32(GetToken(placesIndex));
            int earnings = (int)(Convert.ToDouble(GetToken(earningsIndex)))/1000;
            int earningsPerStart = starts != 0 ? earnings/starts : 0;

            return string.Format("{0,-5} {1,3} {2,3} {3,3} {4,3} {5,4}",
                desc, starts, wins, places, earningsPerStart,earnings );

        }

        public string WetTrackEarnings
        {
            get
            {
                return GetEarningsString("Wet", FieldIndex.WET_TRACK_STARTS, FieldIndex.WET_TRACK_WINS, FieldIndex.WET_TRACK_PLACES, FieldIndex.WET_TRACK_EARNINGS);
            }
        }

        public string PreviousYearEarnings
        {
            get
            {
                string s = GetToken(FieldIndex.PREVIOUS_YEAR);
                return GetEarningsString(s, FieldIndex.PREVIOUS_YEAR_STARTS, FieldIndex.PREVIOUS_YEAR_WINS, FieldIndex.PREVIOUS_YEAR_PLACES, FieldIndex.PREVIOUS_YEAR_EARNINGS);
            }
        }

        public string LifeTimeEarnings
        {
            get
            {
                return GetEarningsString("Life", FieldIndex.LIFE_TIME_STARTS, FieldIndex.LIFE_TIME_WINS, FieldIndex.LIFE_TIME_PLACES, FieldIndex.LIFE_TIME_EARNINGS);
            }
        }

        public string MedicationAndWeight
        {
            get
            {
                return Medication + " " + Weight;
            }
        }

        private int GetWeight()
        {
            return Convert.ToInt32(GetToken(FieldIndex.WEIGHT));
        }

        public int Weight
        {
            get
            {
                return _weight;
            }
        }

        public string Owner
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.OWNERS_NAME));
            }
        }

        public List<Workout> GetWorkouts()
        {
            if(null != _parsableText)
            {
                var workouts = new BrisWorkouts(_parsableText);
                return workouts.GetWorkouts();    
            }
            else
            {
                var workouts = new BrisWorkouts(_tokenizer);
                return workouts.GetWorkouts();    
            }
            
        }

        public string Workouts
        {
            get
            {
                if (null != _parsableText)
                {
                    var workouts = new BrisWorkouts(_parsableText);
                    return workouts.ToString();
                }
                else
                {
                    var workouts = new BrisWorkouts(_tokenizer);
                    return workouts.ToString();
                }
            }
        }

        public string OwnersSilks
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.OWNERS_SILKS));
            }
        }

        public string Jockey
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.JOCKEY_NAME));
            }
        }

        public string Entry
        {
            get
            {
                return GetToken(FieldIndex.ENTRY_INDICATOR);
            }
        }

        private bool GetTodaysRaceIsARoute()
        {
            int yards = Convert.ToInt32(GetToken(FieldIndex.TODAYS_DISTANCE));
            return yards >= Utilities.MIN_DISTANCE_FOR_ROUTE;
        }

        public bool TodaysRaceIsARoute
        {
            get
            {
                return _todaysRaceIsARoute;
            }
        }

        private bool GetTodaysRaceIsSynthetic()
        {
            string s = GetToken(FieldIndex.ALL_WEATHER_FLAG);

            if (s.Length <= 0)
            {
                return false;
            }
            else
            {
                return s[0] == 'a' || s[0] == 'A';
            }
        }

        public string TodaysSurface
        {
            get
            {
                return GetToken(FieldIndex.TODAYS_SURFACE);
            }
        }

        public string Surface
        {
            get
            {
                string s = GetToken(FieldIndex.TODAYS_SURFACE);

                return s.Length <= 0 ? (string) "" : s[0].ToString();
            }
        }

        private bool GetTodaysRaceIsInTurf()
        {
            string s = GetToken(FieldIndex.TODAYS_SURFACE);

            if (s.Length <= 0)
            {
                return false;
            }
            else
            {
                return s[0] == 'T' || s[0] == 't';
            }
        }

        public bool TodaysRaceIsSynthetic
        {
            get
            {
                return _isSynthetic;
            }
        }

        public bool TodaysRaceIsInInnerTrack
        {
            get
            {
                string s = GetToken(FieldIndex.TODAYS_SURFACE);

                if (s.Length <= 0)
                {
                    return false;
                }
                else
                {
                    return s[0] == 't' || s[0] == 'd';
                }
            }
        }

        public bool TodaysRaceIsInTurf
        {
            get
            {
                return _todaysRaceIsInTurf;
            }
        }

        public bool TodaysRaceIsASprint
        {
            get
            {
                return TodaysRaceIsARoute == false;
            }
        }

        public string TodaysDistanceFlag
        {
            get
            {
                int yards = Convert.ToInt32(GetToken(FieldIndex.TODAYS_DISTANCE));

                if (yards < 0)
                {
                    return "A";
                }
                else
                {
                    return "";
                }    
            }
            
        }

        public string TodaysDistance
        {
            get
            {
                int yards = Convert.ToInt32(GetToken(FieldIndex.TODAYS_DISTANCE));

                if (yards < 0)
                {
                    return "*" + Utilities.ConvertYardsToMilesOrFurlongsAbreviation((-1)*yards);
                }
                else
                {
                    return Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards);
                }
            }
        }

        public string RaceTrack
        {
            get
            {
                return GetToken(FieldIndex.RACE_TRACK);
            }
        }

        public string TodaysRaceType
        {
            get
            {
                return GetToken(FieldIndex.RACE_TYPE).Trim().ToUpper();
            }
        }

        public bool TodaysRaceIsMSW
        {
            get
            {
                string s = GetToken(FieldIndex.RACE_TYPE).Trim().ToUpper();

                if (s.Length <= 0)
                {
                    return false;
                }
                return s[0] == 'S';
            }
        }

        public bool TodaysRaceIsStakes
        {
            get
            {
                string s = GetToken(FieldIndex.RACE_TYPE).Trim().ToUpper();
                if (s.Length <= 0)
                {
                    return false;
                }
                return s.ToUpper()[0] == 'G' || s.ToUpper()[0] == 'N';
            }
        }

        public bool TodaysRaceIsClaimer
        {
            get
            {
                string s = GetToken(FieldIndex.RACE_TYPE).Trim().ToUpper();
                if (s.Length <= 0)
                {
                    return false;
                }
                return s[0] == 'C';
            }
        }

        public bool TodaysRaceIsMCL
        {
            get
            {
                string s = GetToken(FieldIndex.RACE_TYPE).Trim().ToUpper();
                if (s.Length <= 0)
                {
                    return false;
                }
                return s[0] == 'M';
            }
        }

        private static string AgeSexRestrictions(string s)
        {
            s = s.ToUpper().Trim();
            if (s.Length < 3)
            {
                return "invalid";
            }
            string txt = "";
            switch (s[0])
            {
                case 'A':
                    txt += "2yo";
                    break;
                case 'B':
                    txt += "3yo";
                    break;
                case 'C':
                    txt += "4yo";
                    break;
                case 'D':
                    txt += "5yo";
                    break;
                case 'E':
                    txt += "3&4yo";
                    break;
                case 'F':
                    txt += "4&5yo";
                    break;
                case 'G':
                    txt += "3&4&5yo";
                    break;
                case 'H':
                    txt += "Noagerest";
                    break;
            }
            switch (s[1])
            {
                case '0':
                    txt += "";
                    break;
                case 'U':
                    txt += "+";
                    break;
            }
            switch (s[2])
            {
                case 'M':
                    txt += " F";
                    break;
                case 'F':
                    txt += " F";
                    break;
                case 'C':
                    txt += " C";
                    break;
            }

            return txt;
        }

        public int DistanceInYards
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.TODAYS_DISTANCE));
            }
        }

        public string RaceClassification
        {
            get
            {
                string stateBred = GetToken(FieldIndex.TODAYS_RACE_STATE_BRED);
                stateBred = stateBred.Trim().ToUpper();
                if (stateBred.Length > 0 && stateBred[0] == 'S')
                {
                    stateBred = "S";
                }
                else
                {
                    stateBred = "";
                }

                string restrictions = GetToken(FieldIndex.AGE_SEX_RESTRICTIONS);
                restrictions = AgeSexRestrictions(restrictions);
                string raceClassification = GetToken(FieldIndex.RACE_CLASSIFICATION);

                string onTurf = TodaysRaceIsInTurf ? "Turf" : "";

                return stateBred + " " + restrictions + " " + raceClassification + " " + onTurf + " " + TodaysDistance;
            }
        }

        public int RaceNumber
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.RACE_NUMBER));
            }
        }

        public string Name
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.HORSE_NAME));
            }
        }

        public string ProgramNumber
        {
            get
            {
                string pn = GetToken(FieldIndex.PROGRAM_NUMBER).Trim();

                if (pn.Length > 0)
                {
                    return pn;
                }
                else
                {
                    return "";
                }
            }
        }

   
    

        public int CurrentYearStarts
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.CURRENT_YEAR_STARTS));
            }
        }

        public int CurrentYearWins
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.CURRENT_YEAR_WINS));
            }
        }

        public int CurrentYearPlaces
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.CURRENT_YEAR_PLACES));
            }
        }

        public int CurrentYearShows
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.CURRENT_YEAR_SHOWS));
            }
        }


        public int PreviousYearStarts
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.PREVIOUS_YEAR_STARTS));
            }
        }

        public int PreviousYearWins
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.PREVIOUS_YEAR_WINS));
            }
        }

        public int PreviousYearPlaces
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.PREVIOUS_YEAR_PLACES));
            }
        }

        public int PreviousYearShows
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.PREVIOUS_YEAR_SHOWS));
            }
        }



        public int NumberOfLifeTimeOnWet
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.WET_TRACK_STARTS));
            }
        }


        public int NumberOfLifeWinsOfWet
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.WET_TRACK_WINS));
            }
        }

        public int NumberOfLifePlacesOfWet
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.WET_TRACK_PLACES));
            }
        }

        public int NumberOfLifeShowsOfWet
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.WET_TRACK_SHOWS));
            }
        }


        public int NumberOfLifeTimeOfTurf
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.TURF_TRACK_STARTS));
            }
        }


        public int NumberOfLifeWinsOfTurf
        {
            get
            {

                return Convert.ToInt32(GetToken(FieldIndex.TURF_TRACK_WINS));
            }
        }

        public int NumberOfLifePlacesOfTurf
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.TURF_TRACK_PLACES));
            }
        }

        public int NumberOfLifeShowsOfTurf
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.TURF_TRACK_SHOWS));
            }
        }


        public string Sire
        {
            get
            {
                string sire = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.SIRE));
                return sire;
            }
        }

        public string DamSire
        {
            get
            {
                string damsSire = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.DAMS_SIRE));
                return damsSire;
            }
        }

        public string StateWhereWasBred
        {
            get
            {
                return GetToken(FieldIndex.STATE_WHERE_WAS_BRED).ToUpper();
            }
        }

        public int PostPosition
        {
            get
            {
                int pp;
                string s = GetToken(FieldIndex.UPDATED_POST_POSITION);
                if (int.TryParse(s, out pp))
                {
                    return pp;
                }
                else
                {
                    s = GetToken(FieldIndex.POST_POSITION);
                    return int.TryParse(s, out pp) ? pp : 0;
                }
            }
        }

        public string SireInfo
        {
            get
            {
                string sire = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.SIRE));
                string siresSire = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.SIRES_SIRE));
                string studFee = FormatCurrency(GetToken(FieldIndex.SIRES_STUD_FEE));
                return sire + " (" + siresSire + ") " + studFee;
            }
        }

        public string DamInfo
        {
            get
            {
                string dam = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.DAM));
                string damsSire = Utilities.CapitalizeOnlyFirstLetter(GetToken(FieldIndex.DAMS_SIRE));
                return dam + " (" + damsSire + ")";
            }
        }

        private int GetAge()
        {
            string yearofbirth = GetToken(FieldIndex.YEAR_OF_BIRTH).Trim();
            if (yearofbirth.Length <= 0)
            {
                return 0;
            }
            string currentyear = GetToken(FieldIndex.RACE_DATE).Trim();
            if (currentyear.Length <= 0)
            {
                return 0;
            }
            if (currentyear.Length >= 4)
            {
                currentyear = currentyear.Substring(0, 4);
            }

            if (currentyear.Length > 0)
            {
                int i = Convert.ToInt32(currentyear);
                i -= 2000;
                int j = Convert.ToInt32(yearofbirth);
                return i - j;
            }
            else
            {
                return 0;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public string ColorAgeAndSex
        {
            get
            {
                string color = GetToken(FieldIndex.HORSE_COLOR);
                string sex = GetToken(FieldIndex.HORSE_SEX);
                string month = GetToken(FieldIndex.FOALING_MONTH);
                string yearofbirth = GetToken(FieldIndex.YEAR_OF_BIRTH);
                string age = "";
                string currentyear = "";
                string d = GetToken(FieldIndex.RACE_DATE);

                if (d.Length >= 4)
                {
                    currentyear = d.Substring(0, 4);
                }

                if (currentyear.Length > 0)
                {
                    int i = Convert.ToInt32(currentyear);
                    i -= 2000;
                    int j = Convert.ToInt32(yearofbirth);
                    age = (i - j).ToString();
                }

                color = color.Trim();
                sex = sex.Trim().ToLower();
                month = month.Trim();

                if (month.Length > 0)
                {
                    month = Utilities.GetMonthName(Convert.ToInt32(month));
                }

                yearofbirth = yearofbirth.Trim();

                return string.Format("{0}. {1}. {2} ({3}) {4}", color, sex, age, month, StateWhereWasBred);

                //return color + ". " + sex + ". " + age + " (" + month + ")";
            }
        }

        private double TrainersWinningPercentage
        {
            get
            {
                string stats = GetToken(FieldIndex.TRAINER_STARTS);
                if (stats.Length <= 0 || Convert.ToDouble(stats) <= 0.0)
                {
                    return 0;
                }
                return (Convert.ToDouble(GetToken(FieldIndex.TRAINER_WINS))/Convert.ToDouble(GetToken(FieldIndex.TRAINER_STARTS)));
            }
        }

        public string TrainersFullName
        {
            get
            {
                return GetToken(FieldIndex.TRAINER);
            }
        }

        public string TrainerInfo
        {
            get
            {
                string txt = "";
                txt = GetToken(FieldIndex.TRAINER) + " ";
                txt += String.Format("{0:0.00}", TrainersWinningPercentage*100) + "% ";
                txt += " (";
                txt += GetToken(FieldIndex.TRAINER_STARTS) + " ";
                txt += GetToken(FieldIndex.TRAINER_WINS) + " ";
                txt += GetToken(FieldIndex.TRAINER_PLACES) + " ";
                txt += GetToken(FieldIndex.TRAINER_SHOWS) + " ";
                txt += ")";
                return Utilities.CapitalizeOnlyFirstLetter(txt);
            }
        }

        public Odds MorningLineOdds
        {
            get
            {
                if (GetToken(FieldIndex.ODDS).Length <= 0)
                {
                    return Odds.Make("0");
                    ;
                }
                else
                {
                    return Odds.Make(GetToken(FieldIndex.ODDS));
                }
            }
        }

        private double ConvertToDouble(string txt)
        {
            string temp = "";
            for (int i = 0; i < txt.Length; ++i)
            {
                if ((txt[i] >= '0' && txt[i] <= '9') || txt[i] == '.')
                {
                    temp += txt[i];
                }
            }

            if (temp.Length <= 0)
            {
                return 0.0;
            }

            return Convert.ToDouble(temp);
        }

        public double BrisDirtPedigreeRating
        {
            get
            {
                return ConvertToDouble(GetToken(FieldIndex.BRIS_DIRT_PEDIGREE_RATING));
            }
        }

        public double BrisMudPedigreeRating
        {
            get
            {
                return ConvertToDouble(GetToken(FieldIndex.BRIS_MUD_PEDIGREE_RATING));
            }
        }

        public double BrisTurfPedigreeRating
        {
            get
            {
                return ConvertToDouble(GetToken(FieldIndex.BRIS_TURF_PEDIGREE_RATING));
            }
        }

        public double BrisDistancePedigreeRating
        {
            get
            {
                return ConvertToDouble(GetToken(FieldIndex.BRIS_DISTANCE_PEDIGREE_RATING));
            }
        }

        public double BrisAvgClassRatingLastThree
        {
            get
            {
                string s = GetToken(FieldIndex.BRIS_AVG_THREE_LAST_CLASS_RATINGS).Trim();
                return s.Length > 0 ? Convert.ToDouble(s) : -1.0;
            }
        }

        public bool HasGoodWorkouts
        {
            get
            {
                if (IsFirstTimeOut)
                {
                    return NumberOfWorkoutsForLastMonth >= 3 && HasAtLeastOneBulletishLatestWorkout;
                }

                int daysSinceLast = DaysSinceLastRace;

                if (daysSinceLast >= Utilities.LAYOFF_DAYS)
                {
                    return NumberOfWorkoutsForLastMonth >= 3 && HasAtLeastOneBulletishLatestWorkout;
                }
                else
                {
                    return HasAtLeastOneBulletishLatestWorkout;
                }
            }
        }

        public bool HasAtLeastOneBulletishLatestWorkout
        {
            get
            {
                List<Workout> workouts = GetWorkouts();
                if (workouts.Count <= 0)
                {
                    return false;
                }

                DateTime d = this.Parent.Parent.GetFullDate();
                d = d.Subtract(new TimeSpan(30, 0, 0, 0));
                int count = 0;
                foreach (Workout w in workouts)
                {
                    if (w.Date.CompareTo(d) > 0 && w.IsBulletish)
                    {
                        ++count;
                    }
                }
                return count > 0;
            }
        }

        public int NumberOfWorkoutsForLastMonth
        {
            get
            {
                List<Workout> workouts = GetWorkouts();
                if (workouts.Count <= 0)
                {
                    return 0;
                }
                DateTime d = this.Parent.Parent.GetFullDate();
                d = d.Subtract(new TimeSpan(30, 0, 0, 0));
                int count = 0;

                BrisPastPerformance lastRace = null;

                if (!IsFirstTimeOut)
                {
                    lastRace = PastPerformances[0];
                }
                foreach (Workout w in workouts)
                {
                    if (w.Date.CompareTo(d) > 0)
                    {
                        if (null != lastRace)
                        {
                            DateTime lastRaceDate = lastRace.Date;
                            if (w.Date.CompareTo(lastRaceDate) > 0)
                            {
                                ++count;
                            }
                        }
                        else
                        {
                            ++count;
                        }
                    }
                }
                return count;
            }
        }

        public int NumberOfWorkoutsSinceLastRace
        {
            get
            {
                List<Workout> workouts = GetWorkouts();
                if (PastPerformances.Count <= 0)
                {
                    return workouts.Count;
                }
                if (workouts.Count <= 0)
                {
                    return 0;
                }
                BrisPastPerformance lastRace = PastPerformances[0];
                DateTime lastRaceDate = lastRace.Date;
                int count = 0;
                foreach (Workout w in workouts)
                {
                    if (w.Date.CompareTo(lastRaceDate) > 0)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }

        public double WinningPercentBasedInBestRating
        {
            get
            {
                return _winningPercentBasedInBestRating;
            }
            set
            {
                _winningPercentBasedInBestRating = value;
            }
        }

        public double WinningPercentBasedInPrimePower
        {
            get
            {
                return _winningPercentBasedInPrimePower;
            }
            set
            {
                _winningPercentBasedInPrimePower = value;
            }
        }

        public bool IsFirstTimeOut
        {
            get
            {
                return PastPerformances.Count <= 0;
            }
        }

        public bool IsFirstTimeTurf
        {
            get
            {
                
                return Parent.Surface.Contains("T") && PastPerformances.All(p => !p.IsATurfRace);
            }
        }



        private BrisPastPerformance FindBestRecentRacePastPerformance()
        {
            BrisPastPerformance bestpp = null;

            if (PastPerformances.Count > 0)
            {
                int count = 0;
                bestpp = PastPerformances[0];
                foreach (BrisPastPerformance bpp in PastPerformances)
                {
                    if (bpp.BrisClassRating > bestpp.BrisClassRating)
                    {
                        bestpp = bpp;
                    }
                    if (++count > 4)
                    {
                        break;
                    }
                }
            }
            return bestpp;
        }

        public double BrisClassAndRaceRating
        {
            get
            {
                return BestRecentRaceRating + BestRecentClassRating;
            }
        }

        public double BestRecentRaceRating
        {
            get
            {
                BrisPastPerformance pp = FindBestRecentRacePastPerformance();
                return pp != null ? pp.BrisRaceRating : 0.0;
            }
        }

        public double BestRecentClassRating
        {
            get
            {
                BrisPastPerformance pp = FindBestRecentRacePastPerformance();
                return pp != null ? pp.BrisClassRating : 0.0;
            }
        }

        public int NumberOfLifeTimeStarts
        {
            get
            {
                return Convert.ToInt32(GetToken(FieldIndex.LIFE_TIME_STARTS));
            }
        }

        public int NumberOfLifeTimeWins
        {
            get
            {
                string s = GetToken(FieldIndex.LIFE_TIME_WINS);

                try
                {
                    return Convert.ToInt32(s.Trim());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public long HandicappingFactorsFlag
        {
            get
            {
                long flag = 0;
                foreach (Factor f in Factor.GetMatchingFactors(_correspondingHorse))
                {
                    flag = flag | f.BitMask;
                }
                return flag;
            }
        }

        public List<Factor> GetMatchingHandicappingFactors(Horse horse)
        {
            if (null == _matchingFactors)
            {
                _matchingFactors = Factor.GetMatchingFactors(horse);
            }
            return _matchingFactors;
        }

        public List<BrisPastPerformance> RunTogethers
        {
            get
            {
                var list = new List<BrisPastPerformance>();
                foreach (BrisHorse brisHorse in Parent.Horses)
                {
                    if (brisHorse != this && brisHorse.CorrespondingHorse.Scratched == false)
                    {
                        foreach (var thisPP in PastPerformances)
                        {
                            foreach (var otherPP in brisHorse.PastPerformances)
                            {
                                if (thisPP.Date == otherPP.Date &&
                                    thisPP.TrackCode == otherPP.TrackCode &&
                                    thisPP.RaceNumber == otherPP.RaceNumber)
                                {
                                    list.Add(otherPP);
                                }
                            }
                        }
                    }
                }
                return list;
            }
        }

        private string GetVotes(List<int> factors, DecisionTreeList dtl)
        {
            if (null == dtl)
            {
                return "NA";
            }
            else
            {
                int votes = 0;
                dtl.ForEach(dt => votes += dt.Evaluate(factors) ? 1 : 0);
                return string.Format("{0}", votes);
            }
        }

        public string GetVotesBasedInOdds(double odds)
        {
            long factorsFlag = this.HandicappingFactorsFlag;
            var factors = new List<int>();
            foreach (var factor in Factor.AvailableFactorsAsList)
            {
                if ((factor.BitMask & factorsFlag) == factor.BitMask)
                {
                    factors.Add(1);
                }
                else
                {
                    factors.Add(0);
                }
            }

            DecisionTreeList dtl = _parent.GetDecisionTreeListBasedInOdds(odds);

            if (null == dtl)
            {
                return "NA";
            }
            else
            {
                int votes = 0;
                dtl.ForEach(dt => votes += dt.Evaluate(factors) ? 1 : 0);
                return string.Format("{0}", votes);
            }
        }

        public string VotesBasedInOdds
        {
            get
            {
                return GetVotesBasedInOdds(_correspondingHorse.FinalOdds);
            }
        }

        public string VotesTotal
        {
            get
            {
                var rgt = _parent.RaceGroupType;
                int total = 0;
                foreach (var targetGroup in rgt.Groups)
                {    
                    if (targetGroup is GoodBetBasedInOdds)
                    {
                        var g = targetGroup as GoodBetBasedInOdds;

                        if (g.MinOdds >= _correspondingHorse.FinalOdds)
                        {
                            int votes = 0;
                            if (int.TryParse(GetVotesBasedInOdds(g.AverageOdds), out votes))
                            {
                                total += votes;
                            }
                        }
                    }
                }
                return total.ToString();
            }
        }

        public string VotesForGoodFavorite
        {
            get
            {
                long factorsFlag = this.HandicappingFactorsFlag;
                var factors = new List<int>();
                foreach (var factor in Factor.AvailableFactorsAsList)
                {
                    if ((factor.BitMask & factorsFlag) == factor.BitMask)
                    {
                        factors.Add(1);
                    }
                    else
                    {
                        factors.Add(0);
                    }
                }
                return GetVotes(factors, _parent.GoodFavoriteDTL);
            }
        }

        public string VotesForBadFavorite
        {
            get
            {
                long factorsFlag = this.HandicappingFactorsFlag;
                var factors = new List<int>();
                foreach (var factor in Factor.AvailableFactorsAsList)
                {
                    if ((factor.BitMask & factorsFlag) == factor.BitMask)
                    {
                        factors.Add(1);
                    }
                    else
                    {
                        factors.Add(0);
                    }
                }
                
                return GetVotes(factors, _parent.BadFavoriteDTL);
            }
        }

        public string VotesForGoodAndBadFavorite
        {
            get
            {
                long factorsFlag = this.HandicappingFactorsFlag;
                var factors = new List<int>();
                foreach (var factor in Factor.AvailableFactorsAsList)
                {
                    if ((factor.BitMask & factorsFlag) == factor.BitMask)
                    {
                        factors.Add(1);
                    }
                    else
                    {
                        factors.Add(0);
                    }
                }
                string goodVotes = GetVotes(factors, _parent.GoodFavoriteDTL);
                string badVotes = GetVotes(factors, _parent.BadFavoriteDTL);
                return string.Format("{0}-{1}", badVotes, goodVotes);
            }
        }
    }
}