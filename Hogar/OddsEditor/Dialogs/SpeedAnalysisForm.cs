using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs
{
    public partial class SpeedAnalysisForm : Form
    {
        private readonly Race _race;
        public SpeedAnalysisForm(Race race)
        {
            _race = race;
            InitializeComponent();
        }

        private void SpeedAnalysisForm_Load(object sender, EventArgs e)
        {
            var list = _race.SpeedAnalysis.OrderBy(s => (-1) * s.FasterPaceFigure).ToList();
            _grid.DataSource = list;

            var figures = _race.CorrespondingBrisRace.GetBrisSpeedFiguresForRecentFormCycles();


            _tbAverage.Text = string.Format("{0:0.0}",figures.Average());
            _tbMin.Text = string.Format("{0:0.0}", figures.Min());
            _tbMax.Text = string.Format("{0:0.0}", figures.Max());
            _tbStdev.Text = string.Format("{0:0.0}", Utilities.CalculateStdDev(figures));
        }
    }
}
