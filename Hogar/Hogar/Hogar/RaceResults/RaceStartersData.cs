using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;


namespace Hogar.RaceResults
{
    class RaceStartersData
    {
        static  int TRACK_CODE = 0;
        static  int RACING_DATE = 1;
        static  int RACE_NUMBER = 2;
        static  int HORSE_NAME = 4;
        static  int FOREIGN_BRED_CODE = 5;
        static  int STATE_BRED_CODE = 6;
        static  int POST_POSITION = 7;
        static  int PROGRAM_NUMBER = 8;
        static  int YEAR_OF_BIRTH = 9;
        static  int BREED = 10;
        static  int COUPLED_FLAG = 11;
        static  int ABBR_JOCKEY_NAME = 12;
        static  int JOCKEY_LAST_NAME = 13;
        static  int JOCKEY_FIRST_NAME = 14;
        static  int JOCKEY_MIDDLE_NAME = 15;
        static  int ABBR_TRAINER_NAME = 17;
        static  int TRAINER_LAST_NAME = 18;
        static  int TRAINER_FIRST_NAME = 19;
        static  int TRAINER_MIDDLE_NAME = 20;
        static  int TRIP_COMMENT = 22;
        static  int OWNER_NAME = 23;
        static  int OWNER_FIRST_NAME = 24;
        static  int OWNER_MIDDLE_NAME = 25;
        static  int CLAIMING_PRICE = 26;
        static  int MEDICATION_CODES = 27;
        static  int EQUIPMENT_CODES = 28;
        static  int EARNINGS = 29;
        static  int ODDS = 30;
        static  int NON_BETTING_FLAG = 31;
        static  int FAVORITE_FLAG = 32;
        static  int DQ_FLAG = 35;
        static  int DQ_PLACING =36;
        static  int WEIGHT =37;
        static  int CORRECTED_WEIGHT = 38;
        static  int OVERWEIGHT_AMOUNT = 39;
        static  int CLAIMED_INDICATOR = 40;
        static  int CLAIMED_BY_TRAINER = 41;
        static  int CLAIMED_BY_OWNER = 46;
        static  int WIN_PAYOFF = 50;
        static  int PLACE_PAYOFF = 51;
        static  int SHOW_PAYOFF = 52;
        static  int START_CALL_POSITION = 54;
        static  int CALL_1_POSITION = 55;
        static  int CALL_2_POSITION = 56;
        static  int CALL_3_POSITION = 57;
        static  int STRETCH_POSITION = 58;
        static  int FINISH_POSITION = 59;
        static  int OFFICIAL_POSITION = 60;
        static  int START_CALL_LENGTHS_AHEAD =61;
        static  int CALL_1_LENGTHS_AHEAD =62;
        static  int CALL_2_LENGTHS_AHEAD =63;
        static  int CALL_3_LENGTHS_AHEAD =64;
        static  int STRETCH_LENGTHS_AHEAD =65;
        static  int FINISH_LENGTHS_AHEAD =66;
        static  int START_CALL_LENGTHS_BEHIND =67;
        static  int CALL_1_LENGTHS_BEHIND =68;
        static  int CALL_2_LENGTHS_BEHIND =69;
        static  int CALL_3_LENGTHS_BEHIND =70;
        static  int STRETCH_LENGTHS_BEHIND =71;
        static  int FINISH_LENGTHS_BEHIND =72;
        static  int START_CALL_MARGIN =73;
        static  int CALL_1_MARGIN =74;
        static  int CALL_2_MARGIN =75;
        static  int CALL_3_MARGIN =76;
        static  int STRETCH_MARGIN =77;
        static  int FINISH_MARGIN =78;
        static  int DEAD_HEAT_FLAG = 79;


        readonly ParsableText _pt;
        readonly RaceResultsInsertToDb.ProcessStatusMessageDelegate _sendMessage;
        readonly SqlCommand _myCommand = new SqlCommand();    

        public RaceStartersData(ParsableText pt, RaceResultsInsertToDb.ProcessStatusMessageDelegate SendMessage)
        {
            _pt = pt;
            _sendMessage = SendMessage;
        }

        public void InsertInDb()
        {
            string sql = InsertSql;
            //_sendMessage(sql);
            _myCommand.CommandText = sql;
            _myCommand.Connection = DbTools.DbUtilities.SqlConnection;
            _myCommand.ExecuteNonQuery();
        }

