using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.RealTimeTools;
using OddsEditor.Dialogs.BetViewer;

namespace OddsEditor.Dialogs
{
    public partial class BreadAndButterForm : Form
    {

         


        private readonly Race _race;
        private readonly OddsRetriever _oddsRetriever;
        private bool _isLoading;

        public BreadAndButterForm(Race race,OddsRetriever oddsRetriever)
        {
            _race = race;
            _oddsRetriever = oddsRetriever;
            InitializeComponent();
        }


        double GetAmountToBet(double odds)
        {

            return 1.0 + ((double)_cbAmountToWin.SelectedItem) / (odds + 1.0);
        }

        double GetExactaPayout(Horse firstHorse, Horse secondHorse)
        {
            Debug.Assert(null != _oddsRetriever);
            int h1 = firstHorse.GetProgramNumberWithoutEntryChar();
            int h2 = secondHorse.GetProgramNumberWithoutEntryChar();
            DataTable dt = _oddsRetriever.ExactaPayouts;
            Debug.Assert(null != dt);
            return (double) dt.Rows[h1 - 1][h2 - 1];
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _isLoading = true;
            _gridUsingOnlyWin.Columns.Add("BET", "BET");
            _gridUsingOnlyWin.Columns.Add("PAYOUT", "PAYOUT");
            _gridUsingOnlyWin.Columns.Add("AMOUNT", "AMOUNT");
            _gridUsingOnlyWin.Columns["PAYOUT"].CellTemplate.ValueType = typeof(double);
            _gridUsingOnlyWin.Columns["AMOUNT"].CellTemplate.ValueType = typeof(double);


            _gridExactasOnly.Columns.Add("BET", "BET");
            _gridExactasOnly.Columns.Add("PAYOUT", "PAYOUT");
            _gridExactasOnly.Columns.Add("AMOUNT", "AMOUNT");
            _gridExactasOnly.Columns["PAYOUT"].CellTemplate.ValueType = typeof(double);
            _gridExactasOnly.Columns["AMOUNT"].CellTemplate.ValueType = typeof(double);




            _gridSurfAndTurf.Columns.Add("BET", "BET");
            _gridSurfAndTurf.Columns.Add("PAYOUT", "PAYOUT");
            _gridSurfAndTurf.Columns.Add("AMOUNT", "AMOUNT");
            _gridSurfAndTurf.Columns["PAYOUT"].CellTemplate.ValueType = typeof(double);
            _gridSurfAndTurf.Columns["AMOUNT"].CellTemplate.ValueType = typeof(double);

            LoadAmountToWinComboBox();
            UpdateGrid();
            _isLoading = false;
        }

        void LoadAmountToWinComboBox()
        {
            _cbAmountToWin.Items.Clear();
            for (double amount = 100; amount <= 1000; amount +=100.0)
            {
                _cbAmountToWin.Items.Add(amount);    
            }
            _cbAmountToWin.Items.Add(1200.0);
            _cbAmountToWin.Items.Add(1500.0);
            _cbAmountToWin.Items.Add(1600.0);
            _cbAmountToWin.Items.Add(1700.0);
            _cbAmountToWin.Items.Add(1800.0);
            _cbAmountToWin.Items.Add(1900.0);
            _cbAmountToWin.Items.Add(2000.0);
            _cbAmountToWin.Items.Add(2500.0);
            _cbAmountToWin.Items.Add(3000.0);
            _cbAmountToWin.Items.Add(4000.0);
            _cbAmountToWin.Items.Add(5000.0);
            _cbAmountToWin.Items.Add(6000.0);
            _cbAmountToWin.Items.Add(7000.0);
            _cbAmountToWin.Items.Add(8000.0);
            _cbAmountToWin.Items.Add(9000.0);
            _cbAmountToWin.Items.Add(10000.0);
            _cbAmountToWin.SelectedItem = 1000.0;

        }

        void UpdateGrid()
        {
            if (null == _oddsRetriever)
            {
                MessageBox.Show("Sorry, odds retriever not started...");
                return;
            }

            if (null == _race || _race.Horses.Count(h => h.IsBestBet) != 1)
            {
                MessageBox.Show("Sorry, best bet should be only one horse");
                return;
            }

            UpdateUsingOnlyWinGrid();
            UpdateUsingOnlyExactasGrid();
            UpdateSurfAndTurf();


            
        }

