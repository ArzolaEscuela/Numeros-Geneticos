namespace Numeros_Geneticos
{
    public static class SettingsManager
    {
        public const int MINIMUM_CHROMOSOME_SIZE = 21;

        // Seed Values
        public static bool UseSeed => false;
        public static int InitialSeed => 1;

        // Generation Values
        public static int IndividualsPerGeneration => 1;
        public static int MaxSelectionsByElitism => 1;
        public static int MaxSelectionsByDefault => 0;
        public static int MaxTotalGenerations => 1;

        // Chromosome Values
        public static int TotalChromosomes => 1;
        public static int SecondaryMutationChromosomesAmount => 4;
        public static int InitialNumberChromosomesAmount => 6;

        // Elitism Values
        public static float ElitismChromosomeChance => 0.66f;

        // Mutation Values
        public static float MutationChance => 0.3f;
        public static int MaxMutableChromosomes => 1;
    }
}