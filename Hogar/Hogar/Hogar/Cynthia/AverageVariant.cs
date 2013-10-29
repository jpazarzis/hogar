using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hogar.BrisPastPerformances;
using Hogar.DbTools;
using Hogar;

namespace Hogar.Cynthia
{
    class AverageVariant
    {

        public static int AvgVariant(Hogar.BrisPastPerformances.Extended.BrisPastPerformance pp)
        {
            

            SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLLoadAvgVariant(pp), Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            int var = 0;
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                var = (int)dr["AVERAGE_VARIANT"];
            }
            return var;
        }

        private static string SQLLoadAvgVariant(Hogar.BrisPastPerformances.Extended.BrisPastPerformance pp)
        {

            Hogar.BrisPastPerformances.Extended.BrisPastPerformance.SurfaceType st = pp.SurfaceAndDistanceType;

                string surface = "";
                switch (st)
                {
                    case Hogar.BrisPastPerformances.Extended.BrisPastPerformance.SurfaceType.Dirt:
                        surface = "D";
                        break;
                    case Hogar.BrisPastPerformances.Extended.BrisPastPerformance.SurfaceType.Turf:
                        surface = "T";
                        break;
                    case Hogar.BrisPastPerformances.Extended.BrisPastPerformance.SurfaceType.InnerTurf:
                        surface = "I";
                        break;
                    case Hogar.BrisPastPerformances.Extended.BrisPastPerformance.SurfaceType.InnerDirt:
                        surface = "N";
                        break;
                    default:
                        surface = "X";
                        break;

                }

                string aboutFlag = "";

                if (pp.AboutDistanceFlag)
                {
                    aboutFlag = "A";
                }
                else
                {
                    aboutFlag = "";
                }

                string sprintOrRoute = pp.DistanceInYards >= Utilities.YARDS_IN_A_FURLONG * 8 ? "R" : "S";

                string trackCondition = pp.TrackCondition.Trim();

                if (trackCondition.ToUpper() == "SY")
                {
                    trackCondition = "sly";
                }
                else if (trackCondition.ToUpper() == "FT")
                {
                    trackCondition = "fst";
                }
                else if (trackCondition.ToUpper() == "TF")
                {
                    trackCondition = "gd";
                }

                string sql = string.Format(@"SELECT TRACK_CONDITION, AVERAGE_VARIANT
                                             FROM CYNTHIA_AVERAGE_VARIANTS
                                            WHERE 
	                                            TRACK_CODE = '{0}'
                                            AND SURFACE = '{1}'
                                            AND SPRINT_OR_ROUTE = '{2}'
                                            AND ABOUT_FLAG = '{3}' 
                                            AND TRACK_CONDITION = '{4}'",
                                    CynthiasAbrForTrackCode(pp.TrackCode),
                                     surface,
                                     sprintOrRoute,
                                     aboutFlag,
                                     trackCondition);

                return sql;
        }

        
        public static int AvgVariant(BrisPastPerformance pp)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLLoadAvgVariant(pp), Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            int var = 0;
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                var = (int)dr["AVERAGE_VARIANT"];
            }
            return var;
        }

        private static string SQLLoadAvgVariant(BrisPastPerformance pp)
        {
            
                BrisPastPerformance.SurfaceType st = pp.SurfaceAndDistanceType;

                string surface = "";
                switch (st)
                {
                    case BrisPastPerformance.SurfaceType.Dirt:
                        surface = "D";
                        break;
                    case BrisPastPerformance.SurfaceType.Turf:
                        surface = "T";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerTurf:
                        surface = "I";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerDirt:
                        surface = "N";
                        break;
                    default:
                        surface = "X";
                        break;

                }

                string aboutFlag = "";

                if (pp.AboutDistanceFlag)
                {
                    aboutFlag = "A";
                }
                else
                {
                    aboutFlag = "";
                }

                string sprintOrRoute = pp.DistanceInYards >= Utilities.YARDS_IN_A_FURLONG * 8 ? "R" : "S";

                string trackCondition = pp.TrackCondition.Trim();

                if (trackCondition.ToUpper() == "SY")
                {
                    trackCondition = "sly";
                }
                else if (trackCondition.ToUpper() == "FT")
                {
                    trackCondition = "fst";
                }
                else if (trackCondition.ToUpper() == "TF")
                {
                    trackCondition = "gd";
                }

                string sql = string.Format(@"SELECT TRACK_CONDITION, AVERAGE_VARIANT
                                             FROM CYNTHIA_AVERAGE_VARIANTS
                                            WHERE 
	                                            TRACK_CODE = '{0}'
                                            AND SURFACE = '{1}'
                                            AND SPRINT_OR_ROUTE = '{2}'
                                            AND ABOUT_FLAG = '{3}' 
                                            AND TRACK_CONDITION = '{4}'",
                                    CynthiasAbrForTrackCode(pp.TrackCode),
                                     surface,
                                     sprintOrRoute,
                                     aboutFlag,
                                     trackCondition);

                return sql;
        }
    
        static private string CynthiasAbrForTrackCode(string trackCode)
        {
            if (trackCode.ToUpper() == "OSA")
            {
                return "SA";
            }
            else
            {
                return trackCode;
            }
        }

    }
}

