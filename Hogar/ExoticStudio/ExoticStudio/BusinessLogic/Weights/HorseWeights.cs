using System.Xml;

namespace ExoticStudio
{
    public sealed class HorseWeights
    {
        public int ProgramNumber { get; private set; }
        public int ValueIndex { get; private set; }
        public int WeightIndex { get; private set; }

        static public HorseWeights Make(XmlNode horseNode)
        {
            try
            {
                return new HorseWeights(horseNode);
            }
            catch
            {
                return null;
            }
        }

        private HorseWeights(XmlNode horseNode)
        {
            ProgramNumber = ValueIndex = WeightIndex = 0;

            int pn, vi, wi;

            if(!int.TryParse(horseNode.Attributes["program-number"].Value, out pn))
                return;

            if (!int.TryParse(horseNode.Attributes["value-index"].Value, out vi))
                return;

            if (!int.TryParse(horseNode.Attributes["weight-index"].Value, out wi))
                return;

            ProgramNumber = pn;
            ValueIndex = vi;
            WeightIndex = wi;

        }
    }
}