using Hogar.DbTools;

namespace Hogar.Research.PickXAnalyzer
{
    public class Result: IDbPopulatable 
    {
        public int FinalRaceId { get; set;}
        public string TrackCode { get; set;}
        public string RacingDate { get; set;}
        public int RaceNumber { get; set;}
        public double Bet{ get; set;}
        public double Payoff{ get; set;}
        public double Pool{ get; set;}
        public int LengthOfBet { get; set; }

        private WinnersSequence _winnersSequence = null;

        public override string ToString()
        {
            return string.Format("{0},{1:00.0},{2:0.00}", ValueIndexTotal, Payoff, AverageNumberOfHorsesPerRace);
        }

        public int ValueIndexTotal
        {
            get
            {
                if(null == _winnersSequence)
                {
                    _winnersSequence = WinnersSequence.Make(this);    
                }

                return _winnersSequence.ValueIndexTotal;

            }
        }

        public double AverageNumberOfHorsesPerRace
        {
            get
            {
                if (null == _winnersSequence)
                {
                    _winnersSequence = WinnersSequence.Make(this);
                }

                return (double) _winnersSequence.TotalNumberOfHorses /(double) LengthOfBet;
            }
        }

        public void Populate(DbReader dbr)
        {
            FinalRaceId = dbr.GetValue<int>("ID");
            TrackCode = dbr.GetValue<string>("TRACK_CODE");
            RacingDate = dbr.GetValue<string>("RACING_DATE");
            RaceNumber = dbr.GetValue<int>("RACE_NUMBER");
            Bet = dbr.GetValue<double>("BET_AMOUNT");
            Payoff = dbr.GetValue<double>("PAYOFF_AMOUNT");
            Pool =  dbr.GetValue<double>("WAGER_POOL");
        }
    
    }
}