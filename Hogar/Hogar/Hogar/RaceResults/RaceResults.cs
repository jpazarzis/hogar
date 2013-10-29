using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;


namespace Hogar.RaceResults
{
    public class RaceResults
    {
        static public List<string> GetAvailableRaceTracks()
        {
            
            List<string> list = new List<string>();

            string sql = string.Format("SELECT DISTINCT TRACK_CODE FROM RACE_DESCRIPTION");
            SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                list.Add((string)myReader["TRACK_CODE"]);
            }
            myReader.Close();

            return list;
        
        }

        static public List<string> GetAvailableDatesForRaceTrack(string trackCode)
        {
            
            List<string> list = new List<string>();

            string sql = string.Format("SELECT DISTINCT DATE_OF_THE_RACE  FROM RACE_DESCRIPTION WHERE TRACK_CODE = '{0}' ORDER BY DATE_OF_THE_RACE DESC",trackCode);
            SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                list.Add((string)myReader["DATE_OF_THE_RACE"]);
            }
            myReader.Close();

            return list;
        
            
        }


    }
}
