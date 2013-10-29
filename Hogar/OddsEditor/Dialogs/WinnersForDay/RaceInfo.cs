using System.Collections.Generic;

namespace OddsEditor.Dialogs.WinnersForDay
{
    class RaceInfo
    {
        public int RaceId
        {
            get;
            set;
        }
        public double Distance
        {
            get;
            set;
        }
        public string Surface
        {
            get;
            set;
        }
        public string AboutFlag
        {
            get;
            set;
        }
        public string TrackCode
        {
            get;
            set;
        }

        public string TrackCondition
        {
            get;
            set;
        }

        public List<string> MatchingHorsesFromTodaysRace
        {
            get;
            set;
        }
    }
}