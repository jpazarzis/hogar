using System;
using System.Xml;

namespace Hogar.RaceAnalyzer
{
    public class LayoffAnalyst : RaceAnalyst
    {
        internal LayoffAnalyst()
        {
            Name = "Layoff";
        }

        public override void AddToXmlDocument(XmlDocument doc, XmlNode parent)
        {
            var node = doc.CreateElement("Analyst");

            node.SetAttribute("Name", "LayoffAnalyst");
                
            foreach (var horse in Race.Horses)
            {
                if(horse.Scratched)
                    continue;

                var node2 = doc.CreateElement("Starter");
                node2.SetAttribute("ProgramNumber", horse.ProgramNumber);
                node2.SetAttribute("HorseName", horse.Name);

                if (horse.FirstAfterLayoff)
                {
                    CreateStatisticNode(doc, node2, "Layoff", horse);
                }

                if (horse.SecondAfterLayoff)
                {
                    CreateStatisticNode(doc, node2, "SecondOfLayoff", horse);
                }

                if (horse.ThirdAfterLayoff)
                {
                    CreateStatisticNode(doc, node2, "ThirdOfLayoff", horse);
                }

                if (horse.FirstAfterLongLayoff)
                {
                    CreateStatisticNode(doc, node2, "LongLayoff", horse);
                }

                if (node2.ChildNodes.Count > 0)
                {
                    node.AppendChild(node2);
                }
            }

            if (node.ChildNodes.Count > 0)
                parent.AppendChild(node);

            parent.AppendChild(node);
        }
    }
}