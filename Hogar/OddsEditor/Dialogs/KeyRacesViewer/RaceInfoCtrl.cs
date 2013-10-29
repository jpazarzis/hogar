using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.KeyRaces;

namespace OddsEditor.Dialogs.KeyRacesViewer
{
    public partial class RaceInfoCtrl : UserControl
    {
        private readonly RaceInfo _raceInfo;

        private Font _boldFont;
        public RaceInfoCtrl(RaceInfo raceInfo)
        {
            _raceInfo = raceInfo;
            InitializeComponent();
        }

        private void RaceInfoCtrl_Load(object sender, EventArgs e)
        {
            _boldFont = new Font(_grid.DefaultCellStyle.Font.FontFamily, _grid.DefaultCellStyle.Font.Size, FontStyle.Bold);
            _labelGoldenFigure.Text = _raceInfo.GoldenFigure.ToString();
            _labelGoldenPaceFigure.Text = _raceInfo.GoldenPaceFigure.ToString();
            _tbTrackCode.Text = _raceInfo.TrackCode;
            _labelDaysSinceThisRace.Text = _raceInfo.DaysSince.ToString();
            _tbDistance.Text = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(_raceInfo.Distance);
            _tbSurface.Text = _raceInfo.Surface;
            _tbTrackCondition.Text = _raceInfo.TrackCondition;
            _tbRaceClassification.Text = _raceInfo.RaceClassification;
            _tbDate.Text = _raceInfo.Date;

            var hiddenColumns = new List<string>();
            _grid.DataSource = _raceInfo.GetFractionsAsDataTable(hiddenColumns).Tables[0];
            HighlightGrid();
            foreach (DataGridViewColumn column in _grid.Columns)
            {
                if (hiddenColumns.Contains(column.HeaderText))
                {
                    column.Visible = false;
                }
            }
        }

        private void HighlightGrid()
        {
            
        
            _grid.RowsDefaultCellStyle.BackColor = Color.White;
            _grid.RowsDefaultCellStyle.ForeColor = Color.Black;
            _grid.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _grid.RowsDefaultCellStyle.SelectionBackColor = _grid.RowsDefaultCellStyle.BackColor;

            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            _grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            _grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = _grid.AlternatingRowsDefaultCellStyle.BackColor;
        }

        public RaceInfo RaceInfo
        {
            get
            {
                return _raceInfo;
            }
        }

        private void PaintGoldenPaceFigureCell(int rowIndex, string columnName)
        {
            int goldenFigure = 0;

            int.TryParse(_grid[columnName, rowIndex].Value.ToString(), out goldenFigure);

            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (goldenFigure != -999)
            {
                backColor = Color.DarkTurquoise;
                foreColor = Color.White;
            }

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void PaintGoldenFigureCell(int rowIndex, string columnName)
        {
            int goldenFigure = 0;

            int.TryParse(_grid[columnName, rowIndex].Value.ToString(), out goldenFigure);

            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (goldenFigure != -999)
            {
                backColor = Color.Black;
                foreColor = Color.White;
            }

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            
        }

        private Color GetColorForCallPosition(int rowIndex, string columnName)
        {
            try
            {
                int pos = Convert.ToInt32(_grid[columnName, rowIndex].Value.ToString().Trim());

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

        
        private void _grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                PaintGoldenPaceFigureCell(e.RowIndex, "GoldenPaceFigureForThisHorse");
                PaintGoldenPaceFigureCell(e.RowIndex, "GoldenPaceFigure");
                PaintGoldenFigureCell(e.RowIndex, "GoldenFigure");
                PaintGoldenFigureCell(e.RowIndex, "GoldenFigureForWinnerOfRace");

                _grid["FirstCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FirstCallPosition");
                _grid["FirstCallPosition", e.RowIndex].Style.SelectionBackColor = GetColorForCallPosition(e.RowIndex, "FirstCallPosition");

                _grid["SecondCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "SecondCallPosition");
                _grid["SecondCallPosition", e.RowIndex].Style.SelectionBackColor = GetColorForCallPosition(e.RowIndex, "SecondCallPosition");
                
                _grid["StretchCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "StretchCallPosition");
                _grid["StretchCallPosition", e.RowIndex].Style.SelectionBackColor= GetColorForCallPosition(e.RowIndex, "StretchCallPosition");
                
                _grid["FinalCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FinalCallPosition");
                _grid["FinalCallPosition", e.RowIndex].Style.SelectionBackColor= GetColorForCallPosition(e.RowIndex, "FinalCallPosition");

            }
        }
    }
}
