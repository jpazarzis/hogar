using System;
using System.Collections.Generic;
using System.IO;

namespace Hogar.Algorithms.ANN
{
    public class PatternCollection
    {
        readonly List<Pattern> _patterns = new List<Pattern>();

        static Random _randomizer = new Random();

        public List<Pattern> GetRandomSubset(double percentage)
        {
            return GetRandomSubset(percentage * _patterns.Count);
        }

        public List<Pattern> GetRandomSubset(int count)
        {
            List<Pattern> subset = null;

            if (count > 0 && count < _patterns.Count)
            {
                subset = new List<Pattern>();
                _patterns.ForEach(p=>p.RandomlySelected=false);
                while (subset.Count < count)
                {
                    int randomIndex = _randomizer.Next(0, _patterns.Count);
                    var pattern = _patterns[randomIndex];
                    if (!pattern.RandomlySelected)
                    {
                        subset.Add(pattern);
                        pattern.RandomlySelected = true;
                    }
                }    
            }

            return subset;
        }

        public void LoadFromFile(string filename, int minNumberOfRacesToConsider)
        {
            _patterns.Clear();

            using (var sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Pattern hp = Pattern.Make(line, minNumberOfRacesToConsider);

                    if (null != hp)
                    {
                        _patterns.Add(hp);
                    }
                }
            }
        }

        public IEnumerable<Pattern> Patterns
        {
            get 
            {
                return _patterns;
            }
        }
    }
}