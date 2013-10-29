using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Willard;

namespace WillardsStudio
{
    public partial class RaceInfoCtrl : UserControl
    {
        public RaceInfoCtrl()
        {
            InitializeComponent();
        }

        public void BindRaceInfo(RaceInfo ri)
        {
            _txtboxClass.Text = ri.EQBRaceType;
            _txtboxDistance.Text = ri.DistanceOfTheRaceInYards.ToString();
            _txtboxFinalTime.Text = ri.FinalTime.ToString();
            _txtboxFirstCall.Text = ri.FirstCall.ToString();
            _txtboxSecondCall.Text = ri.SecondCall.ToString();
            _txtboxInnerOrOuter.Text = (ri.WasRanInInnerTrack ? "Inner" : "Outer") + " " + (ri.WasRanInTheTurf ? "Turf" : "Dirt");
            _txtboxMaxClaimingPrice.Text = string.Format("{0:0}", ri.MaxClaimingPrice);
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
