using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hogar.BrisPastPerformances;
using Hogar;
/*
 *
 * 
FACTORS TO ADD


SufraceWinForTurfRaceOnly


DaysSinceLastRace10
DaysSinceLastRace10To30
DaysSinceLast30To90
DaysSinceLastMoreThan90

RacingFrequencyMoreThan45Days

 */

namespace Hogar.Handicapping
{
    public abstract class Factor 
    {
        readonly string _name;
        readonly long _bitMask;
        

        static private List<Factor> _availableFactors = null;
        static Dictionary<long, string> _factorName = null;

        static public void InitializeFactors()
        {
            
            _availableFactors = new List<Factor>();
            int bitpower = 1;
            
            _availableFactors.Add(new ComingFromBigWin(bitpower++));
            _availableFactors.Add(new TwoConsequtiveWins(bitpower++));
            _availableFactors.Add(new ShortBreak(bitpower++));
            _availableFactors.Add(new HadTroubleInLastRace(bitpower++));
            _availableFactors.Add(new WillMakeTheLeadEasily(bitpower++));
            _availableFactors.Add(new BadLast2(bitpower++));
            _availableFactors.Add(new BadLast2ClmOnly(bitpower++));
            _availableFactors.Add(new TopPrimePower(bitpower++));
            _availableFactors.Add(new TopBrisRating(bitpower++));
            _availableFactors.Add(new TopPrimePowerBy4(bitpower++));
            _availableFactors.Add(new BestFigures(bitpower++));
            _availableFactors.Add(new FirstTimeRouteToSprint(bitpower++));
            _availableFactors.Add(new FirstTimeSprintToRoute(bitpower++));
            _availableFactors.Add(new FirstTimeTurf(bitpower++));
            _availableFactors.Add(new FirstTimeDirt(bitpower++));
            _availableFactors.Add(new FirstTimeOut(bitpower++));
            _availableFactors.Add(new ChangedStyle(bitpower++));
            _availableFactors.Add(new FirstTimeLasix(bitpower++));
            _availableFactors.Add(new BlinkersOn(bitpower++));
            _availableFactors.Add(new BlinkersOff(bitpower++));
            _availableFactors.Add(new DropsToMCLForFirstTime(bitpower++));
            _availableFactors.Add(new DropsFromAlwToClm(bitpower++));
            _availableFactors.Add(new FirstAfterBreakingMdn(bitpower++));
            _availableFactors.Add(new BrisCompositeTopThree(bitpower++));
            _availableFactors.Add(new BrisCompositeTop(bitpower++));
            _availableFactors.Add(new BrisLateTopThree(bitpower++));
            _availableFactors.Add(new BrisLateTop(bitpower++));
            _availableFactors.Add(new TopAvgBrisClassRating(bitpower++));
            _availableFactors.Add(new TopThreeAvgBrisClassRating(bitpower++));
            _availableFactors.Add(new TopPrimePowerOnlyDirt(bitpower++));
            _availableFactors.Add(new UpInClaimingPriceAfterClaimWin(bitpower++));
            _availableFactors.Add(new OlderMaiden(bitpower++));
            _availableFactors.Add(new Layoff(bitpower++));
            _availableFactors.Add(new LongLayoff(bitpower++));
            _availableFactors.Add(new GoodWorkouts(bitpower++));
            _availableFactors.Add(new BrisTopClassAndRaceRating(bitpower++));
            _availableFactors.Add(new ThreeYOAgainstOlder(bitpower++));
            _availableFactors.Add(new FemaleAgainstMale(bitpower++));
            _availableFactors.Add(new DoubleMove(bitpower++));
            _availableFactors.Add(new SecondOfLayoff(bitpower++));
            _availableFactors.Add(new ThirdOfLayoff(bitpower++));
            _availableFactors.Add(new LostGroundInLastRace(bitpower++));
            _availableFactors.Add(new BeatenFavoriteInLastTwoRaces(bitpower++));
            _availableFactors.Add(new LostMoreThanFiveInTheRow(bitpower++));


            _factorName = new Dictionary<long, string>();

            SqlDataReader myReader = null;
            try
            {
                
                const string sql = "SELECT BIT_MASK, FACTOR_NAME FROM FACTOR_NAME";
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        long bitMask = (long)myReader["BIT_MASK"];
                        string name = myReader["FACTOR_NAME"].ToString();
                        _factorName.Add(bitMask, name.Trim());
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

        static public List<string> GetFactorNames(long mask)
        {
            var s = new List<string>();

            foreach (KeyValuePair<long, string> p in _factorName)
            {
                if ((p.Key & mask) == p.Key)
                {
                    s.Add(p.Value);
                }
            }

            return s;
        }


        static public int NumberOfFactors
        {
            get
            {
                return AvailableFactorsAsList.Count;
            }
        }

        static public void SaveFactorNamesToDb()
        {
            foreach (Factor f in AvailableFactorsAsList)
            {
                var myCommand = new SqlCommand(f.SQLSaveFactorName, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
            }
        }


        protected Factor(string name, int bitpower)
        {
            _name = name;
            _bitMask = (long)Math.Pow(2, bitpower);
        }


        private string SQLSaveFactorName
        {
            get
            {
                return string.Format("EXEC InsertFactorName {0}, '{1}' ", _bitMask, _name);
            }
        }
        

        public long BitMask
        {
            get
            {
                return _bitMask;
            }
        }

       

        static public Factor GetFactorByName(string name)
        {
            name = name.Trim();

            foreach (Factor f in AvailableFactorsAsList)
            {
                if (f._name.Trim().Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return f;
                }
            }

            return null;
        }

       
        
        static public List<Factor> AvailableFactorsAsList
        {
            get
            {
                if(null == _availableFactors)
                {
                    InitializeFactors();
                }

                return _availableFactors;
            }
        }


        static internal List<Factor> GetMatchingFactors(Horse myhorse)
        {
            BrisRace race = myhorse.CorrespondingBrisHorse.Parent;
            BrisHorse horse = myhorse.CorrespondingBrisHorse; 

            var af = new List<Factor>();

            foreach (Factor f in AvailableFactorsAsList)
            {
                if (f.AppliesToHorse(myhorse))
                {
                    af.Add(f);
                }
            }
            return af;
        }

        public abstract bool AppliesToHorse(Horse myhorse);


        public string Name
        {
            get
            {
                return _name;
            }
        }

        public override string ToString()
        {
            return _name ;
        }

    }

}
