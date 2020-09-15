using System;
using System.Text.RegularExpressions;

namespace _07._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfTrip = double.Parse(Console.ReadLine());
            int numberOfCrosswords = int.Parse(Console.ReadLine());
            int numberOfTalkingDolls = int.Parse(Console.ReadLine());
            int numberOfTeddyBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            double finalPrice = (numberOfCrosswords * 2.6) + (numberOfTalkingDolls * 3) + (numberOfTeddyBears * 4.10) + (numberOfMinions * 8.20) + (numberOfTrucks * 2);
            int finalNumberOfToys = numberOfCrosswords + numberOfTalkingDolls + numberOfTeddyBears + numberOfMinions + numberOfTrucks;

            if (finalNumberOfToys >= 50)
            {
                //finalPrice = finalPrice * 0.75
                finalPrice *= 0.75;
            }

            //Rent 
            finalPrice *= 0.90;

            if (finalPrice >= priceOfTrip)
            {
                double moneyLeft = finalPrice - priceOfTrip;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else if (finalPrice < priceOfTrip)
            {
                    double moneyWeNeed = priceOfTrip - finalPrice;
                    Console.WriteLine($"Not enough money! {moneyWeNeed:f2} lv needed.");
            }
        }
    }
}
