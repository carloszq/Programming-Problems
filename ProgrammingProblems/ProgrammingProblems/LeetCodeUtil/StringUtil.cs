using System;
namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// Extension method class for <see cref="String"/>
    /// </summary>
    public static class StringUtil
    {
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
    }
}

