using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Hogar.Betting
{
    public class TrifectaSubsystem
    {
        public enum Position
        {
            First, Second, Third
        }

        protected readonly Dictionary<Position, List<int>> _selection = new Dictionary<Position, List<int>>();
        
        readonly double _payoff;
        readonly double _amountToDutch;

        public TrifectaSubsystem()
        {
            _selection.Add(Position.First, new List<int>());
            _selection.Add(Position.Second, new List<int>());
            _selection.Add(Position.Third, new List<int>());
        }

        public TrifectaSubsystem(TrifectaSubsystem other)  : this()
        {
            this._payoff = other._payoff;
            this._amountToDutch = other._amountToDutch;
            foreach(KeyValuePair<Position, List<int>> pair in other._selection)
            {
                Position otherPosition = pair.Key;
                List<int> otherList = pair.Value;
                List<int> thisList = _selection[otherPosition];
                thisList.Clear();
                foreach (int i in otherList)
                {
                    thisList.Add(i);
                }
            }
        }
        

        public TrifectaSubsystem(int h1, int h2, int h3, double payoff, double amountToDutch)
            : this()
        {
            AddHorseToSpecificPosition(Position.First, h1);
            AddHorseToSpecificPosition(Position.Second, h2);
            AddHorseToSpecificPosition(Position.Third, h3);
            _payoff = payoff;
            _amountToDutch = amountToDutch; 
        }

        public bool IsValid
        {
            get
            {
                foreach (int first in _selection[Position.First])
                {
                    foreach (int second in _selection[Position.Second])
                    {
                        foreach (int third in _selection[Position.Third])
                        {
                            if (!(first == second || first == third || second == third))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        public double Payoff
        {
            get
            {
                return _payoff;
            }
        }

        public double AmountToDutch
        {
            get
            {
                return _amountToDutch;
            }
        }

        public void RemoveSingles()
        {
            for (Position p = Position.First; p <= Position.Third; ++p)
            {
                RemoveSingles(p);
            }
        }

        private void RemoveSingles(Position pos)
        {
            List<int> list = GetPositionAsList(pos);

            if (list.Count == 1)
            {
                int n = list[0];

                for (Position p = Position.First; p <= Position.Third; ++p)
                {
                    if (p != pos)
                    {
                        List<int> list2 = GetPositionAsList(p);
                        if (list2.Contains(n))
                        {
                            list2.Remove(n);
                        }
                    }
                }
            }
        }

        public List<int> GetPositionAsList(Position pos)
        {
            return _selection[pos];
        }

        public string GetPositionAsString(Position pos)
        {
            List<int> list = _selection[pos];

            string s = "";

            foreach (int i in list)
            {
                s += i.ToString() + " ";
            }

            return s.Trim();
        }

        public override string ToString()
        {
            return GetPositionAsString(Position.First) + " - " + GetPositionAsString(Position.Second) + " - " + GetPositionAsString(Position.Third);
        }

        public void AddHorseToSpecificPosition(Position pos, int i)
        {
            List<int> list = _selection[pos];

            if (!list.Contains(i))
            {
                list.Add(i);
            }
        }

        public void Merge(TrifectaSubsystem other)
        {
            for (Position p = Position.First; p <= Position.Third; ++p)
            {
                foreach (int n in other._selection[p])
                {
                    AddHorseToSpecificPosition(p, n);
                }
            }
        }
        
        private bool IsPositionContained(Position pos, TrifectaSubsystem other)
        {
            List<int> thisList = _selection[pos];
            List<int> otherList = other._selection[pos];

            foreach (int i in otherList)
            {
                if (false == thisList.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsASuperset(TrifectaSubsystem other)
        {
            for (Position p = Position.First; p <= Position.Third; ++p)
            {
                if (!IsPositionContained(p, other))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ArePositionsIdentical(Position pos, TrifectaSubsystem other)
        {

            List<int> list1 = this._selection[pos];
            List<int> list2 = other._selection[pos];

            if (list1.Count != list2.Count)
            {
                return false;
            }

            foreach (int i in list1)
            {
                if (false == list2.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }
       
        public int CountUnmatchedRaces(TrifectaSubsystem other)
        {
            int countDescrepancies = 0;

            for (Position p = Position.First; p <= Position.Third; ++p )
            {
                if (!ArePositionsIdentical(p, other))
                {
                    ++countDescrepancies;
                }   
            }
            return countDescrepancies;
        }
         
        public int Count()
        {
            int c = 0;

            foreach (int first in _selection[Position.First])
            {
                foreach (int second in _selection[Position.Second])
                {
                    foreach (int third in _selection[Position.Third])
                    {
                        if (!(first == second || first == third || second == third))
                        {
                            ++c;
                        }
                    }
                }
            }

            return c;
        }
    }
}