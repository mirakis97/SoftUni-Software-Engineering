using System;

namespace _01._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            const double menuWithChiken= 10.35;
            const double menuWithFish = 12.40;
            const double menuVegeterian = 8.15;
            const double delivery = 2.50;
            int chikenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegiMenu = int.Parse(Console.ReadLine());

            double priceForChiken = chikenMenu * menuWithChiken;
            double priceForFish = fishMenu * menuWithFish;
            double priceForVegi = vegiMenu * menuVegeterian;

            double menuSum = priceForChiken + priceForFish + priceForVegi;

            double priceFordesert = menuSum * 0.20;

            double totalSum = menuSum + priceFordesert + delivery;

            Console.WriteLine($"Total: {totalSum:f2}");

        }
    }
}
