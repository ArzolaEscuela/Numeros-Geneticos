using Numeros_Geneticos.Properties;

namespace Numeros_Geneticos
{
    public static class SettingsManager
    {
        // This one is used in the problem description
        public static int FakeMinimumChromosomeSize => InitialNumberChromosomesAmount + SecondaryMutationChromosomesAmount + 1 + 2;
        // The +1 Is To Account For a Symbol (+ -), The +10 Accounts For At Least 5 Operation Pairs
        public static int MinimumChromosomeSize => InitialNumberChromosomesAmount + SecondaryMutationChromosomesAmount + 1 + 10;
        public static bool ChromosomeShouldBeEven => MinimumChromosomeSize % 2 == 0;

        // Seed Values
        public static bool UseSeed => Settings.Default.UseSeed;
        public static int InitialSeed => Settings.Default.Seed;

        // Generation Values
        public const int MINIMUM_INDIVIDUALS_PER_GENERATION = 10;
        public static int IndividualsPerGeneration => Settings.Default.IndividualsPerGeneration;
        public static int SelectionsByElitism => Settings.Default.SelectionsByElitism;
        public static int MaxTotalGenerations => Settings.Default.MaxTotalGenerations;

        // Chromosome Values
        public static int TotalChromosomes => Settings.Default.TotalChromosomes;
        public const int MINIMUM_MUTATION_CHROMOSOMES_AMOUNT = 1;
        public static int SecondaryMutationChromosomesAmount => Settings.Default.SecondaryMutationChromosomesAmount;
        public const int MINIMUM_INITIAL_NUMBER_CHROMOSOMES_AMOUNT = 4;
        public static int InitialNumberChromosomesAmount => Settings.Default.InitialNumberChromosomesAmount;

        // Elitism Values
        public static float ElitismChromosomeChance => Settings.Default.ElitismChromosomeChance;

        // Mutation Values
        public static float MutationChance => Settings.Default.MutationChance;
        public const int MINIMUM_MUTABLE_CHROMOSOMES = 1;
        public static int MaxMutableChromosomes => Settings.Default.MaxMutableChromosomes;

        // Uniformity Test
        public static float ChromosomesMatchesToConcludeSimilar => Settings.Default.ChromosomesMatchesToConcludeSimilar;
        public static float SimilarAmountToConcludeUniformity => Settings.Default.SimilarAmountToConcludeUniformity;
    }
}