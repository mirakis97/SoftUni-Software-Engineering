using System;

namespace Conditional_Statements_Advanced___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine();
            int numOfRow = int.Parse(Console.ReadLine());
            int numOfColums = int.Parse(Console.ReadLine());

            double price = 0;
            switch (typeOfProjection)
            {
                case "Premiere":
                    price = 12.00;
                    double income = price * numOfColums * numOfRow;
                    Console.WriteLine($"{income:f2} leva");
                    break;
                case "Normal":
                    price = 7.50;
                    double normalIncome = price * numOfColums * numOfRow;
                    Console.WriteLine($"{normalIncome:f2} leva");
                    break;
                case "Discount":
                    price = 5.00;
                    double discountIncome = price * numOfColums * numOfRow;
                    Console.WriteLine($"{discountIncome:f2} leva");
                    break;
            }
                
        }
    }
}
