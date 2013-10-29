using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Handicapping;

namespace OddsEditor.Dialogs.FactorWorkbench
{
    public partial class FactorWorkbenchForm : Form
    {
        private Dictionary<string, List<HorseInfo>> _filteredHorseInfo;
        private List<HorseInfo> _horseInfo;
        private readonly GroupingInfo _groupingInfo = new GroupingInfo();

        public FactorWorkbenchForm()
        {
            _filteredHorseInfo = new Dictionary<string, List<HorseInfo>>();
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _lbFactor.Items.Clear();
            Factor.AvailableFactorsAsList.ForEach(f => _lbFactor.Items.Add(f));
            Text = string.Format("Factor Workbench   Total Number of Factors: {0}", _lbFactor.Items.Count);
            InitializeGrid();
            UpdateStats();
        }

        private void InitializeGrid()
        {
            /*
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _grid.Columns.Add("TRACK_CODE", "Track");
            _grid.Columns.Add("DATE", "DATE");
            _grid.Columns.Add("RACE_NUMBER", "RACE");
            _grid.Columns.Add("HORSE_NAME", "NAME");
            _grid.Columns.Add("FINISH_POSITION", "POS");
            _grid.Columns.Add("DISTANCE", "DIST");
            _grid.Columns.Add("ODDS", "ODDS");
            _grid.Columns.Add("SURFACE", "SURF");
            _grid.Columns.Add("CLASSIFICATION", "CLASS");
            _grid.Columns.Add("OFF_TURF", "OFF");

            _grid.Columns["DATE"].CellTemplate.ValueType = typeof (DateTime);
            _grid.Columns["RACE_NUMBER"].CellTemplate.ValueType = typeof (int);
            _grid.Columns["FINISH_POSITION"].CellTemplate.ValueType = typeof (int);
            _grid.Columns["ODDS"].CellTemplate.ValueType = typeof (double);
            */

            _gridGrouping.Rows.Clear();
            _gridGrouping.Columns.Clear();
            _gridGrouping.Columns.Add("DESC", "DESC");
            _gridGrouping.Columns.Add("TOTAL", "Total");
            _gridGrouping.Columns.Add("WINS", "Wins");
            _gridGrouping.Columns.Add("WINNING_PERCENT", "%");
            _gridGrouping.Columns.Add("ROI", "ROI");

            _gridGrouping.Columns["TOTAL"].CellTemplate.ValueType = typeof (int);
            _gridGrouping.Columns["WINS"].CellTemplate.ValueType = typeof (int);
            _gridGrouping.Columns["WINNING_PERCENT"].CellTemplate.ValueType = typeof (int);
            _gridGrouping.Columns["ROI"].CellTemplate.ValueType = typeof (string);
            

        }

        private void UpdateStats()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _gridGrouping.Rows.Clear();
                if(null == _horseInfo)
                {
                    return;
                }
                BuildGroups();
                _gridGrouping.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                _filteredHorseInfo.Keys.ToList().ForEach(AddGroupToGrid);
                _gridGrouping.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            finally
            {
                Cursor = Cursors.Default;    
            }
        }

        private void AddGroupToGrid(string key)
        {
            IEnumerable<HorseInfo> horseInfos = _filteredHorseInfo[key];

            int winners = 0;
            int total = 0;
            double roi = 0.0;
            double winningPercent = 0.0;
            if (null != _filteredHorseInfo)
            {
                winners = horseInfos.Count(h => h.FinishPosition == 1);
                total = horseInfos.Count();
                double totalBet = total*1.0;
                double totalReturn = horseInfos.Sum(h => h.FinishPosition == 1 ? h.Odds + 1.0 : 0.0);
                if (0.0 != totalBet)
                {
                    roi = totalReturn/totalBet;
                }
                if (total > 0)
                {
                    winningPercent = ((double) winners)/(double) total;
                }
            }

            _tbWinners.Text = winners.ToString();
            _tbTotal.Text = total.ToString();
            _tbROI.Text = string.Format("{0:0.0}", roi);
            _tbWinningPercent.Text = string.Format("{0:0}%", winningPercent*100.0);

            int index = _gridGrouping.Rows.Add();
            DataGridViewCellCollection cells = _gridGrouping.Rows[index].Cells;
            cells["DESC"].Value = key;
            cells["TOTAL"].Value = total;
            cells["WINS"].Value = winners;
            cells["WINNING_PERCENT"].Value =(int) (winningPercent * 100.0);
            cells["ROI"].Value = string.Format("{0:0.0}", roi);
            _gridGrouping.Rows[index].Tag = horseInfos;
        }

