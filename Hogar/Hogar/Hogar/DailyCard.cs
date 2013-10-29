using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;
using Hogar.BrisPastPerformances;
using Hogar.DbTools;
using Hogar.Handicapping;
using Hogar.ExFigure;
using Hogar.SireStats;
using Hogar.StatisticTools;
using Sipp;
using Hogar.FactorStatisticsNew;

namespace Hogar
{
    public delegate void ShowMessageDelegate(string txt);

    [Serializable]
    public class DailyCard : ISerializable
    {
        private static readonly string FACTORS_PROCESSED_ODDS_FILE_EXTENSION = "ODDS";
        private static readonly string UNPROCESSED_ODDS_FILE_EXTENSION = "OXXX"; // Needs To Process Factors

        #region Serializable Data

        private readonly List<Race> _race = new List<Race>();
        private string _brisAbrvTrackCode = "";
        private string _date = "";
        private bool _hideScratches = false;
        private bool _existsInDb = false;

        #endregion

        #region Non Serializable Data

        private BrisDailyCard _correspondingBrisDailyCard = null;
        private static Dictionary<string, DailyCard> _cache = new Dictionary<string, DailyCard>();
        private string _filename = "";

        #endregion

        #region public interface

        public delegate void UpdateObserverDelegate(string msg);

        public event UpdateObserverDelegate UpdateObserverEvent;

        public static List<string> FilesToUpdateFactors
        {
            get
            {
                var f = new List<string>();
                foreach (string pathForYear in AvailablePathsForYears)
                {
                    foreach (string strg in Directory.GetFiles(pathForYear, @"*." + UNPROCESSED_ODDS_FILE_EXTENSION))
                    {
                        f.Add(Path.GetFullPath(strg));
                    }
                }
                return f;
            }
        }

        public static List<string> ExistingFilesOnlyForFuture
        {
            get
            {
                string mask = string.Format(@"*.{0}", UNPROCESSED_ODDS_FILE_EXTENSION);

                //var junk = Directory.GetFiles(PathForThisYear, mask);

                return Directory.GetFiles(PathForThisYear, mask).Select(Path.GetFullPath).ToList();


                long today = 0;
                var f = new List<string>();
                if (long.TryParse(Utilities.GetDateInYYYYMMDD(DateTime.Now), out today))
                {
                    foreach (string pathForYear in AvailablePathsForYears)
                    {
                        foreach (string strg in Directory.GetFiles(pathForYear, @"*." + FACTORS_PROCESSED_ODDS_FILE_EXTENSION))
                        {
                            string s = Path.GetFileNameWithoutExtension(strg).Substring(3);

                            if (null == s)
                                continue;
                            long thisFileDay;
                            if (long.TryParse(s, out thisFileDay))
                            {
                                if (thisFileDay >= today)
                                {
                                    f.Add(Path.GetFullPath(strg));
                                }
                            }
                        }

                        foreach (string strg in Directory.GetFiles(pathForYear, @"*." + UNPROCESSED_ODDS_FILE_EXTENSION))
                        {
                            string s = Path.GetFileNameWithoutExtension(strg).Substring(3);

                            if (null == s)
                                continue;
                            long thisFileDay;
                            if (long.TryParse(s, out thisFileDay))
                            {
                                if (thisFileDay >= today)
                                {
                                    f.Add(Path.GetFullPath(strg));
                                }
                            }
                        }
                    }
                }

                return f;
            }
        }

        public static List<string> ExistingFiles
        {
            get
            {
                var f = new List<string>();
                foreach (string pathForYear in AvailablePathsForYears)
                {
                    foreach (string strg in Directory.GetFiles(pathForYear, @"*." + FACTORS_PROCESSED_ODDS_FILE_EXTENSION))
                    {
                        f.Add(Path.GetFullPath(strg));
                    }

                    foreach (string strg in Directory.GetFiles(pathForYear, @"*." + UNPROCESSED_ODDS_FILE_EXTENSION))
                    {
                        f.Add(Path.GetFullPath(strg));
                    }
                }
                return f;
            }
        }

        public static void ResetCache()
        {
            _cache.Clear();
        }

        public void ApplyNeuralNetwork()
        {
            _race.ForEach(MemoryBasedNeuronNetwork.Apply);
        }

