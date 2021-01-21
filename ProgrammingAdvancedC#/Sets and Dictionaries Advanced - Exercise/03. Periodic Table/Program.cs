using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> hashSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in elements)
                {
                    hashSet.Add(item);
                }
                
            }

            Console.WriteLine(string.Join(" ",hashSet));
        }
    }
}
