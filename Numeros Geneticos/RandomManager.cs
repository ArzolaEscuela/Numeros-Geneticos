using System;
using System.Linq;

namespace Numeros_Geneticos
{
    public static class RandomManager
    {
        private static Random _random = new Random();

        /// <summary>
        /// Gets a random number, both values are inclusive: [min, max]
        /// </summary>
        public static int RandomInt(int min, int max) => _random.Next(min, max + 1);

        public static int RandomIntWithHollowSpot(int min, int max, int hollowSpot)
        {
            int result = RandomInt(min, max);
            while (result == hollowSpot) { result = RandomInt(min, max); }
            return result;
        }

        public static T[] RandomizeArray<T>(this T[] array) => array.OrderBy(x => _random.Next()).ToArray();

        /// <summary>
        /// <para>Obtains a true or false depending on the percentage chance value, which should be between 0 and 1.</para>
        /// <para>Returns true if the number fell inside of the given chance, otherwise false.</para>
        /// <para>i.e. if you provide a 0.753 then there is a 75.3% chance of getting a "true".</para>
        /// </summary>
        /// <param name="percentage">A value between 0 and 1 that determines the chance of getting a "true".</param>
        public static bool EvaluatePercentage(float percentage) => _random.NextDouble() < percentage;

        public static void SetSeed(int seed = Int32.MinValue)
        {
            if (seed == Int32.MinValue)
            {
                _random = new Random(Guid.NewGuid().GetHashCode());
                return;
            }

            _random = new Random(seed);
        }
    }
}