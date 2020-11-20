using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string patern = @"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";
            MatchCollection mathces = Regex.Matches(input, patern);
            int caluoriesForDay = 0;

            foreach (Match item in mathces)
            {
                int calories = (int.Parse)(item.Groups["calories"].Value);
                caluoriesForDay += calories;
            }
            int days = caluoriesForDay / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in mathces)
            {
                Console.WriteLine($"Item: {item.Groups["name"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }

        }
    }
}
