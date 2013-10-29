using Hogar.DbTools;

namespace TimeProjector
{
    public class AverageTimeCollection : DataBaseCollection<AverageTime>
    {
        private const string _sqlLoader = @"SELECT 
		track_code,		
		surface COLLATE SQL_Latin1_General_CP1_CS_AS 'surface',
		AVG(FINAL_TIME) 'FINAL_TIME' , 
		DISTANCE 'DISTANCE',  
		DISTANCE/AVG(FINAL_TIME) 'SPEED'  ,
		count(*) 'COUNTER'
	FROM 
		RACE_DESCRIPTION 
	WHERE CONTAINS_VALID_TIME = 'Y' 
	GROUP BY track_code,surface COLLATE SQL_Latin1_General_CP1_CS_AS,DISTANCE
	HAVING COUNT(*) > 10
	ORDER BY  track_code, surface COLLATE SQL_Latin1_General_CP1_CS_AS,DISTANCE";

        public void LoadFromDb()
        {
            this.Load(_sqlLoader);
        }
    }
}