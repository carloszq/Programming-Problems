using System.Collections.Generic;

namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// Extension method class for Arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Extension method that will remove elements that match a given value and return the position of
        /// the last element after removal of the rest of the items.
        /// </summary>
        /// <param name="nums"><Array of integers</param>
        /// <param name="val">Value that will be removed from array</param>
        /// <returns>Position of last element after removal of the rest of the items</returns>
        public static int RemoveElement(this int[] nums, int val)
        {
            if (nums == null || nums.Length < 0 || nums.Length > 100)
            {
                return -1;
            }

            if (val < 0 || val > 100)
            {
                return -1;
            }

            // Use a head and tail variables to track position (to be swapped in the array).
            int arraySize = nums.Length;
            int head = 0, tail = arraySize;

            // Traverse array to find elements with an equal value to val.
            // Do this until head and tail values are the same.
            while (head < tail)
            {
                if (nums[head] == val)
                {
                    nums[head] = nums[tail - 1];
                    tail--;
                }
                else
                {
                    head++;
                }
            }

            return tail;
        }


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
