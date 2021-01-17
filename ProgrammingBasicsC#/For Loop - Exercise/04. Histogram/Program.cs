using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            const double doubleConverter = 1.0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            for (int i = 0; i < num; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 200)
                {
                    p1++;
                }
                else if (n < 400)
                {
                    p2++;
                }
                else if (n < 600)
                {
                    p3++;
                }
                else if (n < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }
            double pp1 = doubleConverter * p1 / num * 100;
            double pp2 = doubleConverter * p2 / num * 100;
            double pp3 = doubleConverter * p3 / num * 100;
            double pp4 = doubleConverter * p4 / num * 100;
            double pp5 = doubleConverter * p5 / num * 100;

            Console.WriteLine($"{pp1:f2}%");
            Console.WriteLine($"{pp2:f2}%");
            Console.WriteLine($"{pp3:f2}%");
            Console.WriteLine($"{pp4:f2}%");
            Console.WriteLine($"{pp5:f2}%");
        }
    }
}
