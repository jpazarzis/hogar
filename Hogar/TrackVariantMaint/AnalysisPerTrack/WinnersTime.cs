using System;
using Hogar.DbTools;

namespace TrackVariantMaint.AnalysisPerTrack
{
   public class WinnersTime : IDbPopulatable
    {
        public string TrackDesc { get; set; }

        public double GoldenFigure { get; set; }

        public void Populate(DbReader dbr)
        {
            TrackDesc = dbr.GetValue<string>("track_desc").Trim();
            GoldenFigure = dbr.GetValue<double>("golden_figure");
        }
    }
}