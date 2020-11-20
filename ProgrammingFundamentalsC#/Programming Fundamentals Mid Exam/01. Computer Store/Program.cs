using System;
using System.Xml.Schema;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string cmd = Console.ReadLine();
            double totalPrice = 0;
            while (cmd != "regular" && cmd != "special")
            {
                double prices = double.Parse(cmd);
                if (prices < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else 
                {
                    totalPrice += prices;
                }
                
                cmd = Console.ReadLine();
            }

            double taxes = totalPrice * 0.20;

            double totalPriceWithTax = totalPrice + taxes;
            if (cmd == "special")
            {
                totalPriceWithTax -= totalPriceWithTax * 0.10;
            }
            else if (totalPrice == 0 )
            {
                Console.WriteLine("Invalid order!");
                Environment.Exit(0);
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPriceWithTax:f2}$");
        }
    }
}
