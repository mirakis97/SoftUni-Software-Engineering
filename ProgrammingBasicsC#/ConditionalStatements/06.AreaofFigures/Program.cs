using System;

namespace _06.AreaofFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string faceOf = Console.ReadLine();

            if (faceOf == "square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * a:f3}");
            }
            if (faceOf == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b:f3}");
            }
            if (faceOf == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * a * 3.14159:f3}");
            }
            if (faceOf == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b / 2:f3}");
            }

        }
    }
}
