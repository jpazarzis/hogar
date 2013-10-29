using System;

namespace Hogar.RaceGrouping
{
    public class BadFavorite : TargetGroup
    {
        public BadFavorite(RaceGroupType parent, ComparisonStyleType comparisonStyle)
            : base(parent, "Bad Favorite", "BF", comparisonStyle)
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