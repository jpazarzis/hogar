using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.Handicapping;
using Hogar.Handicapping.Analysis;
using OddsEditor.Dialogs;
using System.Data;
using System.Diagnostics;

namespace OddsEditor.MyComponents
{
    public partial class FactorPerfomanceCtrl : UserControl
    {
        string _trackCode = "";
        long _raceAttributes = 0;
        Horse _horse = null;
        readonly List<FactorPerformance> _selectedFactors = new List<FactorPerformance>();

        public FactorPerfomanceCtrl()
        {
            InitializeComponent();
        }

        private void InitializeSelectedFactors()
        {
            _selectedFactors.Clear();

            if (null != _horse.MatchingFactors)
            {
                DataTable dt = _horse.MatchingFactors.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    FactorPerformance fp = (FactorPerformance)row["F"];
                    if (fp.FactorNames.Count == 1)
                    {
                        _selectedFactors.Add(fp);
                    }
                }
            }
        }

        public void BindHorse(Horse horse)
        {
            _trackCode = "";
            _horse = horse;
           

            if (null != horse && null != horse.MatchingFactors)
            {
                DataTable dt = horse.MatchingFactors.Tables[0];

                List<DataRow> rowsToDelete = new List<DataRow>();
                foreach (DataRow dr in dt.Rows)
                {
                    if ((int)dr["M"] == 1)
                    {
                        rowsToDelete.Add(dr);
                    }
                }

                foreach (DataRow dr in rowsToDelete)
                {
                    dt.Rows.Remove(dr);
                }

                _grid.DataSource = dt;
                _trackCode = horse.CorrespondingBrisHorse.Parent.Parent.TrackCode;
                _raceAttributes = horse.Parent.RaceAttributesFlag;
                _grid.Columns["ROI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _grid.Columns["ROI"].DefaultCellStyle.Format = "##.00";
                _grid.Columns["IV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _grid.Columns["IV"].DefaultCellStyle.Format = "##.00";
                _grid.Sort(_grid.Columns["ROI"], ListSortDirection.Descending);
                _grid.Columns["M"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _grid.Columns["W"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                InitializeSelectedFactors();
            }
        }

        private FactorPerformance GetFPFromRow(DataGridViewRow row)
        {
            if (null != row.Cells[0].Value && row.Cells[0].Value is FactorPerformance)
            {
                return row.Cells[0].Value as FactorPerformance;
            }
            else
            {
                return null;
            }
        }

        private void PaintRow(DataGridViewRow row)
        {
            FactorPerformance fp = GetFPFromRow(row);
            if(null !=fp)
            {
                row.Cells[0].ToolTipText = fp.FactorNamesAsString;
            }

            if (null != row.Cells["ROI"].Value)
            {
                
                double ROI = (double)row.Cells["ROI"].Value;



                if (ROI >= PrimeBetRequirements.Singleton.MinROI)
                {
                    row.Cells["ROI"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells["ROI"].Style.BackColor = Color.White;
                }

                double IV = (double)row.Cells["IV"].Value;
                if (IV >= PrimeBetRequirements.Singleton.MinIV)
                {
                    row.Cells["IV"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells["IV"].Style.BackColor = Color.White;
                }
            }
        }

        private void OnCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = _grid.Rows[e.RowIndex];
                PaintRow(row);
            }
        }

        private void OnCellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    Cursor = Cursors.WaitCursor;  
                    FactorPerformance fp = GetFPFromRow(_grid.Rows[index]);
                    Cursor = Cursors.Default;
                    if (null != fp)
                    {
                        List<Factor> factors = new List<Factor>();
                        foreach (string fname in fp.FactorNames)
                        {
                            factors.Add(Factor.GetFactorByName(fname));
                        }
                        HorsesMatchingFactorsForm f = new HorsesMatchingFactorsForm(factors, _trackCode, _raceAttributes);
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid factor performance object");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnEditAttributes(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void OnFilter(object sender, EventArgs e)
        {
            try
            {
                var faf = new FactorAnalysisForm(_horse);
                faf.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return;

            try
            {

                


                if (null == _horse)
                {
                    return;
                }

                FilterFactorsForm f = new FilterFactorsForm(_horse, _selectedFactors);
                
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _grid.CurrentCell = null;
                    _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    
                    foreach (DataGridViewRow row in _grid.Rows)
                    {
                        bool rowVisibility = false;

                        FactorPerformance fp = (FactorPerformance)row.Cells["F"].Value;
                        foreach (FactorPerformance f1 in _selectedFactors)
                        {
                            string name = f1.FactorNames[0];
                            if (fp.FactorNames.Contains(name))
                            {
                                rowVisibility = true;
                                break;
                            }
                        }

                        row.Visible = rowVisibility;
                    }

                    _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      
    }
}
