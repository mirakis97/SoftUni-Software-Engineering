using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double hight = double.Parse(Console.ReadLine());
            double wedith = double.Parse(Console.ReadLine());
            double area = GetRectangleArea(hight, wedith);
            Console.WriteLine(area);
        }

        static double GetRectangleArea(double hight, double width)
        {
            return hight * width;
        }
    }
}
