namespace OddsEditor.Dialogs.JockeyStatistics
{
    partial class JockeyStatisticsForm
    {
        private class TrainerTrackStats
        {
            private int _starters = 0;
            private int _winners = 0;
            private double _bankroll = 0.0;

            public static string MakeKey(JockeyStarter js)
            {
                return MakeKey(js.TrackCode, js.Trainer);
            }

            public static string MakeKey(string trackCode, string trainer)
            {
                return (trackCode.Trim() + trainer.Trim()).ToUpper();
            }

            public int Starters
            {
                get
                {
                    return _starters;
                }
            }

            public int Winners
            {
                get
                {
                    return _winners;
                }
            }

            public void IncreaseStarters()
            {
                ++_starters;
            }

            public void IncreaseWinners()
            {
                ++_winners;
            }

            public void IncreaseBankroll(double winPayoff)
            {
                _bankroll += winPayoff;
            }

            public double Roi
            {
                get
                {
                    return _starters > 0 ? _bankroll/_starters : 0.0;
                }
            }

            public override string ToString()
            {
                double winPercent = Starters > 0 ? (double) Winners/(double) Starters : 0;
                return string.Format("{0:0.0}%  {1} - {2}", winPercent * 100.00, Winners, Starters);
            }
        }
    }
}