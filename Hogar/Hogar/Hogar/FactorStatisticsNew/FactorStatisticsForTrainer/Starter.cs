using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;

namespace Hogar.FactorStatisticsNew.FactorStatisticsForTrainer
{
    internal class Starter : IDbPopulatable
    {
        public long FactorsFlag { get; set; }
        public double WinPayoff { get; set; }
        public int FieldSize { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }

        public void Populate(DbReader dbr)
        {
            FactorsFlag = dbr.GetValue<long>("FACTORS_FLAG");
            WinPayoff = dbr.GetValue<double>("WIN_PAYOFF");
            FieldSize = dbr.GetValue<int>("FIELD_SIZE");
            Trainer = dbr.GetValue<string>("ABBR_TRAINER_NAME");
            Jockey = dbr.GetValue<string>("ABBR_JOCKEY_NAME");
        }
    }
}
