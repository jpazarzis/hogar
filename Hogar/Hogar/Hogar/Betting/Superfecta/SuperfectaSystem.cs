using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Hogar.Betting.Superfecta
{
    public class SuperfectaSystem
    {
        readonly RaceSelections[] _raceSelections = new RaceSelections[4];

         List<SuperfectaSystem> _combinations = new List<SuperfectaSystem>();


        readonly List<ISuperfectaLimitation> _limitations = new List<ISuperfectaLimitation>();


        enum Status
        {
            Normal,
            ToBeDeleted
        }

        Status _status = Status.Normal;

        public SuperfectaSystem()
        {
            for (int i = 0; i < _raceSelections.Length; ++i)
            {
                _raceSelections[i] = new RaceSelections();
            }
            ClearLimitations();
        }

        public SuperfectaSystem(int horseNum1, int horseNum2, int horseNum3, int horseNum4): 
            this()
        {
            this[0].Add(horseNum1);
            this[1].Add(horseNum2);
            this[2].Add(horseNum3);
            this[3].Add(horseNum4);
        }

        public RaceSelections GetRaceSelections(int i)
        {
            return _raceSelections[i];
        }

        private void ClearLimitations()
        {
            _limitations.Clear();
            _limitations.Add(new ValidCombinationLimitation());
        }

        public bool ContainsLimitation(ISuperfectaLimitation limitation)
        {
            foreach (ISuperfectaLimitation l in _limitations)
            {
                if (l.Equals(limitation))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddLimitation(ISuperfectaLimitation limitation)
        {
            RemoveLimitation(limitation);
            _limitations.Add(limitation);
        }

        public bool IsHorseSelected(int position, int horseNumber)
        {
            return _raceSelections[position].Contains(horseNumber);
        }

        public void AddHorse(int position, int horseNumber)
        {
            _raceSelections[position].Add(horseNumber);
        }

        public void RemoveHorse(int position, int horseNumber)
        {
            _raceSelections[position].Remove(horseNumber);
        }

        public void ToggleHorse(int position, int horseNumber)
        {
            if(IsHorseSelected(position,horseNumber))
            {
                RemoveHorse(position,horseNumber);
            }
            else
            {
                AddHorse(position,horseNumber);
            }
        }

        public void RemoveLimitation(ISuperfectaLimitation limitation)
        {
            List<ISuperfectaLimitation> toDelete = new List<ISuperfectaLimitation>();
            foreach (ISuperfectaLimitation l in _limitations)
            {
                if (l.Equals(limitation))
                {
                    toDelete.Add(l);
                }
            }
            foreach (ISuperfectaLimitation l in toDelete)
            {
                _limitations.Remove(l);
            }
        }


        private SuperfectaSystem MakeACopy()
        {
            SuperfectaSystem temp = new SuperfectaSystem();
            for (int i = 0; i < _raceSelections.Length; ++i)
            {
                for (int j = 0; j < _raceSelections[i].Count; ++j)
                {
                    temp._raceSelections[i].Add(_raceSelections[i][j]);
                }
            }
            return temp;
        }

        public RaceSelections this[int i]
        {
            get
            {
                return _raceSelections[i];
            }
        }

        private bool IsValidCombination(int i0, int i1, int i2, int i3)
        {
            foreach (ISuperfectaLimitation limitation in _limitations)
            {
                if (false == limitation.IsValid(i0,i1,i2,i3))
                {
                    return false;
                }
            }

            return true;
        }

        public List<SuperfectaSystem> DevelopSubSystems()
        {
            _combinations.Clear();

            foreach (int i0 in _raceSelections[0])
            {
                foreach (int i1 in _raceSelections[1])
                {
                    foreach (int i2 in _raceSelections[2])
                    {
                        foreach (int i3 in _raceSelections[3])
                        {
                            if (IsValidCombination(i0, i1, i2, i3))
                            {
                                _combinations.Add(new SuperfectaSystem(i0, i1, i2, i3));
                            }
                        }
                    }
                }
            }


               
            
            
            int countBefore = 0;
            for (; ; )
            {
                CompressBy2();   
                int countAfter = _combinations.Count;
                if (countBefore == countAfter)
                {
                    break;
                }
                countBefore = countAfter;
            }
            
            
            return _combinations;    
        }


        public override string ToString()
        {
            return string.Format(" [{0}] [{1}] [{2}] [{3}] ", _raceSelections[0], _raceSelections[1], _raceSelections[2], _raceSelections[3]);
        }

        
        static private SuperfectaSystem Merge(SuperfectaSystem s1, SuperfectaSystem s2)
        {
            SuperfectaSystem s = s1.MakeACopy();
            for (int i = 0; i < 4; ++i)
            {
                s._raceSelections[i].Merge(s2._raceSelections[i]);
            }

            return s;
        }


        private int CountIdenticalSelections(SuperfectaSystem other)
        {
            int count = 0;

            for (int i = 0; i < 4; ++i)
            {
                if (this[i].Equals(other[i]))
                {
                    ++count;
                }
            }

            return count;
        }


        private void CompressBy2(int startFrom, int matchesCount)
        {
            if (_combinations[startFrom]._status != Status.Normal)
            {
                return;
            }

            for (int i = 0; i < _combinations.Count; ++i)
            {
                if (_combinations[i]._status != Status.Normal || i == startFrom)
                {
                    continue;
                }
                SuperfectaSystem s0 = _combinations[startFrom];
                SuperfectaSystem s1 = _combinations[i];

                if (s0.CountIdenticalSelections(s1) != matchesCount)
                {
                    continue;
                }

                SuperfectaSystem temp = SuperfectaSystem.Merge(s0, s1);
                if (temp.FullSystemCount == s0.FullSystemCount + s1.FullSystemCount)
                {
                    _combinations[startFrom] = temp;
                    _combinations[i]._status = Status.ToBeDeleted;
                }
            }
        }


        private void CompressBy2()
        {
            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy2(i,3);
            }

            RemoveUnusedCombinations();

            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy2(i, 2);
            }

            RemoveUnusedCombinations();
            
            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy2(i, 1);
            }

            RemoveUnusedCombinations();

            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy2(i, 0);
            }

            RemoveUnusedCombinations();

            CompressBy3();

            RemoveUnusedCombinations();

            CompressBy4();

            RemoveUnusedCombinations();
        }

        private void RemoveUnusedCombinations()
        {
            int pos = 0;

            while (pos < _combinations.Count)
            {
                if (_combinations[pos]._status == Status.ToBeDeleted)
                {
                    _combinations.RemoveAt(pos);
                }
                ++pos;
            }
        }

        private void CompressBy3(int startFrom)
        {
            if (_combinations[startFrom]._status != Status.Normal)
            {
                return;
            }

            for (int i = 0; i < _combinations.Count; ++i)
            {
                if (_combinations[i]._status != Status.Normal || i == startFrom)
                {
                    continue;
                }
                SuperfectaSystem s0 = _combinations[startFrom];
                SuperfectaSystem s1 = _combinations[i];

                for (int j = 0; j < _combinations.Count; ++j)
                {
                    if (_combinations[j]._status != Status.Normal || j == startFrom || j ==i)
                    {
                        continue;
                    }

                    SuperfectaSystem s2 = _combinations[j];
                    SuperfectaSystem temp0 = SuperfectaSystem.Merge(s0, s1);
                    SuperfectaSystem temp = SuperfectaSystem.Merge(temp0, s2);
                    
                    if (temp.FullSystemCount == s0.FullSystemCount + s1.FullSystemCount + s2.FullSystemCount)
                    {
                        _combinations[startFrom] = temp;
                        _combinations[i]._status = Status.ToBeDeleted;
                        _combinations[j]._status = Status.ToBeDeleted;
                        break;
                    }
                }
            }
        }


        private void CompressBy3()
        {
            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy3(i);
            }

            RemoveUnusedCombinations();
        }

        private void CompressBy4(int startFrom)
        {
            if (_combinations[startFrom]._status != Status.Normal)
            {
                return;
            }

            for (int i = 0; i < _combinations.Count; ++i)
            {
                if (_combinations[i]._status != Status.Normal || i == startFrom)
                {
                    continue;
                }
                SuperfectaSystem s0 = _combinations[startFrom];
                SuperfectaSystem s1 = _combinations[i];

                for (int j = 0; j < _combinations.Count; ++j)
                {
                    if (_combinations[j]._status != Status.Normal || j == startFrom || j == i)
                    {
                        continue;
                    }

                    SuperfectaSystem s2 = _combinations[j];

                    for (int k = 0; k < _combinations.Count; ++k)
                    {
                        if (_combinations[k]._status != Status.Normal || k == startFrom || k == i || k ==j)
                        {
                            continue;
                        }

                        SuperfectaSystem s3 = _combinations[k];

                        SuperfectaSystem temp0 = SuperfectaSystem.Merge(s0, s1);
                        SuperfectaSystem temp1 = SuperfectaSystem.Merge(temp0, s2);
                        SuperfectaSystem temp = SuperfectaSystem.Merge(temp1, s3);

                        if (temp.FullSystemCount == s0.FullSystemCount + s1.FullSystemCount + s2.FullSystemCount + s3.FullSystemCount)
                        {
                            _combinations[startFrom] = temp;
                            _combinations[i]._status = Status.ToBeDeleted;
                            _combinations[j]._status = Status.ToBeDeleted;
                            _combinations[k]._status = Status.ToBeDeleted;
                            break;
                        }
                    }
                }
            }
        }


        private void CompressBy4()
        {
            for (int i = 0; i < _combinations.Count; ++i)
            {
                CompressBy4(i);
            }

            RemoveUnusedCombinations();
        }

        public int FullSystemCount
        {
            get
            {
                int count = 0;
                var limitation = new ValidCombinationLimitation();
                foreach (int i0 in _raceSelections[0])
                {
                    foreach (int i1 in _raceSelections[1])
                    {
                        foreach (int i2 in _raceSelections[2])
                        {
                            foreach (int i3 in _raceSelections[3])
                            {
                                if (limitation.IsValid(i0, i1, i2, i3))
                                {
                                    ++count;
                                }
                            }
                        }
                    }
                }
                return count;
            }
        }

        public int CombinationsCount
        {
            get
            {
                int count = 0;
                foreach(int i0 in _raceSelections[0])
                {
                    foreach (int i1 in _raceSelections[1])
                    {
                        foreach (int i2 in _raceSelections[2])
                        {
                            foreach (int i3 in _raceSelections[3])
                            {
                                if (IsValidCombination(i0, i1, i2, i3))
                                {
                                    ++count;
                                }
                            }
                        }
                    }
                }
                return count;
            }
        }
    }
}
