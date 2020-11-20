using System;

namespace _01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bitcoin = 1168;
            const double ioana = 0.15;
            const double USD = 1.76;
            const double EUR = 1.95;

            int numberOfBitcoin = int.Parse(Console.ReadLine());
            double numberIoan = double.Parse(Console.ReadLine());
            double comision = double.Parse(Console.ReadLine());

            double priceIoan = (numberIoan * ioana) * USD;
            double totalEuro = (numberOfBitcoin * bitcoin) + priceIoan;
            double finalEuro = totalEuro / EUR; 
            double totalComision = comision * 0.01;
            double priceWithComision = finalEuro * totalComision;
            double finalPrice = finalEuro - priceWithComision;
            Console.WriteLine($"{finalPrice:f2}");

        }
    }
}
