using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.FactorStatisticsNew;

namespace OddsEditor.Dialogs
{
    public partial class StatsForAllTrainersInTheRaceForm : Form
    {
        private Race _race;
        public  StatsForAllTrainersInTheRaceForm(Race race)
        {
            _race = race;
            InitializeComponent();
        }

        private void InsertHorseToGrid(Horse horse)
        {
            int rowIndex = _grid.Rows.Add();
            var cells = _grid.Rows[rowIndex].Cells;

            cells[0].Value = horse.ProgramNumber;
            cells[1].Value = horse.Name;
            cells[2].Value = horse.CorrespondingBrisHorse.TrainersFullName;


            double iv;
            int starters;
            double winningPercent;
            double roi;
            /*
             * TODO : fix this
            var fs = FactorStatisticManager.Get()
            FactorStatistics.GetTrainersIV(horse.CorrespondingBrisHorse.TrainersFullName, out iv, out starters, out winningPercent, out roi);


            cells[3].Value = starters;
            cells[4].Value = string.Format("{0:0.00}%",winningPercent);
            cells[5].Value = string.Format("{0:0.00}", roi);
            cells[6].Value = string.Format("{0:0.00}", iv);
            */
 
        }

        private void StatsForAllTrainersInTheRaceForm_Load(object sender, EventArgs e)
        {
            _grid.Columns.Add("HorseNumber", "HorseNumber");
            _grid.Columns.Add("HorseName", "HorseName");
            _grid.Columns.Add("TrainerName", "TrainerName");
            _grid.Columns.Add("Starters", "Starters");
            _grid.Columns.Add("WinPercent", "WinPercent");
            _grid.Columns.Add("ROI", "ROI");
            _grid.Columns.Add("IV", "IV");

            _race.Horses.Where(h => false == h.Scratched).ToList().ForEach(InsertHorseToGrid);
            
        }
    }
}
