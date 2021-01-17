using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int peopleNum = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double priceForOne = 0.0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    switch (timeOfDay)
                    {
                        case "day":
                            priceForOne = 10.50;
                            break;
                        case "night":
                            priceForOne = 8.40;
                            break;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    switch (timeOfDay)
                    {
                        case "day":
                            priceForOne = 12.60;
                            break;
                        case "night":
                            priceForOne = 10.20;
                            break;
                    }
                    break;
            }

            if (peopleNum >= 4)
            {
                priceForOne -= priceForOne * 0.10;
                if (hours >= 5)
                {
                    priceForOne -= priceForOne * 0.50;
                }

            }

            double totalSum = (priceForOne * peopleNum) * hours;

            Console.WriteLine($"Price per person for one hour: {priceForOne:f2}");
            Console.WriteLine($"Total cost of the visit: {totalSum:f2}");

        }
    }
}
