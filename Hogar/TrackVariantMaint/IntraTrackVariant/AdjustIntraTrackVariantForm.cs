using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.DbTools;
using Hogar;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    public partial class AdjustIntraTrackVariantForm : Form
    {
        private const string SQL_RESET = "delete track_intra_variant";

        private AvgGoldenFigureCollection _avgFigures = null;

        private int _stdAdjColumnIndex = 0;

        private bool _initializing = false;

        public AdjustIntraTrackVariantForm()
        {
            InitializeComponent();
        }

     

        private void UpdateAverageFigures()
        {
            try
            {
                _avgFigures = new AvgGoldenFigureCollection();
                LoadGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadGrid()
        {
            _initializing = true;
            _gridAvgFigures.ReadOnly = false;
            _gridAvgFigures.Rows.Clear();

            _gridAvgFigures.Columns.Clear();

            _gridAvgFigures.Columns.Add("TrackCode", "TrackCode");
            _gridAvgFigures.Columns.Add("Surface", "Surface");
            _gridAvgFigures.Columns.Add("Avg", "Avg");
            _gridAvgFigures.Columns.Add("Adj", "Adj");

            _stdAdjColumnIndex = _gridAvgFigures.Columns.Add("StdAdj", "StdAdj");
            _gridAvgFigures.Columns[_stdAdjColumnIndex].ReadOnly = false;

            foreach (var avgFigure in _avgFigures)
            {
                int rowIndex = _gridAvgFigures.Rows.Add();
                _gridAvgFigures.Rows[rowIndex].Tag = avgFigure;
                var cells = _gridAvgFigures.Rows[rowIndex].Cells;

                cells[0].Value = avgFigure.TrackCode;
                cells[1].Value = avgFigure.Surface;
                cells[2].Value = (int) avgFigure.Figure;
                cells[3].Value = avgFigure.IntraVariant;
                cells[4].Value = avgFigure.StandardAdjustment.ToString();
                cells[4].Tag = avgFigure.StandardAdjustment;

                for (int i = 0; i <= 3; ++i)
                    cells[i].ReadOnly = true;
            }

            _initializing = false;
        }

        private void AdjustIntraTrackVariantForm_Load(object sender, EventArgs e)
        {
            UpdateAverageFigures();
        }

        private void CaclulateIntraTrackVariantClick(object sender, EventArgs e)
        {
            try
            {
                SaveStdAdjustments();
                DbReader.ExecuteNonQuery(SQL_RESET);
                UpdateAverageFigures();
                _avgFigures.CalculateIntraTrackVariant();
                UpdateAverageFigures();
                MessageBox.Show("done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_initializing || e.ColumnIndex != _stdAdjColumnIndex)
                return;

            var cell = _gridAvgFigures[e.ColumnIndex, e.RowIndex];

            int value;
            if (int.TryParse((string) cell.Value, out value))
            {
                cell.Tag = value;
            }
            else
            {
                _initializing = true;
                cell.Value = cell.Tag.ToString();
                _initializing = false;
            }
        }

        private void SaveStdAdjustments()
        {
            foreach (DataGridViewRow row in _gridAvgFigures.Rows)
            {
                var f = row.Tag as AvgGoldenFigure;

                if (f == null)
                    continue;

                int adj;
                if (int.TryParse((string)row.Cells[_stdAdjColumnIndex].Value, out adj))
                {
                    f.StandardAdjustment = adj;
                }
            }

            _avgFigures.SaveStandardAdjustments();
        }

        private void SaveStdAdjustmentsClick(object sender, EventArgs e)
        {
            SaveStdAdjustments();
        }
    }
}