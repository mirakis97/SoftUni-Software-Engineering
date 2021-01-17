using System;

namespace _09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double metersYardGreening = double.Parse(Console.ReadLine());
            //Calculations
            double priceForGreeningOfTheFullPlace = metersYardGreening * 7.61;
            double discountOfThePrice = priceForGreeningOfTheFullPlace * 0.18;
            double finalPriceForTheService = priceForGreeningOfTheFullPlace - discountOfThePrice;
            //Output
            Console.WriteLine($"The final price is: {finalPriceForTheService} lv.");
            Console.WriteLine($"The discount is: {discountOfThePrice} lv.");

        }
    }
}
