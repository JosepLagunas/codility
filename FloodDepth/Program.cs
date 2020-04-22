using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new[] { 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2 };

            var maxDepth = FindMaxDepth(A);
            Console.WriteLine(maxDepth);
        }

        private static int FindMaxDepth(IReadOnlyList<int> A)
        {
            return FindMaxDepthRec(A, 0, int.MaxValue, 0, 0);
        }

        private static int FindMaxDepthRec(IReadOnlyList<int> A, int leftMaxHeightPos,
            int sectionLowerHeight, int maxDepth, int index)
        {
            if (index == A.Count) return maxDepth;

            if (A[index] >= A[leftMaxHeightPos] && leftMaxHeightPos == 0)
            {
                leftMaxHeightPos = index;
                return FindMaxDepthRec(A, leftMaxHeightPos, sectionLowerHeight, maxDepth, index + 1);
            }

            if (index - leftMaxHeightPos <= 1)
                return FindMaxDepthRec(A, leftMaxHeightPos, sectionLowerHeight, maxDepth,
                    index + 1);
            
            if (A[index] >= A[leftMaxHeightPos])
            {
                var heightForDepthCalculation = Math.Min(A[leftMaxHeightPos], A[index]);
                sectionLowerHeight =
                    Math.Min(sectionLowerHeight, A[index]);
                maxDepth = Math.Max(maxDepth, sectionLowerHeight);
                return FindMaxDepthRec(A, index, sectionLowerHeight, maxDepth, index + 1);
            }

            sectionLowerHeight = Math.Min(sectionLowerHeight, A[index]);
            return FindMaxDepthRec(A, leftMaxHeightPos, sectionLowerHeight, maxDepth,
                index + 1);
        }
    }
}
