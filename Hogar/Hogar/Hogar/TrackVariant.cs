using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;

namespace Hogar
{
    public class TrackVariant
    {
        static private TrackVariant _singleton = new TrackVariant();

        readonly SortedDictionary<string, double> _variantMap = new SortedDictionary<string, double>();

        static public TrackVariant Singleton
        {
            get
            {
                return _singleton;
            }
        }

        private TrackVariant()
        {
            Initialize();
        }

        public double GetVariant(string trackCode, DateTime date)
        {
            return GetVariant(trackCode, string.Format("{0}{1:00}{2:00}", date.Year, date.Month, date.Day));
        }

        public double GetVariant(string trackCode, string date)
        {
            
            string key = MakeKey(trackCode, date);
            return _variantMap.ContainsKey(key) ? _variantMap[key] : 999;
        }

        void Initialize()
        {
            _variantMap.Clear();
            using (var dbr = new DbReader())
            {
                string sql = @"SELECT TRACK_CODE, RACING_DATE,  TRACK_VARIANT_ESTIMATE,  TRACK_VARIANT , NUMBER_OF_STARTERS_FOR_TV FROM TV_TRACK_VARIANT ";
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        string trackCode = dbr.GetValue<string>("TRACK_CODE");
                        string date = dbr.GetValue<string>("RACING_DATE");
                        double tv1 = dbr.GetValue<double>("TRACK_VARIANT_ESTIMATE");
                        double tv2 = dbr.GetValue<double>("TRACK_VARIANT");
                        int count = dbr.GetValue<int>("NUMBER_OF_STARTERS_FOR_TV");
       
                        _variantMap.Add(MakeKey(trackCode,date),count > 0 ? tv2 : tv1);
                    }
                }
            }
        }

        private string MakeKey(string trackCode, string date)
        {
            return string.Format("{0}{1}", trackCode.ToUpper(), date);
        }
    }
}
