﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Hogar.Parsing;
using System.Data;

namespace Hogar.BrisPastPerformances.Extended
{
    public class BrisDailyCard
    {
        readonly List<BrisRace> _race = new List<BrisRace>();
        readonly string _brisAbrvTrackCode;
        readonly string _date;
        private DateTime? _fullDate = null;
        DailyCard _correspondingDailyCard = null;


        public BrisDailyCard(string brisAbrvTrackCode, string date)
        {
            _brisAbrvTrackCode = brisAbrvTrackCode;
            _date = date;
        }

        internal DailyCard CorrespondingDailyCard
        {
            get
            {
                return _correspondingDailyCard;
            }
            set
            {
                _correspondingDailyCard = value;
            }
        }

        public string TrackCode
        {
            get
            {
                return RaceTracks.GetTrackCodeFromBrisAbrv(_brisAbrvTrackCode);
            }
        }


        public DateTime GetFullDate()
        {

            if (null == _fullDate)
            {
                int year = Convert.ToInt32(_date.Substring(0, 4));
                int month = Convert.ToInt32(_date.Substring(4, 2));
                int day = Convert.ToInt32(_date.Substring(6, 2));
                _fullDate = new DateTime(year, month, day);

            }

            return _fullDate.Value;
            
        }

        public string Date
        {
            get
            {
                return _date;
            }
        }


        // GetOddsSummary : 
        //      Returns a DataTable containing only the Odds
        //      for every Race and every Horse in the race
        //      Used :
        //      1) From OddsEditor Form to View / Edit Odds
        //      2) From Exotic Studio to calculate average Odds etc

        public DataSet GetOddsSummary()
        {
            DataSet dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();


            int maximunNumberOfHorsesPerRace = 0;

            foreach (BrisRace race in _race)
            {
                dataTable.Columns.Add(" Race # " + race.RaceNumber.ToString(), typeof(Odds));

                if (maximunNumberOfHorsesPerRace < race.NumberOfHorses)
                {
                    maximunNumberOfHorsesPerRace = race.NumberOfHorses;
                }
            }


            for (int i = 0; i < maximunNumberOfHorsesPerRace; ++i)
            {

                object[] field = new object[_race.Count];

                int j = 0;
                foreach (BrisRace race in _race)
                {
                    if (i < race.NumberOfHorses)
                    {
                        field[j++] = race[i].MorningLineOdds;
                    }
                    else
                    {
                        field[j++] = null;
                    }
                }


                dataTable.Rows.Add(field);
            }

            return dataSet;

        }

        public List<BrisRace> Races
        {
            get
            {
                return _race;
            }
        }

        // May 7 2009
        // Calculates the winning percentages for each horse in the card
        // using the StatisticTools.FiguresToProbabilities method
        // we need to pass the mycard to get the scratches... 
        // It is a weakness of the code that we need the Race to be passed
        // This piece of the code needs to be refactored
        // TODO eliminate the need to pass myrace to brisrace to get scratches
        public void CalculatePercentages(DailyCard mycard)
        {
            foreach (BrisRace race in _race)
            {
                Race myrace = mycard.GetRaceFromRaceNumber(race.RaceNumber);
                race.CalculatePercentages(myrace);
            }
        }


        public void Load(string filename)
        {
            DataTable dt = Utilities.Parser(filename);
            BrisRace currentRace = null;
            _race.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                var horse = new BrisHorse(dr);

                // The following if ensures that when a new race is comming
                // we create a new race object and start populating it
                if ((currentRace == null) || (horse.RaceNumber != currentRace.RaceNumber))
                {
                    currentRace = new BrisRace(horse.RaceNumber, this);
                    _race.Add(currentRace);
                }

                Debug.Assert(null != currentRace);
                Debug.Assert(null != horse);

                horse.Parent = currentRace;
                currentRace.Add(horse);

            }
        }

        public BrisRace GetRaceByItsProgramNumber(int raceNumber)
        {
            foreach (BrisRace r in _race)
            {
                if (r.RaceNumber == raceNumber)
                {
                    return r;
                }
            }

            throw new Exception("Race Number: " + raceNumber.ToString() + " does not exist");
        }

        public List<int> GetProgramNumbersForAllRaces()
        {
            List<int> raceNumber = new List<int>();

            Debug.Assert(null != _race);

            foreach (BrisRace r in _race)
            {
                raceNumber.Add(r.RaceNumber);
            }

            return raceNumber;
        }
    }
}
