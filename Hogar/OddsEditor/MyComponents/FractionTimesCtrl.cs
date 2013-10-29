using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.BrisPastPerformances;
using Hogar;

namespace OddsEditor.MyComponents
{
    public partial class FractionTimesCtrl : UserControl
    {
        
        public FractionTimesCtrl()
        {
            InitializeComponent();
        }

        public void BindPastPerformance(BrisPastPerformance pp, double diffInSeconds)
        {
            InitializeGrid(_gridRawTimes);
            AddRowToGrid(_gridRawTimes, "Leader", pp.LeadersFirstCall, pp.LeadersSecondCall, pp.LeadersThirdCall, pp.LeadersFinalCall);
            AddRowToGrid(_gridRawTimes, "This", pp.GetFraction(FractionCall.Level.First).FormatedTime, pp.GetFraction(FractionCall.Level.Second).FormatedTime, pp.GetFraction(FractionCall.Level.Stretch).FormatedTime, pp.GetFraction(FractionCall.Level.Final).FormatedTime);

            double d1 = (-1)*(diffInSeconds * pp.FirstFractionInYards) / pp.DistanceInYards;
            double d2 = (-1) * (diffInSeconds * pp.SecondFractionInYards) / pp.DistanceInYards;
            double d3 = (-1) * (diffInSeconds * pp.ThirdFractionInYards) / pp.DistanceInYards;
            double d4 = (-1)*diffInSeconds;

            InitializeGrid(_gridAdjustedTimes);
            AddRowToGrid(_gridAdjustedTimes, "Leader", pp.AdjustedLeadersFirstCall(d1), pp.AdjustedLeadersSecondCall(d2), pp.AdjustedLeadersThirdCall(d3), pp.AdjustedLeadersFinalCall(d4));

            double thisAdjHorseCall1 = pp.GetFraction(FractionCall.Level.First).Time + d1;
            double thisAdjHorseCall2 = pp.GetFraction(FractionCall.Level.Second).Time + d2;
            double thisAdjHorseCall3 = pp.GetFraction(FractionCall.Level.Stretch).Time + d3;
            double thisAdjHorseFinal = pp.GetFraction(FractionCall.Level.Final).Time + d4;


            string t1 = Utilities.ConvertTimeToMMSSFifth(thisAdjHorseCall1.ToString());
            string t2 = Utilities.ConvertTimeToMMSSFifth(thisAdjHorseCall2.ToString());
            string t3 = Utilities.ConvertTimeToMMSSFifth(thisAdjHorseCall3.ToString());
            string t4 = Utilities.ConvertTimeToMMSSFifth(thisAdjHorseFinal.ToString());


            AddRowToGrid(_gridAdjustedTimes, "This", t1, t2, t3, t4);

        }

        private void AddRowToGrid(DataGridView grid, string title, string firstCall, string secondCall, string thirdCall, string FinalCall)
        {
            int rowIndex = grid.Rows.Add();
            DataGridViewRow row = grid.Rows[rowIndex];
            row.HeaderCell.Value = title;
            row.Cells[0].Value = firstCall;
            row.Cells[1].Value = secondCall;
            row.Cells[2].Value = thirdCall;
            row.Cells[3].Value = FinalCall;
        }

        private void InitializeGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Columns.Add("FirstCall", "FirstCall");
            grid.Columns.Add("SecondCall", "SecondCall");
            grid.Columns.Add("ThirdCall", "ThirdCall");
            grid.Columns.Add("FinalTime", "FinalTime");
        }

        private void FractionTimesCtrl_Load(object sender, EventArgs e)
        {

        }
    }
}
