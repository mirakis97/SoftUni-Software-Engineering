using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._School_Teams
{
    public class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsComb = new string[3];
            var girlsList = new List<string[]>();
            Combinations(0, 0, girlsComb, girls, girlsList);
            var boysComb = new string[2];
            var boysList = new List<string[]>();
            Combinations(0, 0, boysComb, boys, boysList);

            foreach (var girl in girlsList)
            {
                foreach (var boy in boysList)
                {
                    Console.WriteLine($"{string.Join(", ",girl)}, {string.Join(", ",boy)}");
                }
            }
        }

        private static void Combinations(int cellIdx, int girlsIdx, string[] comb, string[] elements, List<string[]> result)
        {
            if (cellIdx >= comb.Length)
            {
                result.Add(comb.ToArray());
                return;
            }

            for (int i = girlsIdx; i < elements.Length; i++)
            {
                comb[cellIdx] = elements[i];
                Combinations(cellIdx + 1, i + 1, comb, elements, result);
            }
        }
    }
}
