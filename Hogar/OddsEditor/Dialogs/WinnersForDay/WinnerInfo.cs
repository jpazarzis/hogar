using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.WinnersForDay
{
    internal class WinnerInfo : IFractionalTimes
    {
        private readonly DateTime _date;
        private readonly int _raceNumber;
        private readonly string _surface;
        private readonly string _aboutDistanceFlag;
        private readonly string _trackCondition;
        private readonly string _abbrRaceClass;
        private readonly string _horseName;
        private readonly double _fraction1;
        private readonly double _fraction2;
        private readonly double _fraction3;
        private readonly double _finalTime;
        private readonly int _raceId;
        private readonly string _stateBredFlag;
        private readonly string _ageSexRestrictions;
        private readonly int _raceGrade;

        public static List<WinnerInfo> LoadFromDb(string trackCode, double distance, string surface, string aboutFlag)
        {
            var list = new List<WinnerInfo>();
            using (var dbr = new DbReader())
            {
                string sql = GetSqlLoader(trackCode, distance, surface, aboutFlag);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        list.Add(new WinnerInfo(dbr));
                    }
                }
            }

            list = RemoveZeroValues(list, (WinnerInfo wik) => wik.FirstFraction());
            list = RemoveZeroValues(list, (WinnerInfo wik) => wik.SecondFraction());
            list = RemoveZeroValues(list, (WinnerInfo wik) => wik.ThirdFraction());
            return list;
        }

        private static List<WinnerInfo> RemoveZeroValues(List<WinnerInfo> list, Func<WinnerInfo, double> func)
        {
            if (list.Count > 0)
            {
                double avg = list.Average(func);
                var list1 = new List<WinnerInfo>();
                foreach (var winnerInfo in list)
                {
                    if (avg == 0 || (func(winnerInfo) >= avg*0.65 && func(winnerInfo) <= avg*1.65))
                    {
                        list1.Add(winnerInfo);
                    }
                }
                return list1;
            }
            else
            {
                return list;
            }
        }

        private static string GetSqlLoader(string trackCode, double distance, string surface, string aboutFlag)
        {
            return string.Format(@"SELECT 
                                                DATE_OF_THE_RACE,
                                                a.RACE_NUMBER, 
                                                DISTANCE, 
                                                SURFACE, 
                                                ABOUT_DISTANCE_FLAG,
                                                TRACK_CONDITION  ,		
                                                ABBR_RACE_CLASS,
                                                HORSE_NAME,
                                                TIME_FOR_FRACTION_1, 
                                                TIME_FOR_FRACTION_2, 
                                                TIME_FOR_FRACTION_3, 
                                                FINAL_TIME,
                                                a.RACE_ID,
                                                STATE_BRED_FLAG,
                                                AGE_SEX_RESTRICTIONS,
                                                RACE_GRADE  
                                            FROM 
                                                RACE_DESCRIPTION a,
                                                RACE_STARTERS b

                                            WHERE 
                                                a.RACE_ID = b.RACE_ID	AND 
                                                a.TRACK_CODE = '{0}' AND 
                                                a.CONTAINS_VALID_TIME = 'Y' AND
                                                a.DISTANCE = {1} AND
                                                a.SURFACE COLLATE Latin1_General_CS_AS = '{2}' AND
                                                a.ABOUT_DISTANCE_FLAG = '{3}' AND
                                                b.FINISH_POSITION = 1  
                                            ORDER BY 
                                                FINAL_TIME ",
                                 trackCode,
                                 distance,
                                 surface,
                                 aboutFlag);
        }

        private WinnerInfo(DbReader dbr)
        {
            _date = Utilities.MakeDateTime(dbr.GetValue<string>("DATE_OF_THE_RACE"));
            _raceNumber = dbr.GetValue<int>("RACE_NUMBER");
            _surface = dbr.GetValue<string>("SURFACE");
            _aboutDistanceFlag = dbr.GetValue<string>("ABOUT_DISTANCE_FLAG");
            _trackCondition = dbr.GetValue<string>("TRACK_CONDITION");
            _abbrRaceClass = dbr.GetValue<string>("ABBR_RACE_CLASS");
            _horseName = dbr.GetValue<string>("HORSE_NAME");
            _fraction1 = dbr.GetValue<double>("TIME_FOR_FRACTION_1");
            _fraction2 = dbr.GetValue<double>("TIME_FOR_FRACTION_2");
            _fraction3 = dbr.GetValue<double>("TIME_FOR_FRACTION_3");
            _finalTime = dbr.GetValue<double>("FINAL_TIME");
            _raceId = dbr.GetValue<int>("RACE_ID");
            _stateBredFlag = dbr.GetValue<string>("STATE_BRED_FLAG");
            _ageSexRestrictions = dbr.GetValue<string>("AGE_SEX_RESTRICTIONS");
            _raceGrade = dbr.GetValue<int>("RACE_GRADE");
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
        public string Surface
        {
            get
            {
                return _surface;
            }
        }
        public string AboutDistanceFlag
        {
            get
            {
                return _aboutDistanceFlag;
            }
        }
        public string TrackCondition
        {
            get
            {
                return _trackCondition;
            }
        }
        public string AbbrRaceClass
        {
            get
            {
                return _abbrRaceClass;
            }
        }
        public string HorseName
        {
            get
            {
                return _horseName;
            }
        }

       


        public double FirstFraction()
        {
            return _fraction1;
        }

        public double SecondFraction()
        {
            return _fraction2;
        }

        public double ThirdFraction()
        {
            return _fraction3;
        }

        public double FinalTime()
        {
            return _finalTime;
        }

        public int RaceId
        {
            get
            {
                return _raceId;
            }
        }
        public string StateBredFlag
        {
            get
            {
                return _stateBredFlag;
            }
        }
        public string AgeSexRestrictions
        {
            get
            {
                return _ageSexRestrictions;
            }
        }
        public int RaceGrade
        {
            get
            {
                return _raceGrade;
            }
        }
    }
}