using System;

namespace _08.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double lengtInCentimeters = double.Parse(Console.ReadLine());
            double widthInCentimeters = double.Parse(Console.ReadLine());
            double heightInCentimeters = double.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine());
            //Calculations
            double capacityOfAquarium = lengtInCentimeters * widthInCentimeters * heightInCentimeters;
            double litersOfWater = capacityOfAquarium * 0.001;
            double realRate = rate * 0.01;
            double literWeNeeed = litersOfWater * (1 - realRate);
            //Output
            Console.WriteLine(literWeNeeed);
        }
    }
}
