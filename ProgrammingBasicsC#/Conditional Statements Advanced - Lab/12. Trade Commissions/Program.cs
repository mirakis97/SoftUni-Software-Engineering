using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());

            double comission = -1.0;

            if (city == "Sofia")
            {
                if (money >= 0 && money <= 500)
                {
                  comission = money * 0.05;
                }
                else if (money > 500 && money <= 1000)
                {
                    comission = money * 0.07;
                }
                else if (money > 1000 && money <= 10000)
                {
                    comission = money * 0.08;
                }
                else if (money > 10000)
                {
                    comission = money * 0.12;
                }
                Console.WriteLine($"{comission:f2}");
            }
            if (city == "Varna")
            {
                if (money >= 0 && money <= 500)
                {
                    comission = money * 0.045;
                }
                else if (money > 500 && money <= 1000)
                {
                    comission = money * 0.075;
                }
                else if (money > 1000 && money <= 10000)
                {
                    comission = money * 0.10;
                }
                else if (money > 10000)
                {
                    comission = money * 0.13;
                }
                Console.WriteLine($"{comission:f2}");
            }
            if (city == "Plovdiv")
            {
                
                if (money >= 0 && money <= 500)
                {
                    comission = money * 0.055;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (money > 500 && money <= 1000)
                {
                    comission = money * 0.08;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (money > 1000 && money <= 10000)
                {
                    comission = money * 0.12;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (money > 10000)
                {
                    comission = money * 0.145;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (money < 0)
                {
                    Console.WriteLine("error");
                }
            }

            if (city != "Sofia" && city != "Varna" && city != "Plovdiv")
            {
                Console.WriteLine("error");
            }
        }
    }
}
