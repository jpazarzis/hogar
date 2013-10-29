using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Betting
{
    public class TrifectaFullSystem : TrifectaSubsystem
    {
        static double BASIC_BET = 2.0;
        Dictionary<int, Odds> _odds = new Dictionary<int, Odds>();
        
        double _amountToWin = 1000;
        readonly List<TrifectaSubsystem> _condensedSubsystems = new List<TrifectaSubsystem>();
        readonly List<TrifectaSubsystem> _rawSubsystems = new List<TrifectaSubsystem>();
        readonly List<TrifectaSubsystem> _invalidsubsystems = new List<TrifectaSubsystem>();

        static double Format(double v)
        {
            string s = v.ToString("#0.00");
            return Convert.ToDouble(s);
        }


        public TrifectaFullSystem()
        {
           
        }

        public TrifectaFullSystem(List<TrifectaSubsystem> selectedCombos)
        {
            _rawSubsystems.Clear();
            _condensedSubsystems.Clear();

            foreach (TrifectaSubsystem s in selectedCombos)
            {
                _rawSubsystems.Add(new TrifectaSubsystem(s));
                _condensedSubsystems.Add(new TrifectaSubsystem(s));
            }

            LoadInvalidFromRawSubsystems();

            Compress();

        }

        private void LoadInvalidFromRawSubsystems()
        {
            TrifectaFullSystem t = new TrifectaFullSystem();

            foreach (TrifectaSubsystem sub in _rawSubsystems)
            {
                for(Position position = Position.First; position <= Position.Third; ++position)
                {
                    foreach (int i in sub.GetPositionAsList(position))
                    {
                        t.AddHorseToSpecificPosition(position, i);
                    }
                }
            }

            t.LoadInvalidSubsystemsOnly();

            _invalidsubsystems.Clear();

            foreach (TrifectaSubsystem s in t._invalidsubsystems)
            {
                _invalidsubsystems.Add(new TrifectaSubsystem(s));
                _rawSubsystems.Add(new TrifectaSubsystem(s));
                _condensedSubsystems.Add(new TrifectaSubsystem(s));

            }

            
        }

        
        public void LoadInvalidSubsystemsOnly()
        {
            _invalidsubsystems.Clear();

            foreach (int first in _selection[Position.First])
            {
                foreach (int second in _selection[Position.Second])
                {
                    foreach (int third in _selection[Position.Third])
                    {
                        

                        if (first == second || first == third || second == third)
                        {
                           
                            _invalidsubsystems.Add(new TrifectaSubsystem(first, second, third, 0, 0));
                        }
                    }
                }
            }
        }
        
        

        public double AmountToWin
        {
            get
            {
                return TrifectaFullSystem.Format(_amountToWin);
            }
            set
            {
                _amountToWin = value;
            }
        }

        private void SetOddsForAllHorsesInTheRace(Dictionary<int, Odds> odds)
        {
            _odds.Clear();

            foreach (KeyValuePair<int, Odds> kvp in odds)
            {
                int number = kvp.Key;
                Odds horseodds = kvp.Value;

                _odds.Add(number, horseodds);
            } 
        }

        public void SpecifySelectionsForTrifectasPosition(Position pos, List<int> other)
        {
            List<int> list = _selection[pos];

            list.Clear();

            foreach (int i in other)
            {
                list.Add(i);
            }
        }


        private double FindPayout(int h1, int h2, int h3)
        {
            try
            {
                double p1 = 1 / (_odds[h1].GetOddsToOne() + 1.0);
                double p2 = 1 / (_odds[h2].GetOddsToOne() + 1.0);
                double p3 = 1 / (_odds[h3].GetOddsToOne() + 1.0);
                double p22 = p2 / (1 - p1);
                double p33 = p3 / (1 - p1 - p2);
                double p = p1 * p22 * p33;
                return Math.Floor(BASIC_BET / p);
            }
            catch
            {
                return 0.0;
            }
        }

        
        
        

        public double DutchingRate
        {
            get
            {
                return 0;
            }
        }

        public double ROI
        {
            get
            {
                double t = TotalBet;

                return t > 0 ? Format(_amountToWin) / t : 0;
            }
        }

        public double TotalBet
        {
            get
            {
                double bet = 0;
                foreach (TrifectaSubsystem s in _rawSubsystems)
                {
                    if (s.IsValid)
                    {
                        bet += s.AmountToDutch;
                    }
                }

                return TrifectaFullSystem.Format(bet);
            }
        }

        private void RemoveContainedSubsystems(int index)
        {
            TrifectaSubsystem s1 = _condensedSubsystems[index];

            for (int i = 0; i < _condensedSubsystems.Count; ++i)
            {
                if (i != index)
                {
                    if (s1.IsASuperset(_condensedSubsystems[i]))
                    {
                        _condensedSubsystems.RemoveAt(i);
                        --i;
                    }
                }
            }
        }

        private void Compress(int index)
        {
            TrifectaSubsystem s1 = _condensedSubsystems[index];
            for (int i = 0; i < _condensedSubsystems.Count; ++i)
            {
                if (i != index)
                {
                    if (s1.CountUnmatchedRaces(_condensedSubsystems[i]) == 1)
                    
                    {
                        s1.Merge(_condensedSubsystems[i]);
                    }
                }
            }
        }

        private void RemoveSingleSelectionsFromOtherPositions()
        {
            foreach (TrifectaSubsystem s in _condensedSubsystems)
            {
                s.RemoveSingles();
            }
        }

        public void Compress()
        {
            for (; ; )
            {
                int countBefore = _condensedSubsystems.Count;

                for (int i = 0; i < _condensedSubsystems.Count; ++i)
                {
                    Compress(i);
                    RemoveContainedSubsystems(i);
                }

                if (countBefore == _condensedSubsystems.Count)
                {
                    RemoveSingleSelectionsFromOtherPositions();

                    return;
                }
            }   
        }
        
        public List<TrifectaSubsystem> RawSubsystems
        {
            get
            {
                return _rawSubsystems;
            }
        }

        public List<TrifectaSubsystem> CondensedSubsystems
        {
            get
            {
                return _condensedSubsystems;
            }
        }

        private void AddCombination(int first, int second, int third)
        {
            string key = first.ToString() + " " + second.ToString() + " " + third.ToString();
            double payout = FindPayout(first, second, third);
            double betNeeded = (_amountToWin * BASIC_BET) / payout;
            _condensedSubsystems.Add(new TrifectaSubsystem(first, second, third, payout,betNeeded));
            _rawSubsystems.Add(new TrifectaSubsystem(first, second, third, payout, betNeeded));
        }

        private void Initialize(Dictionary<int, Odds> odds)
        {
            SetOddsForAllHorsesInTheRace(odds);
           
            _condensedSubsystems.Clear();
            _rawSubsystems.Clear();
           
        }

        public int CountAndDevelop(Dictionary<int, Odds> odds)
        {
            
            int c = 0;

            Initialize(odds);
            _invalidsubsystems.Clear();

            foreach (int first in _selection[Position.First])
            {
                foreach (int second in _selection[Position.Second])
                {
                    foreach (int third in _selection[Position.Third])
                    {
                        if (first == second || first == third || second == third)
                        {
                            _invalidsubsystems.Add(new TrifectaSubsystem(first, second, third,0,0));
                        }
                        else
                        {
                            ++c;                            
                        }
                        AddCombination(first, second, third);
                    }
                }
            }

            Compress();

            return c;
        }

    }
}