        public void SaveWeights()
        {
            var doc = new XmlDocument();

            var node = doc.CreateElement("race-card");
            node.SetAttribute("track-code", this.TrackCode);
            node.SetAttribute("date", this.Date);

            doc.AppendChild(node);
            _race.ForEach(r=>r.AddToWeightXmlNode(doc,node));

            if(!Directory.Exists(Utilities.RaceWeightsDirectory))
            {
                Directory.CreateDirectory(Utilities.RaceWeightsDirectory);
            }

            string filename = string.Format(@"{0}\{1}_{2}.xml", Utilities.RaceWeightsDirectory, this.TrackCode, this.Date);
            doc.Save(filename);
        }

        public string CreateSippDailyCard(ShowMessageDelegate showMessage)
        {
            var sdc = SippDailyCard.Make(Utilities.MakeDateTime(_date), TrackCode);
            
            
            var jockeys = new List<string>();

            foreach (var race in _race)
            {
                showMessage(string.Format("Processing race number: {0}",race.RaceNumber));

                var r = SippRace.Make(race.RaceNumber,
                                      race.CorrespondingBrisRace.DistanceInYards,
                                      race.CorrespondingBrisRace.Surface,
                                      race.CorrespondingBrisRace.RaceClassification);

                foreach (var horse in race.Horses)
                {
                    if(!horse.Scratched)
                    {
                        showMessage(string.Format("Processing race number: {0} horse number {1}", race.RaceNumber,horse.ProgramNumber));

                        string jockey = horse.CorrespondingBrisHorse.Jockey;
                        string trainer = horse.CorrespondingBrisHorse.TrainersFullName;
               
                        if(!jockeys.Contains(jockey))
                        {
                            jockeys.Add(jockey);
                        }

                        var h = SippHorse.Make(horse.ProgramNumber,
                                               horse.Name,
                                               horse.MorningLineOdds.GetOddsToOne(),
                                               jockey,
                                               Utilities.CapitalizeOnlyFirstLetter(trainer),
                                               horse.CorrespondingBrisHorse.PrimePowerRating);

                        h.DaysOff = horse.CorrespondingBrisHorse.DaysSinceLastRace;
                        h.ComingFromLongLayOff = horse.FirstAfterLongLayoff;
                        h.ComingFromLayOff = horse.FirstAfterLayoff;
                        h.SecondOfLayoff = horse.SecondAfterLayoff;
                        h.ThirdOfLayoff = horse.ThirdAfterLayoff;
                        h.FirstTimeOut = horse.CorrespondingBrisHorse.IsFirstTimeOut;
                        h.HandicappingFactors.Clear();

                        
                        h.JockeyStatistics = FactorStatisticManager.GlobalStatisticsPerJockey(jockey).ToString();
                        h.TrainerStatistics = FactorStatisticManager.GlobalStatisticsPerTrainer(trainer).ToString();
                        h.JockeyTrainerStatistics = FactorStatisticManager.GlobalStatisticsPerTrainerAndJockey(trainer, jockey).ToString();

                        /////  Records 
                        h.LifeTimeRecord= horse.CorrespondingBrisHorse.LifeTimeEarnings;
                        h.CurrentYearRecord= horse.CorrespondingBrisHorse.CurrentYearEarnings;
                        h.PreviousYearRecord= horse.CorrespondingBrisHorse.PreviousYearEarnings;
                        h.TodaysTrackRecord= horse.CorrespondingBrisHorse.TodaysTrackEarnings;
                        h.WetTrackRecord= horse.CorrespondingBrisHorse.WetTrackEarnings;
                        h.TurfTrackRecord = horse.CorrespondingBrisHorse.TurfTrackEarnings;
                        h.TodaysDistanceRecord = horse.CorrespondingBrisHorse.TodaysDistanceEarnings;
                        h.ColorAgeAndSex = horse.CorrespondingBrisHorse.ColorAgeAndSex;
                        h.SireName = horse.CorrespondingBrisHorse.SireInfo;
                        h.Dam = horse.CorrespondingBrisHorse.DamInfo;
                        h.ClaimingPrice = horse.CorrespondingBrisHorse.ClaimingPriceOfTheHorse;
                        h.Owner = horse.CorrespondingBrisHorse.Owner;
                        h.OwnerSilks = horse.CorrespondingBrisHorse.OwnersSilks;
                        h.QuirinSpeedPoints = horse.CorrespondingBrisHorse.QuirinSpeedPoints;
                        h.RunningStyle = horse.CorrespondingBrisHorse.BrisRunStyle;
                        h.MedicationAndWeight = horse.CorrespondingBrisHorse.MedicationAndWeight;
                        h.PostPosition = horse.FinalPosition;

                        ////// Add sire info //////////////////////////
                        string sire1 = horse.CorrespondingBrisHorse.Sire;
                        string sire2 = horse.CorrespondingBrisHorse.DamSire;


                        int i = 0;
                        foreach (DataRow dr in Sire.GetSiresInfo(sire1, sire2).Rows)
                        {
                            var sippSire = new SippSire
                                               {
                                                   Name = dr["Name"].ToString(), 
                                                   FirstTimeOutRating = dr["FTS"].ToString(), 
                                                   MudRating = dr["MUD"].ToString(), 
                                                   TurfRating = dr["TURF"].ToString(), 
                                                   AllWeatherRating = dr["AWS"].ToString(), 
                                                   AverageDistance = dr["DIST"].ToString()
                                               };

                            switch (i)
                            {
                                case 0:
                                    h.Sire = sippSire;
                                    break;
                                default:
                                    h.DamSire = sippSire;
                                    break;
                            }

                            ++i;
                        }

                        //////////////////////////////////////////////
                        foreach (var factorStatistic in horse.FactorStatisticsForHorse)
                        {
                            var sippHandicappingFactor = SippHandicappingFactor.Make(factorStatistic.Name);
                            sippHandicappingFactor.GeneralStats = SippHandicappingFactorStats.Make(factorStatistic.Starters,factorStatistic.WinPercent,factorStatistic.Roi, factorStatistic.IV);
                            var trainerStats = FactorStatisticManager.Get(factorStatistic.BitMask, horse.CorrespondingBrisHorse.TrainersFullName);
                            sippHandicappingFactor.TrainerStats = SippHandicappingFactorStats.Make(trainerStats.Starters, trainerStats.WinPercent, trainerStats.Roi, trainerStats.IV);
                            h.HandicappingFactors.Add(sippHandicappingFactor);
                        }

                        foreach (var pp in horse.CorrespondingBrisHorse.PastPerformances)
                        {
                            var sipp = new SippPastPerformance();

                            sipp.DaysSincePreviousRace = pp.DaysSinceLastRace;
                            sipp.DaysSinceTodaysRace = pp.DaysSinceThatRace ;
                            sipp.RacingDate = pp.Date;
                            sipp.RaceNumber = Convert.ToInt32(pp.RaceNumber);
                            sipp.TrackCode = pp.TrackCode;
                            sipp.TrackCondition = pp.TrackCondition;
                            sipp.Distance = pp.DistanceAbreviation;
                            sipp.DistanceInYards = pp.DistanceInYards;
                            sipp.AboutDistanceFlag = pp.AboutDistanceFlag;
                            sipp.Surface = pp.Surface;
                            sipp.RaceCondition = Utilities.FormatCondition(pp.RaceClassification, pp.IsStateBredRestrictedRace, pp.AgeSexRestrictions);
                            sipp.FirstCall = pp.LeadersFirstCall;
                            sipp.SecondCall = pp.LeadersSecondCall;
                            sipp.ThirdCall = pp.LeadersThirdCall;
                            sipp.FinalTime = pp.LeadersFinalCall;
                            sipp.WinnersFinalTime = pp.WinnersFinalTime;
                            sipp.ThisHorseFinalTime = pp.ThisHorseFinalTime;
                            sipp.PostPosition = Convert.ToInt32(pp.PostPosition);
                            sipp.FirstCallPosition = pp.FirstCallPosition;
                            sipp.SecondCallPosition = pp.SecondCallPosition;
                            sipp.ThirdCallPosition= pp.StretchCallPosition;
                            sipp.FinalPosition = pp.FinalPosition;
                            sipp.FirstCallLengthsBehind = pp.FirstCallDistanceFromLeader;
                            sipp.SecondCallLengthsBehind = pp.SecondCallDistanceFromLeader;
                            sipp.ThirdCallLengthsBehind = pp.StretchCallDistanceFromLeader  ;
                            sipp.FinalLengthsBehind = pp.FinalCallDistanceFromLeader;
                            sipp.TrackVariant = pp.TrackVariant;
                            sipp.SpeedFigure = pp.BrisSpeedRating;
                            sipp.Jockey = pp.Jockey.Length < 16 ? pp.Jockey : pp.Jockey.Substring(0, 15);
                            sipp.MedicationWeightEquipment = pp.Medication + pp.Weight + pp.Equipment;
                            sipp.Odds= pp.Odds;
                            sipp.FieldSize = Convert.ToInt32(pp.NumberOfEntrants);

                            
                            sipp.WinnersName = Utilities.CapitalizeOnlyFirstLetter(pp.WinnersName);
                            sipp.SecondPlaceFinisherName = Utilities.CapitalizeOnlyFirstLetter(pp.SecondPlaceFinisherName);
                            sipp.ThirdPlaceFinisherName = Utilities.CapitalizeOnlyFirstLetter(pp.ThirdPlaceFinisherName);
                            h.PastPerformances.Add(sipp);
                        }


                        r.AddHorse(h);    
                    }
                }

                sdc.AddRace(r);
            }

            //IEnumerable<ImpactValueStat> ImpactValues = JockeyStatistics.Get(jockey).AllStats,
            showMessage("Now Adding the Jockeys Stats");
            foreach (var jockey in jockeys)
            {
                showMessage(string.Format("adding jockey: {0} ", jockey));
                var s = sdc.GetJockeySummarizedStatistics(jockey);

                foreach (var ivs in JockeyStatistics.Get(jockey).AllStats)
                {
                    s.Add(new SippImpactValueStat
                              {
                                  Name = ivs.Name, 
                                  IV = ivs.IV, 
                                  Roi = ivs.ROI, 
                                  Starters = ivs.Starters, 
                                  WinPercentage = ivs.WinPercent
                              });    
                }
            }


            if(!Directory.Exists(Utilities.SippFilesDirectory))
            {
                Directory.CreateDirectory(Utilities.SippFilesDirectory);
            }

            string filename = string.Format(@"{0}\sipp_{1}_{2}.xml", Utilities.SippFilesDirectory,TrackCode,_date);
            sdc.SaveToXml(filename);
            showMessage(string.Format("File {0} was created successfully", filename));
            return filename;
        }

