using Hogar.Algorithms.ANN;

namespace Hogar.Algorithms.ANN.PatternStatistics
{
    public class PatternStatistic
    {
        public delegate bool CheckPatternDelegate(Pattern pattern);
        
        public PatternStatistic(int id, string name)
        {
            ID = id;
            Name = name;
            Initialize();
        }

        public int ID { get; private set; }

        public string Name { get; private set; }
        
        public int SampleSize { get; private set;}

        public int Matches { get; private set; }

        public CheckPatternDelegate CheckPattern;

        public override string ToString()
        {
            return Name;
        }
        
        public double MatchingPercentage
        {
            get
            {
                return ((double) Matches / SampleSize) * 100.0;
            }
        }

        public void Initialize()
        {
            SampleSize = 0;
            Matches = 0;
        }

         public void ProcessPattern(Pattern pattern)
         {
             ++SampleSize;

             if(null != CheckPattern && CheckPattern(pattern))
             {
                 ++Matches;
             }
         }

    }

    
}