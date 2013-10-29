using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class UpcomingRacesForm : OddsEditor.GenericForm
    {

        static List<SummaryForm> _summaryForm = new List<SummaryForm>();

        public UpcomingRacesForm()
        {
            InitializeComponent();
        }

        static public void RegisterSummaryForm(SummaryForm sm)
        {
            _summaryForm.Add(sm);
        }

        static public void UnregisterSummaryForm(SummaryForm sm)
        {
            if (_summaryForm.Contains(sm))
            {
                _summaryForm.Remove(sm);
            }
        }

        

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _timer.Interval = 5000;
            _timer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
