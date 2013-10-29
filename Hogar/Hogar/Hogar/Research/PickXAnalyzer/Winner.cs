using Hogar.DbTools;

namespace Hogar.Research.PickXAnalyzer
{
    class Winner : IDbPopulatable 
    {
        public double Odds { get; set; }

        public int FieldSize { get; set; }

        public int ValueIndex
        {
            get
            {
                if (Odds <= 2.0)
                    return 1;
                else if (Odds <= 3.5)
                    return 2;
                else if (Odds <= 6.0)
                    return 3;
                else if (Odds <= 10.0)
                    return 4;
                else
                    return 5;
            }
        }

        public void Populate(DbReader dbr)
        {
            Odds = dbr.GetValue<double>("odds");
            FieldSize = dbr.GetValue<int>("field_size");
        }
    
    }
}