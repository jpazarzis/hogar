using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Hogar;
using Hogar.Algorithms.ANN.InputData;
using Hogar.Parsing;

using Hogar.Research.PickXAnalyzer;

namespace Utilities
{
    class Point
    {
        public double X { get; set;}
        public double Y { get; set;}
    }

    class Program
    {
        static void CreateGoldenFigureFile()
        {
            try
            {
                StarterInfo.CreateGoldenFigureFile(@"C:\Users\John\Desktop\neural_network.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static public void CreateBrisFigureFile(string filename)
        {
            using (var tw = new StreamWriter(filename))
            {
                int count = 0;
                foreach (var ppFilename in DailyCard.ExistingFiles)
                {
                    var card = DailyCard.Load(ppFilename);
                    card.UpdateScratchesFromDb();
                    if (!card.ExistsInDb)
                        continue;
                    card.LoadResultsFromDb();

                    foreach (var race in card.Races)
                    {
                        foreach (var horse in race.Horses)
                        {
                            if (horse.Scratched)
                                continue;


                            tw.Write("{0}\t", horse.ProgramNumber);

                            var figures = horse.CorrespondingBrisHorse.GetBrisSpeedFiguresForRecentFormCycles();
                            tw.Write("{0}\t", figures.Count);

                            foreach (var f in figures)
                            {
                                tw.Write("{0}\t", f);
                            }

                            tw.Write("{0}\t", horse.FinalPosition);
                            tw.Write("{0:0.0}\t", horse.FinalOdds);

                        }
                        tw.WriteLine();
                    }
                    ++count;

                    
                    Console.WriteLine(count);
                    
                    if(count > 100)
                        break;
                    

                }
            }
        }

        static public void TestTokenizer()
        {
            int count = 0;
            foreach (var ppFilename in DailyCard.ExistingFiles)
            {
                ++count;

                
                var sr = new StreamReader(ppFilename);
                var tokenizers = new List<Tokenizer>();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    tokenizers.Add(new Tokenizer(line));

                }
                sr.Close();

                if(0 == count % 100)
                Console.WriteLine(count);

            }
        }


        static public void TestRandomPicks()
        {
            int counter = 0;

            var random = new Random(DateTime.Now.Millisecond);



            double totalBet = 0.0;
            double totalReturn = 0.0;
            double totalNumberOfWinners = 0.0;
            double totalNumberOfPicks = 0.0;
            double totalFieldSize = 0.0;

    

            foreach (var ppFilename in DailyCard.ExistingFiles)
            {
                if (counter > 5000)
                {
                    break;

                }
                if(ppFilename.Contains("BEL"))
                {
                    DailyCard.ResetCache();
                    var card = DailyCard.Load(ppFilename);
                    card.LoadResultsFromDb();

                    if(card.ExistsInDb)
                    {
                        foreach (var race in card.Races)
                        {

                            var horses = from h in race.Horses
                                         where !h.Scratched
                                         select h;

                            var list = horses.ToList();

                            
                            int index = random.Next(list.Count());


                            var selection = list[index];

                            totalBet += 1.0;
                            ++totalNumberOfPicks ;
                            totalFieldSize += race.FieldSize;

    

                            if(selection.FinalPosition == 1)
                            {
                                totalReturn += selection.FinalOdds + 1.0;
                                ++totalNumberOfWinners;
                            }


                            Console.WriteLine(string.Format("  Win% = {0} ROI ={1} IV= {2} Winners = {3} races = {4}", 
                                    totalNumberOfWinners / totalNumberOfPicks, 
                                    totalReturn / totalBet, 
                                    (totalNumberOfWinners / totalNumberOfPicks) / (totalNumberOfPicks / totalFieldSize), 
                                    totalNumberOfWinners,
                                    totalNumberOfPicks));
                            ++counter;
                            

                        }
                    }
                }       
            }
        }

        static public void TestDonkeys()
        {
            int totalStarters = 0;
            int totalDonkeys = 0;
            int winnerDonkeys = 0;
            int numberOfRaces = 0;
            int possibleWinners = 0;
            int possibleWinnersWhoWon = 0;

                
            foreach (var ppFilename in DailyCard.ExistingFiles)
            {
                var card = DailyCard.Load(ppFilename);
                /*
               card.UpdateScratchesFromDb();
                if (!card.ExistsInDb)
                    continue;
                 
                card.LoadResultsFromDb();
                */
                foreach (var race in card.Races)
                {
                  //  race.HandicapBasedInSpeedFigures();
                    ++numberOfRaces;

                    /*
                    foreach (var horse in race.Horses)
                    {
                        if (horse.Scratched)
                            continue;
                        ++totalStarters;
                        if (horse.IsDonkey)
                        {
                            ++totalDonkeys;
                            if (horse.FinalPosition == 1)
                            {
                                ++winnerDonkeys;
                            }    
                        }
                        if(horse.IsPossibleWinner)
                        {
                            ++possibleWinners;
                            if (horse.FinalPosition == 1)
                            {
                                ++possibleWinnersWhoWon;
                            }
                        }
                        
                    }
                     */ 
                }
                
                Console.WriteLine(string.Format("Number Of Races: {0} Starters: {1} Donkeys : {2} Winners {3} PossibleWinners : {4} PWW : {5}",numberOfRaces,totalStarters,totalDonkeys,winnerDonkeys,possibleWinners,possibleWinnersWhoWon));
                if (numberOfRaces > 100)
                    break;
            }
            
        }

        static void TestIfFileLoadsSuccessfully()
        {
            try
            {

                /*
                var list = StarterInfo.LoadCombosFromFile(@"C:\Users\John\Desktop\neural_network.csv", 5,2 );

                int count = 0;
                foreach (var pair in list)
                {
                    Console.WriteLine(string.Format("{0} {1} {2} - {3} {4} {5}", pair.StarterInfo1.HorseName, pair.StarterInfo1.RaceId, pair.StarterInfo1.FinishPosition, pair.StarterInfo2.HorseName, pair.StarterInfo2.RaceId, pair.StarterInfo2.FinishPosition));
                    ++count;
                }
                Console.WriteLine(string.Format("Count = {0}",count));
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                        
        }
        

        static void TestRoi()
        {
            double totalAmountBet = 0;
            double totalAmountWon = 0;
            int numberOfBets = 0;
            int numberOfWinners = 0;

            //string f = @"C:\HorseRacingSoftware\Documents\PastPerformances\Odds\2010\CRC20101121.odds";

            foreach (var filename in DailyCard.ExistingFiles)
            {

                if (filename.Contains("BEL") && Path.GetFileNameWithoutExtension(filename).CompareTo("BEL20100101") == 1)
                {
                    var card = DailyCard.Load(filename);
                    card.UpdateScratchesFromDb();
                    Console.WriteLine(string.Format("{0} Winnings = {1:00} Bet = {2:00} NumberOfBets = {3}  NumberOfWinners = {4} ", filename, totalAmountWon, totalAmountBet, numberOfBets, numberOfWinners));
                    if(!card.ExistsInDb)
                        return;
                    card.LoadResultsFromDb();
                    card.ApplyNeuralNetwork();

                    
                    foreach(var race in card.Races)
                    {
                        if(race.SurfaceWhereTheRaceWasRun == Hogar.Utilities.Surface.Turf)
                            continue;
                        foreach (var horse in race.Horses)
                        {
                            if(horse.Scratched)
                                continue;

                            if (horse.NeuralNetworkOpinion == NeuralNetworkOpinion.IsABet && horse.FinalOdds > 1.0 && horse.FinalOdds < 899)
                            {              
                                ++numberOfBets;
                                totalAmountBet += 2.0;
                                if (horse.FinalPosition == 1)
                                {
                                    totalAmountWon += race.WinnersPayoff;
                                    ++numberOfWinners;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Winnings = {0:00} Bet = {1:00} NumberOfBets = {2}  NumberOfWinners = {3}", totalAmountWon, totalAmountBet, numberOfBets, numberOfWinners);
            
        }


        static double ConvertToDegress(double radians)
        {
            return radians*180.0/Math.PI;
        }

        static double GetSloppe(Point p1, Point p2)
        {
            
            return p2.X != p1.X ? Math.Atan( (p2.Y-p1.Y) / (p2.X-p1.X)) : 0;
        }

        static void TestRaces(IEnumerable<ResearchRace> races)
        {
            int totalHorsesCut = 0;
            int totalHorsesCutWhoWon = 0;
            int total = 0;
            double amountWonFromCutHorses = 0.0;

            int selectionCount = 0;
            int selectionWinners = 0;
            double selectionAmountWon = 0;

            var odds = new List<double>();
            var possibleBets = new List<ResearchHorse>();
            foreach (var race in races)
            {
                var figures = race.GetFigures();
                double average =  figures.Count > 0 ? figures.Average() : 0;
                double stddev = figures.Count > 0 ? Hogar.Utilities.CalculateStdDev(figures) : 0;
                double cutoff = average + stddev;
                possibleBets.Clear();
                

                foreach (var horse in race)
                {
                    ++total;

                    bool possibleWinner = horse.Figure.Any(f => f >= cutoff);

                    if (horse.Figure.Count < 2)
                        continue;

                    if (possibleWinner || horse.Figure.Count < 3)
                    {


                        if(figures[0] < figures[1] && figures[1] > cutoff )
                        {

                            possibleBets.Add(horse);
                            
                        }

                        continue;
                    }
                    else
                    {
                        ++totalHorsesCut;
                        odds.Add(horse.FinalOdds);
                        if (horse.FinalPosition == 1)
                        {
                            ++totalHorsesCutWhoWon;
                            amountWonFromCutHorses += (horse.FinalOdds + 1);
                        }    
                    }
                }

                if (possibleBets.Count > 0)
                {
                    ResearchHorse researchHorse = null;

                    possibleBets.ForEach(h =>
                    {

                        if (null == researchHorse)
                            researchHorse = h;
                        else if (researchHorse.FinalOdds > h.FinalOdds )
                        {
                            researchHorse = h;
                        }
                        
                    });

                    if (null != researchHorse)
                    {
                        ++selectionCount;

                        if (researchHorse.FinalPosition == 1)
                        {
                            ++selectionWinners;
                            selectionAmountWon += researchHorse.FinalOdds + 1;
                        }
                    }

                }

            }

            
            Console.WriteLine("Cut {0} Won {1} Total {2} avgodds = {3:0.0} roi = {4:0.00}", totalHorsesCut, totalHorsesCutWhoWon, total, odds.Average(), amountWonFromCutHorses / totalHorsesCut);


            Console.WriteLine("Selections {0} Won {1} Total {2} roi = {3:0.00}", selectionCount, selectionWinners, total,  selectionAmountWon / selectionCount);
            
        }


        static void Pick3Test()
        {
            foreach (var result in Results.Make(3, "BEL"))
            {
                Console.WriteLine(result);    
            }

        }


        static void Pick4Test()
        {
            foreach (var result in Results.Make(4, "BEL"))
            {
                Console.WriteLine(result);
            }

        }

        static void Main(string[] args)
        {
            UpdatePostPositions.CreateFile();
            return;
            var startTime = DateTime.Now;
           //TestRoi();
            //CreateGoldenFigureFile();
            //TestIfFileLoadsSuccessfully();
           // CreateBrisFigureFile(@"C:\Users\John\Desktop\bris_figures_research.txt");


            //var races = ResearchRace.CreateFromFile(@"C:\Users\John\Desktop\bris_figures_research.txt");

            //Console.WriteLine("Count = {0}", races.Count);
            //TestRaces(races);

            //TestDonkeys();
            //TestRandomPicks();

            //Pick3Test();
           // Pick4Test();

            //TestTokenizer();
            var endTime = DateTime.Now;

            //Console.WriteLine("Duration : {0}",(endTime - startTime).Seconds);
        }

        
    }
}
