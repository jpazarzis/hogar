using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Hogar;
using Hogar.FactorStatisticsNew;

namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    public partial class FactorStatsPerTrainerForm : Form
    {
        private readonly TrainerSummary _trainerSummary;
        private readonly Horse _horse;

        int _trackCodeColIndex;
        int _dateColIndex;
        int _horseNameColIndex;
        private int _jockeyColIndex;
        int _surfaceColIndex;
        int _distanceColIndex;
        int _classificationColIndex;
        int _oddsColIndex;
        int _finalPositionColIndex;

        private StarterCollection _allStarters;
        private StarterCollection _startersForSpecifiedBitMask;
        private readonly List<FactorStatistic> _horseFactors;

        private Font _boldFont;

        private FactorStatistic _selectedFactorStatistic;
        private FactorStatistic _selectedFactorStatisticForTrainer;

        public FactorStatsPerTrainerForm(Horse horse, long bitMask)
        {
            _horse = horse;
            _selectedFactorStatistic = FactorStatisticManager.Get(bitMask);
            _selectedFactorStatisticForTrainer = FactorStatisticManager.Get(bitMask,_horse.CorrespondingBrisHorse.TrainersFullName);
            _trainerSummary = TrainerSummary.Make(_horse.CorrespondingBrisHorse.TrainersFullName);
            _horseFactors = horse.FactorStatisticsForHorse;
            InitializeComponent();
        }

        void UpdateFactorStatsGrid()
        {
            _boldFont = new Font(_gridFactorsStatistics.Font, FontStyle.Bold);
            StatisticPerFactor.Update(_allStarters);
            _gridFactorsStatistics.Columns.Add("Factor", "Factor");
            _gridFactorsStatistics.Columns.Add("All", "All");
            _gridFactorsStatistics.Columns.Add("This", "This");
            var list = StatisticPerFactor.ToList();
            _gridFactorsStatistics.Rows.Add(list.Count);
            int rowIndex = -1;
            foreach (var sf in StatisticPerFactor.ToList())
            {
                ++rowIndex; 
                var cells = _gridFactorsStatistics.Rows[rowIndex].Cells;

                var f = FactorStatisticManager.Get(sf.Flag);

                cells[0].Value = sf.Name;
                cells[1].Value = string.Format("{0,5:#####} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}", f.Starters, f.WinPercent, f.Roi, f.IV);
                cells[2].Value = string.Format("{0,5:#####} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}", sf.Starters, sf.WinPercentage, sf.ROI, sf.IV);

                var c = _gridFactorsStatistics.Rows[rowIndex].Cells[0];

                if(null != _horseFactors.Find(factStat => (factStat.BitMask & sf.Flag) == sf.Flag))
                {
                    c.Style.BackColor = Color.Aqua;
                    c.Style.SelectionBackColor = Color.Aqua;
                    c.Style.ForeColor = Color.Navy;
                    c.Style.SelectionForeColor = Color.Navy;

                    _gridFactorsStatistics.Rows[rowIndex].DefaultCellStyle.Font = _boldFont;

                }

                c = _gridFactorsStatistics.Rows[rowIndex].Cells[2];

                c.Style.BackColor = (1.2*f.IV) >= sf.IV ? Color.LightGray : Color.White;
                c.Style.SelectionBackColor = c.Style.BackColor;
                c.Style.ForeColor = Color.Black;
                c.Style.SelectionForeColor = Color.Black;
                

                _gridFactorsStatistics.Rows[rowIndex].Tag = sf.Flag;
            }
        }

        private void FactorStatsPerTrainerForm_Load(object sender, EventArgs e)
        {
            _allStarters = StarterCollection.Make(_horse.CorrespondingBrisHorse.TrainersFullName, _selectedFactorStatistic.BitMask);
            UpdateFactorStatsGrid();
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            this.Text = string.Format("Trainer: {0} Factor {1}", _horse.CorrespondingBrisHorse.TrainersFullName, _selectedFactorStatistic.Name);
            _startersForSpecifiedBitMask = StarterCollection.Make(_allStarters, _selectedFactorStatistic.BitMask);
            LoadGrid();
            _tbTrainerName.Text = _horse.CorrespondingBrisHorse.TrainersFullName;
            _tbFactorName.Text = _selectedFactorStatistic.Name;
            _tbMCLWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.MCL | RaceType.DIRT | RaceType.TURF));
            _tbMSWWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.MSW | RaceType.DIRT | RaceType.TURF));
            _tbStakesWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.STAKES | RaceType.DIRT | RaceType.TURF));
            _tbALWWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.ALW | RaceType.DIRT | RaceType.TURF));
            _tbCLMWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.CLM | RaceType.DIRT | RaceType.TURF));
            _tbDirtWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.MCL | RaceType.MSW | RaceType.STAKES | RaceType.ALW | RaceType.CLM | RaceType.DIRT));
            _tbTurfWinPercent.Text = string.Format("{0:0.00}", GetWinPercent(RaceType.MCL | RaceType.MSW | RaceType.STAKES | RaceType.ALW | RaceType.CLM | RaceType.TURF));
            LoadSummariesGrid();
        }
       

        double GetWinPercent(RaceType rt)
        {
            var sc = _startersForSpecifiedBitMask.Filter((int) rt);
            int starters = sc.Count;
            int winnerCount = sc.Count(s => { return s.FinishPosition == 1; });
            return starters > 0 ? (double)winnerCount / (double)starters : 0.0;
        }

        void LoadSummariesGrid()
        {
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _gridSummary.Rows.Clear();
            _gridSummary.Columns.Clear();

            _gridSummary.Columns.Add("desc", "desc");
            _gridSummary.Columns.Add("starters", "starters");
            _gridSummary.Columns.Add("winpercent", "win%");
            _gridSummary.Columns.Add("ROI", "ROI");
            _gridSummary.Columns.Add("IV", "IV");

            AddRowToSummariesGrid("Total For Stat", _selectedFactorStatistic.Starters, _selectedFactorStatistic.WinPercent, _selectedFactorStatistic.Roi, _selectedFactorStatistic.IV);
           // TODO FIX THIS
            // AddRowToSummariesGrid("Trainer For Stat", _factorStatistics.TrainerStarters, _factorStatistics.TrainerWinningPercent, _factorStatistics.TrainerRoi, _factorStatistics.TrainerIV);
           // AddRowToSummariesGrid("Trainer Summary", _trainerSummary.StartersCount, _trainerSummary.WinPercent, _trainerSummary.ROI, _trainerSummary.IV);    
        
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void AddRowToSummariesGrid(string total, int starters, double winningPercent, double roi, double iv)
        {
            int rowIndex = _gridSummary.Rows.Add();
            var cells = _gridSummary.Rows[rowIndex].Cells;

            cells[0].Value = total;
            cells[1].Value = starters;
            cells[2].Value = string.Format("{0,2:#0}%", winningPercent);
            cells[3].Value = string.Format("{0,5:#0.00} ", roi);
            cells[4].Value = string.Format("{0,5:#0.00} ", iv);
        }

        void AddStarterToGrid(Starter s)
        {
            int rowIndex = _grid.Rows.Add();
            var cells = _grid.Rows[rowIndex].Cells;
            cells[_trackCodeColIndex].Value = s.TrackCode;
            cells[_dateColIndex].Value = s.Date;
            cells[_horseNameColIndex].Value = s.HorseName;
            cells[_jockeyColIndex].Value = Utilities.CapitalizeOnlyFirstLetter(s.Jockey);
            cells[_surfaceColIndex].Value = s.Surface;
            cells[_distanceColIndex].Value = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int)s.Distance);
            string raceClass = Utilities.MakeRaceCondition(s.StateBredFlag, s.AgeSexRestrictions, s.AbbrRaceClass, s.RaceGrade, s.RaceName);

            if(raceClass.Length >20)
            {
                raceClass = raceClass.Substring(0, 19);
            }

            cells[_classificationColIndex].Value = raceClass;
            cells[_oddsColIndex].Value = s.Odds;
            cells[_finalPositionColIndex].Value = s.FinishPosition;

            Color backColor = Color.White;
            Color foreColor = Color.Black;

            if(s.FinishPosition == 1)
            {
                backColor = Color.LightPink;
            }
            else if (s.FinishPosition == 2)
            {
                backColor = Color.LightGreen;
            }

            _grid.Rows[rowIndex].Tag = s;

            _grid.Rows[rowIndex].DefaultCellStyle.BackColor = _grid.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = backColor;
            _grid.Rows[rowIndex].DefaultCellStyle.ForeColor= _grid.Rows[rowIndex].DefaultCellStyle.SelectionForeColor = foreColor;
        }

        List<Starter> FilterStartes()
        {
            int filter = 0;
            
            if(_cbAlw.Checked)
            {
                filter = filter | (int)RaceType.ALW;
            }

            if (_cbCLM.Checked)
            {
                filter = filter | (int)RaceType.CLM;
            }
            
            if (_cbMCL.Checked)
            {
                filter = filter | (int)RaceType.MCL;
            }

            if (_cbMSW.Checked)
            {
                filter = filter | (int) RaceType.MSW;
            }

            if (_cbStakes.Checked)
            {
                filter = filter | (int) RaceType.STAKES;
            }

            if (_cbDirt.Checked)
            {
                filter = filter | (int)RaceType.DIRT;
            }

            if (_cbTurf.Checked)
            {
                filter = filter | (int)RaceType.TURF;
            }


            return _startersForSpecifiedBitMask.Filter(filter);
        }

        private void LoadGrid()
        {
            var sc = FilterStartes();
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _trackCodeColIndex = _grid.Columns.Add("Tr", "Tr");
            _dateColIndex = _grid.Columns.Add("Date", "Date");
            _horseNameColIndex = _grid.Columns.Add("Horse", "Horse");
            _jockeyColIndex = _grid.Columns.Add("Jockey", "Jockey");
            _surfaceColIndex = _grid.Columns.Add("S", "S");
            _distanceColIndex = _grid.Columns.Add("Distance", "Distance");
            _classificationColIndex = _grid.Columns.Add("Class", "Class");
            _oddsColIndex = _grid.Columns.Add("O", "O");
            _finalPositionColIndex = _grid.Columns.Add("FP", "FP");
            sc.ToList().ForEach(AddStarterToGrid);
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

            int starters = sc.Count;
            int winnerCount = sc.Count(s => { return s.FinishPosition == 1; });

            _tbNumberOfStarters.Text = starters.ToString();
            _tbWinnerCount.Text = winnerCount.ToString();

            double winPercent = starters > 0 ? (double) winnerCount/(double) starters : 0.0;
            _tbWinPercent.Text = string.Format("{0:0.00}", winPercent);

            _tbAvgWinOdds.Text = string.Format("{0:0.00}", sc.Count >0 ? sc.Average(p => p.Odds) : 0);
            _tbWinStdDev.Text = string.Format("{0:0.00}", sc.Count > 0 ? CalculateStdDev(sc.Select(v => v.Odds)) : 0);

        }


        static private double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }


        private void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && _grid.Rows[e.RowIndex].Tag is Starter)
                {
                    var starter = _grid.Rows[e.RowIndex].Tag as Starter;
                    string trackCode = starter.TrackCode;
                    int raceNumber = starter.RaceNumber;
                    string programNumber = starter.ProgramNumber;
                    var form = new IndividualHorsePastPerformancesForm(trackCode, starter.Year, starter.Month, starter.Day, raceNumber, programNumber);
                    form.ShowDialog();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void _cbMCL_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbMSW_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbCLM_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbAlw_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbStakes_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbDirt_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _cbTurf_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void _gridFactorsStatistics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < _gridFactorsStatistics.Rows.Count)
            {
                var row = _gridFactorsStatistics.Rows[e.RowIndex];
                long factorFlag = (long)row.Tag;
                foreach (var hf in _horseFactors)
                {
                    if(hf.BitMask == factorFlag)
                    {
                        _selectedFactorStatistic = FactorStatisticManager.Get(factorFlag);
                        _selectedFactorStatisticForTrainer = FactorStatisticManager.Get(factorFlag, _horse.CorrespondingBrisHorse.TrainersFullName);
                        UpdateDisplay();
                        return;
                    }
                }
                MessageBox.Show("Unmacthed factor");
            }
            
        }
    }
}
