namespace Hogar.RaceGrouping
{
    public class GoodBetBasedInOdds : TargetGroup
    {
        private readonly double _minOdds;
        private readonly double _maxOdds;

        public GoodBetBasedInOdds(RaceGroupType parent, int minOdds, int maxOdds, ComparisonStyleType comparisonStyle)
            : base(parent, MakeDescription(minOdds, maxOdds), MakeAbreviation(minOdds, maxOdds), comparisonStyle)
        {
            _minOdds = (double) minOdds;
            _maxOdds = (double) maxOdds;
        }

        static string MakeDescription(int minOdds, int maxOdds)
        {
            return string.Format("Odds From {0} to {1}", minOdds, maxOdds);
        }

        static string MakeAbreviation(int minOdds, int maxOdds)
        {
            return string.Format("GB{0}TO{1}", minOdds, maxOdds);
        }

        public double MinOdds
        {
            get
            {
                return _minOdds;
            }
        }

        public double MaxOdds
        {
            get
            {
                return _maxOdds;
            }
        }

        public double AverageOdds
        {
            get
            {
                return (_maxOdds + _minOdds)/ 2.0;
            }
        }

        public override string GetSQLToLoadFromDB()
        {
            return string.Format("{0} {1} AND ODDS >= {2} AND ODDS < {3} ORDER BY RACE_ID", _sqlBeginingOfSelect, Parent.WhereClause, _minOdds,_maxOdds);
        }

        public override bool RefersToFavoriteOnly
        {
            get
            {
                return false;
            }
        }
    }
}