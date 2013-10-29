using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hogar;
using NPlot;
using HogarControlLibrary;

namespace OddsEditor.Dialogs.JockeyStatistics
{
    public partial class JockeyStatisticsForm : Form
    {
        private readonly string _jockeyName;
        private readonly JockeyStatisticsCollection _originalStats;
        private string _selectedTrackCode = "ALL";
        private string _selectedTrainer = "ALL";

        private bool _needsToAssignDatesToPeriodSelector = true;

        private readonly Dictionary<string, TrainerTrackStats> _trainerTrackStats = new Dictionary<string, TrainerTrackStats>();

        public JockeyStatisticsForm(string jockeyName)
        {
            _jockeyName = jockeyName;
            _originalStats = new JockeyStatisticsCollection(_jockeyName);
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            this.Text = _jockeyName;
            _statsGrid.Columns.Add("Type", "Type");
            _statsGrid.Columns.Add("Starters", "Starters");
            _statsGrid.Columns.Add("Winners", "W");
            _statsGrid.Columns.Add("Percent", "%");
            _statsGrid.Columns.Add("W2W", "W2W");
            _statsGrid.Columns.Add("W2WPercent", "%");
            _statsGrid.Columns.Add("ROI", "ROI");
            UpdateTrainerTrackGrid();
            UpdateEkar();
        }

