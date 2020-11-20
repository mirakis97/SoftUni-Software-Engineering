using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //static data
            int priceForCake = 45;
            double priceForWaffle = 5.80;
            double priceForPancake = 3.20;
            //Input
            int daysForCamping = int.Parse(Console.ReadLine());
            int numbersOfCookers = int.Parse(Console.ReadLine());
            int numbersOfCakes = int.Parse(Console.ReadLine());
            int numbersOfWaffles = int.Parse(Console.ReadLine());
            int numbersOfPancakes = int.Parse(Console.ReadLine());
            //Calculations
            double totalCakes = numbersOfCakes * priceForCake;
            double totalWaffles = numbersOfWaffles * priceForWaffle;
            double totalPancakes = numbersOfPancakes * priceForPancake;
            double totalSumPerDay = (totalCakes + totalWaffles + totalPancakes) * numbersOfCookers;
            double totalSumForCamping = totalSumPerDay * daysForCamping;
            double totalAfterTheTax = totalSumForCamping - (totalSumForCamping / 8);           
            Console.WriteLine(totalAfterTheTax);
        }
    }
}
