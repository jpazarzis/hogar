using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    
    public class RaceCollection
    {
       readonly List<Race> _races = new List<Race>();

        private readonly int _numberOfRacesToLoad;

       public RaceCollection(int numberOfRacesToLoad)
        {
           _numberOfRacesToLoad = numberOfRacesToLoad;
            LoadFromDb();
        }

        public List<Race>  Races
        {
            get
            {
                return _races;
            }
        }

        private void LoadFromDb()
        {
            _races.Clear();
            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(SqlLoadFromDb, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                int currentRaceId = -9999;

                Race race = null;
                int count = 0;
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int raceid = myReader.GetInt32(0);
                        long factorsFlag = myReader.GetInt64(1);
                        double winPayoff = myReader.GetDouble(2);
                        double odds = myReader.GetDouble(3);

                        if(currentRaceId!=raceid)
                        {
                            if(_races.Count >= _numberOfRacesToLoad)
                            {
                                break;
                            }

                            race = new Race();
                            currentRaceId = raceid;
                            _races.Add(race);
                        }

                        race.AddHorse(factorsFlag, winPayoff, odds);
                       Trace.WriteLine(++count);
                    }
                }
                myReader.Close();
                Trace.WriteLine(string.Format("Number of races = {0}",_races.Count));
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
                
            }
        }

        public string SqlLoadFromDb
        {
            get
            {
                /*
                return @"SELECT 
	                        RACE_ID, FACTORS_FLAG, WIN_PAYOFF  
                        FROM 
	                        HORSE_FACTORS 

                        ORDER BY RACE_ID";*/
                
                /* use this for maidens ONLY*/
                return
                    string.Format(
                        @"SELECT 
                                a.RACE_ID, a.FACTORS_FLAG, a.WIN_PAYOFF, b.ODDS 
                            FROM 
                                HORSE_FACTORS a, RACE_STARTERS b 
                            WHERE 
                                a.RACE_ATTRIBUTES & 64 = 64 AND a.HORSE_ID = b.ID
                            ORDER BY a.RACE_ID");
                                             
            }
        }
    }
}
