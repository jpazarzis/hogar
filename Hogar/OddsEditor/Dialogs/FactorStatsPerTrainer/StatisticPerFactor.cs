using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    class StatisticPerFactor
    {
        public long Flag { get; private set;}
        public int Starters { get; set; }
        public int Winners { get; set; }
        public string Name { get; private set; }
        private int FieldSize { get; set; }
        private double TotalAmountWon { get; set; }
        public double WinPercentage
        {
            get
            {
                return Starters > 0 ? ((Winners * 1.0) / Starters) * 100.0 : 0;
            }
        }

        public double IV
        {
            get
            {
                if (Starters == 0 || FieldSize == 0)
                {
                    return 0.0;
                }

                return ((Winners * 1.0) / Starters) / ((Starters * 1.0) / FieldSize);

            }
        }

        public double ROI
        {
            get
            {
                if (Starters <= 0)
                    return 0.0;

                return (TotalAmountWon * (1.0))/Starters;
            }
        }

        static Dictionary<long , StatisticPerFactor> _stats = new Dictionary<long, StatisticPerFactor>();

        static public List<StatisticPerFactor> ToList()
        {
            return _stats.Keys.Select(key => _stats[key]).ToList();
        }


        static public void Update(IEnumerable<Starter> sc)
        {
            Initialize();

            foreach (var starter in sc)
            {
                foreach (var key in _stats.Keys)
                {
                    var sf = _stats[key];

                    if ((sf.Flag & starter.FactorsFlag) == sf.Flag)
                    {
                        sf.Starters = sf.Starters + 1;
                        if (starter.FinishPosition == 1)
                        {
                            sf.Winners = sf.Winners + 1;
                            sf.TotalAmountWon = sf.TotalAmountWon + (starter.Odds + 1);
                        }
                        sf.FieldSize = starter.FieldSize + sf.FieldSize;
                    }
                }
            }
        }

        static void LoadStats()
        {
            _stats.Clear();

            SqlDataReader myReader = null;
            try
            {
                string sql = "select bit_mask, factor_name from factor_name";
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        long flag = myReader.GetInt64(0);
                        string name = myReader.GetString(1);

                        _stats.Add(flag, new StatisticPerFactor(flag, name));

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

        static void Initialize()
        {
            if(_stats.Count <= 0)
            {
                LoadStats();
            }

            foreach (var key in _stats.Keys)
            {
                _stats[key].Winners = 0;
                _stats[key].Starters = 0;
                _stats[key].FieldSize = 0;
                _stats[key].TotalAmountWon = 0;
            }
            
        }

        static public StatisticPerFactor GetStatistic(long flag)
        {
            return _stats[flag];
        }


        


        private StatisticPerFactor(long flag, string name)
        {
            Flag = flag;
            Starters = 0;
            Winners = 0;
            Name = name.Trim();
            FieldSize = 0;
            TotalAmountWon = 0;
        }
    }
}