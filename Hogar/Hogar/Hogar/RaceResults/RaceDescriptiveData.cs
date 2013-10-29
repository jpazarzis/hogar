using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.RaceResults
{
    class RaceDescriptiveData
    {
           static  int TRACK_CODE = 0;
           static  int DATE_OF_THE_RACE = 1;
           static  int RACE_NUMBER = 2;
           static  int DISTANCE = 4;
           static  int DISTANCE_UNIT = 5;
           static  int ABOUT_DISTANCE_FLAG = 6;
           static  int SURFACE = 8;
           static  int ALL_WEATHER_FLAG =10;
           static  int CHUTE_START_FLAG =11;
           static  int BRIS_RACE_TYPE = 12;
           static  int EQB_RACE_TYPE =13;
           static  int RACE_GRADE = 14;
           static  int AGE_SEX_RESTRICTIONS = 15;
           static  int RACE_RESTRICTIONS = 16;
           static  int STATE_BRED_FLAG = 17;
           static  int ABBR_RACE_CLASS = 18;
           static  int BREED_INDICATOR = 19;
           static  int COUNTRY_OF_RACE = 20;
           static  int PURSE = 21;
           static  int TOTAL_VALUE_OF_RACE = 22;
           static  int MAX_CLAIMING_PRICE = 27;
           static  int RACE_CONDITIONS_1 = 29;
           static  int RACE_CONDITIONS_2 = 30;
           static  int RACE_CONDITIONS_3 = 31;
           static  int RACE_CONDITIONS_4 = 32;
           static  int RACE_CONDITIONS_5 = 33;
           static  int FIELD_SIZE = 36;
           static  int TRACK_CONDITION = 37;
           static  int TIME_FOR_FRACTION_1 = 38;
           static  int TIME_FOR_FRACTION_2 = 39;
           static  int TIME_FOR_FRACTION_3 = 40;
           static  int TIME_FOR_FRACTION_4 = 41;
           static  int TIME_FOR_FRACTION_5 = 42;
           static  int FINAL_TIME = 43;
           static  int FRACTION_1_DISTANCE = 44;
           static  int FRACTION_2_DISTANCE = 45;
           static  int FRACTION_3_DISTANCE = 46;
           static  int FRACTION_4_DISTANCE = 47;
           static  int FRACTION_5_DISTANCE = 48;
           static  int OFF_TIME = 49;
           static  int START_CALL_DISTANCE = 50;
           static  int CALL_1_DISTANCE = 51;  
           static  int CALL_2_DISTANCE = 52;
           static  int CALL_3_DISTANCE = 53;
           static  int RACE_NAME = 54;
           static  int START_DESCRIPTION = 55;
           static  int TEMP_RAIL_DISTANCE = 56;
           static  int OFF_TURF_INDICATOR = 57;
           static  int OFF_TURF_DIST_CHANGE_FLAG =58;
           static  int WEATHER = 62;
           static  int RACE_TEMPERATURE = 63;
           static  int WPS_POOL = 64;


        readonly ParsableText _pt;

        RaceResultsInsertToDb.ProcessStatusMessageDelegate _sendMessage;

        public RaceDescriptiveData(ParsableText pt, RaceResultsInsertToDb.ProcessStatusMessageDelegate SendMessage)
        {
            _pt = pt;
            _sendMessage = SendMessage;
        }


        public void TestInsertInDb()
        {
            Console.Write(RaceConditions);
            Console.Write(" Field Size: ");
            Console.Write(FieldSize);
            Console.Write(" Track Condition: ");
            Console.WriteLine(TrackCondition);
            Console.WriteLine("---------------");

            /*
            sb.Append("'" + RaceConditions + "', ");
            sb.Append(FieldSize + ", ");
            sb.Append("'" + TrackCondition + "', ");
            sb.Append(TimeForFraction1 + ", ");
            sb.Append(TimeForFraction2 + ", ");
            sb.Append(TimeForFraction3 + ", ");
            sb.Append(TimeForFraction4 + ", ");
            sb.Append(TimeForFraction5 + ", ");
            sb.Append(FinalTime + ", ");
            */
        }

        public bool InsertInDb()
        {

            try
            {

                string sql = InsertSql;

                //_sendMessage(sql);

                SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                decimal id = -1;
                while (myReader.Read())
                {

                    id = (decimal)myReader["ID"];
                }
                myReader.Close();

                return id > 0;
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }
    
        private string InsertSql
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("EXEC AddNewRaceDescription ");
                sb.Append("'" + TrackCode + "', ");
                sb.Append("'" + DateOfTheRace + "', ");
                sb.Append(RaceNumber + ", ");
                sb.Append(Distance + ", ");
                sb.Append("'" + DistanceUnit + "', ");
                sb.Append("'" + AboutDistanceFlag + "', ");
                sb.Append("'" + Surface + "', ");
                sb.Append("'" + AllWeatherFlag + "', ");
                sb.Append("'" + ChuteStartFlag + "', ");
                sb.Append("'" + BrisRaceType + "', ");
                sb.Append("'" + EqbRaceType + "', ");
                sb.Append(RaceGrade + ", ");
                sb.Append("'" + AgeSexRestrictions + "', ");
                sb.Append("'" + RaceRestrictions + "', ");
                sb.Append("'" + StateBredFlag + "', ");
                sb.Append("'" + AbbrRaceClass + "', ");
                sb.Append("'" + BreedIndicator + "', ");
                sb.Append("'" + CountryOfRace + "', ");
                sb.Append(Purse + ", ");
                sb.Append(TotalValueOfRace + ", ");
                sb.Append(MaxClaimingPrice + ", ");
                sb.Append("'" + RaceConditions + "', ");
                sb.Append(FieldSize + ", ");
                sb.Append("'" + TrackCondition + "', ");
                sb.Append(TimeForFraction1 + ", ");
                sb.Append(TimeForFraction2 + ", ");
                sb.Append(TimeForFraction3 + ", ");
                sb.Append(TimeForFraction4 + ", ");
                sb.Append(TimeForFraction5 + ", ");
                sb.Append(FinalTime + ", ");
                sb.Append(Fraction1Distance + ", ");
                sb.Append(Fraction2Distance + ", ");
                sb.Append(Fraction3Distance + ", ");
                sb.Append(Fraction4Distance + ", ");
                sb.Append(Fraction5Distance + ", ");
                sb.Append("'" + OffTime + "', ");
                sb.Append(StartCallDistance + ", ");
                sb.Append(Call1Distance + ", ");
                sb.Append(Call2Distance + ", ");
                sb.Append(Call3Distance + ", ");
                sb.Append("'" + RaceName + "', ");
                sb.Append("'" + StartDescription + "', ");
                sb.Append(TempRailDistance + ", ");
                sb.Append("'" + OffTurfIndicator + "', ");
                sb.Append("'" + OffTurfDistChangeFlag + "', ");
                sb.Append("'" + Weather + "', ");
                sb.Append(RaceTemperature + ", ");
                sb.Append(WPSPool + " ");

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

        public string DateOfTheRace
        {
            get
            {
                return _pt.Tokens[DATE_OF_THE_RACE].ToString();
            }
        }

        public int RaceNumber
        {
            get
            {
                return _pt.Tokens[RACE_NUMBER].GetAsInteger();
            }
        }
           
        public double Distance
        {
            get
            {
                return _pt.Tokens[DISTANCE].GetAsDouble();
            }
        }
        
        public string DistanceUnit
        {
            get
            {
                return _pt.Tokens[DISTANCE_UNIT].ToString();
            }
        }

        public string AboutDistanceFlag
        {
            get
            {
                return _pt.Tokens[ABOUT_DISTANCE_FLAG].ToString();
            }
        }

        public string Surface
        {
            get
            {
                return _pt.Tokens[SURFACE].ToString();
            }
        }
         
        public string AllWeatherFlag
        {
            get
            {
                return _pt.Tokens[ALL_WEATHER_FLAG].ToString();
            }
        }
         
        public string ChuteStartFlag
        {
            get
            {
                return _pt.Tokens[CHUTE_START_FLAG].ToString();
            }
        }
         
        public string BrisRaceType
        {
            get
            {
                return _pt.Tokens[BRIS_RACE_TYPE].ToString();
            }
        }

        public string EqbRaceType
        {
            get
            {
                return _pt.Tokens[EQB_RACE_TYPE].ToString();
            }
        }
           
        public int RaceGrade
        {
            get
            {
                return _pt.Tokens[RACE_GRADE].GetAsInteger();
            }
        }
  
        public string AgeSexRestrictions
        {
            get
            {
                return _pt.Tokens[AGE_SEX_RESTRICTIONS].ToString();
            }
        }
           
        public string RaceRestrictions
        {
            get
            {
                return _pt.Tokens[RACE_RESTRICTIONS].ToString();
            }
        }  
         
        public string StateBredFlag
        {
            get
            {
                return _pt.Tokens[STATE_BRED_FLAG].ToString();
            }
        }

        public string AbbrRaceClass
        {
            get
            {
                return _pt.Tokens[ABBR_RACE_CLASS].ToString();
            }
        }
           
        public string BreedIndicator
        {
            get
            {
                return _pt.Tokens[BREED_INDICATOR].ToString();
            }
        }  
         
        public string CountryOfRace
        {
            get
            {
                return _pt.Tokens[COUNTRY_OF_RACE].ToString();
            }
        }
  
        public double Purse
        {
            get
            {
                return _pt.Tokens[PURSE].GetAsDouble();
            }
        }  
         
        public double TotalValueOfRace
        {
            get
            {
                return _pt.Tokens[TOTAL_VALUE_OF_RACE].GetAsDouble();
            }
        }
           
        public double MaxClaimingPrice
        {
            get
            {
                return _pt.Tokens[MAX_CLAIMING_PRICE].GetAsDouble();
            }
        }  
           
        public string RaceConditions
        {
            get
            {
                string txt = "";
                txt += _pt.Tokens[RACE_CONDITIONS_1].ToString();
                txt += _pt.Tokens[RACE_CONDITIONS_2].ToString();
                txt += _pt.Tokens[RACE_CONDITIONS_3].ToString();
                txt += _pt.Tokens[RACE_CONDITIONS_4].ToString();
                txt += _pt.Tokens[RACE_CONDITIONS_5].ToString();
                return txt;
            }
        }
         
        public int FieldSize
        {
            get
            {
                return _pt.Tokens[FIELD_SIZE].GetAsInteger();
            }
        }

        public string TrackCondition
        {
            get
            {
                return _pt.Tokens[TRACK_CONDITION].ToString();
            }
        }

        public double TimeForFraction1
        {
            get
            {
                return _pt.Tokens[TIME_FOR_FRACTION_1].GetAsDouble();
            }
        }
         
        public double TimeForFraction2
        {
            get
            {
                return _pt.Tokens[TIME_FOR_FRACTION_2].GetAsDouble();
            }
        }

        public double TimeForFraction3
        {
            get
            {
                return _pt.Tokens[TIME_FOR_FRACTION_3].GetAsDouble();
            }
        }
         
        public double TimeForFraction4
        {
            get
            {
                return _pt.Tokens[TIME_FOR_FRACTION_4].GetAsDouble();
            }
        }

        public double TimeForFraction5
        {
            get
            {
                return _pt.Tokens[TIME_FOR_FRACTION_5].GetAsDouble();
            }
        }

        public double FinalTime
        {
            get
            {
                return _pt.Tokens[FINAL_TIME].GetAsDouble();
            }
        }
         
        public double Fraction1Distance
        {
            get
            {
                return _pt.Tokens[FRACTION_1_DISTANCE].GetAsDouble();
            }
        }

        public double Fraction2Distance
        {
            get
            {
                return _pt.Tokens[FRACTION_2_DISTANCE].GetAsDouble();
            }
        }
        
        public double Fraction3Distance
        {
            get
            {
                return _pt.Tokens[FRACTION_3_DISTANCE].GetAsDouble();
            }
        }

        public double Fraction4Distance
        {
            get
            {
                return _pt.Tokens[FRACTION_4_DISTANCE].GetAsDouble();
            }
        }

        public double Fraction5Distance
        {
            get
            {
                return _pt.Tokens[FRACTION_5_DISTANCE].GetAsDouble();
            }
        }

        public string OffTime
        {
            get
            {
                return _pt.Tokens[OFF_TIME].ToString();
            }
        }
         
        public double StartCallDistance
        {
            get
            {
                return _pt.Tokens[START_CALL_DISTANCE].GetAsDouble();
            }
        }
         
        public double Call1Distance
        {
            get
            {
                return _pt.Tokens[CALL_1_DISTANCE].GetAsDouble();
            }
        }

        public double Call2Distance
        {
            get
            {
                return _pt.Tokens[CALL_2_DISTANCE].GetAsDouble();
            }
        }
         
        public double Call3Distance
        {
            get
            {
                return _pt.Tokens[CALL_3_DISTANCE].GetAsDouble();
            }
        }

        public string RaceName
        {
            get
            {
                return _pt.Tokens[RACE_NAME].ToString();
            }
        }

        public string StartDescription
        {
            get
            {
                return _pt.Tokens[START_DESCRIPTION].ToString();
            }
        }

        public double TempRailDistance
        {
            get
            {
                return _pt.Tokens[TEMP_RAIL_DISTANCE].GetAsDouble();
            }
        }
   
        public string OffTurfIndicator
        {
            get
            {
                return _pt.Tokens[OFF_TURF_INDICATOR].ToString();
            }
        }
  
        public string OffTurfDistChangeFlag
        {
            get
            {
                return _pt.Tokens[OFF_TURF_DIST_CHANGE_FLAG].ToString();
            }
        }
         
        public string Weather
        {
            get
            {
                return _pt.Tokens[WEATHER].ToString();
            }
        }

        public double RaceTemperature
        {
            get
            {
                return _pt.Tokens[RACE_TEMPERATURE].GetAsDouble();
            }
        }
  
        public double WPSPool
        {
            get
            {
                return _pt.Tokens[WPS_POOL].GetAsDouble();
            }
        }
    }
}