        public void SaveAsXML()
        {
            string filename = string.Format(@"C:\Users\John\Desktop\{0}_{1}.xml", TrackCode, Date);
            TextWriter tw = new StreamWriter(filename);
            tw.WriteLine(@"<?xml version='1.0'?>");
            tw.WriteLine(@"<DAILY_CARD>");
            foreach (Race race in _race)
            {
                tw.WriteLine(race.GetAsXML());
            }
            tw.WriteLine(@"</DAILY_CARD>");
            tw.Close();
        }

        public static DailyCard Load(string filename)
        {
            string key = filename;
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }
            else
            {
                if (!File.Exists(filename))
                {
                    return null;
                }
                Stream stream = File.Open(filename, FileMode.Open);
                var bformatter = new BinaryFormatter();
                var dc = (DailyCard) bformatter.Deserialize(stream);
                stream.Close();
                dc.Initialize();
                _cache.Add(key, dc);
                dc._filename = filename;
                return dc;
            }
        }

        public static DailyCard Load(string trackCode, int year, int month, int day)
        {
            string brisAbrvTrackCode = RaceTracks.GetBrisAbrvFromTrackCode(trackCode);
            string filename = GetExistingFileName(brisAbrvTrackCode, year, month, day);
            return filename.Length > 0 ? Load(filename) : null;
        }

