using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Time
{
    public class Program
    {
        static void Main(string[] args)
        {
            var left = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var right = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var dp = new int[left.Length + 1, right.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (left[row - 1] == right[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    }
                }
            }
            var subset = ExtractCommonLine(dp, left, right);
            Console.WriteLine(String.Join(" ",subset));
            Console.WriteLine(dp[left.Length, right.Length]);
        }

        private static int[] ExtractCommonLine(int[,] lcsMatrix, int[] line1, int[] line2)
        {
            Stack<int> line = new Stack<int>();
            int row = lcsMatrix.GetLength(0) - 1;
            int col = lcsMatrix.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (line1[row - 1] == line2[col - 1])
                {
                    line.Push(line1[row - 1]);
                    row--;
                    col--;
                }
                else if (lcsMatrix[row - 1, col] > lcsMatrix[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return line.ToArray();
        }
    }
}
