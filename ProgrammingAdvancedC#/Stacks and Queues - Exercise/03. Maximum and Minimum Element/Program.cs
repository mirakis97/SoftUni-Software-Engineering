using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] comands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int firstCmd = comands[0];
                
                if (firstCmd == 1)
                {
                    int num = comands[1];
                    numbers.Push(num);
                }
                else if (firstCmd == 2)
                {
                    if (!numbers.Any())
                    {
                        continue;
                    }
                    numbers.Pop();
                }
                else if (firstCmd == 3)
                {
                    if (!numbers.Any())
                    {
                        continue;
                    }
                    Console.WriteLine(numbers.Max());
                }
                else if (firstCmd == 4)
                {
                    if (!numbers.Any())
                    {
                        continue;
                    }
                    Console.WriteLine(numbers.Min());
                }
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
