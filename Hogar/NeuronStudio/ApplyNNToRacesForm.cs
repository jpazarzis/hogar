using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Algorithms;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;
using NPlot;

namespace NeuronStudio
{
    public partial class ApplyNNToRacesForm : Form
    {

        private Dictionary<int, List<StarterInfo>> _races;
        private DetectWinnerNeuronNetwork _nn;

        public ApplyNNToRacesForm()
        {
            InitializeComponent();
        }

        private void ApplyNNToRacesForm_Load(object sender, EventArgs e)
        {
            _races = StarterInfo.LoadRacesFromFile(@"C:\Users\John\Desktop\neural_network.csv", 6);
            _nn = NeuronNetwork.MakeFromXmlFile(@"C:\Users\John\Desktop\nn.xml") as DetectWinnerNeuronNetwork;

            _tbNumberOfRaces.Text = _races.Count.ToString();
        }

        private void TestClick(object sender, EventArgs e)
        {

            double total = 0;
            double winners = 0;
            double amountWon = 0.0;

            double bankroll = 2000.0;
            double maxAllowedBet = 250;
            double minReachedBankroll = double.MaxValue;
            double maxReachedBankroll = double.MinValue;


            var bankrollBehavior = new List<double>();

            bankrollBehavior.Add(bankroll);

            var odds = new List<double>();
            foreach(int raceid in _races.Keys)
            {
                if(_races[raceid].Count <=4)
                    continue;

                if(!ContainsTheWinner(_races[raceid]))
                {
                    continue;
                }
                

                
                var selection = TestRace(_races[raceid]);

                if(selection.Odds < 1.3 || selection.Odds > 18)
                    continue;


                double amountToBet = bankroll * 0.02;

                if (amountToBet > maxAllowedBet)
                    amountToBet = maxAllowedBet;

                bankroll -= amountToBet;

                ++total;
                if (null != selection)
                {
                    odds.Add(selection.Odds);
                    if(1 == selection.FinishPosition )
                    {
                        ++winners;
                        amountWon += (selection.Odds + 1) * 2.0;


                        bankroll += (selection.Odds + 1) * amountToBet;    
                    }
                    
                }

                bankrollBehavior.Add(bankroll);

                if (minReachedBankroll > bankroll)
                    minReachedBankroll = bankroll;

                if (maxReachedBankroll < bankroll)
                    maxReachedBankroll = bankroll;


                _tbTotal.Text = total.ToString();
                _tbWinners.Text = winners.ToString();
                _tbPercentage.Text = string.Format("{0:0.00}", (double)winners / total);

                _tbTotalBet.Text = string.Format("{0:0.00}", 2.0 * total);
                _tbTotalWinnings.Text = string.Format("{0:0.00}", amountWon);


                _tbAverageOdds.Text = string.Format("{0:0.00}", odds.Average());
                _tbMinOdds.Text = string.Format("{0:0.00}", odds.Min());
                _tbMaxOdds.Text = string.Format("{0:0.00}", odds.Max());
                _tbMinOdds.Text = string.Format("{0:0.00}", odds.Min());
                _tbOddsStdDev.Text = string.Format("{0:0.00}", Utilities.CalculateStdDev(odds));

                _tbCurrentBankroll.Text = string.Format("{0:0.00}", bankroll);

                _tbMinReachedBankroll.Text = string.Format("{0:0.00}", minReachedBankroll);
                _tbMaxReachedBankroll.Text = string.Format("{0:0.00}", maxReachedBankroll);

                Application.DoEvents();
            }



            return;
            _graph.Clear();
            var sp = new LinePlot();
            DataSet ds = GetBankrollBehaviorAsDataSet(bankrollBehavior);
            sp.DataSource = ds;
            sp.AbscissaData = "index";
            sp.OrdinateData = "bankrollSize";
            sp.Color = Color.Red;
            sp.Label = "Signal Frequency";
            _graph.Add(sp);
            _graph.Invalidate();

            
        }


        static DataSet GetBankrollBehaviorAsDataSet(List<double> bh)
        {
            var dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("index", typeof(double));
            dataTable.Columns.Add("bankrollSize", typeof(double));
            

            double i = 0;
            foreach (var b in bh)
            {
                dataTable.Rows.Add(i++, b, i++);
            }


            return dataSet;   
        }

        private bool ContainsTheWinner(List<StarterInfo> starterInfos)
        {
            foreach (var starterInfo in starterInfos)
            {
                if(starterInfo.FinishPosition == 1)
                {
                    return true;
                }
            }

            return false;
        }

        private StarterInfo TestRace(List<StarterInfo> starterInfos)
        {
            var votes = new Dictionary<StarterInfo, int>();

            foreach (var combo in CombinationCalculator<StarterInfo>.GenerateCombinations(starterInfos, 2))
            {
                var selected = _nn.GetWinningNeuron(combo).StarterInfo;

                if(votes.ContainsKey(selected))
                {
                    ++votes[selected];
                }
                else
                {
                    votes.Add(selected,1);
                }
            }

            StarterInfo hasMoreVotes = null;
            int maxVotes = int.MinValue;

            foreach (var si in votes.Keys)
            {
                if(null == hasMoreVotes || votes[si] > maxVotes)
                {
                    hasMoreVotes = si;
                    maxVotes = votes[si];
                }
            }


            
            return hasMoreVotes;


        }
    }
}