        private string InsertSql
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("EXEC AddNewRaceStarter ");
                sb.Append("'" +  TrackCode + "', ");
                sb.Append("'" +  RacingDate+ "', ");
                sb.Append( RaceNumber + ", ");
                sb.Append("'" +  HorseName+ "', ");
                sb.Append("'" +  ForeignBredCode+ "', ");
                sb.Append("'" +  StateBredCode+ "', ");
                sb.Append( PostPosition+ ", ");
                sb.Append("'" +  ProgramNumber+ "', ");
                sb.Append( YearOfBirth+ ", ");
                sb.Append("'" +  Breed+ "', ");
                sb.Append("'" +  CoupledFlag+ "', ");
                sb.Append("'" +  AbbrJockeyName+ "', ");
                sb.Append("'" +  JockeyLastName+ "', ");
                sb.Append("'" +  JockeyFirstName+ "', ");
                sb.Append("'" +  JockeyMiddleName+ "', ");
                sb.Append("'" +  AbbrTrainerName+ "', ");
                sb.Append("'" +  TrainerLastName+ "', ");
                sb.Append("'" +  TrainerFirstName+ "', ");
                sb.Append("'" +  TrainerMiddleName+ "', ");
                sb.Append("'" +  TripComment+ "', ");
                sb.Append("'" +  OwnerName+ "', ");
                sb.Append("'" +  OwnerFirstName+ "', ");
                sb.Append("'" +  OwnerMiddleName+ "', ");
                sb.Append( ClaimingPrice+ ", ");
                sb.Append("'" +  MedicationCodes+ "', ");
                sb.Append("'" +  EquipmentCodes+ "', ");
                sb.Append( Earnings+ ", ");
                sb.Append( Odds+ ", ");
                sb.Append("'" +  NonBettingFlag+ "', ");
                sb.Append( FavoriteFlag+ ", ");
                sb.Append("'" +  DQFlag+ "', ");
                sb.Append( DQPlacing+ ", ");
                sb.Append( Weight+ ", ");
                sb.Append("'" +  CorrectedWeight+ "', ");
                sb.Append( OverweightAmount+ ", ");
                sb.Append("'" +  ClaimedIndicator+ "', ");
                sb.Append("'" +  ClaimedByTrainer+ "', ");
                sb.Append("'" +  ClaimedByOwner+ "', ");
                sb.Append( WinPayoff+ ", ");
                sb.Append( PlacePayoff+ ", ");
                sb.Append( ShowPayoff+ ", ");
                sb.Append( StartCallPosition+ ", ");
                sb.Append( Call1Position+ ", ");
                sb.Append( Call2Position+ ", ");
                sb.Append( Call3Position+ ", ");
                sb.Append( StretchPosition+ ", ");
                sb.Append( FinishPosition+ ", ");
                sb.Append( OfficialPosition+ ", ");
                sb.Append( StartCallLengthsAhead+ ", ");
                sb.Append( Call1LengthsAhead+ ", ");
                sb.Append( Call2LengthsAhead+ ", ");
                sb.Append( Call3LengthsAhead+ ", ");
                sb.Append( StretchLengthsAhead+ ", ");
                sb.Append( FinishLengthsAhead+ ", ");
                sb.Append( StartCallLengthsBehind+ ", ");
                sb.Append( Call1LengthsBehind+ ", ");
                sb.Append( Call2LengthsBehind+ ", ");
                sb.Append( Call3LengthsBehind+ ", ");
                sb.Append( StretchLengthsBehind+ ", ");
                sb.Append( FinishLengthsBehind+ ", ");
                sb.Append( StartCallMargin+ ", ");
                sb.Append( Call1Margin+ ", ");
                sb.Append( Call2Margin+ ", ");
                sb.Append( Call3Margin+ ", ");
                sb.Append( StretchMargin+ ", ");
                sb.Append(FinishMargin + ", ");
                sb.Append("'" +  DeadHeatFlag+ "' ");
                string s = sb.ToString();
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
        
        public string HorseName
        {
            get
            {
                return _pt.Tokens[HORSE_NAME].ToString();
            }
        }
        
        public string ForeignBredCode
        {
            get
            {
                return _pt.Tokens[FOREIGN_BRED_CODE].ToString();
            }
        }
        
        public string StateBredCode
        {
            get
            {
                return _pt.Tokens[STATE_BRED_CODE].ToString();
            }
        }
           
        public int PostPosition
        {
            get
            {
                return _pt.Tokens[POST_POSITION].GetAsInteger();
            }
        }
  
        public string ProgramNumber
        {
            get
            {
                return _pt.Tokens[PROGRAM_NUMBER].ToString();
            }
        }
        
