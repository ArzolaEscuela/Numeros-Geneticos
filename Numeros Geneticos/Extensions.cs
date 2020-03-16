using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_Geneticos
{
    public static class Extensions
    {
        public static bool IsSimilarToColor(this Color thisColor, Color otherColor, int tolerance = 20)
        {
            return Math.Abs(thisColor.R - otherColor.R) < tolerance &&
                   Math.Abs(thisColor.G - otherColor.G) < tolerance &&
                   Math.Abs(thisColor.B - otherColor.B) < tolerance;
        }

        private static void SafeAddOrModify<T, T2>(this Dictionary<T, T2> _thisDictionary, Func<T2, T2> transformOperation, T toLook, T2 defaultValue)
        {
            if (_thisDictionary.ContainsKey(toLook))
            {
                _thisDictionary[toLook] = transformOperation(_thisDictionary[toLook]);
                return;
            }
            _thisDictionary.Add(toLook, defaultValue);
        }

        private static int SafeAddOrIncrease<T>(this Dictionary<T, int> thisDictionary, T toLook)
        {
            thisDictionary.SafeAddOrModify(i => i + 1, toLook, 0);
            return thisDictionary[toLook];
        }

        public static int GetNextMagnitude<T>(this Dictionary<T, int> thisDictionary, T toLook)
        {
            return (int)Math.Pow(2, thisDictionary.SafeAddOrIncrease(toLook));
        }

        public static T[] GetSubArray<T>(this T[] array, int minIndex, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, minIndex, result, 0, length);
            return result;
        }

    }
}
