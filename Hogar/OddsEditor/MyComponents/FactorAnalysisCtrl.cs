using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.FactorStatisticsNew;
using Hogar.Handicapping;
using Hogar.StatisticTools;
using OddsEditor.Dialogs;
using OddsEditor.Dialogs.FactorStatsPerTrainer;

namespace OddsEditor.MyComponents
{
    public partial class FactorAnalysisCtrl : UserControl
    {
        private Horse _horse;
        public FactorAnalysisCtrl()
        {
            InitializeComponent();
        }

        public void Bind(Horse horse)
        {
           
            if(null==horse)
            {
                return;
            }

            _horse = horse;

            Cursor = Cursors.WaitCursor;
            try
            {

                string jockey = horse.CorrespondingBrisHorse.Jockey;
                string trainer = horse.CorrespondingBrisHorse.TrainersFullName;
               
                _tbJockeyName.Text = jockey;
                _tbTrainerName.Text = trainer;

               
                _tbTrainersStatistics.Text = FactorStatisticManager.GlobalStatisticsPerTrainer(trainer).ToString();
                _tbJockeyStats.Text = FactorStatisticManager.GlobalStatisticsPerJockey(jockey).ToString();
                _tbJockeyTrainer.Text = FactorStatisticManager.GlobalStatisticsPerTrainerAndJockey(trainer, jockey).ToString();
                _grid.Rows.Clear();

                var factorsStatics = horse.FactorStatisticsForHorse;

                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                factorsStatics.ForEach(AddFactorToGrid);
                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        
        private void AddFactorToGrid(FactorStatistic fs)
        {
            int rowIndex = _grid.Rows.Add();
            var cells = _grid.Rows[rowIndex].Cells;
            cells[0].Value = fs.Name;
            cells[1].Value = fs;
            cells[2].Value = FactorStatisticManager.Get(fs.BitMask, _horse.CorrespondingBrisHorse.TrainersFullName);
            _grid.Rows[rowIndex].Tag = fs;

        }

        private void FactorAnalysisCtrl_Load(object sender, EventArgs e)
        {
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _grid.Columns.Add("Name", "NAME");
            _grid.Columns.Add("All", "All");
            _grid.Columns.Add("Trainer", "Trainer");
            _grid.Columns["All"].CellTemplate.ValueType = typeof(string);
            _grid.Columns["Trainer"].CellTemplate.ValueType = typeof(string);
        }

        private void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;

                if(rowIndex >= 0 && rowIndex < _grid.Rows.Count && _grid.Rows[rowIndex].Tag is FactorStatistic)
                {
                    var fs = _grid.Rows[rowIndex].Tag as FactorStatistic;

                    var form = new FactorStatsPerTrainerForm(_horse, fs.BitMask);
                    form.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void _buttonShowAllTrainerStats_Click(object sender, EventArgs e)
        {
            try
            {
                if(null != _horse)
                {
                    var f = new StatsForAllTrainersInTheRaceForm(_horse.Parent);
                    f.ShowDialog();    
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
