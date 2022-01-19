using System;
using System.Collections.Generic;

namespace _01._Two_Minutes_to_Midnight
{
    public class Program
    {
        private static Dictionary<string, long> cache;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            
            cache = new Dictionary<string, long>();
            Console.WriteLine(GetFibonacci(n, k));
        }
        private static long GetFibonacci(int n, int k)
        {
            if (n <= 1 || k == 0 || k == n)
            {
                return 1;
            }

            var key = $"{n}-{k}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetFibonacci(n - 1, k - 1) + GetFibonacci(n - 1, k);
            cache[key] = result;
            return result;
        }
    }
}
