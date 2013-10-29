using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.PostPositionStatistics;

namespace Utilities
{
    static class UpdatePostPositions
    {
        private const string _sqlInsert = @"INSERT INTO [DB_28661_sipp].[dbo].[PPSTATS] ([TRACK_CODE],[SURFACE],[DISTANCE],[ABOUT_FLAG],[TRACK_CONDITION],[POST_POSITION],[TOTAL_STARTERS],[WIN_PERCENT],[IV],[W2W_PERCENTAGE]) VALUES ('{0}','{1}',{2},'{3}','{4}',{5},{6},{7},{8},{9})";

        static public void CreateFile()
        {
          
            int c = 0;
            foreach (var rti in RaceTracks.RaceTrackInfoCollection)
            {
                string trackCode = rti.TrackCode;

                foreach (var surface in rti.ListOfAvailableSurfaces)
                {
                    foreach (var distance in rti.ListOfAvailableDistancesPerSurface(surface))
                    {
                        foreach (var aboutFlag in rti.ListOfAvailableAboutFlagPerDistanceAndSurface(surface, distance))
                        {
                            
                            var pps = PostPositionStatistics.Make(trackCode, surface, aboutFlag, distance);

                            for (int i = 0; i < pps.Count; ++i)
                            {
                                foreach (var postPositionStatistic in pps[i])
                                {
                                    string trackCondition = pps[i].TrackCondition;
                                    int postPosition = postPositionStatistic.PostPosition;
                                    int total = postPositionStatistic.Starters;
                                    double winPercentage = postPositionStatistic.WinPercent;
                                    double iv = postPositionStatistic.IV;
                                    double w2w = postPositionStatistic.W2WWinPercent;

                                    Console.WriteLine(string.Format(_sqlInsert, trackCode, surface, distance, aboutFlag, trackCondition, postPosition, total, winPercentage, iv, w2w));
                                    Console.WriteLine("GO");
                                }
                            }
                            ++c;
                        }
                    }
                    
                }
            }
        }
    }
}
