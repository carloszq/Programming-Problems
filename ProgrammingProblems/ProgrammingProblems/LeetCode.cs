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
        /// Proposed Solution: Math approach. Will pop and push latest digit from x integer while dividing integer 
        /// x by 10 is not equal to 0. 
        /// </summary>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            return x.Reverse();
        }

        /// <summary>
        /// Leet Code #8 - String to Integer (atoi)
        ///  
        /// Problem: Implement atoi which converts a string to an integer.
        /// The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.
        /// Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, 
        /// and interprets them as a numerical value.
        /// 
        /// The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
        /// If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty 
        /// or it contains only whitespace characters, no conversion is performed.
        /// 
        /// If no valid conversion could be performed, a zero value is returned.
        /// 
        /// * Only the space character ' ' is considered as whitespace character.
        ///   Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: 
        ///   [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN(−231) is returned.
        /// </summary>
        /// <returns></returns>
        public static int MyAtoi(string str)
        {
            return str.Atoi();
        }

        /// <summary>
        /// Leet Code #9 - Palindrome Number
        ///  
        /// Problem: Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
        /// 
        /// Proposed Solution: Math approach. Reversed int (by division and module) and the compared reversed int with original int.
        /// </summary>
        /// <returns>|true| if palindrome, otherwise |false|.</returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            var reversedX = x.Reverse();
            return reversedX == x;
        }

        /// <summary>
        /// Leet Code #13 - Roman to Integer
        ///  
        /// Problem: Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
        /// 
        /// Proposed Solution: Traverse array to sum each digit and handle special cases where a substraction is needed.
        /// </summary>
        /// <returns>Integer value of a roman numeral.</returns>
        public static int RomanToInt(string s)
        {
            return IntegerUtil.RomanToInteger(s);
        }

        /// <summary>
        /// Leet Code #14 - Longest Common Prefix
        ///  
        /// Problem: Write a function to find the longest common prefix string amongst an array of strings. 
        /// 
        /// If there is no common prefix, return an empty string "".
        /// 
        /// Constrains:
        ///     0 <= strs.length <= 200
        ///     0 <= strs[i].length <= 200
        ///     strs[i] consists of only lower-case English letters.
        /// 
        /// Proposed Solution: Find string with shortest length. Compare each character among the different strings until a different character 
        /// is found or the found length limit has been reached.
        /// </summary>
        /// <returns>Longest common prefix.</returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            return StringUtil.LongestCommonPrefix(strs);
        }
    }
}
