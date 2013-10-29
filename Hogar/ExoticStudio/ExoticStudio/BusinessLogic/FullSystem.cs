using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace ExoticStudio
{
    [Serializable]
    // The GOD class of this program.  Holds all the information
        // about a system, nows how to save - load, count and compress 
    public class FullSystem : Limitation, ISerializable
    {
        private int _unitBet = 0;

        private string _raceTrack;

        private DateTime _date;

        private List<LimitationGroup> _group = new List<LimitationGroup>();

        private int _minNumberOfMatchingGroups = 0;

        private int _maxNumberOfMatchingGroups = 0;

        
        private double _averageNumberOfHorsesPerRace = 0;

        private bool _needsToBeSaved = false;

        private bool _needsToBeCounted = false;

        // Here we store the combinations that pass all 
        // the limitation when we count the system
        private List<Limitation> _developedSystem = new List<Limitation>();

        private List<Limitation> _metablito = new List<Limitation>();


        
        WeightStatistics _weightStatisticsForTheFullSystem = new WeightStatistics();
        WeightStatistics _weightStatisticsForTheDevelopedSystem = new WeightStatistics();

        private readonly WeightLimitation _valueWeightLimitationForTheFullSystem = new WeightLimitation();
        private readonly WeightLimitation _weightWeightLimitationForTheFullSystem = new WeightLimitation();





        private string _filename = "";



        private int _developedCount = 0;
        private int _metablitoCount = 0;


        public WeightLimitation ValueWeightLimitationForTheFullSystem
        {
            get { return _valueWeightLimitationForTheFullSystem; }
        }

        public WeightLimitation WeightWeightLimitationForTheFullSystem
        {
            get { return _weightWeightLimitationForTheFullSystem; }
        }
        
        public double AverageNumberOfHorsesPerRace
        {
            get { return _averageNumberOfHorsesPerRace; }
        }


        // Implemented in the Hogar assembly and holds the odds for the
        // track - date if the corresponding odds file exist in the 
        // odds directory
        
        public WeightStatistics WeightStatisticsForTheFullSystem
        {
            get
            {
                return _weightStatisticsForTheFullSystem;
            }
        }

        public WeightStatistics WeightStatisticsForTheDevelopedSystem
        {
            get
            {
                return _weightStatisticsForTheDevelopedSystem;
            }
        }

        public static FullSystem Make(int numOfRaces, string track, DateTime date, int firstRace, int unitBet, double averageNumberOfHorsesPerRace)
        {
            return new FullSystem(numOfRaces, track, date, firstRace, unitBet,averageNumberOfHorsesPerRace);
        }

        public static FullSystem Make(string filename)
        {
            Stream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            var bformatter = new BinaryFormatter();
            var fs = (FullSystem) bformatter.Deserialize(stream);
            stream.Close();
            fs.Filename = filename;
            return fs;
        }

        public string Filename { get { return _filename; } private set { _filename = value.Trim(); } }

        public FullSystem(SerializationInfo info, StreamingContext ctxt) :
            base(info, ctxt)
        {
            _unitBet = (int) info.GetValue("_unitBet", typeof (int));
            _minNumberOfMatchingGroups = (int) info.GetValue("_minNumberOfMatchingGroups", typeof (int));
            _maxNumberOfMatchingGroups = (int) info.GetValue("_maxNumberOfMatchingGroups", typeof (int));
            _raceTrack = (String) info.GetValue("_raceTrack", typeof (string));
            _date = (DateTime)info.GetValue("_date", typeof(DateTime));
            
            int groupCount = (int) info.GetValue("_group_count", typeof (int));
            _group.Clear();

            for (int i = 0; i < groupCount; ++i)
            {
                var lg = (LimitationGroup) info.GetValue("_group" + i.ToString(), typeof (LimitationGroup));
                lg.SetParent(this);
                _group.Add(lg);
            }

            NeedsToBeSaved = false;
        }

        public new void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            base.GetObjectData(info, ctxt);

            info.AddValue("_unitBet", _unitBet);
            info.AddValue("_minNumberOfMatchingGroups", _minNumberOfMatchingGroups);
            info.AddValue("_maxNumberOfMatchingGroups", _maxNumberOfMatchingGroups);
            info.AddValue("_raceTrack", _raceTrack);
            
            info.AddValue("_date", _date);
            info.AddValue("_group_count", _group.Count);

            for (int i = 0; i < _group.Count; ++i)
            {
                info.AddValue("_group" + i.ToString(), _group[i]);
            }
        }

        public List<Limitation> ShowAllMatchesForSpecificCombination(Limitation combination)
        {
            // We need raw combintations so let's ensure that the system is
            // developed without any compression

            CountCombinations();

            var matchingCombination = new List<Limitation>();

            combination.MaxMatches = combination.CountSkippingZeros();
            combination.MinMatches = combination.CountSkippingZeros();

            foreach (Limitation systemCombination in _developedSystem)
            {
                if (combination.IsMatching(systemCombination))
                {
                    matchingCombination.Add(systemCombination);
                }
            }

            return matchingCombination;
        }

        // Used to retrive the winning ticket's index, if any, for a specific
        // combination.  If the system does not contain a winning ticket
        // returns -1
        public int GetWinningTicket(Limitation combination)
        {
            // We need the number of the winning ticket, so let's ensure
            // that the system is already compressed

            Develop();

            int m = 0;

            combination.MaxMatches = combination.Count();
            combination.MinMatches = combination.Count();

            int index = -1;
            foreach (Limitation systemCombination in _developedSystem)
            {
                ++index;

                if (combination.IsMatching(systemCombination))
                {
                    return index + 1;
                }
            }

            return m;
        }

        private FullSystem(int numOfRaces, string track, DateTime date, int firstRace, int unitBet, double averageNumberOfHorsesPerRace) :
            base(numOfRaces, firstRace)
        {
            _unitBet = unitBet;
            _raceTrack = track;
            _date = date;
            MinMatches = numOfRaces;
            MaxMatches = numOfRaces;
            _group.Add(new LimitationGroup(this));
            _minNumberOfMatchingGroups = 1;
            _maxNumberOfMatchingGroups = 1;
            _averageNumberOfHorsesPerRace = averageNumberOfHorsesPerRace;
            NeedsToBeSaved = false;
            _filename = "";
            
        }

        public bool NeedsToBeCounted
        {
            get
            {
                if (_needsToBeCounted || LimitationNeedsToBeCounted)
                {
                    return true;
                }

                for (int i = 0; i < _group.Count; ++i)
                {
                    var lim = _group[i];

                    if (lim.NeedsToBeCounted)
                    {
                        return true;
                    }
                }

                return false;
            }
            set
            {
                _needsToBeCounted = value;
                LimitationNeedsToBeCounted = value;

                for (int i = 0; i < _group.Count; ++i)
                {
                    _group[i].NeedsToBeCounted = value;
                }

                Program.GetMainForm().NeedsToCreateTickets = value;
            }
        }

        public bool NeedsToBeSaved
        {
            get
            {
                if (_needsToBeSaved || LimitationNeedsToBeSaved)
                {
                    return true;
                }

                for (int i = 0; i < _group.Count; ++i)
                {
                    var lim = _group[i];

                    if (lim.NeedsToBeSaved)
                    {
                        return true;
                    }
                }

                return false;
            }
            set
            {
                _needsToBeSaved = value;
                LimitationNeedsToBeSaved = value;

                for (int i = 0; i < _group.Count; ++i)
                {
                    _group[i].NeedsToBeSaved = value;
                }
            }
        }

        public bool FileIsLocked
        {
            get
            {
                if (_filename.Length <= 0)
                {
                    return false;
                }
                else
                {
                    return (File.GetAttributes(_filename) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
                }
            }
        }

        private void AddNonExistingHorses(FullSystem other)
        {
            for (int raceNumber = 0; raceNumber < NumberOfRaces; ++raceNumber)
            {
                RaceSelection rs = other.GetRaceSelection(raceNumber);

                for (int j = 0; j < rs.Count; ++j)
                {
                    int horse = rs.Get(j);

                    if (false == GetRaceSelection(raceNumber).ContainsHorse(horse))
                    {
                        GetRaceSelection(raceNumber).AddHorse(horse);
                        // this can be eliminated by using a pointer to parent but let's live with it for a while May102008

                        for (int groupIndex = 0; groupIndex < _group.Count; ++groupIndex)
                        {
                            _group[groupIndex].AddHorse(raceNumber, horse);
                        }
                    }
                }
            }
        }

        private void RemoveNonSelectedHorses(FullSystem other)
        {
            for (int raceNumber = 0; raceNumber < NumberOfRaces; ++raceNumber)
            {
                RaceSelection rs = GetRaceSelection(raceNumber);

                for (int j = 0; j < rs.Count; ++j)
                {
                    int horse = rs.Get(j);

                    if (false == other.GetRaceSelection(raceNumber).ContainsHorse(horse))
                    {
                        GetRaceSelection(raceNumber).Remove(horse);

                        // this can be eliminated by using a pointer to parent but let's live with it for a while May102008

                        for (int groupIndex = 0; groupIndex < _group.Count; ++groupIndex)
                        {
                            _group[groupIndex].RemoveHorse(raceNumber, horse);
                        }

                        // The following statement that rolls back the index
                        // was missing, thus creating a nusty bug
                        // where a horse previously selected was not removed since its index
                        // was skipped after the removal ... June082008
                        // PLEASE BE CAREFULL IN SIMILAR SITUATIONS IN THE FUTURE!

                        --j;
                    }
                }
            }
        }

        public int DeleteGroup(int groupIndex)
        {
            if (_group.Count <= 1)
            {
                return groupIndex;
            }

            _group.RemoveAt(groupIndex);
            _needsToBeSaved = true;
            _needsToBeCounted = true;

            int previousIndex = groupIndex - 1;

            _minNumberOfMatchingGroups = _group.Count;
            _maxNumberOfMatchingGroups = _group.Count;

            return previousIndex >= 0 ? previousIndex : 0;
        }

        public void CopyLimitation(int groupIndex, int limitationIndex, Limitation toBeCopied)
        {
            Limitation newLimitation = toBeCopied.CreateDeepCopy();
            _group[groupIndex].SetLimitation(limitationIndex, newLimitation);
            _needsToBeSaved = true;
            _needsToBeCounted = true;
        }

        public void DeleteLimitation(int groupIndex, int limitationIndex)
        {
            _group[groupIndex].RemoveLimitation(limitationIndex);
            _needsToBeSaved = true;
            _needsToBeCounted = true;
        }

        public void CopyMainSelections(FullSystem other)
        {
            Debug.Assert(NumberOfRaces == other.NumberOfRaces);

            _developedCount = 0;
            
            _developedSystem.Clear();
            _unitBet = other._unitBet;
            _needsToBeSaved = true;
            _needsToBeCounted = true;
            _raceTrack = other._raceTrack;
            _date = other._date;
            FirstRace = other.FirstRace;
            AddNonExistingHorses(other);
            RemoveNonSelectedHorses(other);

            for (int i = 0; i < _group.Count; ++i)
            {
                var lim = _group[i];
                lim.SetFirstRace(FirstRace);
            }
        }

        public string SuggestedFileName
        {
            get
            {
                string temp = _raceTrack + "_" + FirstRace.ToString() + "_pick" + NumberOfRaces.ToString() + "_" + _date.Year + _date.Month + _date.Day  + ".stm";
                return temp.Replace(@"/", "_");
            }
        }

        public int UnitBet { get { return _unitBet; } }

        public string RaceTrack { get { return _raceTrack; } }

        public int MinNumberOfMatchingGroups
        {
            get { return _minNumberOfMatchingGroups; }
            set
            {
                if (value != _minNumberOfMatchingGroups && value >= 0 && value <= _group.Count)
                {
                    _needsToBeSaved = true;
                    _needsToBeCounted = true;
                    _minNumberOfMatchingGroups = value;
                }
            }
        }

        public int MaxNumberOfMatchingGroups
        {
            get { return _maxNumberOfMatchingGroups; }
            set
            {
                if (value != _maxNumberOfMatchingGroups && value >= 0 && value <= _group.Count)
                {
                    _needsToBeSaved = true;
                    _needsToBeCounted = true;
                    _maxNumberOfMatchingGroups = value;
                }
            }
        }

        public void Save(string filename)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Create);
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this);
                stream.Close();
                NeedsToBeSaved = false;
                Filename = filename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed To Save System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void ClearDevelopedSystem()
        {
            _developedSystem.Clear();
            _weightStatisticsForTheFullSystem.Clear();
            _weightStatisticsForTheDevelopedSystem.Clear();
            _weightStatisticsForTheFullSystem.SelectedRaceCard = RaceCard.CreateFromXml(RaceTrack, _date);
            _weightStatisticsForTheDevelopedSystem.SelectedRaceCard = RaceCard.CreateFromXml(RaceTrack, _date);

        }

        private int CountCombinations3()
        {
            ClearDevelopedSystem();
            int count = 0;

            int[] i = new int[3];

            for (i[0] = 0; i[0] < ((RaceSelection) _selection[0]).Count; ++i[0])
            {
                for (i[1] = 0; i[1] < ((RaceSelection) _selection[1]).Count; ++i[1])
                {
                    for (i[2] = 0; i[2] < ((RaceSelection) _selection[2]).Count; ++i[2])
                    {
                        var limitation = new Limitation(3, FirstRace);

                        limitation.AddHorse(0, ((RaceSelection) _selection[0]).Get(i[0]));
                        limitation.AddHorse(1, ((RaceSelection) _selection[1]).Get(i[1]));
                        limitation.AddHorse(2, ((RaceSelection) _selection[2]).Get(i[2]));
                        _weightStatisticsForTheFullSystem.Add(limitation);

                        
                        int countPassingGroups = 0;

                        for (int k = 0; k < _group.Count; ++k)
                        {
                            if (((LimitationGroup) _group[k]).IsMatchingAllTheLimitations(limitation) == true)
                            {
                                ++countPassingGroups;
                            }
                        }


                        bool isPassingWeights = true;
                        
                        int value = _weightStatisticsForTheFullSystem.GetTotalValue(limitation);
                        int weight = _weightStatisticsForTheFullSystem.GetTotalWeight(limitation);

                        if (value > 0 && _valueWeightLimitationForTheFullSystem.ContainsWeight(value))
                        {
                            isPassingWeights = false;
                        }

                        if (weight > 0 && _weightWeightLimitationForTheFullSystem.ContainsWeight(weight))
                        {
                            isPassingWeights = false;
                        }


                        if (countPassingGroups >= _minNumberOfMatchingGroups &&
                            countPassingGroups <= _maxNumberOfMatchingGroups &&
                            isPassingWeights )
                        {
                            ++count;
                            _developedSystem.Add(limitation);
                            _weightStatisticsForTheDevelopedSystem.Add(limitation);
                        }
                    }
                }
            }

            return _developedSystem.Count;
        }

        private int CountCombinations4()
        {
            ClearDevelopedSystem();

            int count = 0;
            int[] i = new int[4];

            for (i[0] = 0; i[0] < ((RaceSelection) _selection[0]).Count; ++i[0])
            {
                for (i[1] = 0; i[1] < ((RaceSelection) _selection[1]).Count; ++i[1])
                {
                    for (i[2] = 0; i[2] < ((RaceSelection) _selection[2]).Count; ++i[2])
                    {
                        for (i[3] = 0; i[3] < ((RaceSelection) _selection[3]).Count; ++i[3])
                        {
                            var limitation = new Limitation(4, FirstRace);

                            limitation.AddHorse(0, ((RaceSelection) _selection[0]).Get(i[0]));
                            limitation.AddHorse(1, ((RaceSelection) _selection[1]).Get(i[1]));
                            limitation.AddHorse(2, ((RaceSelection) _selection[2]).Get(i[2]));
                            limitation.AddHorse(3, ((RaceSelection) _selection[3]).Get(i[3]));

                            _weightStatisticsForTheFullSystem.Add(limitation);

                            int countPassingGroups = 0;

                            for (int k = 0; k < _group.Count; ++k)
                            {
                                if (_group[k].IsMatchingAllTheLimitations(limitation) == true)
                                {
                                    ++countPassingGroups;
                                }
                            }

                            bool isPassingWeights = true;

                            int value = _weightStatisticsForTheFullSystem.GetTotalValue(limitation);
                            int weight = _weightStatisticsForTheFullSystem.GetTotalWeight(limitation);

                            if (value > 0 && _valueWeightLimitationForTheFullSystem.ContainsWeight(value))
                            {
                                isPassingWeights = false;
                            }

                            if (weight > 0 && _weightWeightLimitationForTheFullSystem.ContainsWeight(weight))
                            {
                                isPassingWeights = false;
                            }


                            if (countPassingGroups >= _minNumberOfMatchingGroups &&
                                countPassingGroups <= _maxNumberOfMatchingGroups &&
                                isPassingWeights)
                            {
                                ++count;
                                _developedSystem.Add(limitation);
                                _weightStatisticsForTheDevelopedSystem.Add(limitation);
                            }
                        }
                    }
                }
            }

            return _developedSystem.Count;
        }

        private int CountCombinations5()
        {
            ClearDevelopedSystem();
            int count = 0;

            int[] i = new int[5];

            for (i[0] = 0; i[0] < ((RaceSelection) _selection[0]).Count; ++i[0])
            {
                for (i[1] = 0; i[1] < ((RaceSelection) _selection[1]).Count; ++i[1])
                {
                    for (i[2] = 0; i[2] < ((RaceSelection) _selection[2]).Count; ++i[2])
                    {
                        for (i[3] = 0; i[3] < ((RaceSelection) _selection[3]).Count; ++i[3])
                        {
                            for (i[4] = 0; i[4] < ((RaceSelection) _selection[4]).Count; ++i[4])
                            {
                                Limitation limitation = new Limitation(5, FirstRace);

                                limitation.AddHorse(0, ((RaceSelection) _selection[0]).Get(i[0]));
                                limitation.AddHorse(1, ((RaceSelection) _selection[1]).Get(i[1]));
                                limitation.AddHorse(2, ((RaceSelection) _selection[2]).Get(i[2]));
                                limitation.AddHorse(3, ((RaceSelection) _selection[3]).Get(i[3]));
                                limitation.AddHorse(4, ((RaceSelection) _selection[4]).Get(i[4]));
                                _weightStatisticsForTheFullSystem.Add(limitation);
                                int countPassingGroups = 0;

                                for (int k = 0; k < _group.Count; ++k)
                                {
                                    if (((LimitationGroup) _group[k]).IsMatchingAllTheLimitations(limitation) == true)
                                    {
                                        ++countPassingGroups;
                                    }
                                }

                                if (countPassingGroups >= _minNumberOfMatchingGroups &&
                                    countPassingGroups <= _maxNumberOfMatchingGroups)
                                {
                                    ++count;
                                    _developedSystem.Add(limitation);
                                    _weightStatisticsForTheDevelopedSystem.Add(limitation);
                                }
                            }
                        }
                    }
                }
            }

            return _developedSystem.Count;
        }

        private int CountCombinations9()
        {
            ClearDevelopedSystem();

            int count = 0;

            int[] i = new int[9];

            for (i[0] = 0; i[0] < ((RaceSelection) _selection[0]).Count; ++i[0])
            {
                for (i[1] = 0; i[1] < ((RaceSelection) _selection[1]).Count; ++i[1])
                {
                    for (i[2] = 0; i[2] < ((RaceSelection) _selection[2]).Count; ++i[2])
                    {
                        for (i[3] = 0; i[3] < ((RaceSelection) _selection[3]).Count; ++i[3])
                        {
                            for (i[4] = 0; i[4] < ((RaceSelection) _selection[4]).Count; ++i[4])
                            {
                                for (i[5] = 0; i[5] < ((RaceSelection) _selection[5]).Count; ++i[5])
                                {
                                    for (i[6] = 0; i[6] < ((RaceSelection) _selection[6]).Count; ++i[6])
                                    {
                                        for (i[7] = 0; i[7] < ((RaceSelection) _selection[6]).Count; ++i[7])
                                        {
                                            for (i[8] = 0; i[8] < ((RaceSelection) _selection[8]).Count; ++i[8])
                                            {
                                                Limitation limitation = new Limitation(9, FirstRace);

                                                limitation.AddHorse(0, ((RaceSelection) _selection[0]).Get(i[0]));
                                                limitation.AddHorse(1, ((RaceSelection) _selection[1]).Get(i[1]));
                                                limitation.AddHorse(2, ((RaceSelection) _selection[2]).Get(i[2]));
                                                limitation.AddHorse(3, ((RaceSelection) _selection[3]).Get(i[3]));
                                                limitation.AddHorse(4, ((RaceSelection) _selection[4]).Get(i[4]));
                                                limitation.AddHorse(5, ((RaceSelection) _selection[5]).Get(i[5]));
                                                limitation.AddHorse(6, ((RaceSelection) _selection[3]).Get(i[6]));
                                                limitation.AddHorse(7, ((RaceSelection) _selection[4]).Get(i[7]));
                                                limitation.AddHorse(8, ((RaceSelection) _selection[5]).Get(i[8]));
                                                _weightStatisticsForTheFullSystem.Add(limitation);
                                                int countPassingGroups = 0;

                                                for (int k = 0; k < _group.Count; ++k)
                                                {
                                                    if (((LimitationGroup) _group[k]).IsMatchingAllTheLimitations(limitation) == true)
                                                    {
                                                        ++countPassingGroups;
                                                    }
                                                }

                                                if (countPassingGroups >= _minNumberOfMatchingGroups &&
                                                    countPassingGroups <= _maxNumberOfMatchingGroups)
                                                {
                                                    ++count;
                                                    _developedSystem.Add(limitation);
                                                    _weightStatisticsForTheDevelopedSystem.Add(limitation);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return _developedSystem.Count;
        }

        private int CountCombinations6()
        {
            ClearDevelopedSystem();

            int count = 0;

            int[] i = new int[6];

            for (i[0] = 0; i[0] < ((RaceSelection) _selection[0]).Count; ++i[0])
            {
                for (i[1] = 0; i[1] < ((RaceSelection) _selection[1]).Count; ++i[1])
                {
                    for (i[2] = 0; i[2] < ((RaceSelection) _selection[2]).Count; ++i[2])
                    {
                        for (i[3] = 0; i[3] < ((RaceSelection) _selection[3]).Count; ++i[3])
                        {
                            for (i[4] = 0; i[4] < ((RaceSelection) _selection[4]).Count; ++i[4])
                            {
                                for (i[5] = 0; i[5] < ((RaceSelection) _selection[5]).Count; ++i[5])
                                {
                                    Limitation limitation = new Limitation(6, FirstRace);

                                    limitation.AddHorse(0, ((RaceSelection) _selection[0]).Get(i[0]));
                                    limitation.AddHorse(1, ((RaceSelection) _selection[1]).Get(i[1]));
                                    limitation.AddHorse(2, ((RaceSelection) _selection[2]).Get(i[2]));
                                    limitation.AddHorse(3, ((RaceSelection) _selection[3]).Get(i[3]));
                                    limitation.AddHorse(4, ((RaceSelection) _selection[4]).Get(i[4]));
                                    limitation.AddHorse(5, ((RaceSelection) _selection[5]).Get(i[5]));
                                    _weightStatisticsForTheFullSystem.Add(limitation);
                                    int countPassingGroups = 0;

                                    for (int k = 0; k < _group.Count; ++k)
                                    {
                                        if (((LimitationGroup) _group[k]).IsMatchingAllTheLimitations(limitation) == true)
                                        {
                                            ++countPassingGroups;
                                        }
                                    }

                                    if (countPassingGroups >= _minNumberOfMatchingGroups &&
                                        countPassingGroups <= _maxNumberOfMatchingGroups)
                                    {
                                        ++count;
                                        _developedSystem.Add(limitation);
                                        _weightStatisticsForTheDevelopedSystem.Add(limitation);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return _developedSystem.Count;
        }

        

        

        private void ClearFrequencies()
        {
            for (int i = 0; i < NumberOfRaces; ++i)
            {
                GetRaceSelection(i).ClearFrequencies();
            }
        }

        private void UpdateFrequencies()
        {
            ClearFrequencies();

            for (int i = 0; i < _developedSystem.Count; ++i)
            {
                Limitation limitation = _developedSystem[i];
                Debug.Assert(null != limitation);

                for (int j = 0; j < limitation.NumberOfRaces; ++j)
                {
                    RaceSelection rc = limitation.GetRaceSelection(j);

                    for (int k = 0; k < rc.Count; ++k)
                    {
                        GetRaceSelection(j).IncreaseFrequency(rc.Get(k));
                    }
                }
            }
        }

        public static bool ReadYearMonthDay(string date, ref int year, ref int month, ref int day)
        {
            try
            {
                if (date.Contains('/'))
                {
                    string[] s = date.Split('/');
                    month = Convert.ToInt32(s[0]);
                    day = Convert.ToInt32(s[1]);
                    year = Convert.ToInt32(s[2]);
                    return true;
                }
                else
                {
                    month = Convert.ToInt32(date.Substring(0, 4));
                    day = Convert.ToInt32(date.Substring(4, 2));
                    year = Convert.ToInt32(date.Substring(6, 2));
                    return true;
                }
            }
            catch
            {
                year = month = day = 0;
                return false;
            }
        }

        public int CountCombinations()
        {
            int count = 0;
          
            int year = _date.Year, month = _date.Month, day = _date.Day;
            
            

            switch (NumberOfRaces)
            {
                case 3:
                    count = CountCombinations3();
                    break;
                case 4:
                    count = CountCombinations4();
                    break;
                case 5:
                    count = CountCombinations5();
                    break;
                case 6:
                    count = CountCombinations6();
                    break;
                case 9:
                    count = CountCombinations9();
                    break;
                default:
                    MessageBox.Show("Feature Not Implemeted");
                    return -1;
            }

            UpdateFrequencies();
            UpdateLimitationMatchesCount();

            _developedCount = count;

            NeedsToBeCounted = false;

            return count;
        }

        // This method calculates the detailed matches for all the limitations
        private void UpdateLimitationMatchesCount()
        {
            foreach (LimitationGroup group in _group)
            {
                group.UpdateMatchesPerRace(_developedSystem);
            }
        }

        public int ConvertToMetablito()
        {
            CountCombinations();
            _developedCount = _developedSystem.Count;

            _metablito.Clear();
            _metablito.AddRange(_developedSystem);

            int matchesNeeded = NumberOfRaces - 1;

            for (int i = 0; i < _metablito.Count; ++i)
            {
                var currentLimitation = _metablito[i];

                for (int j = i + 1; j < _metablito.Count; ++j)
                {
                    var lim = _metablito[j];

                    if (lim.CountIdenticalSelections(currentLimitation) == matchesNeeded)
                    {
                        _metablito.RemoveAt(j);
                    }
                }
            }

            _metablitoCount = _metablito.Count;

            CompressMetablito();

            return _metablitoCount;
        }

        public int DevelopWithoutCompressing()
        {
            CountCombinations();
            _developedCount = _developedSystem.Count;
            return _developedCount;
        }

        public int Develop()
        {
            CountCombinations();
            _developedCount = _developedSystem.Count;
            Compress();
            return _developedCount;
        }

        public int NumberOfGroups { get { return _group.Count; } }

        public int AddGroup()
        {
            var g = new LimitationGroup(this);
            _group.Add(g);
            _needsToBeSaved = true;
            _needsToBeCounted = true;
            _minNumberOfMatchingGroups = _group.Count;
            _maxNumberOfMatchingGroups = _group.Count;
            return _group.Count - 1;
        }

        public LimitationGroup GetGroup(int index)
        {
            return _group[index];
        }

        public string Date
        {
            get { return _date.ToString(); }
        }

        private void CompressMetablito(int index)
        {
            for (int i = 0; i < NumberOfRaces; ++i)
            {
                CompressMetablito(index, i);
            }
        }

        private void Compress(int index)
        {
            for (int i = 0; i < NumberOfRaces; ++i)
            {
                Compress(index, i);
            }
        }

        private void CompressMetablito(int index, int matching_index)
        {
            var theNewObj = new Limitation(NumberOfRaces, FirstRace);

            theNewObj = _metablito[index].CreateCopy();

            for (int i = index + 1; i < _metablito.Count; ++i)
            {
                int m = _metablito[i].CountIdenticalSelections(_metablito[index]);

                if (m != NumberOfRaces - 1)
                {
                    continue;
                }

                if (_metablito[i].GetRaceSelection(matching_index).IsIdentical(_metablito[index].GetRaceSelection(matching_index)))
                {
                    continue;
                }
                else
                {
                    theNewObj.GetRaceSelection(matching_index).Merge(_metablito[i].GetRaceSelection(matching_index));
                    _metablito.RemoveAt(i);
                    --i;
                }
            }

            _metablito[index] = theNewObj;
        }

        private void Compress(int index, int matching_index)
        {
            var theNewObj = new Limitation(NumberOfRaces, FirstRace);

            theNewObj = _developedSystem[index].CreateCopy();

            for (int i = index + 1; i < _developedSystem.Count; ++i)
            {
                int m = _developedSystem[i].CountIdenticalSelections(_developedSystem[index]);

                if (m != NumberOfRaces - 1)
                {
                    continue;
                }

                if (_developedSystem[i].GetRaceSelection(matching_index).IsIdentical(_developedSystem[index].GetRaceSelection(matching_index)))
                {
                    continue;
                }
                else
                {
                    theNewObj.GetRaceSelection(matching_index).Merge(_developedSystem[i].GetRaceSelection(matching_index));
                    _developedSystem.RemoveAt(i);
                    --i;
                }
            }

            _developedSystem[index] = theNewObj;
        }

        private string GetMetablitoSystemAsString()
        {
            var strg = new StringBuilder();

            strg.Append(RaceTrack + ", " + Date + Environment.NewLine + "Pick" + NumberOfRaces.ToString() + " Starting at race number " + FirstRace.ToString());
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("System Description");
            strg.Append(Environment.NewLine);
            strg.Append("------------------");
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Full       : " + GetTotalNumberOfCombinations().ToString());
            strg.Append(Environment.NewLine);

            double percent = ((double) _developedCount/(double) GetTotalNumberOfCombinations())*100;

            strg.Append("Developed  : " + _developedCount.ToString() + " (" + percent.ToString() + " %)");
            strg.Append(Environment.NewLine);

            double metablitoPercent = ((double) _metablitoCount/(double) _developedCount)*100;
            strg.Append("Metablito : " + _metablitoCount.ToString() + " (" + metablitoPercent.ToString() + " %)");
            strg.Append(Environment.NewLine);

            strg.Append("Total Cost : $" + _metablitoCount*UnitBet);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(this.GetSystemAsString2(0));
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Number of Groups: " + NumberOfGroups.ToString());
            strg.Append("  (We need to catch from " + _minNumberOfMatchingGroups.ToString() + " to " + _maxNumberOfMatchingGroups.ToString() + ")");

            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            for (int groupIndex = 0; groupIndex < NumberOfGroups; ++groupIndex)
            {
                strg.AppendFormat("\t");
                strg.Append("Group: " + (groupIndex + 1).ToString());
                strg.Append(Environment.NewLine);
                strg.Append(Environment.NewLine);

                for (int limitationIndex = 0; limitationIndex < _group[groupIndex].Count; ++limitationIndex)
                {
                    Limitation limitation = _group[groupIndex].Get(limitationIndex);

                    if (limitation.Enabled)
                    {
                        strg.AppendFormat("\t\t");
                        strg.Append("Limitation: " + (groupIndex + 1).ToString() + "." + (limitationIndex + 1).ToString());
                        strg.Append(Environment.NewLine);
                        strg.Append(Environment.NewLine);
                        strg.Append(limitation.GetSystemAsString2(3));
                        strg.Append(Environment.NewLine);
                    }
                    else
                    {
                        strg.AppendFormat("\t\t");
                        strg.Append("Limitation: " + (groupIndex + 1).ToString() + "." + (limitationIndex + 1).ToString());
                        strg.Append(Environment.NewLine);
                        strg.Append(Environment.NewLine);
                        strg.AppendFormat("\t\t\t");
                        strg.Append("This Limitation is disabled and is not considered in system development.");
                        strg.Append(Environment.NewLine + Environment.NewLine);
                    }
                }
            }

            strg.Append(Environment.NewLine);

            return strg.ToString();
        }

        private string GetFullSystemAsString()
        {
            StringBuilder strg = new StringBuilder();

            strg.Append(RaceTrack + ", " + Date + Environment.NewLine + "Pick" + NumberOfRaces.ToString() + " Starting at race number " + FirstRace.ToString());
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("System Description");
            strg.Append(Environment.NewLine);
            strg.Append("------------------");
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Full       : " + GetTotalNumberOfCombinations().ToString());
            strg.Append(Environment.NewLine);

            double percent = ((double) _developedCount/(double) GetTotalNumberOfCombinations())*100;

            strg.Append("Developed  : " + _developedCount.ToString() + " (" + percent.ToString() + " %)");
            strg.Append(Environment.NewLine);
            strg.Append("Total Cost : $" + _developedCount*UnitBet);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(this.GetSystemAsString2(0));
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Number of Groups: " + NumberOfGroups.ToString());
            strg.Append("  (We need to catch from " + _minNumberOfMatchingGroups.ToString() + " to " + _maxNumberOfMatchingGroups.ToString() + ")");

            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            for (int groupIndex = 0; groupIndex < NumberOfGroups; ++groupIndex)
            {
                strg.AppendFormat("\t");
                strg.Append("Group: " + (groupIndex + 1).ToString());
                strg.Append(Environment.NewLine);
                strg.Append(Environment.NewLine);

                for (int limitationIndex = 0; limitationIndex < _group[groupIndex].Count; ++limitationIndex)
                {
                    Limitation limitation = _group[groupIndex].Get(limitationIndex);

                    if (limitation.Enabled)
                    {
                        strg.AppendFormat("\t\t");
                        strg.Append("Limitation: " + (groupIndex + 1).ToString() + "." + (limitationIndex + 1).ToString());
                        strg.Append(Environment.NewLine);
                        strg.Append(Environment.NewLine);
                        strg.Append(limitation.GetSystemAsString2(3));
                        strg.Append(Environment.NewLine);
                    }
                    else
                    {
                        strg.AppendFormat("\t\t");
                        strg.Append("Limitation: " + (groupIndex + 1).ToString() + "." + (limitationIndex + 1).ToString());
                        strg.Append(Environment.NewLine);
                        strg.Append(Environment.NewLine);
                        strg.AppendFormat("\t\t\t");
                        strg.Append("This Limitation is disabled and is not considered in system development.");
                        strg.Append(Environment.NewLine + Environment.NewLine);
                    }
                }
            }

            strg.Append(Environment.NewLine);

            return strg.ToString();
        }

        // May 24 after a request from a member of cosmic forum (PROKROYSTIS)
        // I am adding this feature to display the combintions roundly
        // meaning without condense, one by one
        public string GetRoundly()
        {
            string divider = "===================================================================" + Environment.NewLine;

            var strg = new StringBuilder();

            strg.Append(GetFullSystemAsString());

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Tickets Required: " + _developedSystem.Count.ToString());
            strg.Append(Environment.NewLine + Environment.NewLine);

            int total = 0;
            for (int i = 0; i < _developedSystem.Count; ++i)
            {
                strg.Append(Environment.NewLine);
                strg.Append("Ticket #" + (i + 1).ToString());
                strg.Append(": ");
                strg.Append(((Limitation) _developedSystem[i]).GetSystemHorizontaly());
                strg.Append(Environment.NewLine);
                ++total;
            }

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append("Total Number of Combinations: " + total.ToString());
            strg.Append(Environment.NewLine);

            return strg.ToString();
        }

        public string GetMetablitoAsString()
        {
            string divider = "===================================================================" + Environment.NewLine;

            var strg = new StringBuilder();
            strg.Append(GetMetablitoSystemAsString());

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Tickets Required: " + _metablito.Count.ToString());
            strg.Append(Environment.NewLine + Environment.NewLine);

            int total = 0;
            for (int i = 0; i < _metablito.Count; ++i)
            {
                strg.Append(divider);
                strg.Append(Environment.NewLine);
                strg.Append("Ticket #" + (i + 1).ToString());
                strg.Append(Environment.NewLine + Environment.NewLine);
                strg.Append(((Limitation) _metablito[i]).GetSystemAsString(1));
                strg.Append(Environment.NewLine);

                int combs = ((Limitation) _metablito[i]).GetTotalNumberOfCombinations();
                strg.Append(Tools.GetTabedPrefix(1) + "Combinations  : " + combs);
                strg.Append(Environment.NewLine);
                strg.Append(Tools.GetTabedPrefix(1) + "Cost Per Unit : $" + UnitBet);
                strg.Append(Environment.NewLine);
                strg.Append(Tools.GetTabedPrefix(1) + "Ticket Cost   : $" + combs*UnitBet);
                strg.Append(Environment.NewLine + Environment.NewLine);

                total += _metablito[i].GetTotalNumberOfCombinations();
            }

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append("Total Number of Combinations: " + total.ToString());
            strg.Append(Environment.NewLine);

            return strg.ToString();
        }

        public string GetAsString()
        {
            string divider = "===================================================================" + Environment.NewLine;

            var strg = new StringBuilder();

            strg.Append(GetFullSystemAsString());

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append(Environment.NewLine);

            strg.Append("Tickets Required: " + _developedSystem.Count.ToString());
            strg.Append(Environment.NewLine + Environment.NewLine);

            int total = 0;
            for (int i = 0; i < _developedSystem.Count; ++i)
            {
                strg.Append(divider);
                strg.Append(Environment.NewLine);
                strg.Append("Ticket #" + (i + 1).ToString());
                strg.Append(Environment.NewLine + Environment.NewLine);
                strg.Append(((Limitation) _developedSystem[i]).GetSystemAsString(1));
                strg.Append(Environment.NewLine);

                int combs = ((Limitation) _developedSystem[i]).GetTotalNumberOfCombinations();
                strg.Append(Tools.GetTabedPrefix(1) + "Combinations  : " + combs);
                strg.Append(Environment.NewLine);
                strg.Append(Tools.GetTabedPrefix(1) + "Cost Per Unit : $" + UnitBet);
                strg.Append(Environment.NewLine);
                strg.Append(Tools.GetTabedPrefix(1) + "Ticket Cost   : $" + combs*UnitBet);
                strg.Append(Environment.NewLine + Environment.NewLine);

                total += ((Limitation) _developedSystem[i]).GetTotalNumberOfCombinations();
            }

            strg.Append(divider);
            strg.Append(Environment.NewLine);
            strg.Append("Total Number of Combinations: " + total.ToString());
            strg.Append(Environment.NewLine);

            return strg.ToString();
        }

        private int CompressMetablito()
        {
            int columns_before = _metablito.Count;

            for (;;)
            {
                int max = _metablito.Count;

                for (int i = 0; i < max; ++i)
                {
                    CompressMetablito(i);
                    max = _metablito.Count;
                }

                if (columns_before == _metablito.Count)
                {
                    break;
                }
                else
                {
                    columns_before = _metablito.Count();
                }
            }

            return _metablito.Count;
        }

        private int Compress()
        {
            int columns_before = _developedSystem.Count;

            for (;;)
            {
                int max = _developedSystem.Count;

                for (int i = 0; i < max; ++i)
                {
                    Compress(i);
                    max = _developedSystem.Count;
                }

                if (columns_before == _developedSystem.Count)
                {
                    break;
                }
                else
                {
                    columns_before = _developedSystem.Count();
                }
            }

            return _developedSystem.Count;
        }

        public void LockFileOnDisk()
        {
            Debug.Assert(_filename.Length > 0);

            File.SetAttributes(_filename, FileAttributes.ReadOnly);
        }
    }
}