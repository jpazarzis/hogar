using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar;
using System.IO;
using System.Diagnostics;

namespace Hogar.ExFigure
{
    public class RaceClassification
    {
        readonly string _trackCode;
        readonly double _distance;
        readonly string _raceType;
        readonly int _grade;
        readonly string _restrictions;
        readonly string _stateBredFlag;
        readonly string _abbrRaceClass;
        readonly double _valueOfRace;
        readonly double _maxClaimingPrice;
        readonly string _ageSexRestrictions;
        
        readonly bool _isValid;

       
        static internal RaceClassification Make(Race race)
        {
            return new RaceClassification(race);
        }

        private RaceClassification(Race race)
        {
            string sql = @"SELECT   TRACK_CODE,
                                    DISTANCE,
                                    EQB_RACE_TYPE, 
                                    RACE_GRADE, 
                                    RACE_RESTRICTIONS, 
                                    STATE_BRED_FLAG,
                                    ABBR_RACE_CLASS, 
                                    TOTAL_VALUE_OF_RACE,
                                    AGE_SEX_RESTRICTIONS, 
                                    MAX_CLAIMING_PRICE
                                    FROM RACE_DESCRIPTION WHERE race_id = {0}";

            SqlDataReader myReader = null;
            try
            {
                SqlCommand myCommand = new SqlCommand(string.Format(sql, race.RaceID), Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                _isValid = false;
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _trackCode = myReader["TRACK_CODE"].ToString().ToUpper();
                        _distance = (double)myReader["DISTANCE"];
                        _raceType = myReader["EQB_RACE_TYPE"].ToString().ToUpper();
                        _grade = (int)myReader["RACE_GRADE"];
                        _restrictions = myReader["RACE_RESTRICTIONS"].ToString().ToUpper();
                        _stateBredFlag = myReader["STATE_BRED_FLAG"].ToString().ToUpper();
                        _abbrRaceClass = myReader["ABBR_RACE_CLASS"].ToString().ToUpper();
                        _valueOfRace = (double)myReader["TOTAL_VALUE_OF_RACE"];
                        _maxClaimingPrice = (double)myReader["MAX_CLAIMING_PRICE"];
                        _ageSexRestrictions = myReader["AGE_SEX_RESTRICTIONS"].ToString().ToUpper();
                        _isValid = true;
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

        public bool IsValid
        {
            get 
            {
                return _isValid;
            }
        }

        public override string ToString()
        {
            string key = "";

            if (StateBredOnly)
            {
                key += "S";
            }

            if (FilliesAndMaresOnly)
            {
                key += "F";
            }

            if (TwoYearOnly)
            {
                key += "2YO";
            }

            if (ThreeYearOnly)
            {
                key += "3YO";
            }

            if (Grade1)
            {
                return key + "G1";
            }

            if (Grade2)
            {
                return key + "G2";
            }

            if (Grade3)
            {
                return key + "G3";
            }

            if (MCL)
            {
                key += "MCL";

                if (_maxClaimingPrice >= 40000.00)
                {
                    return key + "HIGH";
                }
                else
                {
                    return key + "LOW";
                }
            }

            if (MSW)
            {
                key += "MSW";
                return key;
            }

            if (Claimer)
            {
                key += "CLM";

                if (_maxClaimingPrice >= 40000.00)
                {
                    return key + "HIGH";
                }
                else
                {
                    return key + "LOW";
                }
            }

            if (Allowance)
            {
                key += "ALW";

                if (_restrictions.Contains("NW2L"))
                {
                    key += "LOW";
                    return key;
                }
                else
                {
                    key += "HIGH";
                    return key;
                }
            }

            if (OptionalClaimer)
            {
                key += "OCL";

                if (_restrictions.Contains("NW2L"))
                {
                    key += "LOW";
                    return key;
                }
                else
                {
                    key += "HIGH";
                    return key;
                }
            }

            if (Handicap)
            {
                key += "HCP";
                if (_valueOfRace >= 40000.00)
                {
                    key += "HIGH";
                }
                else
                {
                    key += "LOW";
                }
                return key;
            }

            if (Stakes)
            {
                key += "HCP";
                if (_valueOfRace >= 100000.00)
                {
                    key += "HIGH";
                }
                else
                {
                    key += "LOW";
                }
                return key;
            }


            return "UNKNOWN";
        }

        bool StateBredOnly
        {
            get
            {
                return null != _stateBredFlag && _stateBredFlag.Contains('S');
            }
        }

        bool FilliesAndMaresOnly
        {
            get
            {
                return _ageSexRestrictions.Length >= 3 && (_ageSexRestrictions[2] == 'F' || _ageSexRestrictions[2] == 'M');
            }
        }

        bool TwoYearOnly
        {
            get
            {
                return _ageSexRestrictions.Length >= 2 && _ageSexRestrictions[0] == 'A' && _ageSexRestrictions[1] == 'O';
            }
        }

        bool ThreeYearOnly
        {
            get
            {
                return _ageSexRestrictions.Length >= 1 && _ageSexRestrictions[0] == 'B' && _ageSexRestrictions[1] == 'O';
            }
        }

        public bool MCL
        {
            get
            {
                return _abbrRaceClass.Contains("MCL");
            }
        }

        bool MSW
        {
            get
            {
                return _abbrRaceClass.Contains("MSW");
            }
        }

        bool OptionalClaimer
        {
            get
            {
                return _abbrRaceClass.Contains("AOC");
            }
        }

        bool Claimer
        {
            get
            {
                return _abbrRaceClass.Contains("CLM");
            }
        }

        bool Allowance
        {
            get
            {
                return _abbrRaceClass.Contains("ALW") && !_abbrRaceClass.EndsWith("S");
            }
        }

        bool StarterAllowance
        {
            get
            {
                return _abbrRaceClass.Contains("ALW")  && _abbrRaceClass.EndsWith("S");
            }
        }

        bool Handicap
        {
            get
            {
                return _abbrRaceClass.Contains("SHP");
            }
        }

        bool Stakes
        {
            get
            {
                return _abbrRaceClass.Contains("STK");
            }
        }

        bool Grade1
        {
            get
            {
                return _grade == 1;
            }
        }

        bool Grade2
        {
            get
            {
                return _grade == 2;
            }
        }

        bool Grade3
        {
            get
            {
                return _grade == 3;
            }
        }

    }

}
