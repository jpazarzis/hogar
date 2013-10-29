using System.Collections.Generic;
using Hogar.DbTools;
using System.Linq;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    class AvgGoldenFigureCollection : DataBaseCollection<AvgGoldenFigure>
    {


        const string SQL_DELETE_VARIANT = @"DELETE TRACK_INTRA_VARIANT ";

        const string SQL_INSERT_VARIANT = @"INSERT INTO TRACK_INTRA_VARIANT (TRACK_DESC, TRACK_CODE,SURFACE,INTRA_VARIANT) VALUES ('{0}',  '{1}', '{2}',  {3})";

        private const string SQL_INSERT_STANDARD_ADJUSTMENTS = @"INSERT INTO TRACK_STANDARD_ADJUSTMENTS (TRACK_DESC,TRACK_CODE,SURFACE,POINTS_FASTER_THAN_AVG) VALUES ('{0}','{1}','{2}',{3})";

        private const string SQL_DELETE_STANDARD_ADJUSTMENTS = "delete TRACK_STANDARD_ADJUSTMENTS";

        private const string SQL_LOAD_AVERAGE_FIGURES =
            @"select 
	                c.track_desc,
	                avg(dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, finish_lengths_behind, distance)) 'avg_golden_figure'
                from 
	                race_starters a, race_description b , track_variant c
                where 
                	
	                b.race_id = a.race_id
                and CONTAINS_VALID_TIME = 'Y'
                and c.track_code = a.track_code 
                and c.racing_date = a.racing_date 
                and c.surface = b.surface COLLATE SQL_Latin1_General_CP1_CS_AS
                and a.finish_position = 1
                and bris_race_type like 'S%' 
                and age_sex_restrictions not like ('A%')
                and age_sex_restrictions like ('%N')
                and state_bred_flag != 's'
                group by c.track_desc
                order by 2";


        public AvgGoldenFigureCollection()
        {
            Reload();
        }

        public void Reload()
        {
            Load(SQL_LOAD_AVERAGE_FIGURES);
            LoadStandardAdjustments();
            LoadIntravariants();
        }

        public double AverageFigure
        {

            get
            {
                var figures = new List<double>();
                ForEach(fig => figures.Add(fig.Figure));
                return figures.Average();
            }   
        }

        public void SaveStandardAdjustments()
        {
            DbReader.ExecuteNonQuery(SQL_DELETE_STANDARD_ADJUSTMENTS);
            foreach (var f in this)
            {
                
                string sql = string.Format(SQL_INSERT_STANDARD_ADJUSTMENTS, f.TrackDesc, f.TrackCode, f.Surface, f.StandardAdjustment);
                DbReader.ExecuteNonQuery(sql);
            }
        }

        public void CalculateIntraTrackVariant()
        {

            double average = this.AverageFigure;
            DbReader.ExecuteNonQuery(SQL_DELETE_VARIANT);
            foreach (var fig in this)
            {
                fig.IntraVariant = average - fig.Figure + fig.StandardAdjustment;
                string sql = string.Format(SQL_INSERT_VARIANT, fig.TrackDesc, fig.TrackCode, fig.Surface, fig.IntraVariant);
                DbReader.ExecuteNonQuery(sql);
            }
        }

        private void LoadIntravariants()
        {
            ForEach(f => f.IntraVariant= 0);

            var intraVariantColletion = new TrackIntravariantCollection();

            foreach (var intraVariant in intraVariantColletion)
            {
                var avgFigure = Find(f => f.TrackDesc.Trim() == intraVariant.TrackDesc.Trim());

                if (null != avgFigure)
                {
                    avgFigure.IntraVariant = intraVariant.Intravariant;
                }
            }
        }

        private void LoadStandardAdjustments()
        {
            ForEach(f=>f.StandardAdjustment = 0);

            var adjColletion = new StandardAdjustmentCollection();

            foreach (var adj in adjColletion)
            {
                var avgFigure = Find(f => f.TrackDesc.Trim() == adj.TrackDesc.Trim());

                if (null != avgFigure)
                {
                    avgFigure.StandardAdjustment = adj.PointsFasterThanAverage;
                }
                    
            }
        }
    }
}