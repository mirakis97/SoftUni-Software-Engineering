using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string people = Console.ReadLine();
            string dayOfWeekend = Console.ReadLine();
            double price = 0;
            switch (dayOfWeekend)
            {
                case "Friday":
                    if (people == "Students")
                    {
                        price = 8.45;
                    }
                    else if (people == "Business")
                    {
                        price = 10.90;
                    }
                    else if (people == "Regular")
                    {
                        price = 15;
                    }
                    break;
                case "Saturday":
                    if (people == "Students")
                    {
                        price = 9.80;
                    }
                    else if (people == "Business")
                    {
                        price = 15.60;
                    }
                    else if (people == "Regular")
                    {
                        price = 20;
                    }
                    break;
                case "Sunday":
                    if (people == "Students")
                    {
                        price = 10.46;
                    }
                    else if (people == "Business")
                    {
                        price = 16;
                    }
                    else if (people == "Regular")
                    {
                        price = 22.50;
                    }
                    break;
            }
            double firstPrice = number * price;
            double discountPrice = 0;
            switch (people)
            {
                case "Students":
                    if (number >= 30)
                    {
                        discountPrice = firstPrice * 0.15;
                    }
                    break;
                case "Business":
                    if (number >= 100)
                    {
                       discountPrice = firstPrice - (10 * price);
                        Console.WriteLine($"Total price: {discountPrice:f2}");
                        Environment.Exit(0);
                    }
                    break;
                case "Regular":
                    if (number >= 10 && number <= 20)
                    {
                        discountPrice = firstPrice * 0.05;
                    }
                    break;
                   
            }
            double totalPrice = firstPrice - discountPrice;
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
