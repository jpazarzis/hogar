using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Sipp
{
    public class SippDailyCard : List<SippRace>
    {
        readonly Dictionary<string, List<SippImpactValueStat> > _jockeySummarizedStatistics = new Dictionary<string, List<SippImpactValueStat> >();

       public void AddRace(SippRace race)
       {
           this.Add(race);
           race.Parent = this;
       }

       public List<SippImpactValueStat> GetJockeySummarizedStatistics(string jockeyName)
       {
            jockeyName = jockeyName.ToUpper().Trim();

            if(!_jockeySummarizedStatistics.ContainsKey(jockeyName))
            {
                _jockeySummarizedStatistics.Add(jockeyName, new List<SippImpactValueStat>());
            }

            return _jockeySummarizedStatistics[jockeyName];
       }

       public List<SippHorse> GetHorsesForTrainer(string trainer)
       {
           var horsesForTrainer = new List<SippHorse>();

           foreach (var race in this)
           {
               var horse = race.Find(h => h.Trainer== trainer);

               if (null != horse)
               {
                   horsesForTrainer.Add(horse);
               }
           }

           return horsesForTrainer;
       }


       public List<SippHorse> GetHorsesForJockey(string jockey)
       {
           var horsesForJockey = new List<SippHorse>();

           foreach (var race in this)
           {
               var horse = race.Find(h => h.Jockey == jockey);

               if(null != horse)
               {
                   horsesForJockey.Add(horse);
               }
           }

           return horsesForJockey;
       }


        static public SippDailyCard Make(DateTime dateTime,string trackCode)
        {
            return new SippDailyCard {Date = dateTime, TrackCode = trackCode};
        }

        static public SippDailyCard MakeFromXml(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);
            var node = doc.SelectSingleNode("/race-card");
            var dc = new SippDailyCard { Date = MakeDateTime(node.Attributes["date"].Value), TrackCode = node.Attributes["track-code"].Value };
            foreach (XmlNode raceNode in node.SelectNodes("race"))
            {
                int raceNumber = Convert.ToInt32(raceNode.Attributes["race-number"].Value);
                double distance = Convert.ToDouble(raceNode.Attributes["distance"].Value);
                string surface = raceNode.Attributes["surface"].Value;
                string condition = raceNode.Attributes["condition"].Value;

                var race = SippRace.Make(raceNumber, distance, surface, condition);

                foreach (XmlNode horseNode in raceNode.SelectNodes("horse"))
                {
                    string programNumber = horseNode.Attributes["program-number"].Value;
                    string name = horseNode.Attributes["name"].Value;
                    double odds = Convert.ToDouble(horseNode.Attributes["moring-line-odds"].Value);
                    string jockey = horseNode.Attributes["jockey"].Value;
                    string trainer = horseNode.Attributes["trainer"].Value;
                    int primePower = Convert.ToInt32(horseNode.Attributes["prime-power"].Value);
                    var horse = SippHorse.Make(programNumber, name, odds, jockey, trainer, primePower);

                    horse.DaysOff = Convert.ToInt32(horseNode.Attributes["days-off"].Value);
                    horse.ComingFromLongLayOff = horseNode.Attributes["long-lay-off"].Value == "1";
                    horse.ComingFromLayOff = horseNode.Attributes["lay-off"].Value == "1";
                    horse.SecondOfLayoff = horseNode.Attributes["second-off-lay-off"].Value == "1";
                    horse.ThirdOfLayoff = horseNode.Attributes["third-off-lay-off"].Value == "1";
                    horse.FirstTimeOut = horseNode.Attributes["first-time-out"].Value == "1";
                    horse.LifeTimeRecord = horseNode.Attributes["life-record"].Value;
                    horse.CurrentYearRecord = horseNode.Attributes["cur-year-record"].Value;
                    horse.PreviousYearRecord = horseNode.Attributes["pre-year-record"].Value;
                    horse.TodaysTrackRecord = horseNode.Attributes["track-record"].Value;
                    horse.WetTrackRecord = horseNode.Attributes["wet-record"].Value;
                    horse.TurfTrackRecord = horseNode.Attributes["turf-record"].Value;
                    horse.TodaysDistanceRecord = horseNode.Attributes["distance-record"].Value;
                    horse.JockeyStatistics = horseNode.Attributes["jockey-stats"].Value;
                    horse.TrainerStatistics = horseNode.Attributes["trainer-stats"].Value;
                    horse.JockeyTrainerStatistics = horseNode.Attributes["jockey-trainer-stats"].Value;
                    horse.ColorAgeAndSex = horseNode.Attributes["color-age-sex"].Value;
                    horse.SireName = horseNode.Attributes["sire-name"].Value;
                    horse.Dam = horseNode.Attributes["dam-sire-name"].Value;
                    horse.ClaimingPrice = Convert.ToDouble(horseNode.Attributes["claiming-price"].Value);
                    horse.Owner = horseNode.Attributes["owner"].Value;
                    horse.OwnerSilks = horseNode.Attributes["owner-silks"].Value;
                    horse.QuirinSpeedPoints = Convert.ToInt32(horseNode.Attributes["quirin-speed-points"].Value);
                    horse.RunningStyle = horseNode.Attributes["running-style"].Value;
                    horse.MedicationAndWeight = horseNode.Attributes["weight"].Value;
                    horse.PostPosition = Convert.ToInt32(horseNode.Attributes["post-position"].Value);
                    
                    XmlNode sireNode = horseNode.SelectSingleNode("sire");

                    if(null != sireNode)
                    {
                        horse.Sire = new SippSire(sireNode);
                    }

                    XmlNode damSireNode = horseNode.SelectSingleNode("dam-sire");
                    if (null != sireNode)
                    {
                        horse.DamSire= new SippSire(damSireNode);
                    }


                    var hfs = horse.HandicappingFactors;
                    hfs.Clear();

                    foreach (XmlNode handicappinFactor in horseNode.SelectNodes(@"handicapping-factors/handicapping-factor"))
                    {
                        var hf = SippHandicappingFactor.Make(handicappinFactor.Attributes["name"].Value);
                        
                        int generalStatsSampleSize = Convert.ToInt32(handicappinFactor.Attributes["general-sample-size"].Value);
                        double generalStatsWinPercent = Convert.ToDouble(handicappinFactor.Attributes["general-win-percent"].Value);
                        double generalStatsRoi = Convert.ToDouble(handicappinFactor.Attributes["general-roi"].Value);
                        double generalStatsIv = Convert.ToDouble(handicappinFactor.Attributes["general-iv"].Value);

                        int trainerStatsSampleSize = Convert.ToInt32(handicappinFactor.Attributes["trainer-sample-size"].Value);
                        double trainerStatsWinPercent = Convert.ToDouble(handicappinFactor.Attributes["trainer-win-percent"].Value);
                        double trainerStatsRoi = Convert.ToDouble(handicappinFactor.Attributes["trainer-roi"].Value);
                        double trainerStatsIv = Convert.ToDouble(handicappinFactor.Attributes["trainer-iv"].Value);


                        hf.GeneralStats = SippHandicappingFactorStats.Make(generalStatsSampleSize, generalStatsWinPercent, generalStatsRoi, generalStatsIv);
                        hf.TrainerStats = SippHandicappingFactorStats.Make(trainerStatsSampleSize, trainerStatsWinPercent, trainerStatsRoi, trainerStatsIv);

                        hfs.Add(hf);    
                    }

                    foreach (XmlNode pastPerformance in horseNode.SelectNodes(@"past-performances/past-performance"))
                    {
                        var pp = new SippPastPerformance();

                        pp.DaysSincePreviousRace = Convert.ToInt32(pastPerformance.Attributes["days-since-previous-race"].Value);
                        pp.DaysSinceTodaysRace = Convert.ToInt32(pastPerformance.Attributes["days-since-todays-race"].Value);
                        pp.RacingDate = MakeDateTime(pastPerformance.Attributes["racing-date"].Value);
                        pp.RaceNumber = Convert.ToInt32(pastPerformance.Attributes["race-number"].Value);
                        pp.TrackCode = pastPerformance.Attributes["track-code"].Value;
                        pp.TrackCondition = pastPerformance.Attributes["track-condition"].Value;
                        pp.Distance = pastPerformance.Attributes["distance"].Value;
                        pp.DistanceInYards = Convert.ToInt32(pastPerformance.Attributes["distance-in-yards"].Value);
                        pp.AboutDistanceFlag = pastPerformance.Attributes["about-distance-flag"].Value == "1";
                        pp.Surface = pastPerformance.Attributes["surface"].Value;
                        pp.RaceCondition = pastPerformance.Attributes["race-condition"].Value;
                        pp.FirstCall= pastPerformance.Attributes["first-call"].Value;
                        pp.SecondCall= pastPerformance.Attributes["second-call"].Value;
                        pp.ThirdCall= pastPerformance.Attributes["third-call"].Value;
                        pp.FinalTime= pastPerformance.Attributes["final-time"].Value;
                        pp.WinnersFinalTime = Convert.ToDouble(pastPerformance.Attributes["winners-final-time"].Value);
                        pp.ThisHorseFinalTime = Convert.ToDouble(pastPerformance.Attributes["this-horse-final-time"].Value);
                        pp.PostPosition= Convert.ToInt32(pastPerformance.Attributes["post-position"].Value);
                        pp.FirstCallPosition = pastPerformance.Attributes["first-call-position"].Value;
                        pp.SecondCallPosition = pastPerformance.Attributes["second-call-position"].Value;
                        pp.ThirdCallPosition = pastPerformance.Attributes["third-call-position"].Value;
                        pp.FinalPosition= pastPerformance.Attributes["final-position"].Value;        
                        pp.FirstCallLengthsBehind= pastPerformance.Attributes["first-call-lengths-behind"].Value;        
                        pp.SecondCallLengthsBehind= pastPerformance.Attributes["second-call-lengths-behind"].Value;        
                        pp.ThirdCallLengthsBehind= pastPerformance.Attributes["third-call-lengths-behind"].Value;        
                        pp.FinalLengthsBehind= pastPerformance.Attributes["final-lengths-behind"].Value;    
                        pp.TrackVariant= Convert.ToInt32(pastPerformance.Attributes["track-variant"].Value);
                        pp.SpeedFigure= Convert.ToInt32(pastPerformance.Attributes["speed-figure"].Value);
                        pp.Jockey= pastPerformance.Attributes["jockey"].Value;    
                        pp.MedicationWeightEquipment= pastPerformance.Attributes["weight"].Value;    
                        pp.Odds= pastPerformance.Attributes["odds"].Value;    
                        pp.FieldSize= Convert.ToInt32(pastPerformance.Attributes["field-size"].Value);
                        pp.WinnersName = pastPerformance.Attributes["winners-name"].Value;
                        pp.SecondPlaceFinisherName = pastPerformance.Attributes["second-name"].Value;
                        pp.ThirdPlaceFinisherName = pastPerformance.Attributes["third-name"].Value;    
            
                        horse.PastPerformances.Add(pp);
                    }

                    race.AddHorse(horse);
                }

                race.ReassignPostPositions();
                race.CaclulateNormalFigures();
                dc.AddRace(race);
            }

            // Now Load the jockey statistics for all the jockeys of the day

            
            foreach (XmlNode jockeyNode in node.SelectNodes(@"jockey-stats/jockey"))
            {
                string jockeyName = jockeyNode.Attributes["jockey-name"].Value;

                var stats = dc.GetJockeySummarizedStatistics(jockeyName);

                foreach (XmlNode statNode in jockeyNode.SelectNodes(@"stat"))
                {
                    
                    var sippImpactValueStat = new SippImpactValueStat
                                                  {
                                                      Name = statNode.Attributes["stat-name"].Value,
                                                      Starters = Convert.ToInt32(statNode.Attributes["stat-starters"].Value),
                                                      WinPercentage = Convert.ToDouble(statNode.Attributes["stat-win-percent"].Value),
                                                      Roi = Convert.ToDouble(statNode.Attributes["stat-roi"].Value),
                                                      IV = Convert.ToDouble(statNode.Attributes["stat-iv"].Value)
                                                  };

                    stats.Add(sippImpactValueStat);
                }

            }

            dc.LoadUserSettings();

            return dc;
        }

        string UserSettingsFilename
        {
            get
            {
                return string.Format("sipp-user-{0}-{1}{2:00}{3:00}.xml",TrackCode, Date.Year,Date.Month,Date.Day);
            }
        }

        public static string UserDirectory { get; set; }

        private void LoadUserSettings()
        {
            if (null == UserDirectory || !Directory.Exists(UserDirectory))
                return;
            string filename = string.Format(@"{0}\{1}", UserDirectory, UserSettingsFilename);

            if(!File.Exists(filename))
                return;

            var doc = new XmlDocument();
            doc.Load(filename);
            

            foreach (XmlNode raceNode in doc.SelectNodes(@"/user-changes/race-node"))
            {
                int raceNumber = Convert.ToInt32(raceNode.Attributes["race-number"].Value);

                var race = this.Find(r => r.RaceNumber == raceNumber);

                if(null == race)
                    continue;

                foreach (XmlNode horseNode in raceNode.SelectNodes(@"horse-node"))
                {
                    string programNumber = horseNode.Attributes["program-number"].Value;
                    var horse = race.Find(h => h.ProgramNumber == programNumber);

                    if(null == horse)
                        continue;

                    if(null != horseNode.Attributes["scratched"])
                    {
                        horse.Scratched = true;
                    }
                    else
                    {
                        horse.IsContender = horseNode.Attributes["is-contender"].Value == "1";
                        horse.IsBestBet = horseNode.Attributes["is-best-bet"].Value == "1";   
                    }
                }
            }
        }

        public void SaveUserSettings()
        {

            if (null == UserDirectory || !Directory.Exists(UserDirectory))
               return;

            string filename = string.Format(@"{0}\{1}", UserDirectory, UserSettingsFilename);
            var doc = new XmlDocument();
            var mainNode = doc.CreateElement("user-changes");

            foreach (var race in this)
            {
                var raceNode = doc.CreateElement("race-node");
                raceNode.SetAttribute("race-number", race.RaceNumber.ToString());
                foreach (var horse in race)
                {
                    var horseNode = doc.CreateElement("horse-node");
                    horseNode.SetAttribute("program-number", horse.ProgramNumber);
                    if(horse.Scratched)
                    {
                        horseNode.SetAttribute("scratched", "YES");
                    }
                    else
                    {
                        horseNode.SetAttribute("is-contender", horse.IsContender ? "1" : "0");
                        horseNode.SetAttribute("is-best-bet", horse.IsBestBet ? "1" : "0");
                    }
                    raceNode.AppendChild(horseNode);
                }
                mainNode.AppendChild(raceNode);
            }

            doc.AppendChild(mainNode);

            doc.Save(filename);

            foreach (var race in this)
            {
                foreach (var horse in race)
                {
                    horse.NeedsToSaveUserSettings = false;
                }
            }
        }

        public bool NeedsToSaveUserSettings
        {
            get
            {
                foreach (var race in this)
                {
                    foreach (var horse in race)
                    {
                        if (horse.NeedsToSaveUserSettings)
                            return true;
                    }
                }

                return false;
            }
            
        }

        public void SaveToXml(string filename)
        {
            var doc = new XmlDocument();

            var node = doc.CreateElement("race-card");
            node.SetAttribute("track-code", TrackCode);
            node.SetAttribute("date", string.Format("{0}{1:00}{2:00}", Date.Year, Date.Month, Date.Day));
            doc.AppendChild(node);
            this.ForEach(r=>r.AddToXmlNode(doc,node));

            var jockeysNode = doc.CreateElement("jockey-stats");

            foreach (var jockey in _jockeySummarizedStatistics.Keys)
            {
                var jockeyNode = doc.CreateElement("jockey");
                jockeyNode.SetAttribute("jockey-name", jockey);

                foreach (var stat in _jockeySummarizedStatistics[jockey])
                {
                    var statNode = doc.CreateElement("stat");
                    statNode.SetAttribute("stat-name", stat.Name);
                    statNode.SetAttribute("stat-starters", stat.Starters.ToString());
                    statNode.SetAttribute("stat-win-percent", string.Format("{0:0.00}", stat.WinPercentage));
                    statNode.SetAttribute("stat-roi", string.Format("{0:0.00}", stat.Roi));
                    statNode.SetAttribute("stat-iv", string.Format("{0:0.00}", stat.IV));
                    jockeyNode.AppendChild(statNode);
                }

                jockeysNode.AppendChild(jockeyNode);
            }

            node.AppendChild(jockeysNode);

            doc.Save(filename);
        }


        public DateTime Date { get; private set; }
        public string TrackCode { get; private set; }

        private SippDailyCard()
        {
            
        }

        private static DateTime MakeDateTime(string dateInYYYYMMDD)
        {
            int year = 2000, month = 1, day = 1;

            int.TryParse(dateInYYYYMMDD.Substring(0, 4), out year);
            int.TryParse(dateInYYYYMMDD.Substring(4, 2), out month);
            int.TryParse(dateInYYYYMMDD.Substring(6, 2), out day);

            return new DateTime(year, month, day);
        }
    }
}
