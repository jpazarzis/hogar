using System.Xml;

namespace Hogar.RaceAnalyzer
{
    public class FirstTimesAnalyst : RaceAnalyst
    {
        internal FirstTimesAnalyst()
        {
            Name = "First Times";
        }

        public override void AddToXmlDocument(XmlDocument doc, XmlNode parent)
        {
            

            var node = doc.CreateElement("Analyst");

            node.SetAttribute("Name", "Changes");


            foreach (var horse in Race.Horses)
            {
                if (horse.Scratched)
                    continue;

                var node2 = doc.CreateElement("Starter");

                node2.SetAttribute("ProgramNumber", horse.ProgramNumber);
                node2.SetAttribute("HorseName", horse.Name);

                if (horse.CorrespondingBrisHorse.IsFirstTimeLasix)
                {
                    CreateStatisticNode(doc, node2, "FirstTimeLasix", horse);
                }

                if (horse.CorrespondingBrisHorse.IsFirstTimeOut)
                {
                    var node3 = CreateStatisticNode(doc, node2, "FirstTimeOut", horse);
                    InsertBreedingInfoNode(doc, node3, horse);
                }

                if (horse.CorrespondingBrisHorse.IsFirstTimeTurf)
                {
                    var node3 = CreateStatisticNode(doc, node2, "FirstTimeTurf", horse);
                    InsertBreedingInfoNode(doc, node3, horse);
                }

                if (horse.CorrespondingBrisHorse.BlinkersOff)
                {
                    CreateStatisticNode(doc, node2, "BlinkersOff", horse);
                }

                if (horse.CorrespondingBrisHorse.BlinkersOn)
                {
                    CreateStatisticNode(doc, node2, "BlinkersOn", horse);
                }

                if (node2.ChildNodes.Count > 0)
                {
                    node.AppendChild(node2);
                }
            }

            if (node.ChildNodes.Count > 0)
                parent.AppendChild(node);
        }
    }
}