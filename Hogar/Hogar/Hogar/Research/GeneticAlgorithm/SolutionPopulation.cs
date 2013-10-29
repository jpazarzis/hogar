using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Research.GeneticAlgorithm
{
   

    public class SolutionPopulation
    {
        private readonly List<Solution> _solutions = new List<Solution>();

        private readonly RaceCollection _races;

        private readonly int _numberOfRacesToLoad;


        public static SolutionPopulation Make(int count, int numberOfRacesToLoad)
        {
            return new SolutionPopulation(count, numberOfRacesToLoad);
        }


        protected SolutionPopulation(int count, int numberOfRacesToLoad)
        {
            _numberOfRacesToLoad = numberOfRacesToLoad;

            for (int i = 0; i < count; ++i)
            {
                _solutions.Add(Solution.MakeRandom());
            }

            _races = new RaceCollection(_numberOfRacesToLoad);

            CreateNextGeneration();
        }

        public void SaveToDb()
        {
            _solutions[0].SaveToDb();
        }

        public double BestFitness
        {
            get { return _solutions[0].Fitness; }
        }

        public Solution BestSolution
        {
            get { return _solutions[0]; }
        }


        public int MutationRate
        {
            get
            {
                return Solution.MutationRate;
            }
            set
            {
                Solution.MutationRate = value;
            }
        }

        public void CreateNextGeneration()
        {
            foreach (var solution in _solutions)
            {
                solution.CalculateFitness(_races);
            }

            _solutions.Sort(
                (solution1, solution2) =>
                    {
                        if (solution1.Fitness == solution2.Fitness)
                        {
                            return 0;
                        }
                        else if (solution1.Fitness < solution2.Fitness)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                );

            GenerateCrossovers();

            PerformMutations();
        }

        private void PerformMutations()
        {
            foreach (var solution in _solutions)
            {
                solution.Mutate();
            }
        }

        private void GenerateCrossovers()
        {
            const int startingIndex = 2;
            for (int i = startingIndex; i < _solutions.Count; i++)
            {
                int index1 = Randomizer.GetNextInteger(0, startingIndex);
                int index2 = Randomizer.GetNextInteger(0, startingIndex);

                _solutions[i] = Solution.CrossOver(_solutions[index1], _solutions[index2]);
            }
        }
    }
}