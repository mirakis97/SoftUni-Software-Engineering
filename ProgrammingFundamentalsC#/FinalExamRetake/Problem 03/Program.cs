using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> herosAndSpells = new Dictionary<string, string>();

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                string[] cmdArgs = comand.Split();
                string cmd = cmdArgs[0];
                string hero = cmdArgs[1];
                

                if (cmd == "Enroll")
                {
                    if (herosAndSpells.ContainsKey(hero))
                    {
                        Console.WriteLine($"{hero} is already enrolled.");
                    }
                    else
                    {
                        herosAndSpells.Add(hero, string.Empty);
                    }
                    
                }
                if (!herosAndSpells.ContainsKey(hero))
                {
                    Console.WriteLine($"{hero} doesn't exist.");
                }
                else if (cmd == "Learn")
                {
                    string spellName = cmdArgs[2];
                    if (herosAndSpells[hero].Contains(spellName))
                    {
                        Console.WriteLine($"{hero} has already learnt {spellName}.");
                    }
                    else
                    {
                        herosAndSpells[hero] = spellName;
                    }
                    
                }
                else if (cmd =="Unlearn")
                {
                    string spellName = cmdArgs[2];
                    if (!herosAndSpells.ContainsKey(hero))
                    {
                        Console.WriteLine($"{hero} doesn't exist.");
                    }
                    else if (!herosAndSpells[hero].Contains(spellName))
                    {
                        Console.WriteLine($"{hero} doesn't know {spellName}.");
                    }
                    else 
                    {
                        herosAndSpells[hero] = " ";
                    }
                   
                }
                
                comand = Console.ReadLine();
            }

            foreach (var item in herosAndSpells.OrderByDescending(x=>x.Value.Count()).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Heroes:");
                Console.WriteLine($"== {item.Key}: {item.Value}");
            }
        }
    }
}
