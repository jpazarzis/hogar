using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hogar;
using Hogar.GeneticProgramming;
using Hogar.RaceGrouping;
using Hogar.StatisticTools;
using System.Diagnostics;
using Hogar.Handicapping.Analysis;
using Hogar.Handicapping;

namespace Hogar.BrisPastPerformances
{
    public class BrisRace
    {
        private readonly int _raceNumber;

        private List<BrisHorse> _horse = new List<BrisHorse>();
        private readonly BrisDailyCard _parent;
        private BrisHorse _brisTopClassAndRaceRating = null;
        private Race _correspondingRace = null;

        private DecisionTreeList _goodFavoriteDTL = null;
        private DecisionTreeList _badFavoriteDTL = null;

        private Dictionary<string, DecisionTreeList> _basedInOddsDTL = new Dictionary<string, DecisionTreeList>();

        private double _minClassRating = 0.0;
        private double _maxClassRating = 0.0;
        private double _minRaceRating = 0.0;
        private double _maxRaceRating = 0.0;
        private double _minSpeedFigure = 0.0;
        private double _maxSpeedFigure = 0.0;

        public BrisRace(int raceNumber, BrisDailyCard parent)
        {
            _parent = parent;
            _raceNumber = raceNumber;
        }

        public Race CorrespondingRace
        {
            get
            {
                return _correspondingRace;
            }
            internal set
            {
                _correspondingRace = value;
            }
        }

        public RaceGroupType RaceGroupType
        {
            get
            {
                if (_horse.Count <= 0)
                {
                    return null;
                }
                else if (_horse[0].TodaysRaceIsMCL)
                {
                    return RaceGroupType.MakeMaidenClaimer;
                }
                else if (_horse[0].TodaysRaceIsMSW)
                {
                    return RaceGroupType.MakeMaidenSpecialWeights;
                }
                else if (_horse[0].TodaysRaceIsClaimer)
                {
                    return RaceGroupType.MakeClaimer;
                }
                else if (_horse[0].TodaysRaceIsStakes)
                {
                    return RaceGroupType.MakeStakes;
                }
                else
                {
                    return RaceGroupType.MakeOther;
                }
            }
        }

        internal DecisionTreeList ReadDecisionTreeListFromDisk(string filename)
        {
            var dtl = new DecisionTreeList(DecisionTreeList.Type.Production);

            try
            {
                if (dtl.FileExists(filename))
                {
                    dtl.ReadFromDisk(filename);
                }
                else
                {
                    dtl = null;
                }
            }
            catch
            {
                dtl = null;
            }
            return dtl;
        }

        internal DecisionTreeList GetDecisionTreeListBasedInOdds(double odds)
        {
            string filename = RaceGroupType.BasedInOddsProductionFilename(odds);

            if (_basedInOddsDTL.ContainsKey(filename))
            {
                return _basedInOddsDTL[filename];
            }
            else
            {
                var temp = ReadDecisionTreeListFromDisk(filename);

                if (null != temp)
                {
                    _basedInOddsDTL.Add(filename, temp);
                }
                return temp;
            }
        }

        internal DecisionTreeList GoodFavoriteDTL
        {
            get
            {
                if (null == _goodFavoriteDTL)
                {
                    string filename = RaceGroupType.GoodFavoriteProductionFilename;
                    _goodFavoriteDTL = ReadDecisionTreeListFromDisk(filename);
                }

                return _goodFavoriteDTL;
            }
        }

        internal DecisionTreeList BadFavoriteDTL
        {
            get
            {
                if (null == _badFavoriteDTL)
                {
                    string filename = RaceGroupType.BadFavoriteProductionFilename;
                    _badFavoriteDTL = ReadDecisionTreeListFromDisk(filename);
                }

                return _badFavoriteDTL;
            }
        }

        public DateTime PostTime
        {
            get
            {
                if (_horse.Count > 0)
                {
                    return _horse[0].PostTime;
                }
                else
                {
                    throw new Exception("There are no horses for the race");
                }
            }
        }

