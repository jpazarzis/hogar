using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Betting.Superfecta
{
    public class RaceSelections : IEnumerable<int> , IEnumerator<int>
    {
        readonly List<int> _selections = new List<int>();

        int _currentPosition = -1;

        public RaceSelections()
        {
        }

        public int Count
        {
            get
            {
                return _selections.Count;
            }
        }

        public int this[int index]
        {
            get
            {
                return _selections[index];
            }
        }

        public bool Contains(int i)
        {
            return _selections.Contains(i);
        }


        public void Add(int horseNumber)
        {
            if (false == _selections.Contains(horseNumber))
            {
                _selections.Add(horseNumber);
                _selections.Sort();
            }
        }

        public void Remove(int horseNumber)
        {
            if (_selections.Contains(horseNumber))
            {
                _selections.Remove(horseNumber);
                _selections.Sort();
            }
        }

        public static RaceSelections operator -(RaceSelections lhp, RaceSelections rhp)
        {
            RaceSelections temp = new RaceSelections(), s1 = lhp, s2 = rhp;


            foreach (int i in s2._selections)
            {
                if (!s1.Contains(i))
                {
                    temp.Add(i);
                }
            }

            return temp;
        }

        public bool IsASupersetOf(RaceSelections other)
        {
            foreach (int i in other._selections)
            {
                if (false == this.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

        public void Merge(RaceSelections other)
        {
            foreach (int i in other._selections)
            {
                Add(i);
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is RaceSelections)
            {
                RaceSelections other = obj as RaceSelections;

                if (other == this)
                {
                    return true;
                }

                if (_selections.Count != other._selections.Count)
                {
                    return false;
                }

                foreach (int i in _selections)
                {
                    if (!other.Contains(i))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in _selections)
            {
                if (sb.ToString().Length > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(string.Format("{0}", i));
            }
            return sb.ToString();
        }

        

        public IEnumerator<int> GetEnumerator()
        {
            Reset();
            return this;
        }

        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            Reset();
            return this;
        }

        public int Current
        {
            get
            {
                return _selections[_currentPosition];
            }
        }
        
        public void Dispose()
        {
            
        }
        
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return _selections[_currentPosition];
            }
        }

        public bool MoveNext()
        {
            if (_currentPosition < _selections.Count)
            {
                ++_currentPosition;
            }

            return _currentPosition < _selections.Count;
            
        }

        public void Reset()
        {
            _currentPosition = -1;
        }

        
    }
}
