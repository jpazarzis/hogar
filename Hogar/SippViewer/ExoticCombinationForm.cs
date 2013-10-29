using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    // This form handles both exactas and doubles for Real Time retrieval

    public partial class ExoticCombinationForm : Form
    {
        readonly SippOddsRetriever _oddsRetriver;


        class ExoticCombination
        {
            readonly int _first;
            readonly int _second;
            double _payout;
            bool _isSelected = false;

            public ExoticCombination(int first, int second, double payout)
            {
                _first = first;
                _second = second;
                _payout = payout;
            }

            public double Payout
            {
                get
                {
                    return _payout;
                }
                set
                {
                    _payout = value;
                }
            }

            public int FirstHorse
            {
                get
                {
                    return _first;
                }
            }

            public int SecondHorse
            {
                get
                {
                    return _second;
                }
            }

            public override string ToString()
            {
                return string.Format("{0:0}", _payout);
            }

            public void ToggleSelectionStatus()
            {
                _isSelected = !_isSelected;
            }

            public void SelectIt()
            {
                _isSelected = true;
            }

            public void UnselectedIt()
            {
                _isSelected = false;
            }

            public bool IsSelected
            {
                get
                {
                    return _isSelected;
                }
            }
        }

        public enum ExoticCombinationType
        {
            Exacta,
            Double
        }

        readonly private ExoticCombinationType _exoticCombinationType;

        public ExoticCombinationForm(SippOddsRetriever oddsRetriver, ExoticCombinationType exoticCombinationType)
        {
            _exoticCombinationType = exoticCombinationType;
            _oddsRetriver = oddsRetriver;
            InitializeComponent();
        }

        private DataTable DataTableToUse
        {
            get
            {
                DataTable dt = null;
                if (null != _oddsRetriver)
                {
                    if (_exoticCombinationType == ExoticCombinationType.Exacta)
                    {
                        dt = _oddsRetriver.ExactaPayouts;
                    }
                    else if (_exoticCombinationType == ExoticCombinationType.Double)
                    {
                        dt = _oddsRetriver.DoublePayouts;
                    }
                }
                return dt;
            }
        }

        private void MakeTitle()
        {
            if (_exoticCombinationType == ExoticCombinationType.Exacta)
            {
                this.Text = "Exacta Pool";
            }
            else if (_exoticCombinationType == ExoticCombinationType.Double)
            {
                this.Text = "Double Pool";
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            MakeTitle();

            if (null == _oddsRetriver)
            {
                MessageBox.Show("Please start the Odds Retriever prior to open the Exacta form monitor");
                return;
            }

            _labelRaceTrack.Text = string.Format("{0} Race# {1}", _oddsRetriver.TrackName, _oddsRetriver.RaceNumber);

            _gridSelectedExoticCombinations.Columns.Clear();
            _gridSelectedExoticCombinations.Columns.Add("Combo", "Combo");
            _gridSelectedExoticCombinations.Columns.Add("Price", "Price");
            _gridSelectedExoticCombinations.Columns.Add("Bet", "Bet");
            _gridSelectedExoticCombinations.Columns.Add("Rounded", "Rounded");

            _gridSelectedExoticCombinations.Columns["Price"].CellTemplate.ValueType = typeof(double);
            _gridSelectedExoticCombinations.Columns["Bet"].CellTemplate.ValueType = typeof(double);
            _gridSelectedExoticCombinations.Columns["Rounded"].CellTemplate.ValueType = typeof(double);

            _gridSelectedExoticCombinations.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _gridSelectedExoticCombinations.Columns["Bet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _gridSelectedExoticCombinations.Columns["Rounded"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _gridSelectedExoticCombinations.Columns["Price"].DefaultCellStyle.Format = "##.00";
            _gridSelectedExoticCombinations.Columns["Bet"].DefaultCellStyle.Format = "##.00";
            _gridSelectedExoticCombinations.Columns["Rounded"].DefaultCellStyle.Format = "##";

            _gridSelectedExoticCombinations.Columns["Price"].Visible = false;
            _gridSelectedExoticCombinations.Columns["Bet"].Visible = false;

            DataTable dt = DataTableToUse;

            if (null == dt)
            {
                MessageBox.Show("Sorry data not available");
            }

            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                string colName = (col + 1).ToString();
                _gridExoticCombination.Columns.Add(colName, colName);
            }

            for (int row = 0; row < dt.Rows.Count; ++row)
            {

                int index = _gridExoticCombination.Rows.Add();
                string rowName = (row + 1).ToString();
                _gridExoticCombination.Rows[index].HeaderCell.Value = rowName;
            }

            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                for (int row = 0; row < dt.Rows.Count; ++row)
                {
                    ExoticCombination ec = new ExoticCombination(row + 1, col + 1, (double)dt.Rows[row][col]);
                    _gridExoticCombination[col, row].Value = ec;
                    PaintExoticCombinationGridCell(col, row);
                }
            }

            _gridExoticCombination.DefaultCellStyle.SelectionBackColor = Color.White;
            _gridExoticCombination.DefaultCellStyle.SelectionForeColor = Color.Black;

            _txtboxAmountToWin.Text = "1000";

            _oddsRetriver.UpdateObserverDelegateEvent += _oddsRetriver_UpdateObserverDelegateEvent;


        }

        void _oddsRetriver_UpdateObserverDelegateEvent()
        {
            if (null == _oddsRetriver)
            {
                return;
            }

            if (_oddsRetriver.ErrorStatus != 0)
            {
                _labelRaceTrack.Text = _oddsRetriver.ErrorMessage;
                _oddsRetriver.StopIt();
                return;
            }

            if (_oddsRetriver.PoolWasClosed)
            {
                _labelRaceTrack.Text = "Pool was closed";
                _oddsRetriver.StopIt();
                return;
            }


            DataTable dt = DataTableToUse;

            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                for (int row = 0; row < dt.Rows.Count; ++row)
                {
                    double newPayout = (double)dt.Rows[row][col];
                    ExoticCombination ec = (ExoticCombination)_gridExoticCombination[col, row].Value;
                    ec.Payout = newPayout;
                }
            }

            Calculate();
        }

        private void ExactaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _oddsRetriver.UpdateObserverDelegateEvent -= _oddsRetriver_UpdateObserverDelegateEvent;
            }
            catch
            {
            }
        }

        private void UnselectExoticCombination(ExoticCombination ec)
        {
            DataGridViewRow rowToRemove = null;
            foreach (DataGridViewRow row in _gridSelectedExoticCombinations.Rows)
            {
                if (row.Tag == ec)
                {
                    rowToRemove = row;
                    break;
                }
            }
            if (null != rowToRemove)
            {
                _gridSelectedExoticCombinations.Rows.Remove(rowToRemove);
            }
            UpdateNumberOfCombinationsTextBox();
        }

        private void SelectExoticCombination(ExoticCombination ec)
        {
            int index = _gridSelectedExoticCombinations.Rows.Add();
            _gridSelectedExoticCombinations.Rows[index].Tag = ec;
            _gridSelectedExoticCombinations[0, index].Value = string.Format("{0} X {1}", ec.FirstHorse, ec.SecondHorse);
            _gridSelectedExoticCombinations[1, index].Value = ec.Payout;
            UpdateNumberOfCombinationsTextBox();
        }

        void UpdateNumberOfCombinationsTextBox()
        {
            _txtboxNumberOfCombinations.Text = string.Format("{0}", _gridSelectedExoticCombinations.Rows.Count);
        }


        private void Calculate()
        {
            double amountToWin = Convert.ToDouble(_txtboxAmountToWin.Text);
            double amountNeeded = 0.0;
            double roundedAmountNeeded = 0.0;

            foreach (DataGridViewRow row in _gridSelectedExoticCombinations.Rows)
            {
                ExoticCombination ec = (ExoticCombination)row.Tag;

                if (null != ec && ec.Payout != 0)
                {
                    double bet = (amountToWin * 2.0) / ec.Payout;
                    row.Cells[2].Value = bet;
                    amountNeeded += bet;

                    double fraction = bet - Math.Floor(bet);

                    if (fraction < 0.30)
                    {
                        bet -= fraction;
                    }
                    else
                    {
                        bet = Math.Ceiling(bet);
                    }

                    row.Cells[3].Value = bet;

                    roundedAmountNeeded += bet;
                }

            }
            _txtboxAmountNeeded.Text = string.Format("{0:0.00}", amountNeeded);
            _txtboxRoundedAmountNeeded.Text = string.Format("{0:0.00}", roundedAmountNeeded);
            _txtboxReturn.Text = string.Format("{0:0.00}", (amountToWin / amountNeeded) - 1.0);
        }


        void PaintExoticCombinationGridCell(int col, int row)
        {
            ExoticCombination ex = (ExoticCombination)_gridExoticCombination[col, row].Value;


            Color backColor = ex.IsSelected ? Color.Green : Color.White;
            Color foreColor = Color.Black;

            if (ex.Payout == 0.00)
            {
                backColor = Color.Gray;
                foreColor = Color.Gray;
            }

            _gridExoticCombination[col, row].Style.BackColor = backColor;
            _gridExoticCombination[col, row].Style.ForeColor = foreColor;
            _gridExoticCombination[col, row].Style.SelectionBackColor = backColor;
            _gridExoticCombination[col, row].Style.SelectionForeColor = foreColor;
        }


        private void HandleClick(int col, int row)
        {
            ExoticCombination ec = (ExoticCombination)_gridExoticCombination[col, row].Value;

            if (ec.Payout == 0.00)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ec.ToggleSelectionStatus();
            PaintExoticCombinationGridCell(col, row);
            if (ec.IsSelected == false)
            {
                UnselectExoticCombination(ec);
            }
            else
            {
                SelectExoticCombination(ec);
            }

            Calculate();
        }

        private void OnExactaGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0 && col >= 0)
            {
                HandleClick(col, row);
            }
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            for (int col = 0; col < _gridExoticCombination.Columns.Count; ++col)
            {
                for (int row = 0; row < _gridExoticCombination.Rows.Count; ++row)
                {
                    ExoticCombination ec = (ExoticCombination)_gridExoticCombination[col, row].Value;
                    if (ec.Payout != 0.00)
                    {
                        ec.SelectIt();
                        PaintExoticCombinationGridCell(col, row);
                        SelectExoticCombination(ec);
                    }
                }
            }
            Calculate();
        }

        private void OnUnselectAll(object sender, EventArgs e)
        {
            for (int col = 0; col < _gridExoticCombination.Columns.Count; ++col)
            {
                for (int row = 0; row < _gridExoticCombination.Rows.Count; ++row)
                {
                    ExoticCombination ec = (ExoticCombination)_gridExoticCombination[col, row].Value;
                    if (ec.Payout != 0.00)
                    {
                        ec.UnselectedIt();
                        PaintExoticCombinationGridCell(col, row);
                        UnselectExoticCombination(ec);
                    }
                }
            }
            Calculate();
        }

    }

}
