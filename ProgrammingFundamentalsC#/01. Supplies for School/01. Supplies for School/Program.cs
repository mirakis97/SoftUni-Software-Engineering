using System;

namespace _01._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            const double packPen = 5.80;
            const double packMark = 7.20;
            const double washer = 1.20;

            double numOfPen = double.Parse(Console.ReadLine());
            double numMark = double.Parse(Console.ReadLine());
            double litersWash = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double priceForPen = numOfPen * packPen;
            double priceForMark = numMark * packMark;
            double priceForWash = litersWash * washer;
            double totalPrice = priceForMark + priceForPen + priceForWash;
            double priceWithDiscount = totalPrice - (totalPrice * discount / 100);

            Console.WriteLine($"{priceWithDiscount:f3}");
        }
    }
}
