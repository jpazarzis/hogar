using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.BrisPastPerformances;

namespace OddsEditor.MyComponents
{
    public partial class ShowRunTogethersControl : UserControl
    {
        readonly HorseFractionsComponent _hfc = null;


        public ShowRunTogethersControl()
        {
            InitializeComponent();
        }

        public ShowRunTogethersControl(HorseFractionsComponent hfc)
        {
            _hfc = hfc;
            InitializeComponent();
        }

        public void BindHorse(BrisHorse brisHorse)
        {
            _grid.Columns.Clear();
            _grid.Columns.Add("Date", "Date");
            _grid.Columns.Add("Track", "Track");
            _grid.Columns.Add("ProgramNumber", "PN");
            _grid.Columns.Add("Name", "Name");
            _grid.Columns.Add("Position", "Pos");

            foreach (BrisPastPerformance h in brisHorse.RunTogethers)
            {
                int index = _grid.Rows.Add();

                _grid["Date", index].Value = h.DateAsString;
                _grid["Track", index].Value = h.RaceNumber+h.TrackCode;
                _grid["ProgramNumber", index].Value = h.Parent.ProgramNumber;
                _grid["Name", index].Value = h.Parent.Name;
                _grid["Position", index].Value = h.FinalPosition;

                BrisPastPerformance pp = brisHorse.GetPastPerformance(h.TrackCode, h.Date, h.RaceNumber);

                if (null != pp)
                {
                    if (Convert.ToInt32(pp.FinalPosition) > Convert.ToInt32(h.FinalPosition))
                    {
                        _grid.Rows[index].DefaultCellStyle.BackColor = Color.Beige;
                        _grid.Rows[index].DefaultCellStyle.SelectionBackColor = Color.Beige;
                        _grid.Rows[index].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    else
                    {
                        _grid.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        _grid.Rows[index].DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                        _grid.Rows[index].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
        }


        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < _grid.Rows.Count)
            {
                string date = (string)_grid["Date", index].Value;

                if (null != _hfc)
                {
                    _hfc.SelectRow(date);
                }
            }
        }

        
        
    }
}