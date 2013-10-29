using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPlot;



namespace ExoticStudio.UserControls
{
    public partial class FrequencyGraph : UserControl
    {

        

        public FrequencyGraph()
        {
            InitializeComponent();
        }

        
        public void DisplayGraph(DataSet dataSet)
        {
            _graph.Clear();

            if (null == dataSet)
            {
                return;
            }

            PointPlot pp = new PointPlot();
            pp.Marker = new Marker(Marker.MarkerType.Square, 0);
           

            pp.Marker.Pen = new Pen(Color.Red, 5.0f);
            pp.Marker.DropLine = true;
            pp.DataSource = dataSet;

           
            pp.AbscissaData = dataSet.Tables[0].Columns[0].ColumnName;
            pp.OrdinateData = dataSet.Tables[0].Columns[1].ColumnName;

            _graph.Add(pp);
            _graph.YAxis1.Label = "Volume";
            _graph.YAxis1.LabelOffsetAbsolute = true;
            _graph.YAxis1.LabelOffset = 40;
            _graph.Padding = 5;
            _graph.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));
        }

        
    }
}
