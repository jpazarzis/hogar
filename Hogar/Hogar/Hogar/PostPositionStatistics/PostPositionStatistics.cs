using System.Collections.Generic;

namespace Hogar.PostPositionStatistics
{
    sealed public class PostPositionStatistics : List<PPStatsPerTrackCondition>
    {
        static readonly List<string> _trackConditionsForTurf = new List<string>() { "", "fm", "gd", "sf", "yl" };
        static readonly List<string> _trackConditionsForDirt = new List<string>() { "", "ft", "gd", "my", "sy" };


        static readonly Dictionary<string, PostPositionStatistics> _stats = new Dictionary<string, PostPositionStatistics>();


        static public PostPositionStatistics Make(string trackCode, string surface, string aboutDistanceFlag, double distance)
        {
            string key = MakeKey(trackCode, surface, aboutDistanceFlag, distance);

            if (!_stats.ContainsKey(key))
            {
                _stats.Add(key, new PostPositionStatistics(trackCode, surface, aboutDistanceFlag, distance));
            }
                
            return _stats[key];
        }

        static string MakeKey(string trackCode, string surface, string aboutDistanceFlag, double distance)
        {
            return string.Format("{0}{1}{2}{3}",trackCode.Trim(),surface.Trim(),aboutDistanceFlag.Trim(),(int)distance);
        }



        private PostPositionStatistics(string trackCode, string surface, string aboutDistanceFlag, double distance)
        {
            if (surface.ToUpper().Trim() == "T")
            {
                _trackConditionsForTurf.ForEach(tc => Add(PPStatsPerTrackCondition.Make(trackCode, surface, aboutDistanceFlag, tc, distance)));
            }
            else
            {
                _trackConditionsForDirt.ForEach(tc => Add(PPStatsPerTrackCondition.Make(trackCode, surface, aboutDistanceFlag, tc, distance)));
            }
        }
    }
}