using System;
using Hogar;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    internal enum RaceType
    {
        MCL = 2,
        MSW = 4,
        CLM = 8,
        ALW = 16,
        STAKES = 32,
        DIRT = 64,
        TURF = 128
    }

    internal class Starter
    {
        public Starter(DbReader dbr)
        {
            RaceId = dbr.GetValue<int>("RACE_ID");
            TrackCode = dbr.GetValue<string>("TRACK_CODE").Trim();
            Date = dbr.GetValue<string>("RACING_DATE");
            HorseName = dbr.GetValue<string>("HORSE_NAME").Trim();
            WasTheFavorite = (1 == dbr.GetValue<int>("WAS_THE_FAVORITE"));
            Odds = dbr.GetValue<double>("ODDS");
            Distance = dbr.GetValue<double>("DISTANCE");
            Surface = dbr.GetValue<string>("SURFACE").Trim();
            Jockey = dbr.GetValue<string>("ABBR_JOCKEY_NAME").Trim();
            FinishPosition = dbr.GetValue<int>("FINISH_POSITION");
            AbbrRaceClass = dbr.GetValue<string>("ABBR_RACE_CLASS").Trim();
            AgeSexRestrictions = dbr.GetValue<string>("AGE_SEX_RESTRICTIONS").Trim();
            StateBredFlag = dbr.GetValue<string>("STATE_BRED_FLAG").Trim();
            RaceGrade = dbr.GetValue<int>("RACE_GRADE");
            RaceName = dbr.GetValue<string>("RACE_NAME").Trim();
            RaceNumber = dbr.GetValue<int>("RACE_NUMBER");
            ProgramNumber = dbr.GetValue<string>("PROGRAM_NUMBER").Trim();
            BrisRaceTypeDescription = dbr.GetValue<string>("BRIS_RACE_TYPE").Trim();
            FactorsFlag = dbr.GetValue<long>("FACTORS_FLAG");
            FieldSize = dbr.GetValue<int>("FIELD_SIZE");

            if(AbbrRaceClass.Length > 20)
            {
                AbbrRaceClass = AbbrRaceClass.Substring(0, 19);
            }
        }


        public string TrackCode { get; private set; }
        public int RaceId { get; private set; }
        public string Date { get; private set; }
        public string HorseName { get; private set; }
        public bool WasTheFavorite { get; private set; }
        public double Odds { get; private set; }
        public double Distance { get; private set; }
        public string Surface { get; private set; }
        public string Jockey { get; private set; }
        public int FinishPosition { get; private set; }
        public string AbbrRaceClass { get; private set; }
        public string AgeSexRestrictions { get; private set; }
        public string StateBredFlag { get; private set; }
        public int RaceGrade { get; private set; }
        public string RaceName{ get; private set; }
        public int RaceNumber { get; private set; }
        public string ProgramNumber { get; private set; }
        public string BrisRaceTypeDescription { get; private set; }
        public long FactorsFlag { get; private set; }
        public int FieldSize { get; private set; }

        
        public int Year
        {
            get
            {
                if(Date.Length >=8)
                {
                    return Convert.ToInt32(Date.Substring(0, 4));
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Month
        {
            get
            {
                if (Date.Length >= 8)
                {
                    return Convert.ToInt32(Date.Substring(4, 2));
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Day
        {
            get
            {
                if (Date.Length >= 8)
                {
                    return Convert.ToInt32(Date.Substring(6, 2));
                }
                else
                {
                    return 0;
                }
            }
        }

        public int BrisRaceTypeFlag
        {
            get
            {
                int flag = (int) BrisRaceType;

                if(Surface.ToUpper().Contains("T"))
                {
                    flag = flag | (int)RaceType.TURF;
                }
                else
                {
                    flag = flag | (int)RaceType.DIRT;
                }

                return flag;
            }
        }


        private RaceType BrisRaceType
        {
            get
            {
                if(BrisRaceTypeDescription.Trim().ToUpper() == "M" || BrisRaceTypeDescription.Trim().ToUpper() == "MO")
                {
                    return RaceType.MCL;
                }
                else if (BrisRaceTypeDescription.Trim().ToUpper() == "S" )
                {
                    return RaceType.MSW;
                }
                else if (BrisRaceTypeDescription.Trim().ToUpper() == "C")
                {
                    return RaceType.CLM;
                }
                else if (BrisRaceTypeDescription.Trim().ToUpper() == "G1" ||
                        BrisRaceTypeDescription.Trim().ToUpper() == "G2" ||
                        BrisRaceTypeDescription.Trim().ToUpper() == "G3" ||
                        BrisRaceTypeDescription.Trim().ToUpper() == "N" )
                {
                    return RaceType.STAKES;
                }
                else
                {
                    return RaceType.ALW;
                }
            }
        }

        

    }
}