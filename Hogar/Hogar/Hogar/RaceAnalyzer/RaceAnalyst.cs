using System;
using System.Collections.Generic;
using System.Xml;
using Hogar.SireStats;

namespace Hogar.RaceAnalyzer
{
    public abstract class RaceAnalyst
    {
        public string Name { get; internal set; }

        internal Race Race { get; set; }

        public abstract void AddToXmlDocument(XmlDocument doc, XmlNode parent);


        static protected void InsertBreedingInfoNode(XmlDocument doc, XmlElement node, Horse horse)
        {
            var node2 = doc.CreateElement("BreedingInfo");
            node.AppendChild(node2);
            SireInfo sire, damSire;
            Sire.GetSireStats(horse, out sire, out damSire);
            var node3 = doc.CreateElement("Sire");
            node3.SetAttribute("Name", sire.Name);
            node3.SetAttribute("FTS", sire.FirstTime);
            node3.SetAttribute("MUD", sire.Mud);
            node3.SetAttribute("TURF", sire.Turf);
            node3.SetAttribute("AWS", sire.AllWeather);
            node3.SetAttribute("DIST", sire.AverageDistance);
            node2.AppendChild(node3);

            node3 = doc.CreateElement("DamSire");
            node3.SetAttribute("Name", damSire.Name);
            node3.SetAttribute("FTS", damSire.FirstTime);
            node3.SetAttribute("MUD", damSire.Mud);
            node3.SetAttribute("TURF", damSire.Turf);
            node3.SetAttribute("AWS", damSire.AllWeather);
            node3.SetAttribute("DIST", damSire.AverageDistance);
            node2.AppendChild(node3);


        }

        static protected XmlElement CreateStatisticNode(XmlDocument doc, XmlElement node2, string statName, Horse horse)
        {
            var node3 = doc.CreateElement("Factor");
            node3.SetAttribute("Name", statName);
            
            node2.AppendChild(node3);
            AppendStatistics(doc, node3, statName, horse);
            return node3;
        }

        static protected void AppendStatistics(XmlDocument doc, XmlNode node, string statName, Horse horse)
        {
            if (null == horse || node == null || doc == null)
                return;

/*

            var stat = horse.GetFactorStats(statName);

            if (null == stat)
                return;

            var node2 = doc.CreateElement("Statistics");
            node2.SetAttribute("Name", "General");

            node2.SetAttribute("Starters", stat.Starters.ToString());
            node2.SetAttribute("WinPercent", string.Format("{0:0}%", (int)stat.WinningPercent));
            node2.SetAttribute("ROI", string.Format("{0:0.00}", stat.Roi));
            node2.SetAttribute("IV", string.Format("{0:0.00}", stat.IV));
            node.AppendChild(node2);

            node2 = doc.CreateElement("Statistics");
            node2.SetAttribute("Name", "Trainer");

            node2.SetAttribute("Starters", stat.TrainerStarters.ToString());
            node2.SetAttribute("WinPercent", string.Format("{0:0}%", (int)stat.TrainerWinningPercent));
            node2.SetAttribute("ROI", string.Format("{0:0.00}", stat.TrainerRoi));
            node2.SetAttribute("IV", string.Format("{0:0.00}", stat.TrainerIV));
            node.AppendChild(node2);
            */
        }

    }
}