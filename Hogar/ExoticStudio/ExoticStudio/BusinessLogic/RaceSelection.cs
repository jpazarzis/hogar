using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ExoticStudio
{
    [Serializable]

    // This class holds the selected horses for a race
    // Is used both for full system and individual limitations
    // Note that if this class represents a limitation as opposed to a 
    // full system, we keep the selected horses for the limitation
    // in the _markedHorses array


    public class RaceSelection : ISerializable
    {
        private ArrayList _selection = new ArrayList();
       
        private ArrayList _markedHorses = new ArrayList();

        // horse number to its frequency in the final system
        // will be used only from FullSystem.  This property is
        // a good insetive for the creation of a derived class
        // that will be used only be full system... 
        // I leave this for later
        private Dictionary<int, int> _frequency = new Dictionary<int, int>();

        private bool _needsToBeSaved = false;

        private bool _needsToBeCounted = false;

        public RaceSelection()
        {
        }

        public bool ContainsMarkedHorses
        {
            get
            {
                return _markedHorses.Count > 0;
            }
        }

        public RaceSelection MakeDeepCopy()
        {
            RaceSelection rc = new RaceSelection();

            for (int i = 0; i < _selection.Count; ++i)
            {
                rc._selection.Add(_selection[i]);
            }

            for (int i = 0; i < _markedHorses.Count; ++i)
            {
                rc._markedHorses.Add(_markedHorses[i]);
            }

            return rc;

        }

        public void ClearFrequencies()
        {
            _frequency.Clear();
        }

        public void IncreaseFrequency(int horseNumber)
        {
            if (true == ContainsHorse(horseNumber))
            {
                if (_frequency.ContainsKey(horseNumber) == false)
                {
                    _frequency.Add(horseNumber, 0);
                }

                ++_frequency[horseNumber];    
            }            
        }

        public int GetFrequency(int horseNumber)
        {
            return (_frequency.ContainsKey(horseNumber) == false) ? 0 : _frequency[horseNumber];
        }

        public string GetMarkedAsString()
        {
            string strg = "";
            for (int i = 0; i < _markedHorses.Count; ++i)
            {
                strg += ((int)_markedHorses[i]).ToString() + " ";
            }
            return strg;
        }

        public string GetAsString()
        {
            string strg = "";
            for (int i = 0; i < _selection.Count; ++i)
            {
                strg += ((int)_selection[i]).ToString() + " ";
            }
            return strg;
        }

        public string GetAsString(int racenumber)
        {
            string strg = "";
            for (int i = 0; i < _selection.Count; ++i)
            {
                int horseNumber = (int)_selection[i];
                strg += horseNumber.ToString() + " ";
            }
            return strg;
        }

        public bool IsIdentical(RaceSelection other)
        {
            _selection.Sort();
            other._selection.Sort();

            if (_selection.Count != other._selection.Count)
            {
                return false;
            }

            for (int i = 0; i < _selection.Count; ++i)
            {
                if ((int)_selection[i] != (int)other._selection[i])
                {
                    return false;
                }
            }

            return true;
        }

        public RaceSelection(SerializationInfo info, StreamingContext ctxt)
        {
            _selection = (ArrayList)info.GetValue("_race_selection", typeof(ArrayList));
            _markedHorses = (ArrayList)info.GetValue("_markHorse", typeof(ArrayList));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_race_selection", _selection);
            info.AddValue("_markHorse", _markedHorses);
        }

        public bool NeedsToBeCounted
        {
            get
            {
                return _needsToBeCounted;
            }
            set
            {
                _needsToBeCounted = value;
            }
        }

        public bool NeedsToBeSaved
        {
            get
            {
                return _needsToBeSaved;
            }
            set
            {
                _needsToBeSaved = value;
            }
        }

        public void Remove(int horseNumber)
        {
            if (_selection.Contains(horseNumber) == true)
            {
                _needsToBeSaved = true;
                _needsToBeCounted = true;

                _selection.Remove(horseNumber);
                _markedHorses.Remove(horseNumber);
            }
        }

        public void AddHorse(int horseNumber)
        {
            if (_selection.Contains(horseNumber) == false)
            {
                _needsToBeSaved = true;
                _needsToBeCounted = true;
                _selection.Add(horseNumber);
                _selection.Sort();
            }
        }

        public void Merge(RaceSelection other)
        {
            for (int i = 0; i < other.Count; ++i)
            {
                AddHorse(other.Get(i));
            }
        }

        public bool IsMatching(RaceSelection other)
        {
            for (int i = 0; i < other._selection.Count; ++i)
            {
                int horse = (int) other._selection[i];

                if (_markedHorses.Contains(horse))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHorseMarked(int horse)
        {
            return _markedHorses.Contains(horse);
        }

        public void ToggleSelectionForHorse(int horse)
        {
            _needsToBeSaved = true;
            _needsToBeCounted = true;

            if (_markedHorses.Contains(horse))
            {
                _markedHorses.Remove(horse);
            }
            else
            {
                _markedHorses.Add(horse);
            }
        }

        public int Get(int index)
        {
            return (int)_selection[index];
        }

        public int Count
        {
            get
            {
                return _selection.Count;
            }
        }

        public bool ContainsHorse(int horseNumber)
        {
            return _selection.Contains(horseNumber);
        }
    }
}