        public static bool OddsFileExists(string raceTrack, int year, int month, int day)
        {
            return GetExistingFileName(raceTrack, year, month, day).Length > 0;
        }

        public static DailyCard MakeNewFromBrisFile(string filename)
        {
            var dc = new DailyCard();
            dc.LoadFromBrisFile(filename);
            dc.Initialize();
            dc.Save();
            return dc;
        }

        public void SaveFactorsToDb()
        {
            if (_existsInDb)
            {
                UpdateScratchesFromDb();
                AssignHorseIds();
                foreach (Race race in _race)
                {
                    if (null != UpdateObserverEvent)
                    {
                        UpdateObserverEvent(string.Format("Processing Race#{0} track {1}, date {2}", race.RaceNumber, _brisAbrvTrackCode, _date));
                    }
                    race.SaveFactorsToDb();
                }
                RenameFileToProcessed();
            }
        }

        public string GetAsHTML()
        {
            string s = "";

            foreach (Race race in _race)
            {
                s += race.GetAsHTML();
            }

            return s;
        }

        public BrisDailyCard CorrespondingBrisDailyCard { get { return _correspondingBrisDailyCard; } }

        public bool ExistsInDb { get { return _existsInDb; } }

        public bool HideScratches
        {
            get { return _hideScratches; }
            set
            {
                _hideScratches = value;
                Save();
            }
        }

