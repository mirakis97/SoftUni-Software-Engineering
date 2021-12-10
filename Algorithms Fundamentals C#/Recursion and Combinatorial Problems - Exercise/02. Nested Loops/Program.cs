using System;

namespace _02._Nested_Loops
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var m = new int[n];
            Gen01(m, 0);
        }
        private static void Gen01(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                Gen01(arr, index + 1);
            }
        }
    }
}