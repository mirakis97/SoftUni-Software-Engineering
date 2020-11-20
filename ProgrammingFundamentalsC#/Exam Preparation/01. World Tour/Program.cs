using System;
using System.Linq;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Travel")
            {
                string[] cmdArg = comand.Split(":");
                string firstComand = cmdArg[0];
                if (firstComand == "Add Stop")
                {
                    int index = int.Parse(cmdArg[1]);
                    string newCountry = cmdArg[2];

                    if (index >= 0)
                    {
                        country = country.Insert(index, newCountry);
                        Console.WriteLine(country);
                    }
                }
                else if (firstComand == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int endIndex = int.Parse(cmdArg[2]);

                    if ((startIndex >= 0 &&
                        startIndex < country.Length) && (endIndex >= 0  && endIndex < country.Length))
                    {
                        country = country.Remove(startIndex, endIndex - startIndex + 1);
                        
                    }
                    Console.WriteLine(country);
                }
                else if (firstComand == "Switch")
                {
                    string old = cmdArg[1];
                    string newString = cmdArg[2];

                    if (country.Contains(old))
                    {
                        country = country.Replace(old, newString);
                        Console.WriteLine(country);
                    }
                }


                comand = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {country}");
        }
    }
}
