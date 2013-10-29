using Hogar.DbTools;

namespace TrackVariantMaint
{
    public class IntraTrackStarterInfo: IDbPopulatable
    {
        public string TrackDesc { get; private set; }
        public string Surface { get; private set; }
        public string TrackCode { get; private set; }
        public string HorseName { get; private set; }
        public double ProjectedTime { get; private set; }

        public void Populate(DbReader dbr)
        {

            TrackDesc = dbr.GetValue<string>("track_desc");
            Surface = dbr.GetValue<string>("surface");
            HorseName = dbr.GetValue<string>("horse_name");
            TrackCode = dbr.GetValue<string>("track_code");
            ProjectedTime = dbr.GetValue<double>("ThisHorseProjectedTime");
        }

    }
}