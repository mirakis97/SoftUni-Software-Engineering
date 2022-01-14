using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dividing_Presents
{
    public class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(presents);
            
            var totalSums = presents.Sum();
            var alanSum  = totalSums / 2;

            while (true)
            {
                if (allSums.ContainsKey(alanSum))
                {
                    var alanPresent = FindSubset(allSums, alanSum);
                    var bobsum = totalSums - alanSum;
                    Console.WriteLine($"Difference: {bobsum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobsum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ",alanPresent)}");
                    Console.WriteLine($"Bob takes the rest.");
                    break;
                }
                alanSum -= 1;
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();
            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);

                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var element in elements)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }
                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}
