using Hogar.DbTools;

namespace Hogar.StatisticTools
{
    internal class Starter : IDbPopulatable
    {
	    public string TrackCode { get; private set;} 
	    public string Date { get; private set;}
	    public string Trainer { get; private set;} 
	    public double Odds { get; private set;}
	    public double WinPayoff { get; private set;}
	    public int Call1Position { get; private set;}
	    public int Call2Position { get; private set;} 
	    public int Call3Position { get; private set;}
	    public int FinishPosition { get; private set;}
        public int OfficialPosition { get; private set; }
        public bool WasTheFavorite { get; private set; }
        public int FieldSize { get; private set; }
        public bool Turf { get; private set; }
        public bool Dirt { get; private set; }
        public bool Route { get; private set; }
        public bool Sprint { get; private set; }


        public bool TookTheLead
        {
            get
            {
                return Call1Position == 1;
            }
        }

        public bool WasTheWinner
        {
            get
            {
                return OfficialPosition == 1;
            }
        }

        public bool WentWireToWire
        {
            get
            {
                return Call1Position*Call2Position*Call3Position*FinishPosition == 1; 
            }
        }


        public void Populate(DbReader dbr)
        {

            TrackCode = dbr.GetValue<string>("track_code");
            Date = dbr.GetValue<string>("racing_date");
            Trainer = dbr.GetValue<string>("abbr_trainer_name");
            Odds = dbr.GetValue<double>("odds");
            WinPayoff = dbr.GetValue<double>("win_payoff");
            Call1Position = dbr.GetValue<int>("call_1_position");
            Call2Position = dbr.GetValue<int>("call_2_position");
            Call3Position = dbr.GetValue<int>("call_3_position");
            FinishPosition = dbr.GetValue<int>("finish_position");
            OfficialPosition = dbr.GetValue<int>("official_position");
            WasTheFavorite = (dbr.GetValue<int>("favorite_flag") == 1);
            FieldSize = dbr.GetValue<int>("field_size");
            Turf = dbr.GetValue<string>("surface").ToUpper().Contains("T");
            Dirt = !Turf;
            Route = dbr.GetValue<double>("distance") >= Utilities.MIN_DISTANCE_FOR_ROUTE;
            Sprint = !Route;

        }
    }
}