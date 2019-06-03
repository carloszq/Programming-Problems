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

        /// <summary>
        /// Leet Code #2 - Add Two Numbers.
        ///  
        /// Problem: You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list.
        /// 
        /// *You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// 
        /// Proposed Solution: Math approach. Traverse both list from its head and sum each node as single digit operation while 
        /// adding the carry to next iteration if the sum "overflows".
        /// Time Complexity: O(max(m, n)) as worst case scenario will need to iterate the max(m, n) where m=l1 length, n=l2 length.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            // 1. Create dummy head node and aux node for iterating result.
            ListNode<int> resultHead = new ListNode<int>(0);
            ListNode<int> auxNode = resultHead;
            int sumCarry = 0;

            // 2. Iterate lists if at least one of them is not null, or if a carry is present.
            while (null != l1 || null != l2 || sumCarry != 0)
            {
                // 3. Add single digits from list nodes and carry.
                int summand1 = l1 != null ? l1.Val : 0;
                int summand2 = l2 != null ? l2.Val : 0;
                int sum = summand1 + summand2 + sumCarry;

                // 4. Carry will be 0 or 1 for a single digit sum.
                sumCarry = sum / 10;

                // 5. Mod 10 of sum will ensure a single digit is the result in case of 
                // an overflow. ex. 9 + 9 = 18, 18 Mod 10 = 8; 5 + 4 = 9, 9 Mod 10 = 9.
                auxNode.Next = new ListNode<int>(sum % 10);
                auxNode = auxNode.Next;
                
                l1 = l1?.Next;
                l2 = l2?.Next;
            }

            return resultHead.Next;
        }

        /// <summary>
        /// Lengths the of longest substring.
        /// </summary>
        /// <returns>The of longest substring.</returns>
        /// <param name="s">S.</param>
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null)
            {
                return 0;
            }

            var length = 0;
            var map = new Dictionary<char, bool>();

            for (int i = 0; i < s.Length; i++)
            {
                map.Clear();
                int currentLength = 0;
                for (int j = i; j < s.Length; j++)
                {
                    var key = s[j];
                    if (map.ContainsKey(key))
                    {
                        break;
                    }

                    map.Add(key, true);
                    currentLength++;
                    length = currentLength > length ? currentLength : length;
                }
            }

            return length;
        }

        /// <summary>
        /// Leet Code #5 - Longest Palindromic Substring.
        ///  
        /// Problem: Given a string s, find the longest palindromic substring in s. 
        /// 
        /// * You may assume that the maximum length of s is 1000.
        /// 
        /// Proposed Solution: 
        /// </summary>
        /// <returns></returns>
        public static string LongestPalindromicSubstring(string s)
        {
            if (s.Length >= 1000)
            {
                return null;
            }

            string longestPalindrome = string.Empty;
            // 1. Traverse string to exctract substrings.
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    var length = (j - i) + 1;
                    var candidate = s.Substring(i, length);

                    // 2. Check is string is a palindrome
                    if (candidate.IsPalindrome())
                    {
                        // 3. If it is a palindrome, compare with previous longest.
                        longestPalindrome = longestPalindrome.Length < candidate.Length
                            ? candidate
                            : longestPalindrome;
                    }
                    else 
                    {
                        i = j;
                        j = i;
                    }
                }
            }

            return longestPalindrome;
        }

        /// <summary>
        /// Leet Code #7 - Reverse Integer
        ///  
        /// Problem: Given a 32-bit signed integer, reverse digits of an integer. 
        /// 
        /// * Assume we are dealing with an environment which could only store integers within the 32-bit 
        ///   signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function 
        ///   returns 0 when the reversed integer overflows.
        /// 
        /// Proposed Solution: 
        /// </summary>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            return x.Reverse();
        }
    }
}
