using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.PatternStatistics;

namespace Hogar.Algorithms.ANN.Neurons.NeuronNetworks
{
    public partial class DetectWinnerNeuronNetwork : NeuronNetwork
    {
        internal DetectWinnerNeuronNetwork(int numberOfPastPerformancesToUse, int fieldSize)
        {
            _numberOfPastPerformancesToUse = numberOfPastPerformancesToUse;
            _fieldSize = fieldSize;
            ConcreteName = "DetectWinner";
        }

        internal DetectWinnerNeuronNetwork()
        {
            ConcreteName = "DetectWinner";
        }

       
        protected override void InitializeFromXml(XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode("/NeuronNetwork");
            int.TryParse(node.Attributes["NumberOfPPToUse"].Value, out _numberOfPastPerformancesToUse);
            int.TryParse(node.Attributes["FieldSize"].Value, out _fieldSize);
        }


        protected override string MakeFilename()
        {
            return string.Format("nn_dw_{0}_{1}.xml", _fieldSize, _numberOfPastPerformancesToUse);
        }

        protected override string XmlRootElement 
        { 
            get
            {
                return string.Format("<NeuronNetwork  ConcreteType='DetectWinnerNeuronNetwork'  NumberOfPPToUse = '{0}' FieldSize = '{1}'>", _numberOfPastPerformancesToUse, _fieldSize);
            }
        }

        public int NumberOfPastPerformancesUsed
        {
            get
            {
                return _numberOfPastPerformancesToUse;
            }
        }

        public int FieldSize
        {
            get
            {
                return _fieldSize;
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0} FieldSize: {1} PPs: {2} {3}", ConcreteName, FieldSize, _numberOfPastPerformancesToUse, Filename);
        }

        public override void AddOutputLayer()
        {    
            _outputLayer = OutputLayer.Make(_fieldSize);
            _layers.Add(_outputLayer);
            ConnectLayers();
        }

#region details

        private int _numberOfPastPerformancesToUse;
        private int _fieldSize;


        // Used for training and testing only... 
        protected override void UpdateInputLayer(List<StarterInfo> starters)
        {
            var input = StarterInfo.NormalizedInputForWinnerDetection(starters, _numberOfPastPerformancesToUse);

            Debug.Assert(input.Count + 1 == _inputLayer.Count);

            for (int i = 0; i < input.Count; ++i)
            {
                _inputLayer[i].Value = input[i];
            }
        }

        protected override void UpdateOutputLayer(List<StarterInfo> starters)
        {
            OutputNeuron neuronWithHighestFinishPosition = null;

            for (int i = 0; i < starters.Count; ++i)
            {
                var outputNeuron = (OutputNeuron)_outputLayer[i];

                outputNeuron.StarterInfo = starters[i];
                outputNeuron.DesiredValue = 0.0;

                if (null == neuronWithHighestFinishPosition ||
                    outputNeuron.StarterInfo.FinishPosition < neuronWithHighestFinishPosition.StarterInfo.FinishPosition)
                {
                    neuronWithHighestFinishPosition = outputNeuron;
                }
            }

            neuronWithHighestFinishPosition.DesiredValue = 1.0;

        }

        

        protected override  void CreateInputLayer()
        {
            _layers.Clear();
            _inputLayer = NeuronLayer.Make(StarterInfo.GetNumberOfInputsForWinnerDetection(_numberOfPastPerformancesToUse, _fieldSize));
            _layers.Add(_inputLayer);
        }


#endregion 
    }
}