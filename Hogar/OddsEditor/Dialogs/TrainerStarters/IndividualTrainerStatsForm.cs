using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using Hogar;
using Hogar.BrisPastPerformances;
using System.Data.SqlClient;

namespace OddsEditor.Dialogs
{
    public partial class IndividualTrainerStatsForm : Form
    {

        TrainerFilterForm _tff = new TrainerFilterForm();

        const string _sqlLoadStartersForTrainer =
                            @"SELECT 
                                a.RACE_ID 'RACE_ID',
                                a.PROGRAM_NUMBER 'PROGRAM_NUMBER',
                                a.RACING_DATE 'DateInYYYYMMDD',
                                a.RACING_DATE 'Date',
                                a.TRACK_CODE 'TC',
                                a.RACE_NUMBER 'RN',
                                b.ABBR_RACE_CLASS 'Cls',
                                b.SURFACE 'S',
                                CONVERT (char(12), b.DISTANCE) 'Dst',
                                a.ODDS 'O',
                                a.HORSE_NAME 'Horse Name',
                                a.ABBR_JOCKEY_NAME 'Jockey',
                                a.OFFICIAL_POSITION 'Pos',
                                c.DAYS_OFF 'D1',
                                c.DAYS_OFF_2_BACK 'D2',
	                            c.DAYS_OFF_3_BACK 'D3'
                            FROM 
	                            TRAINER_STATS c, RACE_STARTERS a, RACE_DESCRIPTION b
                            WHERE 
	                            c.ABBR_TRAINER_NAME = ('{0}') 
                                AND a.PROGRAM_NUMBER != 'SCR'
	                            AND a.RACE_ID = b.RACE_ID 
	                            AND a.ID = c.STARTER_ID
                            ORDER BY 
                                a.RACING_DATE DESC";


        
        readonly Horse _horse;
        readonly string _trainerName = "";
        struct Stats
        {
            public int total;
            public int winners;
        }
        
        class JockeyStats
        {
            readonly string _name;
            private int _total = 0;
            private int _winners = 0;

            public JockeyStats(string name)
            {
                _name = name;
            }


            public void AddWinner()
            {
                ++_total;
                ++_winners;
            }

            public void AddNonWinner()
            {
                ++_total;
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public int Total
            {
                get
                {
                    return _total;
                }
            }

            public int Winners
            {
                get
                {
                    return _winners;
                }
            }

            public double WinPercent
            {
                get
                {
                    if (_total <= 0)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return (double)_winners / (double)_total;
                    }
                }
            }
        }

        public IndividualTrainerStatsForm(string trainerName)
        {
            _horse = null;
            _trainerName = trainerName;

            InitializeComponent();
        }

        public IndividualTrainerStatsForm(Horse horse)
        {
            
            _horse = horse;
            _trainerName = _horse.CorrespondingBrisHorse.TrainersFullName;
            InitializeComponent();

        }

