using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            //Dictionary<int, int> evenNum = numbers.Where(kvp => kvp.Value % 2 == 0).ToDictionary(kvp => kvp.Key, v => v.Value);

            KeyValuePair<int, int> kvp = numbers.First(kvp => kvp.Value % 2 == 0);
            Console.WriteLine(kvp.Key);
        }
    }
}
