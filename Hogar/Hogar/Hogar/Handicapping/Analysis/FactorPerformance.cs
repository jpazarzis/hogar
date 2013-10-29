using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;
using System.Runtime.Serialization;


namespace Hogar.Handicapping.Analysis
{
    [Serializable]
    public class FactorPerformance:  ISerializable
    {
     
        static Dictionary<string, FactorPerformance> _fp = new Dictionary<string, FactorPerformance>();

        readonly string _trackCode;
        readonly List<string> _factorName = null;
        readonly int _countAllMatches;
        readonly int _countWinners;
        readonly double _ROI;
        readonly double _IV;
        readonly double _EIX;
        readonly string _factorNamesAsString;

        static object _locker = new object();

        public FactorPerformance(SerializationInfo info, StreamingContext ctxt)
        {
            _trackCode = (string)Utilities.GetSerializedObject(info, "_trackCode", typeof(string), "");
            _factorName = (List<string>)Utilities.GetSerializedObject(info, "_factorName", typeof(List<string>), null);
            _countAllMatches = (int)Utilities.GetSerializedObject(info, "_countAllMatches", typeof(int), 0);
            _countWinners = (int)Utilities.GetSerializedObject(info, "_countWinners", typeof(int), 0);
            _ROI = (double)Utilities.GetSerializedObject(info, "_ROI", typeof(double), 0.0);
            _IV = (double)Utilities.GetSerializedObject(info, "_IV", typeof(double), 0.0);
            _EIX = (double)Utilities.GetSerializedObject(info, "_EIX", typeof(double), 0.0);
            _factorNamesAsString = (string)Utilities.GetSerializedObject(info, "_factorNamesAsString", typeof(string), "");          
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_trackCode", _trackCode);
            info.AddValue("_factorName", _factorName);
            info.AddValue("_countAllMatches", _countAllMatches);
            info.AddValue("_countWinners", _countWinners);
            info.AddValue("_ROI", _ROI);
            info.AddValue("_IV", _IV);
            info.AddValue("_EIX", _EIX);
            info.AddValue("_factorNamesAsString", _factorNamesAsString);    
        }

        static internal void Reset()
        {
            lock (_locker)
            {
                _fp.Clear();
                DailyCard.ResetCache();
            }
        }

        static public FactorPerformance GetFactorPerformance(long mask, long raceAttributes, string trackCode)
        {
            lock (_locker)
            {
                string key = MakeKey(mask, raceAttributes, trackCode);
                if (!_fp.ContainsKey(key))
                {
                    Load(mask, raceAttributes, trackCode);
                }
                return _fp[key];
            }
        }

        private FactorPerformance(string trackCode, List<string> factorName, int allMatches, int winners, double roi, double iv, double eix)
        {
            _trackCode=trackCode;
            _factorName = factorName;
            _countAllMatches=allMatches;
            _countWinners=winners;
            _ROI=roi;
            _IV=iv;
            _EIX=eix;

            _factorNamesAsString = "";
            foreach (string s in factorName)
            {
                _factorNamesAsString += s;
                _factorNamesAsString += Environment.NewLine;
            }
        }

        private static void Load(long mask, long raceAttributes, string trackCode)
        {
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("EXEC FactorPerformance {0} , '{1}' , {2} ", mask, trackCode, raceAttributes);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                long bitMask = 0;
                int allMatches = 0;
                int winners = 0;
                double roi = 0.0;
                double iv = 0.0;
                double eix = 00;
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        bitMask = (long)myReader["BIT_MASK"];
                        allMatches = (int)myReader["COUNT"];
                        winners = (int)myReader["WINNERS_COUNT"];
                        roi = (double)myReader["ROI"];
                        iv = (double)myReader["IMPACT_VALUE"];
                        eix = (double)myReader["EIX"];
                    }
                }
                myReader.Close();
                List<string> factorName = Factor.GetFactorNames(bitMask);
                _fp.Add(MakeKey(mask, raceAttributes, trackCode), new FactorPerformance(trackCode, factorName, allMatches, winners, roi, iv, eix));
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }


        private static string MakeKey(long mask, long raceAttributes, string trackCode)
        {
            return mask.ToString() + raceAttributes.ToString()+ trackCode;
        }

        public override string ToString()
        {
            return _factorName.Count.ToString();
        }

        public List<string> FactorNames
        {
            get
            {
                return _factorName;
            }
        }

        public string FactorNamesAsString
        {
            get
            {
                return _factorNamesAsString;
            }
        }

        public string TrackCode
        {
            get
            {
                return _trackCode;
            }
        }

        public int Matches
        {
            get
            {
                return _countAllMatches;
            }
        }

        public int Winners
        {
            get
            {
                return _countWinners;
            }
        }

        public double ROI
        {
            get
            {
                return _ROI;
            }
        }

        public double IV
        {
            get
            {
                return _IV;
            }
        }

        public double EIX
        {
            get
            {
                return _EIX;
            }
        }
    }
}
