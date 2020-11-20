using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lists___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxIndex = num.Count;

            for (int i = 0; i < maxIndex / 2; i++)
            {
                num[i] += num[num.Count - 1];
                num.RemoveAt(num.Count - 1);
            }

            Console.WriteLine(string.Join(" ", num));
        }
    }
}
