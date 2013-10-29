using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sipp.PostPositionStatistics
{
    public class PostPositionStatistic : SippIDbPopulatable
    {
        public int PostPosition { get; internal set; }
        public int TotalStarters { get; internal set; }
        public double WinPercent { get; internal set; }
        public double IV { get; internal set; }
        public double W2WWinPercent { get; internal set; }

        public void Populate(SippDbReader dbr)
        {
            PostPosition = dbr.GetValue<int>("POST_POSITION");
            TotalStarters = dbr.GetValue<int>("TOTAL_STARTERS");
            WinPercent = dbr.GetValue<double>("WIN_PERCENT");
            IV = dbr.GetValue<double>("IV");
            W2WWinPercent = dbr.GetValue<double>("W2W_PERCENTAGE");
        }
    }


 
    public class PostPositionStatistics : SippDataBaseCollection<PostPositionStatistic>
    {
        const string _sqlLoader = @"Select POST_POSITION, TOTAL_STARTERS, WIN_PERCENT, IV, W2W_PERCENTAGE
                                            FROM PPSTATS
                                            WHERE
                                            TRACK_CODE = '{0}' AND
                                            SURFACE = '{1}' COLLATE SQL_Latin1_General_CP1_CS_AS AND
                                            ABOUT_FLAG = '{2}' AND
                                            DISTANCE = {3} AND TRACK_CONDITION = '{4}' ORDER BY POST_POSITION";

        private const string _sqlLoadAvailableTrackConditions = @"select distinct(TRACK_CONDITION) AS 'TRACK_COND' from PPSTATS 
WHERE TRACK_CODE = '{0}' AND
SURFACE = '{1}' COLLATE SQL_Latin1_General_CP1_CS_AS AND
ABOUT_FLAG = '{2}' AND
DISTANCE = {3}
";


        public string TrackCode { get; private set; }
        public string Surface { get; private set; }
        public string TrackCondition { get; private set; }
        public double Distance { get; private set; }
        public bool AboutDistanceFlag { get; private set; }


        static private List<string> GetAvailableTrackConditions(string trackCode, string surface, double distance, bool aboutDistanceFlag)
        {
            string adf = aboutDistanceFlag ? "A" : "";
            var l = new List<string>();
            using (var dbr = new SippDbReader())
            {
                string sql = string.Format(_sqlLoadAvailableTrackConditions, trackCode, surface, adf, distance);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        l.Add(dbr.GetValue<string>("TRACK_COND"));
                    }
                }
            }
            return l;
        }


        static public List<PostPositionStatistics> LoadPPStats(string trackCode, string surface ,double distance, bool aboutDistanceFlag)
        {
            var list = new List<PostPositionStatistics>();

            foreach (var trackCondition in GetAvailableTrackConditions(trackCode, surface, distance, aboutDistanceFlag))
            {
                list.Add(Make(trackCode, surface ,trackCondition,distance, aboutDistanceFlag));    
            }

            return list;
        }

        static private PostPositionStatistics Make(string trackCode, string surface ,string trackCondition,double distance, bool aboutDistanceFlag)
        {
            var pps = new PostPositionStatistics
                          {
                              TrackCode = trackCode, 
                              Surface = surface,
                              TrackCondition = trackCondition, 
                              Distance = distance, 
                              AboutDistanceFlag = aboutDistanceFlag
                          };

            string adf = pps.AboutDistanceFlag ? "A" : "";

            pps.Load(string.Format(_sqlLoader, pps.TrackCode.Trim(), pps.Surface.Trim(), adf, (int)pps.Distance, pps.TrackCondition.Trim()));

            return pps;
        }


        private PostPositionStatistics()
        {
            
        }
    }
}
