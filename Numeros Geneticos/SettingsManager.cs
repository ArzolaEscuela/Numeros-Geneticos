using Numeros_Geneticos.Properties;

namespace Numeros_Geneticos
{
    public static class SettingsManager
    {
        // This one is used in the problem description
        public const int MINIMUM_OPERATION_CHROMOSOMES_COUNT = 10;
        public static int FakeMinimumChromosomeSize => InitialNumberChromosomesAmount + SecondaryMutationChromosomesAmount + 1 + 2;
        // The +1 Is To Account For a Symbol (+ -), The +10 Accounts For At Least 5 Operation Pairs
        public static int MinimumChromosomeSize => InitialNumberChromosomesAmount + SecondaryMutationChromosomesAmount + 1 + MINIMUM_OPERATION_CHROMOSOMES_COUNT;
        public static bool ChromosomeShouldBeEven => MinimumChromosomeSize % 2 == 0;

        // Seed Values
        public static bool UseSeed
        {
            get => Settings.Default.UseSeed;
            set
            {
                Properties.Settings.Default.UseSeed = value;
                Properties.Settings.Default.Save();
            }
        }
        public static int InitialSeed
        {
            get => Settings.Default.Seed;
            set
            {
                Properties.Settings.Default.Seed = value;
                Properties.Settings.Default.Save();
            }
        }

        // Target
        public static int TargetNumber
        {
            get => Settings.Default.TargetNumber;
            set
            {
                Properties.Settings.Default.TargetNumber = value;
                Properties.Settings.Default.Save();
            }
        }

        // Generation Values
        public static int IndividualsPerGeneration
        {
            get => Settings.Default.IndividualsPerGeneration;
            set
            {
                Properties.Settings.Default.IndividualsPerGeneration = value;
                Properties.Settings.Default.Save();
            }
        }
        public static int SelectionsByElitism
        {
            get => Settings.Default.SelectionsByElitism;
            set
            {
                Properties.Settings.Default.SelectionsByElitism = value;
                Properties.Settings.Default.Save();
            }
        }
        public static int MaxTotalGenerations
        {
            get => Settings.Default.MaxTotalGenerations;
            set
            {
                Properties.Settings.Default.MaxTotalGenerations = value;
                Properties.Settings.Default.Save();
            }
        }

        // Chromosome Values
        public static int TotalChromosomes
        {
            get => Settings.Default.TotalChromosomes;
            set
            {
                Properties.Settings.Default.TotalChromosomes = value;
                Properties.Settings.Default.Save();
            }
        }
        public const int MINIMUM_MUTATION_CHROMOSOMES_AMOUNT = 1;
        public static int SecondaryMutationChromosomesAmount
        {
            get => Settings.Default.SecondaryMutationChromosomesAmount;
            set
            {
                Properties.Settings.Default.SecondaryMutationChromosomesAmount = value;
                Properties.Settings.Default.Save();
            }
        }
        public const int MINIMUM_INITIAL_NUMBER_CHROMOSOMES_AMOUNT = 4;
        public static int InitialNumberChromosomesAmount
        {
            get => Settings.Default.InitialNumberChromosomesAmount;
            set
            {
                Properties.Settings.Default.InitialNumberChromosomesAmount = value;
                Properties.Settings.Default.Save();
            }
        }

        // Elitism Values
        public static float ElitismChromosomeChance
        {
            get => Settings.Default.ElitismChromosomeChance;
            set
            {
                Properties.Settings.Default.ElitismChromosomeChance = value;
                Properties.Settings.Default.Save();
            }
        }

        // Mutation Values
        public static float MutationChance
        {
            get => Settings.Default.MutationChance;
            set
            {
                Properties.Settings.Default.MutationChance = value;
                Properties.Settings.Default.Save();
            }
        }
        public const int MINIMUM_MUTABLE_CHROMOSOMES = 1;
        public static int MaxMutableChromosomes
        {
            get => Settings.Default.MaxMutableChromosomes;
            set
            {
                Properties.Settings.Default.MaxMutableChromosomes = value;
                Properties.Settings.Default.Save();
            }
        }

        // Uniformity Test
        public static int ChromosomesMatchesToConcludeSimilar
        {
            get => Settings.Default.ChromosomesMatchesToConcludeSimilar;
            set
            {
                Properties.Settings.Default.ChromosomesMatchesToConcludeSimilar = value;
                Properties.Settings.Default.Save();
            }
        }
        public static int IndividualMatchesToStopSimulation
        {
            get => Settings.Default.SimilarAmountToConcludeUniformity;
            set
            {
                Properties.Settings.Default.SimilarAmountToConcludeUniformity = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool GuaranteedSurvivalForElites
        {
            get => Settings.Default.PriorityReproductionInsteadOfGuaranteedSurvival;
            set
            {
                Properties.Settings.Default.PriorityReproductionInsteadOfGuaranteedSurvival = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}