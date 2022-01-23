using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_
{
    public class Program
    {
        private static Dictionary<string, long> cache;
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(numberOfPaths(row, col));
        }

        static long numberOfPaths(int m, int n)
        {
            if (m == 1 || n == 1)
                return 1;

            var key = $"{m}-{n}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            var result = numberOfPaths(m - 1, n) + numberOfPaths(m, n - 1);
            cache[key] = result;
            return result;
        }
    }
}