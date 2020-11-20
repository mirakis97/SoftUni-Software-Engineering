using System;

namespace _07.Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double priceOfStrawberry = double.Parse(Console.ReadLine());
            double amountOfBananInKilos = double.Parse(Console.ReadLine());
            double amountOfOrangeInKilos = double.Parse(Console.ReadLine());
            double amountOfRaspberry = double.Parse(Console.ReadLine());
            double amountOfStrawberryInKilos = double.Parse(Console.ReadLine());
            //Еxplanation
            double priceOfRaspberry = priceOfStrawberry / 2;
            double priceOfOrange = priceOfRaspberry - (0.4 * priceOfRaspberry);
            double priceOfBananas = priceOfRaspberry - (0.8 * priceOfRaspberry);
            //Calculations
            double priceOfKilosRaspberry = amountOfRaspberry * priceOfRaspberry;
            double priceOfKilosOrange = amountOfOrangeInKilos * priceOfOrange;
            double priceOfKilosBananas = amountOfBananInKilos * priceOfBananas;
            double priceOfKilosStrawberry = priceOfStrawberry * amountOfStrawberryInKilos;
            double generalPrice = priceOfKilosRaspberry + priceOfKilosOrange + priceOfKilosBananas + priceOfKilosStrawberry;
            //Output
            Console.WriteLine($"{generalPrice:f2}");



        }
    }
}
