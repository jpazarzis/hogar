// *************************************************************
// 
//                           Written By John Pazarzis
// 
// *************************************************************
// 
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
    public partial class FiguresSummaryForm : Form
    {
        private readonly SippRace _race;

        private double _averageFigure = 0;
        private double _minFigure = 0;
        private double _maxFigure = 0;
        private double _stdevFigure = 0;

        public FiguresSummaryForm(SippRace race)
        {
            _race = race;
            InitializeComponent();
        }

        private void SetCellColor(DataGridViewCell cell, Color fore, Color back)
        {
            cell.Style.BackColor = back;
            cell.Style.SelectionBackColor = back;

            cell.Style.ForeColor = fore;
            cell.Style.SelectionForeColor = fore;
        }

        private void UpdateNormalFiguresGrid()
        {
            var programNumberFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);

            _gridNormalFigures.Columns.Add("program-number", "PN");
            _gridNormalFigures.Columns.Add("name", "NAME");

            for (int i = 0; i < 10; ++i)
            {
                string columnName = string.Format("PP_{0}", i);
                _gridNormalFigures.Columns.Add(columnName, columnName);
            }

            SippHorse firstHorse = null;

            foreach (var horse in _race.OrderBy(h => (-1)*h.PrimePower))
            {
                if (horse.Scratched)
                    continue;

                if (null == firstHorse)
                {
                    firstHorse = horse;
                }

                int rowIndex = _gridNormalFigures.Rows.Add();
                var cell = _gridNormalFigures.Rows[rowIndex].Cells;

                _gridNormalFigures.Rows[rowIndex].Tag = horse;

                _gridNormalFigures.Rows[rowIndex].Height = 32;

                cell[0].Value = horse.ProgramNumber;
                cell[1].Value = horse.Name;

                cell[0].Style.Font = programNumberFont;
                if (horse.FirstTimeOut)
                {
                    SetCellColor(cell[0], Color.Yellow, Color.Blue);
                }
                else
                {
                    SetCellColor(cell[0], Color.White, Color.Black);
                }

                cell[0].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                int ppIndex = 0;
                for (int col = 2; col < 12; ++col, ++ppIndex)
                {
                    var c = cell[col];

                    if (ppIndex >= horse.PastPerformances.Count)
                    {
                        c.Style.BackColor = Color.Black;
                        c.Style.SelectionBackColor = Color.Black;
                    }
                    else
                    {
                        c.Style.BackColor = Color.Cyan;
                        c.Style.SelectionBackColor = Color.Cyan;
                        c.Value = horse.PastPerformances[ppIndex].NormalFigure;

                        SetCellColor(c, Color.Navy, horse.PastPerformances[ppIndex].NormalFigureColor);
                    }
                }
            }

            _gridNormalFigures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }

        private void UpdateSpeedFiguresGrid()
        {
            var _figures = new List<double>();
            var f = _race.GetBrisSpeedFiguresForRecentFormCycles();
            _figures.Clear();
            foreach (var i in f)
            {
                _figures.Add(i);
            }

            _averageFigure = _figures.Count > 0 ? _figures.Average() : 0;
            _minFigure = _figures.Count > 0 ? _figures.Min() : 0;
            _maxFigure = _figures.Count > 0 ? _figures.Max() : 0;
            _stdevFigure = _figures.Count > 0 ? RaceViewerControl.CalculateStdDev(_figures) : 0;

            var programNumberFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);

            _grid.Columns.Add("program-number", "PN");
            _grid.Columns.Add("name", "NAME");

            for (int i = 0; i < 10; ++i)
            {
                string columnName = string.Format("PP_{0}", i);
                _grid.Columns.Add(columnName, columnName);
            }

            SippHorse firstHorse = null;

            foreach (var horse in _race.OrderBy(h => (-1)*h.PrimePower))
            {
                if (horse.Scratched)
                    continue;

                if (null == firstHorse)
                {
                    firstHorse = horse;
                }

                int rowIndex = _grid.Rows.Add();
                var cell = _grid.Rows[rowIndex].Cells;

                _grid.Rows[rowIndex].Tag = horse;

                _grid.Rows[rowIndex].Height = 32;

                cell[0].Value = horse.ProgramNumber;
                cell[1].Value = horse.Name;

                cell[0].Style.Font = programNumberFont;
                if (horse.FirstTimeOut)
                {
                    SetCellColor(cell[0], Color.Yellow, Color.Blue);
                }
                else
                {
                    SetCellColor(cell[0], Color.White, Color.Black);
                }

                cell[0].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                int ppIndex = 0;
                for (int col = 2; col < 12; ++col, ++ppIndex)
                {
                    var c = cell[col];

                    if (ppIndex >= horse.PastPerformances.Count)
                    {
                        c.Style.BackColor = Color.Black;
                        c.Style.SelectionBackColor = Color.Black;
                    }
                    else
                    {
                        c.Style.BackColor = Color.Cyan;
                        c.Style.SelectionBackColor = Color.Cyan;
                        c.Value = horse.PastPerformances[ppIndex].SpeedFigure;

                        SetCellColor(c, Color.Navy, GetBackgroundColorForFigure(horse.PastPerformances[ppIndex].SpeedFigure));
                    }
                }
            }

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }

        private void FiguresSummaryForm_Load(object sender, EventArgs e)
        {
            UpdateSpeedFiguresGrid();
            UpdateNormalFiguresGrid();
        }

        private Color GetBackgroundColorForFigure(int speedFigure)
        {
            if (speedFigure >= _averageFigure + 1*_stdevFigure)
            {
                return Color.Red;
            }
            else if (speedFigure >= _averageFigure)
            {
                return Color.LightPink;
            }
            else if (speedFigure >= _averageFigure - 1*_stdevFigure)
            {
                return Color.LightGray;
            }
            else
            {
                return Color.Gray;
            }
        }
    }
}