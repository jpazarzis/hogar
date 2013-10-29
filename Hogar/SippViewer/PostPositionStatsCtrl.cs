using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp.PostPositionStatistics;

namespace SippViewer
{
    public partial class PostPositionStatsCtrl : UserControl
    {
        public PostPositionStatsCtrl()
        {
            InitializeComponent();
        }

        private void PostPositionStatsCtrl_Load(object sender, EventArgs e)
        {

        }


        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        public void Bind(PostPositionStatistics pps)
        {
            _labelCondition.Text = pps.TrackCondition;
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _grid.Columns.Add("PP", "PP");
            _grid.Columns.Add("TOT", "TOT");
            _grid.Columns.Add("W%", "W%");
            _grid.Columns.Add("IV", "IV");
            _grid.Columns.Add("W2W", "W2W");

            _grid.Rows.Add(pps.Count());

            var ivList = new List<double>();
            int rowIndex = 0;
            foreach (var postPositionStatistic in pps)
            {
                var cells = _grid.Rows[rowIndex].Cells;

                cells[0].Value = postPositionStatistic.PostPosition;
                cells[1].Value = postPositionStatistic.TotalStarters;
                cells[2].Value = string.Format("{0}%", (int)(postPositionStatistic.WinPercent * 100));
                cells[3].Value = string.Format("{0:0.00}", postPositionStatistic.IV);
                cells[4].Value = string.Format("{0}%", (int)(postPositionStatistic.W2WWinPercent * 100));

                if (postPositionStatistic.TotalStarters > 12)
                    ivList.Add(postPositionStatistic.IV );
                ++rowIndex;
            }

            _tbAverageIV.Text = string.Format("{0:0.00}", ivList.Count > 0 ? ivList.Average() : 0.0);

            _tbIVStdDev.Text = string.Format("{0:0.00}", CalculateStdDev(ivList));


        }
    }
}