         public int YearOfBirth
        {
            get
            {
                return _pt.Tokens[YEAR_OF_BIRTH].GetAsInteger();
            }
        }  
         
        public string Breed
        {
            get
            {
                return _pt.Tokens[BREED].ToString();
            }
        }
         
        public string CoupledFlag
        {
            get
            {
                return _pt.Tokens[COUPLED_FLAG].ToString();
            }
        }

        public string AbbrJockeyName
        {
            get
            {
                return _pt.Tokens[ABBR_JOCKEY_NAME].ToString();
            }
        }
           
        public string JockeyLastName
        {
            get
            {
                return _pt.Tokens[JOCKEY_LAST_NAME].ToString();
            }
        }  
         
        public string JockeyFirstName
        {
            get
            {
                return _pt.Tokens[JOCKEY_FIRST_NAME].ToString();
            }
        }
         
        public string JockeyMiddleName
        {
            get
            {
                return _pt.Tokens[JOCKEY_MIDDLE_NAME].ToString();
            }
        }

        public string AbbrTrainerName
        {
            get
            {
                return _pt.Tokens[ABBR_TRAINER_NAME].ToString();
            }
        }
           
        public string TrainerLastName
        {
            get
            {
                return _pt.Tokens[TRAINER_LAST_NAME].ToString();
            }
        }  
         
        public string TrainerFirstName
        {
            get
            {
                return _pt.Tokens[TRAINER_FIRST_NAME].ToString();
            }
        }
         
        public string TrainerMiddleName
        {
            get
            {
                return _pt.Tokens[TRAINER_MIDDLE_NAME].ToString();
            }
        }

        public string TripComment
        {
            get
            {
                return _pt.Tokens[TRIP_COMMENT].ToString();
            }
        }

        public string OwnerName
        {
            get
            {
                return _pt.Tokens[OWNER_NAME].ToString();
            }
        }
        
        public string OwnerFirstName
        {
            get
            {
                return _pt.Tokens[OWNER_FIRST_NAME].ToString();
            }
        }
         
        public string OwnerMiddleName
        {
            get
            {
                return _pt.Tokens[OWNER_MIDDLE_NAME].ToString();
            }
        }
           
        public double ClaimingPrice
        {
            get
            {
                return _pt.Tokens[CLAIMING_PRICE].GetAsDouble();
            }
        }

        public string MedicationCodes
        {
            get
            {
                return _pt.Tokens[MEDICATION_CODES].ToString();
            }
        }
           
        public string EquipmentCodes
        {
            get
            {
                return _pt.Tokens[EQUIPMENT_CODES].ToString();
            }
        }
         
        public double Earnings
        {
            get
            {
                return _pt.Tokens[EARNINGS].GetAsDouble();
            }
        }
           
        public double Odds
        {
            get
            {
                return _pt.Tokens[ODDS].GetAsDouble();
            }
        }
  
        public string NonBettingFlag
        {
            get
            {
                return _pt.Tokens[NON_BETTING_FLAG].ToString();
            }
        }

        public int FavoriteFlag
        {
            get
            {
                return _pt.Tokens[FAVORITE_FLAG].GetAsInteger();
            }
        }

        public string DQFlag
        {
            get
            {
                return _pt.Tokens[DQ_FLAG].ToString();
            }
        }

        public int DQPlacing
        {
            get
            {
                return _pt.Tokens[DQ_PLACING].GetAsInteger();
            }
        }
         
        public int Weight
        {
            get
            {
                return _pt.Tokens[WEIGHT].GetAsInteger();
            }
        }

        public string CorrectedWeight
        {
            get
            {
                return _pt.Tokens[CORRECTED_WEIGHT].ToString();
            }
        }
         
        public int OverweightAmount
        {
            get
            {
                return _pt.Tokens[OVERWEIGHT_AMOUNT].GetAsInteger();
            }
        }

        public string ClaimedIndicator
        {
            get
            {
                return _pt.Tokens[CLAIMED_INDICATOR].ToString();
            }
        }
         
        public string ClaimedByTrainer
        {
            get
            {
                return _pt.Tokens[CLAIMED_BY_TRAINER].ToString();
            }
        }
         
        public string ClaimedByOwner
        {
            get
            {
                return _pt.Tokens[CLAIMED_BY_OWNER].ToString();
            }
        }
         
        public double WinPayoff
        {
            get
            {
                return _pt.Tokens[WIN_PAYOFF].GetAsDouble();
            }
        }
         
