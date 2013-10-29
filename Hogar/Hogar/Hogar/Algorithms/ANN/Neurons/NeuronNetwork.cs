using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;

namespace Hogar.Algorithms.ANN.Neurons
{

    public interface INeuronNetworkConstructor
    {
    
    }

    public class DetectWinnerNeuronNetworkConstructor : INeuronNetworkConstructor
    {
        public int NumberOfPastPerformancesToUse { get; set; }
        public int FieldSize { get; set; }
    }

    public class DetectLifeLongshotNeuronNetworkConstructor : INeuronNetworkConstructor
    {
        public int NumberOfPastPerformances { get; set; }
    }

    public class ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor : INeuronNetworkConstructor
    {
        public int NumberOfPastPerformances { get; set; }
    }
    

    public abstract class NeuronNetwork
    {
        protected readonly List<NeuronLayer> _layers = new List<NeuronLayer>();

        protected NeuronLayer _inputLayer;
        protected OutputLayer _outputLayer;


        static public NeuronNetwork MakeFromXmlFile(string xmlFilename)
        {
            try
            {
                NeuronNetwork nn = null;
                var doc = new XmlDocument();
                doc.Load(xmlFilename);
                string concreteType = doc.SelectSingleNode("/NeuronNetwork").Attributes["ConcreteType"].Value;


                if (concreteType == "DetectWinnerNeuronNetwork")
                {
                    nn = new DetectWinnerNeuronNetwork();
                }
                else if (concreteType == "DetectLifeLongshotNeuronNetwork")
                {
                    nn = new ChooseBetweenFirstAndSecondFavoriteNeuronNetwork();
                }
                else if (concreteType == "ChooseBetweenFirstAndSecondFavoriteNeuronNetwork")
                {
                    nn = new ChooseBetweenFirstAndSecondFavoriteNeuronNetwork();
                }
                // new concrete types are going here.....

                if(null != nn)
                {
                    nn.Filename = xmlFilename;
                    nn.LoadFromXmlFile(doc);    
                }
                

                return nn;
            }
            catch
            {
                return null;
            }
        }

        static public NeuronNetwork Make(INeuronNetworkConstructor constructionInfo)
        {

            NeuronNetwork nn = null;

            if(constructionInfo is DetectWinnerNeuronNetworkConstructor)
            {
                var ci = constructionInfo as DetectWinnerNeuronNetworkConstructor;
                nn = new DetectWinnerNeuronNetwork(ci.NumberOfPastPerformancesToUse, ci.FieldSize);   
            }
            else if (constructionInfo is ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor)
            {
                var ci = constructionInfo as ChooseBetweenFirstAndSecondFavoriteNeuronNetworkConstructor;

                nn = new ChooseBetweenFirstAndSecondFavoriteNeuronNetwork(ci);
            }

            if (null != nn)
            {
                nn.CreateInputLayer();
                
            }

            return nn;
        }

        public int NumberOfSynapses
        {
            get
            {
                return _layers.Sum(l => l.NumberOfSynapses);
            }
        }

        private List<Synapse> Synapses
        {
            get
            {
                return (from layer in _layers
                        from neuron in layer.Neurons
                        from synapse in neuron.Synapses
                        select synapse).ToList();
            }
        }

        

        public IEnumerable<NeuronLayer> Layers { get { return _layers; } }


        public string ConcreteName { get; protected set; }

        public void AssignSynapticWeightsFromChromosome(Chromosome chromosome)
        {
            Debug.Assert(chromosome.Count == NumberOfSynapses);

            var synapses = Synapses;

            for(int i = 0; i < chromosome.Count; ++i)
            {
                synapses[i].Weight = chromosome[i];        
            }
        }
        
        public double Train(List<StarterInfo> starters)
        {
            UpdateInputLayer(starters);
            UpdateOutputLayer(starters);
            UpdateNeuronValues();
            Backpropagate();
            return ErrorFactor;
        }

        public OutputLayer OutputLayer
        {
            get
            {
                return _outputLayer;
            }
        }

        public OutputNeuron GetWinningNeuron(List<StarterInfo> starters)
        {
            UpdateInputLayer(starters);
            UpdateOutputLayer(starters);
            UpdateNeuronValues();
            return _outputLayer.GetWinningNeuron();
        }

        public void AddHiddenLayer(int count)
        {
            _layers.Add(NeuronLayer.Make(count));
        }

        private void UpdateNeuronValues()
        {
            for (int i = 1; i < _layers.Count; ++i)
            {
                _layers[i].Neurons.ToList().ForEach(n => n.Value = 0);
            }

            for (int layerIndex = 0; layerIndex < _layers.Count - 1; ++layerIndex)
            {
                foreach (var neuron in _layers[layerIndex].Neurons)
                {
                    foreach (var synapse in neuron.Synapses)
                    {
                        synapse.Neuron2.Value += neuron.Value * synapse.Weight;
                    }
                }

                foreach (var neuron in _layers[layerIndex + 1].Neurons)
                {
                    neuron.ApplySigmoid();
                }

            }
        }

