using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;
using System.Diagnostics;

namespace Hogar.RaceResults
{
    class RaceFootNotes
    {
        static int TRACK_CODE = 0;
		static int RACING_DATE= 1;
		static int RACE_NUMBER = 2;
		static int FOOT_NOTE_SEQUENCE_NUMBER = 4;
		static int FOOT_NOTE_TEXT = 5;



        readonly ParsableText _pt;

        public RaceFootNotes(ParsableText pt)
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
                sb.Append("EXEC AddNewFootNote ");
                sb.Append("'" + TrackCode + "', ");
                sb.Append("'" + RacingDate + "', ");
                sb.Append(RaceNumber + ", ");
                sb.Append(FootNoteSequenceNumber + ", ");
                sb.Append("'" + FootNoteText + "' ");
                
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

        public int FootNoteSequenceNumber
        {
            get
            {
                return _pt.Tokens[FOOT_NOTE_SEQUENCE_NUMBER].GetAsInteger();
            }
        }

        public string FootNoteText
        {
            get
            {
                string s = _pt.Tokens[FOOT_NOTE_TEXT].ToString();
                s = s.Replace("'", "`");
                return s;
            }
        }
    }
}
