using System.Collections.Generic;

namespace Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer
{
    public class Generation : List<Chromosome>
    {
        static public Generation Make(int numberOfChromosomes, int numberOfWeights)
        {
            return new Generation(numberOfChromosomes, numberOfWeights);
        }    

        protected Generation(int numberOfChromosomes, int numberOfWeights)
        {
            for(int i =0; i < numberOfChromosomes; ++i)
            {
                Add(Chromosome.Make(numberOfWeights));
            }
        }

        private void GetRandomIndeces(int max, out int i1, out int i2)
        {
            i1 = Randomizer.GetRandomIndex(max);
            i2 = Randomizer.GetRandomIndex(max);
            while (i2 == i1)
            {
                i2 = Randomizer.GetRandomIndex(max);
            }
        }

        public void Clone()
        {
            var bestSoFar = new List<Chromosome>();


            
            int count = 5;
            for (int i = 0; i < count; ++i)
            {
                bestSoFar.Add(this[i]);
            }

            

            for (int i = 5; i < this.Count ; ++i)
            {
                int index1, index2;
                GetRandomIndeces(count, out index1, out index2);
                this[i] = Chromosome.Clone(bestSoFar[index1], bestSoFar[index2]);
            }
        }

        
    }
}