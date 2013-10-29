using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;

namespace Hogar.KeyRaces
{
    sealed public class RaceInfo
    {

        readonly List<BrisPastPerformance> _pastPerformance = new List<BrisPastPerformance>();

        public static RaceInfo Make(BrisPastPerformance pp)
        {
            return new RaceInfo(pp);
        }

        private RaceInfo(BrisPastPerformance pp)
        {
            TrackCode = pp.TrackCode;
            Date = string.Format("{0:0000}{1:00}{2:00}", pp.Date.Year, pp.Date.Month, pp.Date.Day);
            RaceNumber = Convert.ToInt32(pp.RaceNumber);
            GoldenFigure = (int)pp.GoldenFigureForTheWinner;
            GoldenPaceFigure = (int) pp.GoldenPaceFigureForTheRace;
            Surface = pp.Surface;
            Distance = pp.DistanceInYards;
            TrackCondition = pp.TrackCondition;
        }

        public string TrackCode { get; private set; }
        public string Date { get; private set; }
        public int RaceNumber { get; private set; }
        public int GoldenFigure { get; private set; }
        public int GoldenPaceFigure { get; private set; }
        public int Distance { get; private set; }
        public string Surface { get; private set; }
        public string TrackCondition { get; private set; }

        public void AddPastPerformance(BrisPastPerformance pp)
        {
            _pastPerformance.Add(pp);
        }

        public List<BrisPastPerformance> PastPerformances
        {
            get
            {
                return _pastPerformance;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", TrackCode.Trim(), Date.Trim(), RaceNumber);
        }

        public int Matches { get; internal set; }


        public int DaysSince
        {
            get
            {
                return _pastPerformance[0].DaysSinceThatRace;                
            }
        }

        public string RaceClassification
        {
            get
            {
                return _pastPerformance[0].RaceClassification;
            }
        }

        public DataSet GetFractionsAsDataTable(List<string> hiddenColumns)
        {
            hiddenColumns.Clear();
            var dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("TodayProgramNumber", typeof(string));
            dataTable.Columns.Add("TodaysOdds", typeof(string));
            dataTable.Columns.Add("HorseName", typeof(string));
            dataTable.Columns.Add("NumberOfDaysSinceLastRace", typeof(int));
            dataTable.Columns.Add("NumberOfDaysSinceThatRace", typeof(int));
            dataTable.Columns.Add("FirstFraction", typeof(string));
            dataTable.Columns.Add("SecondFraction", typeof(string));
            dataTable.Columns.Add("ThirdFraction", typeof(string));
            dataTable.Columns.Add("FinalFraction", typeof(string));
            dataTable.Columns.Add("PostPosition", typeof(string));
            dataTable.Columns.Add("FirstCallPosition", typeof(string));
            dataTable.Columns.Add("SecondCallPosition", typeof(string));
            dataTable.Columns.Add("StretchCallPosition", typeof(string));
            dataTable.Columns.Add("FinalCallPosition", typeof(int));
            dataTable.Columns.Add("GoldenPaceFigureForThisHorse", typeof(int));
            dataTable.Columns.Add("GoldenPaceFigure", typeof(int));
            dataTable.Columns.Add("GoldenFigure", typeof(int));
            dataTable.Columns.Add("GoldenFigureForWinnerOfRace", typeof(int));
            dataTable.Columns.Add("Jockey", typeof(string));
            dataTable.Columns.Add("Odds", typeof(string));
            
            List<BrisPastPerformance> pps = PastPerformances;

            foreach (BrisPastPerformance pp in pps.OrderBy(p=>Convert.ToInt32(p.FinalPosition) != 0 ? Convert.ToInt32(p.FinalPosition) : 999 ))
            {
                if (!pp.IsValid)
                {
                    continue;
                }

                object[] v = new object[dataTable.Columns.Count];
                int index = 0;

                v[index++] = pp.Parent.ProgramNumber;


                v[index++] = string.Format("{0:0.0}", pp.Parent.CorrespondingHorse.RealTimeOdds);
                v[index++] = pp.Parent.Name;
                v[index++] = pp.DaysSinceLastRace;
                v[index++] = pp.DaysSinceThatRace;
                v[index++] = pp.GetFraction(FractionCall.Level.First).FormatedTime;
                v[index++] = pp.GetFraction(FractionCall.Level.Second).FormatedTime;
                v[index++] = pp.GetFraction(FractionCall.Level.Stretch).FormatedTime;
                v[index++] = pp.GetFraction(FractionCall.Level.Final).FormatedTime;
                v[index++] = pp.PostPosition;
                v[index++] = pp.FirstCallPosition;
                v[index++] = pp.SecondCallPosition;
                v[index++] = pp.StretchCallPosition;
                int finalPosition=0;
                int.TryParse(pp.FinalPosition, out finalPosition);
                v[index++] = finalPosition == 0 ? 999 : finalPosition;
                v[index++] = (int)pp.GoldenPaceFigureForThisHorse;
                v[index++] = (int)pp.GoldenPaceFigureForTheRace;
                v[index++] = (int)pp.GoldenFigureForThisHorse;
                v[index++] = (int)pp.GoldenFigureForTheWinner;
                v[index++] = pp.Jockey.Length < 16 ? pp.Jockey : pp.Jockey.Substring(0, 15);
                v[index++] = pp.Odds;
                dataTable.Rows.Add(v);
            }

            return dataSet;
        }
    }
}
