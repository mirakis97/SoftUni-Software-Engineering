using System;
using System.Linq;
using System.Collections.Generic;

//Class
namespace VehicleCatalogue
{
    class Catalogue
    {

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
        public double HorsePower { get; set; }
    }
}

//Main
namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> vehicleCatalogue = new List<Catalogue>();
            int count = 0;

            while (true)
            {
                string command = Console.ReadLine();
                string[] parts = command.Split("/");

                if (command == "end")
                {
                    break;
                }

                string type = parts[0];
                string brand = parts[1];
                string model = parts[2];
                double weight = double.Parse(parts[3]);
                double horsePower = double.Parse(parts[3]);

                Catalogue vehicle = new Catalogue();

                vehicle.Type = type;
                vehicle.Brand = brand;
                vehicle.Model = model;
                vehicle.Weight = weight;
                vehicle.HorsePower = horsePower;

                vehicleCatalogue.Add(vehicle);

            }

            List<Catalogue> sortedCatalogue = vehicleCatalogue.OrderBy(vehicle => vehicle.Brand).ToList();

            foreach (Catalogue vehicle in sortedCatalogue)
            {
                if (count == 0)
                {
                    Console.WriteLine("Cars:");
                    count++;
                }

                if (vehicle.Type == "Car")
                {
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
                }
            }

            foreach (Catalogue vehicle in sortedCatalogue)
            {
                if (count == 1 && vehicle.Type == "Truck")
                {
                    Console.WriteLine("Trucks:");
                    count++;
                }

                if (vehicle.Type == "Truck")
                {
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.Weight}kg");
                }
            }
        }
    }
}