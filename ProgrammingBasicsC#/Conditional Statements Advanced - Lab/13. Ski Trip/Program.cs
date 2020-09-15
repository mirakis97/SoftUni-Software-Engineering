using System;
using System.Runtime.CompilerServices;

namespace _13._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            const double roomForOnePerson = 18.00;
            const double apartment = 25.00;
            const double presidentRoom = 35.00;

            int daysForStay = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string quality = Console.ReadLine();

            double totalMoney = 0;
            if (daysForStay < 10)
            {
                if (typeOfRoom == "room for one person")
                {
                    totalMoney = roomForOnePerson * (daysForStay - 1);
                }
                else if (typeOfRoom == "apartment")
                {
                    totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.30;
                }
                else if (typeOfRoom == "president apartment")
                {
                    totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.10;
                }
            }
            else if (daysForStay >= 10 && daysForStay < 15)
            {
                if (typeOfRoom == "room for one person")
                {
                    totalMoney = roomForOnePerson * (daysForStay - 1) ;
                }
                else if (typeOfRoom == "apartment")
                {
                    totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.35;
                }
                else if (typeOfRoom == "president apartment")
                {
                    totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.15;
                }
            }
            else if (daysForStay >= 15)
            {
                if (typeOfRoom == "room for one person")
                {
                    totalMoney = roomForOnePerson * (daysForStay - 1);
                }
                else if (typeOfRoom == "apartment")
                {
                    totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.50;
                }
                else if (typeOfRoom == "president apartment")
                {
                    totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.20;
                }
            }
            if (quality == "positive")
            {
                double newPrice = totalMoney + (totalMoney * 0.25);
                Console.WriteLine($"{newPrice:f2}");
            }
            else if (quality == "negative")
            {
                double newPrice = totalMoney - (totalMoney * 0.10);
                Console.WriteLine($"{newPrice:f2}");
            }
        }
    }
}
