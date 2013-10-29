using System;
using Hogar.DbTools;
using System.Linq;

namespace TrackVariantMaint
{
    public class StarterInfoCollection : DataBaseCollection<StarterInfo>
    {
        private const string _sql1 = @"select a.track_code, a.id, a.horse_name, a.Finish_position ,a.race_id, b.distance, b.surface, b.track_condition, a.racing_date,b.final_time,dbo.TV_CalculateTimeByBeatenLengths (distance, final_time, FINISH_LENGTHS_BEHIND) 'thisHorseTime',dbo.TV_ProjectTimeToDistance(a.track_code, b.surface, b.final_time, b.distance) 'projectedTime',dbo.TV_ProjectTimeToDistance(a.track_code, b.surface, dbo.TV_CalculateTimeByBeatenLengths (distance, final_time, FINISH_LENGTHS_BEHIND), b.distance) 'thisHorseProjectedTime' from race_starters a, race_description b where a.program_number != 'SCR' and finish_position >={0} and finish_position <={1} and b.race_id = a.race_id and b.track_code = '{2}' and surface  = '{3}' COLLATE SQL_Latin1_General_CP1_CS_AS and CONTAINS_VALID_TIME = 'Y' and LEFT(AGE_sex_restrictions,2) <> 'AO'  and LEFT(AGE_sex_restrictions,2) <> 'BO' order by a.horse_name, distance,a.racing_date,  a.finish_position";

        


        public enum LoadingMethod
        {
            VeryTight,
            Tight,
            Medium,
            Loose,
            VeryLoose
        }


        public StarterInfoCollection()
        {
            SelectedLoadingMethod = LoadingMethod.Tight;
        }

        static public string GetLoadingMethodName(LoadingMethod lm)
        {
            switch (lm)
            {
                case LoadingMethod.VeryTight:
                    return "Very Tight";
                case LoadingMethod.Tight:
                    return "Tight";
                case LoadingMethod.Medium:
                    return "Medium";
                case LoadingMethod.Loose:
                    return "Loose";
                case LoadingMethod.VeryLoose:
                    return "Very Loose";
            }

            return null;
        }

        public LoadingMethod SelectedLoadingMethod { get; set; }

        private static string GetSql(int minPos, int maxPos, string trackCode, string surface)
        {
            return string.Format(_sql1, minPos, maxPos, trackCode, surface);
        }

        public void Load(string trackCode, string surface)
        {
            this.Clear();
            
            switch (SelectedLoadingMethod)
            {
                case LoadingMethod.VeryTight:
                    this.Load(GetSql(1, 1, trackCode, surface));
                    this.Load(GetSql(2, 2, trackCode, surface));
                    this.Load(GetSql(3, 3, trackCode, surface));
                    this.Load(GetSql(4, 4, trackCode, surface));
                    break;
                case LoadingMethod.Tight:
                    this.Load(GetSql(1, 2, trackCode, surface));
                    this.Load(GetSql(2, 3, trackCode, surface));
                    this.Load(GetSql(3, 5, trackCode, surface));
                    
                    break;
                case LoadingMethod.Medium:
                    this.Load(GetSql(1, 3, trackCode, surface));
                    this.Load(GetSql(4, 5, trackCode, surface));
                    break;
                    
                case LoadingMethod.Loose:
                    this.Load(GetSql(1, 3, trackCode, surface));
                    this.Load(GetSql(4, 5, trackCode, surface));
                    this.Load(GetSql(6, 7, trackCode, surface));
                    break;
                    
                case LoadingMethod.VeryLoose:
                    this.Load(GetSql(1, 2, trackCode, surface));
                    this.Load(GetSql(3, 5, trackCode, surface));
                    this.Load(GetSql(6, 7, trackCode, surface));
                    break;
 
            }
         
        }

         
    }
}