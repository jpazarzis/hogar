using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.JockeyStatistics
{
    class JockeyStatisticsCollection : List<JockeyStarter>
    {
        readonly string _name;
        const string _sqlLoadFromDb = @"SELECT a.RACE_ID, a.TRACK_CODE, a.RACING_DATE, a.HORSE_NAME, a.ABBR_TRAINER_NAME, a.OWNER_NAME, a.FAVORITE_FLAG, a.ODDS, a.WIN_PAYOFF,
	                                           b.SURFACE, b.DISTANCE, a.CALL_1_POSITION, a.CALL_2_POSITION, a.FINISH_POSITION,a.POST_POSITION, b.TRACK_CONDITION
                                        FROM  RACE_STARTERS a , RACE_DESCRIPTION b
                                        WHERE a.ABBR_JOCKEY_NAME = '{0}' AND a.PROGRAM_NUMBER != 'SCR' AND a.RACE_ID = b.RACE_ID AND a.ABBR_TRAINER_NAME != '' AND a.ABBR_JOCKEY_NAME != '' order by b.date_of_the_race, b.race_number ";

        public JockeyStatisticsCollection(string name)
        {
            _name = name;
            LoadFromDb();
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        private void LoadFromDb()
        {
            
            this.Clear();
            using (var dbr = new DbReader())
            {
                if (dbr.Open(string.Format(_sqlLoadFromDb, _name)))
                {
                    while (dbr.MoveToNextRow())
                    {
                        this.Add(new JockeyStarter(dbr));
                    }
                }
            }
        }
    }
}
