using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Filter
{
    public sealed class FilterCollection : List<Filter>
    {

        static public FilterCollection MakeNew()
        {
            return new FilterCollection();
        }

        private FilterCollection()
        {
            this.Add(new LongLayoffFilter());
            this.Add(new TurfFilter());
            this.Add(new MuddyTrackFilter());
            this.Add(new FirstTimeOutFilter());
            this.Add(new LastYearWinningsFilter());
            this.Add(new EliminateBasedInBrisFigureDistribution());
            
        }
    }
}
