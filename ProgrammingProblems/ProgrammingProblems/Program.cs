using ProgrammingProblems.LeetCodeUtil;
using System;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test code here.
            var strs = new string[] { "flower", "flow", "flight" };
            Console.WriteLine($"Longest Common Prefix: {StringUtil.LongestCommonPrefix(strs)}");
        }    
    }
}
