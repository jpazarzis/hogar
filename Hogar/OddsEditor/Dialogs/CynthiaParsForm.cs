using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar;
using Hogar.BrisPastPerformances;

namespace OddsEditor.Dialogs
{
    public partial class CynthiaParsForm : Form
    {
        readonly string _trackCode;
        readonly int _distance;
        readonly BrisPastPerformance _pp;
        readonly int _avgDailyVariant = 0;
        readonly int _dailyVariant = 0;
        readonly double _adjustedWinersTime = 0.0;
        readonly double _adjustedThisHorseTime = 0.0;

        public CynthiaParsForm(string trackCode, int distance, BrisPastPerformance pp)
        {
            _trackCode = trackCode;
            _distance = distance;
            _pp = pp;
            _avgDailyVariant = GetAverageDailyVariantFromDb();
            _dailyVariant = _pp.TrackVariant;
            _adjustedWinersTime = _pp.WinnersFinalTime - DiffInSeconds;
            _adjustedThisHorseTime = _pp.ThisHorseFinalTime - DiffInSeconds;
            InitializeComponent();
        }

        string CynthiasAbrForTrackCode(string trackCode)
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

        string SelectedSurface
        {
            get
            {
                BrisPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;
                string surfaceClause = "";
                switch (st)
                {
                    case BrisPastPerformance.SurfaceType.Dirt:
                        surfaceClause = @"Dirt";
                        break;
                    case BrisPastPerformance.SurfaceType.Turf:
                        surfaceClause = @"Turf";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerTurf:
                        surfaceClause = @" Inner Turf";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerDirt:
                        surfaceClause = @"Inner Dirt";
                        break;
                    default:
                        break;

                }

                string aboutClause = "";

                if (_pp.AboutDistanceFlag)
                {
                    aboutClause = "(about)";
                }

                return aboutClause + " " + surfaceClause;

            }
        }

        int GetAverageDailyVariantFromDb()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLLoadAvgVariant, Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            int var = 0;
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                var = (int)dr["AVERAGE_VARIANT"];
            }
            return var;
        }


        int VariantDiff
        {
            get
            {
                return _dailyVariant - _avgDailyVariant;
            }
        }

        double DiffInSeconds
        {
            get
            {
                return (double)VariantDiff / 8.0;
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            string s = string.Format("(RowWin:{0},RowThis:{1} AdjWin:{2} AdjThis:{3} )", Utilities.ConvertTimeToMMSSFifth(_pp.WinnersFinalTime), Utilities.ConvertTimeToMMSSFifth(_pp.ThisHorseFinalTime), Utilities.ConvertTimeToMMSSFifth(_adjustedWinersTime), Utilities.ConvertTimeToMMSSFifth(_adjustedThisHorseTime));
            Text = string.Format("Cynthia Pars For {0} {1} {2} {3}", RaceTracks.GetNameFromTrackCode(_trackCode), Utilities.ConvertYardsToMilesOrFurlongs(_distance), SelectedSurface,s);
            _labelRaceTrack.Text = RaceTracks.GetNameFromTrackCode(_trackCode);
            _labelDistance.Text = Utilities.ConvertYardsToMilesOrFurlongs(_distance);
            _labelSurface.Text = SelectedSurface;
            _labelHorseName.Text = _pp.Parent.Name ;
            _labelDate.Text = _pp.Date.ToString();
            _labelRaceNumber.Text = _pp.RaceNumber;
            _labelTrackVariant.Text = _dailyVariant.ToString();
            _labelAvgDailyVariant.Text = _avgDailyVariant.ToString();
            _labelRaceClassification.Text = _pp.RaceClassification;
            _fractionTimesCtrl.BindPastPerformance(_pp, DiffInSeconds);
            LoadGrid();
            if (DiffInSeconds > 0.0)
            {
                _labelFasterOrSlower.Text = "Slower By";
                _labelFasterOrSlowerBy.Text = string.Format("{0:0.00}sec", DiffInSeconds);
            }
            else if (DiffInSeconds < 0.0)
            {
                _labelFasterOrSlower.Text = "Faster By";
                _labelFasterOrSlowerBy.Text = string.Format("{0:0.00}sec", DiffInSeconds * (-1.0));
            }
            else
            {
                _labelFasterOrSlower.Text = "Neutral";
                _labelFasterOrSlowerBy.Text = "";
            }
        }

        string SQLLoadAvgVariant
        {
            get
            {
                BrisPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;

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

                if (_pp.AboutDistanceFlag)
                {
                    aboutFlag = "A";
                }
                else
                {
                    aboutFlag = "";
                }
                string sprintOrRoute = _distance >= Utilities.YARDS_IN_A_FURLONG * 8 ? "R" : "S";

                string trackCondition = _pp.TrackCondition.Trim();

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
                                    CynthiasAbrForTrackCode(_trackCode),
                                     surface,
                                     sprintOrRoute,
                                     aboutFlag,
                                     trackCondition);

                return sql;
            }
        }

        string SQLLoadPars
        {
            get
            {
                BrisPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;

                string surfaceClause = "";
                switch (st)
                {
                    case BrisPastPerformance.SurfaceType.Dirt:
                        surfaceClause = @" AND SURFACE = 'D' ";
                        break;
                    case BrisPastPerformance.SurfaceType.Turf:
                        surfaceClause = @" AND SURFACE = 'T' ";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerTurf:
                        surfaceClause = @" AND SURFACE = 'I' ";
                        break;
                    case BrisPastPerformance.SurfaceType.InnerDirt:
                        surfaceClause = @" AND SURFACE = 'N' ";
                        break;
                    default:
                        break;

                }

                string aboutClause = "";

                if (_pp.AboutDistanceFlag)
                {
                    aboutClause = " AND ABOUT_FLAG = 'A' ";
                }
                else
                {
                    aboutClause = " AND ABOUT_FLAG = 'N' ";
                }

                string sql = string.Format(@"SELECT 
	                                            CLASS,
	                                            FIRST_CALL,
	                                            MID_CALL,
	                                            FINAL_CALL
                                            FROM 
	                                            CYNTHIA_PARS 
                                            WHERE 
	                                            TRACK_CODE = '{0}' 
	                                            AND DISTANCE = {1} ",
                                    CynthiasAbrForTrackCode(_trackCode),
                                     _distance);
                sql += surfaceClause;
                sql += aboutClause; 

                sql += " ORDER BY FINAL_CALL";

                return sql;
            }
        }

        void LoadGrid()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLLoadPars, Hogar.DbTools.DbUtilities.SqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                DataTable dt = dataSet.Tables[0];
                                
                dt.Columns.Add("FIRST_CALL_2");
                dt.Columns.Add("MID_CALL_2");
                dt.Columns.Add("FINAL_CALL_2");
                
                foreach (DataRow row in dt.Rows)
                {
                    row["FIRST_CALL_2"] = Utilities.ConvertTimeToMMSSFifth((double)row["FIRST_CALL"]);
                    row["MID_CALL_2"] = Utilities.ConvertTimeToMMSSFifth((double)row["MID_CALL"]);
                    row["FINAL_CALL_2"] = Utilities.ConvertTimeToMMSSFifth((double)row["FINAL_CALL"]);

                    double finalTime = (double)row["FINAL_CALL"];

                }
                
                dt.Columns.Remove("FIRST_CALL");
                dt.Columns.Remove("MID_CALL");
                dt.Columns.Remove("FINAL_CALL");
                
                _grid.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void _grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
