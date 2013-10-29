using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.BrisPastPerformances;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.RaceChart
{
    public class RaceChart
    {
        readonly List<RaceChartLine> _horse = new List<RaceChartLine>();
        public RaceChart(BrisPastPerformance pp)
        {
            string trackCode = pp.TrackCode;
            string date = string.Format("{0}{1:00}{2:00}",pp.Date.Year,pp.Date.Month,pp.Date.Day);
            int raceNumber = Convert.ToInt32(pp.RaceNumber);

            LoadFromDb(trackCode,date,raceNumber);
        }

        public List<RaceChartLine> Results
        {
            get
            {
                return _horse;
            }
        }

        private void LoadFromDb(string trackCode, string date, int raceNumber)
        {
            _horse.Clear();

            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("SelectRaceResults '{0}', '{1}' , {2}", trackCode, date, raceNumber);

                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string programNumber = myReader["PROGRAM_NUMBER"].ToString().Trim();
                    string horseName = myReader["HORSE_NAME"].ToString().Trim();
                    string jockey = myReader["JOCKEY"].ToString().Trim();
                    
                    _horse.Add(new RaceChartLine(horseName,jockey));
                }    
            }
            
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }

        }
    }
}
