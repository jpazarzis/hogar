using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Cynthia;
using Hogar.Willard;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace WillardsStudio
{
    public class HorseInfo
    {
        readonly int _id;
        readonly string _name;
        readonly string _programNumber;
        readonly double _weight;
        readonly double _firstCallLengthsBehind = 0.0;
        readonly double _secondCallLengthsBehind = 0.0;
        readonly double _finalCallLengthsBehind = 0.0;

        double _firstCallWSF = 0.0;
        double _secondCallWSF = 0.0;
        double _finalCallWSF = 0.0;

        public HorseInfo(int id, string name, string programNumber, double firstCallLengthsBehind, double secondCallLengthsBehind, double finalLengthsBehind, int weight)
        {
            _id = id;
            _name = name;
            _programNumber = programNumber;
            _weight = (double)weight;
            _firstCallLengthsBehind = firstCallLengthsBehind;
            _secondCallLengthsBehind = secondCallLengthsBehind;
            _finalCallLengthsBehind = finalLengthsBehind;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string ProgramNumber
        {
            get
            {
                return _programNumber;
            }
        }

        public void SaveToDb()
        {
            string sql = string.Format("INSERT INTO WSF (HORSE_ID, FirstCallWSF, SecondCallWSF, FinalCallWSF) VALUES ({0}, {1}, {2}, {3})", _id, _firstCallWSF, _secondCallWSF, _firstCallWSF);
            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public void CalculateWSF(RaceInfo ri)
        {
            CynthiaPar cp = CynthiaPar.Make(ri.TrackCode, ri.Year, ri.Month, ri.Day, ri.RaceNumber);
            _firstCallWSF = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.First, _weight,_firstCallLengthsBehind);
            _secondCallWSF = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.Second, _weight,_secondCallLengthsBehind);
            _finalCallWSF = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.Final, _weight,_finalCallLengthsBehind);
        }

        public double FirstCallWSF
        {
            get
            {
                return _firstCallWSF;
            }
        }

        public double SecondCallWSF
        {
            get
            {
                return _secondCallWSF;
            }
        }

        public double FinalCallWSF
        {
            get
            {
                return _finalCallWSF;
            }
        }
    }
}
