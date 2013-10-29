using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Algorithms.ANN;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;
using Hogar.Algorithms.ANN.PatternStatistics;
using NPlot;

namespace NeuronStudio
{
    public partial class NNTrainingForm : Form
    {
        
        private NeuronNetwork _nn;

        private List<List<StarterInfo>> _races;
        private readonly List<List<StarterInfo>> _racesForTraining = new List<List<StarterInfo>>();
        private readonly List<List<StarterInfo>> _racesForTesting = new List<List<StarterInfo>>();

        

        private int _currentPair = 0;

        public NNTrainingForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
           //CreateNeuralNetworkForWinnerSelection();
            //CreateNeuralNetworkForLifeLongshotSelection();
            //CreateNeuralNetworkForImprovementSelection();
            ChooseBetweenFirstAndSecondFavorite();

            
        }

        public void WriteLine(string msg)
        {
            _tbOutput.Text += msg + Environment.NewLine;
            _tbOutput.Select(_tbOutput.Text.Length + 1, 2);
            _tbOutput.ScrollToCaret();
            Application.DoEvents();
        }

        private void LoadRaces()
        {
            if (_nn is ChooseBetweenFirstAndSecondFavoriteNeuronNetwork)
            {
                ChooseBetweenFirstAndSecondFavoriteSelection();
            }
            else if (_nn is DetectWinnerNeuronNetwork)
            {
                LoadRacesForWinnerSelection();
            }
            else if (_nn is DetectImprovementNeuronNetwork)
            {
                LoadRacesForImprovementSelection();
            }
        }

        private void LoadRacesForImprovementSelection()
        {
            _races = new List<List<StarterInfo>>();
            
            if (_nn is DetectImprovementNeuronNetwork)
            {
                var nn = _nn as DetectImprovementNeuronNetwork;

                var s = StarterInfo.LoadStartersFromFile(@"C:\Users\John\Desktop\neural_network.csv", nn.NumberOfPastPerformances);

                foreach (var starterInfo in s)
                {
                    _races.Add(new List<StarterInfo>() {starterInfo});      
                }
                 
            }

            _racesForTesting.Clear();
            _racesForTraining.Clear();

            if (null == _races || _races.Count <= 0)
                return;

            int testingSize = (int)(_races.Count / 20);

            for (int i = 0; i < _races.Count; ++i)
            {
                var l = i < testingSize ? _racesForTraining: _racesForTesting;
                l.Add(_races[i]);
            }

            int maxTrainingSize = 10000;

            if (_racesForTraining.Count > maxTrainingSize)
            {
                _racesForTraining.RemoveRange(maxTrainingSize, _racesForTraining.Count - maxTrainingSize);
            }

            if (_racesForTesting.Count > 2000)
            {
                _racesForTesting.RemoveRange(2000, _racesForTesting.Count - 2000);
            }


            _tbNumberOfRacesForTraining.Text = _racesForTraining.Count.ToString();
            _tbNumberOfRacesForTesting.Text = _racesForTesting.Count.ToString();

            _currentPair = -1;

            _tbEpoch.Text = "";
            _tbErrorFactor.Text = "";
            _tbMinErrorSoFar.Text = "";
        }

        private void ChooseBetweenFirstAndSecondFavoriteSelection()
        {
            _races = new List<List<StarterInfo>>();
        
            if (_nn is ChooseBetweenFirstAndSecondFavoriteNeuronNetwork)
            {
                var nn = _nn as ChooseBetweenFirstAndSecondFavoriteNeuronNetwork;
                _races = StarterInfo.LoadFirstAndSecondFavorite(@"C:\Users\John\Desktop\neural_network.csv", nn.NumberOfPastPerformances);
            }

            _racesForTesting.Clear();
            _racesForTraining.Clear();

            if (null == _races || _races.Count <= 0)
                return;

            int testingSize = (int)(_races.Count / 2);

            for (int i = 0; i < _races.Count; ++i)
            {
                var l = i < testingSize ? _racesForTraining : _racesForTesting;
                l.Add(_races[i]);
            }

            _tbNumberOfRacesForTraining.Text = _racesForTraining.Count.ToString();
            _tbNumberOfRacesForTesting.Text = _racesForTesting.Count.ToString();

            int c = 0;

            foreach (var r in _racesForTesting)
            {
                var si = r.Find(h => h.WasTheFavorite);

                if(null != si && si.FinishPosition != 1)
                {
                    ++c;
                }
            }

            _currentPair = -1;

            _tbEpoch.Text = "";
            _tbErrorFactor.Text = "";
            _tbMinErrorSoFar.Text = "";
        }

