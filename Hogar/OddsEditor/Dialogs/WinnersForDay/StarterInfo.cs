using Hogar.DbTools;

namespace OddsEditor.Dialogs.WinnersForDay
{
    class StarterInfo : IFractionalTimes
    {
        readonly double _fraction1;
        readonly double _fraction2;
        readonly double _fraction3;
        readonly double _finalTime;
        private readonly bool _existsInTheDb;

        public StarterInfo(int raceid, string horseName)
        {            
            _existsInTheDb = false;
            using (var dbr = new DbReader())
            {
                string sql = string.Format(@"EXEC GetHorseFractions {0}, '{1}' ", raceid, horseName);
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        _fraction1 = dbr.GetValue<double>("CALL_1");
                        _fraction2 = dbr.GetValue<double>("CALL_2");
                        _fraction3 = dbr.GetValue<double>("CALL_3");
                        _finalTime = dbr.GetValue<double>("FINAL_CALL");
                        _existsInTheDb = true;
                    }
                }
            }
        }

        public bool ExistsInDb
        {
            get
            {
                return _existsInTheDb;
            }
        }

        public double FirstFraction()
        {
            return _fraction1;
        }

        public double SecondFraction()
        {
            return _fraction2;
        }

        public double ThirdFraction()
        {
            return _fraction3;
        }

        public double FinalTime()
        {
            return _finalTime;
        }
    }
}
