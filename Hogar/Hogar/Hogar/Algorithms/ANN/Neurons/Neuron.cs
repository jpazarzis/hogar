using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Algorithms.ANN.Neurons
{
    

    public class Neuron
    {
        protected double _value = 0.0;

        readonly List<Synapse> _synapses = new List<Synapse>();

        private static int _nextId = 1;
        protected readonly int _id;

        internal Neuron()
        {
            _id = _nextId++;
        }

        internal Neuron(int id)
        {
            _id = id;
        }

        virtual public string GetAsXml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("<Neuron id='{0}'/>",_id));
            return sb.ToString();
        }

        internal int Id
        {
            get
            {
                return _id;
            }
        }

        virtual public string GetSynapsesAsXml()
        {
            var sb = new StringBuilder();
            _synapses.ForEach(s=>sb.AppendLine(s.GetAsXml()));
            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format("id: {0}  Value = {1:0.00}", _id,Value);
        }

        public void ClearSynapses()
        {
            _synapses.Clear();
        }

        public int CountSynapses
        {
            get
            {
                return _synapses.Count;
            }
        }

        public Synapse this [int index]
        {
            get
            {
                return index >= 0 && index < _synapses.Count ? _synapses[index] : null;
            }
        }

        public IEnumerable<Synapse> Synapses
        {
            get
            {
                return _synapses;
            }
        }

        internal void Add(Synapse synapse)
        {
            _synapses.Add(synapse);
        }

        public void Connect(NeuronLayer neuronLayer)
        {
            neuronLayer.Neurons.ToList().ForEach(n => _synapses.Add(new Synapse(this, n)));
        }

        internal void ApplySigmoid()
        {
            _value = Utilities.Sigmoid(Value);
        }

        virtual public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        
    }
}
