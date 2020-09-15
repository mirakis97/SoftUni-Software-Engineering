using System;
using System.Security.Authentication;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            const int springPrice = 3000;
            const int summerAndAutumnPrice = 4200;
            const int winterPrice = 2600;

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFisherman = int.Parse(Console.ReadLine());
            double totalMoney = 0;

            switch (season)
            {
                case "Spring":
                    totalMoney = springPrice;
                    break;
                case "Summer":
                    totalMoney = summerAndAutumnPrice;
                    break;
                case "Autumn":
                    totalMoney = summerAndAutumnPrice;
                    break;
                case "Winter":
                    totalMoney = winterPrice;
                    break;
            }
            if (numberOfFisherman <=6)
            {
                totalMoney -= totalMoney * 0.10;
            }
            else if (numberOfFisherman > 6 && numberOfFisherman <= 11)
            {
                totalMoney -= totalMoney * 0.15;
            }
            else
            {
                totalMoney -= totalMoney * 0.25;
            }
            if (numberOfFisherman % 2 == 0 && season != "Autumn")
            {
                totalMoney -= totalMoney * 0.05;
            }
            if (budget >= totalMoney)
            {
                double moneyLeft = budget - totalMoney;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeeded = totalMoney - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
            }
        }
    }
}
