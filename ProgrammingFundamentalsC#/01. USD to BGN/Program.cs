using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD = double.Parse(Console.ReadLine());
            double bgn = USD * 1.79549;
            Console.WriteLine(bgn);
        }
    }
}
