using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;
using Sipp.PostPositionStatistics;

namespace SippViewer
{
    public partial class PostPositionStatsForm : Form
    {
        string _trackCode;
        string _surface;
        private string _aboutDistanceFlag;
        private double _distance;



        public PostPositionStatsForm(string trackCode, string surface, string aboutDistanceFlag, double distance)
        {
            _trackCode = trackCode;
            _surface = surface;
            _aboutDistanceFlag = aboutDistanceFlag;
            _distance = distance;

            InitializeComponent();
        }

        private void PostPositionStatsForm_Load(object sender, EventArgs e)
        {
            _tbTrackCode.Text = _trackCode;
            _tbAboutFlag.Text = _aboutDistanceFlag;
            _tbSurface.Text = _surface;
            _tbDistance.Text = SippExtentions.ConvertYardsToMilesOrFurlongs((int)_distance);

            foreach (var pps in PostPositionStatistics.LoadPPStats(_trackCode,_surface,_distance,_aboutDistanceFlag.Trim().Length > 0))
            {
                var ctrl = new PostPositionStatsCtrl();
                _panel.Controls.Add(ctrl);    
                ctrl.Bind(pps);
            }
        }

    }
}
