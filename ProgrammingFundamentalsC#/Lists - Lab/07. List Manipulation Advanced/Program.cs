using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
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
                    case "CONTAINS":
                        Console.WriteLine(num.Contains(int.Parse(command[1])) ? "Yes" : "No such number");
                        break;
                    case "PRINTEVEN":
                        Console.WriteLine(string.Join(' ', num.Where(n => n % 2 == 0)));
                        break;
                    case "PRINTODD":
                        Console.WriteLine(string.Join(' ', num.Where(n => n % 2 != 0)));
                        break;
                    case "GETSUM":
                        Console.WriteLine(num.Sum());
                        break;
                    case "FILTER":
                        string result = string.Empty;
                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", num.Where(n => n < int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", num.Where(n => n > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", num.Where(n => n >= int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", num.Where(n => n <= int.Parse(command[2])));
                                break;
                        }
                        Console.WriteLine(result);
                        break;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

   
        }
    }
}