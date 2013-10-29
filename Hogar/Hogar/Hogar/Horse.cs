using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.BrisPastPerformances;
using Hogar.FactorStatisticsNew;
using Hogar.Handicapping.Analysis;
using Hogar.Handicapping;
using System.IO;
using System.Threading;
using Hogar.StatisticTools;

namespace Hogar
{

    public enum NeuralNetworkOpinion
    {
        IsACandiateToImprove,
        IsABet,
        NotABet,
        NoOpinion
    }

    [Serializable]
    public class Horse : ISerializable , IFormattable
    {
        static readonly string HorizontalLine = new string('_', 120);

        readonly string _programNumber;
        readonly string _name;
        readonly Odds _morningLineOdds = null;
        readonly Odds _myOdds = null;
        bool _isScratched = false;
        private bool _isBestBet = false;
        int _selectedRunningLineIndex = -1;
        Race _parent = null;
        int _horseID = -1;
        BrisHorse _correspondingBrisHorse = null;
        double _adjustedSpeed = 0.0;
        bool _hasNotes = false;
        bool _isContenter = true;
        bool _isDonkey = false;
        private int _valueIndex = 0;
        private int _weightIndex = 0;

        // PLEASE NOTE:
        // comments are different from notes.  
        // Notes are stored in the data base
        // and usually describe how the race was run and will appear the next time the
        // horse will run.  
        // Comments in the other hand are part of our handicapping before the race 
        // and are part of the odds file
        string _comments = "";
        double _readTimeOdds = 0.0;

        DataSet _ds = null;
        List<FactorPerformance> _factorsPerformance = null;

        private List<FactorStatistic> _factorStatistics = null;

        private List<FactorStatistic> _factorStatisticsForTrainer = null;



        Dictionary<DateTime, Odds> _realTimeOddsHistory = new Dictionary<DateTime, Odds>();

        public delegate void UpdateObserverDelegate();

        public event UpdateObserverDelegate _updateObserverEvent;

        public delegate void UpdateCommentObserverDelegate(object sender);

        public event UpdateCommentObserverDelegate _updateCommentObserverEvent;
        
        public delegate void UpdateRunningLineDelegate(Horse horse);
        public event UpdateRunningLineDelegate _updateRunningLineEvent;

        object _realTimeOddsLocker = new object();

        private bool _wasTheBettingFavorite = false;

        private double _finalOdds = 0.0;
        private int _finalPosition = 0;

        internal Horse(string number, string name, Odds odds)
        {
            _programNumber = number;
            _name = name;
            _morningLineOdds = new Odds(odds);
            _myOdds = new Odds(odds);
            _myOdds.Parent = this;
        }

        private NeuralNetworkOpinion _neuralNetworkOpinion = NeuralNetworkOpinion.NoOpinion;

        public NeuralNetworkOpinion NeuralNetworkOpinion 
        { 
            get
            {
                return _neuralNetworkOpinion;
            }
            internal set
            {
                _neuralNetworkOpinion = value;
            }
        }

        public void UpdateCommentObservers(object sender)
        {
            if (null != _updateCommentObserverEvent)
            {
                _updateCommentObserverEvent(sender);
            }
        }

        public int Votes { get; set; }

      

        public void UpdateObservers()
        {
            if (null != _updateObserverEvent)
            {
                _updateObserverEvent();
            }
        }

        public void UpdateRunningLineObservers()
        {
            if (null != _updateRunningLineEvent)
            {
                _updateRunningLineEvent(this);
            }
        }

        public bool FirstAfterLayoff
        {
            get
            {

                return _correspondingBrisHorse.DaysSinceLastRace >45;
            }
        }

        public bool FirstAfterLongLayoff
        {
            get
            {

                BrisHorse horse = this.CorrespondingBrisHorse;
                if (horse.IsFirstTimeOut)
                {
                    return false;
                }
                int daysSinceLast = horse.DaysSinceLastRace;
                return daysSinceLast >= Utilities.LONG_LAYOFF_DAYS;
            }
        }


                    

