using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.Parsing;
using System.Diagnostics;
using System.Data;


namespace Hogar.BrisPastPerformances
{

    public class Workout
    {
        string _date ; // YYYYMMDD
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
                if ( _rankOfWorkout.Length > 0 && _numberOfWorkoutsThatDayOnDistance.Length >0)
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

        static public Workout Make(Tokenizer tokenizer, int index)
        {
            var w = new Workout();
            w._date = tokenizer[FieldIndex.DATE + index].Trim();
            w._time = tokenizer[FieldIndex.TIME + index].Trim();
            w._track = tokenizer[FieldIndex.TRACK + index].Trim();
            w._distance = tokenizer[FieldIndex.DISTANCE + index].Trim();
            w._trackCondition = tokenizer[FieldIndex.TRACK_CONDITION + index].Trim();
            w._description = tokenizer[FieldIndex.DESCRIPTION + index].Trim();
            w._mainOrInnerTrackIndicator = tokenizer[FieldIndex.TRACK_INDICATOR + index].Trim();
            w._numberOfWorkoutsThatDayOnDistance = tokenizer[FieldIndex.NUMBER_OF_WORKOUTS + index].Trim();
            w._rankOfWorkout = tokenizer[FieldIndex.RANK + index].Trim();
            return (w._date.Length > 0 && w._distance.Length > 0) ? w : null;


        }

        static public Workout Make(ParsableText parsableText, int index)
        {
            var w = new Workout();

            w._date = parsableText.Tokens[FieldIndex.DATE + index].ToString().Trim();
            w._time = parsableText.Tokens[FieldIndex.TIME + index].ToString().Trim();
            w._track = parsableText.Tokens[FieldIndex.TRACK + index].ToString().Trim();
            w._distance = parsableText.Tokens[FieldIndex.DISTANCE + index].ToString().Trim();
            w._trackCondition = parsableText.Tokens[FieldIndex.TRACK_CONDITION + index].ToString().Trim();
            w._description = parsableText.Tokens[FieldIndex.DESCRIPTION + index].ToString().Trim();
            w._mainOrInnerTrackIndicator = parsableText.Tokens[FieldIndex.TRACK_INDICATOR + index].ToString().Trim();
            w._numberOfWorkoutsThatDayOnDistance = parsableText.Tokens[FieldIndex.NUMBER_OF_WORKOUTS + index].ToString().Trim();
            w._rankOfWorkout = parsableText.Tokens[FieldIndex.RANK + index].ToString().Trim();


            return (w._date.Length > 0 && w._distance.Length > 0) ? w : null;


        }
    }

    public class BrisWorkouts
    {
        readonly ParsableText _parsableText;
        private readonly Tokenizer _tokenizer;

        List<Workout> _workout = new List<Workout>();

        

        static int MAX_WORKOUTS = 12;

        public BrisWorkouts(ParsableText parsableText)
        {
            _parsableText = parsableText;

            PopulateWorkouts();
        }

        public BrisWorkouts(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;

            PopulateWorkouts();
        }

        private void PopulateWorkouts()
        {
           
            _workout.Clear();

            for(int index = 0; index < MAX_WORKOUTS; ++index)
            {

                if(null != _parsableText)
                {
                    Workout w = Workout.Make(_parsableText, index);

                    if (null != w)
                    {
                        _workout.Add(w);
                    }    
                }
                else
                {
                    Workout w = Workout.Make(_tokenizer, index);

                    if (null != w)
                    {
                        _workout.Add(w);
                    }
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
