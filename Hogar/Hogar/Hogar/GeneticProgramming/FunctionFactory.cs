using System.Collections.Generic;

namespace Hogar.GeneticProgramming
{
    static class FunctionFactory
    {
        public delegate Node Maker(int minid, int maxid, Node parent);

        private static readonly List<Maker> _functions = new List<Maker>();

        static public Node MakeRandomFunction(int minid, int maxid, Node parent)
        {
            if(_functions.Count == 0)
            {
                _functions.Add(FunctionAnd.Make);
                _functions.Add(FunctionOr.Make);
                _functions.Add(FunctionNot.Make);
            }

            if (_functions.Count <= 0)
            {
                return null;
            }

            return _functions[Randomizer.GetRandomInteger(_functions.Count)](minid, maxid,parent);
        }

        static public void Register(Maker maker)
        {
            _functions.Add(maker);
        }
    }
}