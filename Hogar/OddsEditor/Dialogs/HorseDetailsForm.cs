using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using System.Diagnostics;

namespace OddsEditor.Dialogs
{
    public partial class HorseDetailsForm : GenericForm
    {
        readonly Horse _horse = null;
        readonly BrisHorse _brisHorse = null;

        public HorseDetailsForm(Horse horse)
        {
            _horse = horse;
            _brisHorse = horse.CorrespondingBrisHorse;
            InitializeComponent();
        }

        

        private void OnFormLoad(object sender, EventArgs e)
        {
            if (null != _brisHorse)
            {
                this.Text = _brisHorse.Name;

                _tbSire.Text = _brisHorse.SireInfo;
                _tbDam.Text = _brisHorse.DamInfo;
                _tbTrainer.Text = _brisHorse.TrainerInfo;
                _tbProgramNumber.Text = _brisHorse.ProgramNumber;
                _tbHorseName.Text = _brisHorse.Name;
                _tbJockey.Text = _brisHorse.Jockey;
                _tbWeight.Text = Convert.ToString(_brisHorse.Weight);

                UpdateGrid();
            }
        }

        void UpdateGrid()
        {
            if (_rbShowFractionTime.Checked)
            {
                _grid.DataSource = _brisHorse.GetPastPerformancesAsDataTable(BrisHorse.DisplayType.ShowFractionTimes).Tables[0];
            }
            else
            {
                _grid.DataSource = _brisHorse.GetPastPerformancesAsDataTable(BrisHorse.DisplayType.ShowSpeedForFractions).Tables[0];
            }

            
        }

        private void OnShowFractionTime(object sender, EventArgs e)
        { 
            
        }

        private void OnShowFractionSpeed(object sender, EventArgs e)
        {
            
        }
    }
}
