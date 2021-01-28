using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            HashSet<string> filters = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();


                switch (command[0])
                {
                    case "Add filter":
                        filters.Add($"{command[1]}:{command[2]}");
                        break;
                    case "Remove filter":
                        filters.Remove($"{command[1]}:{command[2]}");
                        break;
                }
            }

            foreach (var filter in filters)
            {
                string[] filterToken = filter.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = filterToken[0];
                string parameter = filterToken[1];

                if (type == "Starts with")
                {
                    names = names.Where(n => n.StartsWith(parameter) == false).ToList();
                }
                else if (type == "Ends with")
                {
                    names = names.Where(n => n.EndsWith(parameter) == false).ToList();
                }
                else if (type == "Lenght")
                {
                    int lenght = int.Parse(parameter);
                    names = names.Where(n => n.Length != lenght).ToList();
                }
                else if (type == "Contains")
                {
                    names = names.Where(n=>n.Contains(parameter) == false).ToList();
                }
            }

            Console.WriteLine(string.Join(' ', names));
        }
    }
}
