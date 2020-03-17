using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Numeros_Geneticos
{
    public enum EOperations
    {
        DoNothing = 0,
        AddOrSubtract = 1,
        MultiplyOrDivide = 2,
        SquareOrSquareRoot = 3
    }

    public struct IndividualRunResults
    {
        public readonly Individual tester;
        public readonly int result;
        public readonly int differenceFromTarget;
        public readonly HashSet<int> mutatedOperationIndexes;

        public readonly string[] operationsSequence;

        public IndividualRunResults(Individual tester, int result, int differenceFromTarget, HashSet<int> mutatedOperationIndexes)
        {
            this.tester = tester;
            this.result = result;
            this.differenceFromTarget = differenceFromTarget;
            this.mutatedOperationIndexes = mutatedOperationIndexes;

            bool[] operations = tester.UnMutatedOperations;
            operationsSequence = new string[Individual.AmountOfEntriesInResults];
            operationsSequence[0] = $"{tester.InitialValue}";
            int index = 1;

            int operationsCount = operations.Length;
            int operationsUsed = 1;
            Dictionary<EOperations, int> operationCounters = new Dictionary<EOperations, int>();
            for (int i = 0; i < operationsCount; i += 2)
            {
                index++;
                bool doNextOperation = operations[i];
                bool useFirstOperation = operations[i + 1];
                bool mutatedResult = false;

                if (mutatedOperationIndexes.Contains(i))
                {
                    doNextOperation = !doNextOperation;
                    mutatedResult = true;
                }

                if (mutatedOperationIndexes.Contains(i + 1))
                {
                    useFirstOperation = !useFirstOperation;
                    mutatedResult = true;
                }

                EOperations nextOperation = EOperations.DoNothing;

                if (doNextOperation)
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

                string resultString = string.Empty;
                try
                {
                    switch (nextOperation)
                    {
                        case EOperations.DoNothing: continue;
                        case EOperations.AddOrSubtract:
                            char asSign = useFirstOperation ? '+' : '-';
                            resultString += $"{asSign}{operationCounters.GetNextMagnitude(EOperations.AddOrSubtract)}";
                            break;
                        case EOperations.MultiplyOrDivide:
                            char mdSign = useFirstOperation ? '*' : '/';
                            resultString +=
                                $"{mdSign}{operationCounters.GetNextMagnitude(EOperations.MultiplyOrDivide)}";
                            break;
                        case EOperations.SquareOrSquareRoot:
                            string ssSign = useFirstOperation ? "²" : "√";
                            resultString += $"{ssSign}";
                            break;
                        default:
                            throw new NotImplementedException(
                                $@"It was attempted to execute an unsupported operation type: {nextOperation}");
                    }

                    if (mutatedResult)
                    {
                        resultString += " (Mutation)";
                    }

                    operationsSequence[index] = resultString;
                }
                catch { continue; }
            }

            string sign = tester.Sign ? "*1 (Sign)" : "*-1 (Sign)";

            operationsSequence[operationsSequence.Length - 2] = sign;
            operationsSequence[operationsSequence.Length - 1] = $"={result}";
        }


        public void PopulateWithIndividualInfo(PictureBox toDrawAt, DataGridView toWriteAt, int index)
        {

        }

        public override string ToString() => $"[Tester: {tester.Name}, Result: {result}, Distance From Target: {differenceFromTarget}]";
    }

    public class Individual
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        private Generation _generation;
        private Color _drawColor;
        private string _name;

        private readonly Chromosome[] _chromosomes;

        private static int totalIndividuals = 0;

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        public Color DrawColor => _drawColor;
        public Generation Generation => _generation;
        public string Name => _name;

        // Chromosome Values
        private static int TotalChromosomes => SettingsManager.TotalChromosomes;
        private static int SecondaryMutationChromosomesAmount => SettingsManager.SecondaryMutationChromosomesAmount;
        private static int InitialNumberChromosomesAmount => SettingsManager.InitialNumberChromosomesAmount;

        // Elitism Values
        private float ElitismChromosomeChance => SettingsManager.ElitismChromosomeChance;

        // Mutation Values
        private float MutationChance => SettingsManager.MutationChance;
        private int MaxMutableChromosomes => SettingsManager.MaxMutableChromosomes;

        public int InitialValue => _chromosomes.GetSubArray(SecondaryMutationChromosomesAmount,
            InitialNumberChromosomesAmount).GetIntFromChromosomeArray();

        private static int InitialOffset => SecondaryMutationChromosomesAmount + InitialNumberChromosomesAmount;
        private static int AmountOfOperations => TotalChromosomes - InitialOffset - 1;

        public static int AmountOfEntriesInResults => (AmountOfOperations / 2) + 3;// Add slots for the initial value, the result, and the sign.

        public bool[] UnMutatedOperations
        {
            get
            {
                bool[] operations = new bool[AmountOfOperations];
                for (int i = InitialOffset; i < TotalChromosomes - 1; i++) { operations[i - InitialOffset] = _chromosomes[i].Usable; }
                return operations;
            }
        }

        public bool Sign => _chromosomes[SettingsManager.TotalChromosomes - 1].Usable;

        public IndividualRunResults RunResult
        {
            get
            {
                // Set the initial value.
                int result = InitialValue;

                // Copy the initial operations list
                bool[] operations = UnMutatedOperations;

                // Mutate some of the operations if luck demands it.
                int amountToMutate = RandomManager.RandomInt(0, _chromosomes.GetSubArray(0,
                    SecondaryMutationChromosomesAmount).GetIntFromChromosomeArray());
                HashSet<int> mutatedOperationIndex = new HashSet<int>();
                for (int i = 0; i < amountToMutate; i++)
                {
                    int mutatedIndex = RandomManager.RandomInt(0, AmountOfOperations - 1);
                    operations[mutatedIndex] = !operations[mutatedIndex];
                    mutatedOperationIndex.Add(mutatedIndex);
                }

                // Make the concrete operations
                Dictionary<EOperations, int> operationCounters = new Dictionary<EOperations, int>();
                int operationsUsed = 1;
                for (int i = 0; i < AmountOfOperations; i += 2)
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

                // The last chromosome will determine the symbol
                result *= Sign ? 1 : -1;

                return new IndividualRunResults(this, result, Math.Abs(Generation.TargetValue - result), mutatedOperationIndex);
            }
        }

        private string NextIndividualName
        {
            get
            {
                totalIndividuals++;
                return $"Individual #{totalIndividuals}";
            }
        }

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//
        
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
            _name = NextIndividualName;

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
                _chromosomes[i] = new Chromosome(this, RandomManager.RandomInt(0, 1) == 0);
            }
        }

        #endregion Initialization

        public static void ResetIndividualsCount() => totalIndividuals = 0;
    }
}