using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using OddsEditor.Dialogs;
using System.Diagnostics;
using OddsEditor.Dialogs.WinnersForDay;

namespace OddsEditor.MyComponents
{
    public partial class CynthiaProjectionsCtrl : UserControl
    {
        private class DistanceInfo
        {
            private string _surface = "";
            public int Distance { get; set; }
            public int NumberOfRacesInTheDistance { get; set; }

            public string Surface { get { return _surface; } set { _surface = value.ToUpper().Trim(); } }
        }

        private Horse _horse;

        private Font _boldFont = null;
        private Font _boldUnderlinedFont = null;
        private Font _boldItalicFont = null;

        private Font _normalFont = null;
        private Font _underlinedFont = null;
        private Font _italicFont = null;

        private int _daysOffColumnIndex = -1;
        private int _daysAgoColumnIndex = -1;
        private int _trackConditionColumnIndex = -1;
        private int _trackCodeColumnIndex = -1;
        private int _classificationColumnIndex = -1;
        private int _distanceColumnIndex = -1;
        private int _firstFractionColumnIndex = -1;
        private int _secondFractionColumnIndex = -1;
        private int _finalPositionColumnIndex = -1;
        private int _brisSpeedFigureIndex = -1;
        //private int _goldenPaceFigureIndex = -1;
        //private int _goldenPaceFigureForThisHorseIndex = -1;
        //private int _goldenFigureForWinnerOfTheRaceColumnIndex = -1;
        //private int _goldenFigureForThisHorseColumnIndex = -1;

        private Color _background;

        private XRayCtrl _xrayCtrl;

        public CynthiaProjectionsCtrl()
        {
            InitializeComponent();
        }

        public void BindXRayCtrl(XRayCtrl ctrl)
        {
            _xrayCtrl = ctrl;
        }

