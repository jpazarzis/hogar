using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace Hogar.RaceAnalyzer
{
    public class RaceAnalyzer
    {
        readonly List<RaceAnalyst> _analyzers = new List<RaceAnalyst>();

        static public RaceAnalyzer Make(Race race)
        {
            return new RaceAnalyzer(race);
        }

        readonly private Race _race;

        private RaceAnalyzer(Race race)
        {
            _race = race;
            _analyzers.Add(new HeaderAnalyst() {Race = race});
            _analyzers.Add(new FirstTimesAnalyst() { Race = race });
            _analyzers.Add(new LayoffAnalyst() { Race = race });
        }


        string GetFilename()
        {
            return string.Format("{0}_{1}_{2}.xml",_race.Parent.TrackCode, _race.Parent.Date, _race.RaceNumber);
        }

        public string CreateAnalysisDocument()
        {
            string filename = Utilities.WebDocumentDirectory + @"\" + GetFilename();
            var doc = GetAsXml();
            doc.Save(filename);
            return filename;
        }

        public XmlDocument GetAsXml()
        {
            var doc = new XmlDocument();
            var dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            var pi = doc.CreateProcessingInstruction("xml-stylesheet", @"type='text/xsl' href='FactorStatistics.xslt'");
            doc.AppendChild(pi);
            XmlElement root = doc.CreateElement("RaceAnalysis");
            doc.AppendChild(root);
            _analyzers.ForEach(analyzer => analyzer.AddToXmlDocument(doc,root));
            return doc;
        }
        
       
    }
}
