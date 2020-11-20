using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {

            string placesOnMap = Console.ReadLine();
            int travelPoints = 0;
            string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1";
            Regex mathcDestination = new Regex(pattern);
            var match = mathcDestination.Matches(placesOnMap);
            List<string> clear = new List<string>();
            foreach (Match item in match)
            {
                
                if (item.Success)
                {
                    clear.Add(item.ToString().Substring(1, (item.Length - 2)));
                }
                
                var points = item.Value.Length;

                travelPoints += points - 2;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", clear)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
