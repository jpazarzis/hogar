using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.MyComponents
{
    public partial class OddsControl : UserControl
    {
        readonly List<int> _horsenumbers = new List<int>();
        readonly Dictionary<int, Odds> _odds = new Dictionary<int, Odds>();

        public delegate void OddsWereChangedDelegate();

        public event OddsWereChangedDelegate OddsWereChangedEvent;

        public OddsControl()
        {
            InitializeComponent();
        }

        public Dictionary<int, Odds> GetOdds()
        {
            return _odds;
        }

        public void SetOdds(SortedDictionary<int, Odds> odds)
        {
            _horsenumbers.Clear();
            _odds.Clear();
            foreach (KeyValuePair<int,Odds> kvp in odds)
            {
                int number = kvp.Key;
                Odds horseodds = kvp.Value;
                _horsenumbers.Add(number);
                _odds.Add(number, horseodds);
            } 

            PaintGrid();

        }

        void PaintGrid()
        {
            _grid.Columns.Add("Number", "Number");
            _grid.Columns.Add("Odds","Odds");


            _grid.Columns["Number"].Width = 70;
            _grid.Columns["Odds"].Width = 70;

            _grid.Columns["Number"].ReadOnly = true;

            foreach (int i in _horsenumbers)
            {
                int rowindex = _grid.Rows.Add();

                _grid["Number", rowindex].Value = i;

                _grid.Rows[rowindex].Height = 50;

                if (_odds.ContainsKey(i))
                {
                    _grid["Odds", rowindex].Value = _odds[i];

                    string s = _odds[i].ToString();
                }
                else
                {
                    _grid["Odds", rowindex].Value = 0;
                }

            }
            
        }
        
        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        private void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (!_grid.Columns.Contains("Odds") && !_grid.Columns.Contains("Number"))
            {
                return;
            }

            if (null == _grid["Odds", index].Value || null == _grid["Number", index].Value)
            {
                return;
            }

            string s = (string)_grid["Odds", index].Value;
            s = s.Trim();
            int n = (int)_grid["Number", index].Value;
            _odds[n].ReadOddsFromString(s);
            _grid["Odds", index].Value = _odds[n];
            OddsWereChangedEvent();
            
        }
    }
}
