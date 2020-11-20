using System;
using System.Globalization;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int sumOfDiggits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumOfDiggits += digits % 10;
                    digits = digits / 10;
                }
                bool isSpcial = (sumOfDiggits == 5) || (sumOfDiggits == 7) || (sumOfDiggits == 11);

                Console.WriteLine($"{i} -> {isSpcial}");

            }
        }
    }
}
