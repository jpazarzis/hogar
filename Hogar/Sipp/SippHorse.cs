using System;
using System.Collections.Generic;
using System.Xml;

namespace Sipp
{
    public class SippHorse
    {
        static public SippHorse Make(string programNumber, 
                                    string name, 
                                    double mlodds, 
                                    string jockey, 
                                    string trainer, 
                                    int primePower)
        {
            return new SippHorse
                       {
                           ProgramNumber = programNumber,
                           Name = name,
                           MorningLineOdds = mlodds,
                           Jockey = jockey,
                           Trainer = trainer,
                           PrimePower = primePower
                       };
        }


        // Locall properties

        Dictionary<DateTime, SippOdds> _realTimeOddsHistory = new Dictionary<DateTime, SippOdds>();

        private bool _isContender = true;
        private bool _isBestBet = false;
        private bool _isScratched = false;
        private bool _needsToSaveUserSettings = false;


        internal bool NeedsToSaveUserSettings
        {
            get { return _needsToSaveUserSettings; }
            set { _needsToSaveUserSettings = value; }
        }

        public bool IsContender
        {
            set
            {
                if(!value)
                {
                    _isBestBet = false;
                }

                _isContender = value;
                NeedsToSaveUserSettings = true;
            }
            get
            {
                return _isContender;
            }
        }

        public bool IsBestBet
        {
            get
            {
                return _isBestBet;
            }
            set
            {
                if(value)
                {
                    _isContender = true;    
                }
                
                _isBestBet = value;
                NeedsToSaveUserSettings = true;
            }
        }

        public double RealTimeOdds { get; set; }
        public bool Scratched
        {
            get
            {
                return _isScratched;
            }
            set
            {
                _isScratched = value;
                NeedsToSaveUserSettings = true;
                this.Parent.ReassignPostPositions();
                this.Parent.CaclulateNormalFigures();
            }
        }

        public void AddRealTimeOddsToHistory(SippOdds odds)
        {
            _realTimeOddsHistory.Add(DateTime.Now, odds);
        }

        public string CurrentOddsFromWin { get; set; }
        public string CurrentOddsFromExacta { get; set; }
        public string CurrentOddsFromDouble { get; set; }

