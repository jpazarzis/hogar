using System;
using System.Linq;
using System.Text;
using System.Xml;
using Hogar.Algorithms.ANN.PatternStatistics;
using Hogar.Research.GeneticAlgorithm;

namespace Hogar.Algorithms.ANN.Neurons
{
    public class OutputLayer : NeuronLayer
    {
        static new public OutputLayer Make(XmlNode layerNode)
        {
            var layer = new OutputLayer(0);

            layer._neurons.Clear();
            foreach (XmlNode neuronNode in layerNode.SelectNodes("OutputNeuronNeuron"))
            {
                int id = Convert.ToInt32(neuronNode.Attributes["id"].Value);
                layer.AddSingleNeuron(new OutputNeuron(id));
            }

            return layer;
        }

        static public OutputLayer Make(int lengthOfComparisonCombination)
        {
            return new OutputLayer(lengthOfComparisonCombination);
        }

        override public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<OutputLayer>");
            _neurons.ForEach(n => sb.AppendLine(n.GetAsXml()));
            sb.AppendLine("</OutputLayer>");
            return sb.ToString();
        }

        public void Clear()
        {
            _neurons.Clear();
        }

        protected override void AddNeurons(int count)
        {
            throw new Exception("This method should never be called!");
        }

        public OutputNeuron GetWinningNeuron()
        {
            
            OutputNeuron winner = null;

            foreach (var neuron in Neurons)
            {
                var n = (OutputNeuron) neuron;
                
                if (null == winner || winner.Value < n.Value)
                {
                    winner = n;
                }
            }
            return winner;
        }


        protected OutputLayer(int lengthOfComparisonCombination)
        {
            for (int i = 0; i < lengthOfComparisonCombination; ++i )
            {
                _neurons.Add(new OutputNeuron());
            }
                
        }
    }
}