        public List<int> GetBrisSpeedFiguresForRecentFormCycles()
        {
            var f = new List<int>();

            foreach (var brisHorse in _horse)
            {
                if(!brisHorse.CorrespondingHorse.Scratched)
                    f.AddRange(brisHorse.GetBrisSpeedFiguresForRecentFormCycles());
            }

            return f;
        }

        internal double MinClassRating
        {
            get
            {
                return _minClassRating;
            }
        }

        internal double MaxClassRating
        {
            get
            {
                return _maxClassRating;
            }
        }

        internal double MinRaceRating
        {
            get
            {
                return _minRaceRating;
            }
        }

        internal double MaxRaceRating
        {
            get
            {
                return _maxRaceRating;
            }
        }

        internal double MinSpeedFigure
        {
            get
            {
                return _minSpeedFigure;
            }
        }

        internal double MaxSpeedFigure
        {
            get
            {
                return _maxSpeedFigure;
            }
        }

        internal void PrepareForInterpolation()
        {
            _minClassRating = _maxClassRating = _minRaceRating = _maxRaceRating = _minSpeedFigure = _maxSpeedFigure = 0.0;

            foreach (BrisHorse h in _horse)
            {
                if (h.CorrespondingHorse.Scratched)
                    continue;

                foreach (BrisPastPerformance pp in h.PastPerformances)
                {
                    double rr = pp.BrisRaceRating;
                    double cr = pp.BrisClassRating;
                    double sf = (double) pp.BrisSpeedRatingAsInteger;

                    if (cr > 0)
                    {
                        if (_minClassRating == 0 || cr < _minClassRating)
                        {
                            _minClassRating = cr;
                        }

                        if (_maxClassRating == 0 || cr > _maxClassRating)
                        {
                            _maxClassRating = cr;
                        }
                    }

                    if (rr > 0)
                    {
                        if (_minRaceRating == 0 || rr < _minRaceRating)
                        {
                            _minRaceRating = rr;
                        }

                        if (_maxRaceRating == 0 || rr > _maxRaceRating)
                        {
                            _maxRaceRating = rr;
                        }
                    }

                    if (sf > 0)
                    {
                        if (_minSpeedFigure == 0 || sf < _minSpeedFigure)
                        {
                            _minSpeedFigure = sf;
                        }

                        if (_maxSpeedFigure == 0 || sf > _maxSpeedFigure)
                        {
                            _maxSpeedFigure = sf;
                        }
                    }
                }
            }
        }

        public BrisDailyCard Parent
        {
            get
            {
                return _parent;
            }
        }

