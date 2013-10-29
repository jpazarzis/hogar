using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.DbTools;
using NPlot;

namespace OddsEditor.Dialogs.WinnersForDay
{
    internal partial class TimeComparisonCtrl : UserControl
    {
        private string[] _bestRaceText = new string[5];
        private string[] _worstRaceText = new string[5];
        private string[] _thisRaceText = new string[5];
        private string[] _thisHorseText = new string[5];
        private string[] _avgText = new string[5];

        // y2,y1 are the ordinates for fastest and slowest races 
        const double _y2 = 20.0; 
        const double _y1 = 10.0;
        private const double MIN_DISTANCE_WITH_VALID_THIRD_FRACTION = 1760.0;

       // private const double MIN_DISTANCE_WITH_VALID_THIRD_FRACTION = 10000.0;

        private double _distance;

       


        public TimeComparisonCtrl()
        {
            InitializeComponent();
        }

        private static DataSet GetHorizontalLineDataSet(int count, double y)
        {
            var dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();
            dataTable.Columns.Add("X", typeof (double));
            dataTable.Columns.Add("Y", typeof (double));
            for (int i = -1; i < count; ++i)
            {
                dataTable.Rows.Add((double) i, y);
            }
            return dataSet;
        }

        private void Plot(DataSet ds, string[] text, Color color)
        {
            var sp = new LinePlot();
            sp.DataSource = ds;
            sp.AbscissaData = "X";
            sp.OrdinateData = "Y";
            sp.Color = color;
            sp.Label = "TEST";
            _graph.Add(sp);

            if (null != text)
            {
                string[] sa = text.Where(s => s != null).ToArray();
                var tp1 = new LabelPointPlot();
                tp1.DataSource = ds;
                tp1.TextData = sa;
                tp1.LabelTextPosition = LabelPointPlot.LabelPositions.Above;
                tp1.Marker = new Marker(Marker.MarkerType.None, 10);
                tp1.AbscissaData = "X";
                tp1.OrdinateData = "Y";
                _graph.Add(tp1);
            }
        }

        public void Bind(IEnumerable<IFractionalTimes> winners, IFractionalTimes raceToPlot, int raceid, string horseName)
        {
            _graph.Clear();

            _distance = GetDistance(raceid);
            if (null == raceToPlot || winners.Count() <= 2)
            {
                return;
            }

            var thisHorseFractions = new StarterInfo(raceid, horseName);

            var bestRace = CreateDataSet();
            var worstRace = CreateDataSet();
            var thisRace = CreateDataSet();
            var thisHorse = CreateDataSet();
            var average = CreateDataSet();

            int textIndex = 0;

            AddFractionalPoints(bestRace, worstRace, thisRace, thisHorse, average, winners, raceToPlot, thisHorseFractions, (IFractionalTimes ft) => ft.FirstFraction(), textIndex++);
            AddFractionalPoints(bestRace, worstRace, thisRace, thisHorse, average, winners, raceToPlot, thisHorseFractions, (IFractionalTimes ft) => ft.SecondFraction(), textIndex++);

            if (_distance >= MIN_DISTANCE_WITH_VALID_THIRD_FRACTION)
            {
                AddFractionalPoints(bestRace, worstRace, thisRace, thisHorse, average, winners, raceToPlot, thisHorseFractions, (IFractionalTimes ft) => ft.ThirdFraction(), textIndex++);
            }

            AddFractionalPoints(bestRace, worstRace, thisRace, thisHorse, average, winners, raceToPlot, thisHorseFractions, (IFractionalTimes ft) => ft.FinalTime(), textIndex++);
            int count = _distance >= MIN_DISTANCE_WITH_VALID_THIRD_FRACTION ? 5 : 4;
            Plot(GetHorizontalLineDataSet(count, _y1), null, Color.White);
            Plot(bestRace, _bestRaceText, Color.Gray);
            Plot(worstRace, _worstRaceText, Color.Gray);
            Plot(thisRace, _thisRaceText, Color.Blue);
            Plot(thisHorse, _thisHorseText, Color.Red);
            Plot(average, _avgText, Color.LightGray);
            Plot(GetHorizontalLineDataSet(textIndex, 22), null, Color.White);
            _graph.Invalidate();
            _graph.XAxis1.Hidden = true;
            _graph.YAxis1.Hidden = true;
            
        }

        

