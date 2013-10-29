using System;
using Hogar;
using Hogar.DbTools;

namespace TrackVariantMaint
{
    public class StarterInfo : IDbPopulatable
    {
        public string HorseName { get; private set; }
        public int RaceId { get; private set; }
        public string Date { get; private set; }
        public int FinishPosition { get; private set; }
        public double Distance { get; private set; }
        public string Surface { get; private set; }
        public string TrackCondition { get; private set; }
        public double WinnersFinalTime { get; private set; }
        public double ThisHorseTime { get; private set; }
        public double WinnersAdjustedTime { get; private set; }
        public double ThisHorseProjectedTime { get; private set; }

        
        
        public void Populate(DbReader dbr)
        {
            HorseName = dbr.GetValue<string>("horse_name");
            RaceId = dbr.GetValue<int>("race_id");
            Date = dbr.GetValue<string>("RACING_DATE");
            FinishPosition = dbr.GetValue<int>("finish_position");
            Distance = dbr.GetValue<double>("DISTANCE");
            Surface = dbr.GetValue<string>("surface");
            TrackCondition = dbr.GetValue<string>("track_condition");
            WinnersFinalTime = dbr.GetValue<double>("final_time");
            ThisHorseTime = dbr.GetValue<double>("thisHorseTime");
            WinnersAdjustedTime = dbr.GetValue<double>("projectedTime");
            ThisHorseProjectedTime = dbr.GetValue<double>("thisHorseProjectedTime");
            
            
        }
    }
}