        private int CompareBrisRating(BrisHorse h1, BrisHorse h2)
        {
            int r1 = h1.BestRating;
            int r2 = h2.BestRating;

            if (r1 > r2)
            {
                return -1;
            }
            else if (r1 < r2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        

        private bool IsHorseScratched(BrisHorse brisHorse, Race myrace)
        {
            Horse myHorse = myrace.GetHorseByProgramNumber(brisHorse.ProgramNumber);
            return null != myHorse ? myHorse.Scratched : true;
        }


        private int ComparePrimeRatings(BrisHorse h1, BrisHorse h2)
        {
            int r1 = h1.PrimePowerRating;
            int r2 = h2.PrimePowerRating;

            if (r1 > r2)
            {
                return -1;
            }
            else if (r1 < r2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<BrisHorse> Horses
        {
            get
            {
                return _horse;
            }
        }

        public BrisHorse BrisTopClassAndRaceRating
        {
            get
            {
                if (null != _brisTopClassAndRaceRating)
                {
                    return _brisTopClassAndRaceRating;
                }

                if (_horse.Count <= 0)
                {
                    return null;
                }

                _brisTopClassAndRaceRating = null;

                foreach (BrisHorse bh in _horse)
                {
                    if (null == bh.CorrespondingHorse || bh.CorrespondingHorse.Scratched)
                    {
                        continue;
                    }

                    if (null == _brisTopClassAndRaceRating)
                    {
                        _brisTopClassAndRaceRating = bh;
                    }
                    else if (_brisTopClassAndRaceRating.BrisClassAndRaceRating < bh.BrisClassAndRaceRating)
                    {
                        _brisTopClassAndRaceRating = bh;
                    }
                }

                return _brisTopClassAndRaceRating;
            }
        }

        public string GetHighestPowerRatingHorseNumber(Race myrace)
        {
            _horse.Sort(ComparePrimeRatings);

            foreach (BrisHorse h in _horse)
            {
                Horse myhorse = myrace.GetHorseByProgramNumber(h.ProgramNumber);

                if (null != myhorse && !myhorse.Scratched)
                {
                    return h.ProgramNumber;
                }
            }

            return "";
        }

        public int DifferenceFirstFromSecond()
        {
            _horse.Sort(ComparePrimeRatings);
            if (_horse.Count < 1)
            {
                return 0;
            }

            int r1 = Convert.ToInt32(_horse[0].PrimePowerRating);
            int r2 = Convert.ToInt32(_horse[1].PrimePowerRating);

            return r1 - r2;
        }

        public void Add(BrisHorse horse)
        {
            if (!horse.WasScratched)
            {
                _horse.Add(horse);
            }
        }

        public DataSet GetOddsSummary()
        {
            DataSet dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("Number", typeof (string));
            dataTable.Columns.Add("Name", typeof (string));
            dataTable.Columns.Add("Odds", typeof (Odds));

            List<BrisHorse> horseCollection = _horse;

            foreach (BrisHorse horse in horseCollection)
            {
                dataTable.Rows.Add(horse.ProgramNumber,
                                   horse.Name,
                                   horse.MorningLineOdds
                    );
            }

            return dataSet;
        }

        public DataSet GetBrisRatingsSummary()
        {
            DataSet dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("Number", typeof (string));
            dataTable.Columns.Add("Name", typeof (string));
            dataTable.Columns.Add("Odds", typeof (string));
            dataTable.Columns.Add("Dirt", typeof (double));
            dataTable.Columns.Add("Mud", typeof (double));
            dataTable.Columns.Add("Turf", typeof (double));
            dataTable.Columns.Add("Distance", typeof (double));

            List<BrisHorse> horseCollection = _horse;

            foreach (BrisHorse horse in horseCollection)
            {
                dataTable.Rows.Add(horse.ProgramNumber,
                                   horse.Name,
                                   horse.MorningLineOdds.ToString(),
                                   horse.BrisDirtPedigreeRating,
                                   horse.BrisMudPedigreeRating,
                                   horse.BrisTurfPedigreeRating,
                                   horse.BrisDistancePedigreeRating
                    );
            }

            return dataSet;
        }

        public int RaceNumber
        {
            get
            {
                return _raceNumber;
            }
        }

        public BrisHorse GetHorseFromItsNumber(string num)
        {
            // TODO: Make this faster

            num = num.Trim();

            foreach (BrisHorse h in _horse)
            {
                string s = h.ProgramNumber.Trim();

                if (s.CompareTo(num) == 0)
                {
                    return h;
                }
            }

            return null;
        }

        public int DistanceInYards
        {
            get
            {
                return Math.Abs(_horse.Count > 0 ? _horse[0].DistanceInYards : 0);
            }
        }

        public bool IsAboutDistance
        {
            get
            {
                return _horse[0].DistanceInYards < 0;
            }
        }

        public string Surface
        {
            get
            {
                return _horse.Count > 0 ? _horse[0].Surface: "";
            }
        }

        public string RaceClassification
        {
            get
            {
                return _horse.Count > 0 ? _horse[0].RaceClassification : "Unknown";
            }
        }

        public BrisHorse this[int index]
        {
            get
            {
                return _horse[index];
            }
        }

        public int NumberOfHorses
        {
            get
            {
                return _horse.Count;
            }
        }
    }
}