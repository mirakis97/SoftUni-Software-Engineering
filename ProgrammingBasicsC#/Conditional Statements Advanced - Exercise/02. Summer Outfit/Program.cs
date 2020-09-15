using System;

namespace _02._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if (degrees >= 10 && degrees <= 18)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
            }
            if (degrees > 18 && degrees <= 24)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
            }
            if (degrees >= 25)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                }
            }
        }
    }
}
