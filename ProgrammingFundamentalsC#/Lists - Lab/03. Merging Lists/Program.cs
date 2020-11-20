using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> num2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> resultNum = new List<int>();

            for (int i = 0; i < Math.Min(num1.Count, num2.Count); i++)
            {
                resultNum.Add(num1[i]);
                resultNum.Add(num2[i]);
            }

            for (int i = Math.Min(num1.Count, num2.Count); i < Math.Max(num1.Count, num2.Count); i++)
            {
                if (i >= num1.Count)
                {
                    resultNum.Add(num2[i]);
                }
                else
                {
                    resultNum.Add(num1[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultNum));
        }

        
    }
}
