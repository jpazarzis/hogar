using System.Collections.Generic;
using System.Data;

namespace TrackVariantMaint.AnalysisPerTrack
{
    public class Partition
    {
        public double MinFigure { get; private set; }
        
        public double MaxFigure { get; private set; }

        public Dictionary<string, int> CountPerTrack { get; private set; }
        public Dictionary<string, double> FrequencyPerTrack { get; private set; }

        public Partition(double min, double max)
        {
            MinFigure = min;
            MaxFigure = max;
            CountPerTrack = new Dictionary<string, int>();
            FrequencyPerTrack = new Dictionary<string, double>();
        }

        public int TotalNumberOfFigures
        {
            get
            {
                if (null == CountPerTrack)
                    return 0;

                int count = 0;
                foreach (var key in CountPerTrack.Keys)
                {
                    count += CountPerTrack[key];
                }
                return count;
            }
        }


        public DataSet CreateFrequenciesDataSet()
        {
            var dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("Track", typeof(double));
            dataTable.Columns.Add("Frequency", typeof(double));
            dataTable.Columns.Add("TrackName", typeof(string));

            double i = 0;
            foreach (var trackDesc in FrequencyPerTrack.Keys)
            {
                dataTable.Rows.Add(i++, FrequencyPerTrack[trackDesc], trackDesc);
            }

            
            return dataSet;
        }

        public void UpdatePercentage(Dictionary<string,int> totalRacesPerTrack)
        {
            FrequencyPerTrack.Clear();

            foreach (var key in CountPerTrack.Keys)
            {
                if ( totalRacesPerTrack.ContainsKey(key) && totalRacesPerTrack[key] > 0)
                {
                    FrequencyPerTrack.Add(key, (double)CountPerTrack[key] / totalRacesPerTrack[key]);
                }
                    
            }
        }

        public bool Update(WinnersTime wt)
        {
            if (wt.GoldenFigure > MaxFigure || wt.GoldenFigure <= MinFigure)
                return false;

            string key = wt.TrackDesc.Trim();

            if (CountPerTrack.ContainsKey(key))
            {
                ++CountPerTrack[key];
            }
            else
            {
                CountPerTrack.Add(key, 1);
            }

            return true;
        }

        
    }
}