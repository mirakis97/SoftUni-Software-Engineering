using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetSum(n, 0)); 
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }
            return arr[index] + GetSum(arr, index + 1);
        }
    }
}
