using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0M;

            for (int i = 0; i < n; i++)
            {
                sum += decimal.Parse(Console.ReadLine()); 
            }

            Console.WriteLine($"{sum}");
        }
    }
}
