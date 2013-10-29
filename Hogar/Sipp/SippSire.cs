using System;
using System.Xml;

namespace Sipp
{
    public class SippSire
    {
        public string Name { get; set; }
        public string FirstTimeOutRating { get; set; }
        public string MudRating { get; set; }
        public string TurfRating { get; set; }
        public string AllWeatherRating { get; set; }
        public string AverageDistance { get; set; }

        public SippSire()
        {
            
        }

        internal SippSire(XmlNode sireNode)
        {
            Name = sireNode.Attributes["name"].Value;
            FirstTimeOutRating = sireNode.Attributes["fto"].Value;
            MudRating = sireNode.Attributes["mud"].Value;
            TurfRating = sireNode.Attributes["turf"].Value;
            AllWeatherRating = sireNode.Attributes["aws"].Value;
            AverageDistance = sireNode.Attributes["distance"].Value;
        }

        internal void AddToXmlNode(XmlDocument doc, XmlElement ppNode)
        {
            ppNode.SetAttribute("name", Name);
            ppNode.SetAttribute("fto", FirstTimeOutRating);
            ppNode.SetAttribute("mud", MudRating);
            ppNode.SetAttribute("turf", TurfRating);
            ppNode.SetAttribute("aws", AllWeatherRating);
            ppNode.SetAttribute("distance", AverageDistance);
        }
    }
}