        public abstract void AddOutputLayer();

        protected abstract void CreateInputLayer();

        protected abstract void UpdateInputLayer(List<StarterInfo> starters);

        protected abstract void UpdateOutputLayer(List<StarterInfo> starters);

        protected abstract string MakeFilename();

        protected abstract void InitializeFromXml(XmlDocument doc);

        protected abstract string XmlRootElement { get; }

        protected void ConnectLayers()
        {
            _layers.ForEach(l => l.Neurons.ToList().ForEach(n => n.ClearSynapses()));

            for (int i = 0; i < _layers.Count - 1; ++i)
            {
                _layers[i].Neurons.ToList().ForEach(n => n.Connect(_layers[i + 1]));
            }
        }

        private double ErrorFactor
        {
            get
            {
                double error = 0;

                foreach (var n in _outputLayer.Neurons)
                {
                    var neuron = n as OutputNeuron;

                    error += Math.Pow(neuron.DesiredValue - neuron.Value, 2);
                    
                    
                }

                error = error/2.0;
                return error;
    
            }
        }

        private void Backpropagate()
        {
            if (null == _outputLayer)
                return;

            

            double learningFactor = 0.12;


            foreach (var n in _outputLayer.Neurons)
            {
                var neuron = n as OutputNeuron;
                double error = neuron.DesiredValue - neuron.Value;
                //ErrorFactor += Math.Pow(error, 2);
                for (int i = _layers.Count - 1; i >= 0; --i)
                {
                    _layers[i].AdjustSynapticWeights(neuron, error, learningFactor);
                }
            }
        }


        static public DetectWinnerNeuronNetwork Published
        {
            get
            {
                return null;
            }
        }


        public string Filename { get; protected set; }

        static public List<string> AvailableNNFiles
        {
            get
            {
                var files = new List<string>();

                if (Directory.Exists(Utilities.NeuronNetworkDirectory))
                {
                    files.AddRange(Directory.GetFiles(@"nn*.xml").Select(file => Path.GetFileNameWithoutExtension(file)));
                }

                return files;
            }
        }

        public void SaveAsXmlFile()
        {
            string dir = Utilities.NeuronNetworkDirectory;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            Filename = string.Format(@"{0}\{1}", dir, MakeFilename());

            using (var f = new StreamWriter(Filename))
            {
                f.WriteLine(GetAsXml());
            }
        }

        protected void AssignSynapses(XmlDocument doc)
        {
            var map = new Dictionary<int, Neuron>();
            _layers.ForEach(layer => layer.Neurons.ToList().ForEach(neuron => map.Add(neuron.Id, neuron)));
            foreach (XmlNode synapsesNode in doc.SelectNodes("/NeuronNetwork/Synapses"))
            {
                foreach (XmlNode synapseNode in synapsesNode.SelectNodes("Synapse"))
                {
                    int fromNeuronId = Convert.ToInt32(synapseNode.Attributes["FromNeuronID"].Value);
                    int toNeuronId = Convert.ToInt32(synapseNode.Attributes["ToNeuronID"].Value);
                    double weight = Convert.ToDouble(synapseNode.Attributes["Weight"].Value);
                    map[fromNeuronId].Add(new Synapse(map[fromNeuronId], map[toNeuronId], weight));
                }
            }
        }

        protected void AssignOutputLayer(XmlDocument doc)
        {
            XmlNode outputlayerNode = doc.SelectSingleNode("/NeuronNetwork/Layers/OutputLayer");
            _outputLayer = OutputLayer.Make(outputlayerNode);
            _layers.Add(_outputLayer);
        }

        private void AssignLayers(XmlDocument doc)
        {
            _layers.Clear();

            _inputLayer = null;
            _outputLayer = null;

            foreach (XmlNode layerNode in doc.SelectNodes("/NeuronNetwork/Layers/NeuronLayer"))
            {
                var layer = NeuronLayer.Make(layerNode);

                if (null == _inputLayer)
                    _inputLayer = layer;

                _layers.Add(layer);
            }
        }

        private string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(XmlRootElement);
            sb.AppendLine("<Layers>");
            _layers.ForEach(l => sb.AppendLine(l.GetAsXml()));
            sb.AppendLine("</Layers>");
            sb.AppendLine("<Synapses>");
            _layers.ForEach(l => sb.AppendLine(l.GetAsSynapsesXml()));
            sb.AppendLine("</Synapses>");
            sb.AppendLine("</NeuronNetwork>");
            return sb.ToString();
        }

        private void LoadFromXmlFile(XmlDocument doc)
        {
            _layers.Clear();
            _inputLayer = null;
            _outputLayer = null;

            try
            {    
                InitializeFromXml(doc);
                AssignLayers(doc);
                AssignOutputLayer(doc);
                AssignSynapses(doc);
            }
            catch
            {
                Filename = "";
                _layers.Clear();
                _inputLayer = null;
                _outputLayer = null;
                throw;
            }
        }
    }
}