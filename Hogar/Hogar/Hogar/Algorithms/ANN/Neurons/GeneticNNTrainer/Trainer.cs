using System.Collections.Generic;
using Hogar.Algorithms.ANN.InputData;

namespace Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer
{
    public class Trainer
    {
        private readonly Generation _generation;
        private readonly NeuronNetwork _nn;

        public delegate void PrintMessageDelegate(string str);

        public PrintMessageDelegate MessagePrinter; 


        static public Trainer Make(int populationSize, NeuronNetwork nn)
        {
            return new Trainer(populationSize, nn);
        }

        protected Trainer(int numberOfChromosomes, NeuronNetwork nn)
        {
            _generation = Generation.Make(numberOfChromosomes, nn.NumberOfSynapses);
            _nn = nn;
        }

        private void PrintMessage(string s)
        {
            if(null != MessagePrinter)
            {
                MessagePrinter(s);
            }
        }

        public Chromosome Train(List<List<StarterInfo>> races, int maxNumberOfGenerations)
        {
            int count = 0;

            PrintMessage(string.Format("Beginning Training for {0} generations",maxNumberOfGenerations));
            while(true)
            {
                _generation.ForEach(chromosome => chromosome.ROI = 0.0);

                for (int i = 0; i < _generation.Count; ++i )
                {
                    TrainChromosome(races, _generation[i], i);
                }

                    
                _generation.Sort(CompareChromosomes);

                if (_generation[0].ROI > 1.0)
                {
                    PrintMessage(string.Format("Congratulations... {0} ", _generation[0]));
                    _nn.AssignSynapticWeightsFromChromosome(_generation[0]);
                    return _generation[0];
                }
                    

                if (++count <= maxNumberOfGenerations)
                {
                    PrintMessage(string.Format("Best so far {0} ", _generation[0]));
                    _generation.Clone();
                }
                else
                {
                    PrintMessage(string.Format("Did not find the solution. Best so far  {0}", _generation[0]));
                    return _generation[0];
                }
            }
        }

        static private int CompareChromosomes(Chromosome c1, Chromosome c2)
        {

            const double minSelectionrate = 0.25;

            if (c1.SelectionRate < minSelectionrate && c2.SelectionRate > minSelectionrate)
                return 1;

            if (c2.SelectionRate < minSelectionrate && c1.SelectionRate > minSelectionrate)
                return -1;


            if (c1.ROI == c2.ROI)
                return 0;
            else if (c1.ROI > c2.ROI)
                return -1;
            else
                return 1;
        }

        private void TrainChromosome(IEnumerable<List<StarterInfo>> races, Chromosome chromosome, int currentIndex)
        {
            _nn.AssignSynapticWeightsFromChromosome(chromosome);

            double totalAmountBet = 0.0;
            double totalAmountWon = 0.0;

            int numberOfBets = 0;
            int numberOfRaces = 0;

            foreach (var race in races)
            {
                ++numberOfRaces;

                var selectedStarter = _nn.GetWinningNeuron(race).StarterInfo;

                if (null == selectedStarter)
                {
                    // the dummy neuron was selected which means there is no bet at all
                    continue;   
                }

                if(selectedStarter != ((OutputNeuron)_nn.OutputLayer[2]).StarterInfo)
                {
                    continue;   
                }

                totalAmountBet += 2.0;
                ++numberOfBets;
                if(selectedStarter.FinishPosition == 1)
                {
                    totalAmountWon += (selectedStarter.Odds + 1) * 2; 
                }
            }


            double roi = totalAmountBet > 1.0 ? totalAmountWon / totalAmountBet : 0.0;

            double selectionRate = numberOfRaces > 1 ? (double) numberOfBets/numberOfRaces : 0;

            chromosome.ROI = roi;
            chromosome.SelectionRate = selectionRate;

            PrintMessage(string.Format("currentIndex = {0} {1} ", currentIndex, chromosome));
        }

        
    }
}