using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
    public class Solution
    {
        private const int MaxNumberOfFactors = 44;

        readonly List<double> _weights = new List<double>();

        private double _fitness = 0.0;

        private static int _mutationRate = 7;

        private readonly PartitionCollection _partitions = new PartitionCollection(100);

        protected enum CreationType
        {
            Random,
            LoadFromDb
        }

        static public Solution MakeFromDb()
        {
            return new Solution(CreationType.LoadFromDb);
        }


        static internal Solution MakeRandom()
        {
            return new Solution(CreationType.Random);
        }

        static internal Solution CrossOver(Solution s1, Solution s2)
        {
            return new Solution(s1,s2);
        }


        internal PartitionCollection Partitions
        {
            get
            {
                return _partitions;
            }
        }
        
        private Solution(Solution s1, Solution s2)
        {
            _weights = new List<double>();

            int crossOverPoint = Randomizer.GetNextInteger(0, s1._weights.Count);

            for (int i = 0; i < s1._weights.Count; ++i)
            {
                List<double> l = i <= crossOverPoint ? s1._weights : s2._weights;
               _weights.Add(l[i]);
            }
        }
    


        protected Solution(CreationType creationType)
        {
            switch (creationType)
            {
                case CreationType.Random:
                    for (int i = 0; i < MaxNumberOfFactors; ++i)
                    {
                        _weights.Add(Randomizer.GetNextWeight());
                    }
                    break;
                case CreationType.LoadFromDb:
                    LoadFromDb();
                    break;
                    
            }
        }

        private void LoadFromDb()
        {
            _weights.Clear();
            SqlDataReader myReader = null;
            try
            {
                const string sql = @"Select MAIDEN_WEIGHT from Factor_name Order By BIT_MASK";
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _weights.Add(myReader.GetDouble(0));
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }

            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format(@"{0:0.00} ", _fitness));
            foreach (var weight in Weights)
            {
                sb.Append(weight);
                sb.Append(" : ");
            }

            return sb.ToString();
        }
        

        public List<double> Weights
        {
            get
            {
                return _weights;
            }
        }

        public double Fitness 
        { 
            get
            {
                return _fitness;
            } 
        }



        internal double CalculateFitness(RaceCollection rc)
        {
            _partitions.Clear();

            foreach (var race in rc.Races)
            {
                race.UpdatePartitions(this);
            }

            return 0.0;
        }


        /*
        internal double CalculateFitness(RaceCollection rc)
        {
            _fitness = 0.0;

            foreach (var race in rc.Races)
            {
                _fitness += race.CalculateReturn(this);
                
            }

            _fitness = Math.Abs(_fitness);

            return _fitness;
        }
        */

        static internal int MutationRate
        {
            get
            {
                return _mutationRate;
            }
            set
            {
                _mutationRate = value;
            }
        }

        internal void Mutate()
        {
            for (int i = 0; i < _weights.Count; i++)
            {
                if (Randomizer.GetNextInteger(0, 100) < _mutationRate)
                {
                    _weights[i] = Randomizer.GetNextWeight();
                }
            }
        }

        internal void SaveToDb()
        {
            for (int i = 0; i < _weights.Count; i++)
            {
                string sql = SqlUpdateFactorWeight(i, _weights[i]);
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();                
            }            
        }

        internal string SqlUpdateFactorWeight(int index, double weight)
        {
            long flag = index == 0 ? 0 : PowerOf2(index);  
            return string.Format("UPDATE FACTOR_NAME SET MAIDEN_WEIGHT = {0} WHERE BIT_MASK = {1}",weight, flag);
        }

        private static long PowerOf2(int index)
        {
            long i = 1;
            for (int j = 0; j < index; j++)
            {
                i *= (long) 2;
            }
            return i;
        }
    }
}
