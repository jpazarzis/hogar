using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Hogar.Algorithms.ANN.InputData;

namespace Hogar.Algorithms.ANN.Neurons.NeuronNetworks
{
    public class ChooseBetweenFirstAndSecondFavoriteNeuronNetwork : NeuronNetwork
    {

        public int NumberOfPastPerformances { get; set; }


        public ChooseBetweenFirstAndSecondFavoriteNeuronNetwork(ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor ci)
        {
            NumberOfPastPerformances = ci.NumberOfPastPerformances;

            ConcreteName = "ChooseBetweenFirstAndSecondFavoriteNeuronNetwork";
        }

        public ChooseBetweenFirstAndSecondFavoriteNeuronNetwork()
        {
            ConcreteName = "ChooseBetweenFirstAndSecondFavoriteNeuronNetwork";
        }

        public override string ToString()
        {
            return string.Format("{0} FavoritePPs: {1} {2}", ConcreteName, NumberOfPastPerformances, Filename);
        }

        public override void AddOutputLayer()
        {
            // The fourth Neuron is a dummy used to not bet the race
            _outputLayer = OutputLayer.Make(4);
            _layers.Add(_outputLayer);
            ConnectLayers();
        }

        protected override void CreateInputLayer()
        {
            _layers.Clear();
            _inputLayer = NeuronLayer.Make(StarterInfo.GetNumberOfInputsForChooseBetweenFirstAndSecondFavorite(NumberOfPastPerformances));
            _layers.Add(_inputLayer);
        }

        protected override void UpdateInputLayer(List<StarterInfo> starters)
        {
            Debug.Assert(starters.Count == 3);

            StarterInfo favorite = starters[0];
            StarterInfo secondFavorite = starters[1];
            StarterInfo thirdFavorite = starters[2];

            var input = StarterInfo.NormalizedInputToChooseBetweenFirstAndSecondFavorite(favorite, secondFavorite, thirdFavorite,NumberOfPastPerformances);

            for (int i = 0; i < input.Count; ++i)
            {
                _inputLayer[i].Value = input[i];
            }
        }

        protected override void UpdateOutputLayer(List<StarterInfo> starters)
        {
            Debug.Assert(starters.Count == 3);

            StarterInfo favorite = starters[0];
            StarterInfo secondfavorite = starters[1];
            StarterInfo thirdfavorite = starters[2];
        
    
            Debug.Assert(4 == _outputLayer.Count);

            var outputNeuron1 = (OutputNeuron)_outputLayer[0];
            var outputNeuron2 = (OutputNeuron)_outputLayer[1];
            var outputNeuron3 = (OutputNeuron)_outputLayer[2];
            var outputNeuron4 = (OutputNeuron)_outputLayer[3];

            outputNeuron1.Value = 0;
            outputNeuron2.Value = 0;
            outputNeuron3.Value = 0;

            outputNeuron1.StarterInfo = favorite;
            outputNeuron2.StarterInfo = secondfavorite;
            outputNeuron3.StarterInfo = thirdfavorite;
            outputNeuron4.StarterInfo = null;    

            outputNeuron1.DesiredValue = (secondfavorite.FinishPosition > favorite.FinishPosition && thirdfavorite.FinishPosition > favorite.FinishPosition) ? 1.0 : 0.0;
            outputNeuron2.DesiredValue = (secondfavorite.FinishPosition < favorite.FinishPosition && secondfavorite.FinishPosition < thirdfavorite.FinishPosition) ? 1.0 : 0.0;
            outputNeuron3.DesiredValue = (thirdfavorite.FinishPosition < favorite.FinishPosition && thirdfavorite.FinishPosition < secondfavorite.FinishPosition) ? 1.0 : 0.0;
            

        }

        protected override string MakeFilename()
        {
            return string.Format("nn_choose_first_or_second_favorite_{0}.xml", NumberOfPastPerformances);
        }

        protected override void InitializeFromXml(XmlDocument doc)
        {
            int ppCount;
            XmlNode node = doc.SelectSingleNode("/NeuronNetwork");

            int.TryParse(node.Attributes["NumberOfPastPerformances"].Value, out ppCount);


            NumberOfPastPerformances = ppCount;
            

        }

        protected override string XmlRootElement
        {
            get 
            {
                return string.Format("<NeuronNetwork  ConcreteType='ChooseBetweenFirstAndSecondFavoriteNeuronNetwork'  NumberOfPastPerformances = '{0}' >", NumberOfPastPerformances); 
            }
        }
    }
}