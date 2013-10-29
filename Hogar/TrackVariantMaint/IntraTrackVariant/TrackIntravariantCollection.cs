using Hogar.DbTools;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    class TrackIntravariantCollection : DataBaseCollection<TrackIntravariant>
    {
        const string SQL_LOAD_STD_ADJ = @"select track_desc, intra_variant from track_intra_variant";

        public TrackIntravariantCollection()
        {
            Reload();
        }

        private void Reload()
        {
            Load(SQL_LOAD_STD_ADJ);
        }
    }
}