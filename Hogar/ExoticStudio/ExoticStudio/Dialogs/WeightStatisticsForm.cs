using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExoticStudio.Dialogs
{
    public partial class WeightStatisticsForm : Form
    {
        private readonly FullSystem _fullSystem;

        public WeightStatisticsForm(FullSystem fullSystem)
        {
            _fullSystem = fullSystem;

            InitializeComponent();
        }

        private void WeightStatisticsForm_Load(object sender, EventArgs e)
        {
            _gridValue.Tag = _fullSystem.ValueWeightLimitationForTheFullSystem;
            _gridWeight.Tag = _fullSystem.WeightWeightLimitationForTheFullSystem;

            var w = _fullSystem.WeightStatisticsForTheFullSystem;
            LoadGrid(_gridValue, w.Value);
            LoadGrid(_gridWeight, w.Weight);

            w = _fullSystem.WeightStatisticsForTheDevelopedSystem;
            LoadGrid(_gridDevelopedValue, w.Value);
            LoadGrid(_gridDevelopedWeight, w.Weight);


        }



        void LoadGrid(DataGridView grid, Dictionary<int, int> stats)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            grid.Columns.Add("Total", "Total");
            grid.Columns.Add("Count", "Count");

            foreach (int total in stats.Keys)
            {
                int rowIndex = grid.Rows.Add();
                grid[0, rowIndex].Value = total;
                grid[1, rowIndex].Value = stats[total];
                grid.Rows[rowIndex].Tag = total;
                PaintRow(grid, rowIndex);
            }

            grid.Sort(grid.Columns[0], ListSortDirection.Ascending);
        }

        private void PaintRow(DataGridView grid, int index)
        {
            var row = grid.Rows[index];

            int w = (int) grid.Rows[index].Tag;
            
            var limitation = grid.Tag as WeightLimitation;
            
            if(null == limitation)
                return;

            if(limitation.ContainsWeight(w))
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                row.DefaultCellStyle.ForeColor = Color.Gray;
                row.DefaultCellStyle.SelectionForeColor = Color.Gray;

            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Cyan;
                row.DefaultCellStyle.SelectionBackColor = Color.Cyan;
                row.DefaultCellStyle.ForeColor = Color.Navy;
                row.DefaultCellStyle.SelectionForeColor = Color.Navy;
            }
        }

        private void OnGridWasClicked(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if(null == grid)
                return;
            
            int rowIndex = e.RowIndex;

            if(rowIndex< 0)
                return;

            var row = grid.Rows[rowIndex];

            int w = (int) row.Tag;
            var limitation = grid.Tag as WeightLimitation;
            if(null == limitation)
                return;

            if(limitation.ContainsWeight(w))
            {
                limitation.Remove(w);
            }
            else
            {
                limitation.Add(w);
            }

            PaintRow(grid, rowIndex);

            _fullSystem.NeedsToBeCounted = true;
            _fullSystem.NeedsToBeSaved = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
