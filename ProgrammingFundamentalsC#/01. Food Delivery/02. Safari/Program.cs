using System;

namespace _02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            const double literFuel = 2.10;
            const int priceForTourGide = 100;

            double budjet = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double priceForFuel = fuel * literFuel;
            double priceWithGuide = priceForFuel + priceForTourGide;

            switch (dayOfWeek)
            {
                case "Saturday":
                    priceWithGuide = priceWithGuide - (priceWithGuide * 0.10);
                    break;
                case "Sunday":
                    priceWithGuide = priceWithGuide - (priceWithGuide * 0.20);
                    break;
                    
            }

            if (budjet > priceWithGuide)
            {
                double moneyLeft = budjet - priceWithGuide;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv. ");
            }
            else
            {
                double moneyNeeded = priceWithGuide - budjet;
                Console.WriteLine($"Not enough money! Money needed: {moneyNeeded:f2} lv.");
            }
        }
    }
}
