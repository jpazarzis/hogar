using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;
using Hogar.DbTools;
using Hogar.Handicapping.Analysis;

namespace Hogar
{
    public class RaceTrackInfo
    {
        string _trackCode;
        string _brisAbrv;
        string _trackName;
        
        readonly long _trackFlag;
        long _siblingsFlag;
        bool _useAllAttributes;
        bool _updatedDaily;


        static Dictionary<string, string> _lastDayInDataBase = null;


        static void LoadLastUpdatedDay()
        {
            _lastDayInDataBase = new Dictionary<string, string>();
            _lastDayInDataBase.Clear();

            using (var dbr = new DbReader())
            {
                if (dbr.Open(@"SELECT TRACK_CODE, MAX(DATE_OF_THE_RACE) 'MAX_DATE' FROM RACE_DESCRIPTION GROUP BY TRACK_CODE "))
                {
                    while (dbr.MoveToNextRow())
                    {
                        string trackCode = dbr.GetValue<string>("TRACK_CODE");
                        string maxDate = dbr.GetValue<string>("MAX_DATE");
                        _lastDayInDataBase.Add(trackCode.Trim().ToUpper(), maxDate);
                    }
                }
            }
        }



        public string LastUpdatedDate
        {
            get
            {
                if (null == _lastDayInDataBase)
                {
                    LoadLastUpdatedDay();
                }
                return _lastDayInDataBase.ContainsKey(_trackCode.ToUpper().Trim()) ? _lastDayInDataBase[_trackCode] : "";
            }
        }


        public override string ToString()
        {
            return _trackName;
        }

        public string TrackCode 
        { 
            get 
            { 
                return _trackCode; 
            }
            set
            {
                _trackCode = value;
            }
        }
        
        public string BrisAbrv
        {
            get
            {
                return _brisAbrv;
            }
        }

        public string TrackName
        {
            get
            {
                return _trackName;
            }
        }


        public void SetValues(string trackName, string brisAbrv, string trackCode, bool updatedDaily)
        {
            trackCode = trackCode.Trim();
            trackName = trackName.Trim();
            brisAbrv = brisAbrv.Trim();

            int updatedDailyFlag = (updatedDaily ? 1 : 0);

            if(trackCode.Length<=0 || trackName.Length <=0 || brisAbrv.Length <=0)
            {
                throw new Exception("Invalid parameter, try again");
            }


            var sql = string.Format(@"UPDATE 
                                                RACE_TRACK_INFO
                                            SET 
                                                TRACK_CODE =  '{0}' ,
                                                BRIS_ABBRV =  '{1}' ,
                                                TRACK_NAME =  '{2}',
                                                UPDATED_DAILY = {3} 
                                            WHERE 
                                                TRACK_FLAG = {4}",
                                            trackCode, brisAbrv, trackName, updatedDailyFlag, _trackFlag);

            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();

            _trackName = trackName.Trim();
            _brisAbrv = brisAbrv.Trim();
            _trackCode = trackCode.Trim();
            _updatedDaily = updatedDaily;

            
        }


        public bool UpdatedDaily
        {
            get
            {
                return _updatedDaily;
            }
            set
            {
                if (_updatedDaily != value)
                {
                    SetValues(_trackName, _brisAbrv, _trackCode, value);
                }
            }
        }

        public long TrackFlag
        {
            get
            {
                return _trackFlag;
            }
        }

        public bool IsSibling(RaceTrackInfo other)
        {
            return (_siblingsFlag & other.TrackFlag) == other.TrackFlag;
        }

        public void AddSiblingTrack(RaceTrackInfo other)
        {
            if ((other.TrackFlag & _siblingsFlag) != other.TrackFlag)
            {
                _siblingsFlag = _siblingsFlag | other.TrackFlag;
                UpdateSiblingsToDb();
                FactorPerformance.Reset();
            }
        }

        public void RemoveSiblingTrack(RaceTrackInfo other)
        {
            if ((other.TrackFlag & _siblingsFlag) == other.TrackFlag)
            {
                _siblingsFlag = _siblingsFlag & ~other.TrackFlag;
                UpdateSiblingsToDb();
                FactorPerformance.Reset();
            }
        }

        public bool UseAllAttributesForHandicapping
        {
            get
            {
                return _useAllAttributes;
            }
            set
            {
                _useAllAttributes = value;
                UpdateSiblingsToDb();
                FactorPerformance.Reset();
            }
        }

        private void UpdateSiblingsToDb()
        {
            int useAllAtributes = (_useAllAttributes ? 1 : 0);
            string sql = string.Format(@"UPDATE RACE_TRACK_INFO SET SIBLINGS_FLAG = {0}, USE_ALL_RACE_ATTRIBUTES_FOR_HANDICAPPING = {1} WHERE TRACK_CODE = '{2}'", _siblingsFlag, useAllAtributes, _trackCode);
            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }



