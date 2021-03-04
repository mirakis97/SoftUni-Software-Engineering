using System;
using System.Collections.Generic;
using System.Linq;

namespace P4BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];
                if (type == nameof(Citizen))
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];
                    birthables.Add(new Citizen(name,age,id,birthdate));
                }
                else if (type == nameof(Pet))
                {
                    string name = parts[1];
                    string birthdate = parts[2];

                    birthables.Add(new Pet(name,birthdate));
                }

            }

            string fillterYear= Console.ReadLine();

            List<IBirthable> filtredYear = birthables.Where(p => p.Birthdate.EndsWith(fillterYear)).ToList();

            foreach (var birthable in filtredYear)
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}
