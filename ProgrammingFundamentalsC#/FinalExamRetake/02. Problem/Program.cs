using System;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine(); ;

                Regex pattern = new Regex(@"(\|)(?<bossName>[A-Z]{4,})\1:#(?<title>[A-Z][a-z]+ [a-z]+)#");
                MatchCollection boss = pattern.Matches(input);
                
                foreach (Match item in boss)
                {
                    if (item.Success)
                    {
                        string bossName = item.Groups["bossName"].Value;
                        string title = item.Groups["title"].Value;

                        Console.WriteLine($"{bossName}, The {title}");
                        Console.WriteLine($">> Strength: {bossName.Length}");
                        Console.WriteLine($">> Armour: {title.Length}");
                    }
                }
               if (!pattern.IsMatch(input))
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
