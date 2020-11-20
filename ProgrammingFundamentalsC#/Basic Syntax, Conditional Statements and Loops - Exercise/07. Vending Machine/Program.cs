using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string moneyReceive = Console.ReadLine();
            double insertedAmount = 0;

            while (moneyReceive != "Start")
            {
                double curentCoin = double.Parse(moneyReceive);

                if (curentCoin == 0.1 || curentCoin == 0.2 || curentCoin == 0.5 || curentCoin == 1 || curentCoin == 2)
                {
                    insertedAmount += curentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {curentCoin}");
                }

                moneyReceive = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                double productPrice = 0;

                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        continue;
                }

                if (productPrice <= insertedAmount)
                {
                    insertedAmount -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {insertedAmount:F2}");
        }
    }
}
