using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Handicapping;
using Hogar.Handicapping.Analysis;
using Hogar;

namespace OddsEditor.MyComponents
{
    public partial class HandicappingFactorLabel : UserControl
    {
        readonly Factor _factor;
        readonly string _trackCode;

        public HandicappingFactorLabel(Factor f, string trackCode)
        {
            _factor = f;
            _trackCode = trackCode;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _txtbox.BackColor = Color.Beige;

            FactorPerformance fp = FactorPerformance.GetFactorPerformance(_factor.BitMask,0, _trackCode);
            _txtbox.Text = _factor.Name;
            _txtboxTrackRoi.Text = string.Format("{0:0.00}", fp.ROI);

            bool highlightIt = false;

            if (fp.ROI >= PrimeBetRequirements.Singleton.MinROI)
            {
                highlightIt = true;
                _txtboxTrackRoi.BackColor = Color.LightGreen;
            }
            _txtboxThisTrackIV.Text = string.Format("{0:0.00}", fp.IV);
            if (fp.IV >= PrimeBetRequirements.Singleton.MinIV)
            {
                highlightIt = true;
                _txtboxThisTrackIV.BackColor = Color.LightGreen;
            }
            if (highlightIt)
            {
                _txtbox.ForeColor = Color.Black;
                _txtbox.Font = new Font(_txtbox.Font, FontStyle.Bold);
            }
            else
            {
                _txtbox.ForeColor = Color.Gray;
            }
            
        }
    }
}
