using System;
using System.Collections.Generic;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// Extension method class for <see cref="String"/>
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        ///     Dictionary mapping of char digits to its integer value.
        /// </summary>
        public static Dictionary<char, int> CharDigitToInt = new Dictionary<char, int>();

        static StringUtil()
        {
            CharDigitToInt.Add('0', 0);
            CharDigitToInt.Add('1', 1);
            CharDigitToInt.Add('2', 2);
            CharDigitToInt.Add('3', 3);
            CharDigitToInt.Add('4', 4);
            CharDigitToInt.Add('5', 5);
            CharDigitToInt.Add('6', 6);
            CharDigitToInt.Add('7', 7);
            CharDigitToInt.Add('8', 8);
            CharDigitToInt.Add('9', 9);
        }

        /// <summary>
        ///     Parses the C-string str interpreting its content as an integral number, which is returned as a value of type int.
        /// 
        ///     The function first discards as many whitespace characters(as in isspace) as necessary until the first non-whitespace character is found.
        ///     
        ///     Then, starting from this character, takes an optional initial plus or minus sign followed by as many base-10 digits as possible, and interprets them as a numerical value.
        /// 
        ///     The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
        /// 
        ///     If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or 
        ///     it contains only whitespace characters, no conversion is performed and zero is returned.
        /// </summary>
        /// <returns>The converted integer, otherwise 0.</returns>
        /// <param name="s">String value.</param>
        public static int Atoi(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            // 1. Remove all starting white-space characters.
            string trimmedString = s.MyTrimStart();
            if (string.IsNullOrEmpty(trimmedString))
            {
                return 0;
            }

            // 2. Check that first char is sign or integer digit.
            char firstChar = trimmedString[0];
            int startIndex = 0;
            var isNegative = false;
            if (!CharDigitToInt.ContainsKey(firstChar))
            {
                if (firstChar.IsPlusMinusSign() == false)
                {
                    return 0;
                }

                startIndex = 1;
                isNegative |= firstChar == '-';
            }

            int atoiInt = 0;
            int maxIntBy10 = int.MaxValue / 10;
            int minIntBy10 = int.MinValue / 10;

            // 3. Traverse string looking for a valid int-32 value.
            for (int i = startIndex; i < trimmedString.Length; i++)
            {
                // Quit traversing rest ofstring if no valid integer is found.
                var c = trimmedString[i];
                if (CharDigitToInt.TryGetValue(c, out int value) == false)
                {
                    break;
                }

                value = isNegative ? value * -1 : value;

                // Prevent overflow by checking the following:
                //
                // - If the current integer value is already larger than Max divided by ten, 
                //   that means adding any other digit to the right (units) will overflow Max. 
                //
                // - Also, if integer value is equal to Max divided by 10, that means that pop 
                //   value cannot exceed 7 as the largest digit to be added into units.
                if (atoiInt > maxIntBy10 || (atoiInt == maxIntBy10 && value > 7))
                {
                    return int.MaxValue;
                }

                // Previous logic applies as well for negative values.
                if (atoiInt < minIntBy10 || (atoiInt == minIntBy10 && value < -8))
                {
                    return int.MinValue;
                }

                // Move current integer value to Tens to make room in units for new value digit.
                atoiInt = (atoiInt * 10) + value;
            }

            return atoiInt;
        }

        /// <summary>
        /// Is a given string a palindrome.
        /// </summary>
        /// <returns><c>true</c>, if palindrome, <c>false</c> otherwise.</returns>
        /// <param name="s">S.</param>
        public static bool IsPalindrome(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            int head = 0;
            int tail = s.Length - 1;
            while (head < tail)
            {
                if (s[head++] != s[tail--])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Removes all leading white-space characters from the current string.
        /// </summary>
        /// <returns>String with no leading white-space characters.</returns>
        /// <param name="s">String value.</param>
        public static string MyTrimStart(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            bool ignoreStartWhiteSpaces = true;
            string trimmedString = string.Empty;
            foreach (char c in s)
            {
                // If only white-space chars have been found, continue.
                if (ignoreStartWhiteSpaces == true && c == ' ')
                {
                    continue;
                }

                ignoreStartWhiteSpaces = false;
                trimmedString += c;
            }

            return trimmedString;
        }
    }
}

