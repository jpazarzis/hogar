using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using Hogar.RaceChart;
using OddsEditor.Dialogs;

namespace OddsEditor.MyComponents
{
    public partial class ShortRaceChartControl : UserControl
    {
        BrisPastPerformance _pp;
        Font _hyperlinkFont = null;

        public ShortRaceChartControl()
        {
            InitializeComponent();
        }
        
        private void SetCellStyleToHyperlink(int column, int rowIndex)
        {
            _grid[column, rowIndex].Style.Font = _hyperlinkFont;
            _grid[column, rowIndex].Style.ForeColor = Color.Blue;
            _grid[column, rowIndex].Style.SelectionForeColor = _grid[column, rowIndex].Style.ForeColor;
        }

        public void Bind(BrisPastPerformance pp)
        {

            string trackCode = RaceTracks.GetNameFromTrackCode(pp.TrackCode);

            string raceInfo = string.Format("Race# {0} {1} {2}", pp.RaceNumber, trackCode, pp.DateAsString);

            _labelRaceInfo.Text = raceInfo;
            _hyperlinkFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);

            _pp = pp;
            RaceChart rc = new RaceChart(pp);
            _grid.Columns.Clear();
            _grid.Columns.Add("PROGRAM_NUMBER", "PROGRAM_NUMBER");
            _grid.Columns.Add("ODDS", "ODDS");
            _grid.Columns.Add("HORSE_NAME", "HORSE_NAME");

            Race r = _pp.Parent.CorrespondingHorse.Parent;
            foreach (RaceChartLine rcl in rc.Results)
            {
                int row = _grid.Rows.Add();
                _grid[2, row].Value = rcl.HorseName;
                SetCellStyleToHyperlink(2, row);
                Color backColor = Color.White;
                if (r.ContainsHorse(rcl.HorseName))
                {
                    backColor = Color.LightPink;
                    string horseNumber = r.GetProgramNumberFromHorse(rcl.HorseName);
                    if (horseNumber.Length > 0)
                    {
                        Horse h = r.GetHorseByProgramNumber(horseNumber);
                        _grid[0, row].Value = horseNumber;
                        _grid[1, row].Value = string.Format("{0:0.00}",h.RealTimeOdds);
                    }
                }
                _grid.Rows[row].DefaultCellStyle.BackColor = backColor;
                _grid.Rows[row].DefaultCellStyle.SelectionBackColor = backColor;

                _grid.Rows[row].DefaultCellStyle.ForeColor = Color.Black;
                _grid.Rows[row].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _labelRaceInfo.Text = "";
        }

        private void OnGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string horseName = _grid[2, e.RowIndex].Value.ToString();
                    ShowRacesByHorseForm f = new ShowRacesByHorseForm(horseName);
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
