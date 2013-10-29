using Hogar.DbTools;

namespace Hogar.PostPositionStatistics
{
    public class PostPositionStatistic : IDbPopulatable
    {
        public int PostPosition { get; private set; }
        public int Starters { get; private set; }
        public double WinPercent { get; private set; }
        public double IV { get; private set; }
        public double W2WWinPercent { get; private set; }
        public int W2WWinners{ get; private set; }
        public int NumberOfRaces{ get; private set; }

        
        public void Populate(DbReader dbr)
        {
            PostPosition = dbr.GetValue<int>("PostPosition");
            Starters = dbr.GetValue<int>("StartersForPP");
            WinPercent = dbr.GetValue<double>("WinPercent");
            IV = dbr.GetValue<double>("WinnersIV");
            W2WWinPercent = dbr.GetValue<double>("W2WWinPercent");
            W2WWinners = dbr.GetValue<int>("TotalW2WWinners");
            NumberOfRaces = dbr.GetValue<int>("numberOfRaces");
        }
    }
}