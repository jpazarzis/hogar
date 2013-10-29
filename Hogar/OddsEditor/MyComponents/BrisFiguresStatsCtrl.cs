using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using OddsEditor.Dialogs;

namespace OddsEditor.MyComponents
{
    public partial class BrisFiguresStatsCtrl : UserControl
    {
        readonly private List<double> _figures = new List<double>();

        public BrisFiguresStatsCtrl()
        {
            InitializeComponent();
        }

        private void BrisFiguresStatsCtrl_Load(object sender, EventArgs e)
        {

        }

        public void Bind(Race race)
        {
            var f = race.CorrespondingBrisRace.GetBrisSpeedFiguresForRecentFormCycles();
            _figures.Clear();
            foreach (var i in f)
            {
                _figures.Add(i);
            }
            _tbAverage.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Average() : 0);
            _tbMin.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Min(): 0);
            _tbMax.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Max(): 0);
            _tbStdev.Text = string.Format("{0:0}", _figures.Count > 0 ? Utilities.CalculateStdDev(_figures) : 0);            
        }

        private void BrisFiguresStatsCtrl_Click(object sender, EventArgs e)
        {
            if(null == _figures)
                return;
            try
            {
                var f = new HistogramForm(_figures, "Figure", "Frequency");
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
