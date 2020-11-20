using System;

namespace _05._Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1++;
                }
                if (num % 3 == 0) 
                {
                    p2++;
                }
                if (num % 4 == 0) 
                {
                    p3++;
                }
            }

            double p11 = p1 / n * 100;
            double p22 = p2 / n * 100;
            double p33 = p3 / n * 100;
            Console.WriteLine($"{p11:F2}%");
            Console.WriteLine($"{p22:f2}%");
            Console.WriteLine($"{p33:f2}%");
        }
    }
}
