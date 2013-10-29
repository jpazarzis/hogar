using System.Xml;

namespace Sipp
{
    public class SippHandicappingFactor
    {

        static public SippHandicappingFactor Make(string name)
        {
            return new SippHandicappingFactor {Name = name};
        }

        public string Name { get; set; }
        public SippHandicappingFactorStats GeneralStats { get; set; }
        public SippHandicappingFactorStats TrainerStats { get; set; }

        internal void AddToXmlNode(XmlDocument doc, XmlElement node)
        {
            var hf = doc.CreateElement("handicapping-factor");
            hf.SetAttribute("name", Name);
            hf.SetAttribute("general-sample-size", GeneralStats.SampleSize.ToString());
            hf.SetAttribute("general-win-percent", string.Format("{0:0.0}", GeneralStats.WinningPercent));
            hf.SetAttribute("general-roi", string.Format("{0:0.0}", GeneralStats.Roi));
            hf.SetAttribute("general-iv", string.Format("{0:0.0}", GeneralStats.IV));

            hf.SetAttribute("trainer-sample-size", TrainerStats.SampleSize.ToString());
            hf.SetAttribute("trainer-win-percent", string.Format("{0:0.0}", TrainerStats.WinningPercent));
            hf.SetAttribute("trainer-roi", string.Format("{0:0.0}", TrainerStats.Roi));
            hf.SetAttribute("trainer-iv", string.Format("{0:0.0}", TrainerStats.IV));
            
            node.AppendChild(hf);
            
        }

        private SippHandicappingFactor()
        {
            
        }

    }
}