        public string BrisAbrvTrackCode { get { return _brisAbrvTrackCode; } }

        public string TrackCode { get { return RaceTracks.GetTrackCodeFromBrisAbrv(_brisAbrvTrackCode); } }

        public string Date { get { return _date; } }

        public double GetOddsToOne(int raceNumber, int horseNumber)
        {
            foreach (Race race in _race)
            {
                if (race.RaceNumber == raceNumber)
                {
                    foreach (Horse horse in race.Horses)
                    {
                        if (horse.GetProgramNumberWithoutEntryChar() == horseNumber)
                        {
                            return horse.MyOdds.GetOddsToOne();
                        }
                    }
                }
            }

            throw new Exception("Sorry! Horse number: " + horseNumber.ToString() + " not found in race number : " + raceNumber.ToString());
        }

        public Race GetRaceFromRaceNumber(int raceNumber)
        {
            foreach (Race race in _race)
            {
                if (race.RaceNumber == raceNumber)
                {
                    return race;
                }
            }

            throw new Exception("Race Number: " + raceNumber.ToString() + " does not exist");
        }

        public override string ToString()
        {
            return _brisAbrvTrackCode + " " + Utilities.GetFullDateString(_date);
        }

        public List<Race> Races { get { return _race; } }

        #endregion

        private static string RootDirectory { get { return Utilities.CommonDirectory + @"\Odds"; } }

