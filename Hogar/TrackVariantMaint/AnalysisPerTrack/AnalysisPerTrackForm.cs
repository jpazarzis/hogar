using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackVariantMaint.AnalysisPerTrack
{
    public partial class AnalysisPerTrackForm : Form
    {
        private WinnersTimeCollection _winnersTimeCollection;

        public AnalysisPerTrackForm()
        {
            InitializeComponent();
        }

        private void _buttonLoad_Click(object sender, EventArgs e)
        {
            _winnersTimeCollection = new WinnersTimeCollection();
            foreach (var partition in _winnersTimeCollection.Partitions)
            {
                _panel.Controls.Add(new TrackPartitionControl(partition));   
            }
        }
    }
}
