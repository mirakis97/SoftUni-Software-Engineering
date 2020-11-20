using System;

namespace _02.Triangl_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double sideOfTriangle = double.Parse(Console.ReadLine());
            double heightOfTriangle = double.Parse(Console.ReadLine());
            //Calculations
            double area = (sideOfTriangle * heightOfTriangle) / 2;
            //Output
            Console.WriteLine($"{area:f2}");
        }
    }
}
