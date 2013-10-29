using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Cynthia;

namespace OddsEditor.Dialogs
{
    public partial class CompareRaceTracksForm : Form
    {
        List<double> _timeDiffDirtSprint = new List<double>();
        List<double> _timeDiffDirtRoute = new List<double>();
        List<double> _timeDiffTurfSprint = new List<double>();
        List<double> _timeDiffTurfRoute = new List<double>();    


        public CompareRaceTracksForm()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            try
            {
                LoadRaceTracks(_comboBoxTrack1);
                LoadRaceTracks(_comboBoxTrack2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadRaceTracks(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (RaceTrackInfo rti in RaceTracks.RaceTrackInfoCollection)
            {
                cb.Items.Add(rti);
            }
        }

        string GetTrackCodeFromComboBox(ComboBox cb)
        {
            if (null != cb.SelectedItem && cb.SelectedItem is RaceTrackInfo)
            {
                return ((RaceTrackInfo)cb.SelectedItem).TrackCode;
            }
            else
            {
                return "";
            }
        }

        private void OnCompare(object sender, EventArgs e)
        {
            string trackCode1 = GetTrackCodeFromComboBox(_comboBoxTrack1);
            string trackCode2 = GetTrackCodeFromComboBox(_comboBoxTrack2);

            _timeDiffDirtSprint.Clear();
            _timeDiffDirtRoute.Clear();
            _timeDiffTurfSprint.Clear();
            _timeDiffTurfRoute.Clear();

            List<CynthiaPar> par1 = CynthiaPar.LoadParsForRaceTrack(trackCode1);
            List<CynthiaPar> par2 = CynthiaPar.LoadParsForRaceTrack(trackCode2);

            _grid.Columns.Clear();
            _grid.Columns.Add("DIST", "DIST");
            _grid.Columns.Add("SURF", "SURF");
            _grid.Columns.Add("ABOUT", "ABOUT");
            _grid.Columns.Add("CLASS", "CLASS");

            _grid.Columns.Add("FIRST_CALL_1", "FIRST_CALL_1");
            _grid.Columns.Add("SECOND_CALL_1", "SECOND_CALL_1");
            _grid.Columns.Add("FINAL_CALL_1", "FINAL_CALL_1");

            _grid.Columns.Add("FIRST_CALL_2", "FIRST_CALL_2");
            _grid.Columns.Add("SECOND_CALL_2", "SECOND_CALL_2");
            _grid.Columns.Add("FINAL_CALL_2", "FINAL_CALL_2");

            _grid.Columns.Add("FIRST_CALL_DIFF", "FIRST_CALL_DIFF");
            _grid.Columns.Add("SECOND_CALL_DIFF", "SECOND_CALL_DIFF");
            _grid.Columns.Add("FINAL_CALL_DIFF", "FINAL_CALL_DIFF");
            _grid.Columns.Add("DIFF_PER_FURLONG", "DIFF_PER_FURLONG");

            _grid.Columns["FIRST_CALL_1"].Visible = false;
            _grid.Columns["SECOND_CALL_1"].Visible = false;

            _grid.Columns["FIRST_CALL_2"].Visible = false;
            _grid.Columns["SECOND_CALL_2"].Visible = false;

            _grid.Columns["FIRST_CALL_DIFF"].Visible = false;
            _grid.Columns["SECOND_CALL_DIFF"].Visible = false;
            

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            foreach (CynthiaPar p1 in par1)
            {
                CynthiaPar p2 = FindMatch(p1, par2);

                if (null != p2)
                {
                    AddToGrid(p1, p2);
                }
            }

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateAggregateTimeDiffs();

        }

        private void UpdateAggregateTimeDiffs()
        {
            _gridAggregate.Columns.Clear();
            _gridAggregate.Columns.Add("SURFACE", "SURFACE");
            _gridAggregate.Columns.Add("DISTANCE", "DISTANCE");
            _gridAggregate.Columns.Add("TIME_DIFF_PER_FURLONG", "TIME_DIFF_PER_FURLONG");

            _gridAggregate.Rows.Add(4);

            _gridAggregate.Rows[0].Cells[0].Value = "DIRT";
            _gridAggregate.Rows[0].Cells[1].Value = "SPRINT";
            _gridAggregate.Rows[0].Cells[2].Value = FindAvgTime(_timeDiffDirtSprint);

            _gridAggregate.Rows[1].Cells[0].Value = "DIRT";
            _gridAggregate.Rows[1].Cells[1].Value = "ROUTE";
            _gridAggregate.Rows[1].Cells[2].Value = FindAvgTime(_timeDiffDirtRoute);


            _gridAggregate.Rows[2].Cells[0].Value = "TURF";
            _gridAggregate.Rows[2].Cells[1].Value = "SPRINT";
            _gridAggregate.Rows[2].Cells[2].Value = FindAvgTime(_timeDiffTurfSprint);

            _gridAggregate.Rows[3].Cells[0].Value = "TURF";
            _gridAggregate.Rows[3].Cells[1].Value = "ROUTE";
            _gridAggregate.Rows[3].Cells[2].Value = FindAvgTime(_timeDiffTurfRoute);
        }

        private double FindAvgTime(List<double> timeDiff)
        {
            if (timeDiff.Count == 0)
            {
                return 0.0;
            }

            double sum = 0.0;
            foreach (double t in timeDiff)
            {
                sum += t;
            }
            return sum / timeDiff.Count;
        }

        private void AddToGrid(CynthiaPar p1, CynthiaPar p2)
        {
            int rowIndex = _grid.Rows.Add();
            DataGridViewCellCollection cells = _grid.Rows[rowIndex].Cells;
            
            cells[0].Value = p1.Distance;
            cells[1].Value = p1.Surface;
            cells[2].Value = p1.AboutFlag;
            cells[3].Value = p1.CynthiaClassification;

            cells[4].Value = Utilities.ConvertTimeToMMSSFifth(p1.FirstCall);
            cells[5].Value = Utilities.ConvertTimeToMMSSFifth(p1.MidCall);
            cells[6].Value = Utilities.ConvertTimeToMMSSFifth(p1.FinalCall);

            cells[7].Value = Utilities.ConvertTimeToMMSSFifth( p2.FirstCall);
            cells[8].Value = Utilities.ConvertTimeToMMSSFifth(p2.MidCall);
            cells[9].Value = Utilities.ConvertTimeToMMSSFifth(p2.FinalCall);

            double firstCallDiff = p1.FirstCall - p2.FirstCall;
            double secondCallDiff = p1.MidCall - p2.MidCall;
            double finalCallDiff = p1.FinalCall - p2.FinalCall;

            cells[10].Value = string.Format("{0:0.000}", finalCallDiff);
            cells[11].Value = string.Format("{0:0.000}", secondCallDiff);
            cells[12].Value = string.Format("{0:0.000}", finalCallDiff);


            double timeDiffPerFurlong = finalCallDiff / p1.DistanceInFurlongs;
            cells[13].Value = string.Format("{0:0.000}", timeDiffPerFurlong);

            if (p1.Surface == "T")
            {
                if (p1.IsRoute)
                {
                    _timeDiffTurfRoute.Add(timeDiffPerFurlong);
                }
                else
                {
                    _timeDiffTurfSprint.Add(timeDiffPerFurlong);
                }
            }
            else
            {
                if (p1.IsRoute)
                {
                    _timeDiffDirtRoute.Add(timeDiffPerFurlong);
                }
                else
                {
                    _timeDiffDirtSprint.Add(timeDiffPerFurlong);
                }
            }

        }

        private CynthiaPar FindMatch(CynthiaPar p1, List<CynthiaPar> par2)
        {
            foreach (CynthiaPar p2 in par2)
            {
                if (p1.Distance == p2.Distance &&
                   p1.Surface == p2.Surface &&
                   p1.AboutFlag == p2.AboutFlag &&
                   p1.CynthiaClassification == p2.CynthiaClassification)
                {
                    return p2;
                }
            }

            return null;
        }
    }
}
