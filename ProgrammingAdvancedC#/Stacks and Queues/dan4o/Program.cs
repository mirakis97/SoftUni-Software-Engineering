using System;

namespace dan4o
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double result = num * num2;
            Console.WriteLine($"{result:f2}") ;
        }
    }
}