        private void OnInitialLoad(object sender, EventArgs e)
        {

            try
            {
                Text = string.Format("Statistics for trainer {0}", _trainerName);


                if (null != _horse)
                {
                    string s = _trainerName;
                    s += " ";
                    s += " Horse : " + _horse.Name + " Layoff: " + _horse.CorrespondingBrisHorse.DaysSinceLastRace.ToString();

                    List<BrisPastPerformance> pp = _horse.CorrespondingBrisHorse.PastPerformances;
                    if (pp.Count >= 2)
                    {
                        s += " - " + pp[0].DaysSinceLastRace.ToString() + " - " + pp[1].DaysSinceLastRace.ToString();
                    }
                    else if (pp.Count == 1)
                    {
                        s += " - " + pp[0].DaysSinceLastRace.ToString() + "- 0";
                    }
                    else
                    {
                        s += " - 0  - 0";
                    }


                    _labelTrainerName.Text = s;
                }
                else
                {
                    _labelTrainerName.Text = _trainerName;
                }

                Cursor = Cursors.WaitCursor;

                string sql = string.Format(_sqlLoadStartersForTrainer, _trainerName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                DataTable dt = dataSet.Tables[0];

                dt.Columns.Add("Chart");
                dt.Columns.Add("PP");
                dt.Columns.Add("RawDistance");


                _grid.Columns.Clear();
                foreach (DataColumn column in dt.Columns)
                {
                    _grid.Columns.Add(column.Caption, column.Caption);
                    if (column.Caption == "D1" || column.Caption == "D2" || column.Caption == "D3" || column.Caption == "RawDistance")
                    {
                        _grid.Columns[column.Caption].CellTemplate.ValueType = typeof(int);
                    }

                }

                Stats statsTotal,
                      stats0To7,
                     stats8to21,
                     stats22to60,
                     stats61To180,
                     statsMoreThan180, statsDirtOnly, statsTurfOnly;

                statsTotal.total = statsTotal.winners = 0;
                stats0To7.total = stats0To7.winners = 0;
                stats8to21.total = stats8to21.winners = 0;
                stats22to60.total = stats22to60.winners = 0;
                stats61To180.total = stats61To180.winners = 0;
                statsMoreThan180.total = statsMoreThan180.winners = 0;
                statsDirtOnly.total = statsDirtOnly.winners = 0;
                statsTurfOnly.total = statsTurfOnly.winners = 0;
                string jockeyName = "";
                Dictionary<string, JockeyStats> jockeyStats = new Dictionary<string, JockeyStats>();

                Font underlinedFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);

                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dt.Rows.Count <= 0)
                {
                    return;
                }
                _grid.Rows.Add(dt.Rows.Count);

                int rowIndex = -1;
                foreach (DataRow dr in dt.Rows)
                {
                    
                    ++rowIndex;
                    jockeyName = "";

                    for (int i = 0; i < dr.ItemArray.Length; ++i)
                    {
                        string name = dt.Columns[i].Caption;

                        if (name == "Chart")
                        {
                            _grid[name, rowIndex].Value = "Chart";
                            _grid[name, rowIndex].Style.Font = underlinedFont;
                            continue;
                        }
                        if (name == "PP")
                        {
                            _grid[name, rowIndex].Value = "PP";
                            _grid[name, rowIndex].Style.Font = underlinedFont;
                            continue;
                        }

                        if (name == "RawDistance")
                        {
                            _grid[name, rowIndex].Value = (int)Convert.ToDouble((string)dr["Dst"]);
                            continue;
                        }

                        if (name == "Date")
                        {
                            _grid[name, rowIndex].Value = Utilities.GetFullDateString((string)dr["Date"]);
                        }
                        else if (name == "Dst")
                        {
                            _grid[name, rowIndex].Value = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int)Convert.ToDouble((string)dr["Dst"]));
                        }
                        else if (name == "Jockey")
                        {
                            jockeyName = Utilities.CapitalizeOnlyFirstLetter((string)dr["Jockey"]);
                            _grid[name, rowIndex].Value = Utilities.CapitalizeOnlyFirstLetter((string)dr["Jockey"]);
                        }
                        else if (name == "D1" || name == "D2" || name == "D3")
                        {
                            _grid[name, rowIndex].Value = (int)dr[name];
                        }
                        else
                        {
                            if (dr[name] is string)
                            {
                                string st = dr[name] as string;
                                _grid[name, rowIndex].Value = st.Trim();
                            }
                            else
                            {
                                _grid[name, rowIndex].Value = dr[name];
                            }
                        }
                    }

