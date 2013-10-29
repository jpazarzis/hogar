using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.BrisPastPerformances;
using System.Text;
using Hogar.Filter;
using Hogar.Handicapping.Analysis;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar.ExFigure;
using System.IO;
using Hogar.Cynthia;

namespace Hogar
{
    [Serializable]
    public class Race : ISerializable
    {
        private const int MIN_FACTORS_DEPTH = 1;
        private const int MAX_FACTORS_DEPTH = 5;

        public static readonly double TAKE_OUT_PERCENT = 0.15;
        private readonly List<Horse> _horse = new List<Horse>();
        private DailyCard _parent = null;
        private BrisRace _correspondingBrisRace = null;
        private readonly int _raceNumber = 0;
        private bool _isHidden = false;
        private string _raceComments = "";
        private Dictionary<string, Horse> _mapProgramNumbetToHorse = new Dictionary<string, Horse>();
        private bool _needsToBuildIndex = true;

        // The following two field come from the db
        private string _winnerOfTheRace = "";
        private double _winnersPayoff = -1.0;
        private bool _existsInDb = false;
        private int _raceID = -1;
        private int _factorsDepth = 1;

        private Utilities.Surface _surfaceWhereTheRaceWasRun = Utilities.Surface.Invalid;

        private List<RaceAttributes> _raceAttributesToUseForHandicapping = null;

        private RaceClassification _raceClassification = null;

        private bool _needsToReadDataFromDb = true;
        private double _finalTime = 0.0; // Comes for the db for races that already exist there
        private double _distance = 0.0; // Comes for the db for races that already exist there

        private bool _needsToCalculateUnadjustedNormalizedSpeed = true;
        private double _unadjustedNormalizedSpeedOfTheRace = 0.0;

        private System.ComponentModel.BackgroundWorker _backgroundWorker = null;

        #region Cynthia's Time Projections

        public string CynthiaClassification
        {
            get
            {
                BrisHorse h = _correspondingBrisRace.Horses[0];
                return CynthiaPar.MakeCynthiaClassification(h.TodaysRaceType, RaceRestrictions, h.ClaimingPriceOfTheRace);
            }
        }

        public List<SpeedInfo> SpeedAnalysis
        {
            get
            {
                var list = new List<SpeedInfo>();
                _horse.ForEach(h=>list.Add(new SpeedInfo(h)));
                return list;
            }
        }

        public CynthiaPar CynthiaParsForTheRace
        {
            get
            {
                BrisHorse h = _correspondingBrisRace.Horses[0];


                char surface = SurfaceFlagToUseForCynthia;
                char aboutFlag = _correspondingBrisRace.IsAboutDistance ? 'A' : 'N';
                return CynthiaPar.Make(_parent.TrackCode, surface, _correspondingBrisRace.DistanceInYards, CynthiaClassification, aboutFlag);
            }
        }

      


