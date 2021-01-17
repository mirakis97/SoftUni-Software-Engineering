using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int wedith = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cake = wedith * lenght;

            while (true)
            {
                string comand = Console.ReadLine();

                if (cake <= 0 || comand == "STOP" )
                {
                    break;
                }
                int cakePices = int.Parse(comand);
                cake -= cakePices;
            }
            if (cake >= 0)
            {
                Console.WriteLine($"{cake} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
        }
    }
}
