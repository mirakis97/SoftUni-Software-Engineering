using System;

namespace _04.VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double firstRow = double.Parse(Console.ReadLine());
            double secondRow = double.Parse(Console.ReadLine());
            int thirdRow = int.Parse(Console.ReadLine());
            int forthRow = int.Parse(Console.ReadLine());
            //Calculations
            double vegetabelsPrice = firstRow * thirdRow;
            double fruitsPrce = secondRow * forthRow;
            double finalPrice = vegetabelsPrice + fruitsPrce;
            double priceInEuro = finalPrice / 1.94;
            //Output
            Console.WriteLine($"{priceInEuro:f2}");

        }
    }
}
