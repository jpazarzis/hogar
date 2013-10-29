using System;
using System.Collections.Generic;
using System.Data;
using Hogar.Parsing;
using System.Diagnostics;

namespace Hogar.BrisPastPerformances.Extended
{
    public class Workout
    {
        string _date; // YYYYMMDD
        string _time;
        string _track;
        string _distance;
        string _trackCondition;
        string _description;
        string _mainOrInnerTrackIndicator;
        string _numberOfWorkoutsThatDayOnDistance;
        string _rankOfWorkout;

        public string DateAsString
        {
            get
            {
                return MakeDate(_date);
            }
        }

        public DateTime Date
        {
            get
            {
                try
                {
                    string d = _date;
                    d = d.Trim();
                    int year = Convert.ToInt32(d.Substring(0, 4));
                    int month = Convert.ToInt32(d.Substring(4, 2));
                    int day = Convert.ToInt32(d.Substring(6, 2));

                    return new DateTime(year, month, day);
                }
                catch
                {
                    throw new Exception("Invalid date Format");
                }

            }
        }

        public bool IsBullet
        {
            get
            {
                if (_time.Length > 0)
                {
                    return _time[0] == '-';
                }
                else
                {
                    return false;
                }
            }
        }

        public string RaceTrack
        {
            get
            {
                return _track;
            }
        }

        public string Distance
        {
            get
            {

                _distance = _distance.Trim();

                if (_distance.Length <= 0)
                {
                    return "";
                }

                int yards = Convert.ToInt32(_distance);
                return Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards);

            }
        }

        public string TrackCondition
        {
            get
            {
                return _trackCondition;
            }
        }

        public string Time
        {
            get
            {
                string t = "";

                _time = _time.Trim();

                if (_time.Length > 0)
                {


                    double d = Convert.ToDouble(_time.Replace('-', ' '));
                    t = Utilities.ConvertTimeToMMSSHundreds(d);


                }

                return t + " " + _description;
            }
        }

        public bool IsBulletish
        {
            get
            {
                if (_rankOfWorkout.Length > 0 && _numberOfWorkoutsThatDayOnDistance.Length > 0)
                {
                    double r = Convert.ToDouble(_rankOfWorkout);
                    double n = Convert.ToDouble(_numberOfWorkoutsThatDayOnDistance);
                    if (n > 0)
                    {
                        return (r / n) < 0.12;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public string Rank
        {
            get
            {
                return _rankOfWorkout + "/" + _numberOfWorkoutsThatDayOnDistance;
            }
        }


        static private string MakeDate(string d)
        {

            d = d.Trim();

            if (d.Length <= 0)
            {
                return "";
            }

            int year = Convert.ToInt32(d.Substring(0, 4));
            int month = Convert.ToInt32(d.Substring(4, 2));
            int day = Convert.ToInt32(d.Substring(6, 2));

            return Utilities.GetMonthName(month) + " " + day.ToString();


        }

        struct FieldIndex
        {
            static public int DATE = 101;
            static public int TIME = 113;
            static public int TRACK = 125;
            static public int DISTANCE = 137;
            static public int TRACK_CONDITION = 149;
            static public int DESCRIPTION = 161;
            static public int TRACK_INDICATOR = 173;
            static public int NUMBER_OF_WORKOUTS = 185;
            static public int RANK = 197;
        }

        public override string ToString()
        {
            try
            {
                string s = MakeDate(_date);

                s += " " + _track;


                int yards = Convert.ToInt32(_distance);
                s += " " + Utilities.ConvertYardsToMilesOrFurlongsAbreviation(yards);
                s += " " + _trackCondition;
                s += " " + _time;
                s += " " + _description;

                //s += _mainOrInnerTrackIndicator;
                s += " " + _rankOfWorkout;

                s += "/" + _numberOfWorkoutsThatDayOnDistance;

                return s;
            }
            catch
            {
                return "Invalid Workout";
            }
        }

        static public Workout Make(DataRow dr, int index)
        {
            var w = new Workout();


            w._date = Utilities.GetFieldAsString(dr, FieldIndex.DATE + index);
            w._time = Utilities.GetFieldAsString(dr, FieldIndex.TIME + index);
            w._track = Utilities.GetFieldAsString(dr, FieldIndex.TRACK + index);
            w._distance = Utilities.GetFieldAsString(dr, FieldIndex.DISTANCE + index);
            w._trackCondition = Utilities.GetFieldAsString(dr, FieldIndex.TRACK_CONDITION + index);
            w._description = Utilities.GetFieldAsString(dr, FieldIndex.DESCRIPTION + index);
            w._mainOrInnerTrackIndicator = Utilities.GetFieldAsString(dr, FieldIndex.TRACK_INDICATOR + index);
            w._numberOfWorkoutsThatDayOnDistance = Utilities.GetFieldAsString(dr, FieldIndex.NUMBER_OF_WORKOUTS + index);
            w._rankOfWorkout = Utilities.GetFieldAsString(dr, FieldIndex.RANK + index);


            return (w._date.Length > 0 && w._distance.Length > 0) ? w : null;


        }
    }

    public class BrisWorkouts
    {
        readonly DataRow _dr;
        List<Workout> _workout = new List<Workout>();
        static int MAX_WORKOUTS = 12;

        public BrisWorkouts(DataRow dr)
        {
            _dr = dr;
            PopulateWorkouts();
        }

        private void PopulateWorkouts()
        {
            Debug.Assert(null != _dr);

            _workout.Clear();

            for (int index = 0; index < MAX_WORKOUTS; ++index)
            {
                Workout w = Workout.Make(_dr, index);

                if (null != w)
                {
                    _workout.Add(w);
                }
            }
        }

        public List<Workout> GetWorkouts()
        {
            return _workout;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Workout w in _workout)
            {
                s += w.ToString() + " ";
            }
            return s;
        }

    }

}
