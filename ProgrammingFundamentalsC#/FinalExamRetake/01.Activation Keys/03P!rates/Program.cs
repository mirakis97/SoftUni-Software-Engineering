using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> city = new Dictionary<string, Dictionary<string, int>>();

            var command = Console.ReadLine();

            while (command != "Sail")
            {
                var info = command.Split("||", StringSplitOptions.RemoveEmptyEntries);
                var town = info[0];
                var population = int.Parse(info[1]);
                var gold = int.Parse(info[2]);
                if (city.ContainsKey(town))
                {
                    city[town]["population"] += population;
                    city[town]["gold"] += gold;
                }
                else
                {
                    city.Add(town, new Dictionary<string, int>()
                    {
                        {"population", population },
                        { "gold", gold }
                    });
                }
                command = Console.ReadLine();
            }

            command = Console.ReadLine();


            while (command != "End")
            {
                var events = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                var comand = events[0];
                if (comand == "Plunder")
                {
                    var town = events[1];
                    var people = int.Parse(events[2]);
                    var gold = int.Parse(events[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    city[town]["population"] -= people;
                    city[town]["gold"] -= gold;
                    if (city[town]["population"] <= 0 || city[town]["gold"] <= 0)
                    {
                        city.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (comand == "Prosper")
                {
                    var town = events[1];
                    var gold = int.Parse(events[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        break;
                    }
                    city[town]["gold"] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city[town]["gold"]} gold.");
                }

                command = Console.ReadLine();
            }

            if (city.Count > 0)
            {
                city = city.OrderByDescending(x => x.Value["gold"]).ThenBy(x => x.Key).ToDictionary(x => x.Key,v => v.Value);
                Console.WriteLine($"Ahoy, Captain! There are {city.Count} wealthy settlements to go to:");
                foreach (var towns in city)
                {
                    int popilation = towns.Value["population"];
                    int gold = towns.Value["gold"];
                    Console.WriteLine($"{towns.Key} -> Population: {popilation} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}
