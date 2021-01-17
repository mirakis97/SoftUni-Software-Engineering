using System;

namespace _08.Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double numbersOfDogs = double.Parse(Console.ReadLine());
            double numersOfOtherAnimals = double.Parse(Console.ReadLine());
            //Calculations
            double foodForOneDog = numbersOfDogs * 2.50;
            double foodForOhterAnimals = numersOfOtherAnimals * 4;
            //Output
            double finalPrice = foodForOneDog + foodForOhterAnimals;

            Console.WriteLine($"{finalPrice} lv.");




        }
    }
}
