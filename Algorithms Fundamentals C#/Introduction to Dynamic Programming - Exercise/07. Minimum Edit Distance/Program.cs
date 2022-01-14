using System;

namespace _07._Minimum_Edit_Distance
{
    public class Program
    {
        static void Main(string[] args)
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insertCost;
            }
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + deleteCost;
            }

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        dp[r, c] = dp[r - 1, c - 1];
                    }
                    else
                    {
                        var replace = dp[r - 1, c - 1] + replaceCost;
                        var delete = dp[r - 1, c] + deleteCost;
                        var insert = dp[r, c - 1] + insertCost;
                        dp[r, c] = Math.Min(Math.Min(replace,delete),insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[str1.Length, str2.Length]}");
        }
    }
}
