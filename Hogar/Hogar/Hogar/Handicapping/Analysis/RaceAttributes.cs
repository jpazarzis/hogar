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
    public class RaceAttributes
    {
        readonly long _flag;
        readonly string _desc;
        bool _isChecked = false;

        static List<RaceAttributes> _raceAttributes;

        public static List<RaceAttributes> Collection
        {
            get
            {
                return _raceAttributes;
            }
        }

        public static RaceAttributes MakeNew(RaceAttributes other)
        {
            return new RaceAttributes(other._flag, other._desc, false);
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
            }
        }

        public override string ToString()
        {
            return _desc;
        }

        public long Flag
        {
            get
            {
                return _flag;
            }
        }

        public string Description
        {
            get
            {
                return _desc;
            }
        }

        private RaceAttributes(long flag, string desc, bool isChecked)
        {
            _flag = flag;
            _desc = desc;
            _isChecked = isChecked;
        }

        public RaceAttributes(SerializationInfo info, StreamingContext ctxt)
        {
            _flag = (long)Utilities.GetSerializedObject(info, "_flag", typeof(long), 0);
            _desc = (string)Utilities.GetSerializedObject(info, "_desc", typeof(string), "");
            _isChecked= (bool)Utilities.GetSerializedObject(info, "_isChecked", typeof(bool), "");
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_flag", _flag);
            info.AddValue("_desc", _desc);
            info.AddValue("_isChecked", _isChecked);
        }

        static RaceAttributes()
        {
            _raceAttributes = new List<RaceAttributes>();
            SqlDataReader myReader = null;
            try
            {
                string sql = "SELECT FLAG, DESCRIPTION FROM RACE_ATTRIBUTES";
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        long flag = (long)myReader["FLAG"];
                        string desc = myReader["DESCRIPTION"].ToString().Trim();
                        _raceAttributes.Add(new RaceAttributes(flag,desc,false));
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }


    }
}
