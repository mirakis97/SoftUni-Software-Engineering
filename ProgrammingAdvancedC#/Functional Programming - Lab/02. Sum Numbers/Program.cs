using System;
using System.Linq;
namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSumAndCount(int.Parse, a => a.Length, array =>
            {
                int sum = 0;
                foreach (var item in array)
                {
                    sum += item;
                }
                return sum;
            });
        }

        static void PrintSumAndCount (Func<string, int> parser, Func<int[], int> count, Func<int[], int> Sum)
        {
            int[] array = Console.ReadLine().
                  Split(", ")
                  .Select(parser)
                  .ToArray();

            Console.WriteLine(count(array));
            Console.WriteLine(Sum(array));
        }
    }
}
