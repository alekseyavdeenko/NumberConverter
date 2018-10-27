using System;
using System.Linq;
using System.Threading;

namespace KMA.APZRPMJ2018.NumberConverter.Tools
{
    public static class Calculation
    {
        private static readonly string[][] RomanNumerals = new string[][]
        {
            new string[]{"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"}, // ones
            new string[]{"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"}, // tens
            new string[]{"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"}, // hundreds
            new string[]{"", "M", "MM", "MMM", "MMMM", "MMMMM"} // thousands
        };

        public static string CalculateRoman(string arabicValueStr)
        {
            int arabicValue = Int32.Parse(arabicValueStr);

            // Calculation is done in a new thread.
            string value = null;
            var thread = new Thread(
                () =>
                {
                    value = Calculate(arabicValue);
                });
            thread.Start();
            thread.Join();
            return value;
        }

        private static string Calculate(int arabicValue)
        {
            var intArr = arabicValue.ToString().Reverse().ToArray();
            var len = intArr.Length;
            var romanNumeral = "";
            var i = len;

            while (i-- > 0)
            {
                romanNumeral += RomanNumerals[i][Int32.Parse(intArr[i].ToString())];
            }

            return romanNumeral;
        }
    }
}