        private void UpdateEkar()
        {
            Color selectionBackColor = Color.Blue;
            Color selectionForeColor = Color.White;

            Color backColor = Color.LightCyan;
            Color foreColor = Color.Black;

            for (int col = 0; col < _trainerTrackGrid.Columns.Count; ++col)
            {
                _trainerTrackGrid.Columns[col].HeaderText = "";

                _trainerTrackGrid[col, 0].Style.BackColor = backColor;
                _trainerTrackGrid[col, 0].Style.SelectionBackColor = backColor;
                _trainerTrackGrid[col, 0].Style.ForeColor = foreColor;
                _trainerTrackGrid[col, 0].Style.SelectionForeColor = foreColor;

                if (null != _trainerTrackGrid[col, 0].Value)
                {
                    string t = _trainerTrackGrid[col, 0].Value.ToString().Trim().ToUpper();
                    if (t == _selectedTrackCode.Trim().ToUpper())
                    {
                        _trainerTrackGrid.Columns[col].HeaderText = "X";

                        _trainerTrackGrid[col, 0].Style.BackColor = selectionBackColor;
                        _trainerTrackGrid[col, 0].Style.SelectionBackColor = selectionBackColor;
                        _trainerTrackGrid[col, 0].Style.ForeColor = selectionForeColor;
                        _trainerTrackGrid[col, 0].Style.SelectionForeColor = selectionForeColor;
                    }
                }
            }

            for (int row = 0; row < _trainerTrackGrid.Rows.Count; ++row)
            {
                _trainerTrackGrid.Rows[row].HeaderCell.Value = "";
                _trainerTrackGrid[0, row].Style.BackColor = backColor;
                _trainerTrackGrid[0, row].Style.SelectionBackColor = backColor;
                _trainerTrackGrid[0, row].Style.ForeColor = foreColor;
                _trainerTrackGrid[0, row].Style.SelectionForeColor = foreColor;

                if (null != _trainerTrackGrid[0, row].Value)
                {
                    string t = _trainerTrackGrid[0, row].Value.ToString().Trim().ToUpper();
                    if (t == _selectedTrainer.Trim().ToUpper())
                    {
                        _trainerTrackGrid.Rows[row].HeaderCell.Value = "X";
                        _trainerTrackGrid[0, row].Style.BackColor = selectionBackColor;
                        _trainerTrackGrid[0, row].Style.SelectionBackColor = selectionBackColor;
                        _trainerTrackGrid[0, row].Style.ForeColor = selectionForeColor;
                        _trainerTrackGrid[0, row].Style.SelectionForeColor = selectionForeColor;
                    }
                }
            }

            IEnumerable<JockeyStarter> stats = _originalStats;

            if (_selectedTrainer.Trim().ToUpper() != "ALL")
            {
                stats = stats.Where(js => js.Trainer.ToUpper().Trim() == _selectedTrainer.Trim().ToUpper());
            }

            if (_selectedTrackCode.Trim().ToUpper() != "ALL")
            {
                stats = stats.Where(js => js.TrackCode.ToUpper().Trim() == _selectedTrackCode.Trim().ToUpper());
            }

            if(false == _needsToAssignDatesToPeriodSelector)
            {
                stats = stats.Where(js => js.Date >= _periodSelector.FromDate && js.Date <= _periodSelector.ToDate);
            }

            var s = from js in stats
                    orderby js.Date descending
                    select js;

            int maxEkar = 0;
            int currentEkar = 0;
            var ekarList = new List<int>();
            int starters = 0;
            int winners = 0;
            double roi = 0.0;
            double payoff = 0;
            double percent = 0;

            var period = new List<DateTime>();

            foreach (JockeyStarter js in s)
            {
                ++starters;
                if (js.FinalCall == 1)
                {
                    ekarList.Add(currentEkar);
                    currentEkar = 0;
                    ++winners;
                    payoff += js.WinPayoff;
                }
                else
                {
                    ++currentEkar;
                }
                if (currentEkar > maxEkar)
                {
                    maxEkar = currentEkar;
                }
                period.Add(js.Date);
            }

            ekarList.Add(currentEkar);

            roi = starters > 0 ? payoff/(2.0*starters) : 0;
            percent = starters > 0 ? (1.0*winners)/(1.0*starters) : 0;

            _labelEkar.Text = currentEkar.ToString();
            _labelMaxEkar.Text = maxEkar.ToString();
            double averageEkar = ekarList.Count > 0 ? ekarList.Average() : 0;
            _labelAvgEkar.Text = string.Format("{0:0}", averageEkar);

            var ekarDs = new DataSet();
            var avgDs = new DataSet();

            DataTable ekarDt = ekarDs.Tables.Add();
            DataTable avgDt = avgDs.Tables.Add();

            ekarDt.Columns.Add("Count", typeof (double));
            ekarDt.Columns.Add("Ekar", typeof (double));

            avgDt.Columns.Add("Count", typeof(double));
            avgDt.Columns.Add("AvEkar", typeof(double));

            
            for (int i = 0; i < ekarList.Count; ++i)
            {
                ekarDt.Rows.Add(i, ekarList[i]);
                avgDt.Rows.Add(i, averageEkar);
            }

            DataGridView gst = _gridStatsPerSelectedTrainer;
            gst.Columns.Clear();

            gst.Columns.Add("Jockey", "Jockey");
            gst.Columns.Add("Track", "Track");
            gst.Columns.Add("Trainer", "Trainer");
            gst.Columns.Add("Winners", "Winners");
            gst.Columns.Add("Starters", "Starters");
            gst.Columns.Add("Percent", "Percent");
            gst.Columns.Add("ROI", "ROI");

            int rowIndex = gst.Rows.Add();

            gst[0, rowIndex].Value = "Jockey";
            gst[1, rowIndex].Value = "Track";
            gst[2, rowIndex].Value = "Trainer";
            gst[3, rowIndex].Value = "Wins";
            gst[4, rowIndex].Value = "Strts";
            gst[5, rowIndex].Value = "%";
            gst[6, rowIndex].Value = "ROI";

            rowIndex = gst.Rows.Add();

            gst[0, rowIndex].Value = Utilities.CapitalizeOnlyFirstLetter(_jockeyName);
            gst[1, rowIndex].Value = _selectedTrackCode;
            gst[2, rowIndex].Value = Utilities.CapitalizeOnlyFirstLetter(_selectedTrainer);
            gst[3, rowIndex].Value = winners.ToString();
            gst[4, rowIndex].Value = starters.ToString();
            gst[5, rowIndex].Value = string.Format("{0:0}%", percent*100.0);
            gst[6, rowIndex].Value = string.Format("{0:0.00}", roi);

            gst.Rows[0].DefaultCellStyle.Font = new Font(gst.DefaultCellStyle.Font, FontStyle.Bold);
            gst.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            gst.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Blue;
            gst.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            gst.Rows[0].DefaultCellStyle.SelectionForeColor = Color.White;
            gst.Rows[1].DefaultCellStyle.BackColor = Color.White;
            gst.Rows[1].DefaultCellStyle.SelectionBackColor = Color.White;
            gst.Rows[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            gst.Rows[1].Height = gst.Rows[1].Height*2;
            gst.BorderStyle = BorderStyle.None;

            UpdateEkarGraph(ekarDs, avgDs);
            UpdateStatsGrid(stats);

            if (_needsToAssignDatesToPeriodSelector)
            {
                _periodSelector.Period = period;
                _needsToAssignDatesToPeriodSelector = false;
            }
        }

        private void UpdateEkarGraph(DataSet ekarDs, DataSet averageEkar)
        {
            const float penWidth = 2.0F;
            _ekarGraphCtrl.Clear();
            var pp = new PointPlot();
            pp.Marker = new Marker(Marker.MarkerType.Cross1, 6, new Pen(Color.Red, penWidth));
            pp.Marker.Pen = new Pen(Color.Red, penWidth);
            pp.Marker.DropLine = true;
            pp.DataSource = ekarDs;
            pp.AbscissaData = "Count";
            pp.OrdinateData = "Ekar";

            var mygrid = new Grid();
            mygrid.HorizontalGridType = Grid.GridType.Fine;
            mygrid.VerticalGridType = Grid.GridType.Fine;
            _ekarGraphCtrl.Add(mygrid);
            _ekarGraphCtrl.Add(pp);
            _ekarGraphCtrl.Padding = 1;
            _ekarGraphCtrl.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));
            _ekarGraphCtrl.XAxis1.IncreaseRange(0.10);
            var pp1 = new PointPlot();
            pp1.Marker = new Marker(Marker.MarkerType.FilledSquare, 1, new Pen(Color.Blue, 2.0F));
            pp1.Marker.DropLine = false;
            pp1.AbscissaData = "Count";
            pp1.OrdinateData = "AvEkar";
            pp1.DataSource = averageEkar;
            _ekarGraphCtrl.Add(pp1);
            _ekarGraphCtrl.Refresh();
        }

