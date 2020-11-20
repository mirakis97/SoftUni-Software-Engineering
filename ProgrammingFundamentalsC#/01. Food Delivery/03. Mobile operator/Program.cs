using System;

namespace _03._Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {

            double smallContract = 0;
            double middleContract = 0;
            double largeContrat = 0;
            double extraLargeContrat = 0;
            double totalSum = 0;
            string lengtOfContract = Console.ReadLine();
            string typeOfContract = Console.ReadLine();
            string mobileInternet = Console.ReadLine();
            int monthsOfContrat = int.Parse(Console.ReadLine());

            switch (lengtOfContract)
            {
                case "one":
                    smallContract = 9.98;
                    middleContract = 18.99;
                    largeContrat = 25.98;
                    extraLargeContrat = 35.99;
                    break;
                case "two":
                    smallContract = 8.58;
                    middleContract = 17.09;
                    largeContrat = 23.59;
                    extraLargeContrat = 31.79;
                    break;

            }
            switch (mobileInternet)
            {
                case "yes":
                    switch (typeOfContract)
                    {
                        case "Small":
                            totalSum = smallContract + 5.50;
                            break;
                        case "Middle":
                            totalSum = middleContract + 4.35;
                            break;
                        case "Large":
                            totalSum = largeContrat + 4.35;
                            break;
                        case "ExtraLarge":
                            totalSum = extraLargeContrat + 3.85;
                            break;
                    }
                    break;
                case "no":
                    switch (typeOfContract)
                    {
                        case "Small":
                            totalSum = smallContract;
                            break;
                        case "Middle":
                            totalSum = middleContract;
                            break;
                        case "Large":
                            totalSum = largeContrat;
                            break;
                        case "ExtraLarge":
                            totalSum = extraLargeContrat;
                            break;
                    }
                    break;
            }

            double totalPrice = totalSum * monthsOfContrat;
            if (lengtOfContract == "two")
            {
                double discountPrice = totalPrice * 0.0375;
                totalPrice = totalPrice - discountPrice;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
