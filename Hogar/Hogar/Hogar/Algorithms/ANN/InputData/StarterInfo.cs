using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Hogar.BrisPastPerformances;
using Hogar.DbTools;

namespace Hogar.Algorithms.ANN.InputData
{
    public enum RaceType
    {
        MCL, MSW, CLM, ALW, STARTER_ALW,STAKES, GRADE_3, GRADE_2, GRADE_1, UNKNOWN
    }


    public partial class StarterInfo : IDbPopulatable
    {
        public int RaceId { get; private set; }
        public string HorseName { get; private set; }
        public string RacingDate { get; set; }
        public string TrackCode { get; private set; }
        public string TrackCondition { get; private set; }
        public int Distance { get; set; }
        public int FinishPosition { get; private set; }
        public double Odds { get; private set; }
        public int GoldenFigure { get; private set; }
        public int WinnersGoldenFigure { get; private set; }
        public int SecondCallPosition { get; private set; }
        public RaceType RaceType { get; set; }
        public int PostPosition { get; set; }
        public bool RestrictedToFemalesOnly { get; set; }
        public bool RestrictedToStateBredsOnly { get; set; }
        public bool WasClaimed { get; set; }
        public bool BlinkersOff { get; set; }
        public bool FirstTimeLasix { get; set; }
        public bool RestrictedToTwoYearsOnly { get; set; }
        public bool RestrictedToThreeYearsOnly { get; set; }
        public int FieldSize { get; private set; }
        public bool WasTheFavorite { get; private set; }


        public int LayoffInDays
        {
            get
            {
                return null != Previous ?  
                    (Utilities.MakeDateTime(RacingDate) - Utilities.MakeDateTime(Previous.RacingDate)).Days :
                      0;   
            }
        }

        public int Votes { get; set; }

        public StarterInfo Previous { get; set; }
        public StarterInfo Next { get; set; }
        
        private static int _counter = 0;

        public bool BreaksPersonalRecord
        {
            get
            {
                int gf = this.GoldenFigure;

                var si = this.Previous;
                while (null != si)
                {
                    if(si.GoldenFigure >= gf)
                        return false;
                    si = si.Previous;
                }

                return true;
            }
        }


