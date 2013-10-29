using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Hogar;
using Hogar.Betting.Superfecta;

namespace OddsEditor.Dialogs.SuperStudio
{
    public partial class SuperStudioForm : Form
    {
        readonly Race _race;
        SuperfectaSystem _ss = null;

        public SuperStudioForm(Race race, SuperfectaSystem ss)
        {
            _race = race;
            _ss = ss;
            InitializeComponent();
        }


        
        

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _grid.Columns.Clear();
            _grid.Columns.Add("Num", "Num");
            _grid.Columns.Add("Name", "Name");
            _grid.Columns.Add("1", "1");
            _grid.Columns.Add("2", "2");
            _grid.Columns.Add("3", "3");
            _grid.Columns.Add("4", "4");
            _grid.Columns.Add("M", "M");

            int w = 60;
            for (int i = 2; i <= 6; ++i)
            {
                _grid.Columns[i].Width = w;
            }

            _grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            List<int> horseNumber = new List<int>();
            foreach (Horse horse in _race.Horses)
            {
                int num = horse.GetProgramNumberWithoutEntryChar();

                if (horse.Scratched || horseNumber.Contains(num))
                {
                    continue;
                }

                int index = _grid.Rows.Add();
                _grid[0, index].Value = num;
                horseNumber.Add(num);
                _grid[1, index].Value = horse.Name;
                _grid.Rows[index].Tag = num;
            }

            foreach (DataGridViewRow row in _grid.Rows)
            {
                for (int col = 2; col <= 5; ++col)
                {
                    PaintSelectionCell(row, col);
                }

                PaintMandatoryHorseCell(row);
            }

            _grid.Sort(_grid.Columns[0], ListSortDirection.Ascending);

            foreach (DataGridViewColumn column in _grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            CountSystem();
        }

        private void PaintSelectionCell(DataGridViewRow row, int col)
        {
            int pos = col - 2;
            int horseNumber = (int)row.Tag;
            bool isSelected = _ss.IsHorseSelected(pos, horseNumber);
            row.Cells[col].Style.BackColor = (isSelected ? Color.Red : Color.White);
            row.Cells[col].Style.SelectionBackColor = row.Cells[col].Style.BackColor;
        }

        private void PaintMandatoryHorseCell(DataGridViewRow row)
        {
            MandatoryHorseLimitation m = new MandatoryHorseLimitation((int)row.Tag);
            int col = 6;
            Color color = _ss.ContainsLimitation(m) ? Color.Green : Color.White;
            row.Cells[col].Style.BackColor = color;
            row.Cells[col].Style.SelectionBackColor = color;
        }


        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex >= 2 && e.ColumnIndex <= 5)
            {
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    int col = e.ColumnIndex;
                    int pos = col - 2;
                    _ss.RemoveHorse(pos, (int)row.Tag);
                    PaintSelectionCell(row, col);
                }
                CountSystem();
                _gridDevelopedCombinations.Columns.Clear();
            }
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool selectionsChanged = false;
            
            if (e.RowIndex < 0 && e.ColumnIndex >=2 && e.ColumnIndex <=5)
            {
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    int col = e.ColumnIndex;
                    int horseNumber = (int)row.Tag;
                    int pos = col - 2;
                    _ss.AddHorse(pos, horseNumber);
                    PaintSelectionCell(row, col);
                    selectionsChanged = true;
                }
                
            }
            else if (e.RowIndex >= 0)
            {
                int col = e.ColumnIndex;
                int horseNumber = (int)_grid.Rows[e.RowIndex].Tag;
                if (col >= 2 && col <= 5)
                {
                    int pos = col - 2;
                    _ss.ToggleHorse(pos, horseNumber);

                    PaintSelectionCell(_grid.Rows[e.RowIndex], col);
                    selectionsChanged = true;
                }
                else if(col == 6)
                {
                    MandatoryHorseLimitation m = new MandatoryHorseLimitation(horseNumber);
                    if (_ss.ContainsLimitation(m))
                    {
                        _ss.RemoveLimitation(m);
                    }
                    else
                    {
                        _ss.AddLimitation(m);
                    }

                    PaintMandatoryHorseCell(_grid.Rows[e.RowIndex]);
                    selectionsChanged = true;
                }
            }

            if (selectionsChanged)
            {
                CountSystem();
               // _gridDevelopedCombinations.Columns.Clear();
            }
        }


        private void CountSystem()
        {

            int fullSystemCount = _ss.FullSystemCount;
            int developedCount = _ss.CombinationsCount;

            double f = (double)fullSystemCount;
            double d = (double)developedCount;
            double economy = (f== 0.00 ? 0.0 : (f - d) * 100.0 / f);

            _txtboxFullSystemCount.Text = fullSystemCount.ToString();
            _txtboxDevelopedSystemCount.Text = developedCount.ToString();
            _txtboxEconomy.Text = string.Format("{0:0.0}%",economy);
            
        }

        private void OnShowDevelopedCombinations(object sender, EventArgs e)
        {
            int total = 0;
            Cursor = Cursors.WaitCursor;
            try
            {
                _gridDevelopedCombinations.Columns.Clear();
                _gridDevelopedCombinations.Columns.Add("1st", "1st");
                _gridDevelopedCombinations.Columns.Add("2nd", "2nd");
                _gridDevelopedCombinations.Columns.Add("3rd", "3rd");
                _gridDevelopedCombinations.Columns.Add("4th", "4th");
                _gridDevelopedCombinations.Columns.Add("Count", "Count");

                foreach (SuperfectaSystem ss in _ss.DevelopSubSystems())
                {
                    int index = _gridDevelopedCombinations.Rows.Add();
                    _gridDevelopedCombinations[0, index].Value = ss.GetRaceSelections(0).ToString();
                    _gridDevelopedCombinations[1, index].Value = ss.GetRaceSelections(1).ToString();
                    _gridDevelopedCombinations[2, index].Value = ss.GetRaceSelections(2).ToString();
                    _gridDevelopedCombinations[3, index].Value = ss.GetRaceSelections(3).ToString();
                    _gridDevelopedCombinations[4, index].Value = ss.CombinationsCount.ToString();

                    total += ss.CombinationsCount;
                }

                _txtboxTotal.Text = total.ToString();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        
    }
}