        private void LoadRacesForWinnerSelection()
        {
            _races = new List<List<StarterInfo>>();
        
            if (_nn is DetectWinnerNeuronNetwork)
            {
                var nn = _nn as DetectWinnerNeuronNetwork;
                _races = StarterInfo.LoadRacesWithExactNumberOfHorsesFromFile(@"C:\Users\John\Desktop\neural_network.csv", nn.NumberOfPastPerformancesUsed + 1, nn.FieldSize);    
            }
            
            _racesForTesting.Clear();
            _racesForTraining.Clear();

            if (null == _races || _races.Count <= 0)
                return;

            int testingSize = (int)(_races.Count / 2);

            for (int i = 0; i < _races.Count; ++i)
            {
                var l = i < testingSize ? _racesForTraining :_racesForTesting ;
                l.Add(_races[i]);
            }

            

            _tbNumberOfRacesForTraining.Text = _racesForTraining.Count.ToString();
            _tbNumberOfRacesForTesting.Text = _racesForTesting.Count.ToString();

            _currentPair = -1;

            _tbEpoch.Text = "";
            _tbErrorFactor.Text = "";
            _tbMinErrorSoFar.Text = "";
    
        }

        private void CreateNeuralNetworkForWinnerSelection()
        {
            const int fieldSize =6;
            const int numberOfPP =3;
            _nn = NeuronNetwork.Make(new DetectWinnerNeuronNetworkConstructor() { FieldSize = fieldSize, NumberOfPastPerformancesToUse = numberOfPP }) as DetectWinnerNeuronNetwork;
            _nn.AddHiddenLayer(8);
            _nn.AddOutputLayer();
            _neuralNetworkCtrl.Bind(_nn);
            LoadRaces();
            _neuralNetworkCtrl.Invalidate();
            ClearDisplay();
            UpdateScreen();
        }

        private void ChooseBetweenFirstAndSecondFavorite()
        {

            _nn = NeuronNetwork.Make(new ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor() { NumberOfPastPerformances = 3 }) as ChooseBetweenFirstAndSecondFavoriteNeuronNetwork;
            //_nn.AddHiddenLayer(2*_nn.Layers.ToList()[0].Neurons.Count() +1);

            _nn.AddHiddenLayer(_nn.Layers.ToList()[0].Neurons.Count() /2);

            
          
           
            _nn.AddOutputLayer();
            _neuralNetworkCtrl.Bind(_nn);
            ChooseBetweenFirstAndSecondFavoriteSelection();
            _neuralNetworkCtrl.Invalidate();
            ClearDisplay();
            UpdateScreen();
        }

        private void CreateNeuralNetworkForImprovementSelection()
        {
            const int pps = 4;
            _nn = NeuronNetwork.Make(new ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor() {NumberOfPastPerformances = pps}) as DetectImprovementNeuronNetwork;
            _nn.AddHiddenLayer(_nn.Layers.ToList()[0].Neurons.Count()/2);
           // _nn.AddHiddenLayer(5);
            _nn.AddOutputLayer();
            _neuralNetworkCtrl.Bind(_nn);
            LoadRacesForImprovementSelection();
            _neuralNetworkCtrl.Invalidate();
            ClearDisplay();
            UpdateScreen();
        }

        public void UpdateScreen()
        {
            Text = _nn.ToString();
           
            _tbNumberOfSynapses.Text = _nn.NumberOfSynapses.ToString();
            _tbNumberOfInputNodes.Text = _nn.Layers.ToList()[0].Neurons.Count().ToString();

            _tbNumberOfHiddenNeurons.Text = _nn.Layers.ToList()[1].Neurons.Count().ToString();
           
        }

        private void RunNextPatternClick(object sender, EventArgs e)
        {
            ++_currentPair;

            
            if (_currentPair >= _races.Count)
            {
                _currentPair = 0;
            }
            double error = _nn.Train(_races[_currentPair]);    
        


            _neuralNetworkCtrl.Invalidate();

            _tbErrorFactor.Text = string.Format("{0:0.000}", error);
        }

        private void TrainClick(object sender, EventArgs e)
        {
            _tbEpoch.Text = "0";

            double minErrorSoFar = double.MaxValue;

            for (int i = 0; i < 5; ++i)
            {
                double totalError = 0;
                int index = 0;
                foreach (var race in _racesForTraining)
                {


                    totalError += _nn.Train(race);
                   
                }
                
                
                if (Math.Abs(minErrorSoFar - totalError) < 0.001 || minErrorSoFar < totalError)
                {
                    break;
                }
                
                if (minErrorSoFar > totalError)
                {
                    minErrorSoFar = totalError;
                }
                  

                _tbEpoch.Text = i.ToString();
                _tbErrorFactor.Text = string.Format("{0:0.000}", totalError);
                _tbMinErrorSoFar.Text = string.Format("{0:0.000}", minErrorSoFar);

                Application.DoEvents();
            }
            _neuralNetworkCtrl.Invalidate();
        }

        private void ClearDisplay()
        {
            _tbSizeOfTrainingSample.Text = "";
            _tbCorrectSelections.Text = "";
            _tbCorrectSelectionsPercentage.Text = "";
        }


        private double AverageSignalStrengthForFavorite
        {

            get
            {
                var signal = new List<double>();
                foreach (var race in _racesForTesting)
                {
                    double v = _nn.GetWinningNeuron(race).Value;
                    signal.Add((_nn.OutputLayer[0] as OutputNeuron).Value);
                }
                return signal.Average();
            }
        }

