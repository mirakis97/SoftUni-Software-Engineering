using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    public class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }
        private static long GetFibonacci(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            if (n <= 1)
            {
                return n;
            }
            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            cache[n] = result;

            return result;
        }
    }
}
