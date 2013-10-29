using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.Algorithms.ANN.InputData
{
    public partial class StarterInfo
    {
        


        private StarterInfo[] GetPreviousPerformances(int count)
        {
            var array = new StarterInfo[count];

            var si = Previous;

            for (int i = 0; i < count; ++i)
            {
                array[i] = si;

                if (null != si)
                {
                    si = si.Previous;
                }
            }

            return array;
        }


        static private double NormalizeTrackCondition(StarterInfo si)
        {
            return si.TrackCondition.Trim().ToUpper() == "FT" ? 0.3 : 0.7;
        }


        static private double NormalizeDistance(StarterInfo si)
        {
            return si.Distance < 1780 ? 0.3 : 0.7;
        }

        static private double NormalizeOdds(StarterInfo si)
        {
            if (si.WasTheFavorite)
                return 0.9;

            if (si.Odds <= 3.0)
            {
                return 0.6;
            }
            else if (si.Odds <= 5.0)
            {
                return 0.2;
            }
            else
            {
                return 0.02;
            }
            
        }


        static private double NormalizeDaysOff(StarterInfo si)
        {
            int layoff = si.LayoffInDays;

            if (layoff == 0)
                return 0.05;
            else if (layoff < 10)
                return 0.8;
            else if (layoff < 30)
                return 0.5;
            else if (layoff < 80)
                return 0.25;
            else if (layoff < 120)
                return 0.15;
            else 
                return 0.10;
            
        }

        static private double NormalizePosition(int position)
        {
            if (position == 1)
            {
                return 0.82;
            }
            else if (position >= 2 && position <= 3)
            {
                return 0.5;
            }
            else if (position >= 4 && position <= 5)
            {
                return 0.32;
            }
            else
            {
                return 0.20;
            }
        }

        static private double NormalizeGoldenFigure(double figure, double min, double max)
        {

            Debug.Assert(min <= figure);
            Debug.Assert(max >= figure);
            if (max == min)
                return 1.0;

            //return (figure - min)/(max - min);


            return figure*(figure - min)/(max*max - min*max);

            /*
            if (figure == max)
                max = max + 1;

            double a = (figure - min)/ (max - figure);

            return (0.8*a + 0.1)/(1 + a);
            */
        }

        static private double NormalizeGoldenFigure(double figure, double min, double max, double average)
        {

            if (figure <= (min + average) / 2.0)
                return 0.02;


            if (figure <= average)
                return 0.06;


            if (figure <= (max + average) / 2.0)
                return 0.12;

            if (figure <= (max + average) / 1.2)
                return 0.40;


            
            return 0.95;


            if(figure > max - average)

            Debug.Assert(min <= figure);
            Debug.Assert(max >= figure);
            if (max == min)
                return 1.0;

            //return (figure - min)/(max - min);


            return figure * (figure - min) / (max * max - min * max);

            /*
            if (figure == max)
                max = max + 1;

            double a = (figure - min)/ (max - figure);

            return (0.8*a + 0.1)/(1 + a);
            */
        }


        static private void PopulateNormalizedData(StarterInfo starterInfo, List<double> normalizedData, double min, double max, int count)
        {
            starterInfo.GetPreviousPerformances(count).ToList().ForEach(
                si =>
                {
                    normalizedData.Add(NormalizeGoldenFigure(si.GoldenFigure, min, max));
                    normalizedData.Add(NormalizeGoldenFigure(si.WinnersGoldenFigure, min, max));
                    normalizedData.Add(NormalizeTrackCondition(si));
                    normalizedData.Add(NormalizeDistance(si));
                    normalizedData.Add(NormalizePosition(si.SecondCallPosition));
                    normalizedData.Add(NormalizePosition(si.FinishPosition));
                    normalizedData.Add(NormalizeOdds(si));
                    normalizedData.Add(NormalizeDaysOff(si));
                    normalizedData.Add(NormalizeRaceType(si));
                    normalizedData.Add(NormalizePostPosition(si));
                     /* 
                    normalizedData.Add(NormalizeBoolean(si.RestrictedToFemalesOnly));
                    normalizedData.Add(NormalizeBoolean(si.RestrictedToStateBredsOnly));
                    normalizedData.Add(NormalizeBoolean(si.WasClaimed));
                    normalizedData.Add(NormalizeBoolean(si.BlinkersOff));
                    normalizedData.Add(NormalizeBoolean(si.FirstTimeLasix));
                    normalizedData.Add(NormalizeBoolean(si.RestrictedToTwoYearsOnly));
                    normalizedData.Add(NormalizeBoolean(si.RestrictedToThreeYearsOnly));
                     */ 
                });
        }

        static private void PopulateNormalizedData(StarterInfo starterInfo, List<double> normalizedData, double min, double max, double average, int count)
        {
            starterInfo.GetPreviousPerformances(count).ToList().ForEach(
                si =>
                {
                    normalizedData.Add(NormalizeGoldenFigure(si.GoldenFigure, min, max, average));
                   // normalizedData.Add(NormalizeGoldenFigure(si.WinnersGoldenFigure, min, max, average));
                    normalizedData.Add(NormalizeTrackCondition(si));
                   // normalizedData.Add(NormalizeOdds(si));
                    normalizedData.Add(NormalizeDistance(si));
                    //normalizedData.Add(NormalizePosition(si.FinishPosition));

                    /*
                    normalizedData.Add(NormalizePosition(si.SecondCallPosition));
                    normalizedData.Add(NormalizeDaysOff(si));
                    normalizedData.Add(NormalizeRaceType(si));
                    normalizedData.Add(NormalizePostPosition(si));
                      
                    
                   normalizedData.Add(NormalizeBoolean(si.RestrictedToFemalesOnly));
                   normalizedData.Add(NormalizeBoolean(si.RestrictedToStateBredsOnly));
                   normalizedData.Add(NormalizeBoolean(si.WasClaimed));
                   normalizedData.Add(NormalizeBoolean(si.BlinkersOff));
                   normalizedData.Add(NormalizeBoolean(si.FirstTimeLasix));
                   normalizedData.Add(NormalizeBoolean(si.RestrictedToTwoYearsOnly));
                   normalizedData.Add(NormalizeBoolean(si.RestrictedToThreeYearsOnly));
                    */
                });
        }

        static double NormalizeRaceType(StarterInfo si)
        {
            switch(si.RaceType)
            {
                case RaceType.GRADE_1:
                case RaceType.GRADE_2:
                case RaceType.GRADE_3:
                case RaceType.STAKES:
                    return 0.9;
                case RaceType.ALW:
                    return 0.67;
                case RaceType.MSW:
                    return 0.52;
                case RaceType.CLM:
                    return 0.17;
                case RaceType.MCL:
                    return 0.02;
                default:
                    return 0.02;
            }
        }

        static double NormalizePostPosition(StarterInfo si)
        {
            if(si.PostPosition == 1)
            {
                return 0.8;
            }
            else if (si.PostPosition == 2)
            {
                return 0.7;
            }
            else if (si.PostPosition >= 10)
            {
                return 0.1;
            }
            else if (si.PostPosition >= 8)
            {
                return 0.2;
            }
            else 
            {
                return 0.3;
            }


        }

        static double NormalizeBoolean(bool v)
        {
            return v ? 0.90 : 0.05;
        }

       


        // Used for training and back testing when the left and right StarterInfo nodes
        // are both pointing to the race we use to test.
        // It is using the previous StarterInfo's for left and right to initialize the
        // input of the neuron network......
        static internal List<double> NormalizedInputForWinnerDetection(List<StarterInfo> starters, int count)
        {
            var input = new List<double>();
            
            var gf = new List<double>();

            // Calculate min - max of GoldenFigure to be used for normalization
            foreach (var s in starters)
            {
                s.GetPreviousPerformances(count).ToList().ForEach(si => gf.Add(si.GoldenFigure));
                s.GetPreviousPerformances(count).ToList().ForEach(si => gf.Add(si.WinnersGoldenFigure));
            }
            double min = gf.Min();
            double max = gf.Max();

            // Add Past Performances
            foreach (var s in starters)
            {
                PopulateNormalizedData(s, input, min, max, count);

                // Add Today's race info
                input.Add(NormalizeDaysOff(s));
                input.Add(NormalizePostPosition(s));
            }

            // Add Today's race distance
            input.Add(NormalizeDistance(starters[0]));



            
            
            /*
            input.Add(NormalizeBoolean(left.FirstTimeLasix));
            input.Add(NormalizeBoolean(right.FirstTimeLasix));
            input.Add(NormalizeBoolean(left.BlinkersOff));
            input.Add(NormalizeBoolean(right.BlinkersOff));
            input.Add(NormalizeRaceType(left));
            input.Add(NormalizeBoolean(left.RestrictedToFemalesOnly));
            input.Add(NormalizeBoolean(left.RestrictedToStateBredsOnly));
            input.Add(NormalizeBoolean(left.RestrictedToTwoYearsOnly));
            input.Add(NormalizeBoolean(left.RestrictedToThreeYearsOnly));
            */

            return input;
        }

        static internal List<double> NormalizedInputToChooseBetweenFirstAndSecondFavorite(StarterInfo favorite, StarterInfo secondFavorite, StarterInfo thirdFavorite, int ppCount)
        {
            var input = new List<double>();
            var gf = new List<double>();
            favorite.GetPreviousPerformances(ppCount).ToList().ForEach(si => gf.Add(si.GoldenFigure));
           // favorite.GetPreviousPerformances(ppCount).ToList().ForEach(si => gf.Add(si.WinnersGoldenFigure));
            secondFavorite.GetPreviousPerformances(ppCount).ToList().ForEach(si => gf.Add(si.GoldenFigure));
            //secondFavorite.GetPreviousPerformances(ppCount).ToList().ForEach(si => gf.Add(si.WinnersGoldenFigure));


            thirdFavorite.GetPreviousPerformances(ppCount).ToList().ForEach(si => gf.Add(si.GoldenFigure));
            double min = gf.Min();
            double max = gf.Max();
            PopulateNormalizedData(favorite, input, min, max, gf.Average(),ppCount);
            PopulateNormalizedData(secondFavorite, input, min, max, gf.Average(), ppCount);
            PopulateNormalizedData(thirdFavorite, input, min, max, gf.Average(), ppCount);
            
            input.Add(NormalizeDaysOff(favorite));
            input.Add(NormalizeDaysOff(secondFavorite));
            input.Add(NormalizeDaysOff(thirdFavorite));

            
            //input.Add(NormalizeOdds(favorite));
            //input.Add(NormalizeOdds(secondFavorite));
            //input.Add(NormalizeOdds(thirdFavorite));

            //input.Add(NormalizePostPosition(favorite));
            //input.Add(NormalizePostPosition(secondFavorite));
            //input.Add(NormalizePostPosition(thirdFavorite));
            //input.Add(NormalizeDistance(favorite));
            return input;
        }

        static internal List<double> NormalizedInputForImprovementDetection(StarterInfo si, int ppCount)
        {
            var input = new List<double>();
            var gf = new List<double>();
            si.GetPreviousPerformances(ppCount).ToList().ForEach(si2 => gf.Add(si2.GoldenFigure));
            double min = gf.Min();
            double max = gf.Max();
            PopulateNormalizedData(si, input, min, max, ppCount);
            input.Add(NormalizeDaysOff(si));
            input.Add(NormalizePostPosition(si));
            input.Add(NormalizeDistance(si));
            return input;
        }


        static private void PopulateNormalizedDataForMemoryLearning(StarterInfo starterInfo, List<double> input, int count)
        {
            starterInfo.GetPreviousPerformances(count).ToList().ForEach(
                            si =>
                            {
                                input.Add(NormalizeTrackCondition(si));
                                input.Add(NormalizeOdds(si));
                                input.Add(NormalizeDistance(si));
                                input.Add(NormalizePosition(si.FinishPosition));
                                input.Add(NormalizePosition(si.SecondCallPosition));
                                input.Add(NormalizeDaysOff(si));
                                input.Add(NormalizeRaceType(si));
                                input.Add(NormalizePostPosition(si));
                                input.Add(NormalizeBoolean(si.RestrictedToFemalesOnly));
                                input.Add(NormalizeBoolean(si.RestrictedToStateBredsOnly));
                                input.Add(NormalizeBoolean(si.WasClaimed));
                                input.Add(NormalizeBoolean(si.BlinkersOff));
                                input.Add(NormalizeBoolean(si.FirstTimeLasix));
                                input.Add(NormalizeBoolean(si.RestrictedToTwoYearsOnly));
                                input.Add(NormalizeBoolean(si.RestrictedToThreeYearsOnly));
                            });            
        }


        static internal List<double> NormalizedInputForMemoryLearning(StarterInfo si, int ppCount)
        {
            var input = new List<double>();

            if (si.CountPreceding >= ppCount)
            {
                si.GetPreviousPerformances(ppCount).ToList().ForEach(si2 => input.Add(si2.GoldenFigure));

                double min = input.Min();
                double max = input.Max();

                for (int i = 0; i < input.Count; ++i)
                {
                    input[i] = (input[i] - min) / max;
                }

                PopulateNormalizedDataForMemoryLearning(si, input, ppCount);
                input.Add(NormalizeDaysOff(si));
                input.Add(NormalizePostPosition(si));
                input.Add(NormalizeDistance(si));
                input.Add(NormalizeBoolean(si.RestrictedToFemalesOnly));
                input.Add(NormalizeBoolean(si.RestrictedToStateBredsOnly));
                input.Add(NormalizeBoolean(si.WasClaimed));
                input.Add(NormalizeBoolean(si.BlinkersOff));
                input.Add(NormalizeBoolean(si.FirstTimeLasix));
                input.Add(NormalizeBoolean(si.RestrictedToTwoYearsOnly));
                input.Add(NormalizeBoolean(si.RestrictedToThreeYearsOnly));
                double desiredValue = si.GoldenFigure > max ? 1.0 : 0.0;
                input.Add(desiredValue);    
            }
            
            return input;
        }
        


        // int numberOfPPToUse:  The number of past performances to be used for the NN

        // int combinationLength : How many starters will be used for every comparison
        // We can use 2 or more starters as the comparisson unit
 
        static internal int GetNumberOfInputsForWinnerDetection(int numberOfPPToUse, int combinationLength)
        {
            const int dataPointsPerStarter = 10;
            return (numberOfPPToUse * dataPointsPerStarter + 2) * combinationLength + 1;
        }

        static internal int GetNumberOfInputsForChooseBetweenFirstAndSecondFavorite(int ppCount)
        {
            const int dataPointsPerStarter = 3;

            return (3* ppCount ) * dataPointsPerStarter + 3;
            
        }

        static internal int GetNumberOfInputsForImprovementDetection(int ppCount)
        {
            const int dataPointsPerStarter = 10;

            return ppCount * dataPointsPerStarter + 3;

        }
    }
}
