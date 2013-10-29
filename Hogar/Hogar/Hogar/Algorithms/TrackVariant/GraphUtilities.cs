using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hogar.Algorithms.TrackVariant
{
    internal static class GraphUtilities
    {
        private static TrackVariantGraph _g;
        private static readonly Stack<DateVertex> _stack = new Stack<DateVertex>();
        private static string _target;
        private static readonly List<List<DateVertex>> _cycles = new List<List<DateVertex>>();

        private static int _maxCycleLength = 3;


      


        public static List<List<DatesEdge>> GetAllCyclesAsEdges(TrackVariantGraph g)
        {
            _g = g;
            _cycles.Clear();
            g.Verteces.ToList().ForEach(v => Traverse(v));
            return TransformVertecesCycleToEdges();
        }


        static private List<List<DatesEdge>> TransformVertecesCycleToEdges()
        {
            var list = new List<List<DatesEdge>>();

            foreach (var vl in _cycles)
            {
                if (vl.Count <= 2)
                    continue;

                var de = new List<DatesEdge>();
                for (int i = 0; i < vl.Count - 1; ++i)
                {
                    de.Add(_g.GetEdge(vl[i].Key, vl[i + 1].Key));
                }

                de.Add(_g.GetEdge(vl[vl.Count - 1].Key, vl[0].Key));


                list.Add(de);
            }

            return list;
        }


        public static List<List<DateVertex>> GetAllCyclesAsVerteces(TrackVariantGraph g)
        {
            _g = g;
            _cycles.Clear();
            g.Verteces.ToList().ForEach(v => Traverse(v));
            return _cycles;
        }

        private static List<List<DateVertex>> Traverse(DateVertex startingVertex)
        {
            _stack.Clear();
            _g.Verteces.ToList().ForEach(v => v.Visited = false);
            _target = startingVertex.Key;
            _stack.Push(startingVertex);
            startingVertex.Visited = true;
            MakeAVisit();
            return _cycles;
        }

        private static void MakeAVisit()
        {

            if (_stack.Count <= 0)
                return;

            Debug.Assert(_stack.Count <= _maxCycleLength);

            var v = _stack.Peek();
            foreach (var node in _g.GetAdjustentVerteces(v))
            {
                if (node.Key == _target && _stack.Count >= 3)
                {
                   Debug.Assert(_stack.Count <= _maxCycleLength);
                    AddStackToCycles();
                }

                else if (!node.Visited && _stack.Count < _maxCycleLength)
                {
                    _stack.Push(node);
                    node.Visited = true;
                    MakeAVisit();
                    node.Visited = false;
                }

                
            }
            _stack.Pop();
        }

        private static void AddStackToCycles()
        {
            var c = new List<DateVertex>();
            _stack.ToList().ForEach(c.Add);
            c = c.OrderBy(v => v.Key).ToList();

            if (!CycleAlreadyContained(c))
            {
                _cycles.Add(c);

                c.ForEach(v => 
                    { 
                        v.NumberOfCycles++;
                        v.MinCycleSize = c.Count;
                    });
            }

        }


        private static bool CycleAlreadyContained(List<DateVertex> c)
        {
            foreach (var c1 in _cycles)
            {
                if (c.Count == c1.Count)
                {
                    bool found = true;

                    for (int j = 0; j < c1.Count && found; j++)
                    {
                        if (c1[j] != c[j])
                        {
                            found = false;
                        }
                    }

                    if (found)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


    }
}