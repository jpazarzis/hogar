using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;
using Hogar.StatisticTools;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.StatisticTools
{
    public class CalculateOptimalConstant
    {
        readonly List<string> _filenames;
        readonly Dictionary<int, List<double>> _winnerPercentage = new Dictionary<int, List<double>>();
        readonly int _min;
        readonly int _max;
        readonly int _step;


        public delegate void UpdateObserverDelegate(string message);
        public event UpdateObserverDelegate UpdateObserverEvent;

        public delegate double GetValueDelegate(BrisHorse brisHorse);

        public GetValueDelegate GetValue = null;

        

        public CalculateOptimalConstant(int min, int max, int step)
        {
            _max = max;
            _min = min;
            _step = step;
            
            _filenames = DailyCard.ExistingFiles;
        }

        public int Calculate()
        {
            if (null == GetValue)
            {
                throw new Exception("Sorry, cannot calulate because you forgot to set the value accessor method. ");
            }

            _winnerPercentage.Clear();

            foreach (string filename in _filenames)
            {
                ProcessFile(filename);
            }

            int optimalConstant = 0;

            if (_winnerPercentage.Count > 0)
            {
                double maximum = 0;
                
                foreach (KeyValuePair<int, List<double>> pair in _winnerPercentage)
                {

                    double sum = CalculateSum(pair.Value);

                    if (sum > maximum)
                    {
                        optimalConstant = pair.Key;
                        maximum = sum;
                    }
                }
            }

            return optimalConstant;
        }

        double CalculateSum(List<double> valueList)
        {
            if (valueList.Count <= 0)
            {
                return 0;
            }

            double sum = 0.0;

            foreach (double d in valueList)
            {    
                sum += Math.Log(d);
            }

            return Math.Exp(sum / valueList.Count);
        }
        

        private void ProcessFile(string filename)
        {
            UpdateObserver(string.Format("Processing file {0}", filename));
            DailyCard dc = DailyCard.Load(filename);
            dc.UpdateScratchesFromDb();

            BrisDailyCard bdc = new BrisDailyCard(dc.BrisAbrvTrackCode, dc.Date);
            
            //string brisfilename = Hogar.Utilities.PastPerformancesDirectory + @"\" + dc.RaceTrack + dc.Date + ".DRF";
            int year = Convert.ToInt32(dc.Date.Substring(0, 4));
            string brisfilename = Utilities.GetBrisPastPerformancesFilename(year, dc.BrisAbrvTrackCode + dc.Date.Substring(4));
            bdc.Load(brisfilename);

            foreach (Race race in dc.Races)
            {
                BrisRace brisRace = bdc.GetRaceByItsProgramNumber(race.RaceNumber);
                for (int constant = _min; constant < _max; constant+=_step)
                {
                    ProcessRace(race, constant, brisRace,filename);
                }
            }
        }

        string GetWinnerForRace(string trackCode, string date, int raceNumber)
        {
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("Exec SelectWinnersProgramNumber '{0}', '{1}' , {2} ", trackCode, date, raceNumber);

                SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    return (string) myReader["PROGRAM_NUMBER"];
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

        private void ProcessRace(Race race, int constant, BrisRace brisRace,string filename)
        {
            UpdateObserver(string.Format("Processing race {0} with constant = {1} {2}", race.RaceNumber,constant,filename));
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

            string programNumber = GetWinnerForRace(race.Parent.BrisAbrvTrackCode, race.Parent.Date, race.RaceNumber).Trim();

            if (horseIndex.ContainsKey(programNumber))
            {
                int i = horseIndex[programNumber];

                double winnersFigure = figure[i];


                if (!_winnerPercentage.ContainsKey(constant))
                {
                    _winnerPercentage.Add(constant, new List<double>());
                }

                _winnerPercentage[constant].Add(winnersFigure);
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
