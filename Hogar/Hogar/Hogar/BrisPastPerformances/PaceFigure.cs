using Hogar.DbTools;

namespace Hogar.BrisPastPerformances
{
    public sealed class PaceFigure
    {
        private const int INVALID_VALUE = -999;

        private readonly int _figure1ForTheRace = INVALID_VALUE;
        private readonly int _figure2ForTheRace = INVALID_VALUE;
        private readonly int _finalCallForTheRace = INVALID_VALUE;

        private readonly int _figure1ForTheHorse = INVALID_VALUE;
        private readonly int _figure2ForTheHorse = INVALID_VALUE;
        private readonly int _finalCallForTheHorse = INVALID_VALUE;

        internal static PaceFigure Make(string trackCode, string date, int raceNumber, string horseNumber)
        {
            return new PaceFigure(trackCode, date, raceNumber, horseNumber);
        }


        public override string ToString()
        {
            return string.Format("({0,4} /{1,4})({2,4} /{3,4})({4,4} /{5,4})", _figure1ForTheHorse, _figure1ForTheRace, _figure2ForTheHorse, _figure2ForTheRace, _finalCallForTheHorse, _finalCallForTheRace);
        }

        public int Figure1ForTheRace
        {
            get
            {
                return _figure1ForTheRace + 100;
            }
        }

        public int Figure2ForTheRace
        {
            get
            {
                return _figure2ForTheRace + 100;
            }
        }

        

        public int FinalFigureForTheRace
        {
            get
            {
                return _finalCallForTheRace + 100;
            }
        }


        public int Figure1ForTheHorse
        {
            get
            {
                return _figure1ForTheHorse + 100;
            }
        }

        public int Figure2ForTheHorse
        {
            get
            {
                return _figure2ForTheHorse + 100;
            }
        }

        public int FinalFigureForTheHorse
        {
            get
            {
                return _finalCallForTheHorse + 100;
            }
        }



        private PaceFigure(string trackCode, string date, int raceNumber, string horseNumber)
        {
            var sql = string.Format("exec GetPaceFigureForSpecificRace '{0}', '{1}', {2}, '{3}'", trackCode, date, raceNumber, horseNumber);

            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        _figure1ForTheRace = dbr.GetValue<int>("figure1");
                        _figure2ForTheRace = dbr.GetValue<int>("figure2");
                        _finalCallForTheRace = dbr.GetValue<int>("finalFigure");

                        _figure1ForTheHorse = dbr.GetValue<int>("figure1ForTheHorse");
                        _figure2ForTheHorse = dbr.GetValue<int>("figure2ForTheHorse");
                        _finalCallForTheHorse = dbr.GetValue<int>("finalFigureForTheHorse");

                    }
                }
            }
        }
    }
}