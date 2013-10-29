using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Research.GeneticAlgorithm;

namespace GeneticResearch
{
    public partial class BackTestForm : Form
    {
        private readonly Solution _solution;


        public BackTestForm(Solution s)
        {
            _solution = s;

            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _cbStartingBankroll.Items.Add(1000);
            _cbStartingBankroll.Items.Add(2000);
            _cbStartingBankroll.Items.Add(5000);
            _cbStartingBankroll.Items.Add(10000);

            _cbStartingBankroll.SelectedItem = 1000;

            _cbNumberOfRacesToPlay.Items.Add(100);
            _cbNumberOfRacesToPlay.Items.Add(200);
            _cbNumberOfRacesToPlay.Items.Add(500);
            _cbNumberOfRacesToPlay.Items.Add(1000);
            _cbNumberOfRacesToPlay.Items.Add(2000);
            _cbNumberOfRacesToPlay.Items.Add(5000);
            _cbNumberOfRacesToPlay.Items.Add(10000);

            _cbNumberOfRacesToPlay.SelectedItem = 100;

            for (int i = 0; i < 10; i++)
            {
                _cbMinAdvantage.Items.Add(i);
            }

            _cbMinAdvantage.SelectedItem = 5;

            _labelFinalBankroll.Text = "";

            List<double> weights = _solution.Weights;

            _grid.Rows.Clear();
            _grid.Columns.Clear();
            for(int i =0; i < weights.Count;++i)
            {
                string name = string.Format("{0}", i);
                _grid.Columns.Add(name, name);
            }

            int rowIndex = _grid.Rows.Add();
            for (int i = 0; i < weights.Count; ++i)
            {
                _grid[i, rowIndex].Value = weights[i];
            }



        }

        private void OnGo(object sender, EventArgs e)
        {
            try
            {
                var backTester = new BackTester(_solution, (double)((int)_cbStartingBankroll.SelectedItem), (int)_cbNumberOfRacesToPlay.SelectedItem, (int)_cbMinAdvantage.SelectedItem);
                backTester.Run();
                _labelFinalBankroll.Text = string.Format("{0:0}", backTester.Bankroll);
                _labelNumberOfBets.Text = backTester.NumberOfBetsFound.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OnClose(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
