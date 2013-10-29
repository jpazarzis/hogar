using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    public partial class CynthiaParsForm : Form
    {
        readonly string _trackCode;
        readonly int _distance;
        readonly SippPastPerformance _pp;
        readonly int _avgDailyVariant = 0;
        readonly int _dailyVariant = 0;
        readonly double _adjustedWinersTime = 0.0;
        readonly double _adjustedThisHorseTime = 0.0;

        public CynthiaParsForm(string trackCode, int distance, SippPastPerformance pp)
        {
            _trackCode = trackCode;
            _distance = distance;
            _pp = pp;
            _avgDailyVariant = GetAverageDailyVariantFromDb();
            _dailyVariant = _pp.TrackVariant;
            //_adjustedWinersTime = _pp.FinalTime - DiffInSeconds;
            //_adjustedThisHorseTime = _pp.ThisHorseFinalTime - DiffInSeconds;
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
                SippPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;
                string surfaceClause = "";
                switch (st)
                {
                    case SippPastPerformance.SurfaceType.Dirt:
                        surfaceClause = @"Dirt";
                        break;
                    case SippPastPerformance.SurfaceType.Turf:
                        surfaceClause = @"Turf";
                        break;
                    case SippPastPerformance.SurfaceType.InnerTurf:
                        surfaceClause = @" Inner Turf";
                        break;
                    case SippPastPerformance.SurfaceType.InnerDirt:
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
            var dataAdapter = new SqlDataAdapter(SQLLoadAvgVariant, Sipp.SippDbUtilities.SqlConnection);
            var dataSet = new DataSet();
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
            //string s = string.Format("(RowWin:{0},RowThis:{1} AdjWin:{2} AdjThis:{3} )", SippExtentions.ConvertTimeToMMSSFifth(_pp.WinnersFinalTime), SippExtentions.ConvertTimeToMMSSFifth(_pp.ThisHorseFinalTime), SippExtentions.ConvertTimeToMMSSFifth(_adjustedWinersTime), SippExtentions.ConvertTimeToMMSSFifth(_adjustedThisHorseTime));
            Text = string.Format("{0} {1} {2} ", TrackInfo.GetFullName(_trackCode), SippExtentions.ConvertYardsToMilesOrFurlongs(_distance), SelectedSurface);
            _labelRaceTrack.Text = TrackInfo.GetFullName(_trackCode);
            _labelDistance.Text = SippExtentions.ConvertYardsToMilesOrFurlongs(_distance);
            _labelSurface.Text = SelectedSurface;
         
            
            _labelTrackVariant.Text = _dailyVariant.ToString();
            _labelAvgDailyVariant.Text = _avgDailyVariant.ToString();
       


            _tbFirstCall.Text = _pp.FirstCall;
            _tbSecondCall.Text = _pp.SecondCall;
            _tbThirdCall.Text = _pp.ThirdCall;
            _tbFinalTime.Text = _pp.FinalTime;


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
                SippPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;

                string surface = "";
                switch (st)
                {
                    case SippPastPerformance.SurfaceType.Dirt:
                        surface = "D";
                        break;
                    case SippPastPerformance.SurfaceType.Turf:
                        surface = "T";
                        break;
                    case SippPastPerformance.SurfaceType.InnerTurf:
                        surface = "I";
                        break;
                    case SippPastPerformance.SurfaceType.InnerDirt:
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
                string sprintOrRoute = _distance >= 220 * 8 ? "R" : "S";

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
                SippPastPerformance.SurfaceType st = _pp.SurfaceAndDistanceType;

                string surfaceClause = "";
                switch (st)
                {
                    case SippPastPerformance.SurfaceType.Dirt:
                        surfaceClause = @" AND SURFACE = 'D' ";
                        break;
                    case SippPastPerformance.SurfaceType.Turf:
                        surfaceClause = @" AND SURFACE = 'T' ";
                        break;
                    case SippPastPerformance.SurfaceType.InnerTurf:
                        surfaceClause = @" AND SURFACE = 'I' ";
                        break;
                    case SippPastPerformance.SurfaceType.InnerDirt:
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
                    aboutClause = " AND ABOUT_FLAG != 'A' ";
                }

                string sql = string.Format(@"SELECT 
                                                RTRIM(LTRIM(CLASS)) 'Class', 
	                                            FIRST_CALL ,
	                                            MID_CALL   ,
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
                var dataAdapter = new SqlDataAdapter(SQLLoadPars, Sipp.SippDbUtilities.SqlConnection);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                DataTable dt = dataSet.Tables[0];

                dt.Columns.Add("1st Call");
                dt.Columns.Add("2nd Call");
                dt.Columns.Add("Final");

                foreach (DataRow row in dt.Rows)
                {
                    row["1st Call"] = SippExtentions.ConvertTimeToMMSSFifth((double)row["FIRST_CALL"]);
                    row["2nd Call"] = SippExtentions.ConvertTimeToMMSSFifth((double)row["MID_CALL"]);
                    row["Final"] = SippExtentions.ConvertTimeToMMSSFifth((double)row["FINAL_CALL"]);
                }

                dt.Columns.Remove("FIRST_CALL");
                dt.Columns.Remove("MID_CALL");
                dt.Columns.Remove("FINAL_CALL");

                _grid.DataSource = dt;
                _grid.BorderStyle = BorderStyle.None;

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
