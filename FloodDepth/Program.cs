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
            var A = new[] {1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2};

            var maxDepth = FindMaxDepth(A);
            Console.WriteLine(maxDepth);

            A = new[] {8, 5, 8};
            maxDepth = FindMaxDepth(A);
            Console.WriteLine(maxDepth);

            A = new[] {10, 1, 2, 20};
            maxDepth = FindMaxDepth(A);
            Console.WriteLine(maxDepth);

            A = new[] {333, 1, 25, 4, 12, 3};
            maxDepth = FindMaxDepth(A);
            Console.WriteLine(maxDepth);
        }

        private static int FindMaxDepth(IReadOnlyList<int> A)
        {
            return FindMaxDepthRec(A, 0, int.MaxValue, int.MinValue, 0, 0);
        }

        private static int FindMaxDepthRec(IReadOnlyList<int> A, int leftMaxHeightPos,
            int sectionLowerHeight, int higherInSection, int maxDepth, int index)
        {
            if (index == A.Count) return maxDepth;

            if (index - leftMaxHeightPos <= 1)
            {
                if (A[index] > A[leftMaxHeightPos] || index == leftMaxHeightPos)
                {
                    leftMaxHeightPos = index;
                    higherInSection = int.MinValue;
                }
                else
                {
                    sectionLowerHeight = Math.Min(sectionLowerHeight, A[index]);
                    higherInSection = Math.Max(higherInSection, A[index]);
                }

                return FindMaxDepthRec(A, leftMaxHeightPos, sectionLowerHeight, higherInSection,
                    maxDepth, index + 1);
            }

            if (A[index] > higherInSection) //right boundary found
            {
                var heightForDepthCalculation = Math.Min(A[leftMaxHeightPos], A[index]);
                
                maxDepth = Math.Max(maxDepth, heightForDepthCalculation - sectionLowerHeight);

                return FindMaxDepthRec(A, index, int.MaxValue, int.MinValue, maxDepth, index + 1);
            }

            sectionLowerHeight = Math.Min(sectionLowerHeight, A[index]);
            higherInSection = Math.Max(higherInSection, A[index]);
            return FindMaxDepthRec(A, leftMaxHeightPos, sectionLowerHeight, higherInSection,
                maxDepth,
                index + 1);
        }
    }
}