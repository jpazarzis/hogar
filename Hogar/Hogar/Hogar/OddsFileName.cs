using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar
{
    public class OddsFilename
    {
        readonly string _fullPath;
        readonly string _filename;
        readonly string _trackFullName;
        readonly string _year;
        readonly string _month;
        readonly string _day;
        readonly string _trackBrisAbrv;

        readonly int _yearAsInt;
        readonly int _monthAsInt;
        readonly int _dayAsInt;

        public OddsFilename(string fn)
        {
            _fullPath = fn;
            _filename = System.IO.Path.GetFileName(_fullPath);

            if (_filename.Length == 12)
            {
                _trackBrisAbrv = _filename.Substring(0, 3);
                string month = _filename.Substring(3, 2);
                string day = _filename.Substring(5, 2);

                _monthAsInt = Convert.ToInt32(month);
                _dayAsInt = Convert.ToInt32(day);

                month = Utilities.GetMonthFullName(Convert.ToInt32(month.Trim()));
                _trackFullName = string.Format("{0,-15}", RaceTracks.GetNameFromBrisAbrv(_trackBrisAbrv));
                _month = string.Format("{0,-10}", month);
                _day = day;
                _year = "2009";
                _yearAsInt = 2009;
            }
            else if (_filename.Length == 16)
            {
                _trackBrisAbrv = _filename.Substring(0, 3);
                string month = _filename.Substring(7, 2);
                string day = _filename.Substring(9, 2);
                _monthAsInt = Convert.ToInt32(month);
                _dayAsInt = Convert.ToInt32(day);

                _year = _filename.Substring(3, 4);
                _yearAsInt = Convert.ToInt32(_year);
                month = Utilities.GetMonthFullName(Convert.ToInt32(month.Trim()));
                _trackFullName = string.Format("{0,-15}", RaceTracks.GetNameFromBrisAbrv(_trackBrisAbrv));
                _month = string.Format("{0,-10}", month);
                _day = day;
            }
        }


        public int Year
        {
            get
            {
                return _yearAsInt;
            }
        }

        public string TrackCode
        {
            get
            {
                return _trackBrisAbrv;
            }
        }

        public string Track
        {
            get
            {
                return _trackFullName;
            }
        }

        public bool IsTodaysCard
        {
            get
            {
                string todaysDate = string.Format("{0:0000}{1:00}{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                return todaysDate == DateAsYYYYMMDD;
            }
        }

        public bool IsFutureCard
        {
            get
            {
                string todaysDate = string.Format("{0:0000}{1:00}{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


                return Convert.ToInt32(todaysDate) <= Convert.ToInt32(DateAsYYYYMMDD);
            }
        }

        public string MonthFullName
        {
            get
            {
                return Utilities.GetMonthFullName(_monthAsInt);
            }
        }

        public string DateAsYYYYMMDD
        {
            get
            {
                return string.Format("{0:0000}{1:00}{2:00}", _yearAsInt, _monthAsInt, _dayAsInt);
            }
        }


        public override string ToString()
        {
            return string.Format("{0,-9} {1,-2}, {2}", _month.Trim(), _day.Trim(), _year);
        }

        public string FullPath
        {
            get
            {
                return _fullPath;
            }
        }
    }
}
