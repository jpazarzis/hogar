using System.Collections.Generic;

namespace ExoticStudio
{
    public class WeightLimitation
    {
        readonly List<int> _limitation = new List<int>();

        public void Clear()
        {
            _limitation.Clear();
        }

        public bool ContainsWeight(int weight)
        {
            return _limitation.Contains(weight);
        }

        public void Add(int weight)
        {
            if(!_limitation.Contains(weight))    
                _limitation.Add(weight);
        }

        public void Remove(int weight)
        {
            if (_limitation.Contains(weight))
                _limitation.Remove(weight);
        }
    }
}