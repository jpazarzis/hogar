using System;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using OddsEditor.Dialogs;
using OddsEditor.Dialogs.WinnersForDay;

namespace OddsEditor.MyComponents
{
    public partial class CynthiaParsSummaryCtrl : UserControl
    {
        Horse _horse = null;
        
        public CynthiaParsSummaryCtrl()
        {
            InitializeComponent();
        }

        public void BindHorse(Horse horse)
        {
            if (_horse != horse)
            {
                _horse = horse;
                _cynthiaProjectionsCtrl.Bind(horse);
            }
        }

        private static void ShowRaceChart(BrisPastPerformance pp)
        {
            string trackCode = pp.TrackCode;
            string raceNumber = pp.RaceNumber;
            int year = pp.Date.Year;
            int month = pp.Date.Month;
            int day = pp.Date.Day;
            DailyCard dc = DailyCard.Load(trackCode, year, month, day);
            if (null != dc && dc.ExistsInDb)
            {
                var f = new RaceChartForm(dc.GetRaceFromRaceNumber(Convert.ToInt32(raceNumber)).RaceID);
                f.ShowDialog();
            }
            else
            {
                var f = new FirstSecondAndThridInfoForm(pp);
                f.ShowDialog();
            }
        }
  
        
        private void CynthiaParsSummaryCtrl_Load(object sender, EventArgs e)
        {
            
        }

        public void BindXRayCtrl(XRayCtrl xRayCtrl)
        {
            _cynthiaProjectionsCtrl.BindXRayCtrl(xRayCtrl);
        }
    }
}
