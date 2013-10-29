using System.Text;

namespace Hogar.Algorithms.ANN.Neurons
{
    public class TresholdNeuron : Neuron
    {
        public TresholdNeuron(int id) : base(id)
        {
            
        }


        public TresholdNeuron()
        {

        }


        override public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("<TresholdNeuron id='{0}'/>", _id));
            return sb.ToString();
        }

        public override double Value
        {
            get
            {
                return 1;
            }
            set
            {}
        }
    }
}