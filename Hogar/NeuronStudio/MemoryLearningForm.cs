using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;

namespace NeuronStudio
{
    public partial class MemoryLearningForm : Form
    {

        private MemoryBasedNeuronNetwork _nn;

        private List<StarterInfo> _starters;
        private readonly List<StarterInfo> _startersForTraining = new List<StarterInfo>();
        private readonly List<StarterInfo> _startersForTesting = new List<StarterInfo>();

        public MemoryLearningForm()
        {
            InitializeComponent();
        }

        private void _buttonLoad_Click(object sender, EventArgs e)
        {
            _nn = MemoryBasedNeuronNetwork.Make(4);
            LoadRacesForImprovementSelection();
            _nn.AddTrainingPatterns(_startersForTraining);

            double correct = 0, wrong = 0;
            int counter = 0;
            foreach (var starterInfo in _startersForTesting)
            {
                double opinion = _nn.GetOpinion(starterInfo);
                bool breaksPersonalRecord = starterInfo.BreaksPersonalRecord;
                if(opinion > 0)
                {
                    if(breaksPersonalRecord)
                    {
                        ++correct;
                    }
                    else
                    {
                        ++wrong;
                    }
                }

                if(0 == ++counter % 100)
                {
                    WriteLine(string.Format(" {0} Correct {1} Wrong {2}", counter,correct, wrong));
                }
            }

            WriteLine(string.Format("Correct {0} Wrong {1}", correct, wrong));
        }

        public void WriteLine(string msg)
        {
            _tbOutput.Text += msg + Environment.NewLine;
            _tbOutput.Select(_tbOutput.Text.Length + 1, 2);
            _tbOutput.ScrollToCaret();
            Application.DoEvents();
        }


        private void LoadRacesForImprovementSelection()
        {

            _tbNumberOfRacesForTesting.Text = "0";
            _tbNumberOfRacesForTraining.Text = "0";

            _tbNumberOfCorrectPredictions.Text = "0";
            _tbNumberOfWrongPredictions.Text = "0";


            _starters = StarterInfo.LoadStartersFromFile(@"C:\Users\John\Desktop\neural_network.csv", 4);
            _startersForTesting.Clear();
            _startersForTraining.Clear();

            if (null == _starters || _starters.Count <= 0)
                return;

            int testingSize = (int)(_starters.Count / 2);

            for (int i = 0; i < _starters.Count; ++i)
            {
                var l = i < testingSize ? _startersForTraining : _startersForTesting;
                l.Add(_starters[i]);
            }

            _tbNumberOfRacesForTesting.Text = _startersForTesting.Count.ToString();
            _tbNumberOfRacesForTraining.Text = _startersForTraining.Count.ToString();

            Application.DoEvents();
        }

        private void MemoryLearningForm_Load(object sender, EventArgs e)
        {

        }
    }
}
