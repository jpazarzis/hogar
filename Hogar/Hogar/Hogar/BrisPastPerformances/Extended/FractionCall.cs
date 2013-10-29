using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Hogar.Parsing;

namespace Hogar.BrisPastPerformances.Extended
{
    public class FractionCall
    {
        readonly int _position;
        readonly double _leadersTime;
        readonly double _lengthsBehindTheLeader;
        readonly bool _noDataAvailable;
        readonly double _distanceInYards;

        public enum Level
        {
            First,
            Second,
            Stretch,
            Final
        };

        private static string GetValueFromToken(DataRow dr, int index)
        {
            string strg = Utilities.GetFieldAsString(dr, index);

            // April 26 2009 Change the previous commented chunk of code with the following
            // which considers all the characters instead of the first one)

            if (strg.Length <= 0)
            {
                return "0";
            }

            foreach (char c in strg)
            {
                if (c == '.')
                {
                    continue;
                }

                if (c < '0' || c > '9')
                {
                    return "0";
                }
            }
            return strg;
        }

        public static bool NoDataAvailable(DataRow dr, int index)
        {
            string strg = Utilities.GetFieldAsString(dr, index);
            if ((strg.Length <= 0) || (strg[0] >= 'A' && strg[0] <= 'Z'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static FractionCall Make(DataRow dr, double distance, int positionIndex, int timeIndex, int lengthsIndex)
        {
            try
            {
                double time, lengths;
                int position;
                bool noDataAvailable;

                
                time = Convert.ToDouble(GetValueFromToken(dr, timeIndex).Trim());
                position = Convert.ToInt32(GetValueFromToken(dr, positionIndex).Trim());


                if (position > 0)
                {
                    lengths = Convert.ToDouble(GetValueFromToken(dr, lengthsIndex).Trim());
                    noDataAvailable = NoDataAvailable(dr, positionIndex);
                }
                else
                {
                    lengths = 0;
                    noDataAvailable = true;
                }
                return new FractionCall(distance, position, time, lengths, noDataAvailable);
            }
            catch
            {
                return new FractionCall(0, 0, 0, 0, true);
            }
        }


        private FractionCall(double distanceInYards, int position, double time, double lengths, bool noDataAvailable)
        {

            if (position == 0 && lengths == 0)
            {
                _position = 0;
                _lengthsBehindTheLeader = 0;
                _leadersTime = 0.0;
                _noDataAvailable = noDataAvailable;
                _distanceInYards = 0;
            }
            else
            {
                _position = position;
                _lengthsBehindTheLeader = (1 == _position) ? 0 : lengths;
                _leadersTime = time;
                _noDataAvailable = noDataAvailable;
                _distanceInYards = distanceInYards;
            }
        }

        public string TooltipText
        {
            get
            {

                return "position: " + _position.ToString() + " leader's time: " + Utilities.ConvertTimeToMMSSHundreds(_leadersTime) + " lengths behind : " + _lengthsBehindTheLeader.ToString();
            }
        }

        public double Time
        {
            get
            {
                double t1 = Utilities.CalculateTimeBasedInBeatenLengths(_leadersTime, _distanceInYards, _lengthsBehindTheLeader);
                //double t2 = _leadersTime + _lengthsBehindTheLeader * 0.2;
                //return Utilities.CalculateTimeBasedInBeatenLengths(_leadersTime, _distanceInYards, _lengthsBehindTheLeader);
                return t1;
            }
        }

        public string FormatedTime
        {
            get
            {
                if (_noDataAvailable)
                {
                    return "-";
                }
                return Utilities.ConvertTimeToMMSSFifth(Time.ToString());
            }
        }


        public override string ToString()
        {
            return FormatedTime;
        }
    }
}