        void UpdateSurfAndTurf()
        {
            _gridSurfAndTurf.Rows.Clear();
            Horse bestBest = _race.Horses.Find(h => h.IsBestBet);

            _race.Horses.Where(h => h.IsContenter && false == h.IsBestBet && h.Scratched == false && h.GetProgramNumberWithoutEntryChar() != bestBest.GetProgramNumberWithoutEntryChar()).ToList().ForEach
                (
                    h =>
                    {
                        int rowIndex = _gridSurfAndTurf.Rows.Add();
                        _gridSurfAndTurf.Rows[rowIndex].Cells[0].Value = string.Format("{0} X {1} (Exacta)", bestBest.GetProgramNumberWithoutEntryChar(), h.GetProgramNumberWithoutEntryChar());
                        _gridSurfAndTurf.Rows[rowIndex].Cells[1].Value = (int)(GetExactaPayout(bestBest, h));

                        double amountTobet = GetAmountToBet(GetExactaPayout(bestBest, h) / 2.0 - 1.0);
                        if (amountTobet < 1.0)
                        {
                            amountTobet = 1.0;
                        }
                        _gridSurfAndTurf.Rows[rowIndex].Cells[2].Value = (int)amountTobet;
                        _gridSurfAndTurf.Rows[rowIndex].Cells[2].Tag = amountTobet;
                    }
                );

            double totalAmountNeeded = TotalAmountNeededForSurfAndTurf;

            _tbAmountNeededForSurfAndTurf.Text = string.Format("{0:0}", totalAmountNeeded);
            _tbSurfAndTurfRate.Text = string.Format("{0:0.0} - 1 ", (((double)_cbAmountToWin.SelectedItem) / totalAmountNeeded) - 1);

        }

        void UpdateUsingOnlyExactasGrid()
        {
            _gridExactasOnly.Rows.Clear();
            

            Horse bestBest = _race.Horses.Find(h => h.IsBestBet);

            
            
            _race.Horses.Where(h => h.IsContenter && false == h.IsBestBet && h.Scratched == false && h.GetProgramNumberWithoutEntryChar() != bestBest.GetProgramNumberWithoutEntryChar()).ToList().ForEach
                (
                    h =>
                    {
                        int rowIndex = _gridExactasOnly.Rows.Add();
                        _gridExactasOnly.Rows[rowIndex].Cells[0].Value = string.Format("{0} X {1} (Exacta)", bestBest.GetProgramNumberWithoutEntryChar(), h.GetProgramNumberWithoutEntryChar());
                        _gridExactasOnly.Rows[rowIndex].Cells[1].Value = (int) (GetExactaPayout(bestBest, h));

                        double amountTobet = GetAmountToBet(GetExactaPayout(bestBest, h) / 2.0 - 1.0);
                        if (amountTobet < 1.0)
                        {
                            amountTobet = 1.0;
                        }
                        _gridExactasOnly.Rows[rowIndex].Cells[2].Value = (int)amountTobet;
                        _gridExactasOnly.Rows[rowIndex].Cells[2].Tag = amountTobet;
                    }
                );


            _race.Horses.Where(h => h.IsContenter && false == h.IsBestBet && h.Scratched == false && h.GetProgramNumberWithoutEntryChar() != bestBest.GetProgramNumberWithoutEntryChar()).ToList().ForEach
                (
                    h =>
                    {
                        int rowIndex = _gridExactasOnly.Rows.Add();
                        _gridExactasOnly.Rows[rowIndex].Cells[0].Value = string.Format("{0} X {1} (Exacta)", h.GetProgramNumberWithoutEntryChar(), bestBest.GetProgramNumberWithoutEntryChar());
                        _gridExactasOnly.Rows[rowIndex].Cells[1].Value = (int) (GetExactaPayout(h, bestBest));

                        double amountTobet = GetAmountToBet(GetExactaPayout(h, bestBest) / 2.0 - 1.0);
                        if (amountTobet < 1.0)
                        {
                            amountTobet = 1.0;
                        }
                        _gridExactasOnly.Rows[rowIndex].Cells[2].Value = (int)amountTobet;
                        _gridExactasOnly.Rows[rowIndex].Cells[2].Tag = amountTobet;
                    }
                );


            _amountNeededForExactaOnly.Text = string.Format("{0:0}", TotalAmountNeededForExactaOnly);
            _rateForExactaOnly.Text = string.Format("{0:0.0} - 1 ", (((double)_cbAmountToWin.SelectedItem) / TotalAmountNeededForExactaOnly) - 1);

        }


