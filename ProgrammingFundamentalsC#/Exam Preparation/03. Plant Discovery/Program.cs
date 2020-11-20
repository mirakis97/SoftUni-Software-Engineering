using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            Dictionary<string, int> timesRated = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plant = input[0];
                double rarity = double.Parse(input[1]);
                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>() { rarity, 0 });

                }
                else
                {

                    plants[plant][0] = rarity;
                }
            }
            string[] cmdArgs = Console.ReadLine().Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "Exhibition")
            {
                string command = cmdArgs[0];


                string plant = cmdArgs[1];
                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");

                }
                else
                {
                    if (command == "Rate")
                    {
                        double rating = double.Parse(cmdArgs[2]);
                        plants[plant][1] += rating;
                        if (!timesRated.ContainsKey(plant))
                        {
                            timesRated.Add(plant, 1);
                        }
                        else
                        {
                            timesRated[plant]++;
                        }
                    }
                    else if (command == "Update")
                    {
                        double newRarity = double.Parse(cmdArgs[2]);

                        plants[plant][0] = newRarity;
                    }
                    else if (command == "Reset")
                    {
                        plants[plant][1] = 0.0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }

                cmdArgs = Console.ReadLine().Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

            }
            foreach (var item in plants.ToDictionary(x => x.Key, x => x.Value))
            {
                if (timesRated.ContainsKey(item.Key))
                {
                    plants[item.Key][1] = item.Value[1] / timesRated[item.Key];
                }

            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine(($"- {item.Key}; Rarity: {(int)(item.Value[0])}; Rating: {item.Value[1]:f2}"));
            }

        }
    }
}