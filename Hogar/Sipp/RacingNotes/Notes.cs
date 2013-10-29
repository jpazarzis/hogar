using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sipp.RacingNotes
{
    public abstract class Note
    {
        public int Id { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public string CreatedByUser { get; internal set; }
        public string TrackCode { get; set; }
        public DateTime RacingDate { get; set; }
        public string Body { get; set; }
        protected abstract string SqlInsert { get; }
        internal void InsertToDb()
        {
            SippDbReader.ExecuteNonQuery(SqlInsert);
        }
    }

    public class WholeDayNote : Note
    {
        protected override string SqlInsert
        {
            get { return string.Format("Insert into racing_notes "); }
        }
    }

    public class RaceSpecificNote : Note
    {
        public int RaceNumber { get; set; }

        protected override string SqlInsert
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class HorseSpecificNote : Note
    {
        public int RaceNumber { get; set; }
        public string HorseName { get; set; }

        protected override string SqlInsert
        {
            get { throw new NotImplementedException(); }
        }
    }


    public static class Notes
    {
        static readonly List<Note> _notes = new List<Note>();
        private static bool _needsToBeLoaded = true;


        static void LoadFromDb()
        {
            _needsToBeLoaded = false;
        }

        static List<Note> GetNotes(string trackCode, DateTime date)
        {
            return GetNotes(n => n is WholeDayNote &&
                    n.TrackCode.ToUpper().Trim() == trackCode.ToUpper().Trim() && 
                    n.RacingDate == date);
        }

        static List<Note> GetNotes(string trackCode, DateTime date, int raceNumber)
        {
            return GetNotes(n => n is RaceSpecificNote &&
                    n.TrackCode.ToUpper().Trim() == trackCode.ToUpper().Trim() &&
                    n.RacingDate == date &&
                    ((RaceSpecificNote)n).RaceNumber == raceNumber);
        }

        static List<Note> GetNotes(string trackCode, DateTime date, int raceNumber, string horseName)
        {
            return GetNotes(n => n is HorseSpecificNote &&
                    n.TrackCode.ToUpper().Trim() == trackCode.ToUpper().Trim() &&
                    n.RacingDate == date &&
                    ((HorseSpecificNote)n).RaceNumber == raceNumber &&
                    ((HorseSpecificNote)n).HorseName.Trim().ToUpper() == horseName.Trim().ToUpper());
        }

        static private List<Note> GetNotes(Func<Note,bool > selector)
        {
            return _notes.Where(selector).ToList();
        }

        static public void Add(Note note)
        {
            if (_needsToBeLoaded)
            {
                LoadFromDb();
            }

            note.InsertToDb();
            _notes.Add(note);
        }
    }
}
