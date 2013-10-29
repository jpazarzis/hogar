using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;


namespace Hogar.StatisticTools
{
    static public class TrainerStatisticsCollection
    {
        static Dictionary<string, TrainerStatistics> _trainerStats = new Dictionary<string, TrainerStatistics>();

        static public List<TrainerStatistics> TrainerStatsAsList
        {
            get
            {
                List<TrainerStatistics> list = new List<TrainerStatistics>();
                foreach (KeyValuePair<string, TrainerStatistics> pair in _trainerStats)
                {
                    list.Add(pair.Value);
                }
                return list;
            }
        }

        static TrainerStatisticsCollection()
        {
            Load();
        }

        static private void Load()
        {
            _trainerStats.Clear();

            SqlDataReader myReader = null;
            try
            {
                string sql = @"SELECT   ABBR_TRAINER_NAME, 
                                        OFFICIAL_POSITION, 
                                        DAYS_OFF 
                                FROM 
                                        TRAINER_STATS 
                                ORDER BY ABBR_TRAINER_NAME";

                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string name = myReader["ABBR_TRAINER_NAME"].ToString();
                        int officialPosition = (int)myReader["OFFICIAL_POSITION"];
                        int daysOff = (int)myReader["DAYS_OFF"];

                        if (!_trainerStats.ContainsKey(name))
                        {
                            _trainerStats.Add(name, new TrainerStatistics(name));
                        }

                        _trainerStats[name].AddStarterInfo(officialPosition, daysOff);

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
    }
}