        public void Bind(Horse horse)
        {
            _horse = horse;

            RefreshDisplay();
            horse._updateObserverEvent += UpdateGrid;
            horse._updateRunningLineEvent += UpdateRunningLine;
            var ppc = _horse.CorrespondingBrisHorse.PastPerformances;

            if (null == _xrayCtrl)
            {
                return;
            }

            if (null == ppc || ppc.Count <= 0)
            {
                _xrayCtrl.Clear();
            }
            else
            {
                var pp = ppc[0];
                _xrayCtrl.Bind(pp.Date, pp.TrackCode, pp.Parent.Name, Convert.ToInt32(pp.RaceNumber));
            }

//            LoadDistancesToFlowControl();
        }

  
        private void ShowOrHidePastPerformances(DistanceInfo di, bool show)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var pp = row.Tag as BrisPastPerformance;
                if (null != pp && di.Distance == pp.DistanceInYards && di.Surface == pp.Surface.Trim().ToUpper())
                {
                    row.Visible = show;
                }
            }
        }

        private void RefreshDisplay()
        {
            _boldFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold);
            _boldUnderlinedFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold | FontStyle.Underline);
            _boldItalicFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold | FontStyle.Italic);
            _underlinedFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);
            _italicFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Italic);

            _normalFont = _grid.DefaultCellStyle.Font;

            _grid.Rows.Clear();
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            if (null != _horse)
            {
                int daysBefore = _horse.CorrespondingBrisHorse.DaysSinceLastRace;
                int numberOfPP = _horse.CorrespondingBrisHorse.PastPerformances.Count;
                if (numberOfPP <= 0)
                {
                    return;
                }
                _grid.Rows.Add(numberOfPP);

                for (int i = 0; i < numberOfPP; i++)
                {
                    BrisPastPerformance pp = _horse.CorrespondingBrisHorse.PastPerformances[i];
                    AddPastPerformancesToGrid(pp, i, ref daysBefore);
                }
            }
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

            _grid.BorderStyle = BorderStyle.None;
            _grid.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //_grid.Columns[_firstFractionColumnIndex].DefaultCellStyle.BackColor = Color.Blue;
            //_grid.Columns[_secondFractionColumnIndex].DefaultCellStyle.BackColor = Color.Blue;
            //_grid.Columns[_finalPositionColumnIndex].DefaultCellStyle.BackColor = Color.Blue;
        }

        public void UpdateGrid()
        {
            RefreshDisplay();
        }

        private void AddPastPerformancesToGrid(BrisPastPerformance pp, int rowIndex, ref int daysBefore)
        {
            SetRowColors(pp);

            _grid.Rows[rowIndex].DefaultCellStyle.Font = GetFontToUse(pp);

            DataGridViewCellCollection cells = _grid.Rows[rowIndex].Cells;
            cells[_daysAgoColumnIndex].Value = pp.DaysSinceThatRace;
            cells[_daysOffColumnIndex].Value = pp.DaysSinceLastRace;
            cells[_trackConditionColumnIndex].Value = pp.TrackCondition;
            cells[_trackCodeColumnIndex].Value = pp.TrackCode.ToUpper();
            cells[_classificationColumnIndex].Value = pp.RaceClassification;
            cells[_distanceColumnIndex].Value = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(pp.DistanceInYards);
            cells[_firstFractionColumnIndex].Value = pp.FirstFractionPosition;
            cells[_secondFractionColumnIndex].Value = pp.SecondFractionPosition;
            cells[_finalPositionColumnIndex].Value = pp.FinalPosition;
            cells[_brisSpeedFigureIndex].Value = pp.BrisSpeedRating;
            //cells[_goldenPaceFigureForThisHorseIndex].Value = pp.GoldenPaceFigureForThisHorse;
            //cells[_goldenPaceFigureIndex].Value = pp.GoldenPaceFigureForTheRace;
            //cells[_goldenFigureForWinnerOfTheRaceColumnIndex].Value = pp.GoldenFigureForTheWinner;
            //cells[_goldenFigureForThisHorseColumnIndex].Value = pp.GoldenFigureForThisHorse;



            PaintBrisSpeedFigureCell(cells[_brisSpeedFigureIndex]);
            //PaintGoldenPaceFigureCell(cells[_goldenPaceFigureForThisHorseIndex]);
            //PaintGoldenPaceFigureCell(cells[_goldenPaceFigureIndex]);
            //PaintGoldenFigureCell(cells[_goldenFigureForWinnerOfTheRaceColumnIndex]);
            //PaintGoldenFigureCell(cells[_goldenFigureForThisHorseColumnIndex]);
            
            daysBefore += pp.DaysSinceLastRace;

            Color backColor = pp.IsATurfRace ? Color.LightGreen : Color.White;
            Color foreColor = Color.Black;

            if (!pp.CynthiaParForTheRace.IsValid)
            {
                backColor = Color.LightGray;
                foreColor = Color.Black;
            }

            cells[_trackConditionColumnIndex].Style.BackColor = backColor;
            cells[_trackConditionColumnIndex].Style.SelectionBackColor = backColor;

            cells[_trackConditionColumnIndex].Style.ForeColor = foreColor;
            cells[_trackConditionColumnIndex].Style.SelectionBackColor = foreColor;

            cells[0].Style.BackColor = Color.White;
            cells[0].Style.SelectionBackColor = Color.White;
            cells[0].Style.ForeColor = Color.White;
            cells[0].Style.SelectionForeColor = Color.White;

            _grid.Rows[rowIndex].Tag = pp;

            UpdateSelectedAsRunningLineCell(rowIndex);
        }

        private void PaintGoldenFigureCell(DataGridViewCell cell)
        {
            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (null != cell.Value && (double)cell.Value != -999)
            {
                backColor = Color.Black;
                foreColor = Color.White;
            }

            cell.Style.BackColor = cell.Style.SelectionBackColor = backColor;
            cell.Style.ForeColor = cell.Style.SelectionForeColor = foreColor;
        }



        private static void PaintBrisSpeedFigureCell(DataGridViewCell cell)
        {
            Color backColor = Color.Olive;
            Color foreColor = Color.Wheat;
            cell.Style.BackColor = cell.Style.SelectionBackColor = backColor;
            cell.Style.ForeColor = cell.Style.SelectionForeColor = foreColor;

        }

        private static void PaintGoldenPaceFigureCell(DataGridViewCell cell)
        {
            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if(null != cell.Value &&  (double)cell.Value != -999)
            {
                backColor = Color.DarkTurquoise;
                foreColor = Color.White;
            }

            cell.Style.BackColor = cell.Style.SelectionBackColor = backColor;
            cell.Style.ForeColor = cell.Style.SelectionForeColor = foreColor;

        }

        private void SetRowColors(BrisPastPerformance pp)
        {
            if (pp.DaysSinceLastRace == 0)
            {
                _background = Color.White;
            }
            else if (pp.DaysSinceLastRace >= Utilities.LAYOFF_DAYS)
            {
                _background = _background == Color.White ? Color.LightGray : Color.White;
            }
        }

        private void UpdateRunningLine(Horse horse)
        {
            for (int i = 0; i < _grid.Rows.Count; ++i)
            {
                UpdateSelectedAsRunningLineCell(i);
            }
        }

        private void UpdateSelectedAsRunningLineCell(int rowIndex)
        {
            DataGridViewCellCollection cells = _grid.Rows[rowIndex].Cells;
            var pp = _grid.Rows[rowIndex].Tag as BrisPastPerformance;

            if (_horse.SelectedRunningLine == pp)
            {
                cells[0].Value = Properties.Resources.Pointer;
            }
            else
            {
                cells[0].Value = Properties.Resources.NonPointer;
            }
        }

        private Font GetFontToUse(BrisPastPerformance pp)
        {
            Font f = pp.IsARoute ? _boldFont : _normalFont;
            if (pp.DaysSinceLastRace >= Utilities.LAYOFF_DAYS)
            {
                f = new Font(f, FontStyle.Underline);
            }
            return f;
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _grid.Columns.Clear();
            _grid.Columns.Add(new DataGridViewImageColumn());
            _daysOffColumnIndex = _grid.Columns.Add("DaysOff", "DaysOff");
            _daysAgoColumnIndex = _grid.Columns.Add("DaysAgo", "DaysAgo");
            _trackConditionColumnIndex = _grid.Columns.Add("TrackCondition", "TrackCondition");
            _trackCodeColumnIndex = _grid.Columns.Add("TrackCode", "TrackCode");
            _classificationColumnIndex = _grid.Columns.Add("Classification", "Classification");
            _distanceColumnIndex = _grid.Columns.Add("Distance", "Distance");
            _firstFractionColumnIndex = _grid.Columns.Add("FirstFractionPosition", "FirstFractionPosition");
            _secondFractionColumnIndex = _grid.Columns.Add("SecondFractionPosition", "SecondFractionPosition");
            _finalPositionColumnIndex = _grid.Columns.Add("FinalPosition", "FinalPosition");
            _brisSpeedFigureIndex = _grid.Columns.Add("FinalPosition", "BrisSpeedFigure");
            //_goldenPaceFigureForThisHorseIndex = _grid.Columns.Add("GoldenPaceFigureThisHorse", "GoldenPaceFigureThisHorse");
            //_goldenPaceFigureIndex = _grid.Columns.Add("GoldenPaceFigure", "GoldenPaceFigure");
            //_goldenFigureForThisHorseColumnIndex = _grid.Columns.Add("GoldenFigure", "GoldenFigure");
            //_goldenFigureForWinnerOfTheRaceColumnIndex = _grid.Columns.Add("WinnersGoldenFigure", "WinnersGoldenFigure");
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var pp = _grid.Rows[e.RowIndex].Tag as BrisPastPerformance;
                Debug.Assert(null != pp);
                _horse.SelectedRunningLine = pp;
                for (int i = 0; i < _grid.Rows.Count; ++i)
                {
                    UpdateSelectedAsRunningLineCell(i);
                }
            }
            else
            {
                try
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                    {
                        var pp = (BrisPastPerformance) _grid.Rows[e.RowIndex].Tag;

                        if (e.ColumnIndex == 1)
                        {
                            ShowFractionsForTheDayForm.DisplayModal(pp);
                        }
                        else
                        {
                            _xrayCtrl.Bind(pp.Date, pp.TrackCode, pp.Parent.Name, Convert.ToInt32(pp.RaceNumber));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}