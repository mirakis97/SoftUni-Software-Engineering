using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Magic_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> newDeck = new List<string>();
            string cmd = Console.ReadLine();

            while (cmd != "Ready")
            {
                
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string comand = cmdArgs[0];
                string card = cmdArgs[1];

                if (comand == "Add")
                {  
                        newDeck.Add(card);
                    if (!newDeck.Contains(card))
                    {
                      Console.WriteLine("Card not found.");

                    }
                }
                else if (comand == "Inesert")
                {

                    newDeck.Insert(0, card);

                    if (!newDeck.Contains(card))
                    {
                        Console.WriteLine("Error!");
                    }
                    
                }
                else if (comand == "Remove")
                {
                        newDeck.Remove(card);

                    if (!newDeck.Contains(card))
                    {
                        Console.WriteLine("Card not found.");
                    }
                    
                }
                else if (comand == "Swap")
                {
                    string card2 = cmdArgs[2];
                    newDeck.IndexOf(card);
                    
                    
                }
                else if (comand == "Shuffle deck")
                {
                    newDeck.Reverse();
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", newDeck));
        }
    }
}
