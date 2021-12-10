using System;

namespace _01._Reverse_Array
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split();
            //for (int i = 0; i < array.Length / 2; i++)
            //{
            //    var right= array.Length - 1 - i;
            //    Swap(array, i, right);
            //}

            ReversedArray(0, array);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void ReversedArray(int left, string[] array)
        {
            if (left >= array.Length / 2)
            {
                return;
            }

            var right = array.Length - 1 - left;
            Swap(array, left, right);
             
            ReversedArray(left + 1, array);
        }

        private static void Swap(string[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
