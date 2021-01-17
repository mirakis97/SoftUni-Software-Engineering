using System;

namespace _06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            const double basket = 1.50;
            const double wreath = 3.80;
            const double choclateBunny = 7.00;

            double totalSum = 0;
            int items = 0;
            int clients = int.Parse(Console.ReadLine());
            while (true)
            {
                string cmd = Console.ReadLine();

                while (cmd == "Finish")
                {

                    clients--;
                    
                    cmd = Console.ReadLine();
                    if (clients == 0)
                    {
                        break;
                    }
                    Console.WriteLine($"You purchased {items} items for {totalSum:f2} leva.");
                    continue;
                }
               
                switch (cmd)
                {
                    case "basket":
                        totalSum += basket;
                        break;
                    case "wreath":
                        totalSum += wreath;
                        break;
                    case "chocolate bunny":
                        totalSum += choclateBunny;
                        break;
                }
                items++;
            }

            
        }
    }
}
