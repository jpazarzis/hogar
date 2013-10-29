using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Handicapping.Analysis;
using Hogar.Handicapping;


namespace OddsEditor.Dialogs
{
    public partial class FilterFactorsForm : Form
    {
        readonly Horse _horse;

        readonly List<FactorPerformance> _selectedFactors = new List<FactorPerformance>();


        readonly List<FactorPerformance> _originalSelectedFactors;

        

        public FilterFactorsForm(Horse horse, List<FactorPerformance> selectedFactors)
        {
            _horse = horse;
            _originalSelectedFactors = selectedFactors;
            CopyFPList(_originalSelectedFactors, _selectedFactors);
            InitializeComponent();
        }

        

        void CopyFPList(List<FactorPerformance> source, List<FactorPerformance> dest)
        {
            dest.Clear();
            foreach (FactorPerformance fp in source)
            {
                dest.Add(fp);
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            if (_horse == null) return;
            CopyFPList(_originalSelectedFactors, _selectedFactors);
            _grid.Columns.Clear();
            
            _grid.Columns.Add("FactorName", "FactorName");
            //////List<Factor> list = _horse.CorrespondingBrisHorse.GetMatchingHandicappingFactors(_horse);

            if (null != _horse.MatchingFactors)
            {
                DataTable dt = _horse.MatchingFactors.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    FactorPerformance fp = (FactorPerformance)row["F"];
                    List<string> names = fp.FactorNames;
                    if (names.Count != 1)
                    {
                        continue;
                    }

                    int rowIndex = _grid.Rows.Add();

                    _grid.Rows[rowIndex].Cells[0].Value = names[0];
                    _grid.Rows[rowIndex].Tag = fp;
                }

                UpdateAllRowsColor();
            }

            
            
        }

        void UpdateAllRowsColor()
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                UpdateRowColor(row);
            }
        }

        private void UpdateRowColor(DataGridViewRow row)
        {
            Color backColor = Color.White;
            Color frontColor = Color.Black;

            if (_selectedFactors.Contains((FactorPerformance)row.Tag))
            {
                backColor = Color.Red;
                frontColor = Color.White;
            }
            row.DefaultCellStyle.BackColor = backColor;
            row.DefaultCellStyle.SelectionBackColor= backColor;

            row.DefaultCellStyle.ForeColor = frontColor;
            row.DefaultCellStyle.SelectionForeColor = frontColor;

        }

        private void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = _grid.Rows[e.RowIndex];
                FactorPerformance fp = (FactorPerformance)row.Tag;
                if (_selectedFactors.Contains(fp))
                {
                    _selectedFactors.Remove(fp);
                }
                else
                {
                    _selectedFactors.Add(fp);
                }
                
                UpdateRowColor(row);
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CopyFPList(_selectedFactors, _originalSelectedFactors);
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            _selectedFactors.Clear();
            foreach (DataGridViewRow row in _grid.Rows)
            {
                _selectedFactors.Add((FactorPerformance)row.Tag);
            }
            UpdateAllRowsColor();
        }

        private void OnUnselectAll(object sender, EventArgs e)
        {
            _selectedFactors.Clear();
            UpdateAllRowsColor();
        }
    }
}
