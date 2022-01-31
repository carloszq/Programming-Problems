using ProgrammingProblems.LeetCodeUtil;
using System;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test code here.
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("]")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("()")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("()[]{}")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("(]")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("(({}))")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("(()({}))")}");
            Console.WriteLine($"Valid Parentheses: {StringUtil.HasValidParentheses("(()({c}))")}");
        }    
    }
}
