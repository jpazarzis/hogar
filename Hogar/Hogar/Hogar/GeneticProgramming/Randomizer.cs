using System;

namespace Hogar.GeneticProgramming
{
    static public class Randomizer
    {
        static readonly Random _random = new Random(DateTime.Now.Millisecond);
        
        static public int GetRandomInteger(int range)
        {
            return _random.Next(range);
        }
    }
}