                    _grid.Rows[rowIndex].Tag = (string)dr["Date"];
                    _grid.Columns["D1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _grid.Columns["D2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _grid.Columns["D3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    _grid.Columns["RawDistance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                    _grid.Columns["RACE_ID"].Visible = false;
                    _grid.Columns["PROGRAM_NUMBER"].Visible = false;
                    _grid.Columns["DateInYYYYMMDD"].Visible = false;
                    _grid.Columns["RawDistance"].Visible = false;

                    int layoff = (int)dr["D1"];
                    int position = (int)dr["Pos"];
                    string surface = ((string)dr["S"]).Trim().ToUpper();


                    if (jockeyName.Length > 0)
                    {
                        if (jockeyStats.ContainsKey(jockeyName) == false)
                        {
                            JockeyStats js = new JockeyStats(jockeyName);
                            jockeyStats.Add(jockeyName, js);
                        }

                        if (position == 1)
                        {
                            jockeyStats[jockeyName].AddWinner();
                        }
                        else
                        {
                            jockeyStats[jockeyName].AddNonWinner();
                        }
                    }

                    ++statsTotal.total;
                    if (position == 1)
                    {
                        ++statsTotal.winners;
                    }

                    if (surface == "T")
                    {
                        ++statsTurfOnly.total;
                        if (position == 1)
                        {
                            ++statsTurfOnly.winners;
                        }
                    }
                    else
                    {
                        ++statsDirtOnly.total;
                        if (position == 1)
                        {
                            ++statsDirtOnly.winners;
                        }
                    }


                    if (layoff <= 7)
                    {
                        ++stats0To7.total;
                        if (position == 1)
                        {
                            ++stats0To7.winners;
                        }
                    }
                    else if (layoff <= 21)
                    {
                        ++stats8to21.total;
                        if (position == 1)
                        {
                            ++stats8to21.winners;
                        }
                    }
                    else if (layoff <= 60)
                    {

                        ++stats22to60.total;
                        if (position == 1)
                        {
                            ++stats22to60.winners;
                        }
                    }
                    else if (layoff <= 180)
                    {
                        ++stats61To180.total;
                        if (position == 1)
                        {
                            ++stats61To180.winners;
                        }
                    }
                    else
                    {
                        ++statsMoreThan180.total;
                        if (position == 1)
                        {
                            ++statsMoreThan180.winners;
                        }
                    }


                }
                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                UpdateStats(_txtboxTotalStarters, _txtboxWinners, _txtboxWinPercent, statsTotal);
                UpdateStats(_txtbox0to7DaysTotal, _txtbox0to7DaysWinners, _txtbox0to7DaysPercent, stats0To7);
                UpdateStats(_txtbox8To21DaysTotal, _txtbox8To21DaysWinners, _txtbox8To21DaysPercent, stats8to21);
                UpdateStats(_txtbox22To60Total, _txtbox22To60Winners, _txtbox22To60Percent, stats22to60);
                UpdateStats(_txtbox61To180Total, _txtbox61To180Winners, _txtbox61To180Percent, stats61To180);
                UpdateStats(_txtbox180PlusTotal, _txtbox180PlusWinners, _txtbox180PlusPercent, statsMoreThan180);

                UpdateStats(_txtboxDirtTotal, _txtboxDirtWinners, _txtboxDirtPercent, statsDirtOnly);
                UpdateStats(_txtboxTurfTotal, _txtboxTurfWinners, _txtboxTurfPercent, statsTurfOnly);


                UpdateJockeyGrid(jockeyStats);
                UpdateStatsForSelectedDataSet();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void UpdateStatsForSelectedDataSet()
        {
            int totalStarters = 0;
            int totalWinners = 0;
            double totalReturn = 0.0;
            double totalBet = 0.0;

            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Visible)
                {
                    ++totalStarters;
                    totalBet += 1.0;
                    int position = (int)row.Cells["Pos"].Value;
                    if (1 == position)
                    {
                        ++totalWinners;
                        double odds = (double)row.Cells["O"].Value;
                        totalReturn += odds + 1.0;
                    }
                }
            }

            double ROI = 0.0;

            if (totalBet > 0.0)
            {
                ROI = totalReturn / totalBet;
            }

            double winnersPercent = 0.0;

            if(totalStarters >0)
            {
                winnersPercent = ((double)totalWinners / (double) totalStarters) * 100.00;
            }

            _txtboxStartersForSelectedDataSet.Text = totalStarters.ToString();
            _txtboxWinnersForSelectedDataSet.Text = totalWinners.ToString();
            _txtboxWinnersPercentForSelectedDataSet.Text = string.Format("{0:0}%", winnersPercent);
            _txtboxROISelectedDataSet.Text = string.Format("{0:0.00}", ROI);

        }


