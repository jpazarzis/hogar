using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExoticStudio
{
    public partial class FrequenciesForm : Form
    {
        FullSystem _fullSystem = null;

        

        public FrequenciesForm(FullSystem fs)
        {
            _fullSystem = fs;
            InitializeComponent();
        }

        private void updateRaceNumbers()
        {
            for (int row = 0; row < _fullSystem.NumberOfRaces; ++row)
            {
                _grid.Rows[row].HeaderCell.Value = (row + _fullSystem.FirstRace).ToString();
            }
        }

        private void FrequenciesForm_Load(object sender, EventArgs e)
        {

            if (null == _fullSystem)
            {
                return;
            }


            _grid.ColumnCount = Tools.MAX_NUMBER_OF_HORSES_PER_RACE;
            _grid.RowCount = _fullSystem.NumberOfRaces;

            updateRaceNumbers();

            for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
            {

                _grid.Columns[col].Width = 40;
                _grid.Columns[col].HeaderText = (col + 1).ToString();

                for (int row = 0; row < _fullSystem.NumberOfRaces; ++row)
                {
                    int frequency = _fullSystem.GetRaceSelection(row).GetFrequency(col + 1);


                    _grid.Rows[row].Height = 40;

                    if (frequency <= 0)
                    {
                        _grid[col, row].Style.BackColor = Color.Gray;
                        _grid[col, row].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        _grid[col, row].Value = frequency;
                        _grid[col, row].Style.BackColor = Color.Red;
                        _grid[col, row].Style.ForeColor = Color.Black;
                    }
                }
            }







            Width = Tools.MAX_NUMBER_OF_HORSES_PER_RACE * 40 + 60;

            
            Height = _fullSystem.NumberOfRaces * 40 + 60;

        }

        private void _grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
