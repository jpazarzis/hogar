using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs.KeyRacesViewer
{
    public partial class HorseCtrl : UserControl
    {
        private readonly Horse _horse;
        private readonly int _numberOfKeyRaces;

        public HorseCtrl(Horse horse, int numberOfKeyRaces)
        {
            _horse = horse;
            _numberOfKeyRaces = numberOfKeyRaces;
            InitializeComponent();
        }

        private void HorseCtrl_Load(object sender, EventArgs e)
        {
            _lableProgramNuber.Text = _horse.ProgramNumber;
            _labelHorseName.Text = _horse.Name;
            _labelOdds.Text = string.Format("{0:0.0-1}", _horse.RealTimeOdds);

            this.BackColor = _numberOfKeyRaces > 0 ? Color.Red : Color.Gray;
        }

        public Horse Horse
        {
            get
            {
                return _horse;
            }
        }
    }
}
