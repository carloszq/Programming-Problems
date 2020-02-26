using System.Collections.Generic;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    ///     This class provides a set of extended functionality to the <see cref="int"/> data type.
    /// </summary>
    public static class IntegerUtil
    {
        /// <summary>
        ///     Dictionary of roman numerals to integer values.
        /// </summary>
        public static Dictionary<string, int> RomanToIntMap = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "D", 500 },
            { "C", 100 },
            { "L", 50 },
            { "X", 10 },
            { "V", 5 },
            { "I", 1 },
        };

        /// <summary>
        ///     Reverse the specified integer using only Int32 values.
        /// </summary>
        /// <returns>The reversed integer, otherwise 0.</returns>
        /// <param name="x">The x integer to be reversed.</param>
        public static int Reverse(this int x)
        {
            // 2,147,483,647 / 10 = 214,748,364
            int maxIntBy10 = int.MaxValue / 10;

            // -2,147,483,648 / 10 = -214,748,364
            int minIntBy10 = int.MinValue / 10;

            int reversed = 0;
            while (x != 0)
            {
                // Pop digit from back to be pushed into the front.
                int pop = x % 10;
                x = x / 10;

                // Prevent overflow by checking the following:
                //
                // - If the current reversed value is already larger than Max divided by ten, 
                //   that means adding any other digit to the right (units) will overflow Max. 
                //
                // - Also, if reversed value is equal to Max divided by 10, that means that pop 
                //   value cannot exceed 7 as the largest digit to be added into units.
                if (reversed > maxIntBy10 || (reversed == maxIntBy10 && pop > 7))
                {
                    return 0;
                }

                // Previous logic applies as well for negative values.
                if (reversed < minIntBy10 || (reversed == minIntBy10 && pop < -8))
                {
                    return 0;
                }

                // Move current reversed to Tens to make room in units.
                int tensValue = reversed * 10;

                // Push popped value into units.
                reversed = tensValue + pop;
            }

            return reversed;
        }

        /// <summary>
        /// Reverse the specified integer using a string.
        /// </summary>
        /// <returns>The reversed integer, otherwise 0.</returns>
        /// <param name="x">The x integer to be reversed.</param>
        public static int ReverseByString(this int x)
        {
            // Check if value is positive, otherwise make it.
            var isPositive = x > 0;
            x = isPositive ? x : x * -1;

            string xString = x.ToString();
            string reversedX = string.Empty;

            // Reverse int value into a string.
            foreach (char c in xString)
            {
                reversedX = c + reversedX;
            }

            // Try to parse into a valid integer value.
            reversedX = isPositive ? reversedX : '-' + reversedX;
            var isParse = int.TryParse(reversedX, out int result);

            return isParse ? result : 0;
        }

        /// <summary>
        ///     Convert a roman numeral to integer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInteger(this string s)
        {
            int result = 0;
            int prevIntDigit = 0;

            // Traverse string and convert digits.
            for (int i = 0; i < s.Length; i++)
            {
                // Map roman digit to integer.
                string romanDigit = s[i].ToString();
                var intFound = RomanToIntMap.TryGetValue(romanDigit, out int intDigit);
                if (intFound == false)
                {
                    return -1;
                }

                result += intDigit;

                // If prev digit is smaller, substract times two.
                if (prevIntDigit < intDigit)
                {
                    result -= (2 * prevIntDigit);
                }

                prevIntDigit = intDigit;
            }

            return result;
        }
    }
}
