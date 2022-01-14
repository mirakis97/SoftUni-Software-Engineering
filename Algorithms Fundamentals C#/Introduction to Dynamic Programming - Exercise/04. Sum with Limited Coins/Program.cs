using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_with_Limited_Coins
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSum(numbers, target));
        }

        private static int CountSum(int[] numbers, int target)
        {
            var count = 0;
            var sums = new HashSet<int> { 0 };

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (newSum == target)
                    {
                        count += 1;
                    }
                    newSums.Add(newSum);
                }
                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}
