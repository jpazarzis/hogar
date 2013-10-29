using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class TrainerFilterForm : Form
    {
        int _minLayoff = 0;
        int _maxLayoff = 9999;

        double _minOdds = 0.0;
        double _maxOdds = 1000.00;

        public TrainerFilterForm()
        {
            InitializeComponent();
        }


        private void OnInitialLoad(object sender, EventArgs e)
        {
            
            _txtboxMinLayoff.Text = _minLayoff.ToString();
            _txtboxMaxLayoff.Text = _maxLayoff.ToString();
            _txtboxMinOdds.Text = _minOdds.ToString();
            _txtboxMaxOdds.Text = _maxOdds.ToString();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void FilterGrid(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Visible = MatchesFilter(row);
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private bool MatchesFilter(DataGridViewRow row)
        {
            return MatchesLayoff(row) && MatchesSurface(row) && MatchesOdds(row) && MatchesDistance(row);
        }

        private bool MatchesSurface(DataGridViewRow row)
        {
            string surface = (string)row.Cells["S"].Value;
            surface = surface.Trim().ToUpper();
            if (surface.Contains("T"))
            {
                return _checkBoxTurf.Checked;
            }
            else if (surface.Contains("D"))
            {
                return _checkBoxDirt.Checked;
            }
            else
            {
                return true;
            }
        }

        private bool MatchesLayoff(DataGridViewRow row)
        {
            int layoff = (int)row.Cells["D1"].Value;
            return layoff >= _minLayoff && layoff <= _maxLayoff;
        }

        private bool MatchesDistance(DataGridViewRow row)
        {
            int distance = (int)row.Cells["RawDistance"].Value;
            if (distance >= 1600)
            {
                return _checkBoxRoute.Checked;
            }
            else
            {
                return _checkBoxSprint.Checked;
            }
            
        }

        private bool MatchesOdds(DataGridViewRow row)
        {
            double odds = (double)row.Cells["O"].Value;
            return odds >= _minOdds && odds <= _maxOdds;
        }

        private void OnOK(object sender, EventArgs e)
        {
            _minLayoff = 0;
            _maxLayoff = 9999;
            _minOdds = 0.0;
            _maxOdds = 1000.00;
            try
            {
                _minLayoff = Convert.ToInt32(_txtboxMinLayoff.Text);
                _maxLayoff = Convert.ToInt32(_txtboxMaxLayoff.Text);

                _minOdds = Convert.ToDouble(_txtboxMinOdds.Text);
                _maxOdds = Convert.ToDouble(_txtboxMaxOdds.Text);
            }
            catch
            {
            }
            DialogResult = DialogResult.OK;
        }      
    }
}