        private void BuildGroups()
        {
            _filteredHorseInfo.Clear();
            _filteredHorseInfo.Add("ALL", _horseInfo);

            var groups = new Dictionary<string, List<HorseInfo>>();
            if(_groupingInfo.ByTrack)
            {
                _filteredHorseInfo.Keys.ToList().ForEach(desc => AddGroups(groups, _filteredHorseInfo[desc], GroupType.Track, desc));
                _filteredHorseInfo = groups;
            }

            groups = new Dictionary<string, List<HorseInfo>>();
            if (_groupingInfo.ByDistance)
            {
                _filteredHorseInfo.Keys.ToList().ForEach(desc => AddGroups(groups, _filteredHorseInfo[desc], GroupType.Distance, desc));
                _filteredHorseInfo = groups;
            }

            groups = new Dictionary<string, List<HorseInfo>>();
            if (_groupingInfo.ByClassification)
            {
                _filteredHorseInfo.Keys.ToList().ForEach(desc => AddGroups(groups, _filteredHorseInfo[desc], GroupType.Classification, desc));
                _filteredHorseInfo = groups;
            }

            groups = new Dictionary<string, List<HorseInfo>>();
            if (_groupingInfo.ByTrainer)
            {
                _filteredHorseInfo.Keys.ToList().ForEach(desc => AddGroups(groups, _filteredHorseInfo[desc], GroupType.Trainer, desc));
                _filteredHorseInfo = groups;
            }

        }

        void AddGroups(Dictionary<string, List<HorseInfo>> groups, List<HorseInfo> hil, GroupType gt, string desc)
        {
            
            hil.ForEach(h=>
                            {
                                string key = desc + " " + h.GetKey(gt);

                                if(key.Substring(0,3).ToUpper() == "ALL")
                                {
                                    key = key.Substring(3);
                                }
                                if(!groups.ContainsKey(key))
                                {
                                    groups.Add(key, new List<HorseInfo>());
                                }
                                groups[key].Add(h);
                            }
                        );
        }

        /*
        private void UpdateFactorView()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (null == _filter || _filter.IsEmpty)
                {
                    _filteredHorseInfo = _horseInfo;
                }
                else
                {
                    _filteredHorseInfo = _horseInfo.Where(h => _filter.TrackCodes.Contains(h.TrackCode));
                }
                _grid.Rows.Clear();
                _labelFactorName.Text = "";
                if (null != _selectedFactor)
                {
                    _labelFactorName.Text = _selectedFactor.Name;
                    UpdateGrid();
                }
                UpdateStats();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
         */

        /*
        private void UpdateGrid()
        {
            _grid.Rows.Clear();

            if (null != _filteredHorseInfo)
            {
                _grid.Rows.Add(_filteredHorseInfo.Count());
                int row = 0;
                _filteredHorseInfo.ToList().ForEach(hi => AddHorseInfoToGrid(hi, row++));
            }
        }*/

        /*
        private void AddHorseInfoToGrid(HorseInfo hi,int rowindex)
        {
            DataGridViewCellCollection cells = _grid.Rows[rowindex].Cells;
            cells["TRACK_CODE"].Value = hi.TrackCode;
            cells["DATE"].Value = hi.Date;
            cells["RACE_NUMBER"].Value = hi.RaceNumber;
            cells["HORSE_NAME"].Value = hi.HorseName;
            cells["FINISH_POSITION"].Value = hi.FinishPosition;
            cells["DISTANCE"].Value = hi.Distanec;
            cells["ODDS"].Value = hi.Odds;
            cells["SURFACE"].Value = hi.Surface;
            cells["CLASSIFICATION"].Value = hi.RaceClassification;
            cells["OFF_TURF"].Value = hi.OffTurfIndicator;
            _grid.Rows[rowindex].Tag = hi;
        }
         */

        private void OnGroupingWasChanged(object sender, EventArgs e)
        {
            _groupingInfo.ByTrack = _cbGroupByTrack.Checked;
            _groupingInfo.ByDistance = _cbGroupByDistance.Checked;
            _groupingInfo.ByClassification = _cbGroupByClassification.Checked;
            _groupingInfo.ByTrainer = _cbTrainer.Checked;

            UpdateStats();
        }

        private void OnFactorListDoubleClicked(object sender, EventArgs e)
        {
            Text = string.Format("Factor Workbench   Total Number of Factors: {0}", _lbFactor.Items.Count);
            _labelFactorName.Text = (_lbFactor.SelectedItem as Factor).Name;
            _horseInfo = HorseInfo.LoadFromDb(_lbFactor.SelectedItem as Factor);
            UpdateStats();
        }
    }
}