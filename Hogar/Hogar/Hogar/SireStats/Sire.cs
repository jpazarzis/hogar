using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hogar;
using System.Data;
using Hogar.DbTools;

namespace Hogar.SireStats
{

    public class SireInfo
    {
        public string Name { get; internal set; }
        public string FirstTime { get; internal set; }
        public string Mud { get; internal set; }
        public string Turf { get; internal set; }
        public string AllWeather { get; internal set; }
        public string AverageDistance { get; internal set; }
    }

    public class Sire
    {
        readonly string _name;
        readonly string _country;
        readonly int _yearOfBirth;
        readonly double _spi;
        readonly string _firstTimeStarters;
        readonly string _mudStarters;
        readonly string _turfStarters;
        readonly string _allweatherStarters;
        readonly string _averageWinningDistance;
        readonly string _distance;
        readonly string _state;


        static public Sire CreateSireFromDb(string name)
        {
            Sire s= null;
            string sql = string.Format("select STATE, NAME, COUNTRY, YEAR_OF_BIRTH, SPI, DISTANCE,   FIRST_TIME_STARTERS, MUD_STARTERS, TURF_STARTERS, ALL_WEATHER_STARTERS, AVG_WINNING_DISTANCE from sire_stats where name='{0}'", name);
            using (var dbr = new DbReader())
            {
                if (dbr.Open(string.Format(sql)))
                {
                    while (dbr.MoveToNextRow())
                    {
                        s = new Sire(dbr);
                    }
                }
            }
            return s;
   
        }

        public string  Name { get {return _name;} }
        public string Country { get {return _country;}}
        public int YearOfBirth { get {return _yearOfBirth;}}
        public double SPI { get { return _spi; } }
        public string FirstTimeStarters { get { return _firstTimeStarters; } }
        public string MudStarters { get { return _mudStarters; } }
        public string TurfStarters { get { return _turfStarters; } }
        public string AllweatherStarters { get { return _allweatherStarters; } }
        public string AverageWinningDistance { get { return _averageWinningDistance; } }
        public string Distance { get { return _distance; } }
        public string State { get { return _state; } }


        static public void GetSireStats(Horse horse, out SireInfo sire, out SireInfo damSire)
        {
            sire = null;
            damSire = null;

            foreach (DataRow dr in GetSiresInfo(horse.CorrespondingBrisHorse.Sire, horse.CorrespondingBrisHorse.DamSire).Rows)
            {
                var s = new SireInfo
                            {
                                Name = dr["Name"].ToString(), 
                                FirstTime = dr["FTS"].ToString(), 
                                Mud = dr["MUD"].ToString(), 
                                Turf = dr["TURF"].ToString(), 
                                AllWeather = dr["AWS"].ToString(), 
                                AverageDistance = dr["DIST"].ToString()
                            };

                if( dr["S/DS"].ToString().Contains("S"))
                {
                    sire = s;
                }
                else
                {
                    damSire = s;
                }
            }
        }

