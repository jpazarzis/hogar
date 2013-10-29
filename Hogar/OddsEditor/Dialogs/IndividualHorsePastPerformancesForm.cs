using System;
using Hogar;
using OddsEditor.MyComponents;
using Hogar.BrisPastPerformances;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class IndividualHorsePastPerformancesForm : Form
    {
        
        readonly Horse _myHorse;


        public IndividualHorsePastPerformancesForm(string trackCode, int year, int month, int day, int raceNumber, string programNumber)
        {
            DailyCard dc = DailyCard.Load(trackCode,year,month,day);
            Race race = dc.GetRaceFromRaceNumber(raceNumber);
            _myHorse = race.GetHorseByProgramNumber(programNumber);
            
            if (null == _myHorse)
            {
                throw new Exception("Sorry, horse not found");
            }
            InitializeComponent();
        }

        public IndividualHorsePastPerformancesForm(Horse myHorse)
        {
            _myHorse = myHorse;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            
            this.SuspendLayout();
            this.Text = "Past Performances for " + _myHorse.Name;

            string trackCode = RaceTracks.GetNameFromTrackCode(_myHorse.Parent.Parent.TrackCode);
            int raceNumber = _myHorse.Parent.RaceNumber;
            string date = Utilities.GetFullDateString(_myHorse.Parent.Parent.Date);
            string classification = _myHorse.Parent.CorrespondingBrisRace.RaceClassification;

            this.Text = string.Format("{0} {1} {2} {3}", _myHorse.Name, _myHorse.Parent.Parent.TrackCode, _myHorse.Parent.Parent.Date, raceNumber);

           

            HorseFractionsComponent hfc = new MyComponents.HorseFractionsComponent(_myHorse, BrisHorse.TimingType.LeadersHorse);
            _panel.Controls.Add(hfc);
                        
            this.ResumeLayout(false);
            this.Refresh();
            this.AdjustFormScrollbars(true);
           
        }
    }
}
