using System;
using System.Collections.Generic;
using Hogar.DbTools;

namespace Hogar.StatisticTools
{
    internal class StarterCollection : DataBaseCollection<Starter>
    {

        private const string _loadStartersForJockeyAndTrainer = @"select 
	                                                        a.track_code, 
	                                                        racing_date,
	                                                        abbr_trainer_name, 
	                                                        odds,
	                                                        win_payoff,
	                                                        call_1_position,
	                                                        call_2_position, 
	                                                        call_3_position,
	                                                        finish_position,
	                                                        official_position,
	                                                        favorite_flag,
	                                                        field_size,
                                                            surface,
                                                            distance
                                                        from race_starters a, race_description b 
                                                        where
	                                                        a.race_id = b.race_id  and 
	                                                        abbr_jockey_name = '{0}' and abbr_trainer_name = '{1}'  and program_number != 'scr' ";



        private const string _loadStartersForJockey = @"select 
	                                                        a.track_code, 
	                                                        racing_date,
	                                                        abbr_trainer_name, 
	                                                        odds,
	                                                        win_payoff,
	                                                        call_1_position,
	                                                        call_2_position, 
	                                                        call_3_position,
	                                                        finish_position,
	                                                        official_position,
	                                                        favorite_flag,
	                                                        field_size,
                                                            surface,
                                                            distance
                                                        from race_starters a, race_description b 
                                                        where
	                                                        a.race_id = b.race_id  and 
	                                                        abbr_jockey_name = '{0}' and program_number != 'scr' ";


        static public StarterCollection GetStartersForJockey(string jockeyName)
        {
            var sc = new StarterCollection();
            sc.Load(string.Format(_loadStartersForJockey,jockeyName));
            return sc;
        }


        private StarterCollection()
        {
            
        }

        public static IEnumerable<Starter> GetStartersForJockeyAndTrainer(string jockey, string trainer)
        {
            var sc = new StarterCollection();
            sc.Load(string.Format(_loadStartersForJockeyAndTrainer, jockey,trainer));
            return sc;
        }
    }
}