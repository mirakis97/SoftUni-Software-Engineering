using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = (new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country]= new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                var continentName = continent.Key;
                Console.WriteLine($"{continentName}:");

                foreach (var contryCities in continent.Value)
                {
                    var contryName = contryCities.Key;
                    var cities = contryCities.Value;

                    Console.WriteLine($"{contryName} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
