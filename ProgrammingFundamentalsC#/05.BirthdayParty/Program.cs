using System;

namespace _05.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double rentForHall = double.Parse(Console.ReadLine());
            //Calculations
            double cakePrice = rentForHall * 0.20;
            double drinksPrice = cakePrice - (0.45 * cakePrice);
            double animatorPrice = rentForHall / 3;
            double totalSum = rentForHall + cakePrice + drinksPrice + animatorPrice;
            //Output
            Console.WriteLine(totalSum);
        }
    }
}
