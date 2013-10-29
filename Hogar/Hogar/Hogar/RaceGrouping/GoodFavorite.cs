namespace Hogar.RaceGrouping
{
    public class GoodFavorite : TargetGroup
    {
        public GoodFavorite(RaceGroupType parent, ComparisonStyleType comparisonStyle)
            : base(parent, "Good Favorite", "GF", comparisonStyle)
        {
            
        }

    

        public override string GetSQLToLoadFromDB()
        {
            return string.Format("{0} {1} AND WAS_THE_FAVORITE = 1", _sqlBeginingOfSelect, Parent.WhereClause);
        }

        public override bool RefersToFavoriteOnly
        {
            get
            {
                return true;
            }
        }
    }
}