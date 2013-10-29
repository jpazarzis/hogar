using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.RaceResults
{
    class RaceStraightBetPayoff
    {

        static int TRACK_CODE = 0;
        static int RACING_DATE = 1;
        static int RACE_NUMBER = 2;
        static int HORSE_NAME = 4;
        static int PROGRAM_NUMBER = 7;
        static int WIN_PAYOFF = 8;
        static int PLACE_PAYOFF = 9;
        static int SHOW_PAYOFF = 10;	


        readonly ParsableText _pt;

        public RaceStraightBetPayoff(ParsableText pt)
        {
            _pt = pt;
        }

        public void InsertInDb()
        {
            SqlCommand myCommand = new SqlCommand(InsertSql, DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();      
        }

        private string InsertSql
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("EXEC AddNewStraightPayoff ");
                sb.Append("'" + TrackCode + "', ");
                sb.Append("'" + RacingDate + "', ");
                sb.Append(RaceNumber + ", ");
                sb.Append("'" + HorseName + "', ");
                sb.Append("'" + ProgramNumber + "', ");
                sb.Append(WinPayoff + ", ");
                sb.Append(PlacePayoff + ", ");
                sb.Append(ShowPayoff);

                return sb.ToString();
            }
        }

        public string TrackCode
        {
            get
            {
                return _pt.Tokens[TRACK_CODE].ToString();
            }
        }

        public string RacingDate
        {
            get
            {
                return _pt.Tokens[RACING_DATE].ToString();
            }
        }

        public int RaceNumber
        {
            get
            {
                return _pt.Tokens[RACE_NUMBER].GetAsInteger();
            }
        }

        public string HorseName
        {
            get
            {
                return _pt.Tokens[HORSE_NAME].ToString();
            }
        }

        public string ProgramNumber
        {
            get
            {
                return _pt.Tokens[PROGRAM_NUMBER].ToString();
            }
        }

        public double WinPayoff
        {
            get
            {
                return _pt.Tokens[WIN_PAYOFF].GetAsDouble();
            }
        }

        public double PlacePayoff
        {
            get
            {
                return _pt.Tokens[PLACE_PAYOFF].GetAsDouble();
            }
        }

        public double ShowPayoff
        {
            get
            {
                return _pt.Tokens[SHOW_PAYOFF].GetAsDouble();
            }
        }
        
    }
}
