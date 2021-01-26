using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).Select(x => x + (x * 0.2m)).ToArray();

            foreach (var num in numbs)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
