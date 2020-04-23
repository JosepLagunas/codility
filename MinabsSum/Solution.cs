using System;

public class Solution
{
    private static int _minAbsSum;
    public static void Main()
    {
        var A = new[] { 1, 5, 2, -2 };
        var S = new Solution();
        S.solution(A);
        PrintResult();
        A = new[] { 3, 1 };
        S.solution(A);
        PrintResult();
        Console.ReadKey();
    }

    public int solution(int[] A)
    {
        _minAbsSum = int.MaxValue;
        FindMinAbsSumRec(ref A, 0, 0);

        return _minAbsSum;
    }

    private static void FindMinAbsSumRec(ref int[] A, int partialSum, int depth)
    {
        if (depth == A.Length)
        {
            if (_minAbsSum > Math.Abs(partialSum))
            {
                _minAbsSum = Math.Abs(partialSum);
            }

            return;
        }

        if (_minAbsSum == 0) return;

        if (
            partialSum + A[depth] > _minAbsSum ||
            partialSum - A[depth] > _minAbsSum)
            return;

        FindMinAbsSumRec(ref A, partialSum + A[depth], depth + 1);
        if (_minAbsSum == 0) return;
        
        FindMinAbsSumRec(ref A, partialSum - A[depth], depth + 1);
    }

    private static void PrintResult()
    {
        Console.WriteLine($"Min Abs Sum -> {_minAbsSum}");
    }
}