using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            foreach (var numbert in input)
            {
                if (numbers.ContainsKey(numbert))
                {
                    numbers[numbert]++;
                }
                else
                {
                    numbers.Add(numbert, 1);
                }
            }

            foreach (var numbert in numbers)
            {
                Console.WriteLine($"{numbert.Key} -> {numbert.Value}");
            }
        }
    }
}
