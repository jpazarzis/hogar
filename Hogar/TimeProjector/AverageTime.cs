using Hogar.DbTools;

namespace TimeProjector
{
    public class AverageTime : IDbPopulatable 
    {
        public string TrackDesc { get; private set; }
        public string TrackCode { get; private set; }
        public string Surface { get; private set; }
        public double FinalTime { get; private set; }
        public double Distance{ get; private set; }
        public double Speed { get; private set; }
        public int NumberOfRaces { get; private set; }

        public void Populate(DbReader dbr)
        {
            TrackCode = dbr.GetValue<string>("track_code");
            Surface = dbr.GetValue<string>("surface");
            FinalTime = dbr.GetValue<double>("FINAL_TIME");
            Distance = dbr.GetValue<double>("DISTANCE");
            Speed = dbr.GetValue<double>("SPEED");
            NumberOfRaces = dbr.GetValue<int>("COUNTER");
            string s = Surface;
            if (s == "t" || s == "d")
            {
                s = "i" + s;
            }
            TrackDesc = string.Format("{0}_{1}", TrackCode.Trim(), s);
        }

        
        
    }
}