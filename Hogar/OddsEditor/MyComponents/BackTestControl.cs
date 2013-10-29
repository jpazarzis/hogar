using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using Hogar.BrisPastPerformances;
using NPlot;
using System.Diagnostics;

namespace OddsEditor.MyComponents
{
    public partial class BackTestControl : UserControl
    {
        public BackTestControl()
        {
            InitializeComponent();
        }

        private int Constant
        {
            get
            {
                return Convert.ToInt32(_txtboxConstant.Text.Trim());
            }
        }
        public double GetBestRating(BrisHorse brisHorse)
        {
            return brisHorse.BestRating;
        }

        public double GetBestPrimePower(BrisHorse brisHorse)
        {
            return (double)brisHorse.PrimePowerRating;
            //return (double)brisHorse.BestRating;

           // return (double)brisHorse.DeltaLoverFigure;
        }

        public void UpdateMessage(string message)
        {

            _txtboxOutput.Text += message + Environment.NewLine;

            if (_txtboxOutput.Text.Length + message.Length >= _txtboxOutput.MaxLength)
            {
                _txtboxOutput.Text = _txtboxOutput.Text.Substring(10000);
            }

            _txtboxOutput.Select(_txtboxOutput.Text.Length + 1, 2);
            _txtboxOutput.ScrollToCaret();
        }


        public void DisplayNumberOfWinnersGraph(DataSet dt)
        {
            var pp = new PointPlot();
            pp.Marker = new Marker(Marker.MarkerType.Square, 0);
            pp.Marker.Pen = new Pen(Color.Red, 5.0f);
            pp.Marker.DropLine = true;
            pp.DataSource = dt;
            pp.AbscissaData = "Percent";
            pp.OrdinateData = "Winners";



            _grapWinningPercentages.Text = "Number of Contenders";

            _grapWinningPercentages.Add(pp);
            _grapWinningPercentages.YAxis1.Label = "Number Of Winners";
            _grapWinningPercentages.YAxis1.LabelOffsetAbsolute = true;
            _grapWinningPercentages.YAxis1.LabelOffset = 40;
            _grapWinningPercentages.Padding = 5;
            _grapWinningPercentages.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));
        }


        public void DisplayNumberOfContendersGraph(DataSet dt)
        {
            PointPlot pp = new PointPlot();
            pp.Marker = new Marker(Marker.MarkerType.Square, 0);
            pp.Marker.Pen = new Pen(Color.Red, 5.0f);
            pp.Marker.DropLine = true;
            pp.DataSource = dt;
            pp.AbscissaData = "Percent";
            pp.OrdinateData = "Conteners";

            _graphNumberOfContenders.Text = "Number of Contenders";

            _graphNumberOfContenders.Add(pp);
            _graphNumberOfContenders.YAxis1.Label = "Number Of Contenters";
            _graphNumberOfContenders.YAxis1.LabelOffsetAbsolute = true;
            _graphNumberOfContenders.YAxis1.LabelOffset = 40;
            _graphNumberOfContenders.Padding = 5;
            _graphNumberOfContenders.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));
        }

       


        private void OnGo(object sender, EventArgs e)
        {
            var btc = new BackTestConstant();

            btc.GetValue = GetBestPrimePower;
            btc.UpdateObserverEvent += UpdateMessage;
            BackTestConstant.PercentageBracketCollection c = btc.Calculate(Constant);
            

            _grid.Columns.Clear();
            _grid.Rows.Clear();

            _grid.Columns.Add("Braket", "Braket");
            _grid.Columns.Add("Total", "Total");
            _grid.Columns.Add("Winners","Winners");
            _grid.Columns.Add("Percent", "Percent");
            _grid.Columns.Add("ROI", "ROI");

            _grid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["Winners"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["Percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["ROI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var contendersDataSet = new DataSet();
            var winnersDataSet = new DataSet();

            DataTable dtPerformers = contendersDataSet.Tables.Add();
            DataTable dtWinners = winnersDataSet.Tables.Add();

            dtPerformers.Columns.Add("Percent", typeof(double));
            dtPerformers.Columns.Add("Conteners", typeof(double));

            dtWinners.Columns.Add("Percent", typeof(double));
            dtWinners.Columns.Add("Winners", typeof(double));

            foreach (BackTestConstant.PercentageBracket pb in c)
            {
                int index = _grid.Rows.Add();

                _grid.Rows[index].Cells[0].Value = pb.From.ToString() + " " + pb.To.ToString();
                _grid.Rows[index].Cells[1].Value = pb.Performers.ToString();
                _grid.Rows[index].Cells[2].Value = pb.Winners.ToString();

                dtWinners.Rows.Add(pb.AvgPercent, (double)pb.Winners);
                

                if (pb.Performers == 0)
                {
                    _grid.Rows[index].Cells[3].Value = "0";
                }
                else
                {
                    
                    dtPerformers.Rows.Add(pb.AvgPercent, (double)pb.Performers);
                    string s = string.Format("{0:00.00}%", 100.0 * ((double)pb.Winners / (double)pb.Performers));
                    _grid.Rows[index].Cells[3].Value = s;
                }

                var ROI = string.Format("{0:0.00}", pb.ROI);
                _grid.Rows[index].Cells[4].Value = ROI;
            }

            DisplayNumberOfContendersGraph(contendersDataSet);
            DisplayNumberOfWinnersGraph(winnersDataSet);
        }
    }
}
