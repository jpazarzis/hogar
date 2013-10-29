using System;
using System.Collections.Generic;
using System.Linq;
using Hogar.DbTools;
using TrackVariantMaint.IntraTrackVariantMaint;

namespace TrackVariantMaint.AnalysisPerTrack
{
   public  class WinnersTimeCollection : DataBaseCollection<WinnersTime>
    {
        const string SQL_LOAD = @"select  
	c.track_desc,
	dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, finish_lengths_behind, distance) 'golden_figure'
from 
	race_starters a, race_description b , track_variant c, track_intra_variant d
where 
	
	b.race_id = a.race_id
and CONTAINS_VALID_TIME = 'Y'
and c.track_code = a.track_code 
and c.racing_date = a.racing_date 
and c.surface = b.surface COLLATE SQL_Latin1_General_CP1_CS_AS
and d.track_desc = c.track_desc
and a.finish_position = 1";


        public List<Partition> Partitions { get; private set;}

        public WinnersTimeCollection()
        {
            Reload();
        }

        private void Reload()
        {
            Load(SQL_LOAD);
            UpdatePartitions();
        }

       private Dictionary<string,int> TotalRacesPerTrack
       {
           get
           {
               var totalNumberOfRacesPerTrack = new Dictionary<string, int>();

               foreach (var wt in this)
               {
                   string key = wt.TrackDesc;

                   if(totalNumberOfRacesPerTrack.ContainsKey(key))
                   {
                       ++totalNumberOfRacesPerTrack[key];
                   }
                   else
                   {
                       totalNumberOfRacesPerTrack.Add(key,1);
                   }
               }

               return totalNumberOfRacesPerTrack;
           }
       }

        private void UpdatePartitions()
        {
            CreatePartitions();
            
            foreach (var wt in this)
            {
                foreach (var partition in Partitions)
                {
                    if (partition.Update(wt))
                        break;
                }
            }

            Dictionary<string, int> trt = TotalRacesPerTrack;

            Partitions.ForEach(p => p.UpdatePercentage(trt));
        }

       

       private void CreatePartitions()
        {
            Partitions = new List<Partition>();

            double minFigure = this.Min(wt => wt.GoldenFigure);
            double maxFigure = this.Max(wt => wt.GoldenFigure);
            double step = (maxFigure - minFigure)/10.0;
            
            for(double from = minFigure; from < maxFigure; from += step)
            {
                Partitions.Add(new Partition(from, from + step));
            }
        }
    }
}