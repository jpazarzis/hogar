using System;
using System.Collections.Generic;
using System.Text;
using Hogar.Parsing;
using System.Data;
using Hogar.Handicapping;
using System.Data.SqlClient;

namespace Hogar.BrisPastPerformances.Extended
{
    public class BrisHorse
    {
        #region Data

        private DataRow _dr;
        private BrisRace _parent;
        private double _winningPercentBasedInBestRating;
        private double _winningPercentBasedInPrimePower;
        private int _periodCoveredByPastPerformancesInDays = -1;
        private int _racingFrequencyInDays = -1;
        private List<BrisPastPerformance> _pp = null;

        public enum TimingType
        {
            ThisHorse,
            LeadersHorse,
            ThisHorseCynthiaFractions
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
                return ConvertPacificMilitaryTimeToEastern(Utilities.GetFieldAsString(_dr, FieldIndex.POST_TIME));
            }
        }

        internal BrisHorse(DataRow dr)
        {
            _parent = null;
            _dr = dr;
        }

        private DateTime ConvertPacificMilitaryTimeToEastern(string time)
        {
            try
            {
                string dateOfTheRace = Utilities.GetFieldAsString(_dr, FieldIndex.RACE_DATE);
                int year = Convert.ToInt32(dateOfTheRace.Substring(0, 4));
                int month = Convert.ToInt32(dateOfTheRace.Substring(4, 2));
                int day = Convert.ToInt32(dateOfTheRace.Substring(6, 2));
                int hour = Convert.ToInt32(time.Substring(0, 2)) + 3;
                int minute = Convert.ToInt32(time.Substring(2, 2));
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
                string sex = Utilities.GetFieldAsString(_dr, FieldIndex.HORSE_SEX);
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
                    v[index] = pp;
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
                var horseName = new List<string>();
                PastPerformances.ForEach(pp =>
                                             {
                                                 horseName.Add(pp.WinnersName);
                                                 horseName.Add(pp.SecondPlaceFinisherName);
                                                 horseName.Add(pp.ThirdPlaceFinisherName);
                                             });
                var whereClause = new StringBuilder();
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
            dataTable.Columns.Add("BrisRaceShapeFirstCall", typeof (string));
            hiddenColumns.Add("BrisRaceShapeFirstCall");
            dataTable.Columns.Add("BrisRaceShapeSecondCall", typeof (string));
            hiddenColumns.Add("BrisRaceShapeSecondCall");
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
            dataTable.Columns.Add("TrackVariant", typeof (int));
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
                v[index++] = pp.BrisRaceShapeFirstCall;
                v[index++] = pp.BrisRaceShapeSecondCall;
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringFirstFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringSecondFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringThirdFraction);
                v[index++] = ConvertSpeedToFigure(pp.SpeedDuringFinalFraction);
                v[index++] = Utilities.FormatCondition(pp.RaceClassification, pp.IsStateBredRestrictedRace, pp.AgeSexRestrictions);
                v[index++] = pp.BrisRaceRating >= 0 ? pp.BrisRaceRating.ToString() : "N/A";
                v[index++] = pp.BrisClassRating >= 0 ? pp.BrisClassRating.ToString() : "N/A";

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
                v[index++] = pp.PostPosition;
                v[index++] = pp.FirstCallPosition;
                v[index++] = pp.FirstCallDistanceFromLeader;
                v[index++] = pp.SecondCallPosition;
                v[index++] = pp.SecondCallDistanceFromLeader;
                v[index++] = pp.StretchCallPosition;
                v[index++] = pp.StretchCallDistanceFromLeader;
                v[index++] = pp.FinalPosition;
                v[index++] = pp.FinalCallDistanceFromLeader;
                v[index++] = pp.TrackVariant;
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
                v[index] = pp;

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
            var dataSet = new DataSet();

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
                BrisPastPerformance p = new BrisPastPerformance(_dr, i, this);

                if (p.IsValid)
                {
                    _pp.Add(p);
                }
            }

