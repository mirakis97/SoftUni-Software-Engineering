using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            const int studioPriceMayOctober = 50;
            const int apartmentPriceMayOctober = 65;
            const double studioPriceJuneSeptember = 75.20;
            const double apartmentPriceJuneSeptember = 68.70;
            const int studioPriceJulyAugust = 76;
            const int apartmentPriceJulyAugust = 77;

            string month = Console.ReadLine();
            int numbersOfNights = int.Parse(Console.ReadLine());

            double totalPriceForStudio = 0;
            double totalPriceForApartment = 0;

            switch (month)
            {
                case "May":
                    totalPriceForApartment = numbersOfNights * apartmentPriceMayOctober;
                    totalPriceForStudio = numbersOfNights * studioPriceMayOctober;
                    if (numbersOfNights > 7 && numbersOfNights <= 14)
                    {

                        totalPriceForStudio -= totalPriceForStudio * 0.05;
                    }
                    else if (numbersOfNights > 14)
                    {

                        totalPriceForStudio -= totalPriceForStudio * 0.30;
                    }
                    break;
                case "October":
                    totalPriceForApartment = numbersOfNights * apartmentPriceMayOctober;
                    totalPriceForStudio = numbersOfNights * studioPriceMayOctober;
                    if (numbersOfNights > 7 && numbersOfNights <= 14)
                    {

                        totalPriceForStudio -= totalPriceForStudio * 0.05;
                    }
                    else if (numbersOfNights > 14)
                    {

                        totalPriceForStudio -= totalPriceForStudio * 0.30;
                    }
                    break;
                case "June":
                    totalPriceForApartment = numbersOfNights * apartmentPriceJuneSeptember;
                    totalPriceForStudio = numbersOfNights * studioPriceJuneSeptember;
                    if (numbersOfNights > 14)
                    {
                        totalPriceForStudio -= totalPriceForStudio * 0.20;
                    }
                    break;
                case "September":
                    totalPriceForApartment = numbersOfNights * apartmentPriceJuneSeptember;
                    totalPriceForStudio = numbersOfNights * studioPriceJuneSeptember;
                    if (numbersOfNights > 14)
                    {
                        totalPriceForStudio -= totalPriceForStudio * 0.20;
                    }
                    break;
                case "July":
                    totalPriceForApartment = numbersOfNights * apartmentPriceJulyAugust;
                    totalPriceForStudio = numbersOfNights * studioPriceJulyAugust;
                    break;
                case "August":
                    totalPriceForApartment = numbersOfNights * apartmentPriceJulyAugust;
                    totalPriceForStudio = numbersOfNights * studioPriceJulyAugust;
                    break;

            }
            if (numbersOfNights > 14)
            {
                totalPriceForApartment -= totalPriceForApartment * 0.10;
            }

            Console.WriteLine($"Apartment: {totalPriceForApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalPriceForStudio:f2} lv.");
        }   
    }
}