        public bool SecondAfterLayoff
        {
            get
            {

                if (_correspondingBrisHorse.IsFirstTimeOut)
                {
                    return false;
                }
                else if (FirstAfterLayoff)
                {
                    return false;
                }

                else if (_correspondingBrisHorse.PastPerformances.Count ==0)
                {
                    return false;
                }
                else
                {
                    int d = _correspondingBrisHorse.PastPerformances[0].DaysSinceLastRace;
                    return d> 45 || d == 0;                                            
                }
            }
        }

        public bool ThirdAfterLayoff
        {
            get
            {
                if (_correspondingBrisHorse.IsFirstTimeOut)
                {
                    return false;
                }
                else if (FirstAfterLayoff)
                {
                    return false;
                }
                else if (SecondAfterLayoff)
                {
                    return false;
                }
                else if (_correspondingBrisHorse.PastPerformances.Count < 2)
                {
                    return false;
                }
                else
                {
                    int d = _correspondingBrisHorse.PastPerformances[1].DaysSinceLastRace;
                    return d> 45 || d == 0;
                }
            }
        }


        public bool HasNotes
        {
            get
            {
                return _hasNotes;
            }
            set
            {
                _hasNotes = value;
            }
        }

        public int HorseID
        {
            set
            {
                _horseID = value;
            }
            get
            {
                return _horseID;
            }
        }

        public double AdjustedSpeed
        {
            get
            {
                return _adjustedSpeed;
            }
            internal set
            {
                _adjustedSpeed = value;
            }
        }

        public void AddRealTimeOddsToHistory(Odds odds)
        {
            lock (_realTimeOddsLocker)
            {
                _realTimeOddsHistory.Add(DateTime.Now, odds);
            }
        }

        public double RealTimeOdds
        {
            get
            {

                if (_readTimeOdds > 0)
                {
                    return _readTimeOdds;
                }
                else
                {
                    return _morningLineOdds.GetOddsToOne();
                }
            }
            set
            {
                _readTimeOdds = value;
            }
        }

        public Dictionary<DateTime, Odds> RealTimeOddsHistory
        {
            get
            {
                lock (_realTimeOddsLocker)
                {
                    Dictionary<DateTime, Odds> temp = new Dictionary<DateTime, Odds>();

                    foreach (KeyValuePair<DateTime, Odds> pair in _realTimeOddsHistory)
                    {
                        temp.Add(pair.Key, pair.Value);
                    }

                    return temp;
                }
            }
        }

        
        private string SQLDeleteFactor
        {
            get
            {
                return string.Format("EXEC DeleteHorseFactor {0} ", this.HorseID);
            }
        }

        private string SQLUpdateFactor
        {
            get
            {
                return string.Format("EXEC InsertHorseFactor {0} , {1} ", this.HorseID, this._correspondingBrisHorse.HandicappingFactorsFlag);
            }
        }

