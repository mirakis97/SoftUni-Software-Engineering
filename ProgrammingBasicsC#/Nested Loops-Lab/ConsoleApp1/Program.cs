using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int steps = 0;
            bool flag = false;
            for (int i = firstNum; i <= secondNum; i++)
            {
                for (int m = firstNum; m <= secondNum; m++)
                {
                    steps++;
                    if (i + m == thirdNum)
                    {
                        Console.WriteLine($"Combination N:{steps} ({i} + {m} = {i + m})");
                        flag = true;
                        break;
                    }
                    
                }
                if (flag)
                {
                    break;
                }
            }
            if(!flag)
            {
                Console.WriteLine($"{steps} combinations - neither equals {thirdNum}");
            }
        }
    }
}
