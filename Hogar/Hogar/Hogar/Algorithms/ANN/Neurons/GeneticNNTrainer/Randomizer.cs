using System;

namespace Hogar.Algorithms.ANN.Neurons.GeneticNNTrainer
{
    static public class Randomizer
    {
        static readonly private Random _random = new Random();

        static public double GetRandomProbability()
        {
            return _random.NextDouble();
        }

        static public double GetRandomWeight()
        {

            int sign = (0 == _random.Next() % 2 ? -1 : 1);
            return sign * _random.NextDouble();
        }

        static public int GetRandomIndex(int max)
        {
            return _random.Next(0, max);
        }

    }
}