        private static double GetDistance(int raceid)
        {
            double distance = 0.0;
            using (var dbr = new DbReader())
            {
                string sql = string.Format("Select DISTANCE from RACE_DESCRIPTION Where race_id = {0}", raceid);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        distance = dbr.GetValue<double>("DISTANCE");
                    }
                }
            }
            return distance;
        }

        private static DataSet CreateDataSet()
        {
            var ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt.Columns.Add("X", typeof (double));
            dt.Columns.Add("Y", typeof (double));
            return ds;
        }

        // t1: Worst Time (largest)
        // t2: Best Time  (smaller)
        // y1,y2: ordinate of t1,t2 
        // t0 : the time to find its ordinate
        private static double CalculateY(double t1, double t2, double y1, double y2, double t0)
        {

            double w = Math.Abs(y2 - y1);


            if (t0 == t2)
            {
                return y2;
            }
            else if (t0 == t1)
            {
                return y1;
            }
            else if (t0 > t1)
            {
                double a = (t1 - t2)/(t0 - t1);
                return y1 - w / a;
            }
            else if (t0 < t1)
            {
                double a = (t0 - t2)/(t1 - t0);
                return y1 + w/(a + 1);
            }
            else
            {
                throw new Exception("This should never happen");
            }
        }

        private void AddFractionalPoints(DataSet bestRace, DataSet worstRace, DataSet thisRace, DataSet thisHorse, DataSet average, IEnumerable<IFractionalTimes> winners, IFractionalTimes raceToPlot, StarterInfo thisHorseFractions, Func<IFractionalTimes, double> func, int textIndex)
        {
            double bestTime = winners.Min(func);
            double worstTime = winners.Max(func);
            double thisRaceTime = func(raceToPlot);
            double thisHorseTime = func(thisHorseFractions);
            double avg = winners.Average(func);

            if (bestTime <= 0 || worstTime <= 0 || thisRaceTime <= 0 || bestTime > worstTime)
            {
                return;
            }

            const double y2 = _y2;
            const double y1 = _y1;

            double t1 = worstTime;
            double t2 = bestTime;
            double t0 = thisRaceTime;

            _thisRaceText[textIndex] = Utilities.ConvertTimeToMMSSFifth(t0);
            _thisHorseText[textIndex] = Utilities.ConvertTimeToMMSSFifth(thisHorseTime);
            _bestRaceText[textIndex] = Utilities.ConvertTimeToMMSSFifth(bestTime);
            _worstRaceText[textIndex] = Utilities.ConvertTimeToMMSSFifth(worstTime);
            _avgText[textIndex] = Utilities.ConvertTimeToMMSSFifth(avg);

            thisRace.Tables[0].Rows.Add(thisRace.Tables[0].Rows.Count, CalculateY(t1, t2, y1, y2, thisRaceTime));
            average.Tables[0].Rows.Add(average.Tables[0].Rows.Count, CalculateY(t1, t2, y1, y2, avg));
            thisHorse.Tables[0].Rows.Add(thisHorse.Tables[0].Rows.Count, CalculateY(t1, t2, y1, y2, thisHorseTime));
            bestRace.Tables[0].Rows.Add(bestRace.Tables[0].Rows.Count, CalculateY(t1, t2, y1, y2, t2));
            worstRace.Tables[0].Rows.Add(worstRace.Tables[0].Rows.Count, CalculateY(t1, t2, y1, y2, t1));
        }

        private void TimeComparisonCtrl_Load(object sender, EventArgs e)
        {
        }

        public void Clear()
        {
            _graph.Clear();
            _graph.Refresh();
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _popupmenu.Items.Clear();
                
                _popupmenu.Items.Add("Test", null, (object sender22, EventArgs e22) => MessageBox.Show("test"));
                _popupmenu.Show((Control)sender, 10 + e.X, 10 + e.Y);
                
            }
        }
    }
}