        internal void SaveFactorsToDb()
        {
            SqlCommand myCommand = new SqlCommand(SQLDeleteFactor, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
            if (!Scratched)
            {
                myCommand = new SqlCommand(SQLUpdateFactor, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
            }

            UpdateTrainerStats();
           
        }

        private void UpdateTrainerStats()
        {
            if (!Scratched)
            {
                int id = HorseID;
                int daysoff = _correspondingBrisHorse.DaysSinceLastRace;
                int daysOff2Back = _correspondingBrisHorse.DaysOff2Back;
                int daysOff3Back = _correspondingBrisHorse.DaysOff3Back;

                string sql = string.Format("Exec UpdateTrainerStats {0}, {1}, {2}, {3} ", id, daysoff, daysOff2Back, daysOff3Back);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
            }
        }

       

        public BrisHorse CorrespondingBrisHorse
        {
            get
            {
                return _correspondingBrisHorse;
            }
            set
            {
                _correspondingBrisHorse = value;
                if (null != _correspondingBrisHorse)
                {
                    _correspondingBrisHorse.CorrespondingHorse = this;
                }
            }
        }

       public int GetProgramNumberWithoutEntryChar()
        {
            string num = _programNumber.ToUpper();
            if (num.Trim().Length <= 0)
            {
                return 0;
            }
            for (char ch = 'A'; ch <= 'Z'; ++ch)
            {
                string s = new string(ch, 1);
                num = num.Replace(s, "");
            }
            return Convert.ToInt32(num.Trim());
        }

        internal void Save()
        {
            if (null != _parent)
            {
                _parent.Parent.Save();
            }
        }

        public Race Parent
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

        public Horse(SerializationInfo info, StreamingContext ctxt) 
        {
            _programNumber = (String)info.GetValue("_programNumber", typeof(string));
            _name = (String)info.GetValue("_name", typeof(string));

            // TODO Jun 18 2008
            // Investigate why when not use the copy constructor for morning and my odds
            // they both point to the same object

            _morningLineOdds = (Odds)info.GetValue("_morningLineOdds", typeof(Odds));
            _morningLineOdds = new Odds(_morningLineOdds);
            _myOdds = (Odds)info.GetValue("_myOdds", typeof(Odds));
            _myOdds = new Odds(_myOdds);


            // To ensure backwards compatibility lets use the Utilities.GetSerializedObject
            // instead of directly using the info.GetValue, there might be a better solution
            // though, but as of now I don't now it JUN 21 2008 JP

            _isScratched = (bool)Utilities.GetSerializedObject(info, "_isScratched", typeof(bool), false);
            _selectedRunningLineIndex = (int)Utilities.GetSerializedObject(info, "_selectedRunningLineIndex", typeof(int), -1);
            _isContenter = (bool)Utilities.GetSerializedObject(info, "_isContenter", typeof(bool), true);
            _isDonkey = (bool)Utilities.GetSerializedObject(info, "_isDonkey", typeof(bool), false);
            _comments = (string)Utilities.GetSerializedObject(info, "_comments", typeof(string), "");
            _factorsPerformance = (List<FactorPerformance>)Utilities.GetSerializedObject(info, "_factorsPerformance", typeof(List<FactorPerformance>), null);
            _isBestBet = (bool)Utilities.GetSerializedObject(info, "_isBestBet", typeof(bool), false);
            _valueIndex = (int)Utilities.GetSerializedObject(info, "_valueIndex", typeof(int), 0);
            _weightIndex = (int)Utilities.GetSerializedObject(info, "_weightIndex", typeof(int), 0);


            _myOdds.Parent = this;

            _ds = null;

            if (null != _factorsPerformance)
            {
                BuildFactorPerformanceTable();
            }

            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_programNumber", _programNumber);
            info.AddValue("_name", _name);
            info.AddValue("_morningLineOdds", _morningLineOdds);
            info.AddValue("_myOdds", _myOdds);
            info.AddValue("_isScratched", _isScratched);
            info.AddValue("_isBestBet", _isBestBet);
            info.AddValue("_selectedRunningLineIndex", _selectedRunningLineIndex);
            info.AddValue("_isContenter", _isContenter);
            info.AddValue("_comments", _comments);
            info.AddValue("_factorsPerformance", _factorsPerformance);
            info.AddValue("_isDonkey", _isDonkey);
            info.AddValue("_valueIndex", _valueIndex);
            info.AddValue("_weightIndex", _weightIndex);
            

            
        }

        public bool IsBestBet
        {
            get
            {
                return _isBestBet;
            }
            set
            {
                _isBestBet = value;
            }
        }


        public void AutoSelecteRunningLine()
        {
            
        }
        

        public BrisPastPerformance SelectedRunningLine
        {
            get
            {
                if (_selectedRunningLineIndex >= 0)
                {
                    return _correspondingBrisHorse.PastPerformances[_selectedRunningLineIndex];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _selectedRunningLineIndex = -1;
                int index = 0;
                foreach (BrisPastPerformance pp in _correspondingBrisHorse.PastPerformances)
                {
                    if (pp == value)
                    {
                        _selectedRunningLineIndex = index;
                    }
                    ++index;
                }
                _parent.Parent.Save();
                UpdateRunningLineObservers();
            }
        }

        public override String ToString()
        { 
            return ToString(null, null); 
        }

        public String ToString(String format, IFormatProvider fp)
        {
            
            if (format == null)
            {
                return _name;
            }
            else if (format == "full")
            {
                return "Horse Name: " +_name + "         M/L : " + this._morningLineOdds.ToString() + " - 1             My Odds : "  + this.MyOdds.ToString() + " - 1";
            }
            else
            {
                throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
            }
        }

        

        public string Name
        {
            get 
            { 
                return _name; 
            }
        }

        public string ProgramNumber
        {
            get
            { 
                return _programNumber; 
            }
        }

        public Odds MyOdds
        {
            get 
            { 
                return _myOdds; 
            }
        }

        internal void ResetFactors()
        {
            _ds = null;
            _factorsPerformance.Clear();
        }

        public void ScratchIt()
        {
            _isScratched = true;
            
            _parent.Parent.Save();
        }

        public void UnscratchIt()
        {
            _isScratched = false;
            
            _parent.Parent.Save();
        }

        internal void UnscratchItWithoutSaving()
        {
            _isScratched = false;
        }

        public void ToggleIsContenterStatus()
        {
            _isContenter = !_isContenter;
            _parent.Parent.Save();
        }

        public void ToggleScratchStatus()
        {
            _isScratched = !_isScratched;
            _parent.Parent.Save();
        }

        public bool Scratched
        {
            get
            {
                return _isScratched;
            }          
        }

        public List<FactorStatistic> FactorStatisticsForTrainer
        {
            get
            {
                if (null == _factorStatisticsForTrainer)
                {
                    _factorStatisticsForTrainer = CorrespondingBrisHorse.GetMatchingHandicappingFactors(this).Select(factor => FactorStatisticManager.Get(factor.BitMask, CorrespondingBrisHorse.TrainersFullName)).ToList();
                }

                return _factorStatisticsForTrainer;
            }
        }

        public List<FactorStatistic> FactorStatisticsForHorse
        {
            get
            {
                if (null == _factorStatistics)
                {
                    _factorStatistics = CorrespondingBrisHorse.GetMatchingHandicappingFactors(this).Select(factor => FactorStatisticManager.Get(factor.BitMask)).ToList();
                }

                return _factorStatistics;
            }
        }


        public Odds MorningLineOdds
        {
            get 
            { 
                if(_finalOdds > 0 )
                {
                    return Odds.Make(string.Format("{0}", _finalOdds));
                }
                else
                {
                    return _morningLineOdds;     
                }
            }
        }

        internal void ClearFactorsPerformance()
        {
            _factorsPerformance = null;
        }

        public bool IsDonkey
        {
            get
            {
                return _isDonkey;
            }
            set
            {
                _isDonkey = value;
                _parent.Parent.Save();
            }
        }

        public bool IsPossibleWinner
        {
            get
            {
                if(IsDonkey)
                    return false;
                
                var pp = this.CorrespondingBrisHorse.PastPerformances;
                
                if(pp.Count < 3)
                    return false;

                return pp[0].BrisSpeedRating < pp[1].BrisSpeedRating || pp[0].BrisSpeedRating < pp[2].BrisSpeedRating;
            }
        }

        public bool IsContenter
        {
            get
            {
                return _isContenter;
            }
            set
            {
                _isContenter = value;

                if(!_isContenter)
                {
                    _isBestBet = false;
                }
            }
        }

        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                _parent.Parent.Save();
            }
        }

        
        public bool IsAPrimeBet
        {
            get
            {
                if (null == _factorsPerformance)
                {
                    return false;
                }

                foreach (FactorPerformance f in _factorsPerformance)
                {
                    PrimeBetRequirements pbr = PrimeBetRequirements.Singleton;
                    if (pbr.IsPrimeFactor(f))
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        
        public string BrisFiguresAsHtmlFile
        {
            get
            {
                string filename = string.Format(@"{0}\{1}_{2}_{3}_{4}.html", Utilities.WebDocumentDirectory, Parent.Parent.TrackCode, Parent.Parent.Date, Parent.RaceNumber, this.ProgramNumber);
                using (var writer = new StreamWriter(filename))
                {
                    writer.WriteLine(GetFiguresAsHtml());
                }
                return filename;
            }

        }

        // Sep 9 2011
        // I am adding ValueIndex and WeightIndex that will be used for Pick3-4-6 
        // ValueIndex reflects the expected odds of the horse while WeightIndex reflects
        // my own estimate of each horse to win the race...


        // ValueIndex
        //      1: very heavy favorite
        //      2: favorite
        //      3: second choice
        //      4: third choice
        //      5: longshot

        public int ValueIndex
        {
            get
            {
                return _valueIndex;
            }
            set
            {
                _valueIndex = value;

                if (_valueIndex < 0 || _valueIndex > 5)
                {
                    _valueIndex = 0;
                }

                _parent.Parent.Save();
            }
        }


        // WeightIndex
        //      1: Clearly The best
        //      2: First Choice
        //      3: second choice
        //      4: third choice
        //      5: longshot

        public int WeightIndex
        {
            get
            {
                return _weightIndex;
            }
            set
            {
                _weightIndex = value;

                if (_weightIndex < 0 || _weightIndex > 5)
                {
                    _weightIndex = 0;
                }
                
                _parent.Parent.Save();
            }
        }
        

        private string GetFiguresAsHtml()
        {
            var sb = new StringBuilder();

          

                

            for (int i = 0; i < _correspondingBrisHorse.PastPerformances.Count; ++i )
            {
                var pp = _correspondingBrisHorse.PastPerformances[i];

                if (pp.DaysSinceLastRace >= Utilities.LAYOFF_DAYS)
                {
                    sb.Append(@"<div style='text-decoration:underline;'>");
                }
                else
                {
                    sb.Append("<div>");
                }

               
                sb.Append(string.Format("{0}", pp.BrisSpeedRating));
                sb.Append("</div>");
            }

                

            return sb.ToString();
        }

        internal void LoadFactorsPerformance()
        {

            int sleepInterval = 10;

            DataTable dt = new DataTable();

            _factorsPerformance = new List<FactorPerformance>();
            
            dt.Columns.Add("F", typeof(FactorPerformance)); 
            dt.Columns.Add("M", typeof(int));
            dt.Columns.Add("W", typeof(int));
            dt.Columns.Add("ROI", typeof(double));
            dt.Columns.Add("IV", typeof(double));
            

            List<Factor> factors=_correspondingBrisHorse.GetMatchingHandicappingFactors(this);
            string trackCode = _correspondingBrisHorse.Parent.Parent.TrackCode;

            long raceAttributes = this.Parent.RaceAttributesFlag;

            foreach (Factor f in factors)
            {
                Thread.Sleep(sleepInterval);

                FactorPerformance fp = FactorPerformance.GetFactorPerformance(f.BitMask, raceAttributes, trackCode);

                if (fp.Matches > 0)
                {
                    object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV};
                    dt.Rows.Add(obj);
                    _factorsPerformance.Add(fp);
                }
            }

            

            if (_parent.FactorsDepth >= 2)
            {

                for (int i = 0; i < factors.Count - 1; ++i)
                {
                    for (int j = i + 1; j < factors.Count; ++j)
                    {
                        Thread.Sleep(sleepInterval);

                        Factor f1 = factors[i];
                        Factor f2 = factors[j];
                        long mask = f1.BitMask | f2.BitMask;

                        FactorPerformance fp = FactorPerformance.GetFactorPerformance(mask, raceAttributes, trackCode);

                        if (fp.Matches > 0)
                        {
                            object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV};
                            dt.Rows.Add(obj);
                            _factorsPerformance.Add(fp);
                        }
                    }
                }
            }

            if (_parent.FactorsDepth >= 3)
            {
                for (int i = 0; i < factors.Count - 2; ++i)
                {
                    for (int j = i + 1; j < factors.Count - 1; ++j)
                    {
                        for (int k = j + 1; k < factors.Count; ++k)
                        {
                            Thread.Sleep(sleepInterval);

                            Factor f1 = factors[i];
                            Factor f2 = factors[j];
                            Factor f3 = factors[k];
                            long mask = f1.BitMask | f2.BitMask | f3.BitMask;

                            FactorPerformance fp = FactorPerformance.GetFactorPerformance(mask, raceAttributes, trackCode);

                            if (fp.Matches > 0)
                            {
                                object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV};
                                dt.Rows.Add(obj);
                                _factorsPerformance.Add(fp);
                            }
                        }
                    }
                }
            }


            if (_parent.FactorsDepth >= 4)
            {
                for (int i = 0; i < factors.Count - 3; ++i)
                {
                    for (int j = i + 1; j < factors.Count - 2; ++j)
                    {
                        for (int k = j + 1; k < factors.Count - 1; ++k)
                        {
                            for (int m = k + 1; m < factors.Count; ++m)
                            {
                                Thread.Sleep(sleepInterval);

                                Factor f1 = factors[i];
                                Factor f2 = factors[j];
                                Factor f3 = factors[k];
                                Factor f4 = factors[m];
                                long mask = f1.BitMask | f2.BitMask | f3.BitMask | f4.BitMask;

                                FactorPerformance fp = FactorPerformance.GetFactorPerformance(mask, raceAttributes, trackCode);

                                if (fp.Matches > 0)
                                {
                                    object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV};
                                    dt.Rows.Add(obj);
                                    _factorsPerformance.Add(fp);
                                }
                            }
                        }
                    }
                }
            }

            if (_parent.FactorsDepth >= 5)
            {
                for (int i = 0; i < factors.Count - 4; ++i)
                {
                    for (int j = i + 1; j < factors.Count - 3; ++j)
                    {
                        for (int k = j + 1; k < factors.Count - 2; ++k)
                        {
                            for (int m = k + 1; m < factors.Count - 1; ++m)
                            {
                                for (int n = m + 1; n < factors.Count; ++n)
                                {
                                    Thread.Sleep(sleepInterval);

                                    Factor f1 = factors[i];
                                    Factor f2 = factors[j];
                                    Factor f3 = factors[k];
                                    Factor f4 = factors[m];
                                    Factor f5 = factors[n];

                                    long mask = f1.BitMask | f2.BitMask | f3.BitMask | f4.BitMask | f5.BitMask;

                                    FactorPerformance fp = FactorPerformance.GetFactorPerformance(mask, raceAttributes, trackCode);

                                    if (fp.Matches > 0)
                                    {
                                        object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV};
                                        dt.Rows.Add(obj);
                                        _factorsPerformance.Add(fp);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            _ds = new DataSet();
            _ds.Tables.Add(dt);
            _parent.Parent.Save();
        }

        void BuildFactorPerformanceTable()
        {
            _ds = null;

            if(null != _factorsPerformance)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("F", typeof(FactorPerformance));
                dt.Columns.Add("M", typeof(int));
                dt.Columns.Add("W", typeof(int));
                dt.Columns.Add("ROI", typeof(double));
                dt.Columns.Add("IV", typeof(double));

                foreach (FactorPerformance fp in _factorsPerformance)
                {
                    object[] obj = new object[] { fp, fp.Matches, fp.Winners, fp.ROI, fp.IV };
                    dt.Rows.Add(obj);
                }

                _ds = new DataSet();
                _ds.Tables.Add(dt);
            }

        }

        


        public DataSet MatchingFactors
        {
            get
            {
                return _ds;
            }
        }

        public double FinalOdds
        {
            get
            {
                if (0 == _finalOdds)
                {
                    if (0 == _readTimeOdds)
                    {
                        return _morningLineOdds.GetOddsToOne();
                        
                    }
                    else
                    {
                        return _readTimeOdds;
                    }
                }

                else 
                {
                    return _finalOdds;
                }
            }
            internal set
            {
                _finalOdds = value;
            }
        }

        public bool WasTheBettingFavorite
        {
            get
            {
                return _wasTheBettingFavorite;
            }
            internal set
            {
                _wasTheBettingFavorite = value;
            }
        }
        public int FinalPosition
        {
            get
            {
                return _finalPosition;
            }
            internal set
            {
                _finalPosition = value;
            }
        }

        public void ToggleIsBestBetStatus()
        {
            _isBestBet = !_isBestBet;
            _parent.Parent.Save();
        }

        public void AddToWeightXmlNode(XmlDocument doc, XmlElement node)
        {
            
            var horseNode = doc.CreateElement("horse");
            horseNode.SetAttribute("program-number", this.GetProgramNumberWithoutEntryChar().ToString());
            horseNode.SetAttribute("value-index", ValueIndex.ToString());
            horseNode.SetAttribute("weight-index", WeightIndex.ToString());

            node.AppendChild(horseNode);
        }

        public void AutoAssignValueIndexBasedInMorningLine()
        {
            _valueIndex = 0;

            if(Scratched)
                return;

            double odds = MorningLineOdds.GetOddsToOne();

            if (odds <= 2.0)
                _valueIndex = 1;
            else if (odds <= 3.5)
                _valueIndex = 2;
            else if (odds <= 6.0)
                _valueIndex = 3;
            else if (odds <= 10.0)
                _valueIndex = 4;
            else
                _valueIndex = 5;
        }
    }
}