        public double PlacePayoff
        {
            get
            {
                return _pt.Tokens[PLACE_PAYOFF].GetAsDouble();
            }
        }
         
        public double ShowPayoff
        {
            get
            {
                return _pt.Tokens[SHOW_PAYOFF].GetAsDouble();
            }
        }
         
        public int StartCallPosition
        {
            get
            {
                return _pt.Tokens[START_CALL_POSITION].GetAsInteger();
            }
        }
         
        public int Call1Position
        {
            get
            {
                return _pt.Tokens[CALL_1_POSITION].GetAsInteger();
            }
        }
         
        public int Call2Position
        {
            get
            {
                return _pt.Tokens[CALL_2_POSITION].GetAsInteger();
            }
        }
         
        public int Call3Position
        {
            get
            {
                return _pt.Tokens[CALL_3_POSITION].GetAsInteger();
            }
        }

        public int StretchPosition
        {
            get
            {
                return _pt.Tokens[STRETCH_POSITION].GetAsInteger();
            }
        }
         
        public int FinishPosition
        {
            get
            {
                return _pt.Tokens[FINISH_POSITION].GetAsInteger();
            }
        }
           
        public int OfficialPosition
        {
            get
            {
                return _pt.Tokens[OFFICIAL_POSITION].GetAsInteger();
            }
        }  
         
        public double StartCallLengthsAhead
        {
            get
            {
                return _pt.Tokens[START_CALL_LENGTHS_AHEAD].GetAsDouble();
            }
        }
         
        public double Call1LengthsAhead
        {
            get
            {
                return _pt.Tokens[CALL_1_LENGTHS_AHEAD].GetAsDouble();
            }
        }

        public double Call2LengthsAhead
        {
            get
            {
                return _pt.Tokens[CALL_2_LENGTHS_AHEAD].GetAsDouble();
            }
        }

        public double Call3LengthsAhead
        {
            get
            {
                return _pt.Tokens[CALL_3_LENGTHS_AHEAD].GetAsDouble();
            }
        }
         
        public double StretchLengthsAhead
        {
            get
            {
                return _pt.Tokens[STRETCH_LENGTHS_AHEAD].GetAsDouble();
            }
        }
           
        public double FinishLengthsAhead
        {
            get
            {
                return _pt.Tokens[FINISH_LENGTHS_AHEAD].GetAsDouble();
            }
        }
           
        public double StartCallLengthsBehind
        {
            get
            {
                return _pt.Tokens[START_CALL_LENGTHS_BEHIND].GetAsDouble();
            }
        }  
         
        public double Call1LengthsBehind
        {
            get
            {
                return _pt.Tokens[CALL_1_LENGTHS_BEHIND].GetAsDouble();
            }
        }
         
        public double Call2LengthsBehind
        {
            get
            {
                return _pt.Tokens[CALL_2_LENGTHS_BEHIND].GetAsDouble();
            }
        }
         
        public double Call3LengthsBehind
        {
            get
            {
                return _pt.Tokens[CALL_3_LENGTHS_BEHIND].GetAsDouble();
            }
        }
         
        public double StretchLengthsBehind
        {
            get
            {
                return _pt.Tokens[STRETCH_LENGTHS_BEHIND].GetAsDouble();
            }
        }
         
        public double FinishLengthsBehind
        {
            get
            {
                return _pt.Tokens[FINISH_LENGTHS_BEHIND].GetAsDouble();
            }
        }
        
        public double StartCallMargin
        {
            get
            {
                return _pt.Tokens[START_CALL_MARGIN].GetAsDouble();
            }
        }
         
        public double Call1Margin
        {
            get
            {
                return _pt.Tokens[CALL_1_MARGIN].GetAsDouble();
            }
        }
         
        public double Call2Margin
        {
            get
            {
                return _pt.Tokens[CALL_2_MARGIN].GetAsDouble();
            }
        }
         
        public double Call3Margin
        {
            get
            {
                return _pt.Tokens[CALL_3_MARGIN].GetAsDouble();
            }
        }
         
        public double StretchMargin
        {
            get
            {
                return _pt.Tokens[STRETCH_MARGIN].GetAsDouble();
            }
        }

        public double FinishMargin
        {
            get
            {
                return _pt.Tokens[FINISH_MARGIN].GetAsDouble();
            }
        }
         
        public string DeadHeatFlag
        {
            get
            {
                return _pt.Tokens[DEAD_HEAT_FLAG].ToString();
            }
        }
    }
}
