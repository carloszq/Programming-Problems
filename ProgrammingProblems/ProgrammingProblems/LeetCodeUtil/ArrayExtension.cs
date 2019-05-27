using System.Collections.Generic;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// Extension method class for Arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Extension method that returns a <see cref="ListNode{T}"/> which represents the current <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        /// <param name="collection">Collection to be represented as <see cref="ListNode{T}"/></param>
        /// <returns>A <see cref="ListNode{T}"/> representation of a <see cref="IList{T}"/></returns>
        public static ListNode<T> ToListNode<T>(this IList<T> collection)
        {
            ListNode<T> head = null;
            ListNode<T> auxNode = null;
            foreach (var item in collection)
            {
                var newNode = new ListNode<T>(item);
                if (head == null)
                {
                    head = newNode;
                    auxNode = newNode;
                    continue;
                }              

                auxNode.Next = newNode;
                auxNode = newNode;
            }

            return head;
        }
    }
}
