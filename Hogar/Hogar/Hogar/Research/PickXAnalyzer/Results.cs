using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.DbTools;

namespace Hogar.Research.PickXAnalyzer
{
    public class Results: DataBaseCollection<Result>
    {
        public int LengthOfBet { get; private set; }

        public string TrackCode { get; private set; }


        static public Results Make(int lengthOfBet, string trackCode)
        {
            var r = new Results {LengthOfBet = lengthOfBet, TrackCode = trackCode};
            r.Load();
            r.ForEach(r1=>r1.LengthOfBet = lengthOfBet);
            return r;
        }


        private Results()
        {
            
        }


        void Load()
        {
            this.Load(SQLLoader);
        }

        string BetName
        {
            get
            {
                switch (LengthOfBet)
                {
                    case 3:
                        return "Pick Three";
                    case  4:
                        return "Pick Four";
                    default:
                        break;    
                }

                throw new Exception("Unsupporter bet length");
            }
        }

        string SQLLoader
        {
            get { return string.Format(_loader, BetName, TrackCode); }
        }

        private const string _loader = @"select ID, TRACK_CODE, RACING_DATE, RACE_NUMBER, BET_AMOUNT, PAYOFF_AMOUNT, WAGER_POOL from RACE_EXOTICS_PAYOFF where wager_type='{0}' and PAYOFF_AMOUNT>0  and  TRACK_CODE = '{1}'";
    }
}
