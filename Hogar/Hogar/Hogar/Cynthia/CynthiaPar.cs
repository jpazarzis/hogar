using System;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Hogar.Cynthia
{
    public class CynthiaPar
    {
        readonly double _firstCall;
        readonly double _midCall;
        readonly double _finalCall;
        readonly string _trackCode;
        readonly char _surface;
        readonly double _distance;
        readonly string _classification;
        readonly char _aboutFlag;
        int _averageVariant = -9999;
        readonly bool _isValid = false;

        enum RaceTypeEnum
        {
            MaidenClaiming,
            MaidenSpecialWeights,
            Claiming,
            OptionalClaiming,
            Allowance,
            NonGradedStakes,
            GradedStakes,
            StarterAllowance,
            StarterHandicap,
            Unspecified
        }



        static public string MakeCynthiaClassification(string raceType, string raceRestrictions,double maxClaimingPrice)
        {
            switch (GetRaceType(raceType))
            {
                case RaceTypeEnum.MaidenClaiming:
                    return string.Format("MC{0:0,000}", maxClaimingPrice);
                case RaceTypeEnum.MaidenSpecialWeights:
                    return "MSW";
                case RaceTypeEnum.Claiming:
                    return string.Format("C{0:0,000}", maxClaimingPrice);
                case RaceTypeEnum.OptionalClaiming:
                    return string.Format("C{0:0,000}", maxClaimingPrice);
                case RaceTypeEnum.Allowance:

                    string rc = raceRestrictions;

                    if (rc.Contains("NW1"))
                    {
                        return "NW1";
                    }
                    else if (rc.Contains("NW2"))
                    {
                        return "NW2";
                    }
                    else if (rc.Contains("NW3"))
                    {
                        return "NW3";
                    }
                    else if (rc.Contains("NW4"))
                    {
                        return "NW4";
                    }
                    else if (rc.Contains("N$Y"))
                    {
                        return "CLF";
                    }
                    else
                    {
                        if (maxClaimingPrice > 0)
                        {
                            return string.Format("C{0:0,000}", maxClaimingPrice);
                        }
                        else
                        {
                            return "N/A";
                        }
                    }
                case RaceTypeEnum.NonGradedStakes:
                    return "STAKES NG";
                case RaceTypeEnum.GradedStakes:
                    return "STAKES GR";
                case RaceTypeEnum.StarterAllowance:
                case RaceTypeEnum.StarterHandicap:
                    if (maxClaimingPrice > 0.0)
                    {
                        return string.Format("STR{0:0,000}", maxClaimingPrice);
                    }
                    else
                    {
                        string s = StarterHandicapClassification(raceRestrictions);
                        if (s.Length > 0)
                        {
                            return s;
                        }
                        else
                        {
                            return "STR";
                        }
                    }
                default:
                    return "";
            }
        }


        private static string StarterHandicapClassification(string r)
        {
            //example:  r could be "HCP16000S"

            r = r.Trim().ToUpper();

            if (r.StartsWith("FHCP"))
            {
                r = r.Substring(1);
            }

            if (r.Length < 4)
            {
                return "";
            }

            if (r.Substring(0, 3) != "HCP")
            {
                return "";
            }

            r = r.Substring(3);

            if (r.EndsWith("S") == false)
            {
                return "";
            }

            r = r.Replace("S", " ");
            r = r.Trim();

            try
            {
                int valueOfTheRace = Convert.ToInt32(r);
                return string.Format("STR{0:0,000}", valueOfTheRace);
            }
            catch
            {
                return "";
            }
        }


        private static RaceTypeEnum GetRaceType(string raceType)
        {
            //string raceType = _brisRaceType;

            if (raceType.Length > 0)
            {
                raceType += " ";

                if (raceType[0] == 'S')
                {
                    return RaceTypeEnum.MaidenSpecialWeights;
                }
                else if (raceType[0] == 'M')
                {
                    return RaceTypeEnum.MaidenClaiming;
                }
                else if (raceType[0] == 'R' )
                {
                    return RaceTypeEnum.StarterAllowance;
                }
                else if (raceType[0] == 'T')
                {
                    return RaceTypeEnum.StarterHandicap;
                }
                else if (raceType[0] == 'C' && raceType[1] == 'O')
                {
                    return RaceTypeEnum.OptionalClaiming;
                }
                else if (raceType[0] == 'A' && raceType[1] == 'O')
                {
                    return RaceTypeEnum.OptionalClaiming;
                }
                else if (raceType[0] == 'N')
                {
                    return RaceTypeEnum.NonGradedStakes;
                }
                else if (raceType[0] == 'G')
                {
                    return RaceTypeEnum.GradedStakes;
                }
                else if (raceType[0] == 'A')
                {
                    return RaceTypeEnum.Allowance;
                }
                else if (raceType[0] == 'C')
                {
                    return RaceTypeEnum.Claiming;
                }
            }
            return RaceTypeEnum.Unspecified;

        }

#region RaceDescriptiveData

        private class RaceDescriptiveData
        {
            readonly string _trackCode = "";
            readonly string _dateOfTheRace = "";
            readonly double _distance = 0.0;
            readonly string _surface = "";
            readonly string _brisRaceType = "";
            readonly string _raceRestrictions = "";
            readonly double _maxClaimingPrice = 0.0;
            readonly double _purse = 0.0;
            readonly bool _isValid = false;
            readonly string _cynthiaClassification = "";

          
            public RaceDescriptiveData(string trackCode, int year, int month, int day, int raceNumber)
            {
                _trackCode = trackCode;
                _dateOfTheRace = string.Format("{0:0000}{1:00}{2:00}", year, month, day);
                string sql = string.Format("Select RACE_NUMBER, DISTANCE,SURFACE, BRIS_RACE_TYPE, RACE_RESTRICTIONS, MAX_CLAIMING_PRICE, PURSE From race_description where track_Code = '{0}' and DATE_OF_THE_RACE = '{1}' and RACE_NUMBER = {2}", _trackCode, _dateOfTheRace, raceNumber);

                SqlDataReader myReader = null;
                try
                {
                    SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            _distance = (double)myReader["DISTANCE"];
                            _surface = myReader["SURFACE"].ToString();
                            _brisRaceType = myReader["BRIS_RACE_TYPE"].ToString();
                            _raceRestrictions = myReader["RACE_RESTRICTIONS"].ToString();
                            _maxClaimingPrice = (double)myReader["MAX_CLAIMING_PRICE"];
                            _purse = (double)myReader["PURSE"];
                        }
                    }
                    myReader.Close();

                    _cynthiaClassification = MakeCynthiaClassification(_brisRaceType, _raceRestrictions, _maxClaimingPrice);
                    _isValid = true;
                }
                finally
                {
                    if (null != myReader && myReader.IsClosed == false)
                    {
                        myReader.Close();
                    }
                }
            }


            public double Distance
            {
                get
                {
                    return _distance;
                }
            }

            public char Surface
            {
                get
                {
                    if (_surface[0] == 'T')
                    {
                        return 'T';
                    }
                    if (_surface[0] == 't')
                    {
                        return 'I';
                    }
                    else if (_surface[0] == 'd')
                    {
                        return 'N';
                    }
                    else
                    {
                        return 'D';
                    }

                }
            }

            public string CynthiaClassification
            {
                get
                {
                    return _isValid ? _cynthiaClassification : "N/A";
                }
            }
        }