        static public DataTable GetSireInfo(string sireName)
        {
            sireName = ModifyNameForDbUse(sireName);
            string sql = string.Format("SELECT * FROM SIRE_STATS WHERE NAME = '{0}'", sireName);
            var dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        static public DataTable GetSiresInfo(string sireName1, string sireName2)
        {
            sireName1 = ModifyNameForDbUse(sireName1);
            sireName2 = ModifyNameForDbUse(sireName2);
            string sql = string.Format("EXEC  SelectSireStats '{0}', '{1}'", sireName1, sireName2);
            var dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        private Sire(DbReader dbr)
        {
            _name = dbr.GetValue<string>("NAME");
            _country = dbr.GetValue<string>("COUNTRY");
            _yearOfBirth = dbr.GetValue<int>("YEAR_OF_BIRTH");
            _spi = dbr.GetValue<double>("SPI");
            _firstTimeStarters = dbr.GetValue<string>("FIRST_TIME_STARTERS");
            _mudStarters  = dbr.GetValue<string>("MUD_STARTERS");
            _turfStarters = dbr.GetValue<string>("TURF_STARTERS");
            _allweatherStarters  = dbr.GetValue<string>("ALL_WEATHER_STARTERS");
            _averageWinningDistance = dbr.GetValue<string>("AVG_WINNING_DISTANCE");
            _distance = dbr.GetValue<string>("DISTANCE");
            _state = dbr.GetValue<string>("STATE");            
        }


        private Sire(string name, string country, int yearOfBirth, string spi, string fts, string ms, string ts, string aws,string awd, string dist,string state)
        {
            _name = name;
            _country = NormalizeString(country);
            _yearOfBirth = yearOfBirth;
            _spi = 0.0;
            if (spi.Trim().Length > 0)
            {
                _spi = Convert.ToDouble(spi.Trim());
            }
            _firstTimeStarters = NormalizeString(fts);
            _mudStarters = NormalizeString(ms);
            _turfStarters = NormalizeString(ts);
            _allweatherStarters = NormalizeString(aws);
            _averageWinningDistance = NormalizeString(awd);
            _distance = NormalizeString(dist);
            _state = NormalizeString(state);
        }


        

        private string NormalizeString(string s)
        {
            if (s.Trim().Length == 0)
            {
                return "-";
            }
            else
            {
                return s;
            }
        }

        public override string ToString()
        {
            return _name;
        }

        static private string ModifyNameForDbUse(string name)
        {
            name = name.Trim();
            if (name.Contains("'"))
            {
                name = name.Replace("'", "'' ");
            }
            if (name.Contains("`"))
            {
                name = name.Replace("`", "'' ");
            }
            // Do this for names like A.P. Indy for example...
            name = name.Replace(".", ". ");
            name = RemoveConsecutiveSpaces(name);
            return name;
         
        }

        private void UpdateDb()
        {
            string sql = string.Format(@"InsertSireStats '{0}', '{1}', {2} , {3}, '{4}', '{5}','{6}', '{7}','{8}', '{9}','{10}'",
                                        ModifyNameForDbUse(_name),
                                        _country,
                                        _yearOfBirth,
                                        _spi,
                                        _firstTimeStarters,
                                        _mudStarters,
                                        _turfStarters,
                                        _allweatherStarters,
                                        _averageWinningDistance,
                                        _distance,
                                        _state);


            Console.WriteLine(sql);
            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }


        static private Sire Make(string name, string[] otherData)
        {
            if (otherData.Length < 8)
            {
                return null;
            }
            
            string country = "";
            int yearOfBirth = 0;
            string spi = "";
            string fts = "";
            string ms = "";
            string ts = "";
            string aws = "";
            string awd = "";
            string dist = "";
            string state = "";

            if (name.Contains('('))
            {
                int p1 = name.IndexOf('(');
                int p2 = name.IndexOf(')');
                country = name.Substring(p1+1, p2 - p1-1);
                name = name.Substring(0, p1 - 1);
            }

            int index = 0;
            if (otherData.Length == 9)
            {
                yearOfBirth = Convert.ToInt32(otherData[index++]);
            }


            spi = otherData[index++];
            fts = otherData[index++];
            ms = otherData[index++];
            ts = otherData[index++];
            aws = otherData[index++];
            awd = otherData[index++];
            dist = otherData[index++];
            state = otherData[index];
            return new Sire(name, country, yearOfBirth, spi, fts, ms, ts, aws, awd, dist, state);    
        }



        static private string RemoveConsecutiveSpaces(string s)
        {
            if (s.Contains("  ") == false)
            {
                return s;
            }
            else
            {
                s = s.Replace("  ", " ");
                return RemoveConsecutiveSpaces(s);
            }
        }

        static public void InsertSiresToDb(string filename)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                
                line = line.Trim();

                if (line.Length == 0 || line.Contains("TSN"))
                {
                    continue;
                }

                line = line.Replace('~', ' ');
                line = RemoveConsecutiveSpaces(line);
                string[] s = line.Split(',');

                if (s.Length <= 1)
                {
                    continue;
                }

                string name = s[0];
                string otherData = s[1].Trim();
                s = otherData.Split(' ');
                if (s.Length == 9 || s.Length == 8)
                {
                    ++count;
                    Sire sire = Make(name, s);
                    sire.UpdateDb();
                    Console.WriteLine("{0}", sire.ToString());
                }
            }
            sr.Close();

            System.Console.WriteLine("Number of sires: {0}", count);
        }
    }
}
