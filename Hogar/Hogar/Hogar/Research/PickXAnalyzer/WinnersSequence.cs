using System.Linq;
using Hogar.DbTools;

namespace Hogar.Research.PickXAnalyzer
{
    class WinnersSequence : DataBaseCollection<Winner>
    {
        private readonly Result _result;

        static public WinnersSequence Make(Result result)
        {
            var w = new WinnersSequence(result);
            w.Load(w.SqlLoader);
            return w;
        }

        public bool ContainsDeadHeats
        {
            get 
            { 
                return this.Count > _result.LengthOfBet;
            }
        }

        WinnersSequence(Result result)
        {
            _result = result;
        }

        public int ValueIndexTotal
        {
            get { return this.Sum(w => w.ValueIndex); }
        }
        
        public int TotalNumberOfHorses
        {
            get { return this.Sum(w => w.FieldSize); }
        }


        string SqlLoader
        {
            get
            {
                
                return string.Format(_loader, _result.RacingDate, _result.RaceNumber - 2, _result.RaceNumber, _result.TrackCode);    
            }
            
        }

        private const string _loader = @"select odds, field_size from RACE_STARTERS a, RACE_DESCRIPTION b where a.RACING_DATE = '{0}' and a.RACE_NUMBER >= {1} and a.RACE_NUMBER <={2} and a.RACE_ID = b.RACE_ID and a.TRACK_CODE='{3}' and a.OFFICIAL_POSITION=1 order by a.race_id";
    }
}