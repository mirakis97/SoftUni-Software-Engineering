using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int items = int.Parse(Console.ReadLine());

            Orders(product, items); 

        }
        static void Orders(string product, int item)
        {
            double price = 0.0;
            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }
            double totalSum = price * item;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
