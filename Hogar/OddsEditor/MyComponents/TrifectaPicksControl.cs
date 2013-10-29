using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.MyComponents
{
    public partial class TrifectaPicksControl : UserControl
    {
        List<int> _selections = new List<int>();

        string _title = "";


        public delegate void ControlWasSeletedDelegate(TrifectaPicksControl ctrl);

        public event ControlWasSeletedDelegate ControlSelectedEvent;
        

        public TrifectaPicksControl(string txt)
        {
            _title = txt;
            InitializeComponent();
        }

        public List<int> Selections
        {
            get
            {
                return _selections;
            }
        }

        public bool IsHorseSelected(int num)
        {
            return _selections.Contains(num);
        }

        public void AddOrRemove(int i)
        {
            if (_selections.Contains(i))
            {
                _selections.Remove(i);
            }
            else
            {
                _selections.Add(i);
            }

            UpdateSelections();
        }

        public void Remove(int i)
        {
            if (_selections.Contains(i))
            {
                _selections.Remove(i);
            }

            UpdateSelections();
        }

        private void UpdateSelections()
        {
            _buttonSelections.Text = this.ToString();
        }

        public override string ToString()
        {
            string s = "";
            _selections.Sort();
            foreach (int i in _selections)
            {
                if (s.Length > 0)
                {
                    s += ",";
                }
                s += i.ToString();
            }

            return s;
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _txtboxPosition.Text = _title;
            UpdateSelections();
            
        }

        public void UnselectIt()
        {
            
            this.BackColor = Color.Blue;
            _txtboxPosition.BackColor = Color.Blue;
            _buttonSelections.BackColor = Color.Blue;
            _buttonSelections.ForeColor = Color.White;
            _txtboxPosition.BorderStyle = BorderStyle.None;

            _buttonSelections.FlatAppearance.BorderSize = 0;
            _buttonSelections.FlatStyle = FlatStyle.Flat;
        }

        public void SelectIt()
        {
            this.BackColor = Color.Red;
            _txtboxPosition.BackColor = Color.Red;
            _txtboxPosition.BorderStyle = BorderStyle.None;
            _buttonSelections.BackColor = Color.Red;
            _buttonSelections.ForeColor = Color.White;
            _buttonSelections.FlatAppearance.BorderSize = 0;
            _buttonSelections.FlatStyle = FlatStyle.Flat;
            
            
        }

        private void OnSelectionsClick(object sender, EventArgs e)
        {
            SelectIt();
            ControlSelectedEvent(this);
        }

    }
}
