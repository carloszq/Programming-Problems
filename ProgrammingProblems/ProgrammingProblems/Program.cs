using ProgrammingProblems.LeetCodeUtil;
using System;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test code here.
            int[] array1 = new int[] { 0, 5 };
            int[] array2 = new int[] { 0, 5 };

            var list1 = array1.ToListNode<int>();
            var list2 = array2.ToListNode<int>();

            var resultListNode = LeetCode.AddTwoNumbers(list1, list2);
            Console.WriteLine();
            resultListNode.PrintListNode(Console.Write);
        }
    }
}
