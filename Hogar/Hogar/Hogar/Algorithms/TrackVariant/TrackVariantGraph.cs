using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.Algorithms.TrackVariant
{
    public class TrackVariantGraph
    {
        /// <summary>
        /// Returns a collection of all the available verteces
        /// </summary>
        /// 
        /// 
        private List<List<DatesEdge>> _cycles = null;

        public IEnumerable<DateVertex> Verteces
        {
            get
            {
                for (int i = 0; i < _verteces.Count; ++i)
                {
                    yield return _verteces[i];
                }
            }
        }


        private void RemoveVertex(DateVertex v)
        {
            // We want to enforce the re-assignment of cycles 
            _cycles = null;

            v = _verteces.Find(v1 => v.Key == v1.Key);

            if(null != v)
            {
                _verteces.Remove(v);
                _edges.Remove(v.Key);

                foreach (var key in _edges.Keys)
                {
                    var list = _edges[key];
                    int index = 0;
                    while(index < list.Count)
                    {
                        var e = list[index];
                        if(e.V1.Key == v.Key || e.V2.Key == v.Key)
                        {
                            list.Remove(e);
                            --index;
                        }
                        ++index;
                    }
                }
            }
        }

        public void InsertBidectionalEdge(string key1, double time1, string key2, double time2)
        {
            InsertEdge(key1, time1, key2, time2);
            InsertEdge(key2, time2, key1, time1);
        }

        public void InsertEdge(string key1, double time1, string key2, double time2)
        {
            _cycles = null;

            var edge = GetEdge(key1, key2);

            if(null == edge)
            {
                edge = new DatesEdge()
                {
                    V1 = GetVertex(key1),
                    V2 = GetVertex(key2)
                };

                GetEdges(key1).Add(edge);
            }

            edge.AddTimePair(time1,time2);
            
        }

        public DatesEdge GetEdge(string key1, string key2)
        {
            return GetEdges(key1).Find(e => e.V1.Key == key1 && e.V2.Key == key2);
        }

        public bool EdgeExits(string key1, string key2)
        {
            return null != GetEdge(key1, key2);
        }

        private const int INVALID_VARIANT = -9999;

        public void InitializeVariant()
        {
            Verteces.ToList().ForEach(v => 
            { 
                v.Visited = false;
                v.Variant = INVALID_VARIANT;
            });

            var vertex = Verteces.ToList()[0];

            var stack = new Stack<DateVertex>();

            stack.Push(vertex);
            vertex.Visited = true;
            vertex.Variant = GetEdges(vertex.Key)[0].AbsoluteTimeDiff;
            

            while (stack.Count > 0)
            {
                InitializeVariant(stack);
            }

            for (int i = 0; i < _verteces.Count; ++i)
            {
                var vx = _verteces[i];
                if (vx.Variant == INVALID_VARIANT)
                {
                    RemoveVertex(vx);
                    --i;
                }
            }
        }

        private void LoadCyclesIfNeeded()
        {
            if (null == _cycles)
            {
                _cycles = GraphUtilities.GetAllCyclesAsEdges(this);

                for (int i = 0; i < _verteces.Count; ++i)
                {
                    var v = _verteces[i];
                    if (v.NumberOfCycles > 0)
                        continue;
                    RemoveVertex(v);
                    --i;
                }

                _cycles = GraphUtilities.GetAllCyclesAsEdges(this);

                Debug.Assert(Verteces.Where(v => v.NumberOfCycles <= 0).Count() == 0);
            }
        }

        public double AdjustVariant()
        {

            Verteces.ToList().ForEach(v => v.ClearVariantAdjustments());

            LoadCyclesIfNeeded();

            foreach (var cycle in _cycles)
            {
                cycle.ForEach(e =>
                                  {
                                      if (null != e)
                                      {
                                          e.AdjsutVariants();
                                      }
                                  });
            }

            Verteces.ToList().ForEach(v => v.RecalculateVariant());

            return Utilities.CalculateStdDev(Verteces.Select(v => v.DifferenceFromPreviousVariant));
        }

        private readonly List<DateVertex> _verteces = new List<DateVertex>();

        private readonly Dictionary<string, List<DatesEdge>> _edges = new Dictionary<string, List<DatesEdge>>();

        private DateVertex GetVertex(string key)
        {
            DateVertex v = _verteces.Find(vx => vx.Key == key);

            if (null == v)
            {
                v = new DateVertex(key);
                _verteces.Add(v);
            }

            return v;
        }

        internal List<DateVertex> GetAdjustentVerteces(DateVertex vertex)
        {
            var list = new List<DateVertex>();
            GetEdges(vertex.Key).ForEach(e => list.Add(e.V2));
            return list;
        }

        public List<DatesEdge> GetAllAvailableEdges()
        {
            var edges = new List<DatesEdge>();
            _verteces.ForEach(v => GetEdges(v.Key).ForEach(edges.Add));
            return edges;
        }

        public List<DatesEdge> GetEdges(string key)
        {
            if (!_edges.ContainsKey(key))
            {
                _edges.Add(key, new List<DatesEdge>());
            }

            return _edges[key];
        }

        /*
        private static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum)/(values.Count() - 1));
            }
            return ret;
        }
         */

        private void InitializeVariant(Stack<DateVertex> stack)
        {
            var v = stack.Pop();

            foreach (var dateVertex in GetAdjustentVerteces(v))
            {
                if (!dateVertex.Visited)
                {
                    dateVertex.Visited = true;
                    dateVertex.Variant = GetEdge(dateVertex.Key, v.Key).AbsoluteTimeDiff;
                    if(v.Variant == INVALID_VARIANT)
                    {
                        v.Variant = (-1.0)*dateVertex.Variant;
                    }
                    stack.Push(dateVertex);

                    while (stack.Count > 0)
                    {
                        InitializeVariant(stack);
                    }
                }
            }

        }

        public void NormalizeVariant()
        {
            double minVar = Verteces.Min(v => v.Variant);

            Verteces.ToList().ForEach(v=>v.Variant-=minVar);
        }
    }
}