using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                int numbers = arr1[i];
                sum += numbers;
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not idenical. Found difference at {i} index");
                    break;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
