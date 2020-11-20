using System;

namespace _03._Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();
            string name = Console.ReadLine();
            double finalSum = 0;
            int counter = 0;
            while (cmd != "Stop")
            {
                double priceForProduct = double.Parse(name);
                counter++;
                if (counter % 3 == 0)
                {
                    priceForProduct = priceForProduct / 2;
                    
                }
                
                budget -= priceForProduct;
                finalSum += priceForProduct;
                if (budget < 0)
                {
                    
                    Console.WriteLine($"You don't have enough money!");
                    Console.WriteLine($"You need {Math.Abs(budget):f2} leva!");
                    Environment.Exit(0);
                }

                
                cmd = Console.ReadLine();
                name = Console.ReadLine();
                
            }
            Console.WriteLine($"You bought {counter} products for {finalSum:f2} leva.");
        }
    }
}
