using System.Text;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Algorithms.ANN.PatternStatistics;

namespace Hogar.Algorithms.ANN.Neurons
{
    public class OutputNeuron : Neuron
    {
       
        public OutputNeuron(int id) : base(id)
        {
            
        }

        internal OutputNeuron()
        {
            
        }

        public double DesiredValue { get; set;}

        public StarterInfo StarterInfo { get; set; }

        override public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("<OutputNeuronNeuron id='{0}' />", _id));
            return sb.ToString();
        }
       
        public override string ToString()
        {
            return string.Format("Desired Value : {0:0.00}",DesiredValue);
        }
    }
}