using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace ExoticStudio
{

    [Serializable]

    public class Limitation : ISerializable
    {
        #region data section

        protected ArrayList _selection = new ArrayList();

        private int _firstRace;

        private int _minMatches = 0, _maxMatches = 0;

        bool _needsToBeSaved = false;

        bool _needsToBeCounted = false;

        RaceInput _parent = null;

        // Here we store the matches with the developed system
        // maps: count of matches to total occurences
        Dictionary<int, int> _matchesWithDevelopedSystem = null;

        // If _enabled is set to false then this limitation 
        // is not considered when we count the system
        bool _enabled = true;

        #endregion

        public static bool SerializationObjectExists(SerializationInfo info, string fieldName, System.Type dataType)
        {
            Debug.Assert(null != info);
            Debug.Assert(!string.IsNullOrEmpty(fieldName));



            var e = info.GetEnumerator();
            e.Reset();
            e.MoveNext();
            while (e.MoveNext())
            {
                if (e.Current.ObjectType == dataType && e.Current.Name == fieldName)
                {
                    return true;
                }
            }

            return false;


            try
            {
                return null != info.GetValue(fieldName, dataType);
            }
            catch
            {
                return false;
            }
        }

        public static object GetSerializedObject(SerializationInfo info, string fieldName, System.Type dataType, object defautValue)
        {
            if (SerializationObjectExists(info, fieldName, dataType))
            {
                return info.GetValue(fieldName, dataType);
            }
            else
            {
                return defautValue;
            }
        }
        public Limitation(SerializationInfo info, StreamingContext ctxt)
        {
            _firstRace = (int)info.GetValue("_firstRace", typeof(int));
            _minMatches = (int)info.GetValue("_minMatches", typeof(int));
            _maxMatches = (int)info.GetValue("_maxMatches", typeof(int));
            _selection = (ArrayList)info.GetValue("_selection", typeof(ArrayList));
            _enabled = (bool)GetSerializedObject(info, "_enabled", typeof(bool), true);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_firstRace", _firstRace);
            info.AddValue("_minMatches", _minMatches);
            info.AddValue("_maxMatches", _maxMatches);
            info.AddValue("_selection", _selection);
            info.AddValue("_enabled", _enabled);
        }

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        public int FirstRace
        {
            get
            {
                return _firstRace;
            }
            set
            {
                _firstRace = value;
            }

        }

        public string GetSystemAsString2(int precedingTabs)
        {
            if (this is FullSystem)
            {

                string prefix = Tools.GetTabedPrefix(precedingTabs);
                string strg = GetSystemAsString(precedingTabs);

                strg += Environment.NewLine;
                strg += prefix + "From\t" + _minMatches.ToString() + Environment.NewLine;
                strg += prefix + "To\t" + _maxMatches.ToString() + Environment.NewLine;

                return strg;
            }
            else
            {
                string prefix = Tools.GetTabedPrefix(precedingTabs);
                string strg = GetMarkedSelectionsAsString(precedingTabs);

                strg += Environment.NewLine;
                strg += prefix + "From\t" + _minMatches.ToString() + Environment.NewLine;
                strg += prefix + "To\t" + _maxMatches.ToString() + Environment.NewLine;

                return strg;
            }
        }

        string GetMarkedSelectionsAsString(int precedingTabs)
        {
            string prefix = Tools.GetTabedPrefix(precedingTabs);

            string strg = "";

            strg += prefix + "Race\tSelections" + Environment.NewLine;
            strg += prefix + "----\t----------" + Environment.NewLine;

            for (int i = 0; i < _selection.Count; ++i)
            {
                strg += prefix + (i + FirstRace).ToString() + ".\t";
                strg += ((RaceSelection)_selection[i]).GetMarkedAsString();
                strg += Environment.NewLine;
            }

            return strg;
        }

        public List<int> Selections
        {
            get
            {
                return (from RaceSelection s in _selection
                        select s.Get(0)).ToList();
            }
        }

        public string GetSystemHorizontaly()
        {
            string strg = "";
            for (int i = 0; i < _selection.Count; ++i)
            {
                strg += ((RaceSelection)_selection[i]).GetAsString();
                strg += " ";
            }
            return strg;
        }

        public string GetSystemAsString(int precedingTabs)
        {
            string prefix = Tools.GetTabedPrefix(precedingTabs);

            string strg = "";

            strg += prefix + "Race\tSelections" + Environment.NewLine;
            strg += prefix + "----\t----------" + Environment.NewLine;

            for (int i = 0; i < _selection.Count; ++i)
            {
                int raceNumber = i + FirstRace;

                strg += prefix + (raceNumber).ToString() + ".\t";

                strg += ((RaceSelection)_selection[i]).GetAsString(raceNumber);


                strg += Environment.NewLine;
            }

            return strg;
        }

        public bool LimitationNeedsToBeCounted
        {
            get
            {
                if (_needsToBeCounted)
                {
                    return true;
                }

                for (int i = 0; i < _selection.Count; ++i)
                {
                    RaceSelection rc = (RaceSelection)_selection[i];

                    if (rc.NeedsToBeCounted)
                    {
                        return true;
                    }
                }

                return false;
            }
            set
            {
                _needsToBeCounted = value;


                for (int i = 0; i < _selection.Count; ++i)
                {
                    RaceSelection rc = (RaceSelection)_selection[i];

                    rc.NeedsToBeCounted = value;

                }
            }
        }

        public bool LimitationNeedsToBeSaved
        {
            get
            {
                if (_needsToBeSaved)
                {
                    return true;
                }

                for (int i = 0; i < _selection.Count; ++i)
                {
                    RaceSelection rc = (RaceSelection)_selection[i];

                    if (rc.NeedsToBeSaved)
                    {
                        return true;
                    }
                }

                return false;
            }
            set
            {
                _needsToBeSaved = value;
              

                for (int i = 0; i < _selection.Count; ++i)
                {
                    RaceSelection rc = (RaceSelection)_selection[i];

                    rc.NeedsToBeSaved = value;
               
                }
            }
        }

        public Limitation(int numberOfRaces, int firstRace)
        {
            _firstRace = firstRace;
            SetNumberOfRaces(numberOfRaces);
            
        }

        public void SetNumberOfRaces(int numberOfRaces)
        {
            for (int i = 0; i < numberOfRaces; ++i)
            {
                _selection.Add(new RaceSelection());
            }
        }

        public bool IsMatching(Limitation other)
        {
            if (this.Count() != other.Count())
            {
                return false;
            }


            int count = 0;

            for (int i = 0; i < Count(); ++i)
            {
                if (((RaceSelection)_selection[i]).IsMatching(other.GetRaceSelection(i)))
                {
                    ++count;
                }
            }

            return count >= _minMatches && count <= _maxMatches;
        }

        // Maybe the following two methods can be one 
        public Limitation CreateDeepCopy()
        {
            Limitation newObject = new Limitation(NumberOfRaces, _firstRace);

            newObject.CloneDeeplyValues(this);

            return newObject;
        }

        public Limitation CreateCopy()
        {
            Limitation newObject = new Limitation(NumberOfRaces, _firstRace);

            newObject.CloneValues(this);

            return newObject;
        }

        public int CountMatches(Limitation other)
        {
            if (NumberOfRaces != other.NumberOfRaces)
            {
                return -1;
            }

            int count = 0;

            for (int i = 0; i < NumberOfRaces; ++i)
            {
                if (((RaceSelection)_selection[i]).IsMatching((RaceSelection)other._selection[i]))
                {
                    ++count;
                }
            }

            return count;
        }

        public int CountIdenticalSelections(Limitation other)
        {
            if (NumberOfRaces != other.NumberOfRaces)
            {
                return -1;
            }

            int count = 0;

            for (int i = 0; i < NumberOfRaces; ++i)
            {
                
                if ( ((RaceSelection)_selection[i]).IsIdentical((RaceSelection)other._selection[i]))
                {
                    ++count;
                }
            }

            return count;
        }

        public int GetTotalNumberOfCombinations()
        {
            int count = 1;

            for (int i = 0; i < _selection.Count; ++i)
            {
                count *= ((RaceSelection)_selection[i]).Count;
            }

            return count;
        }

        public void CloneDeeplyValues(Limitation other)
        {
            Debug.Assert(NumberOfRaces == other.NumberOfRaces);


            _firstRace = other._firstRace;

            for (int i = 0; i < NumberOfRaces; ++i)
            {
                RaceSelection ors = other.GetRaceSelection(i);
                _selection[i] = ors.MakeDeepCopy();
            }

            _minMatches = other._minMatches;
            _maxMatches = other._maxMatches;

        }

        public void CloneValues(Limitation other)
        {
            Debug.Assert(NumberOfRaces == other.NumberOfRaces);


            _firstRace = other._firstRace;
            for (int i = 0; i < NumberOfRaces; ++i)
            {
                RaceSelection ors = other.GetRaceSelection(i);

                RaceSelection rs = new RaceSelection();

                for (int j = 0; j < ors.Count; ++j)
                {
                    rs.AddHorse(ors.Get(j));
                }

                _selection[i] = rs;
            }

            _minMatches = 0;
            _maxMatches = NumberOfRaces;

        }

        public int NumberOfRaces
        {
            get
            {
                return _selection.Count;
            }
            
        }

      

        public int MinMatches
        {
            get
            {
                return _minMatches;
            }
            set
            {
                if (value != _minMatches)
                {
                    _needsToBeSaved = true;
                    _needsToBeCounted = true;
                    _minMatches = value;
                }
            }

        }

        public int MaxMatches
        {
            get
            {
                return _maxMatches;
            }
            set
            {
                if (value != _maxMatches)
                {
                    _needsToBeSaved = true;
                    _needsToBeCounted = true;
                    _maxMatches = value;
                }
            }

        }

        // Returns the races that have a valid selection
        // (invalid is the race that have only one selection and this selection is 0
        public int CountSkippingZeros()
        {
            int c = 0;

            for (int i = 0; i < _selection.Count; ++i)
            {

                RaceSelection rc = (RaceSelection) _selection[i];

                Debug.Assert(null != rc);

                if (rc.Count > 1 || rc.Get(0) != 0)
                {
                    ++c;
                }
            }

            return c;
        }

        public int Count()
        {
            return _selection.Count;
        }

        public RaceSelection GetRaceSelection(int index)
        {
            return (RaceSelection)_selection[index];
        }

        public void AddHorse(int race, int horse)
        {
            if (race >= 0 && race < _selection.Count)
            {
                ((RaceSelection)_selection[race]).AddHorse(horse);
            }
        }

        public void RemoveHorse(int race, int horse)
        {
            if (race >= 0 && race < _selection.Count)
            {
                ((RaceSelection)_selection[race]).Remove(horse);
            }
        }

        public Dictionary<int, int> MatchesWithDevelopedSystem
        {
            get
            {
                return _matchesWithDevelopedSystem;
            }
        }
        
        public RaceInput Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public void UpdateMatchesPerRace(List<Limitation> developedSystemCombinations)
        {
            _matchesWithDevelopedSystem = new Dictionary<int, int>();

            // if this limitation is disabled which means it is not 
            // considered in the development of the system so
            // we don't want to calculate matches for it that's
            // why we check for this in the following if

            if (_enabled)
            {
                foreach (Limitation combination in developedSystemCombinations)
                {
                    int matches = this.CountMatches(combination);

                    if (_matchesWithDevelopedSystem.ContainsKey(matches))
                    {
                        ++_matchesWithDevelopedSystem[matches];
                    }
                    else
                    {
                        _matchesWithDevelopedSystem.Add(matches, 1);
                    }
                }
            }

            if (null != _parent)
            {
                _parent.UpdateMatchingListView();
            }
        }



        }
}
