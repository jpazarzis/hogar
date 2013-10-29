using System.Data.SqlClient;


namespace Hogar.ExFigure
{
    public class ParSpeed
    {
        readonly string _raceClassification;
        readonly double _avgSpeed;
        readonly int _sampleSize;
        readonly Utilities.Surface _surface;
        readonly string _trackCode;

        static internal ParSpeed Make(Race race)
        {
            
            string raceClassification = race.Classification.ToString();
            string trackCode = race.Parent.TrackCode;
            Utilities.Surface surface = race.SurfaceWhereTheRaceWasRun;

            if (surface == Utilities.Surface.Invalid)
            {
                return null;
            }

            string s = "";
            if (surface == Utilities.Surface.Turf)
            {
                s = "T";
            }
            else
            {
                s = "D";
            }

            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("SELECT TRACK_CODE, CLASSIFICATION, SURFACE, AVERAGE_SPEED, SAMPLE_SIZE FROM AVERAGE_SPEED WHERE TRACK_CODE = '{0}' AND SURFACE='{1}' AND CLASSIFICATION='{2}'", trackCode, s, raceClassification);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int sampleSize = (int)myReader["SAMPLE_SIZE"];
                        double speed = (double)myReader["AVERAGE_SPEED"];
                        return new ParSpeed(raceClassification, speed, sampleSize, trackCode, surface);
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }
    
        internal ParSpeed(  string raceClassification, 
                            double avgSpeed, 
                            int sampleSize,
                            string trackCode,
                            Utilities.Surface surface)
        {
            _raceClassification = raceClassification;
            _avgSpeed = avgSpeed;
            _sampleSize = sampleSize;
            _surface = surface;
            _trackCode = trackCode;
        }


        
        internal void SaveToDb()
        {
            string s = "";
            if (_surface == Utilities.Surface.Turf)
            {
                s = "T";
            }
            else
            {
                s = "D";
            }
            string sql = string.Format(@"INSERT INTO AVERAGE_SPEED
                                        (TRACK_CODE,CLASSIFICATION,AVERAGE_SPEED,SAMPLE_SIZE,SURFACE)
                                        VALUES ('{0}', '{1}', {2}, {3},'{4}' ) ", 
                                        _trackCode,
                                        _raceClassification,
                                        _avgSpeed,
                                        _sampleSize,
                                        s);

            
            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }

        internal static void DeleteFromDb(string trackCode, Utilities.Surface surface)
        {
            string s = "";
            if (surface == Utilities.Surface.Turf)
            {
                s = "T";
            }
            else
            {
                s = "D";
            }
            string sql = string.Format("DELETE AVERAGE_SPEED WHERE TRACK_CODE = '{0}' AND SURFACE = '{1}'", trackCode, s);
            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3:0.00} {4}", TrackCode, Surface, RaceClassification, AvgSpeed, SampleSize);
        }

        public Utilities.Surface Surface
        {
            get
            {
                return _surface;
            }
        }

        public string RaceClassification
        {
            get
            {
                return _raceClassification;
            }
        }

        public double AvgSpeed
        {
            get
            {
                return _avgSpeed;
            }
        }

        public int SampleSize
        {
            get
            {
                return _sampleSize;
            }
        }

        public string TrackCode
        {
            get
            {
                return _trackCode;
            }
        }
    }
}
