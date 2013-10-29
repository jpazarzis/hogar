using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;

namespace Hogar.PostPositionStatistics
{
    sealed public class PPStatsPerTrackCondition : DataBaseCollection<PostPositionStatistic>
    {
        public string TrackCode { get; private set; }
        public string Surface { get; private set; }
        public string AboutDistanceFlag { get; private set; }
        public string TrackCondition { get; private set; }
        public double Distance { get; private set; }


        const string SQL_LOAD = @"exec GetPostPositionStats '{0}', '{1}', '{2}', '{3}', {4}";

        static internal PPStatsPerTrackCondition Make(string trackCode, string surface, string aboutDistanceFlag, string trackCondition, double distance)
        {
            return new PPStatsPerTrackCondition(trackCode, surface, aboutDistanceFlag, trackCondition, distance);
        }

        private PPStatsPerTrackCondition(string trackCode, string surface, string aboutDistanceFlag, string trackCondition, double distance)
        {
            TrackCode = trackCode.Trim();
            Surface = surface.Trim();
            AboutDistanceFlag = aboutDistanceFlag.Trim();
            TrackCondition = trackCondition.Trim();
            Distance = distance;

            LoadFromDb();
        }

        private void LoadFromDb()
        {
            Load(string.Format(SQL_LOAD, TrackCode, Surface, AboutDistanceFlag, TrackCondition, Distance));
        }
    }
}
