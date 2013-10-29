using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar;

namespace Hogar.Willard
{
    public class RaceInfo
    {
        readonly int _raceNumber;
        readonly int _raceID;
        readonly double _distance;
        readonly string _eqbRaceType;
        readonly double _firstCallTime;
        readonly double _secondCallTime;
        readonly double _finalTime;
        readonly string _surface;
        readonly double _maxClaimingPrice;
        readonly string _trackCode;
        readonly int _year;
        readonly int _month;
        readonly int _day;
        readonly bool _isStateBred;
        readonly bool _femaleOnly;
        readonly bool _twoYearsOnly;
        readonly bool _threeYearsOnly;
        readonly Distance _ds;

        public string TrackCode
        {
            get
            {
                return _trackCode;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
        }

        public int Month
        {
            get
            {
                return _month;
            }
        }

        public int Day
        {
            get
            {
                return _day;
            }
        }

        public int RaceNumber
        {
            get { return _raceNumber; }
        }

        public int RaceID
        {
            get { return _raceID; }
        }

        public Distance DistanceDetails
        {
            get
            {
                return _ds;
            }
        }

        public double DistanceOfTheRaceInYards
        {
            get { return _distance; }
        }

        public double DistanceOfTheRaceInFeet
        {
            get { return _distance * Utilities.FEET_IN_A_YEARD; }
        }

        public string EQBRaceType
        {
            get { return _eqbRaceType; }
        }

        public double MaxClaimingPrice
        {
            get { return _maxClaimingPrice; }
        }

        public double FirstCall
        {
            get { return _firstCallTime; }
        }

        public double SecondCall
        {
            get { return _secondCallTime; }
        }

        public double FinalTime
        {
            get { return _finalTime; }
        }


        public double FirstCallInFeet
        {
            get
            {
                return _ds.FractionDistancesForTheDistance.FirstCallDistanceInFeet;
            }
        }

        public double SecondCallInFeet
        {
            get
            {
                return _ds.FractionDistancesForTheDistance.SecondCallDistanceInFeet;
            }
        }

        public bool IsStateBred
        {
            get
            {
                return _isStateBred;
            }
        }

        public bool IsFemaleOnly
        {
            get
            {
                return _femaleOnly;
            }
        }

        public bool IsTwoYearsOnly
        {
            get
            {
                return _twoYearsOnly;
            }
        }

        public bool IsThreeYearsOnly
        {
            get
            {
                return _threeYearsOnly;
            }
        }

        /// <summary>
        /// true if the race was run in the inner false otherwise
        /// </summary>
        public bool WasRanInInnerTrack
        {
            get
            {
                if (_surface.Length > 0)
                {
                    return _surface[0] == 'd' || _surface[0] == 't';
                }
                else
                {
                    return false;
                }
            }
        }


        public bool WasRanInTheTurf
        {
            get
            {
                if (_surface.Length > 0)
                {
                    return _surface[0] == 'T' || _surface[0] == 't';
                }
                else
                {
                    return false;
                }
            }
        }


        static double CorrespondingCall(double f1, double f2, double f3, double f4, double f5, Distance.FractionType ft)
        {
            switch (ft)
            {
                case Distance.FractionType.First:
                    return f1;
                case Distance.FractionType.Second:
                    return f2;
                case Distance.FractionType.Third:
                    return f3;
                case Distance.FractionType.Fourth:
                    return f4;
                case Distance.FractionType.Fifth:
                    return f5;
                default:
                    return -1.0;
            }
        }

        static public RaceInfo Make(SqlDataReader myReader)
        {
            int id = (int)myReader["RACE_ID"];
            int num = (int)myReader["RACE_NUMBER"];
            double distance = (double)myReader["DISTANCE"];
            double f1 = (double)myReader["TIME_FOR_FRACTION_1"];
            double f2 = (double)myReader["TIME_FOR_FRACTION_2"];
            double f3 = (double)myReader["TIME_FOR_FRACTION_3"];
            double f4 = (double)myReader["TIME_FOR_FRACTION_4"];
            double f5 = (double)myReader["TIME_FOR_FRACTION_5"];
            double finalTime = (double)myReader["FINAL_TIME"];
            string eqbRaceType = myReader["EQB_RACE_TYPE"].ToString();
            string stateBredFlag = myReader["STATE_BRED_FLAG"].ToString();
            string ageSexRestriction = myReader["AGE_SEX_RESTRICTIONS"].ToString();
            string surface = myReader["SURFACE"].ToString();
            double maxClaimingPrice = (double)myReader["MAX_CLAIMING_PRICE"];
            string trackCode = myReader["TRACK_CODE"].ToString();

            string dateStrg = myReader["DATE_OF_THE_RACE"].ToString();

            int year = Convert.ToInt32(dateStrg.Substring(0, 4));
            int month = Convert.ToInt32(dateStrg.Substring(4, 2));
            int day = Convert.ToInt32(dateStrg.Substring(6, 2));

            Distance dp = DistanceCollection.FindDistanceInfo(distance, surface);

            if (null == dp)
            {
                string msg = string.Format("distance {0} is not available for {1}", distance, surface);
                throw new Exception(msg);
            }

            double firstCall = CorrespondingCall(f1, f2, f3, f4, f5, dp.FirstFractionType);
            double secondtCall = CorrespondingCall(f1, f2, f3, f4, f5, dp.SecondFractionType);

            return new RaceInfo(id, stateBredFlag, ageSexRestriction, num, distance, eqbRaceType, firstCall, secondtCall, finalTime, surface, maxClaimingPrice, trackCode, year, month, day, dp);

        }



        private RaceInfo(int id, string stateBredFlag, string ageSexRestriction, int num, double distance, string abbrRaceClass, double firstCallTime, double secondCallTime, double finalTime, string surface, double maxClaimingPrice, string trackCode, int year, int month, int day, Distance ds)
        {
            stateBredFlag += " ";
            ageSexRestriction += "   ";
            _raceNumber = num;
            _raceID = id;
            _distance = distance;
            _eqbRaceType = abbrRaceClass;
            _firstCallTime = firstCallTime;
            _secondCallTime = secondCallTime;
            _finalTime = finalTime;
            _surface = surface;
            _maxClaimingPrice = maxClaimingPrice;
            _trackCode = trackCode;
            _year = year;
            _month = month;
            _day = day;
            _ds = ds;
            _isStateBred = stateBredFlag[0] == 'S';
            _femaleOnly = ageSexRestriction[2] == 'F' || ageSexRestriction[2] == 'M';
            _twoYearsOnly = ageSexRestriction[0] == 'A';
            _threeYearsOnly = ageSexRestriction[0] == 'B';

        }

        public override string ToString()
        {
            return _raceNumber.ToString();
        }


    }

}