        private double AverageSignalStrengthForSecondFavorite
        {

            get
            {
                var signal = new List<double>();
                foreach (var race in _racesForTesting)
                {
                    
                    signal.Add((_nn.OutputLayer[1] as OutputNeuron).Value);
                }
                return signal.Average();
            }
        }

        private double AverageSignalStrengthForThirdFavorite
        {

            get
            {
                var signal = new List<double>();
                foreach (var race in _racesForTesting)
                {
                    signal.Add((_nn.OutputLayer[2] as OutputNeuron).Value);
                }
                return signal.Average();
            }
        }


        private void TestClick(object sender, EventArgs e)
        {
            ClearDisplay();
            int total = 0;
            int correct = 0;
            double totalBet = 0;
            double winnings = 0;
            int winningBets = 0;

            double avgSSForFavorite = AverageSignalStrengthForFavorite;
            double avgSSForSecondFavorite = AverageSignalStrengthForSecondFavorite;
            double avgSSForThirdFavorite = AverageSignalStrengthForThirdFavorite;

            double favoriteTreshold = avgSSForFavorite * 0.1;
            double secondFavoriteTreshold = avgSSForSecondFavorite * 0.0;
            double thirdFavoriteTreshold = avgSSForThirdFavorite * 0.0;

            int numberOfWinningFavorites = 0;

            int numberOfFirstFavoritesPicked = 0;
            int numberOfSecondFavoritesPicked = 0;
            int numberOfThirdFavoritesPicked = 0;

            foreach (var r in _racesForTesting)
            {
                var si = r.Find(h => h.WasTheFavorite);

                if (null != si && si.FinishPosition == 1)
                {
                    ++numberOfWinningFavorites;
                }
            }


            double globalWinningFavoritePercent = ((double) numberOfWinningFavorites)/_racesForTesting.Count;

            foreach (var race in _racesForTesting)
            {
               if (_nn is ChooseBetweenFirstAndSecondFavoriteNeuronNetwork)
               {
                   
                    var selection = _nn.GetWinningNeuron(race);

                    if (selection != _nn.OutputLayer[2])
                        continue;
                   

                    if (null != selection.StarterInfo)
                   {
                        if(selection == _nn.OutputLayer[0])
                        {
                            ++numberOfFirstFavoritesPicked;
                        }

                        if (selection == _nn.OutputLayer[1])
                        {
                            ++numberOfSecondFavoritesPicked;
                        }

                        if (selection == _nn.OutputLayer[2])
                        {
                            ++numberOfThirdFavoritesPicked;
                        }

                       ++total;
                       totalBet += 2.0;
                       if (selection.StarterInfo.FinishPosition == 1)
                       {
                           ++winningBets;
                           winnings += (selection.StarterInfo.Odds + 1) * 2;
                       }
                   }
               }
            }

            //_tbAvgSignalStrength.Text = string.Format("{0:0.00}", avgSignalStrength);
            _tbSizeOfTrainingSample.Text = total.ToString();
            _tbCorrectSelections.Text = correct.ToString();

            if(total != 0)
                _tbCorrectSelectionsPercentage.Text = string.Format("{0:0.00}", (double) correct/total);

            _tbTotalBets.Text = total.ToString();
            _tbTotalWinners.Text = winningBets.ToString();
            _tbTotalAmountBet.Text = string.Format("{0:0.00}", totalBet);

            _tbTotalAmountWon.Text = string.Format("{0:0.00}", winnings);

            _tbWinPercent.Text = string.Format("{0:0.00}", (double)winningBets / total);

            _tbCorrectPercentage.Text = string.Format("{0:0.00}", (double)correct / total);
            _tbGlobalWinningFavoritePercentage.Text = string.Format("{0:0.00}", globalWinningFavoritePercent);


            _tbNumberOfFirstFavorites.Text = string.Format("{0}", numberOfFirstFavoritesPicked);
            _tbNumberOfSecondFavorites.Text = string.Format("{0}", numberOfSecondFavoritesPicked);
            _tbNumberOfThirdFavorites.Text = string.Format("{0}", numberOfThirdFavoritesPicked);
            
        }

        private void ResetClick(object sender, EventArgs e)
        {
            CreateNeuralNetworkForWinnerSelection();
            //CreateNeuralNetworkForImprovementSelection();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            try
            {
                _nn.SaveAsXmlFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Utilities.NeuronNetworkDirectory;
            openFileDialog1.Filter = @"nn files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ClearDisplay();
                    _nn = NeuronNetwork.MakeFromXmlFile(openFileDialog1.FileName) ;
                    _tbNumberOfSynapses.Text = _nn.NumberOfSynapses.ToString();
                    _tbEpoch.Text = "";
                    _tbErrorFactor.Text = "";
                    _tbMinErrorSoFar.Text = "";
                    LoadRaces();
                    UpdateScreen();
                    _neuralNetworkCtrl.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
 

           
        }

        private void TrainUsingGeneticAlgorithmClick(object sender, EventArgs e)
        {
            var trainer = Trainer.Make(50, _nn);
            trainer.MessagePrinter = WriteLine;
            trainer.Train(_racesForTraining, 50);
        }


    }
}