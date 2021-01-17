using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int o = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            for (int j = 0; j <= n; j++)
            {
                p1++;
                for (int s = 0; s <= l; s++)
                {
                    p2++;
                    for (int a = 0; a <= b; a++)
                    {
                        p3++;
                        for (int c = 0; c <= o; c++)
                        {
                            p4++;
                        }
                    }
                }

            }
            if (p1 % 2 == 0 && p3 % 2 == 0 && p2 % 1 == 0 && p4 % 1 == 0)
            {
                Console.WriteLine($"{p1}{p2} - {p3}{p4}");
            }
            else
            {
                Console.WriteLine("Cannot change the same player.");
            }
        }
    }
}
