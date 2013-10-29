using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ExoticStudio
{
    public sealed class RaceCard
    {
        readonly Dictionary<int, RaceWeights> _races = new Dictionary<int, RaceWeights>();


        static public RaceCard CreateFromXml(string trackCode, DateTime date)
        {

            return CreateFromXml(trackCode, string.Format("{0}{1:00}{2:00}", date.Year, date.Month, date.Day));
            

        }

        static private RaceCard CreateFromXml(string trackCode, string date /*YYYYMMDD*/)
        {
            try
            {
                string fn = GetFilename(trackCode, date);
                return !File.Exists(fn) ? null : new RaceCard(fn);    
            }
            catch
            {
                return null;
            }

        }

        public RaceWeights GetRace(int rn)
        {
            return _races.ContainsKey(rn) ? _races[rn] : null;
        }

        private RaceCard(string filename)
        {
            _races.Clear();

            var doc = new XmlDocument();
            doc.Load(filename);

            foreach (XmlNode raceNode in doc.SelectNodes("/race-card/race"))
            {
                var r = RaceWeights.Make(raceNode);
                if(null != r)
                {
                    _races.Add(r.RaceNumber, r);
                }
            }
        }

        static private string GetFilename(string trackCode, string date)
        {
            return string.Format(@"C:\HorseRacingSoftware\Documents\RaceWeights\{0}_{1}.xml", trackCode, date);
        }
    }
}