        private static string RootDirectoryForYear(int year)
        {
            return RootDirectory + @"\" + year.ToString();
        }

      
        private static string PathForThisYear
        {
            get { return DailyCard.RootDirectory + @"\" + DateTime.Now.Year.ToString(); }
        }
    
        private static List<string> AvailablePathsForYears
        {
            get
            {
                List<string> years = new List<string>();
                foreach (string strg in Directory.GetDirectories(DailyCard.RootDirectory))
                {
                    years.Add(strg);
                }
                return years;
            }
        }

        private void RenameFileToProcessed()
        {
            if (_filename.Contains(UNPROCESSED_ODDS_FILE_EXTENSION))
            {
                string oldname = _filename;
                _filename = _filename.Replace(UNPROCESSED_ODDS_FILE_EXTENSION, FACTORS_PROCESSED_ODDS_FILE_EXTENSION);
                Save();
                File.Delete(oldname);
            }
        }

        private static string GetExistingFileName(string raceTrack, int year, int month, int day)
        {
            string filename = RootDirectoryForYear(year) + @"\" + raceTrack + string.Format("{0:0000}{1:00}{2:00}", year, month, day) + @"." + FACTORS_PROCESSED_ODDS_FILE_EXTENSION;

            if (File.Exists(filename))
            {
                return filename;
            }

            filename = RootDirectoryForYear(year) + @"\" + raceTrack + string.Format("{0:0000}{1:00}{2:00}", year, month, day) + @"." + UNPROCESSED_ODDS_FILE_EXTENSION;
            if (File.Exists(filename))
            {
                return filename;
            }

            return "";
        }

        private DailyCard()
        {
        }

        private void Initialize()
        {
            var bdc = new BrisDailyCard(_brisAbrvTrackCode, Date);
            int year = Convert.ToInt32(Date.Substring(0, 4));
            string filename = Utilities.GetBrisPastPerformancesFilename(year, _brisAbrvTrackCode + Date.Substring(4));
            bdc.Load(filename);
            _correspondingBrisDailyCard = bdc;
            bdc.CorrespondingDailyCard = this;
            
            foreach (Race race in _race)
            {
                race.Parent = this;
                race.InitializeHorses(bdc.GetRaceByItsProgramNumber(race.RaceNumber));
            }

            
            AssignWinnersFromDb();
            AssignRaceIDFromDb();
            if (ExistsInDb)
            {
                AssignFinalOddsFromDb();
            }
             
        }

        // June 18 2010:
        // Since DailyCard will be used in research projects that will focus in
        // some specific races (for example only Maiden etc) I add the method
        // to unload races that are not needed so the used memory can be kept minimal
        public void UnloadUnusedRaces(List<Race> usedRaces)
        {
            _race.RemoveAll(r => usedRaces.Exists(r1 => r1 == r) == false);
        }

        private void AssignFinalOddsFromDb()
        {
            _race.ForEach(r => r.AssignFinalOddsFromDb());
        }

        private void AssignRaceIDFromDb()
        {
            string sql = string.Format("SELECT RACE_ID, RACE_NUMBER, SURFACE From RACE_DESCRIPTION WHERE TRACK_CODE = '{0}' AND DATE_OF_THE_RACE='{1}'", TrackCode, Date);
            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    _existsInDb = true;
                    while (myReader.Read())
                    {
                        int raceNumber = (int) myReader["RACE_NUMBER"];
                        int raceID = (int) myReader["RACE_ID"];
                        string surface = myReader["SURFACE"].ToString().ToUpper();
                        Race race = GetRaceFromRaceNumber(raceNumber);

                        if (null != race)
                        {
                            race.RaceID = raceID;
                            race.SurfaceWhereTheRaceWasRun = surface.Contains("T") ? Utilities.Surface.Turf : Utilities.Surface.Dirt;
                        }
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
        }

        // June 18 2010
        // Used from research programs 
        public void LoadResultsFromDb()
        {
            using (var dbr = new DbReader())
            {
                foreach (var race in _race)
                {
                    string sql = @"SELECT PROGRAM_NUMBER, FAVORITE_FLAG, ODDS , OFFICIAL_POSITION
                            FROM RACE_STARTERS 
                            WHERE TRACK_CODE = '{0}' AND RACING_DATE = '{1}' AND RACE_NUMBER = {2} AND PROGRAM_NUMBER != 'SCR' ";

                    sql = string.Format(sql, TrackCode, Date, race.RaceNumber);

                    if (dbr.Open(sql))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            var pn = dbr.GetValue<string>("PROGRAM_NUMBER");
                            var fv = dbr.GetValue<int>("FAVORITE_FLAG");
                            var odds = dbr.GetValue<double>("ODDS");
                            var pos = dbr.GetValue<int>("OFFICIAL_POSITION");

                            var horse = race.GetHorseByProgramNumber(pn);

                            if (null != horse)
                            {
                                horse.WasTheBettingFavorite = (1 == fv);
                                horse.FinalOdds = odds;
                                horse.FinalPosition = pos;
                            }
                        }
                    }
                }
            }
        }

        private void AssignWinnersFromDb()
        {
            string sql = string.Format("SELECT RACE_NUMBER, PROGRAM_NUMBER, WIN_PAYOFF, FAVORITE_FLAG, ODDS FROM RACE_STARTERS WHERE OFFICIAL_POSITION =1 AND TRACK_CODE = '{0}' AND RACING_DATE = '{1}'", TrackCode, Date);
            foreach (Race race in _race)
            {
                race.ExistsInDb = false;
                race.WinnersProgramNumber = "";
                race.WinnersPayoff = -1.0;
            }

            _existsInDb = false;

            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    _existsInDb = true;
                    while (myReader.Read())
                    {
                        int raceNumber = (int) myReader["RACE_NUMBER"];
                        string winnersProgramNumber = (string) myReader["PROGRAM_NUMBER"];
                        double winpayoff = (double) myReader["WIN_PAYOFF"];
                        int favoriteFlag = (int) myReader["FAVORITE_FLAG"];
                        double odds = (double) myReader["ODDS"];

                        Race race = GetRaceFromRaceNumber(raceNumber);
                        if (null != race)
                        {
                            race.WinnersProgramNumber = winnersProgramNumber;
                            race.WinnersPayoff = winpayoff;

                            var horse = race.Winner;
                            if (null != horse)
                            {
                                horse.WasTheBettingFavorite = (1 == favoriteFlag);
                                horse.FinalOdds = odds;
                            }
                            race.ExistsInDb = true;
                        }
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
        }

        private DailyCard(SerializationInfo info, StreamingContext ctxt)
        {
            _brisAbrvTrackCode = (String) info.GetValue("_raceTrack", typeof (string));
            _date = (String) info.GetValue("_date", typeof (string));
            _race = (List<Race>) info.GetValue("_race", typeof (List<Race>));
            _hideScratches = (bool) Utilities.GetSerializedObject(info, "_hideScratches", typeof (bool), false);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_raceTrack", _brisAbrvTrackCode);
            info.AddValue("_race", _race);
            info.AddValue("_date", _date);
            info.AddValue("_hideScratches", _hideScratches);
        }

        public void Save()
        {
            if (_filename.Length == 0)
            {
                int year = Convert.ToInt32(_date.Substring(0, 4));
                string dir = DailyCard.RootDirectoryForYear(year);
                if (false == Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string filename = dir + @"\" + _brisAbrvTrackCode + _date + "." + UNPROCESSED_ODDS_FILE_EXTENSION;
                Stream stream = File.Open(filename, FileMode.Create);
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this);
                stream.Close();
                _filename = filename;
            }
            else
            {
                Stream stream = File.Open(_filename, FileMode.Create);
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this);
                stream.Close();
            }
        }

