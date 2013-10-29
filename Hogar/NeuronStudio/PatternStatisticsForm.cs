using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Algorithms.ANN;
using Hogar.Algorithms.ANN.PatternStatistics;

namespace NeuronStudio
{
    public partial class PatternStatisticsForm : Form
    {
        private readonly List<Pattern> _patterns;
        private readonly PatternStatisticCollection _stats = PatternStatisticCollection.Singeton;

        public PatternStatisticsForm(List<Pattern> patterns)
        {
            _patterns = patterns;

            InitializeComponent();
        }

        private void PatternStatisticsForm_Load(object sender, EventArgs e)
        {
            _stats.Process(_patterns);
            _grid.DataSource = _stats;
        }
    }
}
