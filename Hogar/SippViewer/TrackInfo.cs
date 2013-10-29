using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SippViewer
{
    static class TrackInfo
    {
        static public string GetFullName(string abbr)
        {
            abbr = abbr.Trim().ToUpper();
            if(abbr == "AP")
                return "Arlington";
            if(abbr == "AQU")
                return "Aqueduct";
            if(abbr == "ATL")
                return "Atlantic City";
            if(abbr == "BEL")
                return "Belmont";
            if(abbr == "BEU")
                return "Beulah Park";
            if(abbr == "CD")
                return "Churhill Downs";
            if(abbr == "CRC")
                return "Calder Race";
            if(abbr == "DED")
                return "Delta Downs";
            if(abbr == "DEL")
                return "Delaware Park";
            if(abbr == "DMR")
                return "Del Mar";
            if(abbr == "ELP")
                return "Ellis Park";
            if(abbr == "EVD")
                return "Evangeline Downs";
            if(abbr == "FG ")
                return "Fair Grounds";
            if(abbr == "FPX")
                return "Fairplaix";
            if(abbr == "GG")
                return "Golden Gate";
            if(abbr == "GP")
                return "Gulfstream Park";
            if(abbr == "HAW")
                return "Hawthorn";
            if(abbr == "HOL")
                return "Hollywood Park";
            if(abbr == "HOO")
                return "Hoosier Park";
            if(abbr == "KEE")
                return "Keenland";
            if(abbr == "LAD")
                return "Louisiana Downs";
            if(abbr == "LRL")
                return "Laurel";
            if(abbr == "LS ")
                return "Lone Star Park";
            if(abbr == "MED")
                return "Meadowlands";
            if(abbr == "MTH")
                return "Monmouth";
            if(abbr == "OP")
                return "Oaklawn Park";
            if(abbr == "OSA")
                return "Oak Tree SA";
            if(abbr == "PEN")
                return "Pen National";
            if(abbr == "Philadelphia Park")
                return "PHA";
            if(abbr == "Philadelphia Park")
                return "PRX";
            if(abbr == "PIM")
                return "Pimlico";
            if(abbr == "RET")
                return "Retama Park";
            if(abbr == "SAR")
                return "Saratoga";
            if(abbr == "SUF")
                return "Suffolk Downs";
            if(abbr == "TAM")
                return "Tampa Bay Downs";
            if (abbr == "TP")
                return "Turfway Park";
            return abbr;

        }
    }
}
