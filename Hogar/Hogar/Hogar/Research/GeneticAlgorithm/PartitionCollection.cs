using System;
using System.Collections.Generic;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    internal class PartitionCollection
    {
        private readonly double _span;

        private readonly List<Partition> _partitions = null;

        public PartitionCollection(int count)
        {
            if (count <= 0 || count > 100)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            _span = 1.0/(double) count;
            _partitions = new List<Partition>(count);

            for (int i = 0; i < count; i++)
            {
                double from = CalculateLowerBound(i);
                double to = from + _span;

                _partitions.Add(new Partition(from,to));

            }
        }

        public void Clear()
        {
            _partitions.ForEach(p=>p.Clear());
        }

        public double Span
        {
            get
            {
                return _span;
            }
        }

        public int Count
        {
            get
            {
                return _partitions.Count;
            }
        }

        public Partition this[double weight]
        {
            get
            {
                return _partitions[FindIndexFromWeight(weight)];
            }
        }

        private int FindIndexFromWeight(double weight)
        {
            if(weight <0.0 || weight >1.0)
            {
                throw new ArgumentOutOfRangeException("weight");
            }

            double d = weight/_span;
            return (int) d;
        }

        private double CalculateLowerBound(int partitionIndex)
        {
            return _span*(double) partitionIndex;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var delimeter = new string('*', 30);
            sb.AppendLine();
            sb.AppendLine(delimeter);
            sb.AppendLine();
            sb.AppendLine("[PartitionCollection]");
            sb.AppendLine();
            sb.AppendLine(string.Format("span = {0}", _span));
            sb.AppendLine();
            sb.AppendLine(string.Format("Partitions"));
            sb.AppendLine();
            foreach (var partition in _partitions)
            {
                sb.AppendLine(partition.ToString());
            }
            sb.AppendLine();
            sb.AppendLine(string.Format("Total Number of Partitions = {0}", Count));
            sb.AppendLine();
            sb.AppendLine(delimeter);
            return sb.ToString();
        }
    }
}