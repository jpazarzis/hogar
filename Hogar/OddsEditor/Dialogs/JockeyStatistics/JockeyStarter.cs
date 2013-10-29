using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;
using Hogar;

namespace OddsEditor.Dialogs.JockeyStatistics
{
    class JockeyStarter
    {
        readonly int _raceID;
        readonly string _trackCode;
        readonly DateTime _date;
        readonly string _horseName;
        readonly string _trainer;
        readonly string _owner;
        readonly bool _wasTheFavorite;
        readonly double _odds;
        readonly double _winPayoff;
        readonly string _surface;
        readonly double _distanceInYards;
        readonly int _postPosition;
        readonly string _trackCondition;
        readonly int _firstCall;
        readonly int _secondCall;
        readonly int _finalCall;

        public JockeyStarter(DbReader dbr)
        {
            _raceID = dbr.GetValue<int>("RACE_ID");
            _trackCode = dbr.GetValue<string>("TRACK_CODE");
            _date = Utilities.MakeDateTime(dbr.GetValue<string>("RACING_DATE"));
             _horseName = dbr.GetValue<string>("HORSE_NAME");
             _trainer = dbr.GetValue<string>("ABBR_TRAINER_NAME");
             _owner = dbr.GetValue<string>("OWNER_NAME");
            _wasTheFavorite = (1 == dbr.GetValue<int>("FAVORITE_FLAG"));
            _odds = dbr.GetValue<double>("ODDS");
            _winPayoff = dbr.GetValue<double>("WIN_PAYOFF");
            _surface = dbr.GetValue<string>("SURFACE");
            _distanceInYards = dbr.GetValue<double>("DISTANCE");
            _postPosition = dbr.GetValue<int>("POST_POSITION");
            _trackCondition = dbr.GetValue<string>("TRACK_CONDITION");
            _firstCall = dbr.GetValue<int>("CALL_1_POSITION");
            _secondCall = dbr.GetValue<int>("CALL_2_POSITION");
            _finalCall = dbr.GetValue<int>("FINISH_POSITION");
        }


        public JockeyStarter(JockeyStarter other, string trainer, string trackCode)
        {
            _raceID = other._raceID;
            _trackCode = trackCode;
            _date = other._date;
            _horseName = other._horseName;
            _trainer = trainer;
            _owner = other._owner;
            _wasTheFavorite = other._wasTheFavorite;
            _odds = other._odds;
            _winPayoff = other._winPayoff;
            _surface = other._surface;
            _distanceInYards = other._distanceInYards;
            _postPosition = other._postPosition;
            _trackCondition = other._trackCondition;
            _firstCall = other._firstCall;
            _secondCall = other._secondCall;
            _finalCall = other._finalCall;
        }

        public int RaceId { get { return _raceID; } }
        public string TrackCode { get { return _trackCode; } }
        public DateTime Date { get { return _date; } }
        public string HorseName { get { return _horseName; } }
        public string Trainer { get { return _trainer; } }
        public string Owner { get { return _owner; } }
        public bool WasTheFavorite { get { return _wasTheFavorite; } }
        public double Odds { get { return _odds; } }
        public double WinPayoff { get { return _winPayoff; } }
        public string Surface { get { return _surface; } }
        public double DistanceInYards { get { return _distanceInYards; } }
        public int PostPosition { get { return _postPosition; } }
        public string TrackCondition { get { return _trackCondition; } }
        public int FirstCall { get { return _firstCall; } }
        public int SecondCall { get { return _secondCall; } }
        public int FinalCall { get { return _finalCall; } }
        public bool IsSprint { get { return _distanceInYards <1700; } }
        public bool IsRoute { get { return _distanceInYards >= 1700; } }

    }
}