#endregion
        // returns the CynthiaPar for the specific race
        public static CynthiaPar Make(string trackCode, int year, int month, int day, int raceNumber)
        {
            var rdd = new RaceDescriptiveData(trackCode, year, month, day, raceNumber);
            return Make(trackCode, rdd.Surface, rdd.Distance, rdd.CynthiaClassification, 'N');
        }


        public static List<CynthiaPar> LoadParsForRaceTrack(string trackCode)
        {
            var cp = new List<CynthiaPar>();
            string sql = string.Format("SELECT SURFACE, DISTANCE, ABOUT_FLAG, CLASS, FIRST_CALL, MID_CALL, FINAL_CALL FROM  cynthia_pars WHERE track_code = '{0}' ", trackCode);
            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string surface = myReader.GetString(0);
                double distance = myReader.GetDouble(1);
                string aboutFlag = myReader.GetString(2);
                string classification = myReader.GetString(3);
                double firstCall = myReader.GetDouble(4);
                double midCall = myReader.GetDouble(5);
                double finalCall = myReader.GetDouble(6);
                cp.Add(new CynthiaPar(trackCode, surface[0], distance, classification, aboutFlag[0], firstCall, midCall, finalCall, true));
            }
            myReader.Close();
            return cp;
        }

        public static CynthiaPar Make(string trackCode, char surface, double distance, string classification, char aboutFlag)
        {
            string sql = string.Format("EXEC SelectCynthiaParsPerClass '{0}','{1}',{2},'{3}','{4}' ",trackCode, surface, distance, aboutFlag, classification);
            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            double firstCall = 0.0;
            double midCall = 0.0;
            double finalCall = 0.0;

            bool isValid = false;

            while (myReader.Read())
            {
                firstCall = (double)myReader["FIRST_CALL"];
                midCall = (double)myReader["MID_CALL"];
                finalCall = (double)myReader["FINAL_CALL"];
                isValid = true;
            }
            myReader.Close();

            return new CynthiaPar(trackCode, surface, distance, classification, aboutFlag, firstCall, midCall, finalCall, isValid);

        }

        private CynthiaPar(string trackCode, char surface, double distance, string classification, char aboutFlag, double firstCall, double midCall, double finalCall, bool isValid)
        {
            _trackCode = trackCode; 
            _surface = surface;
            _distance = distance;
            _classification = classification;
            _aboutFlag = aboutFlag;
            _firstCall = firstCall;
            _midCall = midCall;
            _finalCall = finalCall;
            _isValid = isValid;
        }

        public override string ToString()
        {
            return string.Format("Track Code: {0} Surface: {1} Class: {2} Dist: {3} AboutFlag: {4}  ", _trackCode, _surface, _classification, _distance, _aboutFlag);
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        public double FirstCall
        {
            get
            {
                return _firstCall;
            }
        }

        public double MidCall
        {
            get
            {
                return _midCall;
            }
        }

        public double FinalCall
        {
            get
            {
                return _finalCall;
            }
        }

        public string TrackCode
        {
            get
            {
                return _trackCode.ToUpper();
            }
        }

        public int DistanceInYards
        {
            get
            {
                return (int)_distance;
            }
        }

        public double DistanceInFurlongs
        {
            get
            {
                return _distance / Utilities.YARDS_IN_A_FURLONG;
            }
        }

        public string Distance
        {
            get
            {
                return Utilities.ConvertYardsToMilesOrFurlongs((int)_distance);
            }
        }

        public string Surface
        {
            get
            {
                return _surface.ToString();
            }
        }

        public string AboutFlag
        {
            get
            {
                return _aboutFlag.ToString();
            }
        }



        public string CynthiaClassification
        {
            get
            {
                return _classification;
            }
        }

        public int AverageVariant
        {
            get
            {
                if (-9999 == _averageVariant)
                {
                }
                return _averageVariant;
            }
        }

        public bool IsRoute
        {
            get
            {
                return _distance >= 8 * Utilities.YARDS_IN_A_FURLONG;
            }
        }

    }
}