            return _pp;
        }

        public string RaceConditions
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.RACE_CONDITIONS);
            }
        }

        public int DaysSinceLastRace
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.NUMBER_OF_DAYS_SINCE_LAST_RACE_FOR_TODAYS_RACE);
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
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.CLAIMING_PRICE_OF_HORSE);
            }
        }

        public double ClaimingPriceOfTheRace
        {
            get
            {
                return Utilities.GetFieldAsDouble(_dr, FieldIndex.CLAIMING_PRICE_OF_RACE);
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
                return CalcBrisLateAvg();
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
                        var c = new List<int> {
                                                PastPerformances[0].BrisComposite,
                                                PastPerformances[1].BrisComposite, 
                                                PastPerformances[2].BrisComposite
                                              };

                        c.Sort();

                        return (PastPerformances[2].BrisComposite + PastPerformances[1].BrisComposite)/2;
                    }
            }
        }

        public int BrisCompositeLastThree
        {
            get
            {
                return CalcBrisCompositeLastThree();
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
                return CalcBestRating();
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
                return Medication.Trim().CompareTo("FL") == 0;
                ;
            }
        }

        public string BrisRunStyle
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_RUN_STYLE);
            }
        }

        public int QuirinSpeedPoints
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.QUIRIN_SPEED_POINTS);
            }
        }

        public int PrimePowerRating
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.PRIME_POWER_RATING);
            }
        }

        public int Equipment
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.EQUIPMENT_CHANGE);
            }
        }

        public string Medication
        {
            get
            {
                switch (Utilities.GetFieldAsInteger(_dr, FieldIndex.MEDICATION))
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

        public string CurrentYearEarnings
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR_STARTS));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR_WINS));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR_PLACES));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR_SHOWS));
                sb.Append(" ");
                sb.Append(FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.CURRENT_YEAR_EARNINGS)));
                return sb.ToString();
            }
        }

        public string TodaysTrackEarnings
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(this.RaceTrack);
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_TRACK_STARTS));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_TRACK_WINS));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_TRACK_PLACES));
                sb.Append(" ");
                sb.Append(Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_TRACK_SHOWS));
                sb.Append(" ");
                sb.Append(FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_TRACK_EARNINGS)));
                return sb.ToString();
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

        public string WetTrackEarnings
        {
            get
            {
                string s = "Wet " + Utilities.GetFieldAsString(_dr, FieldIndex.WET_TRACK_STARTS) + "  ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.WET_TRACK_WINS) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.WET_TRACK_PLACES) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.WET_TRACK_SHOWS) + " ";
                s += FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.WET_TRACK_EARNINGS));
                return s;
            }
        }

        
    
        public string PreviousYearEarnings
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR_STARTS) + "  ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR_WINS) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR_PLACES) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR_SHOWS) + " ";
                s += FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.PREVIOUS_YEAR_EARNINGS));
                return s;
            }
        }

        public string LifeTimeEarnings
        {
            get
            {
                string s = "Life " + Utilities.GetFieldAsString(_dr, FieldIndex.LIFE_TIME_STARTS) + "  ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.LIFE_TIME_WINS) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.LIFE_TIME_PLACES) + " ";
                s += Utilities.GetFieldAsString(_dr, FieldIndex.LIFE_TIME_SHOWS) + " ";
                s += FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.LIFE_TIME_EARNINGS));
                return s;
            }
        }

        public string MedicationAndWeight
        {
            get
            {
                return Medication + " " + Weight.ToString();
            }
        }

        public int Weight
        {
            get
            {
               return Utilities.GetFieldAsInteger(_dr, FieldIndex.WEIGHT);
            }
        }

        public string Owner
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.OWNERS_NAME));
            }
        }

        public List<Workout> GetWorkouts()
        {
            var workouts = new BrisWorkouts(_dr);
            return workouts.GetWorkouts();
        }

        public string Workouts
        {
            get
            {
                var workouts = new BrisWorkouts(_dr);
                return workouts.ToString();
            }
        }

        public string OwnersSilks
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.OWNERS_SILKS));
            }
        }

        public string Jockey
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.JOCKEY_NAME));
            }
        }

        public string Entry
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.ENTRY_INDICATOR);
            }
        }

        public bool TodaysRaceIsARoute
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.TODAYS_DISTANCE) >= Utilities.MIN_DISTANCE_FOR_ROUTE;
            }
        }

        public bool TodaysRaceIsSynthetic
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.ALL_WEATHER_FLAG).ToUpper().Contains("A");
            }
        }

        public bool TodaysRaceIsInInnerTrack
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_SURFACE);

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
                return Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_SURFACE).ToUpper().Contains("T");
            }
        }

        public bool TodaysRaceIsASprint
        {
            get
            {
                return TodaysRaceIsARoute == false;
            }
        }

        public string TodaysDistance
        {
            get
            {
                int yards = Utilities.GetFieldAsInteger(_dr, FieldIndex.TODAYS_DISTANCE);
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
                return Utilities.GetFieldAsString(_dr, FieldIndex.RACE_TRACK);
            }
        }

        public string TodaysRaceType
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.RACE_TYPE).ToUpper();
            }
        }

        public bool TodaysRaceIsMSW
        {
            get
            {
                string s = TodaysRaceType;
                return s.Length > 0 && s[0] == 'S';
            }
        }

        public bool TodaysRaceIsClaimer
        {
            get
            {
                string s = TodaysRaceType;
                return s.Length > 0 && s[0] == 'C';
            }
        }

        public bool TodaysRaceIsMCL
        {
            get
            {
                string s = TodaysRaceType;
                return s.Length > 0 && s[0] == 'M';
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
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.TODAYS_DISTANCE);
            }
        }

        public string RaceClassification
        {
            get
            {
                string stateBred = Utilities.GetFieldAsString(_dr, FieldIndex.TODAYS_RACE_STATE_BRED);
                stateBred = stateBred.Trim().ToUpper();
                if (stateBred.Length > 0 && stateBred[0] == 'S')
                {
                    stateBred = "S";
                }
                else
                {
                    stateBred = "";
                }

                string restrictions = Utilities.GetFieldAsString(_dr, FieldIndex.AGE_SEX_RESTRICTIONS);
                restrictions = AgeSexRestrictions(restrictions);
                string raceClassification = Utilities.GetFieldAsString(_dr, FieldIndex.RACE_CLASSIFICATION);
                string onTurf = TodaysRaceIsInTurf ? "Turf" : "";
                return stateBred + " " + restrictions + " " + raceClassification + " " + onTurf + " " + TodaysDistance;
            }
        }

        public int RaceNumber
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.RACE_NUMBER);
            }
        }

        public string Name
        {
            get
            {
                return Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.HORSE_NAME));
            }
        }

        public string ProgramNumber
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.PROGRAM_NUMBER);
            }
        }

        public string Sire
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.SIRE);
            }
        }

        public string DamSire
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.DAMS_SIRE);
            }
        }

        public string StateWhereWasBred
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.STATE_WHERE_WAS_BRED);
            }
        }

        public int PostPosition
        {
            get
            {
                int pp = Utilities.GetFieldAsInteger(_dr, FieldIndex.UPDATED_POST_POSITION);
                return pp > 0 ? pp : Utilities.GetFieldAsInteger(_dr, FieldIndex.POST_POSITION);
            }
        }

        public string SireInfo
        {
            get
            {
                string sire = Sire;
                string siresSire = Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.SIRES_SIRE));
                string studFee = FormatCurrency(Utilities.GetFieldAsString(_dr, FieldIndex.SIRES_STUD_FEE));
                return sire + " (" + siresSire + ") " + studFee;
            }
        }

        public string DamInfo
        {
            get
            {
                string dam = Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.DAM));
                string damsSire = Utilities.CapitalizeOnlyFirstLetter(Utilities.GetFieldAsString(_dr, FieldIndex.DAMS_SIRE));
                return dam + " (" + damsSire + ")";
            }
        }

        public int Age
        {
            get
            {
                string yearofbirth = Utilities.GetFieldAsString(_dr, FieldIndex.YEAR_OF_BIRTH);
                if (yearofbirth.Length <= 0)
                {
                    return 0;
                }

                string currentyear = Utilities.GetFieldAsString(_dr, FieldIndex.RACE_DATE);
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
        }

        public string ColorAgeAndSex
        {
            get
            {
                string color = Utilities.GetFieldAsString(_dr, FieldIndex.HORSE_COLOR);
                string sex = Utilities.GetFieldAsString(_dr, FieldIndex.HORSE_SEX);
                string month = Utilities.GetFieldAsString(_dr, FieldIndex.FOALING_MONTH);
                string yearofbirth = Utilities.GetFieldAsString(_dr, FieldIndex.YEAR_OF_BIRTH);
                string age = "";
                string currentyear = "";
                string d = Utilities.GetFieldAsString(_dr, FieldIndex.YEAR_OF_BIRTH);

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
            }
        }

        private double TrainersWinningPercentage
        {
            get
            {
                string stats = Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER_STARTS);
                if (stats.Length <= 0 || Convert.ToDouble(stats) <= 0.0)
                {
                    return 0;
                }

                return Utilities.GetFieldAsDouble(_dr, FieldIndex.TRAINER_WINS)/Utilities.GetFieldAsDouble(_dr, FieldIndex.TRAINER_STARTS);  
            }
        }

        public string TrainersFullName
        {
            get
            {
                return Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER);
            }
        }

        public string TrainerInfo
        {
            get
            {
                string txt = "";

                
                txt = TrainersFullName + " ";
                txt += String.Format("{0:0.00}", TrainersWinningPercentage*100) + "% ";
                txt += " (";

                txt += Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER_STARTS) + " ";
                txt += Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER_WINS) + " ";
                txt += Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER_PLACES) + " ";
                txt += Utilities.GetFieldAsString(_dr, FieldIndex.TRAINER_SHOWS) + " ";
                txt += ")";
                return Utilities.CapitalizeOnlyFirstLetter(txt);
            }
        }

        public Odds MorningLineOdds
        {
            get
            {
                if (Utilities.GetFieldAsString(_dr, FieldIndex.ODDS).Length <= 0)
                {
                    return Odds.Make("0");
                }
                else
                {
                    return Odds.Make(Utilities.GetFieldAsString(_dr, FieldIndex.ODDS));
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
                return ConvertToDouble(Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_DIRT_PEDIGREE_RATING));
            }
        }

        public double BrisMudPedigreeRating
        {
            get
            {
                return ConvertToDouble(Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_MUD_PEDIGREE_RATING));
            }
        }

        public double BrisTurfPedigreeRating
        {
            get
            {
                return ConvertToDouble(Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_TURF_PEDIGREE_RATING));
            }
        }

        public double BrisDistancePedigreeRating
        {
            get
            {
                return ConvertToDouble(Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_DISTANCE_PEDIGREE_RATING));
            }
        }

        public double BrisAvgClassRatingLastThree
        {
            get
            {
                string s = Utilities.GetFieldAsString(_dr, FieldIndex.BRIS_AVG_THREE_LAST_CLASS_RATINGS);
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

        public int NumberOfLifeTimeWins
        {
            get
            {
                return Utilities.GetFieldAsInteger(_dr, FieldIndex.LIFE_TIME_WINS);
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
                        foreach (BrisPastPerformance thisPP in PastPerformances)
                        {
                            foreach (BrisPastPerformance otherPP in brisHorse.PastPerformances)
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
    }
}