        internal static RaceTrackInfo CreateNew(string trackName, string brisAbrv, string trackCode)
        {
            if(TrackAlreadyExists(trackName, brisAbrv, trackCode))
            {
                throw new Exception("Sorry, track already exists!");
            }

            long trackFlag = GetNextTrackFlag();

            string sql = string.Format(
                                        @"INSERT INTO RACE_TRACK_INFO
                                               (TRACK_CODE
                                               ,BRIS_ABBRV
                                               ,TRACK_NAME
                                               ,TRACK_FLAG
                                               ,SIBLINGS_FLAG
                                               ,USE_ALL_RACE_ATTRIBUTES_FOR_HANDICAPPING)
                                         VALUES ('{0}','{1}','{2}', {3}, {4}, {5})",
                                        trackCode, brisAbrv, trackName, trackFlag, 0, 0);

            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();


            return new RaceTrackInfo(trackCode, brisAbrv, trackName, trackFlag, 0, 0,0);

            
        }

        private static long GetNextTrackFlag()
        {
            long tf = 1;
            SqlDataReader myReader = null;
            try
            {
                string sql = "SELECT MAX(TRACK_FLAG) FROM RACE_TRACK_INFO";
                    
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        long i = myReader.GetInt64(0);
                        if(i > (long) 1)
                        {
                            tf = i * ((long)2);
                        }
                    }
                }
                myReader.Close();

                return tf;

            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }

        private static bool TrackAlreadyExists(string trackName, string brisAbrv, string trackCode)
        {
            
            SqlDataReader myReader = null;
            try
            {
                string sql =
                    string.Format(
                        "SELECT COUNT(*) FROM RACE_TRACK_INFO WHERE TRACK_CODE = '{0}' OR BRIS_ABBRV = '{1}' OR TRACK_NAME = '{2}'",
                        trackCode, brisAbrv, trackName);

                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                int count = 0;

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        count = myReader.GetInt32(0);
                        
                    }
                }
                myReader.Close();

                return count != 0;

            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }


        internal static RaceTrackInfo Make(string trackCode, string brisAbrv, string trackName, long trackFlag, long siblingsFlag, int useAllAttributes, int updatedDaily)
        {
            return new RaceTrackInfo(trackCode, brisAbrv, trackName, trackFlag, siblingsFlag, useAllAttributes, updatedDaily);
        }


        public List<string > ListOfAvailableAboutFlagPerDistanceAndSurface(string surface, double distance)
        {
            var aboutFlags = new List<string>();

            using (var dbr = new DbReader())
            {
                string sqlLoader = string.Format(@"select distinct(ABOUT_DISTANCE_FLAG) AS 'AFLAG' from RACE_DESCRIPTION where TRACK_CODE = '{0}' AND DISTANCE = {1} AND SURFACE = '{2}' COLLATE SQL_Latin1_General_CP1_CS_AS", this.TrackCode, distance, surface);

                if (dbr.Open(sqlLoader))
                {
                    while (dbr.MoveToNextRow())
                    {
                        aboutFlags.Add(dbr.GetValue<string>("AFLAG"));
                    }
                }
            }
            return aboutFlags;
        }

        public List<double> ListOfAvailableDistancesPerSurface(string surface)
        {
            var distances = new List<double>();

            using (var dbr = new DbReader())
            {
                string sqlLoader = string.Format(@"select distinct(DISTANCE) AS 'DIST' from RACE_DESCRIPTION where TRACK_CODE = '{0}' AND SURFACE = '{1}' COLLATE SQL_Latin1_General_CP1_CS_AS", this.TrackCode, surface);

                if (dbr.Open(sqlLoader))
                {
                    while (dbr.MoveToNextRow())
                    {
                        distances.Add(dbr.GetValue<double>("DIST"));
                    }
                }
            }
            return distances;
        }

        public List<string> ListOfAvailableSurfaces
        {
            get
            { 
                
                var surfaces = new List<string>();

                using (var dbr = new DbReader())
                {
                    string sqlLoader = string.Format(@"select distinct(surface)  COLLATE SQL_Latin1_General_CP1_CS_AS  AS 'SURF' from race_description where track_code = '{0}'", this.TrackCode);

                    if (dbr.Open(sqlLoader))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            string s = dbr.GetValue<string>("SURF");
                            s = s.Trim();
                            if(s.Length > 0)
                            {
                                surfaces.Add(s);
                            }
                        }
                    }
                }
                return surfaces;
            }
        }


        private RaceTrackInfo(string trackCode, string brisAbrv, string trackName, long trackFlag, long siblingsFlag, int useAllAttributes, int updatedDaily)
        {
            _trackCode = trackCode;
            _brisAbrv = brisAbrv;
            _trackName = trackName;
            _trackFlag = trackFlag;
            _siblingsFlag = siblingsFlag;
            _useAllAttributes = (useAllAttributes != 0);
            _updatedDaily = (updatedDaily == 1);
        }



    }
}
