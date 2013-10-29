using Hogar.DbTools;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    class StandardAdjustment : IDbPopulatable
    {
        public string TrackDesc { get; set; }

        public double PointsFasterThanAverage { get; set; }

        public void Populate(DbReader dbr)
        {

            TrackDesc = dbr.GetValue<string>("track_desc");
            PointsFasterThanAverage = dbr.GetValue<double>("POINTS_FASTER_THAN_AVG");
        }
    }
}