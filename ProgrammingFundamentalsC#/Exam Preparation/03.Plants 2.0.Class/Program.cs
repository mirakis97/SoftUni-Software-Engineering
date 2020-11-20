using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsNum = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < plantsNum; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (!plants.ContainsKey(name))
                {
                    Plant plant = new Plant(rarity, new List<double>());
                    plants.Add(name, plant);
                }
                else
                {
                    plants[name].Rarity = rarity;
                }

            }

            string[] comandsData = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Exhibition")
            {

                string comand = comandsData[0];
                string[] curPlant = comandsData[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string name = curPlant[0];

                if (!plants.ContainsKey(name))
                {
                    Console.WriteLine("error");
                    comandsData = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (comand == "Rate")
                {
                    double rating = double.Parse(curPlant[1]);
                    plants[name].Rate.Add(rating);
                }
                else if (comand == "Update")
                {
                    int newRarity = int.Parse(curPlant[1]);
                    plants[name].Rarity = newRarity;
                }
                else if (comand == "Reset")
                {
                    plants[name].Rate.Clear();
                }
                else
                {
                    Console.WriteLine("error");
                }

                comandsData = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in plants)
            {
                if (!item.Value.Rate.Any())
                {
                    item.Value.Rate.Add(0);
                }
            }

            var sortedPlants = plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rate.Average());
            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in sortedPlants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rate.Average():f2}");
            }
        }
    }

    class Plant
    {
        public Plant(int rarity, List<double> rate)
        {
            Rarity = rarity;
            Rate = rate;
        }

        public int Rarity { get; set; }
        public List<double> Rate { get; set; }
    }
}