using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;


namespace Hogar.ExFigure
{
    internal class SpeedNormalizer
    {
        static Dictionary<string, SpeedNormalizer> _speedNormalizer = new Dictionary<string, SpeedNormalizer>();

        internal static SpeedNormalizer GetObject(string trackCode, Utilities.Surface surface)
        {
            string key = MakeKey(trackCode, surface);

            if (_speedNormalizer.ContainsKey(key))
            {
                return _speedNormalizer[key];
            }
            else
            {
                return AddSpeedNormalizer(trackCode, surface);
            }
        }

        
        static private string MakeKey(string trackCode, Utilities.Surface surface)
        {
            switch (surface)
            {
                case Utilities.Surface.Dirt:
                    return trackCode + "DIRT";
                case Utilities.Surface.Turf:
                    return trackCode + "TURF";
                default:
                    throw new Exception("Unsupported surface");
            }
        }

        private static SpeedNormalizer AddSpeedNormalizer(string trackCode, Utilities.Surface surface)
        {
            SpeedNormalizer sn = new SpeedNormalizer(trackCode, surface);
            _speedNormalizer.Add(MakeKey(trackCode, surface), sn);
            return sn;
        }

        readonly string _trackCode;
        readonly Utilities.Surface _surface;
        double _decelarationFactor = 0.0;
        bool _needsToCalculateDecelarationFactor = true;

        double[] _normalSpeed = new double[2];
        double[] _normalDistance = new double[2];


        
        private SpeedNormalizer(string trackCode, Utilities.Surface surface)
        {
            _trackCode = trackCode;
            _surface = surface;
        }

        internal double NormalizeSpeed(double time, double distance)
        {
            if (_needsToCalculateDecelarationFactor)
            {
                CalculateDecelarationFactor();
            }

            if (time <= 0.0 || distance <= 0.0 || _decelarationFactor <= 0.0)
            {
                return 0.0;
            }

            double speed = distance / time;

            if (distance == _normalDistance[0])
            {
                return speed;
            }
            else if (distance > _normalDistance[0])
            {
                double dx = distance - _normalDistance[0];
                return speed + dx * _decelarationFactor;
            }
            else
            {
                double dx = distance - _normalDistance[0];
                return speed - dx * _decelarationFactor;
            }
        }

        private double DecelarationFactor
        {
            get
            {
                if (_needsToCalculateDecelarationFactor)
                {
                    CalculateDecelarationFactor();
                }
                return _decelarationFactor;
            }
        }

        private void CalculateDecelarationFactor()
        {
            _decelarationFactor = 0.0;

            string sql = @"SELECT 
	                            distance /avg(FINAL_TIME) 'SPEED', 
                                distance 'DISTANCE' , 
                                count(*) 'COUNTER'
                           FROM RACE_DESCRIPTION 
                           WHERE 
	                            track_code = '{0}'  and final_time > 0";
 
                                

            if (_surface == Utilities.Surface.Dirt)
            {
                sql += " and Surface != 'T' ";
            }
            else if (_surface == Utilities.Surface.Turf)
            {
                sql += " and Surface = 'T' ";
            }

            sql += " group by distance order by 3 desc";

            SqlDataReader myReader = null;
            try
            {
                SqlCommand myCommand = new SqlCommand(string.Format(sql, _trackCode), Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                int row = 0;

                if (myReader.HasRows)
                {
                    while (myReader.Read() && row < 2)
                    {
                        _normalSpeed[row] = (double)myReader["SPEED"];
                        _normalDistance[row] = (double)myReader["DISTANCE"];
                        ++row;
                    }
                }
                myReader.Close();
                if (row == 2)
                {
                    double dv = Math.Abs(_normalSpeed[1] - _normalSpeed[0]);
                    double dx = Math.Abs(_normalDistance[1] - _normalDistance[0]);
                    if (dx > 0)
                    {
                        _decelarationFactor = dv / dx;
                    }
                }

            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
                _needsToCalculateDecelarationFactor = false;
            }
        }
    }
}
