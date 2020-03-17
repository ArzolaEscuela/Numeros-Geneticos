using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_Geneticos
{
    public static class Extensions
    {
        public static bool IsSimilarToColor(this Color thisColor, Color otherColor, int tolerance = 40)
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
            thisDictionary.SafeAddOrModify(i => i + 1, toLook, 1);
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

        public static bool IsNumeric(this string thisString)
        {
            return Regex.IsMatch(thisString, @"^\d+$");
        }

        public static void Clear(this DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.DataSource = null;
        }

        public static void ClearAndRedrawGrid(this PictureBox pb)
        {
            // throw new NotImplementedException();
        }

        public static int AsInt(this string thisString)
        {
            int result;
            if (int.TryParse(thisString, out result))
            {
                return result;
            }
            return -1;
        }

        public static T2[] TransformArray<T, T2>(this T[] array, Func<T, T2> transformer)
        {
            int arraySize = array.Length;
            T2[] newArray = new T2[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                newArray[i] = transformer(array[i]);
            }

            return newArray;
        }

    }
}
