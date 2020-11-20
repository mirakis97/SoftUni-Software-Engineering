using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstItems = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Craft")
            {
                string[] cmdArgs = cmd.Split(" - ");
                string comand = cmdArgs[0];
                string items = cmdArgs[1];

                if (comand == "Collect")
                {
                    if (!firstItems.Contains(items))
                    {
                        firstItems.Insert(0, items);
                    }
                }
                else if (comand == "Drop")
                { 
                    firstItems.Remove(items);
                }
                else if (comand == "Combine Items")
                {
                    string newItem = cmdArgs[1];
                    if (firstItems.Contains(items))
                    {
                        int index = firstItems.FindIndex(x => x == items);

                        //firstItems[index] = newItem;
                        firstItems.RemoveAt(index);
                        firstItems.Insert(index, newItem);
                    }
                }
                else if (comand == "Renew")
                {
                    if (firstItems.Contains(items))
                    {
                        firstItems.Remove(items);
                        firstItems.Add(items);
                    }
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", firstItems));
        }
    }
}
