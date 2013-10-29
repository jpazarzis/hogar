using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer
{
    public class Chromosome
    {
        private readonly double[] _weight;

        static internal Chromosome Clone(Chromosome c1, Chromosome c2)
        {
            return c1.Count == c2.Count ? new Chromosome(c1, c2) : null;
        }

        static internal Chromosome Make(int count)
        {
            return new Chromosome(count);
        }

        public int Count
        {
            get
            {
                return _weight.Count();
            }
        }

        public double this[int index]
        {
            get
            {
                return _weight[index];
            }
        }

        protected Chromosome(int count)
        {
            _weight = new double[count];
            Initialize();
        }

        protected Chromosome(Chromosome c1, Chromosome c2)
        {
            Debug.Assert(c1.Count == c2.Count);

            if (1 == Randomizer.GetRandomIndex(2))
            {
                var temp = c1;
                c1 = c2;
                c2 = temp;
            }


            _weight = new double[c2.Count];

            int crossOverIndex = Randomizer.GetRandomIndex(c2.Count);
            
            for (int i = 0; i < _weight.Count(); ++i)
            {
                _weight[i] = i < crossOverIndex ? c1[i] : c2[i];
            }

            const double mutationRate = 0.1;

            for (int i = 0; i < _weight.Count(); ++i)
            {
                if (Randomizer.GetRandomProbability() <= mutationRate)
                    _weight[i] = Randomizer.GetRandomWeight();
            }

        }

        protected void Initialize()
        {
            for(int i=0; i < _weight.Count(); ++i)
            {
                _weight[i] = Randomizer.GetRandomWeight();
            }
        }


        public double ROI { get; set; }

        public double SelectionRate { get; set; }

        public override string ToString()
        {
            return string.Format("ROI = {0:0.00} Rate = {1:0.00} ", ROI, SelectionRate);
        }

    }
}
