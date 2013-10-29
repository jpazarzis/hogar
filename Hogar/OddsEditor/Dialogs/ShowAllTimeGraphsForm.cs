using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Hogar;
using System.Linq;
using Hogar.BrisPastPerformances;
using OddsEditor.Dialogs.WinnersForDay;

namespace OddsEditor.Dialogs
{
    public partial class ShowAllTimeGraphsForm : Form
    {
        private readonly Horse _horse;

        private List<XRayCtrl> _ctrls = new List<XRayCtrl>();

        public ShowAllTimeGraphsForm(Horse horse)
        {
            _horse = horse;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            this.Text = string.Format("Time Graphs For {0}", _horse.Name);
            _labelHorseName.Text = string.Format("{0} Race# {1} Horse# {2} Name: {3} ",_horse.Parent.Parent.TrackCode,  _horse.Parent.RaceNumber,  _horse.ProgramNumber, _horse.Name);

            if (_horse.CorrespondingBrisHorse.PastPerformances.Count <=0 )
            {
                return;
            }

            for (int i = 0; i < _horse.CorrespondingBrisHorse.PastPerformances.Count; ++i)
            {
                var ctrl = new XRayCtrl();
                _panel.Controls.Add(ctrl);
                _ctrls.Add(ctrl);
            }


            int graphIndex = 0;
            for (int i = _horse.CorrespondingBrisHorse.PastPerformances.Count-1; i >=0 ; --i)
            {
                _ctrls[graphIndex].Width = 300;
                _ctrls[graphIndex].Height = 280;

                BrisPastPerformance pp = _horse.CorrespondingBrisHorse.PastPerformances[i];
                _ctrls[graphIndex].Bind(pp.Date, pp.TrackCode, pp.Parent.Name, Convert.ToInt32(pp.RaceNumber));
                ++graphIndex;
            }
        }
    }
}