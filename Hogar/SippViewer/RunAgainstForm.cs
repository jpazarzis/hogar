using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    public partial class RunAgainstForm : Form
    {

        private Font _boldFont = null;
        private readonly SippPastPerformance _pp;
        public RunAgainstForm(SippPastPerformance pp)
        {
            _pp = pp;
            InitializeComponent();
        }

        private void HighlightPPGrid()
        {
            _gridPP.Columns["Odds"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            _gridPP.RowsDefaultCellStyle.BackColor = Color.White;
            _gridPP.RowsDefaultCellStyle.ForeColor = Color.Black;
            _gridPP.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _gridPP.RowsDefaultCellStyle.SelectionBackColor = _gridPP.RowsDefaultCellStyle.BackColor;

            _gridPP.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
            _gridPP.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            _gridPP.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.AntiqueWhite;
            _gridPP.AlternatingRowsDefaultCellStyle.SelectionBackColor = _gridPP.AlternatingRowsDefaultCellStyle.BackColor;
        }

        private void RunAgainstForm_Load(object sender, EventArgs e)
        {
            _boldFont = new Font(_gridPP.DefaultCellStyle.Font.FontFamily, _gridPP.DefaultCellStyle.Font.Size, FontStyle.Bold);
            _txtboxTrack.Text = _pp.TrackCode;
            _tbCondition.Text = _pp.TrackCondition;
            _tbDate.Text = _pp.RacingDate.ToString("MM/dd/yyyy");
            _tbDistance.Text = _pp.Distance;
            _tbRaceClassification.Text = _pp.RaceCondition;
            _tbRaceNumber.Text = _pp.RaceNumber.ToString();
            _tbSurface.Text = _pp.Surface;
            _tbFirstCall.Text = _pp.FirstCall;
            _tbSecondCall.Text = _pp.SecondCall;
            _tbThirdCall.Text = _pp.ThirdCall;
            _tbFinalTime.Text = _pp.FinalTime;
            _tbTrackVariant.Text = _pp.TrackVariant.ToString();

            var cpp = new List<CondensedPastPerformance>();
            foreach (var pp in _pp.RunAgainst)
            {
                cpp.Add(new CondensedPastPerformance {ExternalPP = pp});
            }
            cpp.Add(new CondensedPastPerformance { ExternalPP = _pp });


            _gridPP.DataSource = cpp.OrderBy(c1=>c1.FinalPosition).ToList();
            _gridPP.Columns["ExternalPP"].Visible = false;

            HighlightPPGrid();
        }

        private void _txtboxTrack_TextChanged(object sender, EventArgs e)
        {

        }

         class CondensedPastPerformance
        {
        
            public CondensedPastPerformance()
            {
            
            }

            public SippPastPerformance ExternalPP { get; set; }

            public string ProgramNumber { get { return ExternalPP.Parent.ProgramNumber; } }
            public string HorseName { get { return ExternalPP.Parent.Name; } }
            public int PostPosition { get { return ExternalPP.PostPosition; } }
            public string FirstCallPosition { get { return ExternalPP.FirstCallPosition; } }
            public string FirstCallLengthsBehind { get { return ExternalPP.FirstCallLengthsBehind; } }
            public string SecondCallPosition { get { return ExternalPP.SecondCallPosition; } }
            public string SecondCallLengthsBehind { get { return ExternalPP.SecondCallLengthsBehind; } }
            public string ThirdCallPosition { get { return ExternalPP.ThirdCallPosition; } }
            public string ThirdCallLengthsBehind { get { return ExternalPP.ThirdCallLengthsBehind; } }
            public int FinalPosition { get { return Convert.ToInt32(ExternalPP.FinalPosition); } }
            public string FinalLengthsBehind { get { return ExternalPP.FinalLengthsBehind; } }
            public int SpeedFigure { get { return ExternalPP.SpeedFigure; } }
            public string Jockey { get { return ExternalPP.Jockey; } }
            public string MedicationWeightEquipment { get { return ExternalPP.MedicationWeightEquipment; } }
            public string Odds { get { return ExternalPP.Odds; } }
          

             

        }

         private Color GetColorForCallPosition(int rowIndex, string columnName)
         {
             try
             {
                 int pos = Convert.ToInt32(_gridPP[columnName, rowIndex].Value.ToString().Trim());

                 switch (pos)
                 {
                     case 1:
                         return Color.Red;
                     case 2:
                         return Color.LightGreen;
                     case 3:
                     case 4:
                     case 5:
                         return Color.White;
                     default:
                         return Color.LightGray;
                 }
             }
             catch
             {
                 return Color.Black;
             }
         }

         private void PaintBrisSpeedFigureCell(int rowIndex, string columnName)
         {
             Color backColor = Color.Olive;
             Color foreColor = Color.Wheat;

             _gridPP[columnName, rowIndex].Style.BackColor = backColor;
             _gridPP[columnName, rowIndex].Style.ForeColor = foreColor;

             _gridPP[columnName, rowIndex].Style.SelectionBackColor = backColor;
             _gridPP[columnName, rowIndex].Style.SelectionForeColor = foreColor;

             _gridPP[columnName, rowIndex].Style.Font = _boldFont;
             _gridPP[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
         }

         private void _gridPP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
         {
             if (e.ColumnIndex == 1)
             {
                 int row = e.RowIndex;
                 
                 _gridPP["FirstCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FirstCallPosition");
                 _gridPP["SecondCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "SecondCallPosition");
                 _gridPP["ThirdCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "ThirdCallPosition");
                 _gridPP["FinalPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FinalPosition");

                 PaintBrisSpeedFigureCell(e.RowIndex, "SpeedFigure");

                 Color distanceColor = Color.LightCyan;

                 _gridPP["FirstCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                 _gridPP["SecondCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                 _gridPP["ThirdCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                 _gridPP["FinalLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                 _gridPP["PostPosition", e.RowIndex].Style.BackColor = Color.LightSalmon;


                 var pp = (CondensedPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem;

                // _gridPP["NormalFigure", e.RowIndex].Style.BackColor = pp.NormalFigureColor;
                 //_gridPP["NormalFigure", e.RowIndex].Style.SelectionBackColor = pp.NormalFigureColor;


                 


                 foreach (DataGridViewCell cell in _gridPP.Rows[e.RowIndex].Cells)
                 {
                     cell.Style.SelectionBackColor = cell.Style.BackColor;
                     cell.Style.SelectionForeColor = cell.Style.ForeColor;
                 }
             }
         }
    }

    
}
