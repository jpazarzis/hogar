using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;


namespace Hogar.RaceResults
{
    class RaceExoticBetPayoff
    {
        static int TRACK_CODE = 0;
        static int RACING_DATE = 1;
        static int RACE_NUMBER = 2;
        static int WAGER_TYPE = 4;
        static int BET_AMOUNT = 5;
        static int PAYOFF_AMOUNT = 6;
        static int NUMBER_CORRECT = 7;
        static int WINNING_NUMBERS = 8;
        static int WAGER_POOL = 9;
        static int CARRY_OVER_AMOUNT = 10;

        readonly ParsableText _pt;

        public RaceExoticBetPayoff(ParsableText pt)
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
                sb.Append("EXEC AddNewExoticPayoff ");
                sb.Append("'" + TrackCode + "', ");
                sb.Append("'" + RacingDate + "', ");
                sb.Append(RaceNumber + ", ");
                sb.Append("'" + WagerType + "', ");
                sb.Append(BetAmount + ", ");
                sb.Append(PayoffAmount + ", ");
                sb.Append(NumberCorrect + ", ");
                sb.Append("'" + WinningNumbers + "', ");
                sb.Append(WagerPool + ", ");
                sb.Append(CarryOverAmount);
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

        public string WagerType
        {
            get
            {
                return _pt.Tokens[WAGER_TYPE].ToString();
            }
        }

        public double BetAmount
        {
            get
            {
                return _pt.Tokens[BET_AMOUNT].GetAsDouble();
            }
        }

        public double PayoffAmount
        {
            get
            {
                return _pt.Tokens[PAYOFF_AMOUNT].GetAsDouble();
            }
        }

        public int NumberCorrect
        {
            get
            {
                return _pt.Tokens[NUMBER_CORRECT].GetAsInteger();
            }
        }

        public string WinningNumbers
        {
            get
            {
                return _pt.Tokens[WINNING_NUMBERS].ToString();
            }
        }

        public double WagerPool
        {
            get
            {
                return _pt.Tokens[WAGER_POOL].GetAsDouble();
            }
        }

        public double CarryOverAmount
        {
            get
            {
                return _pt.Tokens[CARRY_OVER_AMOUNT].GetAsDouble();
            }
        }
               
    }
}
