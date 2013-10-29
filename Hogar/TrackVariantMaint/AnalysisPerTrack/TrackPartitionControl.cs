using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPlot;

namespace TrackVariantMaint.AnalysisPerTrack
{
    public partial class TrackPartitionControl : UserControl
    {
        private readonly Partition _partition;

        public TrackPartitionControl(Partition partition)
        {
            _partition = partition;
            InitializeComponent();
        }

        private void _graph_Click(object sender, EventArgs e)
        {

        }

        private void TrackPartitionControl_Load(object sender, EventArgs e)
        {
            _labelDescription.Text = string.Format("From: {0:00}  To: {1:00}  Count: {2} ", _partition.MinFigure, _partition.MaxFigure, _partition.TotalNumberOfFigures);

            _graph.Clear();
            var sp = new LinePlot();
          //  var sp = new BarPlot();

            DataSet ds = _partition.CreateFrequenciesDataSet();
            sp.DataSource = ds;
            sp.AbscissaData = "Track";
            sp.OrdinateData = "Frequency";
            sp.Color = Color.Red;
            sp.Label = "Signal Frequency";
            _graph.Add(sp);

            

            var la = new LabelAxis(_graph.XAxis1);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                la.AddLabel((string)row["TrackName"], (double)row["Track"]);
            }
            la.TicksLabelAngle = (float)90.0f;
            la.TicksBetweenText = true;
            _graph.XAxis1 = la;
            
            _graph.Invalidate();
        }
    }
}