        public int ProgramNumberWithoutEntryChar
        {
            get
            {
                string num = ProgramNumber.ToUpper();
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
        }
        
        ///////////////////
        
        public string ProgramNumber { get; set; }
        public string Name { get; set; }
        public double MorningLineOdds { get; set; }
        public string Jockey { get; set; }
        public string JockeyStatistics { get; set; }
        public string Trainer { get; set; }
        public string TrainerStatistics { get; set; }
        public string JockeyTrainerStatistics { get; set; }
        public int PrimePower { get; set; }
        public int DaysOff { get; set; }
        public bool ComingFromLongLayOff { get; set; }
        public bool ComingFromLayOff { get; set; }
        public bool SecondOfLayoff { get; set; }
        public bool ThirdOfLayoff { get; set; }
        public bool FirstTimeOut { get; set; }
        public SippSire Sire { get; set; }
        public SippSire DamSire { get; set; }
        public string LifeTimeRecord{ get; set; }
        public string CurrentYearRecord{ get; set; }
        public string PreviousYearRecord{ get; set; }
        public string TodaysTrackRecord{ get; set; }
        public string WetTrackRecord{ get; set; }
        public string TurfTrackRecord{ get; set; }
        public string TodaysDistanceRecord { get; set; }
        public string ColorAgeAndSex { get; set; }
        public string SireName { get; set; }
        public string Dam { get; set; }
        public double ClaimingPrice { get; set; }
        public string Owner { get; set; }
        public string OwnerSilks { get; set; }
        public int QuirinSpeedPoints { get; set; }
        public string RunningStyle { get; set; }
        public string MedicationAndWeight { get; set; }
        public int PostPosition { get; set; }

        public List<SippPastPerformance> PastPerformances
        {
            get { return _pastPerformances; }
        }

        public List<SippHandicappingFactor> HandicappingFactors
        {
            get { return _handicappingFactors; }
        }

        public SippRace Parent { get; internal set; }

        
        private SippHorse()
        {
            
        }

        public List<int> GetBrisSpeedFiguresForRecentFormCycles()
        {
            var f = new List<int>();

            int longLayoffs = 0;
            const int maxNumberOfFigures = 6;

            foreach (var pp in PastPerformances)
            {
                if (pp.SpeedFigure <= 0)
                    continue;

                f.Add(pp.SpeedFigure);

                if (pp.DaysSincePreviousRace>= 45)
                {
                    ++longLayoffs;
                }

                if (f.Count >= maxNumberOfFigures || longLayoffs >= 3)
                {
                    break;
                }
            }
            return f;
        }

        readonly List<SippHandicappingFactor> _handicappingFactors = new List<SippHandicappingFactor>();
        readonly List<SippPastPerformance> _pastPerformances = new List<SippPastPerformance>();

        internal  void AddToXmlNode(XmlDocument doc, XmlElement node)
        {
            var horse = doc.CreateElement("horse");
           
            horse.SetAttribute("program-number", ProgramNumber);
            horse.SetAttribute("name", Name);
            horse.SetAttribute("moring-line-odds", string.Format("{0:0.00}",MorningLineOdds));
            horse.SetAttribute("jockey", Jockey);
            horse.SetAttribute("jockey-stats", JockeyStatistics);
            horse.SetAttribute("trainer", Trainer);
            horse.SetAttribute("trainer-stats", TrainerStatistics);
            horse.SetAttribute("jockey-trainer-stats", JockeyTrainerStatistics);
            horse.SetAttribute("prime-power", PrimePower.ToString());
            horse.SetAttribute("days-off", DaysOff.ToString());
            horse.SetAttribute("long-lay-off", ComingFromLongLayOff ? "1" : "0");
            horse.SetAttribute("lay-off", ComingFromLayOff ? "1" : "0");
            horse.SetAttribute("second-off-lay-off", SecondOfLayoff ? "1" : "0");
            horse.SetAttribute("third-off-lay-off", ThirdOfLayoff ? "1" : "0");
            horse.SetAttribute("first-time-out", FirstTimeOut ? "1" : "0");
            horse.SetAttribute("life-record", LifeTimeRecord);
            horse.SetAttribute("cur-year-record", CurrentYearRecord);
            horse.SetAttribute("pre-year-record", PreviousYearRecord);
            horse.SetAttribute("track-record", TodaysTrackRecord);
            horse.SetAttribute("wet-record", WetTrackRecord);
            horse.SetAttribute("turf-record", TurfTrackRecord);
            horse.SetAttribute("distance-record", TodaysDistanceRecord);
            horse.SetAttribute("color-age-sex", ColorAgeAndSex);
            horse.SetAttribute("sire-name", SireName);
            horse.SetAttribute("dam-sire-name",Dam);
            horse.SetAttribute("claiming-price", string.Format("{0:0}",ClaimingPrice));
            horse.SetAttribute("owner",Owner);
            horse.SetAttribute("owner-silks",OwnerSilks);
            horse.SetAttribute("quirin-speed-points", string.Format("{0:0}",QuirinSpeedPoints));
            horse.SetAttribute("running-style",RunningStyle);
            horse.SetAttribute("weight",MedicationAndWeight);
            horse.SetAttribute("post-position", PostPosition.ToString());

            var handicappinFactorsNode = doc.CreateElement("handicapping-factors");
            _handicappingFactors.ForEach(hf => hf.AddToXmlNode(doc, handicappinFactorsNode));

            var ppNode = doc.CreateElement("past-performances");
            _pastPerformances.ForEach(pp => pp.AddToXmlNode(doc, ppNode));

            var sireNode = doc.CreateElement("sire");

            if(null == this.Sire)
            {
                Sire = new SippSire();
            }

            Sire.AddToXmlNode(doc, sireNode);

            var damSireNode = doc.CreateElement("dam-sire");
            if (null == this.DamSire)
            {
                DamSire = new SippSire();
            }

            DamSire.AddToXmlNode(doc, damSireNode);

            horse.AppendChild(handicappinFactorsNode);
            horse.AppendChild(ppNode);
            horse.AppendChild(sireNode);
            horse.AppendChild(damSireNode);
            node.AppendChild(horse);
            

        }

        internal void CaclulateNormalFigures(double mean, double stdev)
        {
            

            _pastPerformances.ForEach(pp => pp.CaclulateNormalFigure(mean, stdev));
        }
    }
}