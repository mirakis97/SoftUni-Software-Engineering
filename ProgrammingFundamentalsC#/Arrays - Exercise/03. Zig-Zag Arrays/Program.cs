using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstArray = new string[n];
            string[] secondArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArray = Console.ReadLine()
                                                .Split(" ")
                                                .ToArray();
                string firstElemnt = currentArray[0];
                string secondElement = currentArray[1];

                if (i % 2 == 0)
                {
                    firstArray[i] = firstElemnt;
                    secondArray[i] = secondElement;
                }
                else if (i % 2 == 1)
                {
                    firstArray[i] = secondElement;
                    secondArray[i] = firstElemnt;
                }
            }
            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
