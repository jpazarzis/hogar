using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hogar;
using OddsEditor.MyComponents;
using Hogar.BrisPastPerformances;

namespace OddsEditor.Dialogs
{

    

    public partial class FractionSpeedForm : GenericForm
    {
        readonly Race _race;
        List<HorseFractionsComponent> _fractionComponents = new List<HorseFractionsComponent>();

        public FractionSpeedForm(Race currentRace)
        {
            _race = currentRace;
            InitializeComponent();
        }

        
        private void UpdateGrid()
        {
            _txtboxTrackName.Text = RaceTracks.GetNameFromTrackCode(_race.Parent.TrackCode);
            _txtboxRaceNumber.Text = _race.RaceNumber.ToString();
            _txtboxDate.Text = _race.Parent.Date;
            
            
            if (null != _race.CorrespondingBrisRace)
            {
                _txtboxDistance.Text = _race.CorrespondingBrisRace[0].TodaysDistance;
                _txtboxRaceConditions.Text = _race.CorrespondingBrisRace[0].RaceConditions;
            }



            int y = 20, dy = 860;

            int x = 24;
            foreach (HorseFractionsComponent c in _fractionComponents)
            {
                this._panelPastPerformances.Controls.Remove(c);
            }
            this.SuspendLayout();

            

            _fractionComponents.Clear();

            foreach (Horse horse in _race.Horses)
            {

                BrisHorse.TimingType timingType = (this._radioShowLeadersTime.Checked ? BrisHorse.TimingType.LeadersHorse :
                    BrisHorse.TimingType.ThisHorse);

                if (horse.Scratched)
                {
                    continue;
                }

                var fsp = new HorseFractionsComponent(horse, timingType);

                fsp.Location = new System.Drawing.Point(x, y);
                fsp.Size = new System.Drawing.Size(1280, dy-10);
                this._panelPastPerformances.Controls.Add(fsp);

                _fractionComponents.Add(fsp);
                y += dy;
               
                fsp.BorderStyle = BorderStyle.FixedSingle;
            }

            this.ResumeLayout(false);
            this.Refresh();
            this.AdjustFormScrollbars(true);

            
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _radioThisHorseTime.Checked = true;
            UpdateGrid();
            

        }

        
        private void _radioShowLeadersTime_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void _radioThisHorseTime_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        
        
      
    }
}
