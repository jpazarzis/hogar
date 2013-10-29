using System;
using System.Collections.Generic;
using Hogar;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.WinnersForDay
{
    static class DateOfRace
    {
        private static readonly Dictionary<string, List<DateTime>> _racesPool = new Dictionary<string, List<DateTime>>();


        public static bool RaceExistsInDb(string trackCode, DateTime date, int raceNumber)
        {
            int count = 0;
            using (var dbr = new DbReader())
            {
                string sql = string.Format("SELECT COUNT(*) 'COUNTER' FROM RACE_DESCRIPTION WHERE TRACK_CODE = '{0}' AND DATE_OF_THE_RACE = '{1}' AND RACE_NUMBER = {2} ", trackCode, Utilities.GetDateInYYYYMMDD(date), raceNumber);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        count = dbr.GetValue<int>("COUNTER");
                    }
                }
            }
            return count > 0;
        }

        static public List<DateTime> GetDates(string trackCode)
        {
            if (_racesPool.ContainsKey(trackCode))
            {
                return _racesPool[trackCode];
            }
            else
            {
                using (var dbr = new DbReader())
                {
                    var dates = new List<DateTime>();
                    if (dbr.Open(string.Format(@"Select DATE_OF_THE_RACE FROM RACE_DESCRIPTION WHERE TRACK_CODE = '{0}'", trackCode)))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            dates.Add(Utilities.MakeDateTime(dbr.GetValue<string>("DATE_OF_THE_RACE")));
                        }
                    }
                    _racesPool.Add(trackCode, dates);
                    return dates;
                }
            }
        }
    }
}
