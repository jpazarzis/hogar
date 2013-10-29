using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.DbTools;
using Hogar.Handicapping;

namespace OddsEditor.Dialogs.FactorWorkbench
{
    internal class HorseInfo
    {
        private readonly int _raceid;
        private readonly string _trackCode;
        private readonly DateTime _date;
        private readonly int _raceNumber;
        private readonly string _horseName;
        private readonly int _finishPosition;
        private readonly double _distance;
        private readonly double _odds;
        private readonly string _surface;
        private readonly string _raceClassification;
        private readonly string _offTurfIndicator;
        private readonly string _trainer;

        private readonly string _raceClassificationAbrv;

        public string GetKey(GroupType gt)
        {
            switch (gt)
            {
                case GroupType.Track:
                    return _trackCode;
                case GroupType.Distance:
                    return _distance <= Utilities.MIN_DISTANCE_FOR_ROUTE ? "SPRINT" :"ROUTE";
                case GroupType.Classification:
                    return _raceClassificationAbrv;
                case GroupType.Trainer:
                    return _trainer;
                default:
                    return "Not Supported";
            }
        }

        public static List<HorseInfo> LoadFromDb(Factor factor)
        {
            var hi = new List<HorseInfo>();
            using (var dbr = new DbReader())
            {
                var sql = string.Format("EXEC SelectAllMatchingHorsesByFactorsFlag {0}", factor.BitMask);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        hi.Add(new HorseInfo(dbr));
                    }
                }
            }
            return hi;
        }

        private HorseInfo(DbReader dbr)
        {
            _raceid = dbr.GetValue<int>("RACE_ID");   
            _trackCode= dbr.GetValue<string>("TRACK_CODE").Trim().ToUpper();   
            _date = Utilities.MakeDateTime(dbr.GetValue<string>("DATE"));
            _raceNumber = dbr.GetValue<int>("RACE");   
            _horseName= dbr.GetValue<string>("NAME");   
            _finishPosition = dbr.GetValue<int>("POS");
            _distance = dbr.GetValue<double>("DIST");
            _odds = dbr.GetValue<double>("ODDS");
            _surface= dbr.GetValue<string>("SUR");   
            _raceClassification = dbr.GetValue<string>("CLASS");
            _offTurfIndicator = dbr.GetValue<string>("OFF");
            _trainer = dbr.GetValue<string>("TRAINER");
            _raceClassificationAbrv = MakeClassAbr(_raceClassification);
        }

        static string MakeClassAbr(string s )
        {
            s = s.ToUpper();
            if (s.Contains("MSW"))
            {
                return "MSW";
            }
            else if (s.Contains("MCL"))
            {
                return "MCL";
            }
            else if (s.Contains("ALW") || s.Contains("OCLM"))
            {
                return "ALW";
            }
            else if (s.Contains("G1") || s.Contains("G2") || s.Contains("G3"))
            {
                return "CLM";
            }
            else if (s.Contains("CL"))
            {
                return "CL";
            }
            else
            {
                return "*";
            }
        }

        public int RaceId
        {
            get
            {
                return _raceid;
            }
        }
        public string TrackCode
        {
            get
            {
                return _trackCode;
            }
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
        }
        public int RaceNumber
        {
            get
            {
                return _raceNumber;
            }
        }
        public string HorseName
        {
            get
            {
                return _horseName;
            }
        }
        public int FinishPosition
        {
            get
            {
                return _finishPosition;
            }
        }
        public double Distanec
        {
            get
            {
                return _distance;
            }
        }
        public double Odds
        {
            get
            {
                return _odds;
            }
        }
        public string Surface
        {
            get
            {
                return _surface;
            }
        }
        public string RaceClassification
        {
            get
            {
                return _raceClassification;
            }
        }
        public string OffTurfIndicator
        {
            get
            {
                return _offTurfIndicator;
            }
        }
    }
}