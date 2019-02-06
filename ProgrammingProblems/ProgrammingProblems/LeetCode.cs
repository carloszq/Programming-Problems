using System.Collections.Generic;
using ProgrammingProblems.LeetCodeUtil;

namespace ProgrammingProblems
{
    /// <summary>
    /// Class that covers problems from https://leetcode.com.
    /// </summary>
    public static class LeetCode
    {
        /// <summary>
        /// Leet Code #1 - Two Sums.
        ///  
        /// Problem: Given an array of integers, return indices of the two numbers such that they add up to a specific target. 
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// 
        /// Proposed Solution: Current implementation uses a Dictionary to store num and its position.
        /// This will help for an easy look-up of the difference that would make the sum.
        /// Time Complexity: O(n) as worst case scenario will need to traverse whole array.
        /// </summary>
        /// <param name="nums">Array of integer numbers.</param>
        /// <param name="target">Target number (expected sum).</param>
        /// <returns>Array with the position of the elemns that sum the target, otherwise null.</returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 1)
            {
                return null;
            }

            // 1. Traverse array.
            var minuend = target;
            var numToPos = new Dictionary<int, int>();
            for (int pos = 0; pos < nums.Length; pos++)
            {
                // 2. Look for the difference in dictionary. 
                var subtrahend = nums[pos];
                var difference = minuend - subtrahend;
                if (numToPos.ContainsKey(difference))
                {
                    // 2.a If difference value is present, we have found two numbers that sum the target.
                    return new int[] { numToPos[difference], pos };
                }

                // 3. Add current num and position from array to dictionary.
                if (!numToPos.ContainsKey(subtrahend))
                {
                    numToPos.Add(subtrahend, pos);
                }
            }

            return null;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return null;
        }
    }
}
