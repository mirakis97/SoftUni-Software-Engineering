using System;
using System.Linq;
namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[]condense =

            for (int i = 0; i < numbers.Length; i++)
            {
                condense[i] = numbers[i] + numbers[i + 1];

            }
        }
    }
}
