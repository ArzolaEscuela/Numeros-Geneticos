using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Numeros_Geneticos
{
    public enum EOperations
    {
        DoNothing = 0,
        AddOrSubtract = 1,
        MultiplyOrDivide = 2,
        SquareOrSquareRoot = 3
    }

    public struct Result
    {
        public readonly int value;
        public readonly int differenceFromTarget;
        public readonly List<int> mutatedIndexes;

        public Result(int value, int differenceFromTarget, List<int> mutatedIndexes)
        {
            this.value = value;
            this.differenceFromTarget = differenceFromTarget;
            this.mutatedIndexes = mutatedIndexes;
        }
    }

    public class Individual
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        private Generation _generation;
        private Color _drawColor;
        private readonly Chromosome[] _chromosomes;

        private List<Result> _obtainedResults = new List<Result>();

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        public Color DrawColor => _drawColor;
        public Generation Generation => _generation;

        // Chromosome Values
        private int TotalChromosomes => SettingsManager.TotalChromosomes;
        private int SecondaryMutationChromosomesAmount => SettingsManager.SecondaryMutationChromosomesAmount;
        private int InitialNumberChromosomesAmount => SettingsManager.InitialNumberChromosomesAmount;

        // Elitism Values
        private float ElitismChromosomeChance => SettingsManager.ElitismChromosomeChance;

        // Mutation Values
        private float MutationChance => SettingsManager.MutationChance;
        private int MaxMutableChromosomes => SettingsManager.MaxMutableChromosomes;

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        #region Generate Result

        public void GenerateResult()
        {
            // Set the initial value.
            int result = _chromosomes.GetSubArray(SecondaryMutationChromosomesAmount,
                InitialNumberChromosomesAmount).GetIntFromChromosomeArray();

            // Calculate the amount of chromosomes that will be used as operations.
            int initialOffset = SecondaryMutationChromosomesAmount + InitialNumberChromosomesAmount;
            int amountOfOperations = TotalChromosomes - initialOffset;

            // Copy the initial operations list
            bool[] operations = new bool[amountOfOperations];
            for (int i = initialOffset; i < TotalChromosomes; i++) { operations[i - initialOffset] = _chromosomes[i].Usable; }

            // Mutate some of the operations if luck demands it.
            int amountToMutate = RandomManager.RandomInt(0, _chromosomes.GetSubArray(0,
                SecondaryMutationChromosomesAmount).GetIntFromChromosomeArray());
            List<int> mutatedIndexes = new List<int>();
            for (int i = 0; i < amountToMutate; i++)
            {
                int mutatedIndex = RandomManager.RandomInt(0, amountOfOperations - 1);
                operations[mutatedIndex] = !operations[mutatedIndex];
                mutatedIndexes.Add(mutatedIndex + initialOffset);
            }

            // Make the concrete operations
            Dictionary<EOperations, int> operationCounters = new Dictionary<EOperations, int>();
            int operationsUsed = 1;
            for (int i = 0; i < amountOfOperations; i += 2)
            {
                // Select Operation
                EOperations nextOperation = EOperations.DoNothing;
                bool useFirstOperation = operations[i + 1];

                if (operations[i])
                {
                    if (operationsUsed % 5 == 0)
                    {
                        nextOperation = EOperations.SquareOrSquareRoot;
                        operationsUsed = 0;
                    }
                    else if (operationsUsed % 2 == 0)
                    {
                        nextOperation = EOperations.MultiplyOrDivide;
                    }
                    else
                    {
                        nextOperation = EOperations.AddOrSubtract;
                    }
                }
                operationsUsed++;

                try
                {
                    switch (nextOperation)
                    {
                        case EOperations.DoNothing: continue;
                        case EOperations.AddOrSubtract:
                            result += (useFirstOperation ? 1 : -1) *
                                      operationCounters.GetNextMagnitude(EOperations.AddOrSubtract);
                            continue;
                        case EOperations.MultiplyOrDivide:
                            int magnitude = operationCounters.GetNextMagnitude(EOperations.MultiplyOrDivide);
                            if (useFirstOperation) { result *= magnitude; } else { result /= magnitude; }
                            continue;
                        case EOperations.SquareOrSquareRoot:
                            if (useFirstOperation) { result = result * result; } else { result = (int)Math.Sqrt(result); }
                            continue;
                        default:
                            throw new NotImplementedException($@"It was attempted to execute an unsupported operation type: {nextOperation}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($@"An error has occurred attempting to finish an operation, operation skipped. Full Stack: {e}");
                }
            }

            _obtainedResults.Add(new Result(result, Generation.TargetValue - result, mutatedIndexes));
        }

        #endregion Generate Result

        #region Mutation

        public void SimulateMutation()
        {
            int totalChanges = 0;
            for (int i = 0; i < TotalChromosomes; i++)
            {
                if (totalChanges > MaxMutableChromosomes) { break; }
                if (!RandomManager.EvaluatePercentage(MutationChance)) { continue; }

                _chromosomes[i] = new Chromosome(this, !_chromosomes[i].Usable);
                totalChanges++;
            }
        }

        #endregion Mutation

        #region Initialization

        private void Initialize(Generation generation)
        {
            _generation = generation;

            // Generate Individual Color
            _drawColor = Color.White;
            while (_drawColor.IsSimilarToColor(Color.White))
            {
                _drawColor = Color.FromArgb(255, RandomManager.RandomInt(0, 255),
                    RandomManager.RandomInt(0, 255), RandomManager.RandomInt(0, 255));
            }
        }

        public Individual(Generation generation, Individual father, bool wasFatherSelectedByElitism,
            Individual mother, bool wasMotherSelectedByElitism)
        {
            Initialize(generation);

            _chromosomes = new Chromosome[TotalChromosomes];



            // Initialize Secondary Mutation Chromosomes
            Chromosome[] parentChromosomes = new Chromosome[SecondaryMutationChromosomesAmount];

            bool getFromFather = false;
            for (int i = 0; i < SecondaryMutationChromosomesAmount; i++)
            {
                parentChromosomes[i] = (getFromFather ? father : mother)._chromosomes[i];
                getFromFather = !getFromFather;
            }
            parentChromosomes = parentChromosomes.RandomizeArray();

            for (int i = 0; i < SecondaryMutationChromosomesAmount; i++) { _chromosomes[i] = parentChromosomes[i]; }



            // Divide The Rest Of The Chromosomes Based On Elitism
            float getChromosomeFromFatherChance = wasFatherSelectedByElitism == wasMotherSelectedByElitism ? 0.5f
                : wasFatherSelectedByElitism ? ElitismChromosomeChance : 1f - ElitismChromosomeChance;

            for (int i = SecondaryMutationChromosomesAmount; i < TotalChromosomes; i++)
            {
                _chromosomes[i] = (RandomManager.EvaluatePercentage(getChromosomeFromFatherChance) ? father : mother)._chromosomes[i];
            }
        }

        public Individual(Generation generation)
        {
            Initialize(generation);

            // Initialize Chromosomes
            _chromosomes = new Chromosome[TotalChromosomes];
            for (int i = 0; i < TotalChromosomes; i++)
            {
                _chromosomes[i] = new Chromosome(this);
            }
        }

        #endregion Initialization
    }
}