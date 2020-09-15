using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());

            double price = 0;
            
            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit)
                    {
                        case "banana":
                            price = 2.50;
                            break;
                        case "apple":
                            price = 1.20;
                            break;
                        case "orange":
                            price = 0.85;
                            break;
                        case "grapefruit":
                            price = 1.45;
                            break;
                        case "kiwi": 
                            price = 2.70;
                            break;
                        case "pineapple": 
                            price = 5.50;
                            break;
                        case "grapes": 
                            price = 3.85;
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            price = 2.70;
                            break;
                        case "apple":
                            price = 1.25;
                            break;
                        case "orange":
                            price = 0.90;
                            break;
                        case "grapefruit":
                            price = 1.60;
                            break;
                        case "kiwi":
                            price = 3.00;
                            break;
                        case "pineapple":
                            price = 5.60;
                            break;
                        case "grapes":
                            price = 4.20;
                            break;
                    }
                    break;
            }
             ;
            if (fruit != "banana" && fruit != "apple" && fruit != "orange" && fruit != "grapefruit" && fruit != "kiwi" && fruit != "pineapple" && fruit != "grapes")
            {
                    Console.WriteLine("error");
            }
            else if (dayOfWeek != "Monday" && dayOfWeek != "Tuesday" && dayOfWeek != "Wednesday" && dayOfWeek != "Thursday" && dayOfWeek != "Friday" && dayOfWeek != "Saturday" && dayOfWeek != "Sunday")
                {
                    Console.WriteLine("error");
                }
                else
            {
                Console.WriteLine($"{number * price:f2}");
            }
        }
    }
}
