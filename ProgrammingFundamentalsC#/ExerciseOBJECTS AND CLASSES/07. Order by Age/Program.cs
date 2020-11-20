using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<dynamic> list = new List<dynamic>();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                dynamic person = new { name, id, age };

                list.Add(person);

                command = Console.ReadLine();

            }
            if (command == "End")
            {
                var result = list.OrderBy(person => person.age);
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.name} with ID: {item.id} is {item.age} years old.");
                }
            }
        }
    }
}