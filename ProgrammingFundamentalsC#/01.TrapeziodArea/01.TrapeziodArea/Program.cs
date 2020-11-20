using System;

namespace _01.TrapeziodArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            //Calculations
            double faceOfTrapezoid = (b1 + b2) * h / 2;

            Console.WriteLine($"{faceOfTrapezoid:f1}");
        }
    }
}
