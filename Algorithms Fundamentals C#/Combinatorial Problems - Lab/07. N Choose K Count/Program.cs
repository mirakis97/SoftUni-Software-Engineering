using System;

namespace _07._N_Choose_K_Count
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n,k));
        }
        private static int GetFibonacci(int n, int k)
        {
            if (n <= 1 || k == 0 || k == n)
            {
                return 1;
            }
            return GetFibonacci(n - 1,k - 1) + GetFibonacci(n - 1,k);
        }
    }
}