        void UpdateUsingOnlyWinGrid()
        {
            _gridUsingOnlyWin.Rows.Clear();
            

            Horse bestBest = _race.Horses.Find(h => h.IsBestBet);

            int rowIndex = _gridUsingOnlyWin.Rows.Add();
            _gridUsingOnlyWin.Rows[rowIndex].Cells[0].Value = string.Format("{0} (TO WIN)", bestBest.GetProgramNumberWithoutEntryChar().ToString());
            _gridUsingOnlyWin.Rows[rowIndex].Cells[1].Value = (int) ( (bestBest.RealTimeOdds + 1) * 2.0);


            _tbOddsToWin.Text = bestBest.RealTimeOdds.ToString();
            _gridUsingOnlyWin.Rows[rowIndex].Cells[2].Value = (int)GetAmountToBet(bestBest.RealTimeOdds);
            _gridUsingOnlyWin.Rows[rowIndex].Cells[2].Tag = GetAmountToBet(bestBest.RealTimeOdds);
            _race.Horses.Where(h => h.IsContenter && false == h.IsBestBet && h.Scratched == false && h.GetProgramNumberWithoutEntryChar() != bestBest.GetProgramNumberWithoutEntryChar()).ToList().ForEach
                (
                    h =>
                    {
                        rowIndex = _gridUsingOnlyWin.Rows.Add();
                        _gridUsingOnlyWin.Rows[rowIndex].Cells[0].Value = string.Format("{0} X {1} (Exacta)", h.GetProgramNumberWithoutEntryChar(), bestBest.GetProgramNumberWithoutEntryChar());
                        _gridUsingOnlyWin.Rows[rowIndex].Cells[1].Value = (int) ( GetExactaPayout(h, bestBest));

                        double amountTobet = GetAmountToBet(GetExactaPayout(h, bestBest) / 2.0 - 1.0);
                        if (amountTobet<1.0)
                        {
                            amountTobet = 1.0;
                        }
                        _gridUsingOnlyWin.Rows[rowIndex].Cells[2].Value = (int)amountTobet;
                        _gridUsingOnlyWin.Rows[rowIndex].Cells[2].Tag = amountTobet;
                    }
                );

            _tbAmountNeeded.Text = string.Format("{0:0}", TotalAmountNeeded);
            _tbRate.Text = string.Format("{0:0.0} - 1 ", ( ((double)_cbAmountToWin.SelectedItem) /  TotalAmountNeeded) -1);

        }

        protected double TotalAmountNeeded
        {
            get
            {
                return _gridUsingOnlyWin.Rows.Cast<DataGridViewRow>().Sum(row => (double) row.Cells["AMOUNT"].Tag);
            }
            
        }



        protected double TotalAmountNeededForSurfAndTurf
        {
            get
            {
                return _gridSurfAndTurf.Rows.Cast<DataGridViewRow>().Sum(row => (double)row.Cells["AMOUNT"].Tag);
            }

        }

        protected double TotalAmountNeededForExactaOnly
        {
            get
            {

                return _gridExactasOnly.Rows.Cast<DataGridViewRow>().Sum(row => (double)row.Cells["AMOUNT"].Tag);
            }

        }

        private void OnAmountToWinChanged(object sender, EventArgs e)
        {
            if(!_isLoading)
            {
                UpdateGrid();                
            }
        }

        private void _buttonPlaceBetUsingWinAndExactas_Click(object sender, EventArgs e)
        {

        }

        private void _buttonPlaceTheBetUsingExactasOnly_Click(object sender, EventArgs e)
        {

        }
    }
}
