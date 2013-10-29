using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using Hogar.DbTools;
using System.Data;

namespace Hogar
{
    public static class RaceTracks
    {

        static public bool IsValidTrackFlag(long flag)
        {
            foreach (RaceTrackInfo rti in RaceTrackInfoCollection)
            {
                if (flag== rti.TrackFlag)
                {
                    return true;
                }
            }
            return false;
        }

        static public int GetTotalNumberOfRacesInDb(string trackCode)
        {
            string sql = string.Format("Select count(DISTINCT(RACE_ID)) from race_starters where track_code = '{0}' and finish_position=1 ", trackCode);
            var dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return (int)ds.Tables[0].Rows[0][0];
            }
        }



        static public RaceTrackInfo GetRaceTrackInfo(string trackCode)
        {
            trackCode = trackCode.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (trackCode.Equals(rti.TrackCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti;
                }
            }

            return null;
        }

        static public List<RaceTrackInfo> RaceTrackInfoCollection
        {
            get
            {
                return _raceTrackInfo;
            }
        }

        static public List<RaceTrackInfo> MatchingTracks(long flag)
        {
            List<RaceTrackInfo> rtilist = new List<RaceTrackInfo>();
            foreach (RaceTrackInfo rti in RaceTrackInfoCollection)
            {
                if ( (rti.TrackFlag & flag) == rti.TrackFlag)
                {
                    rtilist.Add(rti);
                }
            }
            return rtilist;
        }

        static public string GetTrackCodeFromName(string trackName)
        {
            trackName = trackName.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (trackName.Equals(rti.TrackName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti.TrackCode;
                }
            }

            return "XXX";
        }

        static public string GetTrackCodeFromBrisAbrv(string  brisAbrv)
        {
            brisAbrv = brisAbrv.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (brisAbrv.Equals(rti.BrisAbrv, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti.TrackCode;
                }
            }

            return "XXX";
        }

        static public string GetNameFromTrackCode(string abrv)
        {
            abrv = abrv.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (abrv.Equals(rti.TrackCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti.TrackName;
                }
            }

            return "XXX";
        }

        static public string GetNameFromBrisAbrv(string abrv)
        {
            abrv = abrv.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (abrv.Equals(rti.BrisAbrv, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti.TrackName;
                }
            }

            return "XXX";
        }

        static public string GetBrisAbrvFromTrackCode(string trackCode)
        {
            trackCode = trackCode.Trim();
            foreach (RaceTrackInfo rti in _raceTrackInfo)
            {
                if (trackCode.Equals(rti.TrackCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    return rti.BrisAbrv;
                }
            }

            return "XXX";
        }

        public static RaceTrackInfo CreateNew(string trackName, string brisAbrv, string trackCode)
        {
            RaceTrackInfo rti = RaceTrackInfo.CreateNew(trackName, brisAbrv, trackCode);
            _raceTrackInfo.Add(rti);
            return rti;
        }

        static RaceTracks()
        {
            _raceTrackInfo.Clear();
            SqlDataReader myReader = null;
            try
            {
                const string sql = @"SELECT   [TRACK_CODE],
                                        [BRIS_ABBRV],
                                        [TRACK_NAME],
                                        [TRACK_FLAG],
                                        [SIBLINGS_FLAG],
                                        [USE_ALL_RACE_ATTRIBUTES_FOR_HANDICAPPING],
                                        [UPDATED_DAILY]
                                FROM 
                                        [RACE_TRACK_INFO]";    
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string trackCode = myReader["TRACK_CODE"].ToString().Trim();
                        string brisAbrv = myReader["BRIS_ABBRV"].ToString().Trim();
                        string trackName = myReader["TRACK_NAME"].ToString().Trim();
                        long trackFlag = (long)myReader["TRACK_FLAG"];
                        long siblingsFlag = (long)myReader["SIBLINGS_FLAG"];
                        int useAllAttributes = (int)myReader["USE_ALL_RACE_ATTRIBUTES_FOR_HANDICAPPING"];
                        int updatedDaily = (int)myReader["UPDATED_DAILY"];
                        _raceTrackInfo.Add(RaceTrackInfo.Make(trackCode, brisAbrv, trackName, trackFlag, siblingsFlag, useAllAttributes, updatedDaily));
                    }
                }
                myReader.Close();
         
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }            
        }

        static List<RaceTrackInfo> _raceTrackInfo = new List<RaceTrackInfo>();
    }
}
