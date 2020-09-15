using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double budgetForMovie = double.Parse(Console.ReadLine());
            int numbersOfExtras = int.Parse(Console.ReadLine());
            double priceForClothesForOneStatist = double.Parse(Console.ReadLine());
            //Calculations
            double priceForDecor = budgetForMovie * 0.10;
            
            //Output
            
            if (numbersOfExtras > 150)
            {
                priceForClothesForOneStatist *= 0.90;
            }
            double priceForClothes = numbersOfExtras * priceForClothesForOneStatist;
            double priceOfTheMovie = priceForDecor + priceForClothes;

            if (priceOfTheMovie > budgetForMovie)
            {
                double neededMoney = priceOfTheMovie - budgetForMovie;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");
            }
            else if (priceOfTheMovie <= budgetForMovie)
            {
                double priceLeft = budgetForMovie - priceOfTheMovie;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {priceLeft:f2} leva left.");
            }
        }
    }
}
