using System.Collections.Generic;
using System.Linq;
using Hogar.Algorithms.ANN;

namespace Hogar.Algorithms.ANN.PatternStatistics
{
    public sealed class PatternStatisticCollection : List<PatternStatistic>
    {
        static private PatternStatisticCollection _singleton;

        static public PatternStatisticCollection Singeton
        {
            get
            {
                if(null == _singleton)
                {
                    _singleton = new PatternStatisticCollection();
                }

                return _singleton;
            }
        }


        private PatternStatisticCollection()
        {
            Initialize();
        }

        public PatternStatistic GetPatternStatistic(int id)
        {
            foreach (var ps in this)
            {
                if(ps.ID == id)
                {
                    return ps;
                }
            }

            return null;
        }

        public PatternStatistic GetFromName(string name)
        {
            return this.Find(ps => ps.Name == name);
        }

        public void Initialize()
        {
            this.Clear();
            int id = 1;
            Add(new PatternStatistic(id++, "Better Than Last Three") { CheckPattern = BetterThanLastThree });
            Add(new PatternStatistic(id++, "Worse Than Last Three") { CheckPattern = WorseThanLastThree });
            Add(new PatternStatistic(id++, "Better Than Last Three By 10%") { CheckPattern = BetterThanLastThreeBy10Percent });
            Add(new PatternStatistic(id++, "Better Than All") { CheckPattern = BetterThanAll });
            Add(new PatternStatistic(id++, "Worse Than All") { CheckPattern = WorseThanAll });
            Add(new PatternStatistic(id++, "Better Than Average") { CheckPattern = BetterThanAverage });
            Add(new PatternStatistic(id++, "Better Than Average Of last Three") { CheckPattern = BetterThanAverageOfLastThree });
       
            this.ForEach(ps => ps.Initialize());
        }


        public void Process(List<Pattern> patterns)
        {
            this.ForEach(ps=>ps.Initialize());
            patterns.ForEach(pattern=>this.ForEach(ps=>ps.ProcessPattern(pattern)));
        }


    

        public bool BetterThanAverageOfLastThree(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();

            if (points.Count < 3)
                return false;

            var l = new List<double>();
            for (int i = points.Count - 1; i >= points.Count - 3; l.Add(points[i--]));

            double desired = pattern.DesiredValue;

            return desired > l.Average();
        }


        public bool BetterThanAverage(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();

            if (points.Count < 3)
                return false;

            double desired = pattern.DesiredValue;

            return desired > points.Average();
        }


        public bool WorseThanAll(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();
            
            if(points.Count < 3)
                return false;

            double desired = pattern.DesiredValue;

            return desired < points.Min();
        }

        public bool BetterThanAll(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();
            
            if(points.Count < 3)
                return false;

            double desired = pattern.DesiredValue;

            return desired > points.Max();
        }

        public bool BetterThanLastThreeBy10Percent(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();

            if (points.Count < 3)
                return false;

            double desired = pattern.DesiredValue - pattern.DesiredValue * 0.2;

            return desired > points[points.Count - 1] && desired > points[points.Count - 2] && desired > points[points.Count - 3];
        }

        
        public bool BetterThanLastThree(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();
            
            if(points.Count < 3)
                return false;

            double desired = pattern.DesiredValue;

            return desired > points[points.Count - 1] && desired > points[points.Count - 2] && desired > points[points.Count - 3];
        }

        public bool WorseThanLastThree(Pattern pattern)
        {
            var points = pattern.DataPoints.ToList();

            if (points.Count < 3)
                return false;

            double desired = pattern.DesiredValue;

            return desired < points[points.Count - 1] && desired < points[points.Count - 2] && desired < points[points.Count - 3];
        }
    }
}