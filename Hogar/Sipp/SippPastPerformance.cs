// *************************************************************
// 
//                           Written By John Pazarzis
// 
// *************************************************************
// 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace Sipp
{
    public class SippPastPerformance
    {
        public enum SurfaceType
        {
            Dirt,
            InnerDirt,
            Turf,
            InnerTurf
        }

        

        public SurfaceType SurfaceAndDistanceType
        {
            get
            {
                SurfaceType surfaceType = SurfaceType.Dirt;

                if (Surface.Length > 0)
                {
                    if (Surface.ToUpper() == "T")
                    {
                        surfaceType = SurfaceType.Turf;
                    }
                    else if (Surface.ToUpper() == "IT")
                    {
                        surfaceType = SurfaceType.InnerTurf;
                    }
                    else if (Surface.ToUpper() == "ID")
                    {
                        surfaceType = SurfaceType.InnerDirt;
                    }
                    else
                    {
                        surfaceType = SurfaceType.Dirt;
                    }
                }


                return surfaceType;
            }
        }


        public List<SippPastPerformance> RunAgainst
        {
            get 
            { 
                if(null == Parent)
                {
                    throw new Exception("Sipp ERROR -> Sorry, you must first assign parent horse...");
                }

                var list = new List<SippPastPerformance>();

                foreach (var horse in Parent.Parent)
                {
                    if(horse == Parent || horse.Scratched)
                        continue;


                    foreach (var pp in horse.PastPerformances)
                    {
                        if(pp.RacingDate != RacingDate)
                            continue;

                        if(pp.TrackCode != TrackCode)
                            continue;

                        if(pp.RaceNumber != RaceNumber)
                            continue;

                        list.Add(pp);
                    }
                }

                return list;
            }
        }
        
        internal void AddToXmlNode(XmlDocument doc, XmlElement node)
        {
            var pp = doc.CreateElement("past-performance");

            pp.SetAttribute("days-since-previous-race", DaysSincePreviousRace.ToString());
            pp.SetAttribute("days-since-todays-race", DaysSinceTodaysRace.ToString());
            pp.SetAttribute("racing-date", string.Format("{0}{1:00}{2:00}", RacingDate.Year, RacingDate.Month, RacingDate.Day));
            pp.SetAttribute("race-number", RaceNumber.ToString());
            pp.SetAttribute("track-code", TrackCode);
            pp.SetAttribute("track-condition", TrackCondition);
            pp.SetAttribute("distance", Distance);
            pp.SetAttribute("distance-in-yards", DistanceInYards.ToString());
            pp.SetAttribute("about-distance-flag", AboutDistanceFlag ? "1" : "0");
            pp.SetAttribute("surface", Surface);
            pp.SetAttribute("race-condition", RaceCondition);
            pp.SetAttribute("first-call", FirstCall);
            pp.SetAttribute("second-call", SecondCall);
            pp.SetAttribute("third-call", ThirdCall);
            pp.SetAttribute("final-time", FinalTime);
            pp.SetAttribute("winners-final-time", string.Format("{0}",WinnersFinalTime));
            pp.SetAttribute("this-horse-final-time", string.Format("{0}",ThisHorseFinalTime));
            pp.SetAttribute("post-position", PostPosition.ToString());
            pp.SetAttribute("first-call-position", FirstCallPosition);
            pp.SetAttribute("second-call-position", SecondCallPosition);
            pp.SetAttribute("third-call-position", ThirdCallPosition);
            pp.SetAttribute("final-position", FinalPosition);
            pp.SetAttribute("first-call-lengths-behind", FirstCallLengthsBehind);
            pp.SetAttribute("second-call-lengths-behind", SecondCallLengthsBehind);
            pp.SetAttribute("third-call-lengths-behind", ThirdCallLengthsBehind);
            pp.SetAttribute("final-lengths-behind", FinalLengthsBehind);
            pp.SetAttribute("track-variant", TrackVariant.ToString());
            pp.SetAttribute("speed-figure", SpeedFigure.ToString());
            pp.SetAttribute("jockey", Jockey);
            pp.SetAttribute("weight", MedicationWeightEquipment);
            pp.SetAttribute("odds", Odds);
            pp.SetAttribute("field-size", FieldSize.ToString());
            pp.SetAttribute("winners-name", WinnersName);
            pp.SetAttribute("second-name", SecondPlaceFinisherName);
            pp.SetAttribute("third-name", ThirdPlaceFinisherName);

            node.AppendChild(pp);
        }

        
        public int DaysSincePreviousRace { get; set; }
        public int DaysSinceTodaysRace { get; set; }
        public DateTime RacingDate { get; set; }
        public int RaceNumber { get; set; }
        public Bitmap RaceReplay { get { return Properties.Resources.video; } }
        public Bitmap RunAgainstIcon { get { return RunAgainst.Count > 0 ? Properties.Resources.key_16 : Properties.Resources.no_run_against_16; } }
        public string TrackCode { get; set; }
        public string TrackCondition { get; set; }
        public string Distance { get; set; }
        public int DistanceInYards { get; set; }
        public bool AboutDistanceFlag { get; set; }
        public string Surface { get; set; }
        public string RaceCondition { get; set; }
        public string FirstCall { get; set; }
        public string SecondCall { get; set; }
        public string ThirdCall { get; set; }
        public string FinalTime { get; set; }
        public double WinnersFinalTime { get; set; }
        public double ThisHorseFinalTime { get; set; }
        public int PostPosition { get; set; }
        public string FirstCallPosition { get; set; }
        public string FirstCallLengthsBehind { get; set; }
        public string SecondCallPosition { get; set; }
        public string SecondCallLengthsBehind { get; set; }
        public string ThirdCallPosition { get; set; }
        public string ThirdCallLengthsBehind { get; set; }
        public string FinalPosition { get; set; }
        public string FinalLengthsBehind { get; set; }
        public int SpeedFigure { get; set; }
        private int _normalFigure = 5;
        public int NormalFigure { get; set; }
        public Color NormalFigureColor { get; private set; }

        public int TrackVariant { get; set; }
       
        public string Jockey { get; set; }
        public string MedicationWeightEquipment { get; set; }
        public string Odds { get; set; }
        public int FieldSize { get; set; }
        public string WinnersName{ get; set; }
        public string SecondPlaceFinisherName{ get; set; }
        public string ThirdPlaceFinisherName { get; set; }
        public SippHorse Parent { get; set; }
        

        internal void CaclulateNormalFigure(double mean, double stdev)
        {
            NormalFigure = (int)(Math.Round( NormalDistribution.GetProbabilityOfMoreThanThis(mean, stdev, SpeedFigure),2) * 100) ;

            double f = (double) SpeedFigure;


            if (f <= mean - 2.0 * stdev)
            {
                NormalFigure = 5;
                NormalFigureColor = Color.DarkGray;
            }
            else if (f <= mean - 1.0 * stdev)
            {
                NormalFigure = 4;
                NormalFigureColor = Color.Gray;
            }
                
            else if (f <= mean)
            {
                NormalFigure = 3;
                NormalFigureColor = Color.LightCyan;
            }
                
            else if (f <= mean + 1.0 * stdev)
            {
                NormalFigure = 2;
                NormalFigureColor = Color.Cyan;
            }
                
            else if (f <= mean + 2.0 * stdev)
            {
                NormalFigure = 1;
                NormalFigureColor = Color.Pink;
            }
                
            else
            {
                NormalFigure = 0;
                NormalFigureColor = Color.Red;
            }
            
        }
    }
}