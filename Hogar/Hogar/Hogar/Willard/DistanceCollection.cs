using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Willard
{
    static class DistanceCollection
    {
        static List<Distance> _distance = new List<Distance>();

        static public Distance FindDistanceInfo(double distanceInYards, string surface)
        {
            Distance.TrackType trackType = Distance.TrackType.OuterTrack;

            if (surface.Trim()[0] == 'd' || surface.Trim()[0] == 't')
            {
                trackType = Distance.TrackType.InnerTrack;
            }


            Distance temp = new Distance(distanceInYards, trackType, Distance.FractionType.Third, Distance.FractionType.Third);
            foreach (Distance d in _distance)
            {

                if (Distance.AreEqual(temp, d))
                {
                    return d;
                }
            }

            return null;
        }

        static DistanceCollection()
        {
            _distance.Add(new Distance(1210, Distance.TrackType.InnerTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1320, Distance.TrackType.InnerTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1760, Distance.TrackType.InnerTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1830.4, Distance.TrackType.InnerTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1870, Distance.TrackType.InnerTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1980, Distance.TrackType.InnerTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(2090, Distance.TrackType.InnerTrack, Distance.FractionType.Second, Distance.FractionType.Third));

            _distance.Add(new Distance(1100, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1210, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1320, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1430, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1540, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1650, Distance.TrackType.OuterTrack, Distance.FractionType.First, Distance.FractionType.Second));
            _distance.Add(new Distance(1760, Distance.TrackType.OuterTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1830.4, Distance.TrackType.OuterTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1870, Distance.TrackType.OuterTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(1980, Distance.TrackType.OuterTrack, Distance.FractionType.Second, Distance.FractionType.Third));
            _distance.Add(new Distance(2090, Distance.TrackType.OuterTrack, Distance.FractionType.Second, Distance.FractionType.Third));
        }
    }
}
