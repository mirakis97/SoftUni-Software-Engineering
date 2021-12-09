using System;

namespace _03._Generating_0_1_Vectors
{
    internal class Program
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
                Console.WriteLine(string.Join("", arr));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                Gen01(arr,index + 1);
            }
        }
    }
}
