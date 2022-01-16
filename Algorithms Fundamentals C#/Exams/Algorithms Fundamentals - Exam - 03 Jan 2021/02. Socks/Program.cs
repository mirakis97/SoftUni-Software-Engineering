using System;
using System.Linq;

namespace _02._Socks
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

            Console.WriteLine(dp[left.Length,right.Length]);
        }
    }
}
