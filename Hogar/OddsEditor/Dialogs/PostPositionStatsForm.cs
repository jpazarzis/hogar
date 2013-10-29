using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.PostPositionStatistics;
using OddsEditor.MyComponents;

namespace OddsEditor.Dialogs
{
    public partial class PostPositionStatsForm : Form
    {
        string _trackCode;
        string _surface;
        private string _aboutDistanceFlag;
        private double _distance;

        private Dictionary<PPStatsPerTrackCondition, int> _startingColumn = new Dictionary<PPStatsPerTrackCondition, int>();

        public PostPositionStatsForm(string trackCode, string surface, string aboutDistanceFlag, double distance)
        {
            _trackCode = trackCode;
            _surface = surface;
            _aboutDistanceFlag = aboutDistanceFlag;
            _distance = distance;
    
            InitializeComponent();
        }

        private void InitializeTableGrid(PostPositionStatistics pps)
        {
            _flowLayoutPanel.Controls.Clear();
            

            foreach (var postPositionStatistic in pps)
            {

                var ctrl = new W2WStatsCtrl
                               {
                                   Description = postPositionStatistic.TrackCondition,
                                   NumberOfRaces =  postPositionStatistic.Count > 0 ?  postPositionStatistic[0].NumberOfRaces : 0,
                                   W2WWinners = postPositionStatistic.Sum(ppstats => ppstats.W2WWinners)
                               };

                _flowLayoutPanel.Controls.Add(ctrl);
            }
        }

        void InitializeGrid(PostPositionStatistics pps)
        {

            
            _grid.Columns.Add("PP", "PP");
            _startingColumn.Clear();

            foreach (var postPositionStatistic in pps)
            {
                string trackCondition = postPositionStatistic.TrackCondition;

                string name = trackCondition + "\nTotal";

                _startingColumn.Add(postPositionStatistic, _grid.Columns.Add(name, name));
                name = trackCondition + "\nWin%";
                _grid.Columns.Add(name, name);

                name = trackCondition + "\nIV";
                _grid.Columns.Add(name, name);


                name = trackCondition + "\nW2W%";
                _grid.Columns.Add(name, name);

            }
            

            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _grid.ColumnHeadersHeight = 50;
            
            for(int col = 0; col < _grid.Columns.Count; ++col)
            {
                _grid.Columns[col].Width = 40;
                _grid.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }

            foreach(int c in _startingColumn.Values)
            {
                _grid.Columns[c].DefaultCellStyle.BackColor = Color.Black;
                _grid.Columns[c].DefaultCellStyle.ForeColor = Color.White;
            }

        }

        private void PostPositionStatsForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _label.Text = "Please wait......";
            
            try
            {
             
                PostPositionStatistics pps = PostPositionStatistics.Make(_trackCode, _surface, _aboutDistanceFlag, _distance);

                InitializeGrid(pps);

                InitializeTableGrid(pps);



                var rowMap = new Dictionary<int, DataGridViewRow>();

                for (int i = 0; i < pps.Count; ++i )
                {
                    foreach (var postPositionStatistic in pps[i])
                    {
                        int postPosition = postPositionStatistic.PostPosition;
                        var row = rowMap.ContainsKey(postPosition) ? rowMap[postPosition] : null;

                        if(null == row)
                        {
                            int index = _grid.Rows.Add();
                            row = _grid.Rows[index];
                            row.Cells[0].Value = postPosition;
                            rowMap.Add(postPosition,row);
                        }

                        int colIndex = _startingColumn[pps[i]];
                        
                        row.Cells[colIndex++].Value = postPositionStatistic.Starters;
                        row.Cells[colIndex++].Value = string.Format("{0}%", (int) (postPositionStatistic.WinPercent*100));
                        row.Cells[colIndex++].Value = string.Format("{0:0.0}", postPositionStatistic.IV);
                        row.Cells[colIndex++].Value = string.Format("{0}%", (int) (postPositionStatistic.W2WWinPercent*100));

                        PaintIVCell(row, _startingColumn[pps[i]] + 2, postPositionStatistic.IV);
                    }

                    
                }

                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            _label.Text = string.Format("Post Position Stats for {0} {1} {2} {3}", _trackCode, _surface, _aboutDistanceFlag, Utilities.ConvertYardsToMilesOrFurlongs((int)_distance));

            Cursor = Cursors.Default;
        }

        

        private void PaintIVCell(DataGridViewRow row, int i, double iv)
        {
            Color backColor = GetIVBackColor(iv);

            row.Cells[i].Style.BackColor = backColor;
            row.Cells[i].Style.SelectionBackColor = backColor;

        }

        private Color GetIVBackColor(double iv)
        {
            if (iv > 2.0)
                return Color.Red;
            else if (iv > 1.7)
                return Color.DeepPink;
            else if (iv > 1.3)
                return Color.LightPink;
            else if (iv > 1.0)
                return Color.LightSkyBlue;
            else if (iv > 0.8)
                return Color.LightGray;
            else
                return Color.Gray;

        }
    }
}
