using System;
using System.Text.RegularExpressions;

namespace _2._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\||#)(?<itemname>[A-Za-z ]+)\1(?<day>\d{2})\/(?<month>\d{2})\/(?<year>\d{2})\1(?<calories>\d{0,10000})\1";

            MatchCollection mathc = Regex.Matches(input, pattern);
            int caloriesPerDay = 0;
            foreach (Match item in mathc)
            {
                int calories = (int.Parse)(item.Groups["calories"].Value);
                caloriesPerDay += calories;
            }
            int days = caloriesPerDay / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in mathc)
            {
                Console.WriteLine($"Item: {match.Groups["itemname"].Value}, Best before: {match.Groups["day"].Value + "/" + match.Groups["month"].Value + "/" + match.Groups["year"].Value }, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