        private void UpdateTrainerTrackGrid()
        {
            var trackCodes = from js in _originalStats
                             group js by js.TrackCode
                             into geee select geee.Key;

            var trainers = from js in _originalStats
                           where js.Trainer.Trim().Length > 0
                           orderby js.Trainer
                           group js by js.Trainer
                           into geeee
                           select geeee.Key;

            int cols = trackCodes.Count() + 2;
            int rows = trainers.Count() + 2;

            DataGridView g = _trainerTrackGrid;
            int colIndex = g.Columns.Add("TRAINER", "");
            g.Columns[colIndex].Tag = "";
            colIndex = g.Columns.Add("ALL", "X");

            foreach (var trackCode in trackCodes)
            {
                colIndex = g.Columns.Add(trackCode, "X");
                g.Columns[colIndex].Tag = trackCode;
            }

            g.Rows.Add(trainers.Count() + 2);

            colIndex = 1;
            int rowIndex = 0;
            g[colIndex++, rowIndex].Value = "ALL";
            foreach (var trackCode in trackCodes)
            {
                g[colIndex++, rowIndex].Value = trackCode;
            }
            rowIndex = 1;
            g[0, rowIndex++].Value = "ALL";

            foreach (var trainer in trainers)
            {
                g[0, rowIndex++].Value = trainer;
            }

            _trainerTrackStats.Clear();

            foreach (var js in _originalStats)
            {
                AddToTrainerTrackStats(js);
                AddToTrainerTrackStats(new JockeyStarter(js, js.Trainer, "ALL"));
                AddToTrainerTrackStats(new JockeyStarter(js, "ALL", js.TrackCode));
                AddToTrainerTrackStats(new JockeyStarter(js, "ALL", "ALL"));
            }

            for (int col = 1; col < g.Columns.Count; ++col)
            {
                for (int row = 1; row < g.Rows.Count; ++row)
                {
                    UpdateTrainerTrackCell(col, row);
                }
            }

            for (int i = 0; i < g.Columns.Count; i++)
            {
                g.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var boldFont = new Font(g.DefaultCellStyle.Font, FontStyle.Bold);
            Color backColor = Color.White;
            Color foreColor = Color.Black;
            g.Rows[0].DefaultCellStyle.Font = boldFont;
            g.Columns[0].DefaultCellStyle.Font = boldFont;

            g.Rows[0].DefaultCellStyle.BackColor = backColor;
            g.Rows[0].DefaultCellStyle.SelectionBackColor = backColor;

            g.Rows[0].DefaultCellStyle.ForeColor = foreColor;
            g.Rows[0].DefaultCellStyle.SelectionForeColor = foreColor;

            g.Columns[0].DefaultCellStyle.BackColor = backColor;
            g.Columns[0].DefaultCellStyle.SelectionBackColor = backColor;

            g.Columns[0].DefaultCellStyle.ForeColor = foreColor;
            g.Columns[0].DefaultCellStyle.SelectionForeColor = foreColor;

            g.ColumnHeadersVisible = false;
            g.RowHeadersVisible = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            g.RowHeadersWidth = 60;
        }

        private void AddToTrainerTrackStats(JockeyStarter js)
        {
            string key = TrainerTrackStats.MakeKey(js);
            if (false == _trainerTrackStats.ContainsKey(key))
            {
                _trainerTrackStats.Add(key, new TrainerTrackStats());
            }
            _trainerTrackStats[key].IncreaseStarters();
            if (js.FinalCall == 1)
            {
                _trainerTrackStats[key].IncreaseWinners();
                _trainerTrackStats[key].IncreaseBankroll(js.WinPayoff);
            }
        }

        private void UpdateTrainerTrackCell(int col, int row)
        {
            string trackCode = _trainerTrackGrid[col, 0].Value.ToString();
            string trainer = _trainerTrackGrid[0, row].Value.ToString();

            var key = TrainerTrackStats.MakeKey(trackCode, trainer);
            DataGridViewCell cell = _trainerTrackGrid[col, row];
            if (_trainerTrackStats.ContainsKey(key))
            {
                TrainerTrackStats tts = _trainerTrackStats[key];
                cell.Tag = tts;
                cell.Value = tts.ToString();
                if (tts.Starters == 0)
                {
                    cell.Value = "";
                    cell.Style.BackColor = Color.LightGray;
                    cell.Style.SelectionBackColor = Color.LightGray;
                }
            }
            else
            {
                cell.Value = "";
                cell.Style.BackColor = Color.LightGray;
                cell.Style.SelectionBackColor = Color.LightGray;
            }
        }

        private void UpdateStatsGrid(IEnumerable<JockeyStarter> stats)
        {
            _statsGrid.Rows.Clear();
            PopulateStatsGrid("Total", stats, (JockeyStarter s) => true);
            PopulateStatsGrid("Dirt", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T') == false);
            PopulateStatsGrid("Dirt Sprint", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T') == false && s.IsSprint);
            PopulateStatsGrid("Dirt Route", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T') == false && s.IsRoute);
            PopulateStatsGrid("Turf", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T'));
            PopulateStatsGrid("Turf Sprint", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T') && s.IsSprint);
            PopulateStatsGrid("Turf Route", stats, (JockeyStarter s) => s.Surface.ToUpper().Contains('T') && s.IsRoute);

            _statsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void PopulateStatsGrid(string desc, IEnumerable<JockeyStarter> stats, Func<JockeyStarter, bool> whereClause)
        {
            var c = stats.Where(whereClause);
            int starters = c.Count();
            int winners = c.Where(s => s.FinalCall == 1).Count();
            int w2w = c.Where(s => s.FinalCall == 1 && s.FinalCall == 1 && s.SecondCall == 1).Count();
            double totalBet = starters*2.0;
            double totalPayoff = c.Select(p => p.WinPayoff).Sum();
            double roi = totalPayoff/totalBet;

            AddRowToStatsGrid(desc, starters, winners, w2w, roi);
        }

        private void AddRowToStatsGrid(string desc, int starters, int winners, int w2w, double roi)
        {
            int rowIndex = _statsGrid.Rows.Add();

            DataGridViewCellCollection cells = _statsGrid.Rows[rowIndex].Cells;

            cells["Type"].Value = desc;
            cells["Starters"].Value = starters;
            cells["Winners"].Value = winners;
            cells["Percent"].Value = string.Format("{0:0}%", starters != 0 ? ((double) winners/(double) starters)*100 : 0);
            cells["W2W"].Value = w2w;
            cells["W2WPercent"].Value = string.Format("{0:0}%", winners != 0 ? ((double) w2w/(double) winners)*100 : 0);
            cells["ROI"].Value = string.Format("{0:0.00}", roi);
        }

        private void OnTrainerTrackGridClicked(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex <= 0 && e.ColumnIndex <=0)
            {
                return;
            }
            else if (e.RowIndex <= 0 && e.ColumnIndex >= 1)
            {
                _needsToAssignDatesToPeriodSelector = true;
                _selectedTrackCode = _trainerTrackGrid[e.ColumnIndex, 0].Value.ToString();
                UpdateEkar();
            }
            else if (e.ColumnIndex <= 0 && e.RowIndex >= 1)
            {
                _needsToAssignDatesToPeriodSelector = true;
                _selectedTrainer = _trainerTrackGrid[0, e.RowIndex].Value.ToString();
                UpdateEkar();
            }
            else
            {
                _needsToAssignDatesToPeriodSelector = true;
                _selectedTrainer = _trainerTrackGrid[0, e.RowIndex].Value.ToString();
                _selectedTrackCode = _trainerTrackGrid[e.ColumnIndex, 0].Value.ToString();
                UpdateEkar();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void OnPeriodChanged(object sender, EventArgs e)
        {
            UpdateEkar();
        }
    }
}