        public string GetAsXML()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("<RACE>"));
            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("<RACE_TRACK>{0}</RACE_TRACK>", RaceTracks.GetNameFromTrackCode(_parent.TrackCode)));
            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("<RACE_NUMBER>{0}</RACE_NUMBER>", _raceNumber));
            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("<CLASSIFICATION>{0}</CLASSIFICATION>", _correspondingBrisRace.RaceClassification));
            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("<HORSES>"));
            sb.Append(string.Format(Environment.NewLine));
            foreach (Horse horse in _horse)
            {
                sb.Append(string.Format("<HORSE>"));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<PROGRAM_NUMBER>{0}</PROGRAM_NUMBER>", horse.ProgramNumber));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<NAME>{0}</NAME>", horse.Name));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<JOCKEY>{0}</JOCKEY>", horse.CorrespondingBrisHorse.Jockey));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<TRAINER>{0}</TRAINER>", horse.CorrespondingBrisHorse.TrainerInfo));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<MORNING_LINE>{0}-1</MORNING_LINE>", Odds.Make(horse.MorningLineOdds.ToString()).GetOddsToOne()));
                sb.Append(string.Format(Environment.NewLine));

                string firstCall = "", secondCall = "", thirdCall = "", lastFraction = "";
                string trackCode = "", date = "", raceClassification = "", surface = "", trackCondition = "";
                string firstFractionPosition = "", secondFractionPosition = "", finalPosition = "";

                BrisPastPerformance pp = horse.SelectedRunningLine;
                if (null != pp)
                {
                    firstCall = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFirstCall);
                    secondCall = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedSecondCall);
                    thirdCall = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFinalCall);
                    lastFraction = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFinalCall - pp.AdjustedSecondCall);
                    trackCode = pp.TrackCode.ToUpper();
                    date = pp.DateAsString;
                    raceClassification = pp.RaceClassification;
                    surface = pp.Surface;
                    trackCondition = pp.TrackCondition;
                    firstFractionPosition = pp.FirstFractionPosition;
                    secondFractionPosition = pp.SecondFractionPosition;
                    finalPosition = pp.FinalPosition;
                }

                sb.Append(string.Format("<TRACK_CODE>{0}</TRACK_CODE>", trackCode));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<DATE>{0}</DATE>", date));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<RACE_CLASSIFICATION>{0}</RACE_CLASSIFICATION>", raceClassification));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<SURFACE>{0}</SURFACE>", surface));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<TRACK_CONDITION>{0}</TRACK_CONDITION>", trackCondition));
                sb.Append(string.Format(Environment.NewLine));

                sb.Append(string.Format("<FIRST_CALL>{0}</FIRST_CALL>", firstCall));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<SECOND_CALL>{0}</SECOND_CALL>", secondCall));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<THIRD_CALL>{0}</THIRD_CALL>", thirdCall));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<LAST_FRACTION>{0}</LAST_FRACTION>", lastFraction));
                sb.Append(string.Format(Environment.NewLine));

                sb.Append(string.Format("<FIRST_CALL_POSITION>{0}</FIRST_CALL_POSITION>", firstFractionPosition));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<SECOND_CALL_POSITION>{0}</SECOND_CALL_POSITION>", secondFractionPosition));
                sb.Append(string.Format(Environment.NewLine));
                sb.Append(string.Format("<THIRD_CALL_POSITION>{0}</THIRD_CALL_POSITION>", finalPosition));
                sb.Append(string.Format(Environment.NewLine));

                sb.Append(string.Format("</HORSE>"));
                sb.Append(string.Format(Environment.NewLine));
            }
            sb.Append(string.Format("</HORSES>"));
            sb.Append(string.Format(Environment.NewLine));
            sb.Append(string.Format("</RACE>"));
            sb.Append(string.Format(Environment.NewLine));

            string temp = sb.ToString();
            temp = temp.Replace("&", "&amp;");
            temp = temp.Replace("'", "&apos;");

            return temp;
        }

        private string RaceRestrictions
        {
            get
            {
                string s = _correspondingBrisRace.Horses[0].RaceClassification.ToUpper();
                s = s.Replace("N1", "NW1");
                s = s.Replace("N2", "NW2");
                s = s.Replace("N3", "NW3");
                s = s.Replace("N4", "NW4");
                return s;
            }
        }

        private char SurfaceFlagToUseForCynthia
        {
            get
            {
                BrisHorse h = _correspondingBrisRace.Horses[0];
                if (h.TodaysRaceIsInTurf)
                {
                    return h.TodaysRaceIsInInnerTrack ? 'I' : 'T';
                }
                else
                {
                    return h.TodaysRaceIsInInnerTrack ? 'N' : 'D';
                }
            }
        }

        #endregion

        public static Race MakeRaceFromBrisRace(BrisRace brisRace)
        {
            Race r = new Race(brisRace.RaceNumber);
            r.LoadFromBrisRace(brisRace);
            return r;
        }

        public Race(SerializationInfo info, StreamingContext ctxt)
        {
            _raceNumber = (int) info.GetValue("_raceNumber", typeof (int));
            _horse = (List<Horse>) info.GetValue("_horse", typeof (List<Horse>));
            _isHidden = (bool) Utilities.GetSerializedObject(info, "_isHidden", typeof (bool), false);
            _raceComments = (string) Utilities.GetSerializedObject(info, "_raceComments", typeof (string), "");
            _raceAttributesToUseForHandicapping = (List<RaceAttributes>) Utilities.GetSerializedObject(info, "_raceAttributesToUseForHandicapping", typeof (List<RaceAttributes>), null);
            _factorsDepth = (int) Utilities.GetSerializedObject(info, "_factorsDepth", typeof (int), 1);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_raceNumber", _raceNumber);
            info.AddValue("_horse", _horse);
            info.AddValue("_isHidden", _isHidden);
            info.AddValue("_raceComments", _raceComments);
            info.AddValue("_raceAttributesToUseForHandicapping", _raceAttributesToUseForHandicapping);
            info.AddValue("_factorsDepth", _factorsDepth);
        }

        public System.ComponentModel.BackgroundWorker BGWorker
        {
            set
            {
                _backgroundWorker = value;
            }
        }

        

        public Utilities.Surface SurfaceWhereTheRaceWasRun
        {
            get
            {
                return _surfaceWhereTheRaceWasRun;
            }
            internal set
            {
                _surfaceWhereTheRaceWasRun = value;
            }
        }

        private void ReadFinalTimeAndDistanceFromDb()
        {
            _needsToReadDataFromDb = true;
            _finalTime = _distance = 0.0;

            SqlDataReader myReader = null;
            try
            {
                string sql = "SELECT FINAL_TIME, DISTANCE FROM RACE_DESCRIPTION WHERE RACE_ID = {0}";
                SqlCommand myCommand = new SqlCommand(string.Format(sql, RaceID), Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _finalTime = (double) myReader["FINAL_TIME"];
                        _distance = (double) myReader["DISTANCE"];
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
                _needsToReadDataFromDb = false;
            }
        }


        public void LoadFactorPerformances()
        {
            int count = 0;

            foreach (Horse horse in _horse)
            {
                ++count;
                if (false == horse.Scratched)
                {
                    horse.LoadFactorsPerformance();
                    if (null != _backgroundWorker)
                    {
                        _backgroundWorker.ReportProgress((int) (((double) count/(double) _horse.Count)*100.00));
                    }
                }
            }

            // Close the Db connection in case we are executing in a background worker
            DbTools.DbUtilities.CloseConnection();
        }

        public ParSpeed ParSpeedForTheRace
        {
            get
            {
                return ParSpeed.Make(this);
            }
        }

        private double FinalTime
        {
            get
            {
                if (_needsToReadDataFromDb)
                {
                    ReadFinalTimeAndDistanceFromDb();
                }
                return _finalTime;
            }
        }

        private double Distance
        {
            get
            {
                if (_needsToReadDataFromDb)
                {
                    ReadFinalTimeAndDistanceFromDb();
                }
                return _distance;
            }
        }



        

        public void SpecifyHorsesWithNotes()
        {
            string horsenames = "";
            foreach (Horse horse in _horse)
            {
                horse.HasNotes = false;
                if (horsenames.Length > 0)
                {
                    horsenames += " , ";
                }
                horsenames += " '" + horse.Name + "' ";
            }
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format(@"SELECT HORSE_NAME FROM HORSE_NOTES WHERE HORSE_NAME IN ({0})", horsenames);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Horse horse = GetHorseByName(myReader["HORSE_NAME"].ToString());
                    if (null != horse)
                    {
                        horse.HasNotes = true;
                    }
                }
            }

            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }
        }

        private void CalculateUnadjustedNormalizedSpeed()
        {
            _needsToCalculateUnadjustedNormalizedSpeed = false;
            _unadjustedNormalizedSpeedOfTheRace = 0.0;

            if (!ExistsInDb)
            {
                _unadjustedNormalizedSpeedOfTheRace = 0.0;
                return;
            }

            string sql = @"SELECT TOP 3 FINISH_LENGTHS_BEHIND 
                            FROM RACE_STARTERS WHERE RACE_ID = {0} AND PROGRAM_NUMBER != 'SCR'
                            ORDER BY FINISH_LENGTHS_BEHIND";

            List<double> lengthsBehind = new List<double>();

            SqlDataReader myReader = null;
            try
            {
                SqlCommand myCommand = new SqlCommand(string.Format(sql, RaceID), Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        lengthsBehind.Add((double) myReader["FINISH_LENGTHS_BEHIND"]);
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }

            if (lengthsBehind.Count <= 0)
            {
                _unadjustedNormalizedSpeedOfTheRace = SpeedNormalizer.GetObject(_parent.TrackCode, SurfaceWhereTheRaceWasRun).NormalizeSpeed(FinalTime, Distance);
                return;
            }

            double sum = 0, count = 0;
            foreach (double d in lengthsBehind)
            {
                if (d > 0)
                {
                    sum += (FinalTime + d*0.2);
                    ++count;
                }
            }

            double avg = sum/count;

            double normalizedSpeed = SpeedNormalizer.GetObject(_parent.TrackCode, SurfaceWhereTheRaceWasRun).NormalizeSpeed(avg, Distance);

            if (normalizedSpeed > 25.00 || normalizedSpeed < 10.00)
            {
                _unadjustedNormalizedSpeedOfTheRace = 0.0;
            }
            else
            {
                _unadjustedNormalizedSpeedOfTheRace = normalizedSpeed;
            }
        }

        public double UnadjustedNormalizedSpeedOfTheRace
        {
            get
            {
                if (_needsToCalculateUnadjustedNormalizedSpeed)
                {
                    CalculateUnadjustedNormalizedSpeed();
                }
                return _unadjustedNormalizedSpeedOfTheRace;
            }
        }

        public RaceClassification Classification
        {
            get
            {
                if (null == _raceClassification)
                {
                    _raceClassification = RaceClassification.Make(this);
                }

                return _raceClassification.IsValid ? _raceClassification : null;
            }
        }

        public int RaceID
        {
            get
            {
                return _raceID;
            }
            set
            {
                _raceID = value;
            }
        }

        public long RaceAttributesFlag
        {
            get
            {
                long attr = 0;

                if (null != _raceAttributesToUseForHandicapping)
                {
                    foreach (RaceAttributes ra in _raceAttributesToUseForHandicapping)
                    {
                        if (ra.IsChecked)
                        {
                            attr = attr | ra.Flag;
                        }
                    }
                }
                return attr;
            }
        }

        public static int MaxFactorsDepth
        {
            get
            {
                return MAX_FACTORS_DEPTH;
            }
        }

        public static int MinFactorsDepth
        {
            get
            {
                return MIN_FACTORS_DEPTH;
            }
        }

        // FactorsDepth is used to specify how many combinations of factors will
        // be created... Depth of 1 uses only the individual factors, depth of 2 will use
        // all the posible combinations by 2 etc....
        // The default depth is 1
        public int FactorsDepth
        {
            get
            {
                return _factorsDepth;
            }
            set
            {
                if (value < MinFactorsDepth || value > MaxFactorsDepth)
                {
                    throw new Exception("Invalid Factors Depth!");
                }
                ClearFactorPerformanceCache();
                _factorsDepth = value;
            }
        }

        public void ClearFactorPerformanceCache()
        {
            foreach (Horse h in _horse)
            {
                h.ClearFactorsPerformance();
            }
        }

        public void PrepareForInterpolation()
        {
            _correspondingBrisRace.PrepareForInterpolation();
        }

        private void BuildIndexes()
        {
            _mapProgramNumbetToHorse.Clear();

            foreach (Horse h in _horse)
            {
                string s = h.ProgramNumber.Trim();
                if (s.Length <= 0)
                {
                    continue;
                }

                if (!_mapProgramNumbetToHorse.ContainsKey(s))
                {
                    _mapProgramNumbetToHorse.Add(s, h);
                }
            }

            _needsToBuildIndex = false;
        }

        public void UnscratchAll()
        {
            foreach (Horse h in _horse)
            {
                h.UnscratchItWithoutSaving();
            }
            Parent.Save();
        }

        public List<RaceAttributes> RaceAttributesToUseForHandicapping
        {
            get
            {
                if (null == _raceAttributesToUseForHandicapping)
                {
                    _raceAttributesToUseForHandicapping = new List<RaceAttributes>();

                    foreach (RaceAttributes ra in RaceAttributes.Collection)
                    {
                        _raceAttributesToUseForHandicapping.Add(RaceAttributes.MakeNew(ra));
                    }
                }

                return _raceAttributesToUseForHandicapping;
            }
        }

        public bool ContainsHorse(string horseName)
        {
            foreach (Horse h in _horse)
            {
                if (!h.Scratched)
                {
                    if (h.Name.Trim().ToUpper() == horseName.Trim().ToUpper())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void SaveFactorsToDb()
        {
            if (_raceID > 0)
            {
                DeleteFactorsFromDb();

                foreach (Horse h in _horse)
                {
                    if (null != h.CorrespondingBrisHorse)
                    {
                        h.SaveFactorsToDb();
                    }
                }
            }
        }

        private void DeleteFactorsFromDb()
        {
            if (_raceID > 0)
            {
                string sql = string.Format("DELETE HORSE_FACTORS WHERE RACE_ID={0}", _raceID);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
            }
        }

        public string GetAsHTML()
        {
            string s = "<div class='TableHeader'>";
            s += "Race# " + this.RaceNumber.ToString();

            s += "<table class='RaceTable' border='2' cellspacing='0' cellpadding='7'>";

            s += Environment.NewLine;
            s += "<tbody>";

            foreach (Horse h in _horse)
            {
                if (h.Scratched)
                {
                    continue;
                }
                s += @"<tr>";
                s += @"<td>";
                s += h.ProgramNumber;
                s += @"</td>";
                s += @"<td>";
                s += h.Name;
                s += @"</td>";
                s += @"<td>";
                s += h.CorrespondingBrisHorse.Jockey;
                s += @"</td>";
                s += @"</tr>";
                s += Environment.NewLine;
            }
            s += "</tbody>";
            s += @"</table>";
            s += "</div>";
            s += "<br/ >";

            s += Environment.NewLine;
            return s;
        }

        // Gets the race description from the correspoding Bris Past Performances File
        // Needs some work though since the bris field is not very readable
        public string RaceConditions
        {
            get
            {
                DailyCard dc = this.Parent;

                if (null == dc)
                {
                    return "";
                }

                Debug.Assert(null != dc);
                //string filename = Utilities.PastPerformancesDirectory + @"\" + dc.RaceTrack + dc.Date + ".DRF";

                int year = Convert.ToInt32(dc.Date.Substring(0, 4));
                string filename = Utilities.GetBrisPastPerformancesFilename(year, dc.BrisAbrvTrackCode + dc.Date.Substring(4));
                BrisDailyCard bdc = new BrisDailyCard(dc.BrisAbrvTrackCode, dc.Date);
                bdc.Load(filename);

                BrisRace race = bdc.GetRaceByItsProgramNumber(this.RaceNumber);

                if (race.NumberOfHorses <= 0)
                {
                    return "Race appears not to have any horses!";
                }

                return race[0].RaceConditions;
            }
        }

        public string Comments
        {
            get
            {
                return _raceComments;
            }
            set
            {
                _raceComments = value;
                _parent.Save();
            }
        }

        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                _isHidden = value;
                _parent.Save();
            }
        }

        public DailyCard Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public int FieldSize
        {
            get
            {
                int count = 0;
                foreach (Horse h in _horse)
                {
                    if (!h.Scratched)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }

        public BrisRace CorrespondingBrisRace
        {
            get
            {
                return _correspondingBrisRace;
            }
        }

        internal void InitializeHorses(BrisRace brisRace)
        {
            _correspondingBrisRace = brisRace;
            brisRace.CorrespondingRace = this;
            foreach (Horse horse in _horse)
            {
                if (null != horse)
                {
                    horse.Parent = this;
                    horse.CorrespondingBrisHorse = brisRace.GetHorseFromItsNumber(horse.ProgramNumber);
                }
            }
        }

        public override string ToString()
        {
            string track = RaceTracks.GetNameFromTrackCode(Parent.TrackCode);
            string date = Parent.Date;
            date = Utilities.GetDateInFullDescription(date);
            return string.Format("{0} {1} Race# {2}", track, date, RaceNumber);
        }

        private Race(int raceNumber)
        {
            _raceNumber = raceNumber;
        }

        private void LoadFromBrisRace(BrisRace brisRace)
        {
            for (int i = 0; i < brisRace.NumberOfHorses; ++i)
            {
                Horse h = new Horse(brisRace[i].ProgramNumber, brisRace[i].Name, brisRace[i].MorningLineOdds);
                _horse.Add(h);
            }
            InitializeHorses(brisRace);
        }

        public int RaceNumber
        {
            get
            {
                return _raceNumber;
            }
        }

        public List<Horse> Horses
        {
            get
            {
                return _horse;
            }
        }

        public Horse BettingFavorite
        {
            get
            {
                return _horse.Find(h => h.WasTheBettingFavorite);
            }
        }

        public Horse GetHorseByName(string horseName)
        {
            // TODO: UGLY Please revisit the name conventions
            // Just in case it comes from the database where the ' is stored as `

            horseName = horseName.ToUpper();

            if (horseName.IndexOf('(') >= 0)
            {
                horseName = horseName.Substring(0, horseName.IndexOf('('));
            }

            horseName = horseName.Replace("`", "'").Trim();

            foreach (Horse h in _horse)
            {
                string s = h.Name.Trim().ToUpper();
                ;

                s = s.Replace("`", "'").Trim();

                if (s.CompareTo(horseName) == 0)
                {
                    return h;
                }
            }

            // In case that does not come from the database...
            horseName = horseName.Replace("'", "`").Trim();

            foreach (Horse h in _horse)
            {
                string s = h.Name.Trim();

                if (s.CompareTo(horseName) == 0)
                {
                    return h;
                }
            }

            return null;
        }

        // returns a string and not an int because we need to handle entries like 1A, 2X etc
        public string GetProgramNumberFromHorse(string horseName)
        {
            foreach (Horse h in _horse)
            {
                if (h.Name.Trim().ToUpper() == horseName.Trim().ToUpper())
                {
                    return h.ProgramNumber;
                }
            }

            return "";
        }

        public Horse GetHorseByProgramNumber(string horsenum)
        {
            if (_needsToBuildIndex)
            {
                BuildIndexes();
            }

            horsenum = horsenum.Trim();

            if (horsenum.Length <= 0)
            {
                return null;
            }

            return _mapProgramNumbetToHorse.ContainsKey(horsenum) ? _mapProgramNumbetToHorse[horsenum] : null;
        }

        public bool IsHorseScratched(string horsenum)
        {
            Horse h = GetHorseByProgramNumber(horsenum);
            return null != h ? h.Scratched : false;
        }

        public string WinnersProgramNumberWithoutEntryChar
        {
            get
            {
                return Utilities.GetProgramNumberWithoutEntryChar(_winnerOfTheRace).ToString();
            }
        }

        public Horse Winner
        {
            get
            {
                foreach (Horse h in _horse)
                {
                    if (h.ProgramNumber.ToUpper().Trim() == _winnerOfTheRace)
                    {
                        return h;
                    }
                }
                return null;
            }
        }

        public string WinnersProgramNumber
        {
            get
            {
                return _winnerOfTheRace;
            }
            internal set
            {
                _winnerOfTheRace = value.ToUpper().Trim();
            }
        }

        public double WinnersPayoff
        {
            get
            {
                return _winnersPayoff;
            }
            internal set
            {
                _winnersPayoff = value;
            }
        }

        public bool ExistsInDb
        {
            get
            {
                return _existsInDb;
            }
            internal set
            {
                _existsInDb = value;
            }
        }
        public bool IsMaidenClaimer
        {
            get
            {
                return Classification != null ? Classification.MCL : false;
            }
        }

        internal void AssignFinalOddsFromDb()
        {
            if (_raceID <= 0)
            {
                return;
            }

            using (var dbr = new DbReader())
            {
                string sql = string.Format("Select PROGRAM_NUMBER, ODDS From Race_starters where race_id = {0} AND PROGRAM_NUMBER != 'SCR'", _raceID);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        int programNumber;
                        if (int.TryParse(dbr.GetValue<string>("PROGRAM_NUMBER"), out programNumber))
                        {
                            double finalOdss = dbr.GetValue<double>("ODDS");

                            _horse.ForEach(h => { 
                                                    if (h.GetProgramNumberWithoutEntryChar() == programNumber)
                                                        h.FinalOdds = finalOdss; 
                                                 }
                                                    );
                        }
                    }
                }
            }
        }

        private string GetRaceInfoInNotesFormat()
        {
            var sb = new StringBuilder();


            sb.AppendLine(string.Format("{0}  {1} Race Number: {2}", RaceTracks.GetNameFromBrisAbrv(_parent.TrackCode), Utilities.GetFullDateString(_parent.Date), _raceNumber));
            sb.AppendLine();
            sb.AppendLine(string.Format("{0}", _raceClassification));

            foreach (var horse in _horse)
            {
                sb.AppendLine(string.Format("{0}.\t{1,-25}\t{2}-1\t{3,-25}\t{4,-25}", horse.ProgramNumber, horse.Name, horse.CorrespondingBrisHorse.MorningLineOdds.GetOddsToOne(), horse.CorrespondingBrisHorse.Jockey, horse.CorrespondingBrisHorse.TrainersFullName));
            }

            sb.AppendLine();
            sb.AppendLine("Speed Analysis");
            //sb.AppendLine(new string('\n',5));
            sb.AppendLine("Obvious Contenters");
            //sb.AppendLine(new string('\n', 5));
            sb.AppendLine("Horses trying distance / surface for first time");
            //sb.AppendLine(new string('\n', 5));
            sb.AppendLine("Shippers");
            //sb.AppendLine(new string('\n', 5));
            sb.AppendLine("Long Layoffs");
            



            return sb.ToString();
        }

        public void CreateNotesAsExternalTextFile(string path)
        {
            string notesFileName = string.Format(@"{0}\\{1}{2}{3}.notes", path,_parent.TrackCode, _parent.Date, _raceNumber);

            if (File.Exists(notesFileName))
            {
                throw new Exception(string.Format("File: {0} already exists!",notesFileName));
            }

            var tw = new StreamWriter(notesFileName);
            tw.WriteLine(GetRaceInfoInNotesFormat());
            tw.Close();
        }

        public void HandicapBasedInSpeedFigures()
        {
            var filter = new EliminateBasedInBrisFigureDistribution();
            filter.Apply(this);
        }

        public void AddToWeightXmlNode(XmlDocument doc, XmlElement node)
        {
            var raceNode = doc.CreateElement("race");
            raceNode.SetAttribute("race-number", this.RaceNumber.ToString());
            raceNode.SetAttribute("number-of-horses", this._horse.Count(h=>h.Scratched == false).ToString());
            _horse.Where(h => h.IsContenter && (!h.Scratched)).ToList().ForEach(h2 => h2.AddToWeightXmlNode(doc, raceNode));
            node.AppendChild(raceNode);
        }

        public void AutoAssignValueIndexBasedInMorningLine()
        {
            _horse.ForEach(h => h.AutoAssignValueIndexBasedInMorningLine());
        }
    }
}