        public StarterInfo()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} ",RaceId, TrackCode,RacingDate, HorseName);
        }

        public int CountPreceding
        {
            get
            {
                return null == Previous ? 0 : 1 + Previous.CountPreceding;
            }
        }


        
        static public List<List<StarterInfo>> LoadFirstAndSecondFavorite(string filename, int ppCount)
        {
            var matches = new List<List<StarterInfo>>();

            var list = LoadRacesFromFile(filename, 0);

            foreach (int raceid in list.Keys)
            {
                var favorite = list[raceid].Find(si => si.WasTheFavorite);

                if (null == favorite || favorite.CountPreceding < ppCount)
                    continue;

                var starters = list[raceid].OrderBy(si => si.Odds).ToList();

                if(starters.Count < 3)
                    continue;

                var secondFavorite = starters[1];

                if (null == secondFavorite || secondFavorite.CountPreceding < ppCount)
                    continue;


                var thirdFavorite = starters[2];

                if (null == thirdFavorite || thirdFavorite.CountPreceding < ppCount)
                    continue;


                matches.Add(new List<StarterInfo>() { favorite, secondFavorite, thirdFavorite });
            }

            return matches;
        }
        

        static public List<List<StarterInfo>> LoadRacesWithExactNumberOfHorsesFromFile(string filename, int minNumberOfPastPerformances, int fieldSize)
        {
            var racesWithExactNumberOfHorse = new List<List<StarterInfo>>();

            var list = LoadRacesFromFile(filename, minNumberOfPastPerformances);

            foreach (int raceid in list.Keys)
            {
                // We need the race to 
                // (1) have exactly the provided number of horses AND
                // (2) contain the winner

                if (list[raceid].Count == fieldSize && null != list[raceid].Find(si => si.FinishPosition == 1))
                {
                    if(list[raceid][0].FieldSize == fieldSize)
                    {
                        racesWithExactNumberOfHorse.Add(list[raceid]);        
                    }
                    
                }
            }

            return racesWithExactNumberOfHorse;
        }

        static public List<List<StarterInfo>> LoadCombosFromFile(string filename, int minNumberOfPastPerformances, int combinationSize)
        {
            var combos = new List<List<StarterInfo>>();

            var list = LoadRacesFromFile(filename, minNumberOfPastPerformances);

            foreach (int raceid in list.Keys)
            {
                if (list[raceid].Count >= combinationSize)
                {
                    combos.AddRange(CombinationCalculator<StarterInfo>.GenerateCombinations(list[raceid], combinationSize));
                }
            }

            return combos;
        }


        


        static public Dictionary<int, List<StarterInfo>> LoadRacesFromFile(string filename, int minNumberOfPastPerformances)
        {
            var list = new Dictionary<int, List<StarterInfo>>();

            var si = LoadStartersFromFile(filename);

            foreach (var starterInfo in si)
            {
                if (starterInfo.CountPreceding < minNumberOfPastPerformances)
                    continue;

                int raceid = starterInfo.RaceId;
                
                if(false == list.ContainsKey(raceid))
                {
                    list.Add(raceid,new List<StarterInfo>());
                }

                list[raceid].Add(starterInfo);

            }


            return list;
        }


        static public List<StarterInfo> LoadStartersFromFile(string filename, int minNumberOfPPs)
        {
            var list = new List<StarterInfo>();
            using (var sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var si = CreateFromString(line.Split(','), 0, null);
                    while (null != si)
                    {
                        if(si.CountPreceding >= minNumberOfPPs && si.WasTheFavorite)
                        {
                            list.Add(si);    
                        }
                        si = si.Next;
                    }
                }
            }

            return list;
        }
        
        static private List<StarterInfo> LoadStartersFromFile(string filename)
        {
            var list = new List<StarterInfo>();
            using (var sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var si = CreateFromString(line.Split(','), 0, null);
                    while (null != si)
                    {
                        list.Add(si);
                        si = si.Next;
                    }
                }
            }

            return list;
        }


        static internal StarterInfo CreateFromBrisPastPerformance(BrisPastPerformance pp)
        {
            if (null == pp || pp.GoldenFigureForThisHorse == -999)
                return null;

            var si = new StarterInfo { Previous = null, Next = null };

            si.HorseName = pp.Parent.CorrespondingHorse.Name;
            si.RaceId = -9999;
            si.TrackCode = pp.Parent.CorrespondingHorse.Parent.Parent.TrackCode;
            si.RacingDate = Utilities.GetDateInYYYYMMDD(pp.Date);
            si.FinishPosition = Convert.ToInt32(pp.FinalPosition);
            si.Odds = pp.OddsAsDouble;
            si.GoldenFigure = (int)pp.GoldenFigureForThisHorse;

            if (si.GoldenFigure < 0)
            {
                si.GoldenFigure = 1;
            }

            si.WinnersGoldenFigure = (int)pp.GoldenFigureForTheWinner;


            si.TrackCondition = pp.TrackCondition;
            si.Distance = pp.DistanceInYards;

            int scp;
            int.TryParse(pp.SecondCallPosition, out scp);
            si.SecondCallPosition = scp;


            return si;

        }

        static private StarterInfo CreateFromString(string[] s, int stringArrayIndex, StarterInfo previous)
        {

            if (stringArrayIndex >= s.Count())
                return null;

            var si = new StarterInfo {Previous = previous, Next = null};

            si.HorseName = (null == previous) ? s[stringArrayIndex++] : previous.HorseName ;
            si.RaceId = Convert.ToInt32(s[stringArrayIndex++]);
            si.TrackCode = s[stringArrayIndex++];
            si.RacingDate = s[stringArrayIndex++];
            si.FinishPosition = Convert.ToInt32(s[stringArrayIndex++]);
            si.Odds = Convert.ToDouble(s[stringArrayIndex++]);
            si.GoldenFigure = Convert.ToInt32(s[stringArrayIndex++]);

            if (si.GoldenFigure < 0)
            {
                si.GoldenFigure = 1;
            }

            si.WinnersGoldenFigure = Convert.ToInt32(s[stringArrayIndex++]);


            si.TrackCondition = s[stringArrayIndex++];
            si.Distance = Convert.ToInt32(s[stringArrayIndex++]);
            si.SecondCallPosition = Convert.ToInt32(s[stringArrayIndex++]);
            si.RaceType = DeserializeRaceType(s[stringArrayIndex++]);
            si.PostPosition = Convert.ToInt32(s[stringArrayIndex++]);
            DeserializeRestrictions(si, s[stringArrayIndex++]);
            si.FieldSize = Convert.ToInt32(s[stringArrayIndex++]);
            si.WasTheFavorite = Convert.ToInt32(s[stringArrayIndex++]) == 1;

            var next = CreateFromString(s, stringArrayIndex, si);
            si.Next = next;
            
            return si;
        }

        static private void DeserializeRestrictions(StarterInfo si, string s)
        {
            s = s.Trim();
            if (s.Length == 7)
            {
                si.RestrictedToFemalesOnly = (s[0] == '1');
                si.RestrictedToStateBredsOnly = (s[1] == '1');
                si.WasClaimed = (s[2] == '1');
                si.BlinkersOff = (s[3] == '1');
                si.FirstTimeLasix = (s[4] == '1');
                si.RestrictedToTwoYearsOnly = (s[5] == '1');
                si.RestrictedToThreeYearsOnly = (s[6] == '1');
            }
        }

        private static RaceType DeserializeRaceType(string s)
        {
            s = s.Trim().ToUpper();
            if(s == "MSW")
            {
                return RaceType.MSW;
            }
            else if (s == "MCL")
            {
                return RaceType.MCL;
            }
            else if (s == "CLM")
            {
                return RaceType.CLM;
            }
            else if (s == "ALW")
            {
                return RaceType.ALW;
            }
            else if (s == "STAKES")
            {
                return RaceType.STAKES;
            }
            else if (s == "GRADE_3")
            {
                return RaceType.GRADE_3;
            }
            else if (s == "GRADE_2")
            {
                return RaceType.GRADE_2;
            }
            else if (s == "GRADE_1")
            {
                return RaceType.GRADE_1;
            }
            else
            {
                return RaceType.UNKNOWN;
            }
        }

        private string GetRestrictionsAsString()
        {
            var sb = new StringBuilder();
            sb.Append(RestrictedToFemalesOnly ? "1" : "0");
            sb.Append(RestrictedToStateBredsOnly ? "1" : "0");
            sb.Append(WasClaimed ? "1" : "0");
            sb.Append(BlinkersOff ? "1" : "0");
            sb.Append(FirstTimeLasix  ? "1" : "0");
            sb.Append(RestrictedToTwoYearsOnly? "1" : "0");
            sb.Append(RestrictedToThreeYearsOnly ? "1" : "0");
            return sb.ToString();
            
        }

        private string GetAsParsableString()
        {
            return string.Format("{0}, {1},{2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12},{13},{14}",
                                 RaceId,
                                 TrackCode,
                                 RacingDate,
                                 FinishPosition,
                                 Odds,
                                 GoldenFigure,
                                 WinnersGoldenFigure,
                                 TrackCondition,
                                 Distance,
                                 SecondCallPosition,
                                 Enum.GetName(typeof(RaceType),this.RaceType),
                                 PostPosition,
                                 GetRestrictionsAsString(),
                                 FieldSize,
                                 WasTheFavorite ? 1 : 0);
        }


        public void Populate(DbReader dbr)
        {
            if (0 == ++_counter % 100)
            {
                Console.WriteLine("Populated so far: {0}", _counter);
            }

            try
            {
                RaceId = dbr.GetValue<int>("race_id");
                HorseName = dbr.GetValue<string>("horse_name").Trim();
                RacingDate = dbr.GetValue<string>("racing_date");
                TrackCode = dbr.GetValue<string>("track_code");
                FinishPosition = dbr.GetValue<int>("finish_position");
                Odds = dbr.GetValue<double>("odds");
                GoldenFigure = (int)dbr.GetValue<double>("goldenFigure");
                WinnersGoldenFigure = (int)dbr.GetValue<double>("WinnersGoldenFigure");
                TrackCondition = dbr.GetValue<string>("track_condition");
                Distance = (int)dbr.GetValue<double>("distance");
                SecondCallPosition = dbr.GetValue<int>("call_2_position");
                RaceType = MakeRaceType(dbr.GetValue<string>("bris_race_type").Trim().ToUpper());
                RestrictedToFemalesOnly = GetRestrictedToFemalesOnly(dbr.GetValue<string>("age_sex_restrictions").Trim().ToUpper());
                RestrictedToTwoYearsOnly = GetIfRestrictedToTwoYearsOnly(dbr.GetValue<string>("age_sex_restrictions").Trim().ToUpper());
                RestrictedToThreeYearsOnly = GetIfRestrictedToThreeYearsOnly(dbr.GetValue<string>("age_sex_restrictions").Trim().ToUpper());
                RestrictedToStateBredsOnly = GetIfRestrictedToStateBredsOnly(dbr.GetValue<string>("state_bred_flag").Trim().ToUpper());
                PostPosition = dbr.GetValue<int>("post_position");
                WasClaimed = GetWasClaimed(dbr.GetValue<string>("claimed_indicator").Trim().ToUpper());
                BlinkersOff = GetBlinkersOff(dbr.GetValue<string>("equipment_codes").Trim().ToUpper());
                FirstTimeLasix = GetFirstTimeLasix(dbr.GetValue<string>("medication_codes").Trim().ToUpper());
                FieldSize = dbr.GetValue<int>("field_size");
                WasTheFavorite = dbr.GetValue<int>("favorite_flag") == 1;
                Previous = null;
                Next = null;
            }
            catch (Exception e)
            {
                GoldenFigure = -999;
            }
        }

        static private RaceType MakeRaceType(string rt)
        {
            if (rt == "S")
            {
                return RaceType.MSW;
            }
            else if (rt == "M" || rt == "MO")
            {
                return RaceType.MCL;
            }
            else if (rt == "CO" || rt == "AO" || rt == "NO" || rt == "A")
            {
                return RaceType.ALW;
            }
            else if (rt == "C")
            {
                return RaceType.CLM;
            }
            else if (rt == "N")
            {
                return RaceType.STAKES;
            }
            else if (rt == "G1")
            {
                return RaceType.GRADE_1;            
            }
            else if (rt == "G2")
            {
                return RaceType.GRADE_2;            
            }
            else if (rt == "G3")
            {
                return RaceType.GRADE_3;            
            }
            else if (rt == "T" || rt == "R")
            {
                return RaceType.STARTER_ALW;
            }
            else
            {
                return RaceType.UNKNOWN;
            }

        }



        static private bool GetWasClaimed(string claimedIndicator)
        {
            if (claimedIndicator.Length < 1)
                return false;
            return claimedIndicator[0] == 'Y';
        }

        static private bool GetIfRestrictedToStateBredsOnly(string stateRestrictions)
        {
            if (stateRestrictions.Length < 1)
                return false;
            return stateRestrictions[0] == 'S';
        }

        static private bool GetBlinkersOff(string equipmentCodes)
        {
            return equipmentCodes.Contains("O");
        }

        static private bool GetFirstTimeLasix(string medication_codes)
        {
            return medication_codes.Contains("M");
        }

        static private bool GetIfRestrictedToTwoYearsOnly(string ageSexRestrictions)
        {
            if (ageSexRestrictions.Length < 1)
            {
                return false;
            }
            return ageSexRestrictions[0] == 'A';
        }

        static private bool GetIfRestrictedToThreeYearsOnly(string ageSexRestrictions)
        {
            if (ageSexRestrictions.Length < 1)
            {
                return false;
            }
            return ageSexRestrictions[0] == 'B';
        }


        static private bool GetRestrictedToFemalesOnly(string ageSexRestrictions)
        {
            if(ageSexRestrictions.Length !=3)
            {
                return false;
            }

            char c = ageSexRestrictions[2];

            if (c == 'M' || c == 'F')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
