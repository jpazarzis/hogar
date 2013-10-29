using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ExoticStudio
{

    [Serializable]

    public class LimitationGroup : ISerializable
    {
        FullSystem _parent = null;

        ArrayList _limitation = new ArrayList();

        bool _needsToBeSaved = false;

        bool _needsToBeCounted = false;


        public LimitationGroup(FullSystem parent)
        {
            _parent = parent;

        }


        public bool NeedsToBeCounted
        {
            get
            {
                if (_needsToBeCounted == true)
                {
                    return true; 
                }

                for (int i = 0; i < _limitation.Count; ++i)
                {
                    Limitation lim = (Limitation)_limitation[i];

                    if (lim.LimitationNeedsToBeCounted)
                    {
                        return true;
                    }
                }

                return false;

            }
            set
            {
                _needsToBeCounted = value;

                for (int i = 0; i < _limitation.Count; ++i)
                {
                    Limitation lim = (Limitation)_limitation[i];

                    lim.LimitationNeedsToBeCounted = value;
                }


            }
        }



        
        public bool NeedsToBeSaved
        {
            get
            {
                if (_needsToBeSaved == true)
                {
                    return true; 
                }

                for (int i = 0; i < _limitation.Count; ++i)
                {
                    Limitation lim = (Limitation)_limitation[i];

                    if (lim.LimitationNeedsToBeSaved)
                    {
                        return true;
                    }
                }

                return false;

            }
            set
            {
                _needsToBeSaved = value;

                for (int i = 0; i < _limitation.Count; ++i)
                {
                    Limitation lim = (Limitation)_limitation[i];

                    lim.LimitationNeedsToBeSaved = value;
                }


            }
        }

        public void SetFirstRace(int firstRace)
        {
            _needsToBeSaved = true;
            _needsToBeCounted = true;

            for (int i = 0; i < _limitation.Count; ++i)
            {
                Limitation lim = (Limitation)_limitation[i];

                lim.FirstRace = firstRace;
            }
        }

        public void RemoveHorse(int raceNumber, int horse)
        {
            for (int i = 0; i < _limitation.Count; ++i)
            {
                ((Limitation)_limitation[i]).RemoveHorse(raceNumber, horse);

            }
        }

        public void AddHorse(int raceNumber, int horse)
        {
            for (int i = 0; i < _limitation.Count; ++i)
            {
                ((Limitation)_limitation[i]).AddHorse(raceNumber, horse);

            }
        }

        public void SetParent(FullSystem parent)
        {
            _parent = parent;
        }

        public LimitationGroup(SerializationInfo info, StreamingContext ctxt)
        {
            _parent = null;
            _limitation = (ArrayList)info.GetValue("_limitationGroup", typeof(ArrayList));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_parent", null);
            info.AddValue("_limitationGroup", _limitation);
        }

        public bool IsMatchingAllTheLimitations(Limitation limitation)
        {
            
            for (int i = 0; i < _limitation.Count; ++i)
            {
                if (((Limitation)_limitation[i]).Enabled)
                {

                    if (((Limitation)_limitation[i]).IsMatching(limitation) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int AddLimitation()
        {
            Limitation limitation = new Limitation(_parent.NumberOfRaces,_parent.FirstRace);

            limitation.CloneValues(_parent);
            return _limitation.Add(limitation);

            
        }


        public void SetLimitation(int limitationIndex, Limitation limitation)
        {
            _limitation[limitationIndex] = limitation;
        }

        public void RemoveLimitation(int limitationIndex)
        {
            _limitation.RemoveAt(limitationIndex);

        }

        public int Count
        {
            get
            {
                return _limitation.Count;
            }
        }

        public Limitation Get(int index)
        {
            return (Limitation)_limitation[index];
        }

        
        
        // Here we initialize the matching counts for all the limitations
        // in the group.  Called after we develop the system
        public void UpdateMatchesPerRace(List<Limitation> developedSystemCombinations)
        {
            for (int i = 0; i < _limitation.Count; ++i)
            {
                Limitation lim = (Limitation)_limitation[i];

                lim.UpdateMatchesPerRace(developedSystemCombinations);
            }
        }
    }
}
