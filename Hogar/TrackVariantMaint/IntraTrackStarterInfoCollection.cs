using Hogar.DbTools;

namespace TrackVariantMaint
{
    public class IntraTrackStarterInfoCollection : DataBaseCollection<IntraTrackStarterInfo>
    {
        private const string _sql1 = @"select 
	a.track_code ,
	c.track_desc,
	c.surface,
	a.horse_name,
	dbo.TV_ProjectTimeToDistance(a.track_code,b.surface, dbo.TV_CalculateTimeByBeatenLengths (distance, final_time, FINISH_LENGTHS_BEHIND), b.distance) + VARIANT 'ThisHorseProjectedTime'
from 
	race_starters a, race_description b , track_variant c
where 
	
a.program_number != 'SCR'
and finish_position >={0} and finish_position <= {1}
and b.race_id = a.race_id
and CONTAINS_VALID_TIME = 'Y'
and c.track_code = a.track_code and c.racing_date = a.racing_date and c.surface = b.surface COLLATE SQL_Latin1_General_CP1_CS_AS
order by a.horse_name, a.track_code";


        public void LoadFromDb()
        {
            Load(string.Format(_sql1, 1, 2));
            Load(string.Format(_sql1, 3, 4));
        }

    }
}