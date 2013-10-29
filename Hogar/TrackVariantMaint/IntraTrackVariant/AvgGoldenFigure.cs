using Hogar.DbTools;

namespace TrackVariantMaint.IntraTrackVariantMaint
{
    class AvgGoldenFigure : IDbPopulatable
    {
        public string TrackDesc { get; private set; }

        public double StandardAdjustment { get; set; }
        
        public string TrackCode
        {
            get
            {
                string s = TrackDesc;

                int pos = s.IndexOf("_");

                if (pos > 0)
                    return s.Substring(0, pos);
                else
                {
                    return "";
                }

            }
        }
        public double Figure { get; set; }

        public string Surface
        {
            get
            {
                string s = TrackDesc;

                int pos = s.IndexOf("_");

                if (pos > 0)
                {
                    string t = s.Substring(pos + 1);
                    if (t == "id")
                        t = "d";
                    if (t == "it")
                        t = "t";
                    return t;

                }
                else
                {
                    return "";
                }

            }
        }
        public double IntraVariant { get; set; }

        public void Populate(DbReader dbr)
        {

            Figure = dbr.GetValue<double>("avg_golden_figure");
            TrackDesc = dbr.GetValue<string>("track_desc");

        }
    }
}