using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.RaceChart
{
    public class RaceChartLine
    {
        readonly string _horseName;
        readonly string _jockey;
        

        internal RaceChartLine(string horseName, string jockey)
        {
            _horseName = horseName;
            _jockey = jockey;
        }

        public string HorseName
        {
            get
            {
                return _horseName;
            }
        }
    }
}
