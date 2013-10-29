using System.Text;
using System.Xml;

namespace Hogar.RaceAnalyzer
{
    public class HeaderAnalyst : RaceAnalyst
    {
        internal HeaderAnalyst()
        {
            Name = "Header";    
        }

        public override void AddToXmlDocument(XmlDocument doc, XmlNode parent)
        {
            var node = doc.CreateElement("HeaderInfo");
            node.SetAttribute("TrackCode", Race.Parent.TrackCode);
            node.SetAttribute("Date", Race.Parent.Date);
            node.SetAttribute("Distance", Utilities.ConvertYardsToMilesOrFurlongsAbreviation(Race.CorrespondingBrisRace.DistanceInYards));
            node.SetAttribute("Surface", Race.CorrespondingBrisRace.Surface);
            node.SetAttribute("Classification", Race.CorrespondingBrisRace.RaceClassification);
            parent.AppendChild(node);
        }
    }
}