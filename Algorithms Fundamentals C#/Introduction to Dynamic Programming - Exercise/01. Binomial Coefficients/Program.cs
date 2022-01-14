using System;
using System.Collections.Generic;

namespace _01._Binomial_Coefficients
{
    public class Program
    {
        private static Dictionary<string, long> cache;
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[key] = result;
            return result;
        }
    }
}
