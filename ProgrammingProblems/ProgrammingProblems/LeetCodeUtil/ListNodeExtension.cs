using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// Extension class for <see cref="ListNode{T}"/>.
    /// </summary>
    public static class ListNodeExtension
    {
        /// <summary>
        /// Given an Action it will print the elements in a <see cref="ListNode{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        /// <param name="listNode"></param>
        /// <param name="printAction">Print Action</param>
        /// <param name="separateBy">Char that will separate elements when printed.</param>
        public static void PrintListNode<T>(this ListNode<T> listNode, Action<string> printAction, char separateBy = '\t')
        {
            while (listNode != null)
            {
                printAction($"{listNode.Val}{separateBy}");
                listNode = listNode.Next;
            }
        }
    }
}
