using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    static class Randomizer
    {
        static readonly Random _random = new Random(DateTime.Now.Millisecond);


        static public double GetNextWeight()
        {
            return (double)_random.Next(1, 101);
        }

        static public int GetNextInteger(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
