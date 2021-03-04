using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P06FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string group = parts[2];
                    buyersByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    string birthdate = parts[3];
                    buyersByName[name] = new Citizen(name, age, birthdate, id);

                }
            }
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(line))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[line];

                buyer.BuyFood();
            }

            var total = buyersByName.Values.Sum(b => b.Food);
            Console.WriteLine(total);
        }
    }
}
