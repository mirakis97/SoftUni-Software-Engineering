using System;
using System.Linq;

namespace _01._Binary_Search
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, num));
        }

        public static int BinarySearch(int[] arr, int key)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                var element = arr[mid];
                if (element == key)
                {
                    return mid;
                }
                if (key > element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
