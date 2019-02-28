namespace ProgrammingProblems.LeetCodeUtil
{
    /// <summary>
    /// List node class defined in LeetCode.com (Problem 2. Add Two Numbers)
    /// </summary>
    public class ListNode<T>
    {
        public T Val { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            Val = value;
        }
    }
}
