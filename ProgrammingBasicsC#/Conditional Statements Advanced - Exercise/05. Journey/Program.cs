using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    double moneyLeft = budget * 0.30;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {moneyLeft:f2}");
                }
                else
                {
                    double moneyNeed = budget * 0.70;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {moneyNeed:f2}");

                }                    
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    double moneyLeft = budget * 0.40;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Camp - {moneyLeft:f2}");
                }
                else
                {
                    double moneyNeeded = budget * 0.80;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {moneyNeeded:f2}");
                }                    
            }
            else if (budget > 1000)
            {
                double moneyLeft = budget * 0.90;
                Console.WriteLine($"Somewhere in Europe");
                Console.WriteLine($"Hotel - {moneyLeft:f2}");
            }
        }
    }
}
