using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var nameAd = Console.ReadLine();
                names.Add(nameAd);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
