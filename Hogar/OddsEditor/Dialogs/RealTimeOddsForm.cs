using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs
{
    public partial class RealTimeOddsHistoryForm : Form
    {
        readonly Horse _horse;
        readonly DataTable _exactaPayouts;

        public RealTimeOddsHistoryForm(Horse horse, DataTable exactaPayouts)
        {
            _horse = horse;
            _exactaPayouts = exactaPayouts;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _labelHorseName.Text = _horse.Name;
            _grid.Columns.Clear();
            
            _grid.Columns.Add("Time", "Time");
            _grid.Columns.Add("Odds", "Odds");

            Dictionary<DateTime, Odds> odds = _horse.RealTimeOddsHistory;

            foreach (KeyValuePair<DateTime, Odds> pair in odds)
            {
                int index = _grid.Rows.Add();

                _grid[0, index].Value = pair.Key.ToLongTimeString();
                _grid[1, index].Value = pair.Value;
            }


            OnRefreshExactaPayouts(null, null);
           

        }

        private void OnRefreshExactaPayouts(object sender, EventArgs e)
        {
            _gridExacta.DataSource = _exactaPayouts;

            for (int i = 0; i < _gridExacta.Rows.Count; ++i)
            {
                _gridExacta.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            for (int col = 0; col < _gridExacta.Columns.Count; ++col)
            {
                for (int row = 0; row < _gridExacta.Rows.Count; ++row)
                {
                    if (0.0 == (double)_gridExacta[col, row].Value)
                    {
                        _gridExacta[col, row].Style.BackColor = Color.Black;
                        _gridExacta[col, row].Style.ForeColor = Color.Black;
                    }
                }
            }
           
        }


    }
}
