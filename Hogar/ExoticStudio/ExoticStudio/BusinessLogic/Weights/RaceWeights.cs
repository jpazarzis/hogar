using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExoticStudio
{
    public sealed class RaceWeights
    {
        public int RaceNumber { get; private set; }

        public int TotalHorseCount { get; private set; }

        readonly Dictionary<int, HorseWeights> _horseWeights = new Dictionary<int, HorseWeights>();


        static public RaceWeights Make(XmlNode raceNode)
        {
            try
            {
                return new RaceWeights(raceNode);
            }
            catch
            {
                return null;
            }
        }

        public HorseWeights GetHorse(int horseProgramNumber)
        {
            return _horseWeights.ContainsKey(horseProgramNumber) ? _horseWeights[horseProgramNumber] : null;
        }

        public List<HorseWeights> Horses
        {
            get
            {
                return _horseWeights.Keys.Select(key => _horseWeights[key]).ToList().OrderBy(h=>h.ProgramNumber).ToList();
            }
        }

        private RaceWeights(XmlNode raceNode)
        {
            _horseWeights.Clear();
            TotalHorseCount = 0;

            int rn;
            if(int.TryParse(raceNode.Attributes["race-number"].Value, out rn))
            {
                RaceNumber = rn;

                int horseCount;
                
                if (int.TryParse(raceNode.Attributes["number-of-horses"].Value, out horseCount))
                {
                    TotalHorseCount = horseCount;
                }

                
                foreach (XmlNode horseNode in raceNode.SelectNodes("horse"))
                {
                    var h = HorseWeights.Make(horseNode);
                    if (null != h)
                    {
                        _horseWeights.Add(h.ProgramNumber, h);
                    }
                }
            }
        }
    }
}