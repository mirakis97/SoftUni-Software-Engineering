using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            const int roses = 5;
            const double dahlias = 3.80;
            const double tulips = 2.80;
            const int narcissus = 3;
            const double gladiolus = 2.50;

            string typeOfFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            
            if (typeOfFlower == "Roses")
            {
                if (numberOfFlowers > 80)
                {
                    double money = (numberOfFlowers * roses) * 0.10;
                    totalMoney = (numberOfFlowers * roses) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * roses;
                }
            }                
            if (typeOfFlower == "Dahlias")
            { 
                if (numberOfFlowers > 90)
                {
                    double money = (numberOfFlowers * dahlias) * 0.15;
                    totalMoney = (numberOfFlowers * dahlias) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * dahlias;
                }
            }
            if (typeOfFlower == "Tulips")
            {
                if (numberOfFlowers > 80)
                {
                    double money = (numberOfFlowers * tulips) * 0.15;
                    totalMoney = (numberOfFlowers * tulips) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * tulips;
                }
            }
            if (typeOfFlower == "Narcissus")
            {
                if (numberOfFlowers < 120)
                {
                    double money = (numberOfFlowers * narcissus) * 0.15;
                    totalMoney = money + (numberOfFlowers * narcissus);
                }
                else
                {
                    totalMoney = numberOfFlowers * narcissus;
                }
            }
            if (typeOfFlower == "Gladiolus")
            {
                if (numberOfFlowers < 80)
                {
                    double money = (numberOfFlowers * gladiolus) * 0.20;
                    totalMoney = money + (numberOfFlowers * gladiolus);
                }
                else
                {
                    totalMoney = numberOfFlowers * gladiolus;
                }
            }
            if (budget >= totalMoney)
            {
                double moneyLeft = budget - totalMoney;
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {moneyLeft:f2} leva left.");
            }
            if (budget < totalMoney)
            {
                double moneyNeeded = totalMoney - budget;
                Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
            }
        }
    }
}
