using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hogar.RaceResults
{
    public class HorsePastPerformance
    {
        readonly string _horseName;
        readonly string _trackCode;
        readonly string _date;
        readonly int _raceNumber;
        readonly int _raceid;
        readonly double _distance;
        readonly string _surface;
        readonly string _abbrRaceClass;
        readonly string _abbrJockeyName;
        readonly string _abbrTrainerName;
        readonly double _odds;
        readonly int _weight;
        readonly int _officialPosition;
        readonly int _finishPosition;
        readonly double _finalTime;
        readonly double _finishLengthBehind;
        readonly int _goldenFigure;
        readonly int _winnersGoldenFigure;


        double _totalMargin = 0;

        public HorsePastPerformance(SqlDataReader myReader)
        {
            _raceid = (int)myReader["RACE_ID"];
            _trackCode = myReader["TRACK_CODE"].ToString().Trim();
            _date = myReader["RACING_DATE"].ToString().Trim();
            _raceNumber = (int)myReader["RACE_NUMBER"];
            _distance = (double)myReader["DISTANCE"];
            _surface = myReader["SURFACE"].ToString().Trim();
            _abbrRaceClass = myReader["ABBR_RACE_CLASS"].ToString().Trim();
            _horseName = myReader["HORSE_NAME"].ToString().Trim();
            _abbrJockeyName = myReader["ABBR_JOCKEY_NAME"].ToString().Trim();
            _abbrTrainerName = myReader["ABBR_TRAINER_NAME"].ToString().Trim();
            _odds = (double)myReader["ODDS"];
            _weight = (int)myReader["WEIGHT"];
            _finishPosition = (int)myReader["FINISH_POSITION"];
            _officialPosition = (int)myReader["OFFICIAL_POSITION"];
            _finalTime = (double)myReader["FINAL_TIME"];
            _finishLengthBehind = (double)myReader["FINISH_LENGTHS_BEHIND"];

            _goldenFigure = (int) ((double)myReader["GoldenFigure"]);
            _winnersGoldenFigure = (int) ((double)myReader["WinnersGoldenFigure"]);

        }


        public string HorseName { get { return _horseName; } }
        public string TrackCode { get { return _trackCode; } }
        public int RaceNumber { get { return _raceNumber; } }
        public int Raceid { get { return _raceid; } }
        public string Date { get { return _date; } }
        public double Distance { get { return _distance; } }
        public string Surface { get { return _surface; } }
        public string RaceClass { get { return _abbrRaceClass; } }
        public string Jockey { get { return _abbrJockeyName; } }
        public string TrainerName { get { return _abbrTrainerName; } }
        public double Odds { get { return _odds; } }
        public int Weight { get { return _weight; } }
        public int OfficialPosition { get { return _officialPosition; } }
        public int FinishPosition { get { return _finishPosition; } }
        public double WinnersTime { get { return _finalTime; } }
        public double FinishLengthsBehind 
        {
            get 
            { 
                return _finishLengthBehind; 
            } 
        }
        public double ActualTime
        {
            get
            {
                if (_officialPosition == 1)
                {
                    return _finalTime;
                }
                else
                {
                    return _finalTime + _finishLengthBehind * 0.2;
                }
            }
        }

        public double TotalMargin
        {
            get
            {
                return _totalMargin;
            }
            internal set
            {
                _totalMargin = value;
            }
        }

        public int GoldenFigure
        {
            get
            {
                return _goldenFigure;
            }
        }

        public int WinnersGoldenFigure
        {
            get
            {
                return _winnersGoldenFigure;
            }
        }
    }
}
