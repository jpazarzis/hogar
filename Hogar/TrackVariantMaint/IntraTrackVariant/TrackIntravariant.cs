using Hogar.DbTools;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    class TrackIntravariant : IDbPopulatable
    {
        public string TrackDesc { get; set; }

        public double Intravariant { get; set; }

        public void Populate(DbReader dbr)
        {

            TrackDesc = dbr.GetValue<string>("track_desc");
            Intravariant = dbr.GetValue<double>("intra_variant");
        }
    }
}