using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Betting;


namespace OddsEditor.MyComponents
{
    public partial class TrifectaPayoutsControl : UserControl
    {
        public delegate void UpdateParentDelegate();

        public event UpdateParentDelegate UpdateParentEvent;

        


        bool _groupUpdating = false;

        public TrifectaPayoutsControl()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            UpdateSelectionButtons();           
        }

        private bool IsRowSelected(DataGridViewRow row)
        {
            return (bool)row.Cells["IsSelected"].Value; 
        }

        
        public int CountSelections()
        {
            int c = 0;
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (IsRowSelected(row))
                {
                    ++c;
                }
            }
            return c;
        }

        public List<TrifectaSubsystem> SelectedCombinations
        {
            get
            {
                List<TrifectaSubsystem> list = new List<TrifectaSubsystem>();

                foreach (DataGridViewRow row in _grid.Rows)
                {
                    if (IsRowSelected(row))
                    {
                        TrifectaSubsystem s = (TrifectaSubsystem)row.Cells["Combo"].Value;

                        if (null != s)
                        {
                            list.Add(s);
                        }
                    }
                }

                return list;

            }
        }


        public void LoadCombinations(List<TrifectaSubsystem> subsystems)
        {
            _grid.Rows.Clear();
            
            foreach (TrifectaSubsystem system in subsystems)
            {
                if (system.IsValid)
                {
                    int index = _grid.Rows.Add();

                    _grid["IsSelected", index].Value = false;
                    _grid["Combo", index].Value = system;
                    _grid["Payoff", index].Value = system.Payoff;
                    _grid["Bet", index].Value = system.AmountToDutch;
                }
            }

            UpdateSelectionButtons();
        }

        private void UpdateRowsColor()
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (IsRowSelected(row))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        
        private void OnCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
            if (null != UpdateParentEvent && _groupUpdating == false)
            {
                _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateParentEvent();
                UpdateRowsColor();
            }
        }

        private void SelectAll(bool isSelected)
        {
            _groupUpdating = true;



            foreach (DataGridViewRow row in _grid.SelectedRows)
            {
                row.Cells["IsSelected"].Value = isSelected;
            }

            _groupUpdating = false;
            UpdateParentEvent();
            UpdateRowsColor();
        }

        private void OnSelect(object sender, EventArgs e)
        {

            SelectAll(true);
        }

        private void OnUnselect(object sender, EventArgs e)
        {
            SelectAll(false);
        }

        private void UpdateSelectionButtons()
        {
            bool state = false;

            if (_grid.Rows.Count > 1 && (_grid.SelectedRows.Count > 1))
            {
                state = true;
            }
            _buttonSelect.Enabled = state;
            _buttonUnselect.Enabled = state;

            _buttonSelect.Visible= state;
            _buttonUnselect.Visible = state;    
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectionButtons();
        }

        
    }
}
