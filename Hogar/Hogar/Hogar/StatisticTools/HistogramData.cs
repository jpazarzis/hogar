using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hogar.StatisticTools
{
    public class Pair
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    static public class HistogramData
    {
        class Range
        {
            public double From { get; private set; }
            public double To { get; private set; }
            public int Count { get; set; }

            public Range(double from, double to)
            {
                From = from;
                To = to;
                Count = 0;
            }


            public Pair ToPair()
            {
                return new Pair() { X = (From + To) / 2, Y = Count };
            }
        }

        static private DataSet GetFigures(List<Pair> pairs, string xAxisName, string yAxisName)
        {
            var dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add(xAxisName, typeof(double));
            dataTable.Columns.Add(yAxisName, typeof(double));

            double d = 0.0;

            for (int i = 0; i < pairs.Count; ++i)
            {

                dataTable.Rows.Add(pairs[i].X, pairs[i].Y);
            }

            return dataSet;
        }

        static public DataSet Create(List<double> values, int partitions, string xAxisName, string yAxisName)
        {
            var ranges = new List<Range>();
            double max = values.Max(), min = values.Min(), width = (max - min) / partitions, from = min;
            for (int i = 0; i < partitions; ++i)
            {
                ranges.Add(new Range(from, from + width));
                from += width;
            }

            foreach (double d in values)
            {
                foreach (Range t in ranges)
                {
                    if (d >= t.From && d <= t.To)
                    {
                        ++t.Count;
                        break;
                    }
                }
            }

            var pairs = new List<Pair>();
            ranges.ForEach(r => pairs.Add(r.ToPair()));
            return GetFigures(pairs, xAxisName, yAxisName);

        }
    }
}