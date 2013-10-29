using System;
using System.Collections.Generic;
using System.Data;
using Hogar.StatisticTools;
using System.Diagnostics;

namespace Hogar.BrisPastPerformances.Extended
{
    public class BrisRace
    {
        readonly int _raceNumber;

        List<BrisHorse> _horse = new List<BrisHorse>();
        readonly BrisDailyCard _parent;
        BrisHorse _brisTopClassAndRaceRating = null;
        Race _correspondingRace = null;

        double _minClassRating = 0.0;
        double _maxClassRating = 0.0;
        double _minRaceRating = 0.0;
        double _maxRaceRating = 0.0;
        double _minSpeedFigure = 0.0;
        double _maxSpeedFigure = 0.0;

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
                if (h.CorrespondingHorse.Scratched) continue;

                foreach (BrisPastPerformance pp in h.PastPerformances)
                {
                    double rr = pp.BrisRaceRating;
                    double cr = pp.BrisClassRating;
                    double sf = (double)pp.BrisSpeedRatingAsInteger;


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

        int CompareBrisRating(BrisHorse h1, BrisHorse h2)
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

        public void CalculatePercentages(Race race)
        {
            CalculatePercentagesBasedInBestRating(race);
            CalculatePercentagesBasedInBrisPrimePower(race);
        }

        private bool IsHorseScratched(BrisHorse brisHorse, Race myrace)
        {
            Horse myHorse = myrace.GetHorseByProgramNumber(brisHorse.ProgramNumber);
            return null != myHorse ? myHorse.Scratched : true;
        }

        private void CalculatePercentagesBasedInBrisPrimePower(Race myrace)
        {
            List<double> primePowerList = new List<double>();

            foreach (BrisHorse brisHorse in _horse)
            {
                if (!IsHorseScratched(brisHorse, myrace))
                {
                    primePowerList.Add((double)brisHorse.PrimePowerRating);
                }
            }

            FiguresToProbabilities fp = new FiguresToProbabilities();
            List<double> percentages = fp.Calculate(primePowerList, Utilities.PRIME_POWER_CONSTANT);

            Debug.Assert(percentages.Count == primePowerList.Count);

            int i = 0;
            foreach (BrisHorse brisHorse in _horse)
            {
                if (!IsHorseScratched(brisHorse, myrace))
                {
                    brisHorse.WinningPercentBasedInPrimePower = percentages[i++];
                }
            }
        }

        private void CalculatePercentagesBasedInBestRating(Race myrace)
        {
            List<double> bestRatingList = new List<double>();

            foreach (BrisHorse brisHorse in _horse)
            {
                if (!IsHorseScratched(brisHorse, myrace))
                {
                    bestRatingList.Add(brisHorse.BestRating);
                }
            }

            FiguresToProbabilities fp = new FiguresToProbabilities();
            List<double> percentages = fp.Calculate(bestRatingList, Utilities.BEST_RATING_CONSTANT);

            Debug.Assert(percentages.Count == bestRatingList.Count);

            int i = 0;
            foreach (BrisHorse brisHorse in _horse)
            {
                if (!IsHorseScratched(brisHorse, myrace))
                {
                    brisHorse.WinningPercentBasedInBestRating = percentages[i++];
                }
            }
        }

        int ComparePrimeRatings(BrisHorse h1, BrisHorse h2)
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

            dataTable.Columns.Add("Number", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Odds", typeof(Odds));


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

            dataTable.Columns.Add("Number", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Odds", typeof(string));
            dataTable.Columns.Add("Dirt", typeof(double));
            dataTable.Columns.Add("Mud", typeof(double));
            dataTable.Columns.Add("Turf", typeof(double));
            dataTable.Columns.Add("Distance", typeof(double));


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
