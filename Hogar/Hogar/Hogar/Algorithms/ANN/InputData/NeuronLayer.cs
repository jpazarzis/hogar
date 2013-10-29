using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Hogar.Algorithms.ANN.Neurons
{
    public class NeuronLayer
    {
        protected readonly List<Neuron> _neurons = new List<Neuron>();

        static public NeuronLayer Make(XmlNode layerNode)
        {
            var layer = new NeuronLayer();

            foreach (XmlNode neuronNode in layerNode.SelectNodes("Neuron"))
            {
                layer.AddSingleNeuron(new Neuron(Convert.ToInt32(neuronNode.Attributes["id"].Value)));
            }

            XmlNode tresholdNeuron = layerNode.SelectSingleNode("TresholdNeuron");
            layer.AddSingleNeuron(new TresholdNeuron(Convert.ToInt32(tresholdNeuron.Attributes["id"].Value)));
            return layer;
        }


        static public NeuronLayer Make(int count)
        {
            var layer = new NeuronLayer();
            layer.AddNeurons(count);
            
            return layer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            _neurons.ForEach(n=>sb.Append(string.Format("{0} ", n.ToString())));
            return sb.ToString();
        }

        protected NeuronLayer()
        {
            
        }

        public int NumberOfInputsNeeded
        {
            get
            {
                return 0;
            }
        }

        virtual public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<NeuronLayer>");
            _neurons.ForEach(n=>sb.AppendLine(n.GetAsXml()));
            sb.AppendLine("</NeuronLayer>");
            return sb.ToString();
        }

        virtual public string GetAsSynapsesXml()
        {
            var sb = new StringBuilder();
            _neurons.ForEach(n => sb.AppendLine(n.GetSynapsesAsXml()));
            return sb.ToString();
        }

        public IEnumerable<Synapse> Synapses
        {
            get
            {
                foreach (var neuron in _neurons)
                {
                    foreach (var synapse in neuron.Synapses)
                    {
                        yield return synapse;
                    }
                }
            }
        }

        public int NumberOfSynapses
        {
            get
            {
                return _neurons.Sum(neuron => neuron.Synapses.ToList().Count);
            }
        }

        public void AdjustSynapticWeights(Neuron targetNeuron, double error, double learningFactor)
        {

            double momentum = 0.0;
            foreach (var neuron in _neurons)
            {
                foreach (var synapse in neuron.Synapses)
                {
                    if (synapse.Neuron2 == targetNeuron)
                    {
                        double delta = learningFactor * error * synapse.Neuron1.Value;
                        synapse.Weight = synapse.Weight + delta + momentum * synapse.DeltaWeight;
                    }
                }
            }
        }


        public IEnumerable<Neuron> Neurons
        {
            get
            {
                return _neurons;
            }
        }

        public Neuron this[int index]
        {
            get 
            { 
                return index >= 0 && index < _neurons.Count ?  _neurons[index] : null; 
            }
        }

        public int Count
        {
            get
            {
                return _neurons.Count;
            }
        }

        virtual protected void AddSingleNeuron(Neuron neuron)
        {
            _neurons.Add(neuron);
        }

        virtual protected void AddNeurons(int count)
        {
            for(int i = 0; i < count; ++i)
            {
                _neurons.Add(new Neuron());
            }

            _neurons.Add(new TresholdNeuron());
            
        }
    }
}