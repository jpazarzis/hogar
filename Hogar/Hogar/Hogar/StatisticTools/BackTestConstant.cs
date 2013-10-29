using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hogar.BrisPastPerformances;

namespace Hogar.StatisticTools
{
    public class BackTestConstant
    {
        public delegate double GetValueDelegate(BrisHorse brisHorse);
        public GetValueDelegate GetValue = null;
        public delegate void UpdateObserverDelegate(string message);
        public event UpdateObserverDelegate UpdateObserverEvent;


        public class PercentageBracket
        {
            readonly double _from;
            readonly double _to;

            int _totalPerformers = 0;
            int _totalWinners = 0;

            double _totalAmountWon = 0.0;

            internal PercentageBracket(double from, double to)
            {
                _from = from;
                _to = to;
                _totalAmountWon = 0.0;
            }

            internal bool Fits(double v)
            {
                return v >= _from && v < _to;
            }

            internal void IncreaseWinners()
            {
                ++_totalWinners;
            }

            internal void IncreasePerformers()
            {
                ++_totalPerformers;
            }

            internal void AddToTotalAmountWon(double amount)
            {
                _totalAmountWon += amount;
            }

            public double AvgPercent
            {
                get
                {
                    return (_from + _to) / 2;
                }
            }

            public double ROI
            {
                get
                {
                    if (_totalPerformers == 0)
                    {
                        return 0;
                    }

                    return _totalAmountWon / (2.0 * (double)_totalPerformers);
                }
            }


            public int Winners
            {
                get
                {
                    return _totalWinners;
                }
            }

            public int Performers
            {
                get
                {
                    return _totalPerformers;
                }
            }

            public double From
            {
                get
                {
                    return _from;
                }
            }

            public double To
            {
                get
                {
                    return _to;
                }
            }
        }

        public class PercentageBracketCollection : List<PercentageBracket>
        {
            internal PercentageBracketCollection()
            {
                Initialize();
            }

            private void Initialize()
            {
                double step = 0.02;
                double lastV = 0;
                for (double v = 0.0; v < 0.40; v += step)
                {
                    Add(new PercentageBracket(v,v+step));
                    lastV += step;
                }

                //Add(new PercentageBracket(lastV, 1.0));
            }

            internal void IncreasePerformers(double v)
            {
                foreach (PercentageBracket pb in this)
                {
                    if (pb.Fits(v))
                    {
                        pb.IncreasePerformers();
                        return;
                    }
                }
            }
            internal void IncreaseWinners(double v)
            {
                foreach (PercentageBracket pb in this)
                {
                    if (pb.Fits(v))
                    {
                        pb.IncreaseWinners();
                        return;
                    }
                }
            }
            internal void AddToTotalAmountWon(double v, double amount)
            {

                
                foreach (PercentageBracket pb in this)
                {
                    if (pb.Fits(v))
                    {
                        pb.AddToTotalAmountWon(amount);
                        return;
                    }
                }
            }

        }

        PercentageBracketCollection _percenatges = null;


        public PercentageBracketCollection Calculate(int constant)
        {
            _percenatges = new PercentageBracketCollection();
            List<string> filenames = DailyCard.ExistingFiles;

            foreach (string f in filenames)
            {
                ProcessFile(f,constant);
            }

            return _percenatges;
        }

        private void ProcessFile(string filename, int constant)
        {
            DailyCard dc = DailyCard.Load(filename);
            dc.UpdateScratchesFromDb();

            BrisDailyCard bdc = new BrisDailyCard(dc.BrisAbrvTrackCode, dc.Date);
            int year = Convert.ToInt32(dc.Date.Substring(0, 4));
            string brisfilename = Utilities.GetBrisPastPerformancesFilename(year, dc.BrisAbrvTrackCode + dc.Date.Substring(4));
            bdc.Load(brisfilename);

            foreach (Race race in dc.Races)
            {
                BrisRace brisRace = bdc.GetRaceByItsProgramNumber(race.RaceNumber);
                
                ProcessRace(race, constant, brisRace);
                
            }
        }

        private void ProcessRace(Race race, int constant, BrisRace brisRace)
        {
            
            List<double> figure = new List<double>();
            Dictionary<string, int> horseIndex = new Dictionary<string, int>();

            int index = 0;
            foreach (Horse horse in race.Horses)
            {
                if (!horse.Scratched)
                {
                    if (horse.ProgramNumber.Trim().Length == 0)
                    {
                        continue;
                    }
                    BrisHorse brisHorse = brisRace.GetHorseFromItsNumber(horse.ProgramNumber);

                    if (null != GetValue)
                    {
                        figure.Add(GetValue(brisHorse));
                        horseIndex.Add(brisHorse.ProgramNumber.Trim(), index);
                        ++index;
                    }
                }
            }

            FiguresToProbabilities fp = new FiguresToProbabilities();

            figure = fp.Calculate(figure, constant);

            foreach (double d in figure)
            {
                _percenatges.IncreasePerformers(d);
            }

            double winPayoff = 0.0 ;
            string programNumber = GetWinnerForRace(race.Parent.BrisAbrvTrackCode, race.Parent.Date, race.RaceNumber, ref winPayoff).Trim();

            if (horseIndex.ContainsKey(programNumber))
            {
                int i = horseIndex[programNumber];

                double winnersFigure = figure[i];

                _percenatges.IncreaseWinners(winnersFigure);
                _percenatges.AddToTotalAmountWon(winnersFigure, winPayoff);
            }
        }

        //TODO same method exists in CalculateOptimalConstant Please refactor
        string GetWinnerForRace(string trackCode, string date, int raceNumber, ref double winPayoff)
        {
            UpdateObserver(string.Format("processing {0} {1} {2}", trackCode, date, raceNumber));
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("Exec SelectWinnersProgramNumber '{0}', '{1}' , {2} ", trackCode, date, raceNumber);

                SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    winPayoff = (double)myReader["WIN_PAYOFF"];
                    return (string)myReader["PROGRAM_NUMBER"];
                }

                return "";
            }
            catch
            {
                return "";
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }

        }

        private void UpdateObserver(string s)
        {
            if (null != UpdateObserverEvent)
            {
                UpdateObserverEvent(s);
            }
        }
    }
}
