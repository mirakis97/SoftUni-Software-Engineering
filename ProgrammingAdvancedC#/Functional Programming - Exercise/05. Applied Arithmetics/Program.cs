using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            string comand = Console.ReadLine();
            Func<int, int> arithmeticFunc = num => num;
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (comand != "end")
            {
                if (comand == "add")
                {
                    arithmeticFunc = num => num + 1;
                    numbers = numbers.Select(arithmeticFunc).ToList();
                }
                else if (comand == "multiply")
                {
                    arithmeticFunc = num => num * 2;
                    numbers = numbers.Select(arithmeticFunc).ToList();
                }
                else if (comand == "subtract")
                {
                    arithmeticFunc = num => num - 1;
                    numbers = numbers.Select(arithmeticFunc).ToList();
                }
                else if (comand == "print")
                {
                    print(numbers);
                }

                comand = Console.ReadLine();
            }
        }
    }
}