        private string GetYearFromFullPathOfBrisFile(string filename)
        {
            try
            {
                string[] token = filename.Split('\\');
                string year = token[token.Length - 2];
                return year.Length == 4 ? year : "0000";
            }
            catch
            {
                return "0000";
            }
        }

        private void LoadFromBrisFile(string filename)
        {
            string year = GetYearFromFullPathOfBrisFile(filename);

            string temp;
            if (filename.IndexOf("DRF") >= 0)
            {
                temp = Path.GetFileName(filename).ToUpper().Replace(".DRF", "");
            }
            else if (filename.IndexOf("MCP") >= 0)
            {
                temp = Path.GetFileName(filename).ToUpper().Replace(".MCP", "");
            }
            else
            {
                throw new Exception("Invalid File Name: " + filename);
            }

            _brisAbrvTrackCode = temp.Substring(0, 3);
            _date = year + temp.Substring(3);
            _race.Clear();

            var rc = new BrisDailyCard(_brisAbrvTrackCode, _date);
            rc.Load(filename);

            List<int> rn = rc.GetProgramNumbersForAllRaces();

            foreach (int raceNumber in rn)
            {
                BrisRace brisRace = rc.GetRaceByItsProgramNumber(raceNumber);

                _race.Add(Race.MakeRaceFromBrisRace(brisRace));
            }
        }

        private void AssignHorseIds()
        {
            SqlDataReader myReader = null;

            try
            {
                string sql = string.Format("SelectHorseIDs '{0}', '{1}'", TrackCode, _date);
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int raceNumber = (int) myReader["RACE_NUMBER"];
                    string horseName = myReader["HORSE_NAME"].ToString();
                    int horseID = (int) myReader["HORSE_ID"];
                    Race race = GetRaceFromRaceNumber(raceNumber);
                    if (null != race)
                    {
                        Horse horse = race.GetHorseByName(horseName);
                        if (null != horse)
                        {
                            horse.HorseID = horseID;
                        }
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

        /// <summary>
        /// Apr 25 2009
        /// Just in case we did not update the race card with scratches
        /// this method gets them from the data base, if the race exists
        /// there and updates the scratch field per race and horse.....
        /// </summary>
        public void UpdateScratchesFromDb()
        {
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("SelectScratches '{0}', '{1}'", TrackCode, _date);
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int raceNumber = (int) myReader["RACE_NUMBER"];
                    string horseName = myReader["HORSE_NAME"].ToString();
                    Race race = GetRaceFromRaceNumber(raceNumber);
                    if (null != race)
                    {
                        Horse horse = race.GetHorseByName(horseName);
                        if (null != horse)
                        {
                            horse.ScratchIt();
                        }
                    }
                }
                this.Save();
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }
        }

        public void AutoAssignValueIndexBasedInMorningLine()
        {
            _race.ForEach(r => r.AutoAssignValueIndexBasedInMorningLine());
            Save();
        }
    }
}