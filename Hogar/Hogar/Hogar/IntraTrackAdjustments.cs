using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hogar
{
    public class IntraTrackAdjustments
    {
        enum DistanceType
        {
            Sprint, Route
        }

        readonly string _trackCode1;
        readonly string _trackCode2;
        readonly string _surface;
        readonly string _distanceType; // S: SPRINT R: Route
        readonly double _timeDiff;

        public IntraTrackAdjustments(string trackCode1, string trackCode2, string surface, string distanceType, double timeDiff)
        {
            _trackCode1 = trackCode1;
            _trackCode2 = trackCode2;
            _surface = surface;
            _distanceType = distanceType;
            _timeDiff = timeDiff;
        }

        public void InsertToDb()
        {
            string sql = string.Format("INSERT INTO INTRA_TRACK_ADJ (TRACK_CODE_1,TRACK_CODE_2, SURFACE, DISTANCE_TYPE, TIME_DIFF) VALUES ('{0}','{1}','{2}','{3}',{4})", _trackCode1, _trackCode2, _surface, _distanceType, _timeDiff);
            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }

    }
}
