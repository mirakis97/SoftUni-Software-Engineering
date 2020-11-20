using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> people = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string guestName = cmdArg[0];
                if (cmdArg.Length > 3)
                {
                    if (people.Contains(guestName))
                    {
                        people.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
                else
                {
                    if (!people.Contains(guestName))
                    {
                        people.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
                            
        }
    }
}
