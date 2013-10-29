using System;
using System.Text;

namespace Hogar.Algorithms.ANN.Neurons
{
    public class Synapse
    {
        readonly private Neuron _from;
        readonly private Neuron _to;

        private double _weight = 0;

        static readonly private Random _random = new Random();


        internal Synapse(Neuron n1, Neuron n2, double weight)
        {
            _from = n1;
            _to = n2;
            Weight = weight;
        }

        public Synapse(Neuron n1, Neuron n2)
        {
            _from = n1;
            _to = n2;

            int sign = (0 == _random.Next() % 2 ? -1 : 1);


            Weight = sign * _random.NextDouble() ;

            //Weight = sign * _random.NextDouble() / 2.0;
        }

        public double DeltaWeight { get; private set; }

        public double Weight 
        { 
            get
            {
                return _weight;
            }
            set
            {
                DeltaWeight = _weight - value;
                _weight = value;
            }
        }


        virtual public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("<Synapse FromNeuronID='{0}' ToNeuronID='{1}' Weight = '{2:0.00}' />",_from.Id,_to.Id, Weight));
            return sb.ToString();
        }


        public Neuron Neuron1
        {
            get
            {
                return _from;
            }
        }

        public Neuron Neuron2
        {
            get
            {
                return _to;
            }
        }

    }
}