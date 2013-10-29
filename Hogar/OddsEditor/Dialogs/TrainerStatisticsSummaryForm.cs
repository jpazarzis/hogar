using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using Hogar;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace OddsEditor.Dialogs
{
    public partial class TrainerStatisticsSummaryForm : OddsEditor.GenericForm
    {
        const string _sqlLoadStartersForTrainer =
@"SELECT 
    a.RACING_DATE 'Date',
    a.TRACK_CODE 'Track',
    a.RACE_NUMBER 'Race#',
    b.ABBR_RACE_CLASS 'Cls',
    b.SURFACE 'Sfc',
    CONVERT (char(12), b.DISTANCE) 'Dst',
    a.ODDS 'Odds',
    a.HORSE_NAME 'Horse Name',
    a.ABBR_JOCKEY_NAME 'Jockey',
    a.OFFICIAL_POSITION 'Pos',
    c.DAYS_OFF 'Off',
	c.DAYS_OFF_2_BACK 'Off2', 
	c.DAYS_OFF_3_BACK 'Off3'	 
FROM 
	TRAINER_STATS c, RACE_STARTERS a, RACE_DESCRIPTION b
WHERE 
	c.ABBR_TRAINER_NAME = ('{0}') 
	AND a.RACE_ID = b.RACE_ID 
	AND a.ID = c.STARTER_ID
ORDER BY 
    a.RACING_DATE DESC";

        public TrainerStatisticsSummaryForm()
        {
            InitializeComponent();
        }

        string MakeColumnHeader(TrainerStatistics.PeriodResults pr)
        {
            return pr.MinLayoff.ToString() + "-" + pr.MaxLayoff.ToString();
        }


        void InitializeGrid(TrainerStatistics ts)
        {
            _grid.Columns.Clear();
            _grid.Columns.Add("Name","Name");

            int width = 50;
            foreach (TrainerStatistics.PeriodResults pr in ts.PeriodResulsCollection)
            {
                string columnName = MakeColumnHeader(pr) + " %";
                _grid.Columns.Add(columnName, columnName);
                _grid.Columns[columnName].Width = width;

                columnName = MakeColumnHeader(pr) + " Win";
                _grid.Columns.Add(columnName, columnName);
                _grid.Columns[columnName].Width = width;
                _grid.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                columnName = MakeColumnHeader(pr) + " Total";
                _grid.Columns.Add(columnName, columnName);
                _grid.Columns[columnName].Width = width;
                _grid.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            }
         
        }

        Color GetColor(double perc)
        {
            if (perc >= 0.5)
            {
                return Color.Red;
            }
            else if (perc >= 0.25)
            {
                return Color.LightPink;
            }
            else if (perc >= 0.12)
            {
                return Color.LightGreen;
            }
            else if (perc >= 0.06)
            {
                return Color.LightBlue;
            }
            else
            {
                return Color.Gray;
            }
        }

        void AddResultsToGrid(TrainerStatistics ts)
        {
            int row = _grid.Rows.Add();
            _grid["Name", row].Value = Utilities.CapitalizeOnlyFirstLetter(ts.Name);
            foreach (TrainerStatistics.PeriodResults pr in ts.PeriodResulsCollection)
            {
                string columnName = MakeColumnHeader(pr) + " %";

                if (pr.Total <= 0)
                {
                    _grid[columnName, row].Value = "N/A";
                    _grid[columnName, row].Style.BackColor = Color.Gray;
                    _grid[columnName, row].Style.ForeColor = Color.Gray;

                    columnName = MakeColumnHeader(pr) + " Win";
                    _grid[columnName, row].Style.BackColor = Color.Gray;
                    _grid[columnName, row].Style.ForeColor = Color.Gray;

                    columnName = MakeColumnHeader(pr) + " Total";
                    _grid[columnName, row].Style.BackColor = Color.Gray;
                    _grid[columnName, row].Style.ForeColor = Color.Gray;

                }
                else
                {
                    double perc = ((double) pr.Winners) / ((double)pr.Total);
                    _grid[columnName, row].Value = string.Format("{0:00.00}%", perc*100.0);
                    _grid[columnName, row].Style.BackColor = GetColor(perc);

                    columnName = MakeColumnHeader(pr) + " Win";
                    _grid[columnName, row].Value = pr.Winners;
                    _grid[columnName, row].Style.BackColor = GetColor(perc);

                    columnName = MakeColumnHeader(pr) + " Total";
                    _grid[columnName, row].Value = pr.Total;
                    _grid[columnName, row].Style.BackColor = GetColor(perc);
                }
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _grid.Columns.Clear();
            foreach(TrainerStatistics ts in TrainerStatisticsCollection.TrainerStatsAsList)
            {
                if (_grid.Columns.Count <= 0)
                {
                    InitializeGrid(ts);
                }

                AddResultsToGrid(ts);
            }
        }

        private void OnShowTrainerStarters(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cursor = Cursors.WaitCursor;
                string trainerName = _grid[0, e.RowIndex].Value.ToString();
                _labelTrainerName.Text = trainerName;
                string sql = string.Format(_sqlLoadStartersForTrainer, trainerName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                DataTable dt = dataSet.Tables[0];
                _gridStarters.Columns.Clear();
                foreach (DataColumn column in dt.Columns)
                {
                    _gridStarters.Columns.Add(column.Caption, column.Caption);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    int rowIndex = _gridStarters.Rows.Add();

                    for(int i = 0; i < dr.ItemArray.Length;++i)
                    {
                        string name = dt.Columns[i].Caption;

                        if (name == "Date")
                        {
                            _gridStarters[name, rowIndex].Value = Utilities.GetFullDateString((string)dr["Date"]);
                        }
                        else if (name == "Dst")
                        {
                            _gridStarters[name, rowIndex].Value = Utilities.ConvertYardsToMilesOrFurlongs((int)Convert.ToDouble((string)dr["Dst"]));
                        }
                        else if (name == "Jockey")
                        {
                            _gridStarters[name, rowIndex].Value = Utilities.CapitalizeOnlyFirstLetter((string)dr["Jockey"]);
                        }
                        else
                        {
                            _gridStarters[name, rowIndex].Value = dr[name];
                        }
                    }
                    _gridStarters.Rows[rowIndex].Tag = (string)dr["Date"];                    
                }
                Cursor = Cursors.Default;
            }
        }

        private void OnGridStartersCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = _gridStarters.Rows[e.RowIndex];

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
            }
        }

        private void OnGridStartersSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name.CompareTo("Date") == 0)
            {

                string s1 = _gridStarters.Rows[e.RowIndex1].Tag.ToString();
                string s2 = _gridStarters.Rows[e.RowIndex2].Tag.ToString();


                decimal d1 = Convert.ToDecimal(s1);
                decimal d2 = Convert.ToDecimal(s2);

                if (d1 > d2 )
                {
                    e.SortResult = 1;
                }
                else if (d1<d2)
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
    }
}
