using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Hogar.Algorithms.ANN.InputData;

namespace Hogar.Algorithms.ANN.Neurons.NeuronNetworks
{
    public class DetectImprovementNeuronNetwork : NeuronNetwork
    {
        public int NumberOfPastPerformances { get; set; }

        public DetectImprovementNeuronNetwork(ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor ci)
        {
            NumberOfPastPerformances = ci.NumberOfPastPerformances;
            ConcreteName = "DetectImprovementNeuronNetwork";
        }

        public DetectImprovementNeuronNetwork()
        {
            ConcreteName = "DetectImprovementNeuronNetwork";
        }

        public override string ToString()
        {
            return string.Format("{0} PPs: {1}  {2}", ConcreteName, NumberOfPastPerformances, Filename);
        }

        public override void AddOutputLayer()
        {
            _outputLayer = OutputLayer.Make(3);
            _layers.Add(_outputLayer);
            ConnectLayers();
        }

        protected override void CreateInputLayer()
        {
            _layers.Clear();
            _inputLayer = NeuronLayer.Make(StarterInfo.GetNumberOfInputsForImprovementDetection(NumberOfPastPerformances));
            _layers.Add(_inputLayer);
        }

        protected override void UpdateInputLayer(List<StarterInfo> starters)
        {
            Debug.Assert(starters.Count == 1);

            StarterInfo si = starters[0];

            var input = StarterInfo.NormalizedInputForImprovementDetection(si, NumberOfPastPerformances);

            for (int i = 0; i < input.Count; ++i)
            {
                _inputLayer[i].Value = input[i];
            }
        }

        protected override void UpdateOutputLayer(List<StarterInfo> starters)
        {
            Debug.Assert(starters.Count == 1);

            StarterInfo si = starters[0];

            Debug.Assert(1 == _outputLayer.Count);
            
            OutputNeuron outputNeuron;

            for(int i = 0; i < 3; ++i)
            {
                outputNeuron = (OutputNeuron)_outputLayer[i];
                outputNeuron.DesiredValue = 0.0;
                outputNeuron.StarterInfo = si;
            }

            if (si.GoldenFigure > si.Previous.GoldenFigure && si.GoldenFigure > si.Previous.Previous.GoldenFigure && si.GoldenFigure > si.Previous.Previous.Previous.GoldenFigure)
            {
                outputNeuron = (OutputNeuron)_outputLayer[0];
            }
            else if (si.GoldenFigure < si.Previous.GoldenFigure && si.GoldenFigure < si.Previous.Previous.GoldenFigure && si.GoldenFigure < si.Previous.Previous.Previous.GoldenFigure)
            {
                outputNeuron = (OutputNeuron)_outputLayer[1];
            }
            else
            {
                outputNeuron = (OutputNeuron)_outputLayer[2];
            }

            outputNeuron.DesiredValue = 1.0;
            
        }

        protected override string MakeFilename()
        {
            return string.Format("nn_impovement_{0}.xml", NumberOfPastPerformances);
        }

        protected override void InitializeFromXml(XmlDocument doc)
        {
            int pps;
            XmlNode node = doc.SelectSingleNode("/NeuronNetwork");

            int.TryParse(node.Attributes["NumberOfPastPerformances"].Value, out pps);
            NumberOfPastPerformances = pps;
        }

        protected override string XmlRootElement { get { return string.Format("<NeuronNetwork  ConcreteType='DetectImprovementNeuronNetwork'  NumberOfPastPerformances = '{0}' >", NumberOfPastPerformances); } }
    }
}