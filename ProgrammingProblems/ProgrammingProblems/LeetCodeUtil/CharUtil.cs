using System;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    ///     Extension method class for <see cref="Char"/>
    /// </summary>
    public static class CharUtil
    {
        /// <summary>
        ///     Determines if a given char is a Plus-minus sign: '-'/'+'.
        /// </summary>
        /// <returns><c>true</c>, if char is a plus or minus sign, <c>false</c> otherwise.</returns>
        /// <param name="c">S.</param>
        public static bool IsPlusMinusSign(this char c)
        {
            return c == '-' || c == '+';
        }
    }
}
