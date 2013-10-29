using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.Cynthia;

namespace Hogar.Willard
{
    public class WillardSpeedFigure
    {
        public enum CallOfTheRace
        {
            First,
            Second,
            Final
        }

        static public double Make(RaceInfo raceInfo, CynthiaPar cp ,CallOfTheRace callOfTheRace, double weight, double beatenLengths)
        {

            double distanceInFeet =0.0;
            double cynthiaPar = 0.0;
            double timeForTheCall = 0.0;

            switch (callOfTheRace)
            {
                case CallOfTheRace.First:
                    distanceInFeet = raceInfo.FirstCallInFeet;
                    timeForTheCall = raceInfo.FirstCall;
                    cynthiaPar = cp.FirstCall;
                    break;
                case CallOfTheRace.Second:
                    distanceInFeet = raceInfo.SecondCallInFeet;
                    timeForTheCall = raceInfo.SecondCall;
                    cynthiaPar = cp.MidCall;
                    break;
                case CallOfTheRace.Final:
                    distanceInFeet = raceInfo.DistanceOfTheRaceInFeet;
                    timeForTheCall = raceInfo.FinalTime;
                    cynthiaPar = cp.FinalCall;
                    break;
            }

            double d = distanceInFeet;
            double t = timeForTheCall;
            double w = weight;
            double dt = (120.0 - w) * 0.035;

            double unadjustedFigure =  (distanceInFeet / cynthiaPar) - (distanceInFeet - beatenLengths * 10.0) / (t + dt);

            return unadjustedFigure + Adjustment(raceInfo, callOfTheRace);
        }

        static private double Adjustment(RaceInfo ri, CallOfTheRace callOfTheRace)
        {

            double adj = 0.0;

            if (ri.IsStateBred && callOfTheRace == CallOfTheRace.Final)
            {
                adj += -0.2;

            }

            if (ri.IsThreeYearsOnly)
            {
                switch (callOfTheRace)
                {
                    case CallOfTheRace.First:
                        adj += ThreeYearOldAdjusment(ri.Month, ri.Day, callOfTheRace);
                        break;
                    case CallOfTheRace.Second:
                        adj += ThreeYearOldAdjusment(ri.Month, ri.Day, callOfTheRace);
                        break;
                    case CallOfTheRace.Final:
                        adj += ThreeYearOldAdjusment(ri.Month, ri.Day, callOfTheRace);
                        break;
                }
            }
            else if (ri.IsTwoYearsOnly)
            {
                return 0.0;
            }
            
            if (ri.IsFemaleOnly)
            {
                switch (callOfTheRace)
                {
                    case CallOfTheRace.First:
                        adj += -0.14;
                        break;
                    case CallOfTheRace.Second:
                        adj += -0.22;
                        break;
                    case CallOfTheRace.Final:
                        adj += -0.45;
                        break;
                }
            }
        

            return adj;
        }

        static private double ThreeYearOldAdjusment(int month, int day, CallOfTheRace callOfTheRace)
        {
            if(month <= 4 && day < 15)
            {
                switch (callOfTheRace)
                {
                    case CallOfTheRace.First:
                        return -0.14;
                        
                    case CallOfTheRace.Second:
                        return -0.22;
                        
                    case CallOfTheRace.Final:
                        return -0.45;        

                    default:
                        return 0.0;
                }
                
            }
            else if (month <= 7 && day < 1)
            {
                switch (callOfTheRace)
                {
                    case CallOfTheRace.First:
                        return -0.14 * 0.666;

                    case CallOfTheRace.Second:
                        return -0.22 * 0.666; 

                    case CallOfTheRace.Final:
                        return -0.45 * 0.666;

                    default:
                        return 0.0;
                }
            }
            else if (month <= 11 && day < 1)
            {
                switch (callOfTheRace)
                {
                    case CallOfTheRace.First:
                        return -0.14 * 0.3333;

                    case CallOfTheRace.Second:
                        return -0.22 * 0.3333;

                    case CallOfTheRace.Final:
                        return -0.45 * 0.3333;

                    default:
                        return 0.0;
                }
            }
            else
            {
                return 0.0;
            }
        }

    }
}
