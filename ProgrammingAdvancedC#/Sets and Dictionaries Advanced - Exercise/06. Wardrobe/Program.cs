using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var cloth = Console.ReadLine()
                    .Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = cloth[0];
                string[] allCloth = cloth.Skip(1).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                Dictionary<string, int> currentColorCloth = wardrobe[color];
                foreach (string item in allCloth)
                {
                    if (!currentColorCloth.ContainsKey(item))
                    {
                        currentColorCloth.Add(item, 0);
                    }
                    currentColorCloth[item]++;
                }
                
            }
            string[] searchData = Console.ReadLine().Split();

            foreach ((string color, Dictionary<string,int> colorData) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach ((string clothing, int count) in colorData)
                {

                    if (searchData[0] == color && searchData[1] == clothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");
                    }

                }
            }
        }
    }
}
