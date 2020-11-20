using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                           .Split("|")
                           .ToList();

            items.Reverse();

            List<string> result = new List<string>();
            foreach (string curentItem in items)
            {
                string[] numbers = curentItem.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string curentNum in numbers)
                {
                    result.Add(curentNum);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
