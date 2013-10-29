using Hogar.DbTools;

namespace TrackVariantMaint.IntraTrackVariantMaint
{


    class StandardAdjustmentCollection : DataBaseCollection<StandardAdjustment>
    {
        const string SQL_LOAD_STD_ADJ = @"select TRACK_DESC, POINTS_FASTER_THAN_AVG from TRACK_STANDARD_ADJUSTMENTS";
    
        public StandardAdjustmentCollection()
        {
            Reload();
        }

        private void Reload()
        {
            Load(SQL_LOAD_STD_ADJ);
        }
    }
}