using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace Sipp
{
    public class SippRace : List<SippHorse>
    {
        public void AddHorse(SippHorse horse)
        {
            this.Add(horse);
            horse.Parent = this;


            foreach (var pp in horse.PastPerformances)
            {
                pp.Parent = horse;
            }
        }

        public SippDailyCard Parent { get; internal set; }


        public class FactorKey
        {
            public string Name { get; set; }
            public SippHandicappingFactorStats Stats { get; set; }
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }

        public  class HorseData
        {
            public string Description { get; set; }
            public SippHorse Horse { get; set; }
        }

        public Dictionary<FactorKey, List<HorseData>> HandicappingFactorsSummary
        {
            get
            {
                var sum = new Dictionary<FactorKey, List<HorseData>>();
                foreach (var horse in this)
                {
                    if (horse.Scratched)
                        continue;

                    foreach (var factor in horse.HandicappingFactors)
                    {
                        FactorKey key=null;
                        if(sum.Count > 0 )
                            key = sum.Keys.ToList().Find(f=>f.Name == factor.Name);
                        if(null == key)
                            key = new FactorKey { Name = factor.Name, Stats = factor.GeneralStats };
                        if (!sum.ContainsKey(key))
                        {
                            sum.Add(key, new List<HorseData>());
                        }

                        var list = sum[key];
                        list.Add(new HorseData { Description = string.Format("{0,2}. {1,-22} {2}", horse.ProgramNumber, horse.Name, factor.TrainerStats), Horse = horse });
                    }
                }
                return sum;    
            }
        }

        static public SippRace Make(int raceNumber, double distanceInYards, string surface, string raceCondition)
        {
            return new SippRace
                       {
                           RaceNumber = raceNumber,
                           DistanceInYeards = distanceInYards,
                           Surface = surface,
                           RaceCondition = raceCondition
                       };
        }

        public int RaceNumber { get;  set; }
        public double DistanceInYeards { get; set; }
        public string Surface { get; set; }
        public string RaceCondition { get; set; }

        internal void ReassignPostPositions()
        {
            int currentPostposition = 0;


            foreach (var horse in this.OrderBy(h=>(-1)*h.PostPosition))
            {
                if(horse.Scratched)
                    continue;

                horse.PostPosition = ++currentPostposition;
            }
        }

        public int NumberOfHorses
        {
            get
            {
                var list = new List<int>();

                foreach (var horse in this)
                {
                    if (horse.Scratched)
                        continue;

                    int number = horse.ProgramNumberWithoutEntryChar;

                    if(!list.Contains(number))
                    {
                        list.Add(number);
                    }
                }

                return list.Count;
            }
        }


        internal  void AddToXmlNode(XmlDocument doc, XmlElement node)
        {
            var raceNode = doc.CreateElement("race");
            raceNode.SetAttribute("race-number", RaceNumber.ToString());
            raceNode.SetAttribute("distance", ((int) DistanceInYeards).ToString() );
            raceNode.SetAttribute("surface", Surface );
            raceNode.SetAttribute("condition", RaceCondition);
            this.ForEach(h=>h.AddToXmlNode(doc, raceNode));
            node.AppendChild(raceNode);
        }

        private SippRace()
        {
            
        }

        public List<int> GetBrisSpeedFiguresForRecentFormCycles()
        {
            
            var f = new List<int>();

            foreach (var horse in this)
            {
                if(!horse.Scratched)
                    f.AddRange(horse.GetBrisSpeedFiguresForRecentFormCycles());
            }

            return f;
        
        }

        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        internal void CaclulateNormalFigures()
        {
            var figures = GetBrisSpeedFiguresForRecentFormCycles().Select(i => (double)i).ToList();
            double mean = figures.Count > 0 ? figures.Average() : 0;
            double stdev = figures.Count > 0 ? CalculateStdDev(figures) : 0;
            this.ForEach(h => h.CaclulateNormalFigures(mean,stdev));
   
        }
    }
}