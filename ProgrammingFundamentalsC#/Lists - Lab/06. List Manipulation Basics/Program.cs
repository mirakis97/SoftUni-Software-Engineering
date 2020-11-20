using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0].ToUpper() != "END")
            {
                switch (command[0].ToUpper())
                {
                    case "ADD":
                        num.Add(int.Parse(command[1]));
                        break;
                    case "REMOVE":
                        num.Remove(int.Parse(command[1]));
                        break;
                    case "REMOVEAT":
                        num.RemoveAt(int.Parse(command[1]));
                        break;
                    case "INSERT":
                        num.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", num));
        }
    }
}