        private void UpdateJockeyGrid(Dictionary<string, JockeyStats> jockeyStats)
        {
            _gridJockeyStats.Columns.Clear();
            _gridJockeyStats.Columns.Add("Name", "Name");
            _gridJockeyStats.Columns.Add("Wins", "Wins");
            _gridJockeyStats.Columns.Add("Total", "Total");
            _gridJockeyStats.Columns.Add("Prc", "Prc");
            foreach (KeyValuePair<string, JockeyStats> pair in jockeyStats)
            {
                int index = _gridJockeyStats.Rows.Add();
                _gridJockeyStats[0, index].Value = pair.Value.Name;
                _gridJockeyStats[1, index].Value = pair.Value.Winners;
                _gridJockeyStats[2, index].Value = pair.Value.Total;
                _gridJockeyStats[3, index].Value = string.Format("{0:0.00}", pair.Value.WinPercent);
            }

            _gridJockeyStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void UpdateStats(TextBox total, TextBox winners, TextBox percent, Stats stats)
        {
            total.Text = stats.total.ToString();
            winners.Text = stats.winners.ToString();
            double per = ((double)stats.winners / (double)stats.total) * 100.00;
            percent.Text = string.Format("{0:0}%", per);

            Color backColor = Color.Blue;
            if (per >= 50)
            {
                backColor = Color.Red;
            }
            else if (per >= 20)
            {
                backColor = Color.LightPink;
            }
            else if (per >= 10)
            {
                backColor = Color.LightGreen;
            }
            else if (per >= 5)
            {
                backColor = Color.Yellow;
            }
            else
            {
                backColor = Color.LightGray;
            }

            total.BackColor = backColor;
            winners.BackColor = backColor;
            percent.BackColor = backColor;

        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == _grid.Columns["Date"].Index)
            {
                DataGridViewRow row = _grid.Rows[e.RowIndex];

                if (null == row.Cells["Pos"].Value)
                {
                    return;
                }

                int p = (int)row.Cells["Pos"].Value;

                if (p == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else if (p == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                row.Cells["Chart"].Style.ForeColor = Color.Blue;
                row.Cells["PP"].Style.ForeColor = Color.Blue;
            }

        }

        private void OnSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name.CompareTo("Date") == 0)
            {

                string s1 = _grid.Rows[e.RowIndex1].Tag.ToString();
                string s2 = _grid.Rows[e.RowIndex2].Tag.ToString();


                decimal d1 = Convert.ToDecimal(s1);
                decimal d2 = Convert.ToDecimal(s2);

                if (d1 > d2)
                {
                    e.SortResult = 1;
                }
                else if (d1 < d2)
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
                e.Handled = true;
            }
        }

        private void _txtbox180PlusTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if(_grid.Columns[e.ColumnIndex].Name == "Chart")
                    {
                        int raceid = (int)_grid["RACE_ID", e.RowIndex].Value;
                        RaceChartForm form = new RaceChartForm(raceid);
                        form.ShowDialog();
                    }
                    else if (_grid.Columns[e.ColumnIndex].Name == "PP")
                    {
                        string date = _grid["DateInYYYYMMDD", e.RowIndex].Value.ToString();
                            
                        string trackCode = _grid["TC", e.RowIndex].Value.ToString();
                        int year = Convert.ToInt32(date.Substring(0,4));
                        int month = Convert.ToInt32(date.Substring(4, 2));
                        int day = Convert.ToInt32(date.Substring(6, 2));
                        int raceNumber = (int)_grid["RN", e.RowIndex].Value;
                        string programNumber = _grid["PROGRAM_NUMBER", e.RowIndex].Value.ToString();
                        
                        IndividualHorsePastPerformancesForm form = new IndividualHorsePastPerformancesForm(trackCode, year, month, day, raceNumber, programNumber);
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFilter(object sender, EventArgs e)
        {
            try
            {
                if (_tff.ShowDialog() == DialogResult.OK)
                {
                    _tff.FilterGrid(_grid);

                    UpdateStatsForSelectedDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
