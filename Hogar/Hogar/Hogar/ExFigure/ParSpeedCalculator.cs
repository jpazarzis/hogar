using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Data;
using Hogar.DbTools;

namespace Hogar.ExFigure
{
    static public class ParSpeedCalculator
    {
        public delegate void NotifyObserverDelegate(string msg);
        public static event NotifyObserverDelegate NotifyObserverEvent;


        static public void UpdateDb(string trackCode, Utilities.Surface surface)
        {
            ParSpeed.DeleteFromDb(trackCode, surface);                           
            Dictionary<string, List<double>> times = new Dictionary<string, List<double>>();
            foreach (string fullpath in DailyCard.ExistingFiles)
            {
                string filename = Path.GetFileName(fullpath);
                if (filename.Substring(0, trackCode.Length).ToUpper() == trackCode.ToUpper())
                {
                    if (null != NotifyObserverEvent)
                    {
                        NotifyObserverEvent(string.Format("Processing File: {0}", filename));
                    }
                    DailyCard dc = DailyCard.Load(fullpath);
                    foreach (Race race in dc.Races)
                    {
                        if (race.ExistsInDb && surface == race.SurfaceWhereTheRaceWasRun)
                        {
                            RaceClassification rc = race.Classification;

                            if (null != rc && rc.IsValid)
                            {
                                double normalizedSpeed = race.UnadjustedNormalizedSpeedOfTheRace;
                                if (normalizedSpeed > 0.0)
                                {
                                    string key = rc.ToString();
                                    if (!times.ContainsKey(key))
                                    {
                                        times.Add(key, new List<double>());
                                    }
                                    times[key].Add(race.UnadjustedNormalizedSpeedOfTheRace);
                                }
                            }
                        }
                    }
                }
            }

         
            foreach (KeyValuePair<string, List<double>> pair in times)
            {
                double sum = 0.0, count = 0.0;
                foreach (double d in pair.Value)
                {
                    sum += d;
                    ++count;
                }

                ParSpeed ps = new ParSpeed(pair.Key, sum / count, pair.Value.Count, trackCode,surface);
                if (null != NotifyObserverEvent)
                {
                    NotifyObserverEvent(ps.ToString());
                }
                ps.SaveToDb();
            }
        }

    }
}
