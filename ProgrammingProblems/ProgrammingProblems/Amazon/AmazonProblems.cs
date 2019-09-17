
namespace ProgrammingProblems.Amazon
{
    /// <summary>
    /// Example problems from known Amazon interview exercises.
    /// </summary>
    public static class AmazonProblems
    {
        /// <summary>
        /// Question: Imagine you have a 2D array that represents a ski slope (see figure below).
        /// An index with a value of 1 represents a tree. The skier can only travel right and down along the array.
        /// Write an algorithm to determine whether a clear path exists for the skier to cross the finish line.
        /// 
        /// Example Input:
        ///  [[0, 0, 0, 0],
        ///  [0, 1, 0, 1],
        ///  [0, 1, 0, 1],
        ///  [0, 1, 0, 0]]
        /// Output: true.
        /// </summary>
        public static bool PathExistInSlope(int[,] skiSlope)
        {
            if (null == skiSlope)
            {
                return false;
            }

            var rowsLength = skiSlope.GetLength(0);
            var colsLength = skiSlope.GetLength(1);

            if (rowsLength == 0 || colsLength == 0)
            {
                return false;
            }

            return DescendSlope(skiSlope, 0, 0, rowsLength, colsLength);
        }

        /// <summary>
        /// Auxiliary recursive method that relies on backtracking to retry remember and retry a new path to descend slope.
        /// </summary>
        /// <returns><c>true</c>, if slope was descended, <c>false</c> otherwise.</returns>
        /// <param name="skiSlope">Ski slope 2D array representation.</param>
        /// <param name="row">Row position in 2D array.</param>
        /// <param name="col">Col position in 2D array.</param>
        /// <param name="rowsLength">Rows length.</param>
        /// <param name="colsLength">Cols length.</param>
        private static bool DescendSlope(int[,] skiSlope, int row, int col, int rowsLength, int colsLength)
        { 
            // Base case: if you reached uttermost right + 1. You can't continue moving.
            if (col > colsLength - 1)
            {
                return false;
            }

            // Base case: if you reached uttermost bottom + 1. You have exited the slope.
            if (row > rowsLength - 1)
            {
                return true;
            }

            // Base case: if you hit a tree. You can't continue moving.
            var currPos = skiSlope[row, col];
            if (currPos == 1)
            {
                return false;
            }

            // Go down on Y axis - move array position. Depth-first approach.
            if (DescendSlope(skiSlope, row + 1, col, rowsLength, colsLength))
            {
                return true;
            }

            // Go right on X axis - move array position. Back track to previous row pos.
            return DescendSlope(skiSlope, row, col + 1, rowsLength, colsLength);
        }
    }
}
